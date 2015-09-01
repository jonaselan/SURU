using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Implementa funções relacionadas ao modelo de <typeparamref name="Usuario"/>
    /// </summary>
    interface IUsuario
    {
        Task<DTO.Usuario> ConsultarPorMatricula(string matricula);
        Task<DTO.Perfil> GetPerfil(DTO.Usuario u);
        void Inserir(DTO.Usuario u, ref DTO.Perfil p);
        void Alterar(DTO.Usuario u, ref DTO.Perfil p, bool hashSenha);
    }
}
