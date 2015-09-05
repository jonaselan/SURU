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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BLL;
using System.ComponentModel;
using System.Windows.Threading;

namespace UI.Adm
{
    /// <summary>
    /// Interaction logic for wAdministrador.xaml
    /// </summary>
    public partial class wAdministrador : Window
    {

        #region ANIMAÇÃO
        private Grid grdAberto;
        private DoubleAnimation animationHeightExpand = new DoubleAnimation {
            To = 621,
            Duration = new Duration(TimeSpan.FromSeconds(1))
        };

        private DoubleAnimation animationOpacidadeUp = new DoubleAnimation {
            To = 1,
            Duration = new Duration(TimeSpan.FromSeconds(0.2))
        };
        private DoubleAnimation animationOpacidadeDown = new DoubleAnimation
        {
            To = 0,
            Duration = new Duration(TimeSpan.FromSeconds(0.2))
        };
        #endregion

        public Session s;
        public DTO.Administrador adiministrador;
        int qtd = 0;
        public wAdministrador(Session s)
        {
            InitializeComponent();
            this.s = s;

            cbTipo.SelectedIndex = 0;

            //animationOpacidadeUp.Completed += new EventHandler(animation_OpacidadeUp);
            //BeginAnimation(OpacityProperty, animationOpacidadeUp);
        }

        public async Task<DTO.Administrador> GetAdm(Session s)
        {
            BLL.Usuario usrbll = new BLL.Usuario();
            DTO.Administrador a = (DTO.Administrador)await usrbll.GetPerfil(s.User);
            return a;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            adiministrador = await GetAdm(s);
            txNome.Text = adiministrador.NOME;
            txMatricula.Text = s.User.MATRICULA;
        }

        private void btnFila_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
           if (grdAberto != null)
            {
                if (grdAberto.Opacity == 0)
                {
                    BeginAnimation(HeightProperty, animationHeightExpand);
                    grdFila.BeginAnimation(OpacityProperty, animationOpacidadeUp);
                    grdAberto = grdFila;
                }
                else
                {
                    grdAberto.BeginAnimation(OpacityProperty, animationOpacidadeDown);
                    grdFila.BeginAnimation(OpacityProperty, animationOpacidadeUp);
                    grdAlunos.Visibility = Visibility.Hidden;
                    grdFila.Visibility = Visibility.Visible;
                    grdAberto = grdFila;
                }
            }
            else 
            {
                BeginAnimation(HeightProperty, animationHeightExpand);
                grdFila.BeginAnimation(OpacityProperty, animationOpacidadeUp);
                grdAlunos.Visibility = Visibility.Hidden;
                grdAberto = grdFila;
            }
            
        }

        private void btnAluno_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (grdAberto != null)
            {
                if (grdAberto.Opacity == 0)
                {
                    grdAlunos.BeginAnimation(OpacityProperty, animationOpacidadeUp);
                    grdAberto = grdAlunos;
                }
                else
                {
                    grdAberto.BeginAnimation(OpacityProperty, animationOpacidadeDown);
                    grdAlunos.BeginAnimation(OpacityProperty, animationOpacidadeUp);
                    grdFila.Visibility = Visibility.Hidden;
                    grdAlunos.Visibility = Visibility.Visible;
                    grdAberto = grdAlunos;
                }
            }
            else 
            {
                BeginAnimation(HeightProperty, animationHeightExpand);
                grdAlunos.BeginAnimation(OpacityProperty, animationOpacidadeUp);
                grdAberto = grdAlunos;
            }
        }

        #region Eventos grdAlunos

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
                    timer.Tick += new EventHandler(delegate(object s, EventArgs a)
                    {
                        txbSenhaClick.Visibility = Visibility.Hidden;
                        timer.Stop();
                    });
                    timer.Start();
                }
            }
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            wUsuariosList listwindow = new wUsuariosList();
            if (listwindow.ShowDialog() == true)
            {
                var composto = listwindow.dgUsuarios.SelectedItem as ItemComposto;
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
                //chkAdmin.IsChecked = usr.ISADM;
                txtNome.Text = p.NOME;
                /*txtTelefone.Text = p.Telefone;
                txtEmail.Text = p.Email;*/
            }

        }

        private async void btnInsAlt_Click(object sender, RoutedEventArgs e)
        {
            DTO.Usuario usr = new DTO.Usuario();
            DTO.Aluno a = new DTO.Aluno();
            DTO.Administrador adm = new DTO.Administrador();

            BLL.Usuario db_usr = new BLL.Usuario();
            BLL.Administrador db_admin = new BLL.Administrador();
            BLL.Aluno db_aluno = new BLL.Aluno();

            usr.MATRICULA = txtMatricula.Text;
            usr.SENHA = pwdSenha.Password;
            usr.ISADM = false;
                a.NOME = txtNome.Text;
                a.CURSO = txtCurso.Text;
                a.TURNO = txtTurno.Text;
                a.PERIODO = txtPeriodo.Text;
                a.TIPO = cbTipo.Text;
                a.SEG = (bool)CheckSeg.IsChecked;
                a.TER = (bool)CheckTerc.IsChecked;
                a.QUA = (bool)CheckQuart.IsChecked;
                a.QUI = (bool)CheckQuint.IsChecked;
                a.SEX = (bool)CheckSex.IsChecked;

            /*p.Telefone = txtTelefone.Text;
             p.Email = txtEmail.Text;*/
            DTO.Usuario usr_match = await db_usr.ConsultarPorMatricula(txtMatricula.Text);
            if (usr_match == null)
            {
                try
                {
                    // var list = await db_usr.Listar();
                    
                        var list2 = await db_aluno.Listar();
                        a.ID = list2.Count();
                        usr.ID_PERFIL = a.ID;
                        db_usr.Inserir(usr, a);
                        MessageBox.Show("Usuário adicionado com sucesso!");

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
                            a.ID = usr.ID_PERFIL;
                            db_usr.Alterar(usr, a, pwdSenha.IsEnabled);
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            pwdSenha.IsEnabled = false;
        }

        private async void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            BLL.Usuario db_usr = new BLL.Usuario();
            DTO.Usuario usr = await db_usr.Procurar(MATRICULA: txtMatricula.Text);
            try
            {
                db_usr.Remover(usr);
                txtMatricula.Clear();
                pwdSenha.Clear();
                txtNome.Clear();
                //txtEmail.Clear();
               // txtTelefone.Clear();
            }
            catch (Exception ex)
            {
                MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        private void cbTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbTipo.SelectedIndex==1)
            {
                CheckSeg.IsChecked = true;
                CheckTerc.IsChecked = true;
                CheckQuart.IsChecked = true;
                CheckQuint.IsChecked = true;
                CheckSex.IsChecked = true;
            }
            else if (cbTipo.SelectedIndex == 0)
            {
                CheckSeg.IsChecked = false;
                CheckTerc.IsChecked = false;
                CheckQuart.IsChecked = false;
                CheckQuint.IsChecked = false;
                CheckSex.IsChecked = false;
            }
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private async void cbAlunos_Loaded(object sender, RoutedEventArgs e)
        {
            BLL.Usuario usrBLL = new BLL.Usuario();
            var list = await usrBLL.Listar();
            list = list.FindAll(u => u.ISADM == false);
            cbAlunos.ItemsSource = list;
        }

        private void btnInsFila_Click(object sender, RoutedEventArgs e) {  
            Random rdn = new Random();
            DTO.Fila f = new DTO.Fila();
            qtd++;
            if (qtd <= 10)
            {
                // se ainda haver espaço na fila
                f.ID_FILA = rdn.Next(1000, 2000);
                f.MATRICULA = 0; // POR ENQUANTO
                f.QTD = qtd;

                DateTime a = DateTime.Today;
                f.DATA = a.ToString("dd/MM/yyyy");

                // adicionar novo prato
                BLL.Fila db_fila = new BLL.Fila();
                db_fila.Inserir(f);
                AtualizarGrid();
                MessageBox.Show("Aluno adicionado a fila com sucesso!");
            }
            else
            {
                MessageBox.Show("Não há mais espaço na fila");
            }

            
        }

        private async void AtualizarGrid()
        {
            BLL.Fila fBLL = new BLL.Fila();
            dgFila.ItemsSource = await fBLL.Listar();

        }

        private void dgFila_Loaded(object sender, RoutedEventArgs e)
        {
            AtualizarGrid();
        }

    }
}
