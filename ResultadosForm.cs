namespace SDVE;

/*
 CONTEXTO GENERAL:
 Este formulario muestra los resultados de la votación del Sistema Digital de Votación Estudiantil (SDVE).
 El usuario elige una convocatoria y cómo agrupar los datos (por Grupo, Carrera o Centro Universitario).
 Con los votos guardados en la clase Datos se calcula, para cada segmento, el padrón, los votos emitidos,
 el porcentaje de participación y el porcentaje de abstencionismo.
 Los resultados se muestran en una tabla, en las tarjetas de resumen y en una gráfica de barras
 dibujada en un panel (participación por segmento).
*/

public partial class ResultadosForm : Form
{
    // Datos que usa la gráfica: nombre del segmento y su participación
    private List<(string nombre, double participacion)> datosGrafica = new();

    public ResultadosForm()
    {
        InitializeComponent();

        // Llenar el combo de convocatorias y elegir valores iniciales
        cmbConvocatoria.Items.AddRange(Datos.Convocatorias);
        cmbConvocatoria.SelectedIndex = 0;
        cmbAgrupar.SelectedIndex = 0;

        // Conectar los eventos (el botón y los combos no traen evento en el diseñador)
        btnActualizar.Click += (s, e) => Actualizar();
        cmbConvocatoria.SelectedIndexChanged += (s, e) => Actualizar();
        cmbAgrupar.SelectedIndexChanged += (s, e) => Actualizar();

        Actualizar();
    }

    // Función para obtener la clave del segmento según cómo se agrupa
    private string ObtenerClave(string grupo, string carrera, string centro)
    {
        if (cmbAgrupar.SelectedIndex == 0) return grupo;
        if (cmbAgrupar.SelectedIndex == 1) return carrera;
        return centro;
    }

    // Función para calcular los resultados y actualizar tabla, tarjetas y gráfica
    private void Actualizar()
    {
        string conv = cmbConvocatoria.Text;
        if (conv == "") return;

        // Votos de la convocatoria elegida
        List<Voto> votosConv = Datos.Votos.Where(v => v.Convocatoria == conv).ToList();

        grid.Rows.Clear();
        datosGrafica.Clear();

        // Agrupar el padrón por segmento
        var segmentos = Datos.Padron
            .GroupBy(a => ObtenerClave(a.Grupo, a.Carrera, a.Centro))
            .OrderBy(g => g.Key);

        foreach (var seg in segmentos)
        {
            int padron = seg.Count();
            int votos = votosConv.Count(v => ObtenerClave(v.Grupo, v.Carrera, v.Centro) == seg.Key);

            double participacion = padron == 0 ? 0 : votos * 100.0 / padron;
            double abstencion = 100 - participacion;

            grid.Rows.Add(seg.Key, padron, votos,
                participacion.ToString("0.0") + " %",
                abstencion.ToString("0.0") + " %");

            datosGrafica.Add((seg.Key, participacion));
        }

        // Totales para las tarjetas de resumen
        int padronTotal = Datos.Padron.Count;
        int votosTotal = votosConv.Count;
        double partTotal = padronTotal == 0 ? 0 : votosTotal * 100.0 / padronTotal;
        double absTotal = 100 - partTotal;

        lblPadron.Text = "Padrón total\n" + padronTotal.ToString("N0");
        lblVotos.Text = "Votos emitidos\n" + votosTotal.ToString("N0");
        lblParticipacion.Text = "Participación\n" + partTotal.ToString("0.0") + " %";
        lblAbstencion.Text = "Abstencionismo\n" + absTotal.ToString("0.0") + " %";

        // Volver a dibujar la gráfica
        panelGrafica.Invalidate();
    }

    // Función para dibujar la gráfica de barras
    private void panelGrafica_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.Clear(Color.White);

        using Font fuenteTitulo = new Font("Segoe UI", 11F, FontStyle.Bold);
        using Font fuente = new Font("Segoe UI", 8F);
        using SolidBrush azul = new SolidBrush(Color.FromArgb(30, 60, 114));

        if (datosGrafica.Count == 0)
        {
            g.DrawString("Sin datos para mostrar", fuenteTitulo, Brushes.Gray, 10, 10);
            return;
        }

        // Título de la gráfica
        g.DrawString("Participación (%) por " + cmbAgrupar.Text, fuenteTitulo, Brushes.Black, 10, 5);

        int margenIzq = 45;
        int margenSup = 40;
        int margenInf = 60;
        int ancho = panelGrafica.Width - margenIzq - 20;
        int alto = panelGrafica.Height - margenSup - margenInf;
        if (ancho <= 0 || alto <= 0) return;

        int baseY = margenSup + alto;

        // Líneas guía en 0, 25, 50, 75 y 100 %
        for (int i = 0; i <= 4; i++)
        {
            int y = baseY - (alto * i / 4);
            g.DrawLine(Pens.LightGray, margenIzq, y, margenIzq + ancho, y);
            g.DrawString((i * 25) + "%", fuente, Brushes.Black, 5, y - 8);
        }

        // Ejes
        g.DrawLine(Pens.Black, margenIzq, margenSup, margenIzq, baseY);
        g.DrawLine(Pens.Black, margenIzq, baseY, margenIzq + ancho, baseY);

        // Barras
        int espacio = ancho / datosGrafica.Count;
        int anchoBarra = Math.Max(espacio * 2 / 3, 5);

        using StringFormat centro = new StringFormat();
        centro.Alignment = StringAlignment.Center;
        centro.Trimming = StringTrimming.EllipsisCharacter;

        for (int i = 0; i < datosGrafica.Count; i++)
        {
            var dato = datosGrafica[i];
            int x = margenIzq + i * espacio + (espacio - anchoBarra) / 2;
            int h = (int)(dato.participacion / 100.0 * alto);

            // Barra
            g.FillRectangle(azul, x, baseY - h, anchoBarra, h);

            // Porcentaje arriba de la barra
            g.DrawString(dato.participacion.ToString("0.0") + "%", fuente, Brushes.Black, x - 4, baseY - h - 16);

            // Nombre del segmento abajo
            RectangleF zona = new RectangleF(margenIzq + i * espacio, baseY + 5, espacio, margenInf - 10);
            g.DrawString(dato.nombre, fuente, Brushes.Black, zona, centro);
        }
    }

    // Función para redibujar la gráfica al cambiar el tamaño
    private void panelGrafica_Resize(object? sender, EventArgs e)
    {
        panelGrafica.Invalidate();
    }
}