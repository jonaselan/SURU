using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;
using DTO;

namespace BLL
{
    public class Aluno : IPerfil<DTO.Aluno>, IAluno, IDBElement<DTO.Aluno>
    {
        public void Alterar(DTO.Aluno e)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(e);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Update(e);
        }

        public async Task<DTO.Aluno> ConsultarPorID(long id)
        {
            DTO.Aluno aluno = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_ALUNOS
                        where p.ID == id
                        select p;
                aluno = await q.FirstOrDefaultAsync();
            }
            return aluno;
        }

        public async Task<DTO.Aluno> ConsultarPorNome(string nome)
        {
            DTO.Aluno aluno = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_ALUNOS
                        where p.CURSO == nome
                        select p;
                aluno = await q.FirstOrDefaultAsync();
            }
            return aluno;
        }

        public void Inserir(DTO.Aluno e)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(e);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Insert(e);
        }

        public void IsValido(DTO.Aluno e)
        {
            if (e.CURSO == "") { throw new Exception("Nome inválido"); }
        }

        public async Task<List<DTO.Aluno>> Listar()
        {
            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();

            // ADQUIRINDO TABELA DE PERFIS
            var table = db.Select<DTO.Aluno>();

            return await table.ToListAsync(); ;
        }

        public void Remover(DTO.Aluno e)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(e);

            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();

            db.Delete(e);
        }
    }
}
