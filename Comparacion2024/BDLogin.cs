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
        public DbSet<Reels> Reels { get; set; } 
        public DbSet<MPM_COMPARACIONES> MPM_COMPARACIONES { get; set; }
        // Puedes agregar DbSet para otras entidades como Roles si es necesario
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NGL0121W\\SQLEXPRESS01; Database=DBLoginMPM;Integrated Security=true",
                    options => options.EnableRetryOnFailure());
            }
        }
    }
}
