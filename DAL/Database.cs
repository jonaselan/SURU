using DTO;
using LinqToDB;

namespace DAL
{
    public class Database
    {
        /// <summary>
        /// Caso não exista, a DB é criada.
        /// </summary>
        public static void Create() {
            using (var db = new DTO.Database())
            {
                try
                {
                    db.CreateTable<Usuario>();
                }
                catch {
                    return;
                }
                db.CreateTable<Aluno>();
                db.CreateTable<Administrador>();
                db.CreateTable<Email>();
                db.CreateTable<Telefone>();
                db.CreateTable<Prato>();
            }
        }

        /// <summary>
        /// Seleciona todos os valores da tabela T no banco de dados.<para/>Equivalente ao "SELECT * FROM T".
        /// </summary>
        /// <typeparam name="T">Tipo do objetos na tabela.</typeparam>
        /// <returns>Tabela com objetos do tipo T.</returns>
        public ITable<T> Select<T>() where T : class
        {
            ITable<T> selection;
            using (var db = new DTO.Database()) {
                selection = db.GetTable<T>();
            }
            return selection;
        }

        /// <summary>
        /// Insere o objeto do tipo T em sua tabela equivalente no banco de dados.
        /// </summary>
        /// <typeparam name="T">Tipo dos objetos na tabela.</typeparam>
        /// <param name="element">Objeto a ser adicionado a tabela.</param>
        public void Insert<T>(T element)
        {
            using (var db = new DTO.Database()) {
                db.Insert(element);
            }
        }

        /// <summary>
        /// Atualiza o objeto do tipo T em sua tabela equivalente no banco de dados.
        /// </summary>
        /// <typeparam name="T">Tipo dos objetos na tabela.</typeparam>
        /// <param name="element">Objeto a ser atualizado na tabela.</param>
        public void Update<T>(T element)
        {
            using (var db = new DTO.Database()) {
                db.Update(element);
            }
        }

        /// <summary>
        /// Remove o objeto do tipo T da sua tabela equivalente no banco de dados.
        /// </summary>
        /// <typeparam name="T">Tipo dos objetos na tabela.</typeparam>
        /// <param name="element">Objeto a ser removido da tabela.</param>
        public void Delete<T>(T element)
        {
            using (var db = new DTO.Database()) {
                db.Delete(element);
            }
        }
    }
}
