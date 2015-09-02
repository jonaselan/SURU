using DTO;
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

namespace UI.Adm
{
    /// <summary>
    /// Interaction logic for wAdministrador.xaml
    /// </summary>
    public partial class wAdministrador : Window
    {
        public wAdministrador(Session s)
        {
            InitializeComponent();
        }

        private void btnFila_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAluno_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //try {
            if (e.ClickCount == 1)
            {
            wCadastroUsuarios cadastro = new wCadastroUsuarios();
            cadastro.Show();
            }
            //}
            /**catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }**/
        }

        private void btnCardapio_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
