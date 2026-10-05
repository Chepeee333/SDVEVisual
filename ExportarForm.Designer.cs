namespace SDVE;

partial class ExportarForm
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
        gbFormato = new GroupBox();
        flowFormato = new FlowLayoutPanel();
        rbCsv = new RadioButton();
        rbJson = new RadioButton();
        rbXml = new RadioButton();
        gbDestino = new GroupBox();
        txtRuta = new TextBox();
        btnExaminar = new Button();
        btnExportar = new Button();
        panelHeader = new Panel();
        lblTitulo = new Label();
        panelContenido.SuspendLayout();
        gbFormato.SuspendLayout();
        flowFormato.SuspendLayout();
        gbDestino.SuspendLayout();
        panelHeader.SuspendLayout();
        SuspendLayout();
        //
        // panelContenido
        //
        panelContenido.Controls.Add(gbFormato);
        panelContenido.Controls.Add(gbDestino);
        panelContenido.Controls.Add(btnExportar);
        panelContenido.Dock = DockStyle.Fill;
        panelContenido.Location = new Point(0, 60);
        panelContenido.Name = "panelContenido";
        panelContenido.Size = new Size(684, 301);
        panelContenido.TabIndex = 0;
        //
        // gbFormato
        //
        gbFormato.Controls.Add(flowFormato);
        gbFormato.Location = new Point(20, 20);
        gbFormato.Name = "gbFormato";
        gbFormato.Size = new Size(300, 100);
        gbFormato.TabIndex = 0;
        gbFormato.TabStop = false;
        gbFormato.Text = "Formato de exportación";
        //
        // flowFormato
        //
        flowFormato.Controls.Add(rbCsv);
        flowFormato.Controls.Add(rbJson);
        flowFormato.Controls.Add(rbXml);
        flowFormato.Dock = DockStyle.Fill;
        flowFormato.Location = new Point(3, 23);
        flowFormato.Name = "flowFormato";
        flowFormato.Padding = new Padding(15, 20, 0, 0);
        flowFormato.Size = new Size(294, 74);
        flowFormato.TabIndex = 0;
        //
        // rbCsv
        //
        rbCsv.AutoSize = true;
        rbCsv.Checked = true;
        rbCsv.Name = "rbCsv";
        rbCsv.TabIndex = 0;
        rbCsv.TabStop = true;
        rbCsv.Text = "CSV";
        rbCsv.UseVisualStyleBackColor = true;
        //
        // rbJson
        //
        rbJson.AutoSize = true;
        rbJson.Name = "rbJson";
        rbJson.TabIndex = 1;
        rbJson.Text = "JSON";
        rbJson.UseVisualStyleBackColor = true;
        //
        // rbXml
        //
        rbXml.AutoSize = true;
        rbXml.Name = "rbXml";
        rbXml.TabIndex = 2;
        rbXml.Text = "XML";
        rbXml.UseVisualStyleBackColor = true;
        //
        // gbDestino
        //
        gbDestino.Controls.Add(txtRuta);
        gbDestino.Controls.Add(btnExaminar);
        gbDestino.Location = new Point(20, 140);
        gbDestino.Name = "gbDestino";
        gbDestino.Size = new Size(640, 90);
        gbDestino.TabIndex = 1;
        gbDestino.TabStop = false;
        gbDestino.Text = "Destino";
        //
        // txtRuta
        //
        txtRuta.Location = new Point(15, 35);
        txtRuta.Name = "txtRuta";
        txtRuta.Size = new Size(460, 25);
        txtRuta.TabIndex = 0;
        txtRuta.Text = "C:\\Resultados\\sdve_resultados.csv";
        //
        // btnExaminar
        //
        btnExaminar.Location = new Point(515, 33);
        btnExaminar.Name = "btnExaminar";
        btnExaminar.Size = new Size(100, 30);
        btnExaminar.TabIndex = 1;
        btnExaminar.Text = "Examinar…";
        btnExaminar.UseVisualStyleBackColor = true;
        btnExaminar.Click += btnExaminar_Click;
        //
        // btnExportar
        //
        btnExportar.BackColor = Color.FromArgb(30, 60, 114);
        btnExportar.FlatStyle = FlatStyle.Flat;
        btnExportar.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
        btnExportar.ForeColor = Color.White;
        btnExportar.Location = new Point(20, 250);
        btnExportar.Name = "btnExportar";
        btnExportar.Size = new Size(230, 44);
        btnExportar.TabIndex = 2;
        btnExportar.Text = "⬇  Exportar resultados";
        btnExportar.UseVisualStyleBackColor = false;
        btnExportar.Click += btnExportar_Click;
        //
        // panelHeader
        //
        panelHeader.BackColor = Color.FromArgb(30, 60, 114);
        panelHeader.Controls.Add(lblTitulo);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Name = "panelHeader";
        panelHeader.Size = new Size(684, 60);
        panelHeader.TabIndex = 1;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 14);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "💾  Exportación de resultados";
        //
        // ExportarForm
        //
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(684, 361);
        Controls.Add(panelContenido);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        Name = "ExportarForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "SDVE - Exportar resultados";
        panelContenido.ResumeLayout(false);
        gbFormato.ResumeLayout(false);
        flowFormato.ResumeLayout(false);
        flowFormato.PerformLayout();
        gbDestino.ResumeLayout(false);
        gbDestino.PerformLayout();
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelContenido;
    private GroupBox gbFormato;
    private FlowLayoutPanel flowFormato;
    private RadioButton rbCsv;
    private RadioButton rbJson;
    private RadioButton rbXml;
    private GroupBox gbDestino;
    private TextBox txtRuta;
    private Button btnExaminar;
    private Button btnExportar;
    private Panel panelHeader;
    private Label lblTitulo;
}
