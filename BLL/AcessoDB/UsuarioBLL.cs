using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using DTO;
using DAL;
using System.Threading.Tasks;
using System;

namespace BLL
{
    public class UsuarioBLL : IUsuario, IDBElement<Usuario>
    {
        public async Task<List<Usuario>> Listar()
        {
            Database db = new Database();
            var table = db.Select<Usuario>();
            return await table.ToListAsync(); ;
        }

        public void Inserir(Usuario u, Perfil p)
        {

            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            ///* CHECAGEM DOS VALORES INSERIDOS */

            try { IsValido(u); } catch (Exception ex) { throw ex; }

            ///* HASH DA SENHA */
            u.SENHA = DBElementHandling.Hash(u.SENHA);
            
            ///* TENTAR INSERIR O PERFIL */
            PerfilBLL pbll = new PerfilBLL();
            try { pbll.Inserir(p); } catch(Exception ex) { throw ex; }
            
            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Insert(u);
        }

        public async Task<Usuario> ConsultarPorMatricula(string matricula)
        {
            Database.Acess();
            Usuario usr = null;
            using (var db = new UsuariosDB()) {
                var q = from u in db.TB_USUARIOS
                        where u.MATRICULA == matricula
                        select u;
                usr = await q.FirstOrDefaultAsync();
            }
            return usr;
        }

        public void Alterar(Usuario u, Perfil p)
        {

            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            ///* CHECAGEM DOS VALORES INSERIDOS */
            try { IsValido(u); } catch (Exception ex) { throw ex; }

            ///* TENTAR ALTERAR O PERFIL */
            PerfilBLL pbll = new PerfilBLL();

            try { pbll.Alterar(p); } catch (Exception ex) { throw ex; }

            ///* CONECTANDO AO DB */
            Database db = new Database();
            db.Update(u);
        }

        public async void Remover(Usuario u)
        {

            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            u = await ConsultarPorMatricula(u.MATRICULA);

            if (u == null) { throw new Exception("Usuário não encontrado"); } ;

            PerfilBLL pbll = new PerfilBLL();

            Perfil p = await pbll.ConsultarPorId(u.ID_PERFIL);

            try { pbll.Remover(p); } catch (Exception ex) { throw ex; }

            Database db = new Database();
            db.Delete(u);
        }

        public async Task<Usuario> ConsultarPorId(long id)
        {
            Database.Acess();
            Usuario usr = null;
            using (var db = new UsuariosDB())
            {
                var q = from u in db.TB_USUARIOS
                        where u.ID == id
                        select u;
                usr = await q.FirstOrDefaultAsync();
            }
            return usr;
        }

        public void IsValido(Usuario u)
        {
            if (u.MATRICULA == "") { throw new Exception("Matrícula inválida"); }
            if (u.SENHA == "") { throw new Exception("Senha inválida"); }
        }

        public void Inserir(Usuario e)
        {
            throw new Exception("Perfil não especificado.");
        }

        public void Alterar(Usuario e)
        {
            throw new Exception("Perfil não especificado.");
        }
    }
}
