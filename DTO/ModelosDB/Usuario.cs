using LinqToDB.Mapping;

namespace DTO
{
    /// <summary>
    /// Modelo de Usuário
    /// </summary>
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        [PrimaryKey, NotNull]
        public long ID { get; set; } // integer
        [Column, NotNull]
        public string MATRICULA { get; set; } // text(max)
        [Column, NotNull]
        public string SENHA { get; set; } // text(max)
        [Column, NotNull]
        public bool ISADM { get; set; } // integer
        [Column, NotNull]
        public long ID_PERFIL { get; set; } // integer
    }
}
