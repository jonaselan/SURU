using System.Threading.Tasks;
using System.Collections.Generic;
namespace BLL
{
    /// <summary>
    /// Implementa funções relacionadas ao modelo de <typeparamref name="Fila"/>
    /// </summary>
    interface IFila
    {
        void Inserir(DTO.Fila e);
        void Alterar(DTO.Fila e);
        //        async Task<List<DTO.Prato>> Listar();
        void Remover(DTO.Fila e);
    }
}
