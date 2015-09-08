using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class Fila : IFila, IDBElement<DTO.Fila>
    {
        public void Alterar(DTO.Fila e)
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

        public async Task<DTO.Fila> ConsultarPorData(DateTime data)
        {
            DTO.Fila eml = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_FILAS
                        where e.DATA == data
                        select e;
                eml = await q.FirstOrDefaultAsync();
            }
            return eml;
        }

        public void Inserir(DTO.Fila e)
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

        public void IsValido(DTO.Fila e) { }

        public async Task<List<DTO.Fila>> Listar()
        {
            DAL.Database db = new DAL.Database();
            var table = db.Select<DTO.Fila>();
            return await table.ToListAsync(); ;
        }

        public void Remover(DTO.Fila e)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(e);
            DAL.Database db = new DAL.Database();
            db.Delete(e);
        }
    }
}
