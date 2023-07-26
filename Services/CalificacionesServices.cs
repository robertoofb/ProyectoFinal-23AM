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
    public class CalificacionesServices
    {
        public void AddCalificacion(Calificaciones request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Calificaciones res = new Calificaciones()
                        {
                            FkMatricula = request.FkMatricula,
                            FkGrado= request.FkGrado,
                            FkMateria= request.FkMateria,
                            Calificación = request.Calificación,
                        };
                        _context.calificaciones.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public void UpdateCalificacion(Calificaciones request)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Calificaciones update = _context.calificaciones.Find(request.PkCalificaciones);
                    update.FkMatricula = request.FkMatricula;
                    update.FkGrado = request.FkGrado;
                    update.FkMateria = request.FkMateria;
                    update.Calificación = request.Calificación;

                    _context.calificaciones.Update(update);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
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
        public List<Materias> GetMaterias()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Materias> materias = new List<Materias>();

                    materias = _context.materias.ToList();

                    return materias;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
    }
}
