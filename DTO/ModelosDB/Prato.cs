using LinqToDB.Mapping;
using System;

namespace DTO
{
    /// <summary>
    /// Modelo do Prato
    /// </summary>
    [Table("TB_PRATOS")]
    public partial class Prato
    {
        [PrimaryKey, NotNull]
        public int ID_PRATO { get; set; } // integer
        [Column, Nullable]
        public long MATRICULA { get; set; } // text(max)
        [Column, Nullable]
        public string CONTEUDO { get; set; } // text(max)
        [Column, Nullable]
        public string DATA { get; set; } // text(max)
    }
}
