using Microsoft.EntityFrameworkCore;
using ProyectoFinal_23AM.Context;
using ProyectoFinal_23AM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Services
{
    public class ObservacionesServices
    {
        public void AddObservación(Observaciones request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDbContext())
                    {
                        Observaciones res = new Observaciones()
                        {
                            FkMatricula = request.FkMatricula,
                            Observación = request.Observación
                        };
                        _context.observaciones.Add(res);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error " + ex.Message);
            }
        }
        public List<Observaciones> GetObservaciones(string Nombre)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Observaciones> observaciones = new List<Observaciones>();

                    observaciones = _context.observaciones.Where(x => x.Alumnos.Nombre == Nombre).ToList();
                    return observaciones;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error " + ex.Message);
            }
        }
    }
}
