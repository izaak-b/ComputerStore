using ComputerStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerStore.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public virtual Member Member { get; set; }
        public string MemberEmail { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
