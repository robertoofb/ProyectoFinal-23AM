using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Entities
{
    public class Calificaciones
    {
        [Key]
        public int PkCalificaciones { get; set; }

        public decimal Calificación { get; set; }

        [ForeignKey("Materias")]
        public int? FkMateria { get; set; }
        public Materias Materias { get; set; }

        [ForeignKey("Grados")]
        public int? FkGrado { get; set; }
        public Grados Grados { get; set; }

        [ForeignKey("Alumnos")]
        public int? FkMatricula { get; set; }
        public Alumno Alumnos { get; set; }
    }
}
