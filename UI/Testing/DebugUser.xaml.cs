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
using System.ComponentModel;
using System.Windows.Threading;

namespace UI.Testing
{
    /// <summary>
    /// Interaction logic for DebugUser.xaml
    /// </summary>
    public partial class DebugUser : Window
    {
        public DebugUser()
        {
            InitializeComponent();
            ConsoleManager.Show();
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            DebugUserList listwindow = new DebugUserList();
            if (listwindow.ShowDialog() == true)
            {
                var composto = listwindow.dgUsuarios.SelectedItem as ItemComposto;
                var usr = composto.Item1 as DTO.Usuario;
                var p = composto.Item2 as DTO.Perfil;
#if DEBUG
                Console.WriteLine("USUÁRIO SELECIONADO:\n");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(usr)) {
                    Console.WriteLine("\t{0} = {1}\n",descriptor.Name,descriptor.GetValue(usr));
                }
                Console.WriteLine("PERFIL SELECIONADO:\n");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(p))
                {
                    Console.WriteLine("\t{0} = {1}\n", descriptor.Name, descriptor.GetValue(p));
                }
#endif
                txtMatricula.Text = usr.MATRICULA;
                pwdSenha.Password = usr.SENHA;
                pwdSenha.IsEnabled = false;
                pwdSenha.Cursor = Cursors.Hand;
                chkAdmin.IsChecked = usr.ISADM;
                txtNome.Text = p.NOME;
                /*txtTelefone.Text = p.Telefone;
                txtEmail.Text = p.Email;*/
            }
        }

        private async void btnInsAlt_Click(object sender, RoutedEventArgs e)
        {
            DTO.Usuario usr = new DTO.Usuario();
            BLL.Usuario db_usr = new BLL.Usuario();
           /* db_usr.Procurar(from db_usr); */
            BLL.Perfil db_pf = new BLL.Perfil();
            DTO.Perfil p = new DTO.Perfil(); ;
            usr.MATRICULA = txtMatricula.Text;
            usr.SENHA = pwdSenha.Password;
            usr.ISADM = (bool)chkAdmin.IsChecked;
            p.NOME = txtNome.Text;
            /*p.Telefone = txtTelefone.Text;
             p.Email = txtEmail.Text;*/
            DTO.Usuario usr_match = await db_usr.ConsultarPorMatricula(txtMatricula.Text);
            if (usr_match == null)
            {
                try
                {
                    var list = await db_usr.Listar();
                    var list2 = await db_pf.Listar();
                    usr.ID = list.Count();
                    p.ID = list2.Count();
                    usr.ID_PERFIL = p.ID;
                    db_usr.Inserir(usr, p);
                }
                catch (Exception ex)
                {
                    MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                try
                {
                    MessageBoxResult confirmationBox = MessageBox.Show("Sure", "Some Title", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                    if (DialogResult == true)
                    {
                        usr.ID = usr_match.ID;
                        usr.ID_PERFIL = usr_match.ID_PERFIL;
                        p.ID = usr.ID_PERFIL;
                        db_usr.Alterar(usr, p, pwdSenha.IsEnabled);
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            pwdSenha.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!pwdSenha.IsEnabled)
            {
                pwdSenha.Password = "";
                pwdSenha.IsEnabled = true;
            }
            if (txtMatricula.Text == "")
            {
                btnRemover.IsEnabled = false;
            }
            else
            {
                btnRemover.IsEnabled = true;
            }
        }

        private async void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            BLL.Usuario db_usr = new BLL.Usuario();
            DTO.Usuario usr = await db_usr.Procurar(MATRICULA:txtMatricula.Text);
            try
            {
                db_usr.Remover(usr);
                txtMatricula.Clear();
                pwdSenha.Clear();
                txtNome.Clear();
                txtEmail.Clear();
                txtTelefone.Clear();
            }
            catch (Exception ex)
            {
                MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void rectSenha_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                if (pwdSenha.IsEnabled)
                    Keyboard.Focus(pwdSenha);
            }
        }

        private void rectSenha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (!pwdSenha.IsEnabled)
                {
                    txbSenhaClick.Visibility = Visibility.Hidden;
                    pwdSenha.Password = "";
                    pwdSenha.IsEnabled = true;
                }
            }
            else
            {
                if (!pwdSenha.IsEnabled)
                {
                    txbSenhaClick.Visibility = Visibility.Visible;
                    var timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromMilliseconds(1000);
                    timer.Tick += new EventHandler(delegate (object s, EventArgs a)
                    {
                        txbSenhaClick.Visibility = Visibility.Hidden;
                        timer.Stop();
                    });
                    timer.Start();
                }
            }
        }
    }
}
