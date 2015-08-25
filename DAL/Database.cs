using DTO;
using LinqToDB;
using System;
using System.ComponentModel;

namespace DAL
{
    public class Database
    {
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
                db.CreateTable<Perfil>();
                db.CreateTable<Email>();
                db.CreateTable<Telefone>();
            }
        }
        public ITable<T> Select<T>() where T : class
        {
            ITable<T> selection;
            using (var db = new DTO.Database()) {
                selection = db.GetTable<T>();
            }
            return selection;
        }

        public void Insert<T>(T element)
        {
            using (var db = new DTO.Database()) {
                db.Insert(element);
            }
        }

        public void Update<T>(T element)
        {
            using (var db = new DTO.Database()) {
                db.Update(element);
            }
        }

        public void Delete<T>(T element)
        {
            using (var db = new DTO.Database()) {
                db.Delete(element);
            }
        }
    }
}
