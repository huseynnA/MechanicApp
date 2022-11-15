using AutoMapper;
using DataAccess;
using DataAccess.Entites;
using DTO;
using Helper;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AdminService:BaseService<AdminDTO,Admin,AdminDTO>,IAdminService
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public AdminService(IUserService userService,IProductService productService,AppDbContext appDbContext,IMapper imapper):base(appDbContext,imapper)
        {
            _userService = userService;
            _productService= productService;
        }

   

        public AdminDTO SignIn(AdminDTO model)
        {

            var res = _db.Admins.Where(x => x.Username == model.Username);

            if (res.Count() == 1)
            {
                var user = res.FirstOrDefault();
                var hash = Crypto.GenerateSHA256Hash(model.Password, user.Salt);

                if (hash == user.PasswordHash)
                {
                    var dto = _mapper.Map<Admin, AdminDTO>(res.First());
                    return dto;
                }
                else
                {
                    throw new Exception("Wrong password!");
                }
            }
            else
            {
                throw new Exception("Admin not found");
            }

        }

       

        public ProductDTO CreateProduct(ProductDTO productDTO) 
        {
            var res = _productService.Create(productDTO);
            return res;
        }
    }
}
