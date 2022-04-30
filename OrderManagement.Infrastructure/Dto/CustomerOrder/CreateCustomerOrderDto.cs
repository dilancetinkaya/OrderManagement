namespace OrderManagement.Infrastructure.Dto;

public class CreateCustomerOrderDto
{
    public string CustomerId { get; set; }
    public  List<CreateOrderItemDto> OrderItems { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

}

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
