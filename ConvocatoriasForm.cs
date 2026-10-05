namespace SDVE;

/*
 CONTEXTO GENERAL:
 Este formulario sirve para preparar la votación de un alumno.
 Aquí se eligen las convocatorias en las que va a votar (1, 2 o las 3),
 se captura su código, grupo, carrera y centro universitario,
 y se puede cargar una lista oficial de candidatos desde un archivo CSV.
 Al presionar "Iniciar papeleta" se validan los datos y se guardan en la clase Datos,
 para que la papeleta sepa quién vota y en qué elecciones.
*/

public partial class ConvocatoriasForm : Form
{
    public ConvocatoriasForm()
    {
        InitializeComponent();

        // Llenar los combos de carrera y centro
        cmbCarrera.Items.AddRange(Datos.Carreras);
        cmbCentro.Items.AddRange(Datos.Centros);
    }

    // Botón para cargar la lista de candidatos desde un CSV
    private void btnCargar_Click(object? sender, EventArgs e)
    {
        OpenFileDialog dialogo = new OpenFileDialog();
        dialogo.Filter = "Archivos CSV (*.csv)|*.csv";
        dialogo.Title = "Selecciona la lista de candidatos";

        if (dialogo.ShowDialog() != DialogResult.OK) return;

        try
        {
            int total = Datos.CargarCandidatosCsv(dialogo.FileName);

            if (total == 0)
            {
                MessageBox.Show("No se encontraron candidatos válidos en el archivo.\nFormato: Convocatoria,Candidato",
                    "Cargar lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Se cargaron " + total + " candidatos.",
                    "Cargar lista", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("No se pudo leer el archivo: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Botón para validar los datos e iniciar la papeleta
    private void btnIniciar_Click(object? sender, EventArgs e)
    {
        // Revisar qué convocatorias se eligieron
        List<string> elegidas = new();
        if (chkSociedad.Checked) elegidas.Add("Sociedad de Alumnos");
        if (chkConsejoU.Checked) elegidas.Add("Consejo Universitario");
        if (chkRepresentantes.Checked) elegidas.Add("Consejo de Representantes");

        if (elegidas.Count == 0)
        {
            MessageBox.Show("Elige al menos una convocatoria para votar.",
                "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Validar los datos del votante
        string codigo = txtCodigo.Text.Trim();
        string grupo = txtGrupo.Text.Trim();

        if (codigo == "" || grupo == "" || cmbCarrera.SelectedItem == null || cmbCentro.SelectedItem == null)
        {
            MessageBox.Show("Captura el código, grupo, carrera y centro universitario.",
                "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Revisar que el alumno no haya votado ya en las convocatorias elegidas
        List<string> yaVotadas = elegidas.Where(c => Datos.YaVoto(codigo, c)).ToList();

        if (yaVotadas.Count > 0)
        {
            MessageBox.Show("Este alumno ya votó en: " + string.Join(", ", yaVotadas) +
                ".\nQuita esas convocatorias para continuar.",
                "Voto repetido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Guardar los datos del votante y las convocatorias elegidas
        Datos.VotanteActual = new Alumno
        {
            Codigo = codigo,
            Grupo = grupo,
            Carrera = cmbCarrera.SelectedItem.ToString() ?? "",
            Centro = cmbCentro.SelectedItem.ToString() ?? ""
        };
        Datos.ConvocatoriasSeleccionadas = elegidas;

        // Abrir la papeleta
        PapeletaForm frm = new PapeletaForm();
        frm.ShowDialog();

        // Cerrar este formulario al terminar de votar
        Close();
    }
}