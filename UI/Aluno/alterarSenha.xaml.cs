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

namespace UI.Aluno
{
    /// <summary>
    /// Interaction logic for alterarSenha.xaml
    /// </summary>
    public partial class alterarSenha : Window
    {
        private Session s;
        public alterarSenha(Session s)
        {
            this.s = s;
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
                BLL.Usuario usrBLL = new BLL.Usuario();
                DTO.Usuario usrDTO = s.User;

                s.User.SENHA = txtDigitarNov.Password;
                usrBLL.Alterar(s.User, true);

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
