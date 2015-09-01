using LinqToDB.Mapping;
using System;

namespace DTO
{
    /// <summary>
    /// Modelo de Aluno
    /// </summary>
    [Table("TB_ALUNOS")]
    public class Aluno : Perfil
    {
        [Column, Nullable]
        public string TIPO { get; set; }
        [Column, Nullable]
        public bool SEG { get; set; }
        [Column, Nullable]
        public bool TER { get; set; }
        [Column, Nullable]
        public bool QUA { get; set; }
        [Column, Nullable]
        public bool QUI { get; set; }
        [Column, Nullable]
        public bool SEX { get; set; }
        // demais....
    }
    
}
