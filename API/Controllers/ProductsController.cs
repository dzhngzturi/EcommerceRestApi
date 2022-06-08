using AutoMapper;
using Ecommerce.Application.Contracts.Persistence;
using Ecommerce.Application.Contracts.Persistence.Services;
using Ecommerce.Application.Contracts.Persistence.Specification;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.DTOs.ProductType;
using Ecommerce.Application.Errors;
using Ecommerce.Application.Features.ProductBrands.Requests.Commands;
using Ecommerce.Application.Features.ProductBrands.Requests.Queries;
using Ecommerce.Application.Features.Products.Requests.Commands;
using Ecommerce.Application.Features.Products.Requests.Queries;
using Ecommerce.Application.Features.ProductTypes.Requests.Commands;
using Ecommerce.Application.Features.ProductTypes.Requests.Queries;
using Ecommerce.Application.Profiles;
using Ecommerce.Application.Responses;
using Ecommerce.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPhotoService _photoService;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator,
            IUnitOfWork unitOfWork,
            IPhotoService photoService, 
            IMapper mapper)
        {
            _mediator = mediator;
            _unitOfWork = unitOfWork;
            _photoService = photoService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        {
            var products = await _mediator.Send(new GetProductListRequest(productParams));
            return Ok(products);
        }

        // GET: api/Products/2
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse), (404))]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductWithDetailsRequest { Id = id });
            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(product);
        }

        //POST api/Products
        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public async Task<ActionResult<ProductToReturnDto>> Post([FromBody] CreateProductDto createProductDto)
        {
            var command = new CreateProductCommand { CreateProductDto = createProductDto };
            await _mediator.Send(command);
            return NoContent();
        }

        //PUT api/Products/2
        [HttpPut("{id}")]
        [Authorize( Roles ="Administrator")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var command = new UpdateProductCommand { Id = id, UpdateProductDto = updateProductDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize("Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}/photo")]
        [Authorize("Administrator")]
        public async Task<ActionResult<ProductToReturnDto>> AddProductPhoto (int id , [FromForm] ProductPhotoDto photoDto)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

            if (photoDto.Photo.Length > 0)
            {
                var photo = await _photoService.SaveToDiskAsync(photoDto.Photo);

                if (photo != null)
                {
                    product.AddPhoto(photo.PictureUrl, photo.FileName);
                   await _unitOfWork.Repository<Product>().Update(product);
                    var result = await _unitOfWork.Complete();
                    if (result <= 0) return BadRequest(new ApiResponse(400, "Problem adding photo product"));
                }
                else
                {
                    return BadRequest(new ApiResponse(400, "problem saving photo to disk"));
                }
            }
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpDelete("{id}/photo")]
        [Authorize("Administrator")]
        public async Task<ActionResult> DeletePhoto(int id)
        {
            try
            {
               var command = new DeletePhotoCommand { Id = id};
                await _mediator.Send(command);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // api/ProductsController/types
        [HttpGet("types")]
        
        public async Task<ActionResult<ProductTypeDto>> GetTypes()
        {
            var productType = await _mediator.Send(new GetProductTypesRequest());
            return Ok(productType);
        }

        [HttpGet("types/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse), (404))]
        public async Task<ActionResult<ProductTypeDto>> GetTypes(int id)
        {
            var productType = await _mediator.Send(new GetProductTypesWithDetailsRequest { Id = id});
            return Ok(productType);
        }

        [HttpPost("types")]
        [Authorize("Administrator")]
        
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductTypeDto createProductTypeDto)
        {
            var command = new CreateProductTyoesCommand { CreateProductTypeDto = createProductTypeDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("types/{id}")]
        [Authorize("Administrator")]

        public async Task<ActionResult> Put([FromBody] UpdateProductTypeDto productTypeDto)
        {
            var command = new UpdateProductTypesCoammand { ProductTypeDto = productTypeDto};
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("types/{id}")]
        [Authorize("Administrator")]

        public async Task<ActionResult> DeleteProductType(int id)
        {
            var command = new DeleteProductTypesCoammand { Id = id };
            await _mediator.Send(command);
            return NoContent();

        }


        // api/ProductsController/brands
        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrandDto>> GetBrands()
        {
            var productBrnads = await _mediator.Send(new GetProductBrandsRequest());
            return Ok(productBrnads);
        }
        [HttpGet("brands/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ApiResponse), (404))]
        public async Task<ActionResult<ProductBrandDto>> GetBrands(int id)
        {
            var productBrnads = await _mediator.Send(new GetProductBrandsWithDetailsRequest {Id = id});
            return Ok(productBrnads);
        }

        [HttpPost("brands")]
        [Authorize("Administrator")]

        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductBrandDto productBrandDto)
        {
            var command = new CreateProductBrandCommand {  CreateProductBrandDto = productBrandDto};
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("brands/id")]
        [Authorize("Administrator")]

        public async Task<ActionResult> Put([FromBody] UpdateProductBrandDto productBrandDto)
        {
            var command = new UpdateProductBrandCommand { UpdateProductBrandDto = productBrandDto};
            var response = await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("brands/id")]
        [Authorize("Administrator")]

        public async Task<ActionResult> DeleteProductBrand(int id)
        {
            var command = new DeleteProductBrandCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
