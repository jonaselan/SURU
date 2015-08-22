using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Security.Cryptography;

namespace BLL
{
    public class UsuarioBLL : IUsuario, IDBElement<Usuario>
    {
        public List<Usuario> Listar()
        {
            DBConnect db = new DBConnect(0);
            return db.Select<Usuario>();
        }

        public void Inserir(Usuario u, Perfil p)
        {
            /* RETIRANDO OS ESPAÇOS */

            DBElementHandling.RemoverEspacos(u);

            /* CHECAGEM DOS VALORES INSERIDOS */

            try { IsValido(u); } catch (Exception ex) { throw ex; }

            /* HASH DA SENHA */
            u.Senha = DBElementHandling.Hash(u.Senha);

            /* TENTAR INSERIR O PERFIL */
            PerfilBLL pbll = new PerfilBLL();
            try { pbll.Inserir(p); } catch(Exception ex) { throw ex; }

            /* CONECTANDO AO DB */
            DBConnect db = new DBConnect(0);
            db.Insert(u);
        }

        public Usuario ConsultarPorMatricula(string matricula)
        {
            DBConnect db = new DBConnect(0);
            return db.Select<Usuario>().FirstOrDefault(u => u.Matricula == matricula);
        }

        public void Alterar(Usuario u, Perfil p)
        {
            /* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            /* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(u); } catch (Exception ex) { throw ex; }

            /* TENTAR ALTERAR O PERFIL */
            PerfilBLL pbll = new PerfilBLL();

            try { pbll.Alterar(p); } catch (Exception ex) { throw ex; }

            /* CONECTANDO AO DB */
            DBConnect db = new DBConnect(0);
            db.Update(u);
        }

        public void Remover(Usuario u)
        {
            throw new NotImplementedException();
        }

        public Usuario ConsultarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void IsValido(Usuario e)
        {
            if (e.Matricula == "") { throw new Exception("Matrícula inválida"); }
            if (e.Senha == "") { throw new Exception("Senha inválida"); }
        }

        public void Inserir(Usuario e)
        {
            throw new Exception("Perfil não especificado.");
        }

        public void Alterar(Usuario e)
        {
            throw new Exception("Perfil não especificado.");
        }
    }
}
