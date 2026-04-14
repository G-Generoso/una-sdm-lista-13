using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AmericanAirlinesApi.Data;
using AmericanAirlinesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmericanAirlinesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VooController : ControllerBase
    {
        private readonly AppDbContext _context;
        public VooController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var voos = _context.Voos.ToList();
            return Ok(voos);
        }
        [HttpPost]
        public IActionResult Post(Voo voo)
        {
            var aeronave = _context.Aeronaves.Find(voo.AeronaveId);
            if (aeronave != null)
            {
                var vooEmAndamento = _context.Voos
        .FirstOrDefault(v => v.AeronaveId == voo.AeronaveId && v.Status == "Em Voo");

                if (vooEmAndamento != null)
                {
                    return Conflict("Aeronave indisponível, encontra-se em trânsito.");
                }
            }
            _context.Voos.Add(voo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = voo.Id }, voo);
        }




        /*A. [POST] Agendamento de Voo Inteligente:
        Ao criar um voo, o sistema deve verificar se a AeronaveId existe.
        Se a aeronave já estiver vinculada a outro voo com status "Em Voo", impeça o
        cadastro e retorne Conflict:
        "Aeronave indisponível, encontra-se em trânsito."*/

    }
}