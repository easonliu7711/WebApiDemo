using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data.Entities;

namespace WebApiDemo.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<DeviceEntity> DeviceInfo { get; set; }

    public override int SaveChanges()
    {
        OnBeforeSaving();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSaving()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity &&
                        (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Added)
                ((AuditableEntity)entityEntry.Entity).CreateTime = DateTime.UtcNow;
            else
                entityEntry.Property("CreateTime").IsModified = false;
            ((AuditableEntity)entityEntry.Entity).UpdateTime = DateTime.UtcNow;
        }
    }
}