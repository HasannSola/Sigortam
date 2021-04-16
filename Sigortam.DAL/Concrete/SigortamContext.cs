using Microsoft.EntityFrameworkCore;
using Sigortam.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Concrete
{
    public class SigortamContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "";
            connection = @"Server=.; Database=Sigortam;Integrated Security=false; Persist Security Info=False; User ID=sa; Password=1; MultipleActiveResultSets=True";
            //connection = @"Server=(localdb)\MSSQLLocalDB; Database=CrmMs; Persist Security Info=True;  MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connection);
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Collection 
            modelBuilder.Entity<Entities.Model.User>().Property(p => p.StPlaka)
            .HasMaxLength(20);
            modelBuilder.Entity<Entities.Model.User>().Property(p => p.StRuhsatSeriKodu)
             .HasMaxLength(50);
            modelBuilder.Entity<Entities.Model.User>().Property(p => p.StRuhsatSeriNo)
               .HasMaxLength(50);
            modelBuilder.Entity<Entities.Model.User>().Property(p => p.StTCKN)
               .HasMaxLength(50);
            #endregion
        }
    }
}
