using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BLL
{
    public class PerfilBLL : IPerfil, IDBElement<Perfil>
    {
        public void Alterar(Perfil p)
        {
            /* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);

            /* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(p); } catch (Exception ex) { throw ex; }


            /* CONECTANDO AO DB */
            DBConnect db = new DBConnect(1);
            db.Update(p);
        }

        public Perfil ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ConsultarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Perfil p)
        {
            /* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);

            /* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(p); } catch(Exception ex) { throw ex; }
            

            /* CONECTANDO AO DB */
            DBConnect db = new DBConnect(1);
            db.Insert(p);
        }

        public void IsValido(Perfil e)
        {
            if (e.Nome == "") { throw new Exception("Nome inválido"); }
        }

        public List<Perfil> Listar()
        {
            DBConnect db = new DBConnect(1);
            return db.Select<Perfil>();
        }

        public void Remover(Perfil p)
        {
            throw new NotImplementedException();
        }
    }
}
