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
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }

        UsuarioServices services = new UsuarioServices();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtPkUser.Text == "")
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = txtNombre.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    FkRol = int.Parse(SelectRol.SelectedValue.ToString())
                };

                services.AddUser(usuario);
                MessageBox.Show("Usuario agregado");
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUserTable();
            }
            else
            {
                //hacer funcion editar y eliminar
                int userId = Convert.ToInt32(txtPkUser.Text);
                Usuario usuario = new Usuario()
                {
                    PkUsuario = userId,
                    Nombre= txtNombre.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    FkRol = int.Parse(SelectRol.SelectedValue.ToString())
                };
                services.UpdateUser(usuario);
                MessageBox.Show("Usuario modificado");
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUserTable();
            }
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario;
            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
        }
        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            if (txtPkUser.Text!= "")
            {
                int userId = Convert.ToInt32(txtPkUser.Text);
                Usuario usuario = new Usuario();
                usuario.PkUsuario = userId;
                services.DeleteUser(userId);
                MessageBox.Show("Registro Eliminado");
                txtNombre.Clear();
                txtUserName.Clear();
                txtPassword.Clear();
                GetUserTable();
            }
            else
            {
                MessageBox.Show("Primero selecciona un registro");
            }
        }
        public void GetUserTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
        }
        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main= new MainWindow();
            main.Show();
            Close();
        }

        private void BtnAlumnos_Click(object sender, RoutedEventArgs e)
        {
            AdminAlumnado alumno = new AdminAlumnado();
            alumno.Show();
            Close();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtPkUser.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            txtNombre.Clear();
        }
    }
}
