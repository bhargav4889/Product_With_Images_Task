using System.ComponentModel.DataAnnotations;

namespace Product_With_Images_Task.Models
{
    public class Product_Model
    {
        public int Product_ID { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        public string Product_Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product SKU")]
        public string Product_SKU { get; set; }

        [Required(ErrorMessage = "Please Enter Product Price")]
        public decimal Product_Price { get; set; }
        public bool Product_IsActive { get; set; }

      
        public IFormFile? Product_Image { get; set; }

        public string Product_Image_Path { get; set; }

    }
}
