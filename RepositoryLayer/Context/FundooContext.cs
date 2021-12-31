using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    /// <summary>
    /// This is a Context class
    /// </summary>
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> UserTable { get; set; }
        public DbSet<Notes> NoteTable { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Notes>()
        //        .HasKey(c => new { c.Id });
        //}
    }
}
