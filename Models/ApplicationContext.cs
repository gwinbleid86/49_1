using System;
using Microsoft.EntityFrameworkCore;

namespace _49_1.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<TaskModel> TasksModel { get; set; }
        public DbSet<UserModel> UsersModel { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map entities to tables
            modelBuilder.Entity<TaskModel>().ToTable("Task");
            modelBuilder.Entity<UserModel>().ToTable("User");

            // Configure Primary Keys
            modelBuilder.Entity<TaskModel>().HasKey(e => e.Id).HasName("PK_Task");
            modelBuilder.Entity<UserModel>().HasKey(e => e.Id).HasName("PK_User");

            // Configure indexes
            modelBuilder.Entity<TaskModel>().HasIndex(e => e.Id).IsUnique().HasDatabaseName("Idx_Task_Id");
            modelBuilder.Entity<UserModel>().HasIndex(e => e.Id).IsUnique().HasDatabaseName("Idx_User_Id");

            // Configure columns
            modelBuilder.Entity<TaskModel>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<TaskModel>().Property(e => e.Name).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<TaskModel>().Property(e => e.DateOfCreate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<TaskModel>().Property(e => e.DateOfRelease).HasColumnType("datetime");
            modelBuilder.Entity<TaskModel>().Property(e => e.Status).HasColumnType("nvarchar(100)").HasDefaultValue("new").IsRequired();
            modelBuilder.Entity<TaskModel>().Property(e => e.Description).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<TaskModel>().Property(e => e.UserId).HasColumnType("int");

            modelBuilder.Entity<UserModel>().Property(e => e.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<UserModel>().Property(e => e.Name).HasColumnType("nvarchar(100)").IsRequired();

            // Configure relationships
            modelBuilder.Entity<TaskModel>().HasOne<UserModel>().WithMany().HasPrincipalKey(e => e.Id).HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_Tasks");
        }
    }
}
