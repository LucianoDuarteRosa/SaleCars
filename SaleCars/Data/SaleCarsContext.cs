using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaleCars.Models;

namespace SaleCars.Data;

public class SaleCarsContext : IdentityDbContext<UserModel, IdentityRole<int>, int>
{
    public SaleCarsContext(DbContextOptions<SaleCarsContext> options) : base(options) { }

    public DbSet<ProfileModel> Profiles { get; set; }
    public DbSet<ClientModel> Clients { get; set; }
    public DbSet<SaleStatusModel> SaleStatus { get; set; }
    public DbSet<CarModel> Cars { get; set; }
    public DbSet<SaleModel> Sales { get; set; }
    public DbSet<SupplierModel> Suppliers { get; set; }
}
