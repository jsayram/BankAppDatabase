using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

#nullable disable

namespace BankApplication.Models
{
    public partial class jrtestdataContext : DbContext
    {
        
        public jrtestdataContext()
        {

        }

        public jrtestdataContext(DbContextOptions<jrtestdataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            using var reader = new StreamReader(@"connectionString.csv");
            var connectionString = reader.ReadLine();
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer($"{connectionString}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(Accounts =>
            {
                Accounts.HasNoKey();

                Accounts.ToTable("ACCOUNTS");

                Accounts.Property(e => e.Balance).HasColumnType("decimal(18, 0)");

                Accounts.Property(e => e.CheckingNumber)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                Accounts.Property(e => e.UsersId).HasColumnName("UsersID");

                Accounts.HasOne(d => d.Users)
                    .WithMany()
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("ACCOUNTS_FK");
            });

            modelBuilder.Entity<User>(User =>
            {
                User.HasKey(e => e.UsersPkid)
                    .HasName("USERS_PK");

                User.ToTable("USERS");

                User.Property(e => e.UsersPkid)
                    .ValueGeneratedNever()
                    .HasColumnName("UsersPKID");

                User.Property(e => e.FistName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                User.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                User.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .UseCollation("SQL_Latin1_General_CP1_CS_AS");

                User.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
