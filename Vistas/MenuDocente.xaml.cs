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
    /// Lógica de interacción para MenuDocente.xaml
    /// </summary>
    public partial class MenuDocente : Window
    {
        public MenuDocente()
        {
            InitializeComponent();
        }
        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void BtnAddCalif_Click(object sender, RoutedEventArgs e)
        {
            Docente docente = new Docente();
            docente.Show();
            Close();
        }

        private void BtnUpdateCalif_Click(object sender, RoutedEventArgs e)
        {
            DocenteUpdate docente = new DocenteUpdate();
            docente.Show();
            Close();
        }
    }
}
