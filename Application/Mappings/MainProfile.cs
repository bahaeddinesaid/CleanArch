using Application.DTOs.Product;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MainProfile: AutoMapper.Profile
    {
        public MainProfile()
        {
            #region Product Mappings
            CreateMap<Product, ProductDto>().ReverseMap();
            #endregion LeaveRequest

        }
    }
}
