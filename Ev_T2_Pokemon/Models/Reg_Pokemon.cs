using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models
{
    public class Reg_Pokemon
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Id es Obligatorio")]
        public  string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Nombre es Obligatorio")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "El campo Tipo es Obligatorio")]
        public string Imagen { get; set; }
        [Required(ErrorMessage = "El campo Iamgen es Obligatorio")]

        public Us_Pokemon Us_Pokemon { get; set; }

    }
}
