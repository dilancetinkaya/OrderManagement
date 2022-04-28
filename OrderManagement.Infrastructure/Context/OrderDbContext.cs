using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Models;

namespace OrderManagement.Infrastructure.Context;
public class OrderDbContext : IdentityDbContext<Customer>
{

    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {

    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
}


