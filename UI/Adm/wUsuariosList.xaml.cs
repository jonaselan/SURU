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

namespace UI.Adm
{
    /// <summary>
    /// Interaction logic for wUsuariosList.xaml
    /// </summary>
    public partial class wUsuariosList : Window
    {
        public wUsuariosList()
        {
            InitializeComponent();
        }

        private async Task<List<ItemComposto>> GetDB()
        {

            BLL.Usuario usuariobll = new BLL.Usuario();
            BLL.Telefone telefonebll = new BLL.Telefone();
            BLL.Email emailbll = new BLL.Email();
            ItemComposto itemcomposto;
            List<ItemComposto> combined = new List<ItemComposto>();

            foreach (Usuario u in await usuariobll.Listar())
            {
                itemcomposto = new ItemComposto();
                itemcomposto.Item1 = u;
                itemcomposto.Item2 = await usuariobll.GetPerfil(u);
                List<Telefone> listatelefones = await telefonebll.TelefonesPerfilId(u.ID_PERFIL);
                List<Email> listaemails = await emailbll.EmailsPerfilId(u.ID_PERFIL);
                itemcomposto.Item3 = listatelefones.FirstOrDefault();
                itemcomposto.Item4 = listaemails.FirstOrDefault();
                combined.Add(itemcomposto);
            }
            return combined;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BLL.Usuario bll = new BLL.Usuario();
            dgUsuarios.ItemsSource = await GetDB();
        }

        private void dgUsuarios_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            btnSelecionar.IsEnabled = true;
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
