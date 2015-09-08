using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class Prato : IPrato, IDBElement<DTO.Prato>
    {
        public void Alterar(DTO.Prato e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); }
            catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Update(e);
        }

        public async Task<DTO.Prato> ConsultarPorId(long id)
        {
            DTO.Prato eml = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_PRATOS
                        where e.ID_PRATO == id
                        select e;
                eml = await q.FirstOrDefaultAsync();
            }
            return eml;
        }

        public void Inserir(DTO.Prato e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(e); }
            catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Insert(e);
        }

        public void IsValido(DTO.Prato e) { }

        public async Task<List<DTO.Prato>> Listar()
        {
            DAL.Database db = new DAL.Database();
            var table = db.Select<DTO.Prato>();
            return await table.ToListAsync(); ;
        }

        public void Remover(DTO.Prato e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);
            DAL.Database db = new DAL.Database();
            db.Delete(e);
        }

        /*public async Task<List<DTO.Prato>> PratosPerfilId(long id)
        {
            List<DTO.Prato> eml = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_PratoS
                        where e.ID == id
                        select e;
                var list = await q.ToListAsync();
                eml = list;
            }
            return eml;
        }*/
    
    }
}
