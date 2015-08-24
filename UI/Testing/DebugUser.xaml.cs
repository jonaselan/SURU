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
            ConsoleManager.Show();
        }

        private async void btnSelecionar_Click(object sender, RoutedEventArgs e)
        {
            DebugUserList listwindow = new DebugUserList();
            if (listwindow.ShowDialog() == true)
            {
                Usuario usr = (Usuario)listwindow.dgUsuarios.SelectedItem;
                PerfilBLL pbll = new PerfilBLL();
                Perfil p = await pbll.ConsultarPorId(usr.ID_PERFIL);
                txtMatricula.Text = usr.MATRICULA;
                pwdSenha.Password = usr.SENHA;
                usr.ISADM = (bool)chkAdmin.IsChecked ? 1 : 0;
                txtNome.Text = p.NOME;
                /*txtTelefone.Text = p.Telefone;
                txtEmail.Text = p.Email;*/
            }
        }

        private async void btnInsAlt_Click(object sender, RoutedEventArgs e)
        {
            Usuario usr = new Usuario();
            UsuarioBLL db_usr = new UsuarioBLL();
            PerfilBLL db_pf = new PerfilBLL();
            Perfil p = new Perfil(); ;
            usr.MATRICULA = txtMatricula.Text;
            usr.SENHA = pwdSenha.Password;
            usr.ISADM = (bool)chkAdmin.IsChecked ? 1 : 0;
            p.NOME = txtNome.Text;
           /*p.Telefone = txtTelefone.Text;
            p.Email = txtEmail.Text;*/
            Usuario usr_match = await db_usr.ConsultarPorMatricula(txtMatricula.Text);
            if (usr_match == null)
            {
                try
                {
                    var list = await db_usr.Listar();
                    var list2 = await db_pf.Listar();
                    usr.ID = list.Count();
                    p.ID = list2.Count();
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
                    usr.ID_PERFIL = usr_match.ID_PERFIL;
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
            usr.MATRICULA = txtMatricula.Text;
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
