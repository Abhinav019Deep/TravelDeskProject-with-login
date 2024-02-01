using Microsoft.EntityFrameworkCore;
using TravelDeskProject.Models;

public class TravelDbContext : DbContext
{
    //public TravelDbContext()
    //{

    //}
    public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options) { }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("data source=(localdb)\\MSSQLLocalDB;initial catalog=StuDb;integrated security=true;TrustServerCertificate=true");
    //}
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
}