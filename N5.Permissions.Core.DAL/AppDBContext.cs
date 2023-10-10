using Microsoft.EntityFrameworkCore;
using N5.Permissions.Core.Contracts;
using N5.Permissions.Core.Entities;

namespace N5.Permissions.Core.DAL
{
    public class AppDBContext : DbContext , IAppDBContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
           : base(options)
        {
        }     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

            modelBuilder.Entity<Permission>()
            .HasOne(e => e.PermissionType)
            .WithMany()
            .HasForeignKey("PermissionType_Id")
            .IsRequired();
        }

        public void Save()
        {
            SaveChanges();
        }

        #region DBSets

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }      

        #endregion
    }
}