namespace SDVE;

partial class ResultadosForm
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
        split = new SplitContainer();
        grid = new DataGridView();
        colSegmento = new DataGridViewTextBoxColumn();
        colPadron = new DataGridViewTextBoxColumn();
        colVotos = new DataGridViewTextBoxColumn();
        colParticipacion = new DataGridViewTextBoxColumn();
        colAbstencion = new DataGridViewTextBoxColumn();
        panelGrafica = new Panel();
        panelFiltros = new FlowLayoutPanel();
        lblConvocatoria = new Label();
        cmbConvocatoria = new ComboBox();
        lblAgrupar = new Label();
        cmbAgrupar = new ComboBox();
        btnActualizar = new Button();
        panelHeader = new Panel();
        lblTitulo = new Label();
        tablaResumen = new TableLayoutPanel();
        lblPadron = new Label();
        lblVotos = new Label();
        lblParticipacion = new Label();
        lblAbstencion = new Label();
        ((System.ComponentModel.ISupportInitialize)split).BeginInit();
        split.Panel1.SuspendLayout();
        split.Panel2.SuspendLayout();
        split.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
        panelFiltros.SuspendLayout();
        panelHeader.SuspendLayout();
        tablaResumen.SuspendLayout();
        SuspendLayout();
        // 
        // split
        // 
        split.Dock = DockStyle.Fill;
        split.Location = new Point(0, 115);
        split.Name = "split";
        split.Panel1.Controls.Add(grid);
        split.Panel2.Controls.Add(panelGrafica);
        split.Size = new Size(1084, 465);
        split.SplitterDistance = 560;
        split.TabIndex = 0;
        // 
        // grid
        // 
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.BackgroundColor = SystemColors.Window;
        grid.Columns.AddRange(new DataGridViewColumn[] { colSegmento, colPadron, colVotos, colParticipacion, colAbstencion });
        grid.Dock = DockStyle.Fill;
        grid.Location = new Point(0, 0);
        grid.Name = "grid";
        grid.ReadOnly = true;
        grid.RowHeadersVisible = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.TabIndex = 0;
        // 
        // colSegmento
        // 
        colSegmento.HeaderText = "Segmento";
        colSegmento.Name = "colSegmento";
        colSegmento.ReadOnly = true;
        // 
        // colPadron
        // 
        colPadron.HeaderText = "Padrón";
        colPadron.Name = "colPadron";
        colPadron.ReadOnly = true;
        // 
        // colVotos
        // 
        colVotos.HeaderText = "Votos";
        colVotos.Name = "colVotos";
        colVotos.ReadOnly = true;
        // 
        // colParticipacion
        // 
        colParticipacion.HeaderText = "Participación %";
        colParticipacion.Name = "colParticipacion";
        colParticipacion.ReadOnly = true;
        // 
        // colAbstencion
        // 
        colAbstencion.HeaderText = "Abstención %";
        colAbstencion.Name = "colAbstencion";
        colAbstencion.ReadOnly = true;
        // 
        // panelGrafica
        // 
        panelGrafica.BackColor = Color.White;
        panelGrafica.Dock = DockStyle.Fill;
        panelGrafica.Location = new Point(0, 0);
        panelGrafica.Name = "panelGrafica";
        panelGrafica.TabIndex = 0;
        panelGrafica.Paint += panelGrafica_Paint;
        panelGrafica.Resize += panelGrafica_Resize;
        // 
        // panelFiltros
        // 
        panelFiltros.Controls.Add(lblConvocatoria);
        panelFiltros.Controls.Add(cmbConvocatoria);
        panelFiltros.Controls.Add(lblAgrupar);
        panelFiltros.Controls.Add(cmbAgrupar);
        panelFiltros.Controls.Add(btnActualizar);
        panelFiltros.Dock = DockStyle.Top;
        panelFiltros.Location = new Point(0, 60);
        panelFiltros.Name = "panelFiltros";
        panelFiltros.Padding = new Padding(10, 12, 0, 0);
        panelFiltros.Size = new Size(1084, 55);
        panelFiltros.TabIndex = 1;
        // 
        // lblConvocatoria
        // 
        lblConvocatoria.AutoSize = true;
        lblConvocatoria.Margin = new Padding(3, 6, 3, 0);
        lblConvocatoria.Name = "lblConvocatoria";
        lblConvocatoria.TabIndex = 0;
        lblConvocatoria.Text = "Convocatoria:";
        // 
        // cmbConvocatoria
        // 
        cmbConvocatoria.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbConvocatoria.FormattingEnabled = true;
        cmbConvocatoria.Name = "cmbConvocatoria";
        cmbConvocatoria.Size = new Size(210, 25);
        cmbConvocatoria.TabIndex = 1;
        // 
        // lblAgrupar
        // 
        lblAgrupar.AutoSize = true;
        lblAgrupar.Margin = new Padding(20, 6, 3, 0);
        lblAgrupar.Name = "lblAgrupar";
        lblAgrupar.TabIndex = 2;
        lblAgrupar.Text = "Agrupar por:";
        // 
        // cmbAgrupar
        // 
        cmbAgrupar.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbAgrupar.FormattingEnabled = true;
        cmbAgrupar.Items.AddRange(new object[] { "Grupo", "Carrera", "Centro Universitario" });
        cmbAgrupar.Name = "cmbAgrupar";
        cmbAgrupar.Size = new Size(170, 25);
        cmbAgrupar.TabIndex = 3;
        // 
        // btnActualizar
        // 
        btnActualizar.Margin = new Padding(20, 0, 0, 0);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(120, 30);
        btnActualizar.TabIndex = 4;
        btnActualizar.Text = "🔄 Actualizar";
        btnActualizar.UseVisualStyleBackColor = true;
        // 
        // panelHeader
        // 
        panelHeader.BackColor = Color.FromArgb(30, 60, 114);
        panelHeader.Controls.Add(lblTitulo);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(1084, 60);
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
        lblTitulo.Text = "📊  Resultados y participación";
        // 
        // tablaResumen
        // 
        tablaResumen.ColumnCount = 4;
        tablaResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tablaResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tablaResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tablaResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tablaResumen.Controls.Add(lblPadron, 0, 0);
        tablaResumen.Controls.Add(lblVotos, 1, 0);
        tablaResumen.Controls.Add(lblParticipacion, 2, 0);
        tablaResumen.Controls.Add(lblAbstencion, 3, 0);
        tablaResumen.Dock = DockStyle.Bottom;
        tablaResumen.Location = new Point(0, 580);
        tablaResumen.Name = "tablaResumen";
        tablaResumen.Padding = new Padding(10);
        tablaResumen.RowCount = 1;
        tablaResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tablaResumen.Size = new Size(1084, 80);
        tablaResumen.TabIndex = 3;
        // 
        // lblPadron
        // 
        lblPadron.BackColor = Color.FromArgb(235, 240, 250);
        lblPadron.Dock = DockStyle.Fill;
        lblPadron.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblPadron.Margin = new Padding(5);
        lblPadron.Name = "lblPadron";
        lblPadron.TabIndex = 0;
        lblPadron.Text = "Padrón total\n1,200";
        lblPadron.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblVotos
        // 
        lblVotos.BackColor = Color.FromArgb(235, 240, 250);
        lblVotos.Dock = DockStyle.Fill;
        lblVotos.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblVotos.Margin = new Padding(5);
        lblVotos.Name = "lblVotos";
        lblVotos.TabIndex = 1;
        lblVotos.Text = "Votos emitidos\n846";
        lblVotos.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblParticipacion
        // 
        lblParticipacion.BackColor = Color.FromArgb(235, 240, 250);
        lblParticipacion.Dock = DockStyle.Fill;
        lblParticipacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblParticipacion.Margin = new Padding(5);
        lblParticipacion.Name = "lblParticipacion";
        lblParticipacion.TabIndex = 2;
        lblParticipacion.Text = "Participación\n70.5 %";
        lblParticipacion.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblAbstencion
        // 
        lblAbstencion.BackColor = Color.FromArgb(235, 240, 250);
        lblAbstencion.Dock = DockStyle.Fill;
        lblAbstencion.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblAbstencion.Margin = new Padding(5);
        lblAbstencion.Name = "lblAbstencion";
        lblAbstencion.TabIndex = 3;
        lblAbstencion.Text = "Abstencionismo\n29.5 %";
        lblAbstencion.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // ResultadosForm
        // 
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1084, 660);
        Controls.Add(split);
        Controls.Add(panelFiltros);
        Controls.Add(panelHeader);
        Controls.Add(tablaResumen);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "ResultadosForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "SDVE - Resultados";
        split.Panel1.ResumeLayout(false);
        split.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)split).EndInit();
        split.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)grid).EndInit();
        panelFiltros.ResumeLayout(false);
        panelFiltros.PerformLayout();
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        tablaResumen.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private SplitContainer split;
    private DataGridView grid;
    private DataGridViewTextBoxColumn colSegmento;
    private DataGridViewTextBoxColumn colPadron;
    private DataGridViewTextBoxColumn colVotos;
    private DataGridViewTextBoxColumn colParticipacion;
    private DataGridViewTextBoxColumn colAbstencion;
    private Panel panelGrafica;
    private FlowLayoutPanel panelFiltros;
    private Label lblConvocatoria;
    private ComboBox cmbConvocatoria;
    private Label lblAgrupar;
    private ComboBox cmbAgrupar;
    private Button btnActualizar;
    private Panel panelHeader;
    private Label lblTitulo;
    private TableLayoutPanel tablaResumen;
    private Label lblPadron;
    private Label lblVotos;
    private Label lblParticipacion;
    private Label lblAbstencion;
}
