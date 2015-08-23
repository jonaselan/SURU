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
    public class AlunoBLL : IAluno, IDBElement<Aluno>
    {

        public Usuario ConsultarPorMatricula(string matricula)
        {
            DBConnect db = new DBConnect(0);
            return db.Select<Usuario>().FirstOrDefault(u => u.Matricula == matricula);
        }

        public List<Aluno> Listar()
        {
            DBConnect db = new DBConnect(1);
            return db.Select<Aluno>();
        }

        public void Inserir(Aluno e)
        {
            throw new Exception("Perfil não especificado.");
        }

        public void Alterar(Aluno e)
        {
            /* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            /* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); }
            catch (Exception ex) { throw ex; }


            /* CONECTANDO AO DB */
            DBConnect db = new DBConnect(1);
            db.Update(e);
        }

        void IDBElement<Aluno>.Remover(Aluno e)
        {
            /* RETIRANDO OS ESPAÇOS */

            DBElementHandling.RemoverEspacos(e);

            DBConnect db = new DBConnect(1);
            db.Delete(e);
        }

        Aluno IDBElement<Aluno>.ConsultarPorId(int id)
        {
            DBConnect db = new DBConnect(1);
            return db.Select<Aluno>().FirstOrDefault(p => p.Id == id);
        }

        public void IsValido(Aluno e)
        {
            if (e.Nome == "") { throw new Exception("wewewoewoeow"); } // Adicionar erro
            if (e.Curso == "") { throw new Exception("curso sem delicia"); }
        }

        Aluno IAluno.ConsultarPorNome(string nome)
        {
            DBConnect db = new DBConnect(1);
            return db.Select<Aluno>().FirstOrDefault(p => p.Nome == nome);
        }
    }
}
