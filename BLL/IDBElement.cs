using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IDBElement<T>
    {
        List<T> Listar();
        void Inserir(T e);
        void Alterar(T e);
        void Remover(T e);
        T ConsultarPorId(int id);
        void IsValido(T e);
    }
}
