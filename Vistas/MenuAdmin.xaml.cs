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

namespace ProyectoFinal_23AM.Vistas
{
    /// <summary>
    /// Lógica de interacción para MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Window
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            Sistema sistema= new Sistema();
            sistema.Show();
            Close();
        }

        private void BtnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            AdminAlumnado alumno = new AdminAlumnado();
            alumno.Show();
            Close();
        }

        private void BtnCalif_Click(object sender, RoutedEventArgs e)
        {
            AdminCalif calif = new AdminCalif();
            calif.Show();
            Close();
        }
    }
}
