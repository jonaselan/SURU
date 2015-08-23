using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /* Modelo de Aluno, aqui ficara as informações bolsista, diaria, etc. */
    public class Aluno : Perfil
    {
        private bool isBolsista;
        private bool segunda;
        private bool terca;
        private bool quarta;
        private bool quinta;
        private bool sexta;
        private string curso;
        private string turno;
        private string semestre;

        public bool IsBolsista
        {
            set { this.isBolsista = value; }
            get { return this.isBolsista; }

        }

        public bool Segunda 
        {

            set { this.segunda = value; }
            get { return this.segunda; }
        
        }

        public bool Terca
        {

            set { this.terca = value; }
            get { return this.terca; }

        }

        public bool Quarta
        {

            set { this.quarta = value; }
            get { return this.quarta; }

        }

        public bool Quinta
        {

            set { this.quinta = value; }
            get { return this.quinta; }

        }

        public bool Sexta
        {

            set { this.sexta = value; }
            get { return this.sexta; }

        }

        public string Curso 
        {
            set { this.curso = value; }
            get { return this.curso; }
        }

        public string Turno 
        {
            set { this.turno = value; }
            get { return this.turno; }
        }

        public string Semestre 
        {
            set { this.semestre = value; }
            get { return this.semestre; }
        }
    }
}
