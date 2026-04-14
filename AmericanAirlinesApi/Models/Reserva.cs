using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericanAirlinesApi.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int VooId { get; set; }
        public string NomePassageiro { get; set; }
        public string Assento { get; set; }

    }
}