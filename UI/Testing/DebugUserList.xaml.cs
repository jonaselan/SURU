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
            UsuarioBLL usuariobll = new UsuarioBLL();
            listUsuarios.ItemsSource = usuariobll.Listar();
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            if(listUsuarios.SelectedItem != null)
            {
                this.DialogResult = true;
            }
            else
            {
                MessageBoxResult errBox = MessageBox.Show("Nenhum usuário foi selecionado!", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
