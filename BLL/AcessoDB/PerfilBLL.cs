using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using DTO;
using DAL;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class PerfilBLL : IPerfil, IDBElement<Perfil>
    {
        public void Alterar(Perfil p)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(p); } catch (Exception ex) { throw ex; }


            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Update(p);
        }

        public async Task<Perfil> ConsultarPorId(long id)
        {
            Database.Acess();
            Perfil perf = null;
            using (var db = new UsuariosDB())
            {
                var q = from p in db.TB_PERFIS
                        where p.ID == id
                        select p;
                var list = await q.ToListAsync();
                if (list[0] != null)
                {
                    perf = list[0];
                }
            }
            return perf;
        }

        public async Task<Perfil> ConsultarPorNome(string nome)
        {
            Database.Acess();
            Perfil perf = null;
            using (var db = new UsuariosDB())
            {
                var q = from p in db.TB_PERFIS
                        where p.NOME == nome
                        select p;
                perf = await q.FirstOrDefaultAsync();
            }
            return perf;
        }

        public void Inserir(Perfil p)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(p); } catch(Exception ex) { throw ex; }
            

            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Insert(p);
        }

        public void IsValido(Perfil p)
        {
            if (p.NOME == "") { throw new Exception("Nome inválido"); }
        }

        public async Task<List<Perfil>> Listar()
        {
            Database db = new Database();
            var table = db.Select<Perfil>();
            return await table.ToListAsync(); ;
        }

        public void Remover(Perfil p)
        {
            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(p);
            Database db = new Database();
            db.Delete(p);
        }
    }
}
