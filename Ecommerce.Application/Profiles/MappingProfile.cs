using AutoMapper;
using Ecommerce.Application.DTOs.Basket;
using Ecommerce.Application.DTOs.Order;
using Ecommerce.Application.DTOs.Product;
using Ecommerce.Application.DTOs.ProductBrand;
using Ecommerce.Application.DTOs.ProductType;
using Ecommerce.Domain;
using Ecommerce.Domain.OrderAggregate;


namespace Ecommerce.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
        //    CreateMap<Product, ProductToReturnDto>()

            CreateMap<Photo, PhotoToReturnDto>()
                .ForMember(d => d.PictureUrl,
                    o => o.MapFrom<PhotoUrlResolver>());
            #endregion

            #region ProductBrand
            CreateMap<ProductBrand, ProductBrandDto>().ReverseMap();
            CreateMap<ProductBrand, CreateProductBrandDto>().ReverseMap();
            CreateMap<ProductBrand, UpdateProductBrandDto>().ReverseMap();
            #endregion ProductBrand

            #region ProductType
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductType, CreateProductTypeDto>().ReverseMap();
            CreateMap<ProductType, UpdateProductTypeDto>().ReverseMap();
            #endregion

            #region Basket
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            #endregion

            #region Order
            CreateMap<AddressDto, Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            #endregion

            #region OrderItem
            CreateMap<OrderItem, OrderItemDto>()
              .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
              .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
              .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
              .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
            #endregion
        }
    }
}
