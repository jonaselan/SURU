using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    interface IDBElement<T>
    {
        Task<List<T>> Listar();
        void Inserir(T e);
        void Alterar(T e);
        void Remover(T e);
        Task<T> ConsultarPorId(long id);
        void IsValido(T e);
    }
}
