using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class ProductDto : BaseDto<int>
    {
        
        public string Description { get; set; }

        [Required]
        [MaxLength(10), MinLength(5, ErrorMessage = "Type must be min 5 chars")]
        public string Type { get; set; }
    }
}
