namespace OrderManagement.Infrastructure.Dto;

public class CreateCustomerOrderDto
{
    public Guid CustomerId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int TotalPrice { get; set; }
    public  List<OrderItemDto> OrderItems { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

}

public class CreateOrderItemDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
