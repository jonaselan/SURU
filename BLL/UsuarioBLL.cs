using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class UsuarioBLL : IUsuario
    {
        List<Usuario> IUsuario.GetLista()
        {
            DBConnect db = new DBConnect(0);
            return db.Select<Usuario>();
        }

        void IUsuario.Inserir(Usuario u)
        {
            DBConnect db_users = new DBConnect(0);
            db_users.Insert(u);
            /*
            PerfilBLL p = new PerfilBLL()
            p.Inserir(u.Perfil);
            */
        }
    }
}
