using Product_With_Images_Task.Models;
using Product_With_Images_Task.DAL;

namespace Product_With_Images_Task.BAL
{
    public class BAL_Product
    {
        private readonly DAL_Product _dalProduct;

        public BAL_Product(IConfiguration configuration)
        {
            _dalProduct = new DAL_Product(configuration);
        }

        public bool AddProduct(Product_Model product)
        {
            return _dalProduct.Add_Product(product);
        }

        public bool UpdateProduct(Product_Model product)
        {
            return _dalProduct.Update_Product(product);
        }

        public bool DeleteProduct(int Product_ID)
        {
            return _dalProduct.Delete_Product(Product_ID);
        }

        public List<Product_Model> GetAllProducts()
        {
            return _dalProduct.Get_All_Products();
        }

        public Product_Model GetProductById(int Product_ID)
        {
            return _dalProduct.Product_By_ID(Product_ID);
        }
    }
}
