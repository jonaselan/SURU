using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    /* 
    INTERFACE do usuário
        404 ?
     */
    interface IUsuario
    {
        Usuario ConsultarPorMatricula(string matricula);
        void Inserir(Usuario u, Perfil p);
        void Alterar(Usuario u, Perfil p);
    }
}
