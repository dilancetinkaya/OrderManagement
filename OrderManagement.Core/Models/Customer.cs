using Microsoft.AspNetCore.Identity;

namespace OrderManagement.Core.Models;

public class Customer : IdentityUser
{
    public string Name { get; set; }
    public string Address { get; set; }
}

