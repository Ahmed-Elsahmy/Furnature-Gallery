using ITI_Project.BLL.ModelVM;
using ITI_Project.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ITI_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Read()
        {
            var result = productService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new CreateProductVM();
            return View(product);
        }

        [HttpPost]
        public IActionResult Create(CreateProductVM product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var x = productService.Create(product);
                    return RedirectToAction("Read", "Product");
                }
            }
            catch (Exception ex)
            { 
                return View(product);
            }

            return View(product);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = productService.GetByProductId(id);
            return View(data);
        }


        [HttpPost]
        public IActionResult Delete(GetProductVM product)
        {
            try
            {
                productService.Delete(product.Id);
                return RedirectToAction("Read", "Product");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(product);
            }

        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var data = productService.GetByProductId(id);

            return View(data);
        }


        [HttpPost]
        public IActionResult Update(UpdateProductVM product)
        {
            try
            {
                if (ModelState.IsValid)
                {


                    productService.Update(product);
                    return RedirectToAction("Read", "Employee");
                }
            }
            catch (Exception ex)
            {
                return View(product);
            }

            return View(product);

        }
    }
}
