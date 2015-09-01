using System.Collections.Generic;
using LinqToDB;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BLL
{
    /// <summary>
    /// Lógica de interação do modelo de <typeparamref name="Perfil"/>
    /// </summary>
    public class Perfil : IPerfil, IDBElement<DTO.Perfil>
    {

        #region Métodos de BUSCA
        /// <summary>
        /// Procura um <typeparamref name="Perfil"/> no banco de dados de acordo com o id fornecido
        /// </summary>
        /// <param name="id">Id do <typeparamref name="Perfil"/> a ser consultado.</param>
        /// <returns>Um <typeparamref name="Task"/> com o <typeparamref name="Perfil"/> encontrado.</returns>
        public async Task<DTO.Perfil> ConsultarPorId(long id)
        {
            DTO.Perfil perf = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_ALUNOS
                        where p.ID == id
                        select p;
                perf = await q.FirstOrDefaultAsync();
            }
            return perf;
        }

        /// <summary>
        /// Procura um <typeparamref name="Perfil"/> no banco de dados de acordo com o nome fornecido
        /// </summary>
        /// <param name="nome">Nome do <typeparamref name="Perfil"/> a ser consultado.</param>
        /// <returns>Um <typeparamref name="Task"/> com o <typeparamref name="Perfil"/> encontrado.</returns>
        public async Task<DTO.Perfil> ConsultarPorNome(string nome)
        {
            DTO.Perfil perf = null;
            using (var db = new DTO.Database())
            {
                var q = from p in db.TB_ALUNOS
                        where p.NOME == nome
                        select p;
                perf = await q.FirstOrDefaultAsync();
            }
            return perf;
        }

        #endregion

        #region Métodos de MANIPULAÇÃO de dados

        /// <summary>
        /// Adiciona o <typeparamref name="Perfil"/> fornecido ao banco de dados.
        /// </summary>
        /// <param name="p">Perfil a ser inserido.</param>
        public void Inserir(DTO.Perfil p)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(p);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(p); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Insert(p);
        }

        /// <summary>
        /// Altera no banco de dados o <typeparamref name="Perfil"/> fornecido.
        /// </summary>
        /// <param name="p">Perfil a ser alterado.</param>
        public void Alterar(DTO.Perfil p)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(p);

            // CHECAGEM DOS VALORES INSERIDOS
            try { IsValido(p); } catch (Exception ex) { throw ex; }


            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();
            db.Update(p);
        }

        /// <summary>
        /// Remove o <typeparamref name="Perfil"/> fornecido do banco de dados.
        /// </summary>
        /// <param name="p">Perfil a ser removido.</param>
        public void Remover(DTO.Perfil p)
        {
            // RETIRANDO OS ESPAÇOS
            DBElementHandling.RemoverEspacos(p);

            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();

            db.Delete(p);
        }
        #endregion

        /// <summary>
        /// Checa se os atributos do <typeparamref name="Perfil"/> são é validos.
        /// </summary>
        /// <param name="p">Perfil a ser checado.</param>
        public void IsValido(DTO.Perfil p)
        {
            if (p.NOME == "") { throw new Exception("Nome inválido"); }
        }

        /// <summary>
        /// Lista todos os perfis do banco de dados.
        /// </summary>
        /// <returns>Um <typeparamref name="Task"/> contendo a listagem dos perfis no banco de dados.</returns>
        public async Task<List<DTO.Perfil>> Listar()
        {
            // CONECTANDO AO DB
            DAL.Database db = new DAL.Database();

            // ADQUIRINDO TABELA DE PERFIS
            var table = db.Select<DTO.Perfil>();

            return await table.ToListAsync(); ;
        }

    }
}
