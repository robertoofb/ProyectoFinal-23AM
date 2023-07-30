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
        }
        AlumnadoServices services = new AlumnadoServices();
        Calificaciones calificaciones = new Calificaciones();
        CalificacionesServices servicess = new CalificacionesServices();
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MenuDocente main= new MenuDocente();
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

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtGrado.Clear();
            txtMatricula.Clear();
            txtMateria.Clear();
            txtCalificacion.Clear();
        }

        private void BtnAddCalif_Click(object sender, RoutedEventArgs e)
        {
            if (txtMatricula.Text == "")
            {
                MessageBox.Show("Primero selecciona a un alumno");
            }
            else
            {
                Calificaciones calificaciones = new Calificaciones()
                {
                    FkMatricula = int.Parse(txtMatricula.Text),
                    FkMateria = int.Parse(txtMateria.Text),
                    FkGrado = int.Parse(txtGrado.Text),
                    Calificación = decimal.Parse(txtCalificacion.Text)
                };

                servicess.AddCalificacion(calificaciones);
                MessageBox.Show("Calificación agregada");
                txtNombre.Clear();
                txtGrado.Clear();
                txtMatricula.Clear();
                txtCalificacion.Clear();
                txtMateria.Clear();
            }
        }
        private void BtnMaterias_Click(object sender, RoutedEventArgs e)
        {
            DocenteMaterias docente = new DocenteMaterias();
            docente.Show();
            Close();
        }
    }
}
