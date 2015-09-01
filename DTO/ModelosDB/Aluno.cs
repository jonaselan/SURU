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
    }
    
}
