using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Session
    {
        Usuario user;
        Aluno aluno;

        public Usuario User {
            get { return this.user; }
            set { this.user = value; }
        }

        public Aluno Aluno
        {
            get { return this.aluno; }
            set { this.aluno = value; }
        }

    }
}
