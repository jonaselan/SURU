using System.Linq;

using LinqToDB;

namespace DTO
{
    public partial class Database : LinqToDB.Data.DataConnection
    {
        public ITable<Email> TB_EMAILS { get { return this.GetTable<Email>(); } }
        public ITable<Aluno> TB_ALUNOS { get { return this.GetTable<Aluno>(); } }
        public ITable<Administrador> TB_ADMINISTRADORES { get { return this.GetTable<Administrador>(); } }
        public ITable<Telefone> TB_TELEFONES { get { return this.GetTable<Telefone>(); } }
        public ITable<Usuario> TB_USUARIOS { get { return this.GetTable<Usuario>(); } }
        public ITable<Prato> TB_PRATOS { get { return this.GetTable<Prato>(); } }
        public ITable<Fila> TB_FILAS { get { return this.GetTable<Fila>(); } }

        public Database()
        {
            InitDataContext();
        }

        public Database(string configuration)
            : base(configuration)
        {
            InitDataContext();
        }

        partial void InitDataContext();
    }

    public static partial class TableExtensions
    {
        public static Email Find(this ITable<Email> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }

        public static Aluno Find(this ITable<Aluno> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }

        public static Administrador Find(this ITable<Administrador> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }

        public static Telefone Find(this ITable<Telefone> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }

        public static Usuario Find(this ITable<Usuario> table, string MATRICULA)
        {
            return table.FirstOrDefault(t =>
                t.MATRICULA == MATRICULA);
        }
        public static Prato Find(this ITable<Prato> table, int ID_PRATO)
        {
            return table.FirstOrDefault(t =>
                t.ID_PRATO == ID_PRATO);
        }
        public static Fila Find(this ITable<Fila> table, int ID_FILA)
        {
            return table.FirstOrDefault(t =>
                t.ID_FILA == ID_FILA);
        }

    }
}
