﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    interface IPerfil
    {
        Usuario ConsultarPorNome(string nome);
    }
}