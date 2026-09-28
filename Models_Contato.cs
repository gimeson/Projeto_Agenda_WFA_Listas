using System;
using System.Collections.Generic;

namespace AgendaWinForms.Models
{
    public class Contato
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public Data DtNasc { get; set; }
        public List<Telefone> Telefones { get; set; }

        public Contato()
        {
            Telefones = new List<Telefone>();
        }

        public Contato(string email, string nome, Data dtNasc) : this()
        {
            Email = email;
            Nome = nome;
            DtNasc = dtNasc;
        }

        public int GetIdade()
        {
            if (DtNasc == null) return 0;

            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DtNasc.Ano;

            if (DtNasc.Mes > hoje.Month || (DtNasc.Mes == hoje.Month && DtNasc.Dia > hoje.Day))
            {
                idade--;
            }

            return idade;
        }

        public void AdicionarTelefone(Telefone t)
        {
            if (t.Principal)
            {
                foreach (var tel in Telefones)
                {
                    tel.Principal = false;
                }
            }
            Telefones.Add(t);
        }

        public string GetTelefonePrincipal()
        {
            Telefone telPrincipal = Telefones.Find(t => t.Principal);
            if (telPrincipal != null)
            {
                return $"{telPrincipal.Numero} ({telPrincipal.Tipo})";
            }
            return Telefones.Count > 0 ? $"{Telefones[0].Numero} ({Telefones[0].Tipo})" : "Sem telefone";
        }

        public override string ToString()
        {
            string dataNascStr = DtNasc != null ? DtNasc.ToString() : "N/D";
            return $"Nome: {Nome} | Email: {Email} | Nasc: {dataNascStr} ({GetIdade()} anos) | Tel. Principal: {GetTelefonePrincipal()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contato outro)
            {
                return !string.IsNullOrEmpty(Email) && Email.Equals(outro.Email, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Email != null ? Email.ToLower().GetHashCode() : 0;
        }
    }
}