using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComputerStore.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
    }
}
