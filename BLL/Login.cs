using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class Login
    {
        public static Session Validar(string m, string s) {
            UsuarioBLL usrbll = new UsuarioBLL();
            Usuario usr = usrbll.ConsultarPorMatricula(m);
            s = DBElementHandling.Hash(s);
            if(usr == null) { throw new Exception("Matrícula ou Senha inválida."); }
            if (s != usr.Senha) { throw new Exception("Matrícula ou Senha inválida."); }
            Session session = new Session();
            session.User = usr;
            return session;
        }
    }
}
