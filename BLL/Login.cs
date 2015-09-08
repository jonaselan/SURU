using DTO;
using System;
using System.Threading.Tasks;

namespace BLL
{
    public static class Login
    {
        public async static Task<Session> Validar(string m, string s) {
            Usuario usrbll = new Usuario();
            DTO.Usuario usr = await usrbll.ConsultarPorMatricula(m);
            s = DBElementHandling.Hash(s);
            if(usr == null) { throw new Exception("Matrícula ou Senha inválida."); }
            if (s != usr.SENHA) { throw new Exception("Matrícula ou Senha inválida."); }
            Session session = new Session();
            session.User = usr;
            session.Perfil = await usrbll.GetPerfil(usr);    
            return session;
        }
    }
}
