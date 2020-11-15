using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web1.Domain;

namespace Web1.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual  DbSet<Role> Roles { get; set; }
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
              .HasData(
              new Role() { RoleId = 1, RoleName = "Admin", Status = true },
              new Role() { RoleId = 2, RoleName = "Director", Status = true },
              new Role() { RoleId = 3, RoleName = "Manager", Status = true },
              new Role() { RoleId = 4, RoleName = "Leader", Status = true },
              new Role() { RoleId = 5, RoleName = "Staff", Status = true });
        }

    }
}
