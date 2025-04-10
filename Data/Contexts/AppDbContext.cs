using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<StatusEntity> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationships and other settings here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
