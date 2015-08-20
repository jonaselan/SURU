using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace DAL
{
    class Usuario
    {
        private string tabela_usuarios = "c:\\banco\\usuario.xml";

        public List<BLL.Usuario> Select() 
        {
            List<BLL.Usuario> objs;
            try
            {
                using (StreamReader f = new StreamReader(tabela_usuarios, Encoding.Default))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<BLL.Usuario>));
                    objs = (List<BLL.Usuario>)xml.Deserialize(f);
                }
            }
            catch 
            {
                objs = new List<BLL.Usuario>(); 
            }

            return objs;
        }

        public void Insert(BLL.Usuario usuario) 
        {
            List<BLL.Usuario> objs = Select();
            objs.Add(usuario);
            using (StreamWriter f = new StreamWriter(tabela_usuarios, false, Encoding.Default)) 
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<BLL.Usuario>));
                xml.Serialize(f, objs);
            }
        }
    }
}
