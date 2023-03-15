using Microsoft.EntityFrameworkCore;

namespace ElectronicsVendor.Models
{
  public class ElectronicsVendorContext : DbContext
  {
    public DbSet<Component> Components { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<ComponentVendor> ComponentVendors { get; set; }
    public DbSet<ModelLine> ModelLines { get; set; }
    public ElectronicsVendorContext(DbContextOptions options) : base(options) { }
  }
}