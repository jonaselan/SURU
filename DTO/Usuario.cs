using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /* 
        MODELO DE USUÁRIO 
            1: Id - Identificação do usuário no database;
            2: Matricula - Matricula (IFRN);
            3: Nome - Nome completo;
            4: Telefone;
     */
    public class Usuario
    {
        private string id;
        private string matricula;
        private string nome;
        private string telefone;

        public string Id
        {
            set { this.id = value; }
            get { return this.id; }
        }

        public string Matricula
        {
            set { this.matricula = value; }
            get { return this.matricula; }
        }

        public string Nome
        {
            set { this.nome = value; }
            get { return this.nome;  }
        }

        public string Telefone
        {
            set { this.telefone = value; }
            get { return this.telefone; }
        }
    }
}
