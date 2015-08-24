using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using DTO;
using DAL;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class EmailBLL : IEmail, IDBElement<Email>
    {
        public void Alterar(Email e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Update(e);
        }

        public async Task<Email> ConsultarPorId(long id)
        {
            Email eml = null;
            using (var db = new UsuariosDB())
            {
                var q = from e in db.TB_EMAILS
                        where e.ID == id
                        select e;
                eml = await q.FirstOrDefaultAsync();
            }
            return eml;
        }

        public async Task<List<Email>> EmailsPerfilId(long id)
        {
            List<Email> eml = null;
            using (var db = new UsuariosDB())
            {
                var q = from e in db.TB_EMAILS
                        where e.ID == id
                        select e;
                var list = await q.ToListAsync();
                eml = list;
            }
            return eml;
        }

        public void Inserir(Email e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Insert(e);
        }

        public void IsValido(Email e) { }

        public async Task<List<Email>> Listar()
        {
            Database db = new Database();
            var table = db.Select<Email>();
            return await table.ToListAsync(); ;
        }

        public void Remover(Email e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);
            Database db = new Database();
            db.Delete(e);
        }
    }
}
