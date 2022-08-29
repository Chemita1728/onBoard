using onBoard.Models;
using Microsoft.EntityFrameworkCore;
using System;


namespace onBoard.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<UserSQL> Users { get; set; }
        public DbSet<HourSQL> Hours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSQL>().ToTable("User").HasKey(p => p.UserID);
            modelBuilder.Entity<HourSQL>().ToTable("Hour").HasKey(p => p.HourID);
        }
    }
}
