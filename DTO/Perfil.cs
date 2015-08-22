using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /* 
        MODELO DE PERFIL 
            1: Id - Identificação do perfil no database;
            2: Nome - Nome completo;
            3: Telefone;
            4: E-mail;
     */
    public class Perfil : IComparable<Perfil>
    {
        private int id;
        private string nome;
        private string telefone;
        private string email;

        public int Id
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public string Nome
        {
            set { this.nome = value; }
            get { return this.nome; }
        }

        public string Telefone
        {
            set { this.telefone = value; }
            get { return this.telefone; }
        }

        public string Email
        {
            set { this.email = value; }
            get { return this.email; }
        }

        public int CompareTo(Perfil other)
        {
            if (other.id == this.id) { return 1; }
            return 0;
        }
    }
}
