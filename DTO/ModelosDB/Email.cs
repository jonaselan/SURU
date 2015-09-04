using LinqToDB.Mapping;
using System;

namespace DTO
{
    [Table("TB_EMAILS")]
    public partial class Email
    {
        [PrimaryKey, NotNull]
        public long ID { get; set; } // integer
        [Column, Nullable]
        public string ENDERECO { get; set; } // text(max)
        [Column, NotNull]
        public long ID_PERFIL { get; set; } // integer
    }
}
