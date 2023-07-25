using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Entities
{
    public class Alumno
    {
        [Key]
        public int PkMatricula { get; set; }
        public string Nombre { get; set; }

        [ForeignKey ("Grados")]
        public int? FkGrado { get; set; }
        public Grados Grados { get; set; }
    }
}
