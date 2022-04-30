using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Core.Models;

public class CustomerOrder
{
    public CustomerOrder()
    {
        OrderItems = new List<OrderItem>();
    }
    public Guid Id { get; set; }
    public string CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }//siparisi veren
    public DateTime CreatedAt { get; set; }
    public double TotalPrice { get=>CalculateTotalPrice();  }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public string Name { get; set; }//gonderilecegi kisi
    public string Address { get; set; }//gonderilen adres

    private double CalculateTotalPrice()
    {
        double totalPrice = 0;
        totalPrice = OrderItems.Sum(x => x.Quantity * x.Product.Price);
        return totalPrice;

    }

}

public class OrderItem
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    [ForeignKey("OrderId")]
    public virtual CustomerOrder Order { get; set; }
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}

