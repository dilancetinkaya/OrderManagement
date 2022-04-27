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
    public Guid ProductId { get; set; }
    public Guid CustomerId { get; set; }
    [ForeignKey("ProductId")]
    public virtual List<Product> Products { get; set; }
    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; }


}

