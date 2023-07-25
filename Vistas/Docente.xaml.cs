using ProyectoFinal_23AM.Entities;
using ProyectoFinal_23AM.Services;
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
    /// Lógica de interacción para Docente.xaml
    /// </summary>
    public partial class Docente : Window
    {
        public Docente()
        {
            InitializeComponent();
            GetAlumnosTable();
        }
        AlumnadoServices services = new AlumnadoServices();
        Alumno alumno = new Alumno();
        Calificaciones calificaciones = new Calificaciones();
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
            Close();
        }
        public void GetAlumnosTable()
        {
            UserTable.ItemsSource = services.GetAlumnos();
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {

            alumno = (sender as FrameworkElement).DataContext as Alumno;
            txtNombre.Text = alumno.Nombre.ToString();



        }
    }
}
