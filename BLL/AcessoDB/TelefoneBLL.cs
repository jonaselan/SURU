using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using DTO;
using DAL;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class TelefoneBLL : ITelefone, IDBElement<Telefone>
    {
        public void Alterar(Telefone t)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(t);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(t); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Update(t);
        }

        public async Task<Telefone> ConsultarPorId(long id)
        {
            Telefone tel = null;
            using (var db = new UsuariosDB())
            {
                var q = from e in db.TB_TELEFONES
                        where e.ID == id
                        select e;
                tel = await q.FirstOrDefaultAsync();
            }
            return tel;
        }

        public void Inserir(Telefone t)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(t);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(t); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Insert(t);
        }

        public void IsValido(Telefone e)
        {
            
        }

        public async Task<List<Telefone>> Listar()
        {
            Database db = new Database();
            var table = db.Select<Telefone>();
            return await table.ToListAsync(); ;
        }

        public void Remover(Telefone t)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(t);
            Database db = new Database();
            db.Delete(t);
        }

        public async Task<List<Telefone>> TelefonesPerfilId(long id)
        {
            List<Telefone> tel = null;
            using (var db = new UsuariosDB())
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
