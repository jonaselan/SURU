using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Implementa funções relacionadas ao modelo de <typeparamref name="Usuario"/>
    /// </summary>
    interface IUsuario
    {
        Task<DTO.Usuario> ConsultarPorMatricula(string matricula);
        void Inserir(DTO.Usuario u, DTO.Perfil p);
        void Alterar(DTO.Usuario u, DTO.Perfil p, bool hashSenha);
    }
}
