using System.ComponentModel;

namespace SDVE;

/// <summary>
/// Sección de la papeleta para una elección (se crea en tiempo de ejecución):
/// candidatos oficiales, candidato no registrado (write-in) y voto en blanco.
/// </summary>
[ToolboxItem(false)]
internal sealed class BallotSection : GroupBox
{
    private readonly List<RadioButton> opciones = new();
    private readonly RadioButton rbWriteIn = new() { Text = "Otro (candidato no registrado):", AutoSize = true, Margin = new Padding(3, 8, 3, 3) };
    private readonly TextBox txtWriteIn = new() { Width = 340, Enabled = false, PlaceholderText = "Escribe el nombre del candidato", Margin = new Padding(28, 0, 3, 3) };

    public BallotSection(string eleccion)
    {
        Text = eleccion;
        Width = 880;
        Height = 270;
        Font = new Font("Segoe UI", 10F, FontStyle.Bold);

        var flow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(15, 5, 0, 0),
            Font = new Font("Segoe UI", 10F),
        };

        foreach (var c in Datos.Candidatos[eleccion])
        {
            var rb = new RadioButton { Text = c, AutoSize = true, Margin = new Padding(3, 5, 3, 5) };
            opciones.Add(rb);
            flow.Controls.Add(rb);
        }

        // Todos los RadioButton comparten el mismo contenedor para que sean excluyentes entre sí.
        opciones.Add(rbWriteIn);
        flow.Controls.Add(rbWriteIn);
        flow.Controls.Add(txtWriteIn);
        rbWriteIn.CheckedChanged += (_, _) =>
        {
            txtWriteIn.Enabled = rbWriteIn.Checked;
            if (rbWriteIn.Checked) txtWriteIn.Focus();
        };

        var rbBlanco = new RadioButton { Text = "Voto en blanco / abstención", AutoSize = true, Margin = new Padding(3, 8, 3, 3) };
        opciones.Add(rbBlanco);
        flow.Controls.Add(rbBlanco);

        Controls.Add(flow);
    }

    public bool TieneSeleccion => opciones.Any(r => r.Checked);
    public bool WriteInVacio => rbWriteIn.Checked && string.IsNullOrWhiteSpace(txtWriteIn.Text);
}
