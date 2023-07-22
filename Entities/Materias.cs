using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Entities
{
    public class Materias
    {
        [Key]
        public int PkMateria { get; set; }
        public string Materia { get; set; }
    }
}
