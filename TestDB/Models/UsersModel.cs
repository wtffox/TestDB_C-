using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TestDB
{
    public partial class UsersModel : DbContext
    {
        public UsersModel()
            : base("name=UsersModel")
        {
        }

        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<Musicians> Musicians { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Years> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genres>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Genres>()
                .HasMany(e => e.Tracks)
                .WithRequired(e => e.Genres)
                .HasForeignKey(e => e.genre_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musicians>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Musicians>()
                .HasMany(e => e.Tracks)
                .WithRequired(e => e.Musicians)
                .HasForeignKey(e => e.musician_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tracks>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Tracks)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.owner_id)
                .WillCascadeOnDelete(false);
        }
    }
}
