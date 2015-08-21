using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    class DBConnect
    {

        private string[] db_path = new string[2]{
            Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "db_users.xml",
             Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "db_perfis.xml"
        };

        private string dbfile;
        public DBConnect(int id) {
            this.dbfile = db_path[id];
        }

        public List<T> Select<T>()
        {
            List<T> objs;
            try
            {
                using (StreamReader f = new StreamReader(dbfile, Encoding.Default))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                    objs = (List<T>)xml.Deserialize(f);
                }
            }
            catch
            {
                objs = new List<T>();
            }
            return objs;
        }

        public void Insert<T>(T u)
        {
            List<T> objs = Select<T>();
            objs.Add(u);
            using (StreamWriter f = new StreamWriter(dbfile, false, Encoding.Default))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(f, objs);
            }
        }

        public void Update<T>(T u) where T : IComparable<T>
        {
            List<T> objs = Select<T>();
            var toUpdate = objs.Where(objeto => objeto.CompareTo(u) < 0).FirstOrDefault();
            if (toUpdate != null) {
                objs[objs.IndexOf(toUpdate)] = u;
            }
            using (StreamWriter f = new StreamWriter(dbfile, false, Encoding.Default))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(f, objs);
            }
        }

        public void Delete<T>(T u) where T : IComparable<T>
        {
            List<T> objs = Select<T>();
            var toDelete = objs.Where(objeto => objeto.CompareTo(u) < 0).FirstOrDefault();
            if (toDelete != null)
            {
                objs.Remove(toDelete);
            }
            using (StreamWriter f = new StreamWriter(dbfile, false, Encoding.Default))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(f, objs);
            }
        }
    }
}
