using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ev_T2_Pokemon.Models
{
    public class Us_Pokemon
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPokemon { get; set; }
        public DateTime Fecha { get; set; }

        // relaciones
        public Reg_Pokemon Reg_Pokemon { get; set; }
        public Reg_Usuario Reg_Usuario { get; set; }

    }
}
