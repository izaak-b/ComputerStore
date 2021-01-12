using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
