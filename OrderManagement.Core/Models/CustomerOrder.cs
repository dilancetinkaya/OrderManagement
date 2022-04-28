using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Models;

public class CustomerOrder
{
    public Guid Id { get; set; }
    public virtual Customer Customer { get; set; }//siparisi veren
    public DateTime CreatedAt { get; set; }
    public int TotalPrice { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public string Name { get; set; }//gönderilecegi kisi
    public string Address { get; set; }//gönderilen adres

}

public class OrderItem
{
    public Guid Id { get; set; }
    public virtual CustomerOrder Order { get; set; }
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}

