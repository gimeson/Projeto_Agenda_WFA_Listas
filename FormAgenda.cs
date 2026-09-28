using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AgendaWinForms.Models;

namespace AgendaWinForms.Forms
{
    public partial class FormAgenda : Form
    {
        private Contatos minhaAgenda = new Contatos();
        private List<Telefone> telefonesTemporarios = new List<Telefone>();

        public FormAgenda()
        {
            InitializeComponent();
            ConfigurarGrid();
            InicializarCombos();
        }

        private void ConfigurarGrid()
        {
            dgvContatos.AutoGenerateColumns = false;
            dgvContatos.Columns.Clear();

            dgvContatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Nome", DataPropertyName = "Nome", HeaderText = "Nome", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvContatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Email", DataPropertyName = "Email", HeaderText = "E-mail", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvContatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "DataNasc", HeaderText = "Data Nasc.", Width = 90 });
            dgvContatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "Idade", HeaderText = "Idade", Width = 50 });
            dgvContatos.Columns.Add(new DataGridViewTextBoxColumn { Name = "TelPrincipal", HeaderText = "Tel. Principal", Width = 150 });
        }

        private void InicializarCombos()
        {
            cmbTipoTel.Items.Clear();
            cmbTipoTel.Items.AddRange(new object[] { "Celular", "Residencial", "Trabalho", "Outro" });
            cmbTipoTel.SelectedIndex = 0;
        }

        // --- AÇÕES DO FORMULÁRIO ---

        private void btnAdicionarTelefone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumeroTel.Text))
            {
                MessageBox.Show("Informe o número do telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool ePrincipal = chkPrincipal.Checked;
            if (ePrincipal)
            {
                foreach (var t in telefonesTemporarios)
                {
                    t.Principal = false;
                }
            }

            Telefone tel = new Telefone(cmbTipoTel.SelectedItem.ToString(), txtNumeroTel.Text.Trim(), ePrincipal);
            telefonesTemporarios.Add(tel);

            AtualizarListaTelefones();
            txtNumeroTel.Clear();
            chkPrincipal.Checked = false;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposBasicos()) return;

            string email = txtEmail.Text.Trim();
            string nome = txtNome.Text.Trim();
            DateTime dt = dtpNascimento.Value;

            Contato novo = new Contato(email, nome, new Data(dt.Day, dt.Month, dt.Year));
            foreach (var t in telefonesTemporarios)
            {
                novo.AdicionarTelefone(t);
            }

            if (minhaAgenda.Adicionar(novo))
            {
                MessageBox.Show("Contato cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFormulario();
                AtualizarGridContatos();
            }
            else
            {
                MessageBox.Show("Já existe um contato cadastrado com este e-mail.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Informe o e-mail do contato que deseja pesquisar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Contato busca = new Contato { Email = email };
            Contato encontrado = minhaAgenda.Pesquisar(busca);

            if (encontrado != null)
            {
                txtNome.Text = encontrado.Nome;
                if (encontrado.DtNasc != null)
                {
                    dtpNascimento.Value = new DateTime(encontrado.DtNasc.Ano, encontrado.DtNasc.Mes, encontrado.DtNasc.Dia);
                }

                telefonesTemporarios = new List<Telefone>(encontrado.Telefones);
                AtualizarListaTelefones();

                MessageBox.Show($"Contato encontrado!\nIdade: {encontrado.GetIdade()} anos", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Contato não encontrado.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposBasicos()) return;

            string email = txtEmail.Text.Trim();
            string nome = txtNome.Text.Trim();
            DateTime dt = dtpNascimento.Value;

            Contato alterado = new Contato(email, nome, new Data(dt.Day, dt.Month, dt.Year));
            foreach (var t in telefonesTemporarios)
            {
                alterado.AdicionarTelefone(t);
            }

            if (minhaAgenda.Alterar(alterado))
            {
                MessageBox.Show("Contato alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFormulario();
                AtualizarGridContatos();
            }
            else
            {
                MessageBox.Show("Contato não encontrado para alteração.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Informe o e-mail do contato que deseja remover.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Deseja realmente remover este contato?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Contato busca = new Contato { Email = email };
                if (minhaAgenda.Remover(busca))
                {
                    MessageBox.Show("Contato removido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparFormulario();
                    AtualizarGridContatos();
                }
                else
                {
                    MessageBox.Show("Contato não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            AtualizarGridContatos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvContatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < minhaAgenda.Agenda.Count)
            {
                Contato selecionado = minhaAgenda.Agenda[e.RowIndex];
                txtEmail.Text = selecionado.Email;
                txtNome.Text = selecionado.Nome;
                if (selecionado.DtNasc != null)
                {
                    dtpNascimento.Value = new DateTime(selecionado.DtNasc.Ano, selecionado.DtNasc.Mes, selecionado.DtNasc.Dia);
                }
                telefonesTemporarios = new List<Telefone>(selecionado.Telefones);
                AtualizarListaTelefones();
            }
        }

        // --- MÉTODOS AUXILIARES ---

        private bool ValidarCamposBasicos()
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Preencha o Nome e o E-mail obrigatoriamente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void AtualizarListaTelefones()
        {
            lstTelefones.Items.Clear();
            foreach (var t in telefonesTemporarios)
            {
                lstTelefones.Items.Add(t.ToString());
            }
        }

        private void AtualizarGridContatos()
        {
            dgvContatos.Rows.Clear();
            foreach (var c in minhaAgenda.Agenda)
            {
                string dataStr = c.DtNasc != null ? c.DtNasc.ToString() : "";
                dgvContatos.Rows.Add(c.Nome, c.Email, dataStr, c.GetIdade(), c.GetTelefonePrincipal());
            }
        }

        private void LimparFormulario()
        {
            txtEmail.Clear();
            txtNome.Clear();
            dtpNascimento.Value = DateTime.Today;
            txtNumeroTel.Clear();
            chkPrincipal.Checked = false;
            telefonesTemporarios.Clear();
            lstTelefones.Items.Clear();
        }
    }
}