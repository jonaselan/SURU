using System;
using LinqToDB.Mapping;

namespace DTO
{
    /*
        MODELO DE USUÁRIO
            1: Id - Identificação do usuário no database;
            2: Matricula - Matricula (IFRN);
            3: Senha - Senha de acesso;
            4: IsAdm - Se o usuario tem privilegios de administrador;
            5: IdPerfil - Id do perfil no banco de dados;
     */
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
        public long ISADM { get; set; } // integer
        [Column, NotNull]
        public long ID_PERFIL { get; set; } // integer
    }
}
