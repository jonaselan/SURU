using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class Perfil : IPerfil, IDBElement<DTO.Perfil>
    {

        #region Métodos de BUSCA
        public async Task<DTO.Perfil> ConsultarPorId(long id)
        {
            DTO.Perfil perf = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_PERFIS
                        where p.ID == id
                        select p;
                perf = await q.FirstOrDefaultAsync();
            }
            return perf;
        }

        public async Task<DTO.Perfil> ConsultarPorNome(string nome)
        {
            DTO.Perfil perf = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_PERFIS
                        where p.NOME == nome
                        select p;
                perf = await q.FirstOrDefaultAsync();
            }
            return perf;
        }

        #endregion

        #region Métodos de MANIPULAÇÃO de dados

        public void Inserir(DTO.Perfil p)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(p);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(p); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Insert(p);
        }

        public void Alterar(DTO.Perfil p)
        {
            //* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);

            //* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(p); } catch (Exception ex) { throw ex; }


            //* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Update(p);
        }

        public void Remover(DTO.Perfil p)
        {
            //* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);
            DAL.Database db = new DAL.Database();
            db.Delete(p);
        }
        #endregion


        public void IsValido(DTO.Perfil p)
        {
            if (p.NOME == "") { throw new Exception("Nome inválido"); }
        }

        public async Task<List<DTO.Perfil>> Listar()
        {
            DAL.Database db = new DAL.Database();
            var table = db.Select<DTO.Perfil>();
            return await table.ToListAsync(); ;
        }

    }
}
