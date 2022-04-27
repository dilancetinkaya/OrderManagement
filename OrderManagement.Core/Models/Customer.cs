using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Models;

public class Customer : IdentityUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

