using DTO;
using LinqToDB;

namespace DAL
{
    public class Database
    {
        public static void Acess() {
            using (var db = new UsuariosDB())
            {
                try
                {
                    db.CreateTable<Usuario>();
                }
                catch {
                    return;
                }
                db.CreateTable<Perfil>();
                db.CreateTable<Email>();
                db.CreateTable<Telefone>();
            }
        }
        public ITable<T> Select<T>() where T : class
        {
            Acess();
            ITable<T> selection;
            using (var db = new UsuariosDB()) {
                selection = db.GetTable<T>();
            }
            return selection;
        }

        public void Insert<T>(T element)
        {
            Acess();
            using (var db = new UsuariosDB()) {
                db.Insert(element);
            }
        }

        public void Update<T>(T element)
        {
            Acess();
            using (var db = new UsuariosDB()) {
                db.Update(element);
            }
        }

        public void Delete<T>(T element)
        {
            Acess();
            using (var db = new UsuariosDB()) {
                db.Delete(element);
            }
        }
    }
}
