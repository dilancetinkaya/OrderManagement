using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Core.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

}

