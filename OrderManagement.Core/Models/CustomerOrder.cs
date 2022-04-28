namespace OrderManagement.Core.Models;

public class CustomerOrder
{
    public Guid Id { get; set; }
    public virtual Customer Customer { get; set; }//siparisi veren
    public DateTime CreatedAt { get; set; }
    public int TotalPrice { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public string Name { get; set; }//gonderilecegi kisi
    public string Address { get; set; }//gonderilen adres

}

public class OrderItem
{
    public Guid Id { get; set; }
    public virtual CustomerOrder Order { get; set; }
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}

