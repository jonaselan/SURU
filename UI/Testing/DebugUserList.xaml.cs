using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using BLL;

namespace UI.Testing
{
    /// <summary>
    /// Interaction logic for DebugUserList.xaml
    /// </summary>
    public partial class DebugUserList : Window
    {
        public DebugUserList()
        {
            InitializeComponent();
        }

        private List<ItemComposto> GetDB() {
            UsuarioBLL usuariobll = new UsuarioBLL();
            PerfilBLL perfillbll = new PerfilBLL();
            List<Usuario> usrs = usuariobll.Listar();
            List<Perfil> perfis = perfillbll.Listar();
            ItemComposto itemcomposto;
            List<ItemComposto> combined = new List<ItemComposto>();
            foreach (Perfil p in perfis) {
                foreach (Usuario u in usrs.Where(us => us.IdPerfil == p.Id)) {
                    itemcomposto = new ItemComposto();
                    itemcomposto.Item1 = u;
                    itemcomposto.Item2 = p;
                    combined.Add(itemcomposto);
                }
            }
            return combined;
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void listUsuarios_Selected(object sender, RoutedEventArgs e)
        {
            btnSelecionar.IsEnabled = true;
        }

        private void DebugUserListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dgUsuarios.ItemsSource = GetDB();
        }

        private void dgUsuarios_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}
