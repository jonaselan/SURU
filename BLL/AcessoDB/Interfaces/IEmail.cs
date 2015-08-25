using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    interface IEmail
    {
        Task<List<DTO.Email>> EmailsPerfilId(long id);
    }
}
