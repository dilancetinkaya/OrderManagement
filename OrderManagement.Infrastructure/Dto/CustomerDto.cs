﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Dto;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}

