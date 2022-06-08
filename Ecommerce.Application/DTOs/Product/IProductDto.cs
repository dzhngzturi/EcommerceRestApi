using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.DTOs.Product
{
    public interface IProductDto
    {
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }

    }
}
