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
        public DbSet<Collaborator> CollaborationTable { get; set; }
        public DbSet<Label> LabelTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborator>()
                .HasKey(e => new { e.NotesId, e.Id });
            modelBuilder.Entity<Collaborator>()
                .HasOne(e => e.notes)
                .WithMany(e => e.Collaborator)
                .HasForeignKey(e => e.NotesId);
            modelBuilder.Entity<Collaborator>()
                .HasOne(e => e.User)
                .WithMany(e => e.Collaborator)
                .HasForeignKey(e => e.Id);
        }
    }
}




    
