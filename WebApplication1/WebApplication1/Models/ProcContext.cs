using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Models
{
    public class ProcContext : DbContext
    {
        public ProcContext(DbContextOptions<ProcContext> options)
            : base(options)
        {

        }

        public DbSet<ImageM> ImageMs { get; set; }
        public DbSet<Smile> Smiles { get; set; }
        public DbSet<Body> Bodies { get; set; }
    }
}
