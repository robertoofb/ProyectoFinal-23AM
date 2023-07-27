using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Entities
{
    public class Observaciones
    {
        [Key]
        public int PkObervaciones { get; set; }
        public string Observación { get; set; }

        [ForeignKey("Alumnos")]
        public int? FkMatricula { get; set; }
        public Alumno Alumnos { get; set; }
    }
}
