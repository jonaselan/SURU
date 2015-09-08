using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;
using DTO;

namespace BLL
{
    /// <summary>
    /// Lógica de interação do modelo de <typeparamref name="Usuario"/>
    /// </summary>
    public class Usuario : IUsuario, IDBElement<DTO.Usuario>
    {

        #region Métodos de BUSCA
        /// <summary>
        /// Lista todos os usuários do banco de dados.
        /// </summary>
        /// <returns>Um <typeparamref name="Task"/> contendo a listagem dos usuários no banco de dados.</returns>
        public async Task<List<DTO.Usuario>> Listar()
        {
            DAL.Database db = new DAL.Database();
            var table = db.Select<DTO.Usuario>();
            return await table.ToListAsync(); ;
        }

        /// <summary>
        /// Procura um <typeparamref name="Usuario"/> no banco dedados com as propriedades fornecidas.
        /// </summary>
        /// <param name="ID">Id do <typeparamref name="Usuario"/> a ser procurado.</param>
        /// <param name="MATRICULA">Matricula do <typeparamref name="Usuario"/> a ser procurado.</param>
        /// <param name="SENHA">Senha do <typeparamref name="Usuario"/> a ser procurado.</param>
        /// <param name="ID_PERFIL">Id do <typeparamref name="Perfil"/> que pertence ao <typeparamref name="Usuario"/> a ser procurado.</param>
        /// <returns>Um <typeparamref name="Task"/> contendo o resultado da busca.</returns>
        public async Task<DTO.Usuario> Procurar(long ID = -1, string MATRICULA = null, string SENHA = null, long ID_PERFIL = -1)
        {
            DTO.Usuario usr = null;
            using (var db = new DTO.Database())
            {
                var q = from u in db.TB_USUARIOS
                        where u.MATRICULA == MATRICULA ||
                              u.SENHA == SENHA ||
                              u.ID_PERFIL == ID_PERFIL
                        select u;
                usr = await q.FirstOrDefaultAsync();
            }
            return usr;
        }

        /// <summary>
        /// Procura um <typeparamref name="Usuario"/> no banco de dados de acordo com a matricula fornecida
        /// </summary>
        /// <param name="matricula">Matricula do <typeparamref name="Usuario"/> a ser consultado.</param>
        /// <returns>Um <typeparamref name="Task"/> com o <typeparamref name="Usuario"/> encontrado.</returns>
        public async Task<DTO.Usuario> ConsultarPorMatricula(string matricula)
        {
            DTO.Usuario usr = null;
            using (var db = new DTO.Database())
            {
                var q = from u in db.TB_USUARIOS
                        where u.MATRICULA == matricula
                        select u;
                usr = await q.FirstOrDefaultAsync();
            }
            return usr;
        }
        #endregion

        #region Métodos de MANIPULAÇÃO de dados
        public void Inserir(DTO.Usuario u, DTO.Aluno p)
        {

            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            ///* CHECAGEM DOS VALORES INSERIDOS */

            try { IsValido(u); } catch (Exception ex) { throw ex; }

            ///* HASH DA SENHA */
            u.SENHA = DBElementHandling.Hash(u.SENHA);

            // TENTAR INSERIR O PERFIL
            Aluno abll = new Aluno();
            try { abll.Inserir(p); } catch (Exception ex) { throw ex; }

            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Insert(u);
        }

        public void Inserir(DTO.Usuario u, DTO.Administrador p)
        {

            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            ///* CHECAGEM DOS VALORES INSERIDOS */

            try { IsValido(u); }
            catch (Exception ex) { throw ex; }

            ///* HASH DA SENHA */
            u.SENHA = DBElementHandling.Hash(u.SENHA);

            // TENTAR INSERIR O PERFIL
            Administrador abll = new Administrador();
            try { abll.Inserir(p); }
            catch (Exception ex) { throw ex; }

            ///* CONECTANDO AO DB */
            DAL.Database db = new DAL.Database();
            db.Insert(u);
        }

        public void Alterar(DTO.Usuario u, DTO.Administrador p, bool hashSenha = true)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(u);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(u); } catch (Exception ex) { throw ex; }

            // HASH DA SENHA
            if (hashSenha)
                u.SENHA = DBElementHandling.Hash(u.SENHA);

            // TENTAR ALTERAR O PERFIL
            Administrador abll = new Administrador();
            try { abll.Alterar(p); } catch (Exception ex) { throw ex; }

            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Update(u);
        }

        public void Alterar(DTO.Usuario u, bool hashSenha = true)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(u);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(u); }
            catch (Exception ex) { throw ex; }

            // HASH DA SENHA
            if (hashSenha)
                u.SENHA = DBElementHandling.Hash(u.SENHA);

            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Update(u);
        }

        public void Alterar(DTO.Usuario u, DTO.Aluno p, bool hashSenha = true)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(u);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(u); }
            catch (Exception ex) { throw ex; }

            // HASH DA SENHA
            if (hashSenha)
                u.SENHA = DBElementHandling.Hash(u.SENHA);

            // TENTAR ALTERAR O PERFIL
            Aluno abll = new Aluno();
            try { abll.Alterar(p); }
            catch (Exception ex) { throw ex; }

            // CONECTANDO AO DB
            // modificar usuário
            DAL.Database db = new DAL.Database();
            db.Update(u);
        }

        public void Alterar(DTO.Usuario u, bool hashSenha = true)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(u);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(u); }
            catch (Exception ex) { throw ex; }

            // HASH DA SENHA
            if (hashSenha)
                u.SENHA = DBElementHandling.Hash(u.SENHA);

            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Update(u);
        }
        
        public async void Remover(DTO.Usuario u)
        {

            ///* RETIRANDO OS ESPAÇOS */
            DBElementHandling.RemoverEspacos(u);

            u = await ConsultarPorMatricula(u.MATRICULA);

            if (u == null) { throw new Exception("Usuário não encontrado"); }

            // TENTAR REMOVER O PERFIL
            if (u.ISADM)
            {
                Administrador abll = new Administrador();
                DTO.Administrador p = await abll.ConsultarPorID(u.ID_PERFIL);
                try { abll.Remover(p); } catch (Exception ex) { throw ex; }
            }
            else
            {
                Aluno abll = new Aluno();
                DTO.Aluno p = await abll.ConsultarPorID(u.ID_PERFIL);
                try { abll.Remover(p); } catch (Exception ex) { throw ex; }
            }

            DAL.Database db = new DAL.Database();
            db.Delete(u);
        }

        public void Inserir(DTO.Usuario e)
        {
            throw new Exception("Perfil não especificado.");
        }

        public void Alterar(DTO.Usuario e)
        {
            throw new Exception("Perfil não especificado.");
        }
        #endregion

        #region Métodos de VERIFICAÇÃO
        public void IsValido(DTO.Usuario u)
        {
            if (u.MATRICULA == "") { throw new Exception("Matrícula inválida"); }
            if (u.SENHA == "") { throw new Exception("Senha inválida"); }
        }

        public async Task<Perfil> GetPerfil(DTO.Usuario u)
        {
            Perfil p = null;
            if (u.ISADM)
            {
                Administrador abll = new Administrador();
                p = await abll.ConsultarPorID(u.ID_PERFIL);
            }
            else
            {
                Aluno abll = new Aluno();
                p = await abll.ConsultarPorID(u.ID_PERFIL);
            }
            return p;
        }
        #endregion
    }
}
