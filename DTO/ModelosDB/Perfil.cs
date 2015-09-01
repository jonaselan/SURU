﻿using LinqToDB.Mapping;
using System;

namespace DTO
{
    /// <summary>
    /// Modelo de Perfil
    /// </summary>
    //[Table("TB_PERFIS")]
    public partial class Perfil
    {
        [PrimaryKey, NotNull]
        public long ID { get; set; } // integer
        [Column, Nullable]
        public string NOME { get; set; } // text(max)
    }
}
