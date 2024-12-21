using Microsoft.AspNetCore.Mvc;
using Product_With_Images_Task.Models;
using Product_With_Images_Task.BAL;
using Product_With_Images_Task.Auth;

namespace Product_With_Images_Task.Controllers
{
    [Route("[controller]/[action]")]
    [CheckAuth]
    public class ProductController : Controller
    {
        private readonly BAL_Product _balProduct;

        public ProductController(IConfiguration configuration)
        {
            _balProduct = new BAL_Product(configuration);
        }

        public IActionResult Products()
        {
            var products = _balProduct.GetAllProducts();
            return View(products);
        }


        public IActionResult Add_Product()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_Product(Product_Model product)
        {

            bool isAdded = _balProduct.AddProduct(product);
            if (isAdded)
            {
                TempData["SuccessMessage"] = "Product added successfully!";
                return RedirectToAction("Products", "Product");
            }



            TempData["ErrorMessage"] = "Failed to add product.";
            return View(product);
        }

        [HttpGet]
        public IActionResult Edit_Product(int Product_ID)
        {
            var product = _balProduct.GetProductById(Product_ID);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit_Product(Product_Model product)
        {

            // If a new image is uploaded, handle it, otherwise retain the old image path
            if (product.Product_Image != null)
            {
                string newImagePath = _balProduct.SaveProductImage(product.Product_Image, product.Product_Name);

                // Optionally, delete the old image from the server
                if (!string.IsNullOrEmpty(product.Product_Image_Path))
                {
                    string oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", product.Product_Image_Path.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Set the new image path in the model
                product.Product_Image_Path = newImagePath;
            }

            bool isUpdated = _balProduct.UpdateProduct(product);
            if (isUpdated)
            {
                TempData["SuccessMessage"] = "Product updated successfully!";
                return RedirectToAction("Products");
            }

            TempData["ErrorMessage"] = "Failed to update product.";

            return View(product);
        }






        public IActionResult Delete_Product(int Product_ID)
        {
            bool isDeleted = _balProduct.DeleteProduct(Product_ID);
            if (isDeleted)
            {
                TempData["SuccessMessage"] = "Product deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete product.";
            }
            return RedirectToAction("Products");
        }
    }
}


