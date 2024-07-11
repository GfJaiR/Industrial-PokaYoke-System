using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Comparacion2024
{
    class BDLogin : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }    
        public DbSet<Stenciles> Stenciles { get; set; }
        public DbSet<Pastas> Pastas { get; set; }
        public DbSet<MPM_COMPARACIONES> MPM_COMPARACIONES { get; set; }
        // Puedes agregar DbSet para otras entidades como Roles si es necesario
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NGNAB001; Database=DBLoginMPM;User Id=hornosUser; Password=Conti123;",
                    options => options.EnableRetryOnFailure());
            }
        }
    }
}
