namespace OrderManagement.Infrastructure.Dto;

public class UpdateCustomerOrderDto
{
    public Guid CustomerId { get; set; }//siparisi veren
    public DateTime CreatedAt { get; set; }
    public int TotalPrice { get; set; }
    //public virtual ICollection<OrderItemDto> OrderItems { get; set; }
    public string Name { get; set; }//gönderilecegi kisi
    public string Address { get; set; }//gönderilen adres

}

public class UpdateOrderItemDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}