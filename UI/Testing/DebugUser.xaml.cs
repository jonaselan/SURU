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
                Usuario usr = (Usuario)listwindow.dgUsuarios.SelectedItem;
                PerfilBLL pbll = new PerfilBLL();
                Perfil p = pbll.ConsultarPorId(usr.IdPerfil);
                txtMatricula.Text = usr.Matricula;
                pwdSenha.Password = usr.Senha;
                chkAdmin.IsChecked = usr.IsAdm;
                txtNome.Text = p.Nome;
                txtTelefone.Text = p.Telefone;
                txtEmail.Text = p.Email;
            }
        }

        private void btnInsAlt_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            UsuarioBLL db_usr = new UsuarioBLL();
            PerfilBLL db_pf = new PerfilBLL();
            Perfil p = new Perfil(); ;
            usr.Matricula = txtMatricula.Text;
            usr.Senha = pwdSenha.Password;
            usr.IsAdm = (bool) chkAdmin.IsChecked;
            p.Nome = txtNome.Text;
            p.Telefone = txtTelefone.Text;
            p.Email = txtEmail.Text;
            Usuario usr_match = db_usr.ConsultarPorMatricula(txtMatricula.Text);
            if (usr_match == null)
            {
                try
                {
                    usr.Id = db_usr.Listar().Count() + 1;                 
                    p.Id = db_pf.Listar().Count + 1;
                    usr.IdPerfil = p.Id;
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
                    usr.Id = usr_match.Id;
                    usr.IdPerfil = usr_match.IdPerfil;
                    db_usr.Alterar(usr, p);
                }
                catch (Exception ex)
                {
                    MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void txtMatricula_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtMatricula.Text == "")
            {
                btnRemover.IsEnabled = false;
            }
            else
            {
                btnRemover.IsEnabled = true;
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            UsuarioBLL db_usr = new UsuarioBLL();
            usr.Matricula = txtMatricula.Text;
            try
            {
                db_usr.Remover(usr);
            }
            catch (Exception ex)
            {
                MessageBoxResult errBox = MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
