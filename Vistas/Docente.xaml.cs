using ProyectoFinal_23AM.Entities;
using ProyectoFinal_23AM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            GetCalificacionesTable();
        }
        AlumnadoServices services = new AlumnadoServices();
        Calificaciones calificaciones = new Calificaciones();
        CalificacionesServices servicess = new CalificacionesServices();
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
            Close();
        }
        public void GetAlumnosTable()
        {
            AlumnoTable.ItemsSource = services.GetAlumnos();
            AlumnoTable.ItemsSource = services.GetGrado();
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Alumno alumno = new Alumno();
            alumno = (sender as FrameworkElement).DataContext as Alumno;
            txtMatricula.Text = alumno.PkMatricula.ToString();
            txtNombre.Text = alumno.Nombre.ToString();
            txtGrado.Text = alumno.FkGrado.ToString();
        }
        public void EditItemCalif(object sender, RoutedEventArgs e)
        {
            Calificaciones calificaciones = new Calificaciones();
            calificaciones = (sender as FrameworkElement).DataContext as Calificaciones;
            txtId.Text = calificaciones.PkCalificaciones.ToString();
            txtMateria.Text = calificaciones.FkMateria.ToString();
            txtCalificacion.Text = calificaciones.Calificación.ToString();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtGrado.Clear();
            txtMatricula.Clear();
        }

        private void BtnAddCalif_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text == "")
            {
                Calificaciones calificaciones = new Calificaciones()
                {
                    FkMatricula = int.Parse(txtMatricula.Text),
                    FkMateria = int.Parse(txtMateria.Text),
                    FkGrado = int.Parse(txtGrado.Text),
                    Calificación = int.Parse(txtCalificacion.Text)
                };

                servicess.AddCalificacion(calificaciones);
                MessageBox.Show("Calificación agregada");
                GetCalificacionesTable();
                txtNombre.Clear();
                txtGrado.Clear();
                txtMatricula.Clear();
                txtCalificacion.Clear();
                txtMateria.Clear();
            }
            else
            {
                //hacer funcion editar y eliminar
                int userId = Convert.ToInt32(txtId.Text);
                Calificaciones calificaciones = new Calificaciones()
                {
                    PkCalificaciones = userId,
                    FkMatricula = int.Parse(txtMatricula.Text),
                    FkMateria = int.Parse(txtMateria.Text),
                    FkGrado = int.Parse(txtGrado.Text),
                    Calificación = int.Parse(txtCalificacion.Text)
                };

                servicess.UpdateCalificacion(calificaciones);
                MessageBox.Show("Calificación modificada");
                GetCalificacionesTable();
                txtNombre.Clear();
                txtGrado.Clear();
                txtMatricula.Clear();
                txtCalificacion.Clear();
                txtMateria.Clear();
            }
        }
        public void GetCalificacionesTable()
        {
            UserTable.ItemsSource = services.GetCalificaciones();
        }

        private void BtnClearCalif_Click(object sender, RoutedEventArgs e)
        {
            txtMateria.Clear();
            txtCalificacion.Clear();
            txtId.Clear();
        }

        private void BtnMaterias_Click(object sender, RoutedEventArgs e)
        {
            DocenteMaterias docente = new DocenteMaterias();
            docente.Show();
            Close();
        }
    }
}
