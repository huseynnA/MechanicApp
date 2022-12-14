using AutoMapper;
using DataAccess.Entites;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<CartDTO, Cart>();            
            CreateMap<Cart, CartDTO>()
                .ForMember(dst => dst.ProductName,x=>x.MapFrom(src=>src.Product.Name))
                .ForMember(dst => dst.ProductImgPath,x=>x.MapFrom(src=>src.Product.ImgPath))
                .ForMember(dst => dst.ProductPrice,x=>x.MapFrom(src=>src.Product.Price));

            CreateMap<AdminDTO, Admin>();
            CreateMap<Admin, AdminDTO>();
        }
    }
}
