using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Numero
    {
        [Key]
        public int Id { get; set; }
        public int Valor { get; set; }
        public string Hexadecimal { get; set; }
        public string Binario { get; set; }
        public List<Multiplo> Multiplos { get; set; }
    }
}
