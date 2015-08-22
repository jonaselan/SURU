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
using UI.Testing;
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
            InitializeComponent();
            /*
                DESCOMENTE A LINHA ABAIXO PARA ABRIR DB_DEBUG
            */
            #if DEBUG_DB
            DebugUser janelaDBDebug = new DebugUser();
            janelaDBDebug.Show();
            #endif
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Session session = session = Login.Validar(txtMatricula.Text, txtSenha.Text);
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
    }
}
