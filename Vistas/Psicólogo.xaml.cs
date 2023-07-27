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
    /// Lógica de interacción para Psicólogo.xaml
    /// </summary>
    public partial class Psicólogo : Window
    {
        public Psicólogo()
        {
            InitializeComponent();
            GetCalificacionesTable();
        }
        AlumnadoServices services= new AlumnadoServices();
        ObservacionesServices servicess = new ObservacionesServices();
        public void GetCalificacionesTable()
        {
            UserTable.ItemsSource = services.GetCalificacionesPsicólogo();
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Calificaciones calificaciones = new Calificaciones();
            calificaciones = (sender as FrameworkElement).DataContext as Calificaciones;
            txtMatricula.Text = calificaciones.FkMatricula.ToString();
        }

        private void BtnAddObs_Click(object sender, RoutedEventArgs e)
        {
            Observaciones observaciones = new Observaciones()
            {
                FkMatricula = int.Parse(txtMatricula.Text),
                Observación = txtObservación.Text
            };

            servicess.AddObservación(observaciones);
            MessageBox.Show("Observación agregada, será visible para el tutor del alumno");
            txtMatricula.Clear();
            txtObservación.Clear();
        }
    }
}
