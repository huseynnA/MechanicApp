using DTO;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService,IProductService productService,IUserService userService)
        {
            _adminService = adminService;
            _productService= productService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("SignIn")]
        public IActionResult SignIn(AdminDTO adminDTO)
        {
            try
            {
                //ViewBag.Status=adminDTO.
                //   var res = _adminService.SignIn(adminDTO);
                return RedirectToAction("Index", adminDTO);
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred.Please try again", e);
            }
        }

        [HttpGet]
        [Route("AddProduct")]
        public IActionResult AddProduct() 
        {
            return View();
        }


      

        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetProducts(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null) 
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;
            //to save search text in input


            var res = _productService.GetFilter(page, pageSize, order, search);

            var allProductsCount = res.Count();
            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }
            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }


            ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
            ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;


            var pagedRs = new PagedResponseDTO<ProductDTO>(page, pageSize, res);

            return View(pagedRs);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers(int page = 1, int pageSize = 16, ProductSortOrder order = ProductSortOrder.NameAsc, string search = null) 
        {
            if (!string.IsNullOrEmpty(search))
                ViewBag.Search = search;
            //to save search text in input


            var res = _userService.GetFilter(page, pageSize, order, search);

            var allProductsCount = res.Count();
            ViewBag.HasPrevious = true;
            ViewBag.HasNext = true;

            if (page * pageSize >= allProductsCount)
            {
                ViewBag.HasNext = false;
            }
            if (page <= 1)
            {
                ViewBag.HasPrevious = false;
            }


            ViewBag.NameSort = order == ProductSortOrder.NameAsc ? ProductSortOrder.NameDesc : ProductSortOrder.NameAsc;
            ViewBag.PriceSort = order == ProductSortOrder.PriceAsc ? ProductSortOrder.PriceDesc : ProductSortOrder.PriceAsc;


            var pagedRs = new PagedResponseDTO<UserDTO>(page, pageSize, res);
            return View(pagedRs);
        }

        [HttpGet("User/Get/{id}")]
        public IActionResult Get(int id, string message = null, bool isSuccess = true)
        {
            if (!string.IsNullOrEmpty(message))
            {
                if (isSuccess)
                    ViewBag.Success = message;
                else
                    ViewBag.Error = message;
            }


            var res = _userService.Get(id);

            if (res == null)
            {
                ViewBag.Error = "Not Found!";
                return View();
            }
            return View(res);
        }

        [HttpPost]
        [Route("DeleteProduct")]
        public IActionResult DeleteProduct(int id) 
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductDTO productDTO) 
        {
            var res = _productService.Create(productDTO);
            return View();
        }

        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int id) 
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("EditUserPage")]
        public IActionResult EditUserPage(int id)
        {
            return View(id);
        }

        [HttpPost]
        [Route("EditUser")]
        public IActionResult EditUser(int id)
        {
            var res = _userService.Get(id);
            _userService.Update(res);
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //[Route("GetUsername")]
        //public IActionResult GetUsername(int id)
        //{
        //    var ent=_userService.Get(id);
        //    var res = ent.Name + ent.Surname;
        //    return RedirectToAction();
        //}
    }
    
}
