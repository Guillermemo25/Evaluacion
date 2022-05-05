using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class NumeroContext: DbContext
    {
        public NumeroContext(DbContextOptions<NumeroContext> options) : base(options)
        {
        }

        public DbSet<Numero> Numeros { get; set; }
        public DbSet<Multiplo> Multiplos { get; set; }
    }
}
