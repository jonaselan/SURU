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
using System.Windows.Media.Animation;
using System.Reflection;

namespace UI.Testing
{
    /// <summary>
    /// Interaction logic for DebugUser.xaml
    /// </summary>
    public partial class DebugUser : Window
    {

        private DoubleAnimation animationDgUsuarioOpacityDown = new DoubleAnimation {
            To = 0,
            Duration = new Duration(TimeSpan.FromSeconds(0.3))
        };

        private DoubleAnimation animationDgUsuarioOpacityUp = new DoubleAnimation {
            To = 1,
            Duration = new Duration(TimeSpan.FromSeconds(0.3))
        };

        public DebugUser()
        {
            InitializeComponent();
            ConsoleManager.Show();
            animationDgUsuarioOpacityUp.Completed += new EventHandler(dgUsuario_OpacityUp);
            animationDgUsuarioOpacityDown.Completed += new EventHandler(dgUsuario_OpacityDown);
        }

        void dgUsuario_OpacityUp(object sender, EventArgs e)
        {

        }

        void dgUsuario_OpacityDown(object sender, EventArgs e) {
            dgUsuarios.MaxHeight = 0;
        }

        private async void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsuarios.IsEnabled)
            {

                DoubleAnimation animation = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(0.3),
                    To = 360,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                };

                DoubleAnimation animationWidth = new DoubleAnimation
                {
                    To = 513,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2))
                };
                dgUsuarios.BeginAnimation(OpacityProperty, animationDgUsuarioOpacityDown);
                BeginAnimation(WidthProperty, animationWidth);
                BeginAnimation(HeightProperty, animation);
                dgUsuarios.IsEnabled = false;
                btnSelecionar.Content = "Abrir DB";
            }
            else
            {
                dgUsuarios.IsEnabled = true;
                var db = await GetDB();
                var count = db.Count;
                dgUsuarios.ItemsSource = db;
                PropertyInfo pi = dgUsuarios.GetType().GetProperty("Height", BindingFlags.NonPublic | BindingFlags.Instance);
                dgUsuarios.MaxHeight = Double.PositiveInfinity;

                DoubleAnimation animation = new DoubleAnimation
                {
                    To = 360 + count * 26,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                };

                DoubleAnimation animationWidth = new DoubleAnimation
                {
                    BeginTime = TimeSpan.FromSeconds(0.3),
                    To = 758,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2))
                };

                dgUsuarios.BeginAnimation(OpacityProperty, animationDgUsuarioOpacityUp);
                BeginAnimation(HeightProperty, animation);
                BeginAnimation(WidthProperty, animationWidth);
                DebugUserList listwindow = new DebugUserList();
                btnSelecionar.Content = "Fechar DB";
            }
            /*
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
                /*
            }
            */
        }

        private async void btnInsAlt_Click(object sender, RoutedEventArgs e)
        {
            DTO.Usuario usr = new DTO.Usuario(); 
            DTO.Aluno a = new DTO.Aluno();
            DTO.Administrador adm = new DTO.Administrador();
            DTO.Telefone tel = new DTO.Telefone();
            DTO.Email email = new DTO.Email();
            
            BLL.Usuario db_usr = new BLL.Usuario();
            BLL.Administrador db_admin = new BLL.Administrador();
            BLL.Aluno db_aluno = new BLL.Aluno();

            usr.MATRICULA = txtMatricula.Text;
            usr.SENHA = pwdSenha.Password;
            usr.ISADM = (bool)chkAdmin.IsChecked;

            tel.NUMERO = txtTelefone.Text;
            email.ENDERECO = txtEmail.Text;

            /* db_usr.Procurar(from db_usr); */

            if (usr.ISADM)
            {
                adm.NOME = txtNome.Text;
            }
            else {
                //p = new DTO.Aluno();
                a.NOME = txtNome.Text;
                // ???    
            }
            

            /*p.Telefone = txtTelefone.Text;
             p.Email = txtEmail.Text;*/
            DTO.Usuario usr_match = await db_usr.ConsultarPorMatricula(txtMatricula.Text);
            if (usr_match == null)
            {
                try
                {
                    var list = await db_usr.Listar();
                    if (usr.ISADM)
                    {
                        var list2 = await db_admin.Listar();
                        adm.ID = list2.Count();
                        db_usr.Inserir(usr, adm);
                    }
                    else
                    {
                        var list2 = await db_aluno.Listar();
                        a.ID = list2.Count();
                        usr.ID_PERFIL = a.ID;
                        db_usr.Inserir(usr, a);
                    }
                    
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
                        usr.ID_PERFIL = usr_match.ID_PERFIL;
                        if (usr.ISADM)
                        {
                            adm.ID = usr.ID_PERFIL;
                            db_usr.Alterar(usr, adm, pwdSenha.IsEnabled);
                        }
                        else 
                        {
                            a.ID = usr.ID_PERFIL;
                            db_usr.Alterar(usr, a, pwdSenha.IsEnabled);
                        }
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

        // FROM USERLIST

        private async Task<List<ItemComposto>> GetDB()
        {

            BLL.Usuario usuariobll = new BLL.Usuario();
            BLL.Telefone telefonebll = new BLL.Telefone();
            BLL.Email emailbll = new BLL.Email();
            ItemComposto itemcomposto;
            List<ItemComposto> combined = new List<ItemComposto>();

            foreach (DTO.Usuario u in await usuariobll.Listar())
            {
                itemcomposto = new ItemComposto();
                itemcomposto.Item1 = u;
                itemcomposto.Item2 = await usuariobll.GetPerfil(u);
                List<DTO.Telefone> listatelefones = await telefonebll.TelefonesPerfilId(u.ID_PERFIL);
                List<DTO.Email> listaemails = await emailbll.EmailsPerfilId(u.ID_PERFIL);
                itemcomposto.Item3 = listatelefones.FirstOrDefault();
                itemcomposto.Item4 = listaemails.FirstOrDefault();
                combined.Add(itemcomposto);
            }
            return combined;
        }

        private void btnSelecionar2_Click(object sender, RoutedEventArgs e)
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
            if(dgUsuarios.SelectedItem != null)
            {
                var composto = dgUsuarios.SelectedItem as ItemComposto;
                var usr = composto.Item1 as DTO.Usuario;
                var p = composto.Item2 as DTO.Perfil;
#if DEBUG
                Console.WriteLine("USUÁRIO SELECIONADO:\n");
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(usr))
                {
                    Console.WriteLine("\t{0} = {1}\n", descriptor.Name, descriptor.GetValue(usr));
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

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                BeginTime = TimeSpan.FromSeconds(0.3),
                To = 348,
                Duration = new Duration(TimeSpan.FromSeconds(0.2)),
            };

            DoubleAnimation animationWidth = new DoubleAnimation
            {
                To = 513,
                Duration = new Duration(TimeSpan.FromSeconds(0.2))
            };
            BeginAnimation(WidthProperty, animationWidth);
            BeginAnimation(HeightProperty, animation);
        }
    }
}
