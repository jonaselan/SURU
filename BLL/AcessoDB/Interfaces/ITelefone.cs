using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    interface ITelefone
    {
        Task<List<DTO.Telefone>> TelefonesPerfilId(long id);
    }
}
