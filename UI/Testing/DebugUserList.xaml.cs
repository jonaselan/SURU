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

        private async Task<List<ItemComposto>> GetDB() {
           
            BLL.Usuario usuariobll = new BLL.Usuario();
            BLL.Perfil perfillbll = new BLL.Perfil();
            BLL.Telefone telefonebll = new BLL.Telefone();
            BLL.Email emailbll = new BLL.Email();
            ItemComposto itemcomposto;
            List<ItemComposto> combined = new List<ItemComposto>();

            foreach (Usuario u in await usuariobll.Listar()) {
                itemcomposto = new ItemComposto();
                itemcomposto.Item1 = u;
                itemcomposto.Item2 = await perfillbll.ConsultarPorId(u.ID_PERFIL);
                List<Telefone> listatelefones = await telefonebll.TelefonesPerfilId(u.ID_PERFIL);
                List<Email> listaemails = await emailbll.EmailsPerfilId(u.ID_PERFIL);
                itemcomposto.Item3 = listatelefones.FirstOrDefault();
                itemcomposto.Item4 = listaemails.FirstOrDefault();
                combined.Add(itemcomposto);
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

        private async void DebugUserListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            BLL.Usuario bll = new BLL.Usuario();
            dgUsuarios.ItemsSource = await GetDB();
        }

        private void dgUsuarios_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            btnSelecionar.IsEnabled = true;
        }
    }
}
