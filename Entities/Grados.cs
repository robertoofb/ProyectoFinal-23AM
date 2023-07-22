using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal_23AM.Entities
{
    public class Grados
    {
        [Key]
        public int PkGrado { get; set; }
        public int Grado { get; set; }

    }
}
