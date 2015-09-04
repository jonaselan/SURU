using LinqToDB.Mapping;
using System;

namespace DTO
{
    /// <summary>
    /// Modelo de Telefone
    /// </summary>
    [Table("TB_TELEFONES")]
    public partial class Telefone
    {
        [PrimaryKey, NotNull]
        public long ID { get; set; } // integer
        [Column, Nullable]
        public string NUMERO { get; set; } // text(max)
        [Column, NotNull]
        public long ID_PERFIL { get; set; } // integer
    }
}
