using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// Implementa funcionalidade a perfis relacionados ao banco de dados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IPerfil<T>
    {
        Task<T> ConsultarPorID(long id);
        Task<T> ConsultarPorNome(string nome);
    }
}