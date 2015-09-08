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
using UI.Adm;
using BLL;
using BLL.AcessoDB;
using System.Windows.Media.Animation;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Animações da Janela de Login
        /// </summary>
        private static class Animations {
            public static class Logo
            {
                public static ThicknessAnimation TextRUMargin {
                    get { return new ThicknessAnimation {
                        To = new Thickness(91, 0, 0, 0),
                        Duration = new Duration(TimeSpan.FromSeconds(0.3))
                    }; }
                }
                public static ThicknessAnimation TextUMargin {
                    get { return new ThicknessAnimation {
                        To = new Thickness(41, 0, 0, 0),
                        Duration = new Duration(TimeSpan.FromSeconds(0.3))
                    }; }
                }
                public static DoubleAnimation TextRUFont
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            To = 80,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation EllipseGrow
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            To = 1000,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation EllipsePosTop
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            To = -410,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation EllipsePosLeft
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            To = -250,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation MoveLogoCenterY
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            To = 102,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation MoveLogoCenterX
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            To = 148,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation FadeOutContent
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            BeginTime = TimeSpan.FromSeconds(0.3),
                            To = 0,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
                public static DoubleAnimation FadeInContent
                {
                    get
                    {
                        return new DoubleAnimation
                        {
                            BeginTime = TimeSpan.FromSeconds(0.5),
                            To = 1,
                            Duration = new Duration(TimeSpan.FromSeconds(0.3))
                        };
                    }
                }
            }
            public static class Buttons {
                public static ThicknessAnimation EntrarErro {
                    get { return new ThicknessAnimation {
                        To = new Thickness(150, 160, 0, 0),
                        Duration = new Duration(TimeSpan.FromSeconds(0.1))
                    }; }
                }
                public static ThicknessAnimation LimparErro {
                    get { return new ThicknessAnimation {
                        To = new Thickness(30, 160, 0, 0),
                        Duration = new Duration(TimeSpan.FromSeconds(0.1))
                    }; }
                }
            }
            public static class TextBlock {
                public static DoubleAnimation TextEntrarErro {
                    get { return new DoubleAnimation {
                        To = 150,
                        Duration = new Duration(TimeSpan.FromSeconds(0.1))
                    }; }
                }
            }
        }

        // ANIMAÇÕES COM EVENTOS
        private DoubleAnimation animationLogoHeight = Animations.Logo.EllipseGrow;
        private DoubleAnimation animationLogoFadeOutContent = Animations.Logo.FadeOutContent;
        private ThicknessAnimation animationBtnEntrarErro = Animations.Buttons.EntrarErro;

        private DTO.Session session;

        public MainWindow()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            Database.Acess();
            InitializeComponent();
#if DEBUG_DB
            DebugUser janelaDBDebug = new DebugUser();
            janelaDBDebug.Show();
#endif
            animationLogoHeight.Completed += new EventHandler(logoFinished);
            animationLogoFadeOutContent.Completed += new EventHandler(animation_FadeOutCompleted);
            animationBtnEntrarErro.Completed += new EventHandler(animation_EntrarErroCompleted);
        }

        private void animation_EntrarErroCompleted(object sender, EventArgs e) {
            txbEntrarErro.BeginAnimation(WidthProperty, Animations.TextBlock.TextEntrarErro);
        }

        private async void logoFinished(object sender, EventArgs e) {
            gridLogoText.BeginAnimation(Canvas.TopProperty, Animations.Logo.MoveLogoCenterY);
            gridLogoText.BeginAnimation(Canvas.LeftProperty, Animations.Logo.MoveLogoCenterX);
            txbLogoRU.BeginAnimation(FontSizeProperty, Animations.Logo.TextRUFont);
            txbLogoU.BeginAnimation(FontSizeProperty, Animations.Logo.TextRUFont);
            txbLogoU.BeginAnimation(MarginProperty, Animations.Logo.TextUMargin);
            txbLogoRU.BeginAnimation(MarginProperty, Animations.Logo.TextRUMargin);

            polygonRU.BeginAnimation(TopProperty, new DoubleAnimation(133, new Duration(TimeSpan.FromSeconds(0.3))));
            polygonRU.BeginAnimation(LeftProperty, new DoubleAnimation(293, new Duration(TimeSpan.FromSeconds(0.3))));
            polygonRU.BeginAnimation(HeightProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.3))));
            polygonRU.BeginAnimation(WidthProperty, new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.3))));

            await Task.Delay(1500);
            wAluno telaAluno = new wAluno(session);
            App.Current.MainWindow = telaAluno;
            Close();
            telaAluno.Show();
        }

        private void animation_FadeOutCompleted(object sender, EventArgs e)
        {
            txbLogin.Visibility = Visibility.Hidden;
            txtMatricula.Visibility = Visibility.Hidden;
            pwdSenha.Visibility = Visibility.Hidden;
            btnEntrar.Visibility = Visibility.Hidden;
            btnLimpar.Visibility = Visibility.Hidden;
            lbMatricula.Visibility = Visibility.Hidden;
            lbSenha.Visibility = Visibility.Hidden;
            polygonSU.Visibility = Visibility.Hidden;
            polygonRU.Visibility = Visibility.Hidden;
        }


        private async void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                session = await Login.Validar(txtMatricula.Text, pwdSenha.Password);
            }
            catch (Exception ex)
            {
                txbEntrarErro.Text = ex.Message;
                btnEntrar.BeginAnimation(MarginProperty, animationBtnEntrarErro);
                btnLimpar.BeginAnimation(MarginProperty, Animations.Buttons.LimparErro);
                return;
            }
            txbBemVindo.Text = string.Format("Bem vindo\n{0}", (session != null) ? session.Aluno.NOME : "?");
            txbEntrarErro.Visibility = Visibility.Hidden;
            ellipseLogo.BeginAnimation(HeightProperty, animationLogoHeight);
            ellipseLogo.BeginAnimation(WidthProperty, Animations.Logo.EllipseGrow);
            ellipseLogo.BeginAnimation(Canvas.TopProperty, Animations.Logo.EllipsePosTop);
            ellipseLogo.BeginAnimation(Canvas.LeftProperty, Animations.Logo.EllipsePosLeft);
            txbBemVindo.BeginAnimation(OpacityProperty, Animations.Logo.FadeInContent);
            txbLogin.BeginAnimation(OpacityProperty, animationLogoFadeOutContent);
            txtMatricula.BeginAnimation(OpacityProperty, Animations.Logo.FadeOutContent);
            pwdSenha.BeginAnimation(OpacityProperty, Animations.Logo.FadeOutContent);
            btnEntrar.BeginAnimation(OpacityProperty, Animations.Logo.FadeOutContent);
            btnLimpar.BeginAnimation(OpacityProperty, Animations.Logo.FadeOutContent);
            lbMatricula.BeginAnimation(OpacityProperty, Animations.Logo.FadeOutContent);
            lbSenha.BeginAnimation(OpacityProperty, Animations.Logo.FadeOutContent);
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
            get { return DTO.Program.Version; }
        }

        private async void LoginWindow_Loaded(object sender, RoutedEventArgs e)
        {
            bool uptodate = await BLL.Program.IsUpToDate();
            if (uptodate)
            {
                txbGit.Text = "Nenhuma atualização pendente.";
            }
            else
            {
                txbGit.Text = "Versão nova disponível: "+ DTO.Program.OnlineVersion;
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
