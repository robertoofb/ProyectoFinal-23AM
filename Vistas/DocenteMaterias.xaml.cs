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
    /// Lógica de interacción para DocenteMaterias.xaml
    /// </summary>
    public partial class DocenteMaterias : Window
    {
        public DocenteMaterias()
        {
            InitializeComponent();
            GetMateriasTable();
        }
        CalificacionesServices services= new CalificacionesServices();
        public void GetMateriasTable()
        {
            AlumnoTable.ItemsSource = services.GetMaterias();
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Docente main = new Docente();
            main.Show();
            Close();
        }
    }
}
