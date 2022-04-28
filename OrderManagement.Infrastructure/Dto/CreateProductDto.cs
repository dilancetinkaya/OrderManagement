namespace OrderManagement.Infrastructure.Dto;

public class CreateProductDto
{
    public string Barcode { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
}

