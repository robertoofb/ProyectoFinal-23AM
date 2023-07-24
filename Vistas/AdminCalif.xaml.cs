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
    /// Lógica de interacción para AdminCalif.xaml
    /// </summary>
    public partial class AdminCalif : Window
    {
        public AdminCalif()
        {
            InitializeComponent();
            GetCalificacionesTable();
        }
        AlumnadoServices services = new AlumnadoServices();
        public void GetCalificacionesTable()
        {
            UserTable.ItemsSource = services.GetCalificaciones();
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            AdminAlumnado admin = new AdminAlumnado();
            admin.Show();
            Close();
        }
    }
}
