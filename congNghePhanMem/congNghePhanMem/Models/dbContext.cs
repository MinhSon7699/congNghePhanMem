namespace congNghePhanMem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<check> checks { get; set; }
        public virtual DbSet<information> information { get; set; }
        public virtual DbSet<register> registers { get; set; }
        public virtual DbSet<work> works { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<information>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<information>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<information>()
                .HasMany(e => e.checks)
                .WithOptional(e => e.information)
                .HasForeignKey(e => e.IdInformation);

            modelBuilder.Entity<register>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.passWord)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<register>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<work>()
                .Property(e => e.nameEmployee)
                .IsUnicode(false);

            modelBuilder.Entity<work>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<work>()
                .Property(e => e.department)
                .IsUnicode(false);
        }
    }
}
