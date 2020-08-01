using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.Services.Interfaces;

using PetStore.ViewModels.Product;
using PetStore.ViewModels.Product.InputModels;
using PetStore.ViewModels.Product.OutputModels;
using System.Collections.Generic;

namespace PetsStore.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return this.RedirectToAction("All");
        }
        [HttpGet]
        public IActionResult All()
        {
            var allProducts = productService.GetAll();

            ICollection<ListAllProductsViewModel> viewModels 
                = this.mapper.Map<List<ListAllProductsViewModel>>(allProducts);
            return View(viewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }
            AddProductInputServiceModel serviceModel =
                this.mapper.Map<AddProductInputServiceModel>(model);

            this.productService.AddProduct(serviceModel);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            ProductDetailsServiceModel serviceModel = this.productService.GetById(id);

            ProductDetailsViewModel viewModel = this.mapper.Map<ProductDetailsViewModel>(serviceModel);

            return this.View(viewModel);
        }
    }
}
