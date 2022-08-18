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

        public DbSet<User> Users { get; set; }
        public DbSet<HourSQL> Hours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<HourSQL>().ToTable("Hour");
        }
    }
}
