/* DESCOMENTE A LINHA ABAIXO PARA ABRIR JANELA DE DB */
#define DEBUG_DB
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Aluno;
#if DEBUG_DB
using UI.Testing;
#endif
using DTO;
using BLL;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            InitializeComponent();
            /*
                DESCOMENTE A LINHA ABAIXO PARA ABRIR DB_DEBUG
            */
#if DEBUG_DB
            DebugUser janelaDBDebug = new DebugUser();
            janelaDBDebug.Show();
#endif
        }

        private async void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session session = await Login.Validar(txtMatricula.Text, pwdSenha.Password);
            }
            catch (Exception ex)
            {
                MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            /* Função acima retorna um objeto da classe Session que pode ser acessado para obter o usuario da sessão atual */
            /* JONATHAN - Não mexi em nada abaixo */
            wAluno telaAluno = new wAluno();
            this.Close();
            telaAluno.ShowDialog();
        }

        private void txtMatricula_GotFocus(object sender, RoutedEventArgs e)
        {
            lbMatricula.Visibility = Visibility.Hidden;
        }

        private void txtMatricula_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtMatricula.Text != "") { return; }
            lbMatricula.Visibility = Visibility.Visible;

        }

        private void pwdSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            lbSenha.Visibility = Visibility.Hidden;
        }

        private void pwdSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pwdSenha.Password != "") { return; }
            lbSenha.Visibility = Visibility.Visible;
        }

        private void btnLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtMatricula.Text = "";
            pwdSenha.Password = "";
            lbMatricula.Visibility = Visibility.Visible;
            lbSenha.Visibility = Visibility.Visible;
        }

        private void lbInput_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1) {
                var label = (System.Windows.Controls.Label)sender;
                Keyboard.Focus(label.Target);
            }
        }

        public string ProgramVersion
        {
            get { return Program.Version; }
        }

        private async void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool uptodate = await ProgramBLL.IsUpToDate();
            if (uptodate)
            {
                txbGit.Text = "Nenhuma atualização pendente.";
            }
            else
            {
                txbGit.Text = "Versão nova disponível: "+Program.OnlineVersion;
                txbGit.Cursor = Cursors.Hand;
                txbGit.MouseLeftButtonUp += txbGit_MouseLeftButtonUp;
            }
        }

        private void txbGit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                System.Diagnostics.Process.Start("https://github.com/jonaselan/SURU");
            }
        }
    }
}
