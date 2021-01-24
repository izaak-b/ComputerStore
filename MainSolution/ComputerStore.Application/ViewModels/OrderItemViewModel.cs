using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.ViewModels
{
    public class OrderItemViewModel
    {
        public Guid Id { get; set; }
        public virtual Order Order { get; set; }
        public Guid OrderId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
