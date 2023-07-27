using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23AM.Context;
using ProyectoFinal_23AM.Entities;
using ProyectoFinal_23AM.Vistas;
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
                            FkGrado= request.FkGrado
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
                    update.FkGrado = request.FkGrado;

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
        public List<Calificaciones> GetCalificaciones()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Calificaciones> calificaciones = new List<Calificaciones>();

                    calificaciones = _context.calificaciones.Include(x => x.Materias).Include(x => x.Grados).Include(x => x.Alumnos).ToList();

                    return calificaciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public List<Calificaciones> GetCalificacionesPsicólogo()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Calificaciones> calificaciones = new List<Calificaciones>();

                    calificaciones = _context.calificaciones.Where(x => x.Calificación < 6).Include(x => x.Materias).Include(x => x.Grados).Include(x => x.Alumnos).ToList();
                    return calificaciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public List<Calificaciones> GetCalificacionesTutor(string Nombre)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Calificaciones> calificaciones = new List<Calificaciones>();

                    calificaciones = _context.calificaciones.Where(x => x.Alumnos.Nombre == Nombre).Include(x => x.Materias).Include(x => x.Grados).Include(x => x.Alumnos).ToList();
                    return calificaciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public List<Alumno> GetGrado()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Alumno> alumnos = new List<Alumno>();

                    alumnos = _context.alumnos.Include(x => x.Grados).ToList();

                    return alumnos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
        public List<Calificaciones> GetMateria()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Calificaciones> alumnos = new List<Calificaciones>();

                    alumnos = _context.calificaciones.Include(x => x.Materias).ToList();

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
