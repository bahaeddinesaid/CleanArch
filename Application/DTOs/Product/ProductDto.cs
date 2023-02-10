using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class ProductDto : BaseDto<int>
    {
        public string Description { get; set; }

        public string Type { get; set; }
    }
}
