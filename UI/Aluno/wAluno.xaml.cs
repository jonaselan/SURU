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
    /// Interaction logic for wAluno.xaml
    /// </summary>
    public partial class wAluno : Window
    {
        private Session s;
        private DTO.Aluno aluno;
        public wAluno(Session s)
        {
            InitializeComponent();
            this.s = s;
        }
        public async Task<DTO.Aluno> GetAluno(Session s) {
            BLL.Usuario usrbll = new BLL.Usuario();
            DTO.Aluno a = (DTO.Aluno)await usrbll.GetPerfil(s.User);
            return a;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            aluno = await GetAluno(s);
            txbNome.Text = aluno.NOME;
        }
    }
}
