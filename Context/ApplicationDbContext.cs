using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //Cadena de conexion
            options.UseMySQL("server=localhost; database=EduKids; user=root; password=");
            //Si hay error con la mmigracion prueba esta
            //optionsBuilder.UseMySQL("Server=localhost;port=3306;User ID=root; Database=Empleados23BM");
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Alumno> alumnos { get; set; }
        public DbSet<Grados> grados { get; set; }
        public DbSet<Materias> materias { get; set; }
        public DbSet<Calificaciones> calificaciones { get; set; }
        public DbSet<Observaciones> observaciones { get; set; }


    }
}  
