using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Data;
using System;
using WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumeroController : ControllerBase
    {
        private readonly NumeroContext _context;

        public NumeroController(NumeroContext context)
        {
            _context = context;
            if (_context.Numeros.Count() == 0)
            {
                _context.Numeros.Add(new Numero() { Valor = 2 });
                _context.Numeros.Add(new Numero() { Valor = 3 });
                _context.Numeros.Add(new Numero() { Valor = 5 });
                _context.Numeros.Add(new Numero() { Valor = 7 });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("{valor}")]
        public ActionResult Get(int valor) 
        {
            Numero numero = new Numero();
            numero.Valor = valor;
            numero.Multiplos = new List<Multiplo>();
            _context.Multiplos.ToList().ForEach(multiplo => 
            {
                if (esMultiplo(multiplo.Valor, valor))
                    numero.Multiplos.Add(multiplo);
            });

            numero.Binario = Convert.ToString(valor, 2);
            numero.Hexadecimal = Convert.ToString(valor, 16);
            return Ok(numero);
        }

        private bool esMultiplo(int multiplo, int valor)
        {
            return valor % multiplo == 0;
        }

        [HttpPost]
        public ActionResult Post(Multiplo multiplo)
        {
            //var numero = _context.Numeros.OrderBy(numero=> numero.Id).Last();
            var multiplos = _context.Multiplos.ToList();

            if (!multiplos.Exists(m => m.Valor == multiplo.Valor))
            {
                _context.Multiplos.Add(multiplo);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Post), new { Id = multiplo.Id }, multiplo);
            }
            else
                return BadRequest();
        }

    }
}
