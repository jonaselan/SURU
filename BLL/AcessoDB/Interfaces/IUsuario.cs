using System.Threading.Tasks;

namespace BLL
{
    interface IUsuario
    {
        Task<DTO.Usuario> ConsultarPorMatricula(string matricula);
        void Inserir(DTO.Usuario u, DTO.Perfil p);
        void Alterar(DTO.Usuario u, DTO.Perfil p, bool hashSenha);
    }
}
