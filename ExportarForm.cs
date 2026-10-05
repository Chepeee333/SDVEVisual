using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Xml.Linq;

namespace SDVE;

/*
 CONTEXTO GENERAL:
 Este formulario exporta los resultados del Sistema Digital de Votación Estudiantil (SDVE) a un archivo CSV, JSON o XML.
 Lee los mismos datos que usa ResultadosForm (la clase Datos: padrón, candidatos y votos) y calcula, para las 3 convocatorias:
   1) Resumen: padrón, votos emitidos, participación y abstencionismo.
   2) Candidatos: votos y porcentaje de cada candidato registrado, de los votos en blanco y de los write-in (no registrados).
   3) Segmentos: padrón, votos, participación y abstencionismo por Grupo, por Carrera y por Centro Universitario.
 El formato se elige con los botones de opción; la extensión de la ruta se ajusta sola al cambiar de formato.
 Los porcentajes de candidatos se calculan sobre los votos emitidos de su convocatoria (incluye blancos y write-in).
*/

/// <summary>Módulo 4: exportación de resultados a CSV, JSON o XML.</summary>
public partial class ExportarForm : Form
{
    private enum Formato { Csv, Json, Xml }

    // Filas de resultados que se escriben en cualquiera de los 3 formatos
    private sealed record ResumenConv(string Convocatoria, int Padron, int Votos, double Participacion, double Abstencion);
    private sealed record FilaCandidato(string Convocatoria, string Candidato, string Tipo, int Votos, double Porcentaje);
    private sealed record FilaSegmento(string Convocatoria, string Agrupacion, string Segmento, int Padron, int Votos, double Participacion, double Abstencion);

    private static readonly CultureInfo Inv = CultureInfo.InvariantCulture;

    public ExportarForm()
    {
        InitializeComponent();

        // Ruta inicial: carpeta Documentos del usuario (la ruta del diseñador no existe en todas las PC)
        string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        txtRuta.Text = Path.Combine(documentos, "SDVE", "sdve_resultados.csv");

        // Conectar el cambio de formato (los botones de opción no traen evento en el diseñador)
        rbCsv.CheckedChanged += FormatoCambiado;
        rbJson.CheckedChanged += FormatoCambiado;
        rbXml.CheckedChanged += FormatoCambiado;
    }

    // Función para saber qué formato está elegido
    private Formato FormatoActual()
    {
        if (rbJson.Checked) return Formato.Json;
        if (rbXml.Checked) return Formato.Xml;
        return Formato.Csv;
    }

    // Función para obtener la extensión del formato elegido
    private string ExtensionActual() => FormatoActual() switch
    {
        Formato.Json => ".json",
        Formato.Xml => ".xml",
        _ => ".csv"
    };

    // Evento para cambiar la extensión de la ruta cuando se cambia de formato
    private void FormatoCambiado(object? sender, EventArgs e)
    {
        if (sender is RadioButton rb && !rb.Checked) return;

        string ruta = txtRuta.Text.Trim();
        if (ruta == "") return;

        txtRuta.Text = Path.ChangeExtension(ruta, ExtensionActual());
    }

    private void btnExaminar_Click(object? sender, EventArgs e)
    {
        string ruta = txtRuta.Text.Trim();
        string? carpeta = ruta == "" ? null : Path.GetDirectoryName(ruta);

        using var dlg = new SaveFileDialog
        {
            Filter = "CSV (*.csv)|*.csv|JSON (*.json)|*.json|XML (*.xml)|*.xml",
            FilterIndex = (int)FormatoActual() + 1,
            FileName = ruta == "" ? "sdve_resultados" : Path.GetFileName(ruta),
            AddExtension = true,
            OverwritePrompt = false // la confirmación de sobrescribir se hace al exportar
        };
        if (!string.IsNullOrEmpty(carpeta) && Directory.Exists(carpeta)) dlg.InitialDirectory = carpeta;

        if (dlg.ShowDialog(this) != DialogResult.OK) return;

        // Elegir el formato según la extensión escrita; si no es válida, según el filtro del diálogo
        string ext = Path.GetExtension(dlg.FileName).ToLowerInvariant();
        if (ext == ".json") rbJson.Checked = true;
        else if (ext == ".xml") rbXml.Checked = true;
        else if (ext == ".csv") rbCsv.Checked = true;
        else if (dlg.FilterIndex == 2) rbJson.Checked = true;
        else if (dlg.FilterIndex == 3) rbXml.Checked = true;
        else rbCsv.Checked = true;

        txtRuta.Text = dlg.FileName;
        FormatoCambiado(null, EventArgs.Empty);
    }

    private void btnExportar_Click(object? sender, EventArgs e)
    {
        // Validar la ruta
        string ruta = txtRuta.Text.Trim();
        if (ruta == "")
        {
            MessageBox.Show("Escribe o elige la ruta del archivo de destino.", "SDVE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRuta.Focus();
            return;
        }

        try
        {
            // La extensión siempre debe coincidir con el formato elegido
            ruta = Path.GetFullPath(Path.ChangeExtension(ruta, ExtensionActual()));
        }
        catch (Exception ex) when (ex is ArgumentException || ex is NotSupportedException || ex is PathTooLongException)
        {
            MessageBox.Show("La ruta del archivo no es válida.", "SDVE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtRuta.Focus();
            return;
        }
        txtRuta.Text = ruta;

        // Avisar si todavía no hay votos
        if (Datos.Votos.Count == 0)
        {
            DialogResult sinVotos = MessageBox.Show(
                "Todavía no hay votos registrados, los resultados saldrán en cero.\n¿Deseas exportar de todos modos?",
                "SDVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sinVotos != DialogResult.Yes) return;
        }

        // Confirmar si el archivo ya existe
        if (File.Exists(ruta))
        {
            DialogResult reemplazar = MessageBox.Show("El archivo ya existe.\n¿Deseas reemplazarlo?",
                "SDVE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (reemplazar != DialogResult.Yes) return;
        }

        try
        {
            // Calcular los resultados con los datos actuales
            CalcularResultados(out List<ResumenConv> resumen, out List<FilaCandidato> candidatos, out List<FilaSegmento> segmentos);

            // Crear la carpeta si no existe
            string? carpeta = Path.GetDirectoryName(ruta);
            if (!string.IsNullOrEmpty(carpeta)) Directory.CreateDirectory(carpeta);

            switch (FormatoActual())
            {
                case Formato.Json: EscribirJson(ruta, resumen, candidatos, segmentos); break;
                case Formato.Xml: EscribirXml(ruta, resumen, candidatos, segmentos); break;
                default: EscribirCsv(ruta, resumen, candidatos, segmentos); break;
            }
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            MessageBox.Show("No se pudo guardar el archivo:\n" + ex.Message, "SDVE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        DialogResult abrir = MessageBox.Show("Resultados exportados correctamente en:\n" + ruta + "\n\n¿Deseas abrir la carpeta?",
            "SDVE", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        if (abrir == DialogResult.Yes)
        {
            Process.Start(new ProcessStartInfo("explorer.exe", "/select,\"" + ruta + "\"") { UseShellExecute = true });
        }
    }

    // ---------------------------------------------------------------------
    // Cálculo de resultados (mismas reglas que ResultadosForm)
    // ---------------------------------------------------------------------

    // Función para calcular el porcentaje de una parte respecto al total (2 decimales)
    private static double Porcentaje(int parte, int total) => total == 0 ? 0 : Math.Round(parte * 100.0 / total, 2);

    // Función para calcular el resumen, los candidatos y los segmentos de las 3 convocatorias
    private static void CalcularResultados(out List<ResumenConv> resumen, out List<FilaCandidato> candidatos, out List<FilaSegmento> segmentos)
    {
        resumen = new List<ResumenConv>();
        candidatos = new List<FilaCandidato>();
        segmentos = new List<FilaSegmento>();

        // Formas de agrupar: nombre, clave del alumno (padrón) y clave del voto
        var agrupaciones = new List<(string nombre, Func<Alumno, string> alumno, Func<Voto, string> voto)>
        {
            ("Grupo", a => a.Grupo, v => v.Grupo),
            ("Carrera", a => a.Carrera, v => v.Carrera),
            ("Centro", a => a.Centro, v => v.Centro)
        };

        foreach (string conv in Datos.Convocatorias)
        {
            List<Voto> votosConv = Datos.Votos.Where(v => v.Convocatoria == conv).ToList();
            int padron = Datos.Padron.Count;
            int emitidos = votosConv.Count;
            double participacion = Porcentaje(emitidos, padron);
            double abstencion = padron == 0 ? 0 : Math.Round(100 - emitidos * 100.0 / padron, 2);

            resumen.Add(new ResumenConv(conv, padron, emitidos, participacion, abstencion));

            // Candidatos registrados (incluye los que tienen 0 votos) y cualquier nombre con votos fuera de la lista actual
            Dictionary<string, int> conteo = votosConv
                .Where(v => !v.EsWriteIn && v.Candidato != Datos.VotoBlanco)
                .GroupBy(v => v.Candidato)
                .ToDictionary(g => g.Key, g => g.Count());

            Datos.Candidatos.TryGetValue(conv, out string[]? lista);
            IEnumerable<string> nombres = (lista ?? Array.Empty<string>()).Union(conteo.Keys);

            var registrados = nombres
                .Select(n => (nombre: n, votos: conteo.TryGetValue(n, out int c) ? c : 0))
                .OrderByDescending(x => x.votos)
                .ThenBy(x => x.nombre);

            foreach (var r in registrados)
                candidatos.Add(new FilaCandidato(conv, r.nombre, "Registrado", r.votos, Porcentaje(r.votos, emitidos)));

            // Votos en blanco
            int blancos = votosConv.Count(v => !v.EsWriteIn && v.Candidato == Datos.VotoBlanco);
            candidatos.Add(new FilaCandidato(conv, Datos.VotoBlanco, "Blanco", blancos, Porcentaje(blancos, emitidos)));

            // Candidatos no registrados (write-in)
            var writeIn = votosConv
                .Where(v => v.EsWriteIn)
                .GroupBy(v => v.Candidato)
                .Select(g => (nombre: g.Key, votos: g.Count()))
                .OrderByDescending(x => x.votos)
                .ThenBy(x => x.nombre);

            foreach (var w in writeIn)
                candidatos.Add(new FilaCandidato(conv, w.nombre, "Write-in", w.votos, Porcentaje(w.votos, emitidos)));

            // Participación y abstencionismo por Grupo, Carrera y Centro
            foreach (var agr in agrupaciones)
            {
                foreach (var seg in Datos.Padron.GroupBy(agr.alumno).OrderBy(g => g.Key))
                {
                    int padronSeg = seg.Count();
                    int votosSeg = votosConv.Count(v => agr.voto(v) == seg.Key);
                    double part = Porcentaje(votosSeg, padronSeg);
                    double abs = padronSeg == 0 ? 0 : Math.Round(100 - votosSeg * 100.0 / padronSeg, 2);

                    segmentos.Add(new FilaSegmento(conv, agr.nombre, seg.Key, padronSeg, votosSeg, part, abs));
                }
            }
        }
    }

    // ---------------------------------------------------------------------
    // Escritura de archivos
    // ---------------------------------------------------------------------

    // Función para escribir un número con punto decimal sin importar el idioma de Windows
    private static string Num(double valor) => valor.ToString("0.00", Inv);

    // Función para escapar un texto en CSV (comillas si trae coma, comillas o salto de línea)
    private static string CsvTexto(string texto)
    {
        if (texto.IndexOfAny(new[] { ',', '"', '\r', '\n' }) < 0) return texto;
        return "\"" + texto.Replace("\"", "\"\"") + "\"";
    }

    // Función para unir los campos de una fila CSV
    private static string CsvFila(params object[] campos)
    {
        return string.Join(",", campos.Select(c => c is double d ? Num(d) : CsvTexto(Convert.ToString(c, Inv) ?? "")));
    }

    // Función para exportar a CSV: 3 tablas (resumen, candidatos y segmentos) separadas por una línea en blanco
    private static void EscribirCsv(string ruta, List<ResumenConv> resumen, List<FilaCandidato> candidatos, List<FilaSegmento> segmentos)
    {
        var sb = new StringBuilder();

        sb.AppendLine("# RESUMEN POR CONVOCATORIA");
        sb.AppendLine("Convocatoria,Padron,VotosEmitidos,ParticipacionPct,AbstencionismoPct");
        foreach (var r in resumen)
            sb.AppendLine(CsvFila(r.Convocatoria, r.Padron, r.Votos, r.Participacion, r.Abstencion));

        sb.AppendLine();
        sb.AppendLine("# VOTOS POR CANDIDATO");
        sb.AppendLine("Convocatoria,Candidato,Tipo,Votos,PorcentajePct");
        foreach (var c in candidatos)
            sb.AppendLine(CsvFila(c.Convocatoria, c.Candidato, c.Tipo, c.Votos, c.Porcentaje));

        sb.AppendLine();
        sb.AppendLine("# PARTICIPACION POR GRUPO, CARRERA Y CENTRO");
        sb.AppendLine("Convocatoria,Agrupacion,Segmento,Padron,Votos,ParticipacionPct,AbstencionismoPct");
        foreach (var s in segmentos)
            sb.AppendLine(CsvFila(s.Convocatoria, s.Agrupacion, s.Segmento, s.Padron, s.Votos, s.Participacion, s.Abstencion));

        // UTF-8 con BOM para que Excel muestre bien los acentos
        File.WriteAllText(ruta, sb.ToString(), new UTF8Encoding(true));
    }

    // Función para exportar a JSON: una lista de convocatorias con sus candidatos y segmentos
    private static void EscribirJson(string ruta, List<ResumenConv> resumen, List<FilaCandidato> candidatos, List<FilaSegmento> segmentos)
    {
        var convocatorias = resumen.Select(r => new
        {
            nombre = r.Convocatoria,
            padron = r.Padron,
            votosEmitidos = r.Votos,
            participacionPct = r.Participacion,
            abstencionismoPct = r.Abstencion,
            candidatos = candidatos.Where(c => c.Convocatoria == r.Convocatoria)
                .Select(c => new { nombre = c.Candidato, tipo = c.Tipo, votos = c.Votos, porcentajePct = c.Porcentaje }),
            porGrupo = SegmentosJson(segmentos, r.Convocatoria, "Grupo"),
            porCarrera = SegmentosJson(segmentos, r.Convocatoria, "Carrera"),
            porCentro = SegmentosJson(segmentos, r.Convocatoria, "Centro")
        });

        var raiz = new
        {
            sistema = "SDVE",
            generado = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", Inv),
            convocatorias
        };

        var opciones = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // deja los acentos tal cual
        };

        File.WriteAllText(ruta, JsonSerializer.Serialize(raiz, opciones), new UTF8Encoding(false));
    }

    // Función auxiliar para armar los segmentos de una convocatoria y una agrupación en JSON
    private static IEnumerable<object> SegmentosJson(List<FilaSegmento> segmentos, string conv, string agrupacion)
    {
        return segmentos.Where(s => s.Convocatoria == conv && s.Agrupacion == agrupacion)
            .Select(s => (object)new
            {
                segmento = s.Segmento,
                padron = s.Padron,
                votos = s.Votos,
                participacionPct = s.Participacion,
                abstencionismoPct = s.Abstencion
            });
    }

    // Función para exportar a XML con la misma estructura que el JSON
    private static void EscribirXml(string ruta, List<ResumenConv> resumen, List<FilaCandidato> candidatos, List<FilaSegmento> segmentos)
    {
        var raiz = new XElement("Resultados",
            new XAttribute("sistema", "SDVE"),
            new XAttribute("generado", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", Inv)));

        foreach (var r in resumen)
        {
            var conv = new XElement("Convocatoria",
                new XAttribute("nombre", r.Convocatoria),
                new XElement("Padron", r.Padron),
                new XElement("VotosEmitidos", r.Votos),
                new XElement("ParticipacionPct", Num(r.Participacion)),
                new XElement("AbstencionismoPct", Num(r.Abstencion)));

            var xmlCandidatos = new XElement("Candidatos");
            foreach (var c in candidatos.Where(c => c.Convocatoria == r.Convocatoria))
            {
                xmlCandidatos.Add(new XElement("Candidato",
                    new XAttribute("nombre", c.Candidato),
                    new XAttribute("tipo", c.Tipo),
                    new XElement("Votos", c.Votos),
                    new XElement("PorcentajePct", Num(c.Porcentaje))));
            }
            conv.Add(xmlCandidatos);

            foreach (string agr in new[] { "Grupo", "Carrera", "Centro" })
            {
                var xmlSegmentos = new XElement("Por" + agr);
                foreach (var s in segmentos.Where(s => s.Convocatoria == r.Convocatoria && s.Agrupacion == agr))
                {
                    xmlSegmentos.Add(new XElement("Segmento",
                        new XAttribute("nombre", s.Segmento),
                        new XElement("Padron", s.Padron),
                        new XElement("Votos", s.Votos),
                        new XElement("ParticipacionPct", Num(s.Participacion)),
                        new XElement("AbstencionismoPct", Num(s.Abstencion))));
                }
                conv.Add(xmlSegmentos);
            }

            raiz.Add(conv);
        }

        new XDocument(new XDeclaration("1.0", "utf-8", null), raiz).Save(ruta);
    }
}
