using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class Email : IEmail, IDBElement<DTO.Email>
    {
        public void Alterar(DTO.Email e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Update(e);
        }

        public async Task<DTO.Email> ConsultarPorId(long id)
        {
            DTO.Email eml = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_EMAILS
                        where e.ID == id
                        select e;
                eml = await q.FirstOrDefaultAsync();
            }
            return eml;
        }

        public async Task<List<DTO.Email>> EmailsPerfilId(long id)
        {
            List<DTO.Email> eml = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_EMAILS
                        where e.ID == id
                        select e;
                var list = await q.ToListAsync();
                eml = list;
            }
            return eml;
        }

        public void Inserir(DTO.Email e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Insert(e);
        }

        public void IsValido(DTO.Email e) { }

        public async Task<List<DTO.Email>> Listar()
        {
            DAL.Database db = new DAL.Database();
            var table = db.Select<DTO.Email>();
            return await table.ToListAsync(); ;
        }

        public void Remover(DTO.Email e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);
            DAL.Database db = new DAL.Database();
            db.Delete(e);
        }
    }
}
