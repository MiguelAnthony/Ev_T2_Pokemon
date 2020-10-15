using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models
{
    public class Reg_Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Id es Obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "El campo Usuario es Obligatorio")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es Obligatorio")]

        public List<Us_Pokemon> Us_Pokemon { get; set; }

    }
}
