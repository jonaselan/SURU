using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;
using DTO;

namespace BLL
{
    public class Administrador : IPerfil<DTO.Administrador>, IAdministrador, IDBElement<DTO.Administrador>
    {
        public void Alterar(DTO.Administrador e)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(e);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Update(e);
        }

        public async Task<DTO.Administrador> ConsultarPorID(long id)
        {
            DTO.Administrador admin = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_ADMINISTRADORES
                        where p.ID == id
                        select p;
                admin = await q.FirstOrDefaultAsync();
            }
            return admin;
        }

        public async Task<DTO.Administrador> ConsultarPorNome(string nome)
        {
            DTO.Administrador admin = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_ADMINISTRADORES
                        where p.NOME == nome
                        select p;
                admin = await q.FirstOrDefaultAsync();
            }
            return admin;
        }

        public void Inserir(DTO.Administrador e)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(e);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(e); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Insert(e);
        }

        public void IsValido(DTO.Administrador e)
        {
            if (e.NOME == "") { throw new Exception("Nome inválido"); }
        }

        public async Task<List<DTO.Administrador>> Listar()
        {
            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();

            // ADQUIRINDO TABELA DE PERFIS
            var table = db.Select<DTO.Administrador>();

            return await table.ToListAsync(); ;
        }

        public void Remover(DTO.Administrador e)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(e);

            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();

            db.Delete(e);
        }
    }
}
