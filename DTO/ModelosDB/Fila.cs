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
        public DateTime DATA { get; set; } // Date
        [Column, Nullable]
        public long MATRICULA { get; set; } // interger
    }
}
