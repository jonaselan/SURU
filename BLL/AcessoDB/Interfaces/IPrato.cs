using System.Threading.Tasks;
using System.Collections.Generic;
namespace BLL
{
    /// <summary>
    /// Implementa funções relacionadas ao modelo de <typeparamref name="Prato"/>
    /// </summary>
    interface IPrato
    {
        void Inserir(DTO.Prato e);
        void Alterar(DTO.Prato e);
//        async Task<List<DTO.Prato>> Listar();
        void Remover(DTO.Prato e);
    }
}
