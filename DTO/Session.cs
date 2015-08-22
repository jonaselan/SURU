using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Session
    {
        Usuario user;
        
        public Usuario User {
            get { return this.user; }
            set { this.user = value; }
        }
    }
}
