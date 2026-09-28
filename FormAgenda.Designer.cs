namespace AgendaWinForms.Forms
{
    partial class FormAgenda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        private void InitializeComponent()
        {
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNascimento = new System.Windows.Forms.Label();
            this.dtpNascimento = new System.Windows.Forms.DateTimePicker();
            this.grpTelefones = new System.Windows.Forms.GroupBox();
            this.cmbTipoTel = new System.Windows.Forms.ComboBox();
            this.txtNumeroTel = new System.Windows.Forms.TextBox();
            this.chkPrincipal = new System.Windows.Forms.CheckBox();
            this.btnAdicionarTelefone = new System.Windows.Forms.Button();
            this.lstTelefones = new System.Windows.Forms.ListBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.dgvContatos = new System.Windows.Forms.DataGridView();
            this.grpTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).BeginInit();
            this.SuspendLayout();

            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(15, 20);
            this.lblEmail.Text = "E-mail:";
            this.lblEmail.Size = new System.Drawing.Size(50, 20);

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(80, 17);
            this.txtEmail.Size = new System.Drawing.Size(250, 20);

            // lblNome
            this.lblNome.Location = new System.Drawing.Point(15, 50);
            this.lblNome.Text = "Nome:";
            this.lblNome.Size = new System.Drawing.Size(50, 20);

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(80, 47);
            this.txtNome.Size = new System.Drawing.Size(250, 20);

            // lblNascimento
            this.lblNascimento.Location = new System.Drawing.Point(15, 80);
            this.lblNascimento.Text = "Data Nasc.:";
            this.lblNascimento.Size = new System.Drawing.Size(65, 20);

            // dtpNascimento
            this.dtpNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNascimento.Location = new System.Drawing.Point(80, 77);
            this.dtpNascimento.Size = new System.Drawing.Size(120, 20);

            // grpTelefones
            this.grpTelefones.Controls.Add(this.cmbTipoTel);
            this.grpTelefones.Controls.Add(this.txtNumeroTel);
            this.grpTelefones.Controls.Add(this.chkPrincipal);
            this.grpTelefones.Controls.Add(this.btnAdicionarTelefone);
            this.grpTelefones.Controls.Add(this.lstTelefones);
            this.grpTelefones.Location = new System.Drawing.Point(350, 15);
            this.grpTelefones.Size = new System.Drawing.Point(320, 150);
            this.grpTelefones.Text = "Telefones";

            this.cmbTipoTel.Location = new System.Drawing.Point(10, 20);
            this.cmbTipoTel.Size = new System.Drawing.Size(100, 21);

            this.txtNumeroTel.Location = new System.Drawing.Point(115, 20);
            this.txtNumeroTel.Size = new System.Drawing.Size(110, 20);

            this.chkPrincipal.Location = new System.Drawing.Point(230, 20);
            this.chkPrincipal.Text = "Principal";
            this.chkPrincipal.Size = new System.Drawing.Size(80, 20);

            this.btnAdicionarTelefone.Location = new System.Drawing.Point(10, 50);
            this.btnAdicionarTelefone.Size = new System.Drawing.Size(300, 23);
            this.btnAdicionarTelefone.Text = "Adicionar Telefone";
            this.btnAdicionarTelefone.Click += new System.EventHandler(this.btnAdicionarTelefone_Click);

            this.lstTelefones.Location = new System.Drawing.Point(10, 80);
            this.lstTelefones.Size = new System.Drawing.Size(300, 56);

            // BOTOES DE ACAO
            this.btnAdicionar.Location = new System.Drawing.Point(18, 120);
            this.btnAdicionar.Size = new System.Drawing.Size(100, 30);
            this.btnAdicionar.Text = "1. Adicionar";
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);

            this.btnPesquisar.Location = new System.Drawing.Point(124, 120);
            this.btnPesquisar.Size = new System.Drawing.Size(100, 30);
            this.btnPesquisar.Text = "2. Pesquisar";
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);

            this.btnAlterar.Location = new System.Drawing.Point(230, 120);
            this.btnAlterar.Size = new System.Drawing.Size(100, 30);
            this.btnAlterar.Text = "3. Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);

            this.btnRemover.Location = new System.Drawing.Point(18, 160);
            this.btnRemover.Size = new System.Drawing.Size(100, 30);
            this.btnRemover.Text = "4. Remover";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);

            this.btnListar.Location = new System.Drawing.Point(124, 160);
            this.btnListar.Size = new System.Drawing.Size(100, 30);
            this.btnListar.Text = "5. Listar";
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);

            this.btnSair.Location = new System.Drawing.Point(230, 160);
            this.btnSair.Size = new System.Drawing.Size(100, 30);
            this.btnSair.Text = "0. Sair";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);

            // dgvContatos
            this.dgvContatos.Location = new System.Drawing.Point(18, 205);
            this.dgvContatos.Size = new System.Drawing.Size(652, 220);
            this.dgvContatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContatos_CellClick);

            // FormAgenda
            this.ClientSize = new System.Drawing.Size(684, 441);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNascimento);
            this.Controls.Add(this.dtpNascimento);
            this.Controls.Add(this.grpTelefones);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.dgvContatos);
            this.Text = "Agenda de Contatos - Windows Forms";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.grpTelefones.ResumeLayout(false);
            this.grpTelefones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNascimento;
        private System.Windows.Forms.DateTimePicker dtpNascimento;
        private System.Windows.Forms.GroupBox grpTelefones;
        private System.Windows.Forms.ComboBox cmbTipoTel;
        private System.Windows.Forms.TextBox txtNumeroTel;
        private System.Windows.Forms.CheckBox chkPrincipal;
        private System.Windows.Forms.Button btnAdicionarTelefone;
        private System.Windows.Forms.ListBox lstTelefones;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dgvContatos;
    }
}