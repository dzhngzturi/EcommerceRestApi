using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.ProductType
{
    public class CreateProductTypeDto : IProductTypeDto
    {
        public string Name { get; set; }
    }
}
