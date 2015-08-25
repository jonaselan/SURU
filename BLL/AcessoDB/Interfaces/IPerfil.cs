using System.Threading.Tasks;

namespace BLL
{
    
    interface IPerfil
    {
        Task<DTO.Perfil> ConsultarPorNome(string nome);
    }
}
