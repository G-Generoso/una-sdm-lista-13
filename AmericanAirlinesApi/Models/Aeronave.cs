using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericanAirlinesApi.Models
{
    public class Aeronave
    {
        public int Id {get;set;}
        public String Modelo { get; set; }
        public string CodigoCauda { get; set; }
        public int CapacidadePassageiros { get; set; }
    }
}