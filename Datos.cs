namespace SDVE;

/*
 CONTEXTO GENERAL:
 Este archivo contiene los datos compartidos del Sistema Digital de Votación Estudiantil (SDVE).
 Guarda en memoria las convocatorias, los candidatos, el padrón de alumnos y los votos emitidos.
 También guarda al votante actual y las convocatorias que eligió para votar.
 Todos los formularios (Menú, Convocatorias, Papeleta, Resultados y Exportar) leen y escriben aquí.
 Incluye datos de demostración para que Resultados y Exportar muestren información desde el inicio.
*/

// Clase para un alumno del padrón
public class Alumno
{
    public string Codigo { get; set; } = "";
    public string Grupo { get; set; } = "";
    public string Carrera { get; set; } = "";
    public string Centro { get; set; } = "";
}

// Clase para un voto emitido
public class Voto
{
    public string Codigo { get; set; } = "";
    public string Grupo { get; set; } = "";
    public string Carrera { get; set; } = "";
    public string Centro { get; set; } = "";
    public string Convocatoria { get; set; } = "";
    public string Candidato { get; set; } = "";
    public bool EsWriteIn { get; set; }
}

internal static class Datos
{
    // Candidatos oficiales por convocatoria
    public static readonly Dictionary<string, string[]> Candidatos = new()
    {
        ["Sociedad de Alumnos"] = new[] { "Planilla Azul - Ana Torres", "Planilla Verde - Luis Ramírez", "Planilla Roja - María Gómez" },
        ["Consejo Universitario"] = new[] { "Carlos Mendoza", "Sofía Herrera", "Jorge Navarro" },
        ["Consejo de Representantes"] = new[] { "Valeria Cruz", "Diego Castillo", "Paola Ibarra" },
    };

    public static readonly string[] Carreras =
        { "Ing. en Computación", "Ing. Informática", "Ing. en Redes", "Lic. en Administración", "Lic. en Contaduría" };

    public static readonly string[] Centros = { "CUCEI", "CUCEA", "CUCS", "CUCSH" };

    // Nombres de las convocatorias
    public static readonly string[] Convocatorias =
    {
        "Sociedad de Alumnos",
        "Consejo Universitario",
        "Consejo de Representantes"
    };

    // Texto para cuando el alumno no elige a nadie y para write-in de demo
    public const string VotoBlanco = "Voto en blanco";
    public const string WriteInDemo = "Candidato No Registrado";

    // Listas en memoria
    public static List<Alumno> Padron = new();
    public static List<Voto> Votos = new();

    // Datos de la sesión de votación actual
    public static Alumno? VotanteActual;
    public static List<string> ConvocatoriasSeleccionadas = new();

    // Constructor estático: carga los datos de demostración al iniciar
    static Datos()
    {
        CargarDemo();
    }

    // Función para cargar datos de demostración
    public static void CargarDemo()
    {
        Padron.Clear();
        Votos.Clear();

        string[] grupos = { "1A", "1B", "2A", "2B" };
        Random rnd = new Random(1);

        // Padrón de ejemplo (200 alumnos)
        for (int i = 1; i <= 200; i++)
        {
            Padron.Add(new Alumno
            {
                Codigo = (219000000 + i).ToString(),
                Grupo = grupos[rnd.Next(grupos.Length)],
                Carrera = Carreras[rnd.Next(Carreras.Length)],
                Centro = Centros[rnd.Next(Centros.Length)]
            });
        }

        // Votos de ejemplo (más o menos 60% de participación por convocatoria)
        foreach (Alumno a in Padron)
        {
            foreach (string conv in Convocatorias)
            {
                if (rnd.NextDouble() > 0.6) continue;

                string[] lista = Candidatos[conv];
                double azar = rnd.NextDouble();

                string nombre;
                bool writeIn = false;

                if (azar < 0.08)
                {
                    nombre = VotoBlanco;
                }
                else if (azar < 0.13)
                {
                    nombre = WriteInDemo;
                    writeIn = true;
                }
                else
                {
                    nombre = lista[rnd.Next(lista.Length)];
                }

                Votos.Add(new Voto
                {
                    Codigo = a.Codigo,
                    Grupo = a.Grupo,
                    Carrera = a.Carrera,
                    Centro = a.Centro,
                    Convocatoria = conv,
                    Candidato = nombre,
                    EsWriteIn = writeIn
                });
            }
        }
    }

    // Función para borrar los votos de demostración
    public static void LimpiarVotos()
    {
        Votos.Clear();
    }

    // Función para cargar candidatos desde un archivo CSV (Convocatoria,Candidato)
    public static int CargarCandidatosCsv(string ruta)
    {
        Dictionary<string, List<string>> nuevos = new();
        int total = 0;

        foreach (string linea in File.ReadAllLines(ruta))
        {
            if (string.IsNullOrWhiteSpace(linea)) continue;

            string[] partes = linea.Split(',');
            if (partes.Length < 2) continue;

            string conv = partes[0].Trim();
            string nombre = partes[1].Trim();

            // Saltar encabezado
            if (conv.Equals("Convocatoria", StringComparison.OrdinalIgnoreCase)) continue;

            // Solo aceptar convocatorias válidas
            string? valida = Convocatorias.FirstOrDefault(c => c.Equals(conv, StringComparison.OrdinalIgnoreCase));
            if (valida == null || nombre == "") continue;

            if (!nuevos.ContainsKey(valida)) nuevos[valida] = new List<string>();
            nuevos[valida].Add(nombre);
            total++;
        }

        // Reemplazar solo las convocatorias que vienen en el archivo
        foreach (var par in nuevos)
        {
            Candidatos[par.Key] = par.Value.ToArray();
        }

        return total;
    }

    // Función para saber si un alumno ya votó en una convocatoria
    public static bool YaVoto(string codigo, string convocatoria)
    {
        return Votos.Any(v => v.Codigo == codigo && v.Convocatoria == convocatoria);
    }

    // Función para registrar un voto
    public static void RegistrarVoto(Alumno alumno, string convocatoria, string candidato, bool esWriteIn)
    {
        // Si el alumno no estaba en el padrón, se agrega
        if (!Padron.Any(p => p.Codigo == alumno.Codigo))
        {
            Padron.Add(alumno);
        }

        Votos.Add(new Voto
        {
            Codigo = alumno.Codigo,
            Grupo = alumno.Grupo,
            Carrera = alumno.Carrera,
            Centro = alumno.Centro,
            Convocatoria = convocatoria,
            Candidato = candidato,
            EsWriteIn = esWriteIn
        });
    }
}