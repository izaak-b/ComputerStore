using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.ViewModels
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }
        public virtual Cart Cart { get; set; }
        public Guid CartId { get; set; }
        public virtual Product Product { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
