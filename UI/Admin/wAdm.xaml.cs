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

namespace UI.Admin
{
    /// <summary>
    /// Interaction logic for wAdm.xaml
    /// </summary>
    public partial class wAdm : Window
    {
        public wAdm()
        {
            InitializeComponent();
        }

        private async void dgPratos_Loaded(object sender, RoutedEventArgs e)
        {
            BLL.Prato pBLL = new BLL.Prato();
            dgPratos.ItemsSource = await pBLL.Listar();
        }

    }
}
