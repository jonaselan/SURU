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
        }

        private void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            DebugUserList listwindow = new DebugUserList();
            if (listwindow.ShowDialog() == true)
            {
                Usuario usr = (Usuario)listwindow.listUsuarios.SelectedItem;
                txtMatricula.Text = usr.Matricula;
                pwdSenha.Password = usr.Senha;
                txtNome.Text = usr.Perfil.Nome;
                txtTelefone.Text = usr.Perfil.Telefone;
                txtEmail.Text = usr.Perfil.Email;
            }
        }

        private void btnInsAlt_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            UsuarioBLL db_usr = new UsuarioBLL();
            PerfilBLL db_pf = new PerfilBLL();
            usr.Matricula = txtMatricula.Text;
            usr.Senha = pwdSenha.Password;
            usr.IsAdm = (bool) chkAdmin.IsChecked;
            usr.Perfil = new Perfil();
            usr.Perfil.Nome = txtNome.Text;
            usr.Perfil.Telefone = txtTelefone.Text;
            usr.Perfil.Email = txtEmail.Text;
            Usuario usr_match = db_usr.ConsultarPorMatricula(txtMatricula.Text);
            if (usr_match == null)
            {
                try
                {
                    usr.Id = db_usr.Listar().Count() + 1;
                    usr.Perfil.Id = db_pf.Listar().Count + 1;
                    db_usr.Inserir(usr);
                }
                catch (Exception ex)
                {
                    MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                usr.Id = usr_match.Id;
                usr.Perfil.Id = usr_match.Perfil.Id;
                db_usr.Alterar(usr);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
