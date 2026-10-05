namespace SDVE;

partial class MenuPrincipalForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        tablaOpciones = new TableLayoutPanel();
        btnConvocatorias = new Button();
        btnPapeleta = new Button();
        btnResultados = new Button();
        btnExportar = new Button();
        panelPie = new Panel();
        btnSalir = new Button();
        panelHeader = new Panel();
        lblTitulo = new Label();
        tablaOpciones.SuspendLayout();
        panelPie.SuspendLayout();
        panelHeader.SuspendLayout();
        SuspendLayout();
        //
        // tablaOpciones
        //
        tablaOpciones.ColumnCount = 2;
        tablaOpciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaOpciones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaOpciones.Controls.Add(btnConvocatorias, 0, 0);
        tablaOpciones.Controls.Add(btnPapeleta, 1, 0);
        tablaOpciones.Controls.Add(btnResultados, 0, 1);
        tablaOpciones.Controls.Add(btnExportar, 1, 1);
        tablaOpciones.Dock = DockStyle.Fill;
        tablaOpciones.Location = new Point(0, 60);
        tablaOpciones.Name = "tablaOpciones";
        tablaOpciones.Padding = new Padding(30);
        tablaOpciones.RowCount = 2;
        tablaOpciones.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tablaOpciones.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        tablaOpciones.Size = new Size(624, 326);
        tablaOpciones.TabIndex = 0;
        //
        // btnConvocatorias
        //
        btnConvocatorias.BackColor = Color.FromArgb(235, 240, 250);
        btnConvocatorias.Dock = DockStyle.Fill;
        btnConvocatorias.FlatStyle = FlatStyle.Flat;
        btnConvocatorias.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        btnConvocatorias.Margin = new Padding(10);
        btnConvocatorias.Name = "btnConvocatorias";
        btnConvocatorias.TabIndex = 0;
        btnConvocatorias.Text = "📋  Convocatorias\ny votante";
        btnConvocatorias.UseVisualStyleBackColor = false;
        btnConvocatorias.Click += btnConvocatorias_Click;
        //
        // btnPapeleta
        //
        btnPapeleta.BackColor = Color.FromArgb(235, 240, 250);
        btnPapeleta.Dock = DockStyle.Fill;
        btnPapeleta.FlatStyle = FlatStyle.Flat;
        btnPapeleta.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        btnPapeleta.Margin = new Padding(10);
        btnPapeleta.Name = "btnPapeleta";
        btnPapeleta.TabIndex = 1;
        btnPapeleta.Text = "🗳  Papeleta\n(demo)";
        btnPapeleta.UseVisualStyleBackColor = false;
        btnPapeleta.Click += btnPapeleta_Click;
        //
        // btnResultados
        //
        btnResultados.BackColor = Color.FromArgb(235, 240, 250);
        btnResultados.Dock = DockStyle.Fill;
        btnResultados.FlatStyle = FlatStyle.Flat;
        btnResultados.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        btnResultados.Margin = new Padding(10);
        btnResultados.Name = "btnResultados";
        btnResultados.TabIndex = 2;
        btnResultados.Text = "📊  Resultados";
        btnResultados.UseVisualStyleBackColor = false;
        btnResultados.Click += btnResultados_Click;
        //
        // btnExportar
        //
        btnExportar.BackColor = Color.FromArgb(235, 240, 250);
        btnExportar.Dock = DockStyle.Fill;
        btnExportar.FlatStyle = FlatStyle.Flat;
        btnExportar.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        btnExportar.Margin = new Padding(10);
        btnExportar.Name = "btnExportar";
        btnExportar.TabIndex = 3;
        btnExportar.Text = "💾  Exportar";
        btnExportar.UseVisualStyleBackColor = false;
        btnExportar.Click += btnExportar_Click;
        //
        // panelPie
        //
        panelPie.Controls.Add(btnSalir);
        panelPie.Dock = DockStyle.Bottom;
        panelPie.Location = new Point(0, 386);
        panelPie.Name = "panelPie";
        panelPie.Size = new Size(624, 55);
        panelPie.TabIndex = 1;
        //
        // btnSalir
        //
        btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSalir.Location = new Point(510, 10);
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new Size(100, 34);
        btnSalir.TabIndex = 0;
        btnSalir.Text = "Salir";
        btnSalir.UseVisualStyleBackColor = true;
        btnSalir.Click += btnSalir_Click;
        //
        // panelHeader
        //
        panelHeader.BackColor = Color.FromArgb(30, 60, 114);
        panelHeader.Controls.Add(lblTitulo);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(624, 60);
        panelHeader.TabIndex = 2;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 14);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "🗳  Sistema Digital de Votación Estudiantil";
        //
        // MenuPrincipalForm
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(624, 441);
        Controls.Add(tablaOpciones);
        Controls.Add(panelPie);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MenuPrincipalForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SDVE - Sistema Digital de Votación Estudiantil";
        tablaOpciones.ResumeLayout(false);
        panelPie.ResumeLayout(false);
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tablaOpciones;
    private Button btnConvocatorias;
    private Button btnPapeleta;
    private Button btnResultados;
    private Button btnExportar;
    private Panel panelPie;
    private Button btnSalir;
    private Panel panelHeader;
    private Label lblTitulo;
}
