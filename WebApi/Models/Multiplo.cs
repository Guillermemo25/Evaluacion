using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Multiplo
    {
        [Key]
        public int Id { get; set; }
        public int Valor { get; set; }
    }
}
