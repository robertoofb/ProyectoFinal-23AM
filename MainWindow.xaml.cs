using ProyectoFinal_23AM.Services;
using ProyectoFinal_23AM.Vistas;
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

namespace ProyectoFinal_23AM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices services = new UsuarioServices();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUserName.Text;
            string Password = txtPassword.Password;

            var response = services.Login(user, Password);

            if(response != null)
            {
                if(response.Roles.Nombre == "SA")
                {
                    SuperAdmin sistema = new SuperAdmin();
                    sistema.Show();
                    Close();
                }
                else if(response.Roles.Nombre == "Administrador")
                {
                    Sistema sistema = new Sistema();
                    sistema.Show();
                    Close();
                }
                else if(response.Roles.Nombre == "Docente")
                {
                    Docente sistema = new Docente();
                    sistema.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("No se encontró el usuario");
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
