﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

}
