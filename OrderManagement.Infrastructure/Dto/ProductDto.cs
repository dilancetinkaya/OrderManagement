using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Dto;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}


