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

namespace UI.Aluno
{
    /// <summary>
    /// Interaction logic for alterarSenha.xaml
    /// </summary>
    public partial class alterarSenha : Window
    {
        public alterarSenha()
        {
            InitializeComponent();
        }
        
        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDigitarNov.Password != txtNovaSenha.Password)
            {
                MessageBox.Show("Senhas não são iguais!");
            }
            else
            {
                // modificar senha

            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtDigitarNov.Password != txtNovaSenha.Password)
            {
                txAviso.Visibility = Visibility.Visible;
            }
            else txAviso.Visibility = Visibility.Hidden;
        }
    }
}
