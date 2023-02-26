using ArtShop.Abstraction;
using ArtShop.Entities;
using ArtShop.Models.Category;
using ArtShop.Models.Designer;
using ArtShop.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtShop.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IDesignerService _designerService;

        public ProductController(IProductService productService, ICategoryService categoryService, IDesignerService designerService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._designerService = designerService;
        }

        // GET: ProductController
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringDesignerName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringDesignerName)
               .Select(product => new ProductIndexVM
               {
                   Id = product.Id,
                   Name = product.Name,
                   CategoryId = product.CategoryId,
                   CategoryName = product.Category.CategoryName,
                   DesignerId = product.DesignerId,
                   DesignerName = product.Designer.DesignerName,
                   Description = product.Description,
                   Photo = product.Photo,
                   Price = product.Price,
                   Quantity = product.Quantity,
                   Discount = product.Discount

               }).ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsVM product = new ProductDetailsVM()
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                DesignerId = item.DesignerId,
                DesignerName = item.Designer.DesignerName,
                Description = item.Description,
                Photo = item.Photo,
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount
            };
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Designers = _designerService.GetDesigners().Select(x => new DesignerPairVM()
            {
                Id = x.Id,
                Name = x.DesignerName
            }).ToList();
            product.Categories = _categoryService.GetCategories().Select(x => new CategoryPairVM()
            {
                Id = x.Id,
                Name = x.CategoryName
            }).ToList();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.Name, product.CategoryId,
                                                       product.DesignerId, product.Description,
                                                       product.Photo, product.Price,
                                                       product.Quantity, product.Discount);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductEditVM updatedProduct = new ProductEditVM()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                DesignerId = product.DesignerId,
                Description = product.Description,
                Photo = product.Photo,
                Price = product.Price,
                Quantity = product.Quantity,
                Discount = product.Discount
            };
            updatedProduct.Designers = _designerService.GetDesigners().Select(b => new DesignerPairVM()
            {
                Id = b.Id,
                Name = b.DesignerName
            }).ToList();
            updatedProduct.Categories = _categoryService.GetCategories().Select(c => new CategoryPairVM()
            {
                Id = c.Id,
                Name = c.CategoryName
            }).ToList();
            return View(updatedProduct);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM product)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.Update(id, product.Name,
                    product.CategoryId, product.DesignerId,product.Description, product.Photo,
                    product.Price, product.Quantity, product.Discount);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDeleteVM product = new ProductDeleteVM()
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                DesignerId = item.DesignerId,
                Description = item.Description,
                Photo = item.Photo,
                Price = item.Price,
                Quantity = item.Quantity,
                Discount = item.Discount
            };
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
