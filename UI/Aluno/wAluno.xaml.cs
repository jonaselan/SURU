using DTO;
using System;
using System.Collections;
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

            cbSucoSeg.SelectedIndex = 0;
            cbSucoTerc.SelectedIndex = 0;
            cbSucoQuart.SelectedIndex = 0;
            cbSucoQuint.SelectedIndex = 0;
            cbSucoSex.SelectedIndex = 0;

        }

        public async Task<DTO.Aluno> GetAluno(Session s) {
            BLL.Usuario usrbll = new BLL.Usuario();
            DTO.Aluno a = (DTO.Aluno)await usrbll.GetPerfil(s.User);
            return a;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            aluno = await GetAluno(s);
            txNome.Text = aluno.NOME;
            txPeriodo.Text = aluno.PERIODO;
            txCurso.Text = aluno.CURSO;
            txTurno.Text = aluno.TURNO;
            txMatricula.Text = s.User.MATRICULA;

            if (!aluno.SEG)
            {
                gridSeg.IsEnabled = false;
            }
            if (!aluno.TER)
            {
                gridTerc.IsEnabled = false;
            }
            if (!aluno.QUA)
            {
                gridQuart.IsEnabled = false;
            }
            if (!aluno.QUI)
            {
                gridQuint.IsEnabled = false;
            }
            if (!aluno.SEX)
            {
                gridSex.IsEnabled = false;
            }

        }

        private void ckSeg_Checked(object sender, RoutedEventArgs e)
        {
            carneSeg.IsChecked = true;
            arrozSeg.IsChecked = true;
            feijaoSeg.IsChecked = true;
            verduraSeg.IsChecked = true;
            frutaSeg.IsChecked = true;
            lbSucoSeg.Visibility = Visibility.Visible;
        }
        private void ckSeg_Unchecked(object sender, RoutedEventArgs e)
        {
            carneSeg.IsChecked = false;
            arrozSeg.IsChecked = false;
            feijaoSeg.IsChecked = false;
            verduraSeg.IsChecked = false;
            frutaSeg.IsChecked = false;
            lbSucoSeg.Visibility = Visibility.Hidden;
        }
        private void ckTerc_Checked(object sender, RoutedEventArgs e)
        {
            carneTerc.IsChecked = true;
            arrozTerc.IsChecked = true;
            feijaoTerc.IsChecked = true;
            verduraTerc.IsChecked = true;
            frutaTerc.IsChecked = true;
            lbSucoTerc.Visibility = Visibility.Visible;
        }
        private void ckTerc_Unchecked(object sender, RoutedEventArgs e)
        {
            carneTerc.IsChecked = false;
            arrozTerc.IsChecked = false;
            feijaoTerc.IsChecked = false;
            verduraTerc.IsChecked = false;
            frutaTerc.IsChecked = false;
            lbSucoTerc.Visibility = Visibility.Hidden;
        }
        private void ckQuart_Checked(object sender, RoutedEventArgs e)
        {
            carneQuart.IsChecked = true;
            arrozQuart.IsChecked = true;
            feijaoQuart.IsChecked = true;
            verduraQuart.IsChecked = true;
            frutaQuart.IsChecked = true;
            lbSucoQuart.Visibility = Visibility.Visible;
        }
        private void ckQuart_Unchecked(object sender, RoutedEventArgs e)
        {
            carneQuart.IsChecked = false;
            arrozQuart.IsChecked = false;
            feijaoQuart.IsChecked = false;
            verduraQuart.IsChecked = false;
            frutaQuart.IsChecked = false;
            lbSucoQuart.Visibility = Visibility.Hidden;
        }
        private void ckQuint_Checked(object sender, RoutedEventArgs e)
        {
            carneQuint.IsChecked = true;
            arrozQuint.IsChecked = true;
            feijaoQuint.IsChecked = true;
            verduraQuint.IsChecked = true;
            frutaQuint.IsChecked = true;
            lbSucoQuint.Visibility = Visibility.Visible;
        }
        private void ckQuint_Unchecked(object sender, RoutedEventArgs e)
        {
            carneQuint.IsChecked = false;
            arrozQuint.IsChecked = false;
            feijaoQuint.IsChecked = false;
            verduraQuint.IsChecked = false;
            frutaQuint.IsChecked = false;
            lbSucoQuint.Visibility = Visibility.Hidden;
        }
        private void ckSex_Unchecked(object sender, RoutedEventArgs e)
        {
            carneSex.IsChecked = false;
            arrozSex.IsChecked = false;
            feijaoSex.IsChecked = false;
            verduraSex.IsChecked = false;
            frutaSex.IsChecked = false;
            lbSucoSex.Visibility = Visibility.Hidden;
        }
        private void ckSex_Checked(object sender, RoutedEventArgs e)
        {
            carneSex.IsChecked = true;
            arrozSex.IsChecked = true;
            feijaoSex.IsChecked = true;
            verduraSex.IsChecked = true;
            frutaSex.IsChecked = true;
            lbSucoSex.Visibility = Visibility.Visible;
        }

        // array com todos a data de todos os dias da semana
        private ArrayList diaAtual()
        {
            // DESCOMENTAR QUANDO DIA DA SEMANA
            // DateTime a = DateTime.Today; 

            DateTime a = new DateTime(2015, 8, 24);
            ArrayList listaDias = new ArrayList();
            //string diaAtual = Convert.ToString(DateTime.Now.DayOfWeek);
            string diaAtual = Convert.ToString(a.DayOfWeek);

            if (diaAtual == "Monday")
            {
                listaDias.Add(a.ToString(("dd/MM/yyyy"))); // seg
                listaDias.Add(a.AddDays(1).ToString(("dd/MM/yyyy"))); // tec
                listaDias.Add(a.AddDays(2).ToString(("dd/MM/yyyy"))); // quart
                listaDias.Add(a.AddDays(3).ToString(("dd/MM/yyyy"))); // quint
                listaDias.Add(a.AddDays(4).ToString(("dd/MM/yyyy"))); // sext
            }
            else if (diaAtual == "Tuesday")
            {
                listaDias.Add(a.AddDays(-1).ToString(("dd/MM/yyyy"))); // seg
                listaDias.Add(a.ToString(("dd/MM/yyyy"))); // tec
                listaDias.Add(a.AddDays(1).ToString(("dd/MM/yyyy"))); // quart
                listaDias.Add(a.AddDays(2).ToString(("dd/MM/yyyy"))); // quint
                listaDias.Add(a.AddDays(3).ToString(("dd/MM/yyyy"))); // sext

            }
            else if (diaAtual == "Wednesday")
            {
                listaDias.Add(a.AddDays(-2).ToString(("dd/MM/yyyy"))); // seg
                listaDias.Add(a.AddDays(-1).ToString(("dd/MM/yyyy"))); // ter
                listaDias.Add(a.ToString(("dd/MM/yyyy"))); // quart
                listaDias.Add(a.AddDays(1).ToString(("dd/MM/yyyy"))); // quint
                listaDias.Add(a.AddDays(2).ToString(("dd/MM/yyyy"))); // sext
            }
            else if (diaAtual == "Thursday")
            {
                listaDias.Add(a.AddDays(-3).ToString(("dd/MM/yyyy"))); // seg
                listaDias.Add(a.AddDays(-2).ToString(("dd/MM/yyyy"))); // ter
                listaDias.Add(a.AddDays(-1).ToString(("dd/MM/yyyy"))); // quart
                listaDias.Add(a.ToString(("dd/MM/yyyy"))); // quint
                listaDias.Add(a.AddDays(1).ToString(("dd/MM/yyyy"))); // sex
            }
            else if (diaAtual == "Friday")
            {
                listaDias.Add(a.AddDays(-4).ToString(("dd/MM/yyyy"))); // seg
                listaDias.Add(a.AddDays(-3).ToString(("dd/MM/yyyy"))); // ter
                listaDias.Add(a.AddDays(-2).ToString(("dd/MM/yyyy"))); // quart
                listaDias.Add(a.AddDays(-1).ToString(("dd/MM/yyyy"))); // quint
                listaDias.Add(a.ToString(("dd/MM/yyyy"))); // sex
            }

            return listaDias;
        }

        private void finSegunda_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Não será possivel editar o prato posteriormente\nConfirmar?", "Montar Prato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string pratoFeito = "";

                // mistura
                if (frangoSeg.IsChecked == true)
                {
                    pratoFeito += "Frango ";
                }
                else if (peixeSeg.IsChecked == true)
                {
                    pratoFeito += "Peixe ";
                }
                else if (carneSeg.IsChecked == true)
                {
                    pratoFeito += "Carne ";
                }
                else if (lingSeg.IsChecked == true)
                {
                    pratoFeito += "Linguiça ";
                }

                // acompanhamento
                if (arrozSeg.IsChecked == true)
                {
                    pratoFeito += "Arroz ";
                }
                else if (macarraoSeg.IsChecked == true)
                {
                    pratoFeito += "Macarrão ";
                }

                // feijão
                if (feijaoSeg.IsChecked == true)
                {
                    pratoFeito += "Feijão ";
                }
                else pratoFeito += "- ";

                // verdura
                if (verduraSeg.IsChecked == true)
                {
                    pratoFeito += "Verdura ";
                }
                else pratoFeito += "- ";

                // fruta
                if (frutaSeg.IsChecked == true)
                {
                    pratoFeito += "Fruta ";
                }
                else pratoFeito += "- ";

                // suco
                pratoFeito += cbSucoSeg.SelectionBoxItem;

                // data 
                ArrayList diasSemana = new ArrayList();
                diasSemana = diaAtual();
                // pratoFeito += diasSemana[0].ToString();

                // idPrato
                Random rdn = new Random();
                int idPrato = rdn.Next(1000, 2000);

                MessageBox.Show("Prato montando com sucesso!\nSeu código é " + idPrato);
                lbCodigoSeg.Content = idPrato;
                
                gridSeg.IsEnabled = false;
                lbSucoSeg.Visibility = Visibility.Hidden;
                
                // preencher obj
                DTO.Prato p = new DTO.Prato();
                p.CONTEUDO = pratoFeito;
                p.ID_PRATO = idPrato; 
                p.MATRICULA = int.Parse(s.User.MATRICULA);
                p.DATA = diasSemana[0].ToString();

                // adicionar novo prato
                BLL.Prato db_prato = new BLL.Prato();
                db_prato.Inserir(p);
            }
        }

        private void finTerca_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Não será possivel editar o prato posteriormente\nConfirmar?", "Montar Prato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string pratoFeito = "";

                // mistura
                if (frangoTerc.IsChecked == true)
                {
                    pratoFeito += "Frango ";
                }
                else if (peixeTerc.IsChecked == true)
                {
                    pratoFeito += "Peixe ";
                }
                else if (carneTerc.IsChecked == true)
                {
                    pratoFeito += "Carne ";
                }
                else if (lingTerc.IsChecked == true)
                {
                    pratoFeito += "Linguiça ";
                }

                // acompanhamento
                if (arrozTerc.IsChecked == true)
                {
                    pratoFeito += "Arroz ";
                }
                else if (macarraoTerc.IsChecked == true)
                {
                    pratoFeito += "Macarrão ";
                }

                // feijão
                if (feijaoTerc.IsChecked == true)
                {
                    pratoFeito += "Feijão ";
                }
                else pratoFeito += "- ";

                // verdura
                if (verduraTerc.IsChecked == true)
                {
                    pratoFeito += "Verdura ";
                }
                else pratoFeito += "- ";

                // fruta
                if (frutaTerc.IsChecked == true)
                {
                    pratoFeito += "Fruta ";
                }
                else pratoFeito += "- ";

                // suco
                pratoFeito += cbSucoTerc.SelectionBoxItem;


                // data 
                ArrayList diasSemana = new ArrayList();
                diasSemana = diaAtual();

                DateTime b = new DateTime(2015, 8, 24); // data de hoje
                string dia = Convert.ToString(b.DayOfWeek);

                /*if (dia == "Monday")
                {
                    pratoFeito += diasSemana[1].ToString();
                }
                else if (dia == "Tuesday")
                {
                    pratoFeito += diasSemana[1].ToString();
                }*/

                // idPrato
                Random rdn = new Random();
                int idPrato = rdn.Next(1000, 2000);

                MessageBox.Show("Prato montando com sucesso!\n Seu código é " + idPrato);
                lbCodigoTerc.Content = idPrato;


                gridTerc.IsEnabled = false;
                lbSucoTerc.Visibility = Visibility.Hidden;

                // preencher obj
                DTO.Prato p = new DTO.Prato();
                p.CONTEUDO = pratoFeito;
                p.ID_PRATO = idPrato;
                p.MATRICULA = int.Parse(s.User.MATRICULA);
                p.DATA = diasSemana[1].ToString();

                // adicionar novo prato
                BLL.Prato db_prato = new BLL.Prato();
                db_prato.Inserir(p);
            }
        }
        
        private void finQuarta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Não será possivel editar o prato posteriormente\nConfirmar?", "Montar Prato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string pratoFeito = "";

                // mistura
                if (frangoQuart.IsChecked == true)
                {
                    pratoFeito += "Frango ";
                }
                else if (peixeQuart.IsChecked == true)
                {
                    pratoFeito += "Peixe ";
                }
                else if (carneQuart.IsChecked == true)
                {
                    pratoFeito += "Carne ";
                }
                else if (lingQuart.IsChecked == true)
                {
                    pratoFeito += "Linguiça ";
                }

                // acompanhamento
                if (arrozQuart.IsChecked == true)
                {
                    pratoFeito += "Arroz ";
                }
                else if (macarraoQuart.IsChecked == true)
                {
                    pratoFeito += "Macarrão ";
                }

                // feijão
                if (feijaoQuart.IsChecked == true)
                {
                    pratoFeito += "Feijão ";
                }
                else pratoFeito += "- ";

                // verdura
                if (verduraQuart.IsChecked == true)
                {
                    pratoFeito += "Verdura ";
                }
                else pratoFeito += "- ";

                // fruta
                if (frutaQuart.IsChecked == true)
                {
                    pratoFeito += "Fruta ";
                }
                else pratoFeito += "- ";

                // suco
                pratoFeito += cbSucoQuart.SelectionBoxItem;


                // data 
                ArrayList diasSemana = new ArrayList();
                diasSemana = diaAtual();

                DateTime b = new DateTime(2015, 8, 24); // data de hoje
                string dia = Convert.ToString(b.DayOfWeek);

                /*if (dia == "Monday")
                {
                    pratoFeito += diasSemana[2].ToString();
                }
                else if (dia == "Tuesday")
                {
                    pratoFeito += diasSemana[2].ToString();
                }
                else if (dia == "Wednesday ")
                {
                    pratoFeito += diasSemana[2].ToString();
                }*/

                // idPrato
                Random rdn = new Random();
                int idPrato = rdn.Next(1000, 2000);

                MessageBox.Show("Prato montando com sucesso!\n Seu código é " + idPrato);
                lbCodigoQuart.Content = idPrato;


                gridQuart.IsEnabled = false;
                lbSucoQuart.Visibility = Visibility.Hidden;

                // preencher obj
                DTO.Prato p = new DTO.Prato();
                p.CONTEUDO = pratoFeito;
                p.ID_PRATO = idPrato;
                p.MATRICULA = int.Parse(s.User.MATRICULA);
                p.DATA = diasSemana[2].ToString();

                // adicionar novo prato
                BLL.Prato db_prato = new BLL.Prato();
                db_prato.Inserir(p);

            }
        }

        private void finQuinta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Não será possivel editar o prato posteriormente\nConfirmar?", "Montar Prato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string pratoFeito = "";

                // mistura
                if (frangoQuint.IsChecked == true)
                {
                    pratoFeito += "Frango ";
                }
                else if (peixeQuint.IsChecked == true)
                {
                    pratoFeito += "Peixe ";
                }
                else if (carneQuint.IsChecked == true)
                {
                    pratoFeito += "Carne ";
                }
                else if (lingQuint.IsChecked == true)
                {
                    pratoFeito += "Linguiça ";
                }

                // acompanhamento
                if (arrozQuint.IsChecked == true)
                {
                    pratoFeito += "Arroz ";
                }
                else if (macarraoQuint.IsChecked == true)
                {
                    pratoFeito += "Macarrão ";
                }

                // feijão
                if (feijaoQuint.IsChecked == true)
                {
                    pratoFeito += "Feijão ";
                }
                else pratoFeito += "- ";

                // verdura
                if (verduraQuint.IsChecked == true)
                {
                    pratoFeito += "Verdura ";
                }
                else pratoFeito += "- ";

                // fruta
                if (frutaQuint.IsChecked == true)
                {
                    pratoFeito += "Fruta ";
                }
                else pratoFeito += "- ";

                // suco
                pratoFeito += cbSucoQuint.SelectionBoxItem;


                // data 
                ArrayList diasSemana = new ArrayList();
                diasSemana = diaAtual();

                DateTime b = new DateTime(2015, 8, 24); // data de hoje
                string dia = Convert.ToString(b.DayOfWeek);

                /*if (dia == "Monday")
                {
                    pratoFeito += diasSemana[3].ToString();
                }
                else if (dia == "Tuesday")
                {
                    pratoFeito += diasSemana[3].ToString();
                }
                else if (dia == "Wednesday")
                {
                    pratoFeito += diasSemana[3].ToString();
                }
                else if (dia == "Thursday")
                {
                    pratoFeito += diasSemana[3].ToString();
                }*/
                
                // idPrato
                Random rdn = new Random();
                int idPrato = rdn.Next(1000, 2000);

                MessageBox.Show("Prato montando com sucesso!\n Seu código é " + idPrato);
                lbCodigoQuint.Content = idPrato;


                gridQuint.IsEnabled = false;
                lbSucoQuint.Visibility = Visibility.Hidden;

                // preencher obj
                DTO.Prato p = new DTO.Prato();
                p.CONTEUDO = pratoFeito;
                p.ID_PRATO = idPrato;
                p.MATRICULA = int.Parse(s.User.MATRICULA);
                p.DATA = diasSemana[3].ToString();

                // adicionar novo prato
                BLL.Prato db_prato = new BLL.Prato();
                db_prato.Inserir(p);

            }
        }

        private void finSexta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Não será possivel editar o prato posteriormente\nConfirmar?", "Montar Prato", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                string pratoFeito = "";

                // mistura
                if (frangoSex.IsChecked == true)
                {
                    pratoFeito += "Frango ";
                }
                else if (peixeSex.IsChecked == true)
                {
                    pratoFeito += "Peixe ";
                }
                else if (carneSex.IsChecked == true)
                {
                    pratoFeito += "Carne ";
                }
                else if (lingSex.IsChecked == true)
                {
                    pratoFeito += "Linguiça ";
                }

                // acompanhamento
                if (arrozSex.IsChecked == true)
                {
                    pratoFeito += "Arroz ";
                }
                else if (macarraoSex.IsChecked == true)
                {
                    pratoFeito += "Macarrão ";
                }

                // feijão
                if (feijaoSex.IsChecked == true)
                {
                    pratoFeito += "Feijão ";
                }
                else pratoFeito += "- ";

                // verdura
                if (verduraSex.IsChecked == true)
                {
                    pratoFeito += "Verdura ";
                }
                else pratoFeito += "- ";

                // fruta
                if (frutaSex.IsChecked == true)
                {
                    pratoFeito += "Fruta ";
                }
                else pratoFeito += "- ";

                // suco
                pratoFeito += cbSucoSex.SelectionBoxItem;


                // data 
                ArrayList diasSemana = new ArrayList();
                diasSemana = diaAtual();

                DateTime b = new DateTime(2015, 8, 24); // data de hoje
                string dia = Convert.ToString(b.DayOfWeek);

                /*if (dia == "Monday")
                {
                    pratoFeito += diasSemana[4].ToString();
                }
                else if (dia == "Tuesday")
                {
                    pratoFeito += diasSemana[4].ToString();
                }
                else if (dia == "Wednesday")
                {
                    pratoFeito += diasSemana[4].ToString();
                }
                else if (dia == "Thursday")
                {
                    pratoFeito += diasSemana[4].ToString();
                }
                else if (dia == "Friday")
                {
                    pratoFeito += diasSemana[4].ToString();
                }*/

                // idPrato
                Random rdn = new Random();
                int idPrato = rdn.Next(1000, 2000);

                MessageBox.Show("Prato montando com sucesso!\n Seu código é " + idPrato);
                lbCodigoSex.Content = idPrato;


                gridSex.IsEnabled = false;
                lbSucoSex.Visibility = Visibility.Hidden;

                // preencher obj
                DTO.Prato p = new DTO.Prato();
                p.CONTEUDO = pratoFeito;
                p.ID_PRATO = idPrato;
                p.MATRICULA = int.Parse(s.User.MATRICULA);
                p.DATA = diasSemana[4].ToString();

                // adicionar novo prato
                BLL.Prato db_prato = new BLL.Prato();
                db_prato.Inserir(p);

            }
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            this.Close();
            login.ShowDialog();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            alterarSenha alt = new alterarSenha();
            alt.ShowDialog();
        }
        
    }
}
