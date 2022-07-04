using CidadeAltaProject.Controllers;
using CidadeAltaProject.Objects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class XMainWindow : Window
  {
    private static XMainWindow _Instancia;
    public Usuario UsuarioLogado;

    public static XMainWindow Instancia
    {
      get
      {
        return _Instancia ?? (_Instancia = new XMainWindow());
      }
    }

    public static void CriaInstancia()
    {
      _Instancia = new XMainWindow();
    }

    private XMainWindow()
    {
      InitializeComponent();

      TxtUser.Foreground = Brushes.Gray;
      TxtUser.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
      TxtUser.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(TxtUser_LostKeyboardFocus);
      TxtSenha.Foreground = Brushes.Gray;
      TxtSenha.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
      TxtSenha.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(TxtSenha_LostKeyboardFocus);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      using (var userService = new XUserServicesController(null))
      {
        UsuarioLogado = userService.Login(TxtUser.Text, TxtSenha.Text);
        if (UsuarioLogado != null)
        {
          XWindowTable window = new XWindowTable();
          window.Show();
          this.Visibility = Visibility.Hidden;
        }
        else
        {
          LblOperationError.Visibility = Visibility.Visible;
          LblOperationError.Foreground = Brushes.Red;
          LblOperationError.Content = "*Usuario e/ou senha inválido(s).";
        }
      }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      if (TxtUser.Text == "Usuario")
        return;
      using (var userService = new XUserServicesController(null))
      {
        if (userService.Cadastrar(TxtUser.Text, TxtSenha.Text))
        {
          LblOperationError.Visibility = Visibility.Visible;
          LblOperationError.Foreground = Brushes.Green;
          LblOperationError.Content = "Cadastro feito com sucesso.";
        }
        else
        {
          LblOperationError.Visibility = Visibility.Visible;
          LblOperationError.Foreground = Brushes.Red;
          LblOperationError.Content = "*Usuario já existe.";
        }
      }
    }

    private void tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender is TextBox)
      {
        //If nothing has been entered yet.
        if (((TextBox)sender).Foreground == Brushes.Gray)
        {
          ((TextBox)sender).Text = "";
          ((TextBox)sender).Foreground = Brushes.Black;
        }
      }
    }

    private void TxtUser_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender is TextBox)
      {
        if (((TextBox)sender).Text.Trim().Equals(""))
        {
          ((TextBox)sender).Foreground = Brushes.Gray;
          ((TextBox)sender).Text = "Usuario";
        }
      }
    }

    private void TxtSenha_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
      if (sender is TextBox)
      {
        if (((TextBox)sender).Text.Trim().Equals(""))
        {
          ((TextBox)sender).Foreground = Brushes.Gray;
          ((TextBox)sender).Text = "Senha";
        }
      }
    }
  }
}
