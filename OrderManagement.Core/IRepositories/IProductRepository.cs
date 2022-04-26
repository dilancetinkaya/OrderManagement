using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.IRepositories;

public interface IProductRepository
{
    public List<Product> GetProduct();
    public Product GetProductById(Guid id);
    public void CreateProduct(Product product);
    public void UpdateProduct(Product product);
    public void DeleteProduct(Guid id);
}

