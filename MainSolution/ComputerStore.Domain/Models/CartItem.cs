﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerStore.Domain.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public virtual Cart Cart { get; set; }
        [ForeignKey("Cart")]
        public Guid CartId { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Quantity { get; set; }
}
}
