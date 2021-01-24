using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerStore.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public virtual Member Member { get; set; }
        [ForeignKey("Member")]
        public string MemberEmail { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
    }
}
