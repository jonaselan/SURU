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
            3: Senha - Senha de acesso;
            4: IsAdm - Se o usuario tem privilegios de administrador;
            5: IdPerfil - Id do perfil no banco de dados;
     */
    public class Usuario : IComparable<Usuario>
    {
        private string id;
        private string matricula;
        private string senha;
        private bool isadm;
        private Perfil perfil;

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

        public string Senha
        {
            set { this.senha = value; }
            get { return this.senha;  }
        }

        public bool IsAdm
        {
            set { this.isadm = value; }
            get { return this.isadm; }
        }

        public Perfil Perfil
        {
            set { this.perfil = value; }
            get { return this.perfil; }
        }

        public int CompareTo(Usuario other)
        {
            if (other.id == this.id) { return 1; }
            return 0;
        }
    }
}
