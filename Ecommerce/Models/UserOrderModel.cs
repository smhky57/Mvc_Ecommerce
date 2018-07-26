﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce.Entity;
namespace Ecommerce.Models
{
    public class UserOrderModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }

    }
}