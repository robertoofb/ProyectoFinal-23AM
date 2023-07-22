using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23AM.Context;
using ProyectoFinal_23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoFinal_23AM.Services
{
    public class AlumnadoServices
    {
        public void AddAlumno(Alumno request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Alumno res = new Alumno()
                        {
                            Nombre = request.Nombre,
                        };
                        _context.alumnos.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void UpdateAlumno(Alumno request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Alumno update = _context.alumnos.Find(request.PkMatricula);
                    update.Nombre = request.Nombre;

                    _context.alumnos.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void DeleteAlumno(int UserId)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Alumno alumno = _context.alumnos.Find(UserId);

                    if (alumno != null)
                    {
                        _context.alumnos.Remove(alumno);
                        _context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("No existe el registro");
                    }

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Alumno> GetAlumnos()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Alumno> alumnos = new List<Alumno>();

                    alumnos = _context.alumnos.ToList();

                    return alumnos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
    }
}
