using LinqToDB.Mapping;
using System;

namespace DTO
{
    /// <summary>
    /// Modelo do Fila
    /// </summary>
    [Table("TB_FILAS")]
    public partial class Fila
    {
        [PrimaryKey, NotNull]
        public int ID_FILA { get; set; } // integer
        [Column, Nullable]
        public long MATRICULA { get; set; } // interger
        [Column, Nullable]
        public string DATA { get; set; } // text(max)
        [Column, Nullable]
        public int QTD { get; set; } // integer
    }
}
