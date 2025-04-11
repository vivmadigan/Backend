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

            // Seed Clients
            modelBuilder.Entity<ClientEntity>().HasData(
                new ClientEntity { Id = "4f3bb3c0-3d92-4e28-b6e4-5823a30b3a1c", ClientName = "Contoso Ltd." },
                new ClientEntity { Id = "c2ab1b58-0e0f-4b52-9a11-0dc5e18cfd63", ClientName = "Globex Corporation" },
                new ClientEntity { Id = "0b8c6218-e1c7-4149-b3c9-3e6217c1c14e", ClientName = "Soylent Corp" },
                new ClientEntity { Id = "ab2566ae-45c9-4c11-85ff-1ef1da3772e4", ClientName = "Initech" },
                new ClientEntity { Id = "f6dc7358-0bd3-4c43-a965-40421ef8ee4f", ClientName = "Umbrella Corp" }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = "e00af53f-45dc-4e1b-9db4-82512bc2b31a", UserName = "alice@example.com" },
                new UserEntity { Id = "8297339c-1f0f-4d6d-a378-c6a08a61ff2a", UserName = "bob@example.com" },
                new UserEntity { Id = "6618abef-8c1e-44c5-a2d1-3318c6c76927", UserName = "carol@example.com" },
                new UserEntity { Id = "58e16de8-2046-4f4f-86da-88e11bdc0f2a", UserName = "dave@example.com" },
                new UserEntity { Id = "65c37406-2a7a-4f67-8c7f-89b4b2e40f03", UserName = "eve@example.com" }
            );

            // Seed Statuses
            modelBuilder.Entity<StatusEntity>().HasData(
                new StatusEntity { Id = 1, StatusName = "Planning" },
                new StatusEntity { Id = 2, StatusName = "Started" },
                new StatusEntity { Id = 3, StatusName = "Completed" }
            );
        }
    }
}
