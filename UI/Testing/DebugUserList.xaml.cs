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

        private async Task<List<ItemComposto>> GetDB() {
           
            UsuarioBLL usuariobll = new UsuarioBLL();
            PerfilBLL perfillbll = new PerfilBLL();
            TelefoneBLL telefonebll = new TelefoneBLL();
            EmailBLL emailbll = new EmailBLL();
            List<Usuario> usrs = await usuariobll.Listar();
            ItemComposto itemcomposto;
            List<ItemComposto> combined = new List<ItemComposto>();
            foreach (Usuario u in usrs) {
                itemcomposto = new ItemComposto();
                itemcomposto.Item1 = u;
                itemcomposto.Item2 = await perfillbll.ConsultarPorId(u.ID_PERFIL);
                List<Telefone> listatelefones = await telefonebll.TelefonesPerfilId(u.ID_PERFIL);
                List<Email> listaemails = await emailbll.EmailsPerfilId(u.ID_PERFIL);
                if (listatelefones.Count != 0) { itemcomposto.Item3 = listatelefones[0]; }
                if (listaemails.Count != 0) { itemcomposto.Item4 = listaemails[0]; }
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
            UsuarioBLL bll = new UsuarioBLL();
            dgUsuarios.ItemsSource = await GetDB();
        }

        private void dgUsuarios_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
        }
    }
}
