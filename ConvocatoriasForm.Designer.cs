namespace SDVE;

partial class ConvocatoriasForm
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
        panelContenido = new Panel();
        gbConvocatorias = new GroupBox();
        flowConvocatorias = new FlowLayoutPanel();
        chkSociedad = new CheckBox();
        chkConsejoU = new CheckBox();
        chkRepresentantes = new CheckBox();
        gbListas = new GroupBox();
        btnCargar = new Button();
        gbVotante = new GroupBox();
        tablaVotante = new TableLayoutPanel();
        lblCodigo = new Label();
        txtCodigo = new TextBox();
        lblGrupo = new Label();
        txtGrupo = new TextBox();
        lblCarrera = new Label();
        cmbCarrera = new ComboBox();
        lblCentro = new Label();
        cmbCentro = new ComboBox();
        btnIniciar = new Button();
        panelHeader = new Panel();
        lblTitulo = new Label();
        panelContenido.SuspendLayout();
        gbConvocatorias.SuspendLayout();
        flowConvocatorias.SuspendLayout();
        gbListas.SuspendLayout();
        gbVotante.SuspendLayout();
        tablaVotante.SuspendLayout();
        panelHeader.SuspendLayout();
        SuspendLayout();
        // 
        // panelContenido
        // 
        panelContenido.Controls.Add(gbConvocatorias);
        panelContenido.Controls.Add(gbListas);
        panelContenido.Controls.Add(gbVotante);
        panelContenido.Controls.Add(btnIniciar);
        panelContenido.Dock = DockStyle.Fill;
        panelContenido.Location = new Point(0, 60);
        panelContenido.Name = "panelContenido";
        panelContenido.Size = new Size(984, 321);
        panelContenido.TabIndex = 0;
        // 
        // gbConvocatorias
        // 
        gbConvocatorias.Controls.Add(flowConvocatorias);
        gbConvocatorias.Location = new Point(20, 20);
        gbConvocatorias.Name = "gbConvocatorias";
        gbConvocatorias.Size = new Size(430, 160);
        gbConvocatorias.TabIndex = 0;
        gbConvocatorias.TabStop = false;
        gbConvocatorias.Text = "Procesos activos a votar (elige 1, 2 o los 3)";
        // 
        // flowConvocatorias
        // 
        flowConvocatorias.Controls.Add(chkSociedad);
        flowConvocatorias.Controls.Add(chkConsejoU);
        flowConvocatorias.Controls.Add(chkRepresentantes);
        flowConvocatorias.Dock = DockStyle.Fill;
        flowConvocatorias.FlowDirection = FlowDirection.TopDown;
        flowConvocatorias.Location = new Point(3, 26);
        flowConvocatorias.Name = "flowConvocatorias";
        flowConvocatorias.Padding = new Padding(15, 10, 0, 0);
        flowConvocatorias.Size = new Size(424, 131);
        flowConvocatorias.TabIndex = 0;
        // 
        // chkSociedad
        // 
        chkSociedad.AutoSize = true;
        chkSociedad.Location = new Point(18, 18);
        chkSociedad.Margin = new Padding(3, 8, 3, 8);
        chkSociedad.Name = "chkSociedad";
        chkSociedad.Size = new Size(197, 27);
        chkSociedad.TabIndex = 0;
        chkSociedad.Text = "Sociedad de Alumnos";
        chkSociedad.UseVisualStyleBackColor = true;
        // 
        // chkConsejoU
        // 
        chkConsejoU.AutoSize = true;
        chkConsejoU.Location = new Point(18, 61);
        chkConsejoU.Margin = new Padding(3, 8, 3, 8);
        chkConsejoU.Name = "chkConsejoU";
        chkConsejoU.Size = new Size(193, 27);
        chkConsejoU.TabIndex = 1;
        chkConsejoU.Text = "Consejo Universitario";
        chkConsejoU.UseVisualStyleBackColor = true;
        // 
        // chkRepresentantes
        // 
        chkRepresentantes.AutoSize = true;
        chkRepresentantes.Location = new Point(221, 18);
        chkRepresentantes.Margin = new Padding(3, 8, 3, 8);
        chkRepresentantes.Name = "chkRepresentantes";
        chkRepresentantes.Size = new Size(239, 27);
        chkRepresentantes.TabIndex = 2;
        chkRepresentantes.Text = "Consejo de Representantes";
        chkRepresentantes.UseVisualStyleBackColor = true;
        // 
        // gbListas
        // 
        gbListas.Controls.Add(btnCargar);
        gbListas.Location = new Point(20, 195);
        gbListas.Name = "gbListas";
        gbListas.Size = new Size(430, 80);
        gbListas.TabIndex = 1;
        gbListas.TabStop = false;
        gbListas.Text = "Listas oficiales de candidatos";
        // 
        // btnCargar
        // 
        btnCargar.Location = new Point(15, 30);
        btnCargar.Name = "btnCargar";
        btnCargar.Size = new Size(260, 34);
        btnCargar.TabIndex = 0;
        btnCargar.Text = "📂  Cargar lista de candidatos…";
        btnCargar.UseVisualStyleBackColor = true;
        btnCargar.Click += btnCargar_Click;
        // 
        // gbVotante
        // 
        gbVotante.Controls.Add(tablaVotante);
        gbVotante.Location = new Point(470, 20);
        gbVotante.Name = "gbVotante";
        gbVotante.Size = new Size(470, 230);
        gbVotante.TabIndex = 2;
        gbVotante.TabStop = false;
        gbVotante.Text = "Datos del votante";
        // 
        // tablaVotante
        // 
        tablaVotante.ColumnCount = 2;
        tablaVotante.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        tablaVotante.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tablaVotante.Controls.Add(lblCodigo, 0, 0);
        tablaVotante.Controls.Add(txtCodigo, 1, 0);
        tablaVotante.Controls.Add(lblGrupo, 0, 1);
        tablaVotante.Controls.Add(txtGrupo, 1, 1);
        tablaVotante.Controls.Add(lblCarrera, 0, 2);
        tablaVotante.Controls.Add(cmbCarrera, 1, 2);
        tablaVotante.Controls.Add(lblCentro, 0, 3);
        tablaVotante.Controls.Add(cmbCentro, 1, 3);
        tablaVotante.Dock = DockStyle.Fill;
        tablaVotante.Location = new Point(3, 26);
        tablaVotante.Name = "tablaVotante";
        tablaVotante.Padding = new Padding(10);
        tablaVotante.RowCount = 4;
        tablaVotante.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        tablaVotante.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        tablaVotante.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        tablaVotante.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
        tablaVotante.Size = new Size(464, 201);
        tablaVotante.TabIndex = 0;
        // 
        // lblCodigo
        // 
        lblCodigo.Anchor = AnchorStyles.Left;
        lblCodigo.AutoSize = true;
        lblCodigo.Location = new Point(13, 10);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new Size(94, 45);
        lblCodigo.TabIndex = 0;
        lblCodigo.Text = "Código de alumno:";
        // 
        // txtCodigo
        // 
        txtCodigo.Location = new Point(163, 13);
        txtCodigo.Name = "txtCodigo";
        txtCodigo.Size = new Size(220, 30);
        txtCodigo.TabIndex = 1;
        // 
        // lblGrupo
        // 
        lblGrupo.Anchor = AnchorStyles.Left;
        lblGrupo.AutoSize = true;
        lblGrupo.Location = new Point(13, 66);
        lblGrupo.Name = "lblGrupo";
        lblGrupo.Size = new Size(62, 23);
        lblGrupo.TabIndex = 2;
        lblGrupo.Text = "Grupo:";
        // 
        // txtGrupo
        // 
        txtGrupo.Location = new Point(163, 58);
        txtGrupo.Name = "txtGrupo";
        txtGrupo.Size = new Size(220, 30);
        txtGrupo.TabIndex = 3;
        // 
        // lblCarrera
        // 
        lblCarrera.Anchor = AnchorStyles.Left;
        lblCarrera.AutoSize = true;
        lblCarrera.Location = new Point(13, 111);
        lblCarrera.Name = "lblCarrera";
        lblCarrera.Size = new Size(70, 23);
        lblCarrera.TabIndex = 4;
        lblCarrera.Text = "Carrera:";
        // 
        // cmbCarrera
        // 
        cmbCarrera.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCarrera.FormattingEnabled = true;
        cmbCarrera.Location = new Point(163, 103);
        cmbCarrera.Name = "cmbCarrera";
        cmbCarrera.Size = new Size(220, 31);
        cmbCarrera.TabIndex = 5;
        // 
        // lblCentro
        // 
        lblCentro.Anchor = AnchorStyles.Left;
        lblCentro.AutoSize = true;
        lblCentro.Location = new Point(13, 145);
        lblCentro.Name = "lblCentro";
        lblCentro.Size = new Size(109, 46);
        lblCentro.TabIndex = 6;
        lblCentro.Text = "Centro Universitario:";
        // 
        // cmbCentro
        // 
        cmbCentro.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCentro.FormattingEnabled = true;
        cmbCentro.Location = new Point(163, 148);
        cmbCentro.Name = "cmbCentro";
        cmbCentro.Size = new Size(220, 31);
        cmbCentro.TabIndex = 7;
        // 
        // btnIniciar
        // 
        btnIniciar.BackColor = Color.FromArgb(30, 60, 114);
        btnIniciar.FlatStyle = FlatStyle.Flat;
        btnIniciar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnIniciar.ForeColor = Color.White;
        btnIniciar.Location = new Point(740, 270);
        btnIniciar.Name = "btnIniciar";
        btnIniciar.Size = new Size(200, 44);
        btnIniciar.TabIndex = 3;
        btnIniciar.Text = "Iniciar papeleta  ▶";
        btnIniciar.UseVisualStyleBackColor = false;
        btnIniciar.Click += btnIniciar_Click;
        // 
        // panelHeader
        // 
        panelHeader.BackColor = Color.FromArgb(30, 60, 114);
        panelHeader.Controls.Add(lblTitulo);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(984, 60);
        panelHeader.TabIndex = 1;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 14);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(393, 37);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "📋  Gestión de convocatorias";
        // 
        // ConvocatoriasForm
        // 
        AutoScaleDimensions = new SizeF(120F, 120F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(984, 381);
        Controls.Add(panelContenido);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 10F);
        Name = "ConvocatoriasForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "SDVE - Convocatorias";
        panelContenido.ResumeLayout(false);
        gbConvocatorias.ResumeLayout(false);
        flowConvocatorias.ResumeLayout(false);
        flowConvocatorias.PerformLayout();
        gbListas.ResumeLayout(false);
        gbVotante.ResumeLayout(false);
        tablaVotante.ResumeLayout(false);
        tablaVotante.PerformLayout();
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelContenido;
    private GroupBox gbConvocatorias;
    private FlowLayoutPanel flowConvocatorias;
    private CheckBox chkSociedad;
    private CheckBox chkConsejoU;
    private CheckBox chkRepresentantes;
    private GroupBox gbListas;
    private Button btnCargar;
    private GroupBox gbVotante;
    private TableLayoutPanel tablaVotante;
    private Label lblCodigo;
    private Label lblGrupo;
    private Label lblCarrera;
    private Label lblCentro;
    private TextBox txtCodigo;
    private TextBox txtGrupo;
    private ComboBox cmbCarrera;
    private ComboBox cmbCentro;
    private Button btnIniciar;
    private Panel panelHeader;
    private Label lblTitulo;
}
