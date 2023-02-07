using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
                       
        public string Description { get; set; } = String.Empty;
        
        public string Type { get; set; } = String.Empty;
    }
}
