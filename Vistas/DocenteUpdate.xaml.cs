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
    /// Lógica de interacción para DocenteUpdate.xaml
    /// </summary>
    public partial class DocenteUpdate : Window
    {
        public DocenteUpdate()
        {
            InitializeComponent();
            GetCalificacionesTable();
        }

        AlumnadoServices services = new AlumnadoServices();
        CalificacionesServices servicess = new CalificacionesServices();

        public void GetCalificacionesTable()
        {
            UserTable.ItemsSource = services.GetCalificaciones();
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MenuDocente main = new MenuDocente();
            main.Show();
            Close();
        }
        public void EditItemCalif(object sender, RoutedEventArgs e)
        {
            Calificaciones calificaciones = new Calificaciones();
            calificaciones = (sender as FrameworkElement).DataContext as Calificaciones;
            txtId.Text = calificaciones.PkCalificaciones.ToString();
            txtMateria.Text = calificaciones.FkMateria.ToString();
            txtCalificacion.Text = calificaciones.Calificación.ToString();
            txtMatricula.Text = calificaciones.FkMatricula.ToString();
            txtGrado.Text = calificaciones.FkGrado.ToString();
        }

        private void BtnClearCalif_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtMateria.Clear();
            txtCalificacion.Clear();
            txtGrado.Clear();
            txtMatricula.Clear();
        }

        private void BtnUpdateCalif_Click(object sender, RoutedEventArgs e)
        {
            if(txtId.Text == "")
            {
                MessageBox.Show("Primero selecciona una calificación");
            }
            else
            {
                int userId = Convert.ToInt32(txtId.Text);
                Calificaciones calificaciones = new Calificaciones()
                {
                    PkCalificaciones = userId,
                    FkMatricula = int.Parse(txtMatricula.Text),
                    FkMateria = int.Parse(txtMateria.Text),
                    FkGrado = int.Parse(txtGrado.Text),
                    Calificación = decimal.Parse(txtCalificacion.Text)
                };

                servicess.UpdateCalificacion(calificaciones);
                MessageBox.Show("Calificación modificada");
                GetCalificacionesTable();
                txtId.Clear();
                txtMateria.Clear();
                txtCalificacion.Clear();
                txtGrado.Clear();
                txtMatricula.Clear();
            }
        }
    }
}
