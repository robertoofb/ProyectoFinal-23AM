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
    /// Lógica de interacción para Tutor.xaml
    /// </summary>
    public partial class Tutor : Window
    {
        public Tutor()
        {
            InitializeComponent();
        }
        AlumnadoServices services = new AlumnadoServices();
        ObservacionesServices servicess = new ObservacionesServices();
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
        public void GetCalificacionesTable()
        {
            UserTable.ItemsSource = services.GetCalificacionesTutor(txtNombre.Text);
        }
        public void GetObservacionesTable()
        {
            UserTableO.ItemsSource = servicess.GetObservaciones(txtNombre.Text);
        }
        private void BtnMaterias_Click(object sender, RoutedEventArgs e)
        {
            GetCalificacionesTable();
            GetObservacionesTable();
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Observaciones observaciones = new Observaciones();
            observaciones = (sender as FrameworkElement).DataContext as Observaciones;
            txtObservación.Text = observaciones.Observación.ToString();
        }
    }
}