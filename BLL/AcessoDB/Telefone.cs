using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class Telefone : ITelefone, IDBElement<DTO.Telefone>
    {
        public void Alterar(DTO.Telefone t)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(t);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(t); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Update(t);
        }

        public async Task<DTO.Telefone> ConsultarPorId(long id)
        {
            DTO.Telefone tel = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_TELEFONES
                        where e.ID == id
                        select e;
                tel = await q.FirstOrDefaultAsync();
            }
            return tel;
        }

        public void Inserir(DTO.Telefone t)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(t);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(t); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Insert(t);
        }

        public void IsValido(DTO.Telefone e)
        {
            
        }

        public async Task<List<DTO.Telefone>> Listar()
        {
            DAL.Database db = new DAL.Database();
            var table = db.Select<DTO.Telefone>();
            return await table.ToListAsync(); ;
        }

        public void Remover(DTO.Telefone t)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(t);
            DAL.Database db = new DAL.Database();
            db.Delete(t);
        }

        public async Task<List<DTO.Telefone>> TelefonesPerfilId(long id)
        {
            List<DTO.Telefone> tel = null;
            using (var db = new DTO.Database())
            {
                var q = from e in db.TB_TELEFONES
                        where e.ID == id
                        select e;
                var list = await q.ToListAsync();
                tel = list;
            }
            return tel;
        }
    }
}
