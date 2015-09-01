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
        void Inserir(DTO.Usuario u, DTO.Administrador p);
        void Alterar(DTO.Usuario u, DTO.Administrador p, bool hashSenha);
        void Inserir(DTO.Usuario u, DTO.Aluno p);
        void Alterar(DTO.Usuario u, DTO.Aluno p, bool hashSenha);
    }
}
