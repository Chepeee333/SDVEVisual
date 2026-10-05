namespace SDVE;

/*
 CONTEXTO GENERAL:
 Este formulario es el menú principal del Sistema Digital de Votación Estudiantil (SDVE).
 Desde aquí se abren las demás pantallas: Convocatorias y votante, Papeleta, Resultados y Exportar.
 No tiene lógica de votación, solo sirve para navegar entre los formularios.
 La papeleta solo se puede abrir si ya se eligieron convocatorias y se capturaron los datos del votante.
*/

public partial class MenuPrincipalForm : Form
{
    public MenuPrincipalForm()
    {
        InitializeComponent();
    }

    // Botón para abrir la pantalla de convocatorias y votante
    private void btnConvocatorias_Click(object? sender, EventArgs e)
    {
        ConvocatoriasForm frm = new ConvocatoriasForm();
        frm.ShowDialog();
    }

    // Botón para abrir la papeleta (solo si ya hay votante y convocatorias)
    private void btnPapeleta_Click(object? sender, EventArgs e)
    {
        if (Datos.VotanteActual == null || Datos.ConvocatoriasSeleccionadas.Count == 0)
        {
            MessageBox.Show("Primero entra a 'Convocatorias y votante' para elegir las convocatorias y capturar tus datos.",
                "Papeleta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        PapeletaForm frm = new PapeletaForm();
        frm.ShowDialog();
    }

    // Botón para abrir los resultados
    private void btnResultados_Click(object? sender, EventArgs e)
    {
        ResultadosForm frm = new ResultadosForm();
        frm.ShowDialog();
    }

    // Botón para abrir la exportación
    private void btnExportar_Click(object? sender, EventArgs e)
    {
        ExportarForm frm = new ExportarForm();
        frm.ShowDialog();
    }

    // Botón para salir del programa
    private void btnSalir_Click(object? sender, EventArgs e)
    {
        Close();
    }
}