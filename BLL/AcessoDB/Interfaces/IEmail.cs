using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    interface IEmail
    {
        Task<List<Email>> EmailsPerfilId(long id);
    }
}
