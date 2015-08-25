using System.Linq;

using LinqToDB;

namespace DTO
{
    public partial class Database : LinqToDB.Data.DataConnection
    {
        public ITable<Email> TB_EMAILS { get { return this.GetTable<Email>(); } }
        public ITable<Perfil> TB_PERFIS { get { return this.GetTable<Perfil>(); } }
        public ITable<Telefone> TB_TELEFONES { get { return this.GetTable<Telefone>(); } }
        public ITable<Usuario> TB_USUARIOS { get { return this.GetTable<Usuario>(); } }

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

        public static Perfil Find(this ITable<Perfil> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }

        public static Telefone Find(this ITable<Telefone> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }

        public static Usuario Find(this ITable<Usuario> table, long ID)
        {
            return table.FirstOrDefault(t =>
                t.ID == ID);
        }
    }
}
