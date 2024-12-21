using Product_With_Images_Task.Models;
using System.Data.SqlClient;

namespace Product_With_Images_Task.DAL
{
    public class DAL_Product : DAL_Connection
    {
        private readonly IConfiguration _configuration;

        public DAL_Product(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Add_Product(Product_Model product)
        {
            try
            {
                // Save the uploaded image to the specified folder
                string uniqueFileName = SaveProductImage(product.Product_Image, product.Product_Name);

                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "InsertProduct"; // Ensure you create this stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Product_Name", product.Product_Name);
                sqlCommand.Parameters.AddWithValue("@Product_SKU", product.Product_SKU);
                sqlCommand.Parameters.AddWithValue("@Product_Price", product.Product_Price);
                sqlCommand.Parameters.AddWithValue("@Product_Status", product.Product_IsActive);
                sqlCommand.Parameters.AddWithValue("@Product_Image_Path", uniqueFileName);
                

                int isInserted = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isInserted > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool Update_Product(Product_Model product)
        {
            try
            {
                string uniqueFileName = string.Empty;

                // Update image if a new one is uploaded
                if (product.Product_Image != null)
                {
                    uniqueFileName = SaveProductImage(product.Product_Image, product.Product_Name);
                }

                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "UpdateProduct"; // Ensure you create this stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Product_ID", product.Product_ID);
                sqlCommand.Parameters.AddWithValue("@Product_Name", product.Product_Name);
                sqlCommand.Parameters.AddWithValue("@Product_SKU", product.Product_SKU);
                sqlCommand.Parameters.AddWithValue("@Product_Price", product.Product_Price);
                sqlCommand.Parameters.AddWithValue("@Product_Status", product.Product_IsActive);

                if (!string.IsNullOrEmpty(uniqueFileName))
                {
                    sqlCommand.Parameters.AddWithValue("@Product_Image_Path", uniqueFileName);
                }

                int isUpdated = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isUpdated > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool Delete_Product(int Product_ID)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "DeleteProduct"; // Ensure you create this stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Product_ID", Product_ID);

                int isDeleted = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isDeleted > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public List<Product_Model> Get_All_Products()
        {
            List<Product_Model> products = new List<Product_Model>();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "SelectAllProducts"; // Ensure you create this stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Product_Model product = new Product_Model
                    {
                        Product_ID = Convert.ToInt32(reader["Product_ID"]),
                        Product_Name = reader["Product_Name"].ToString(),
                        Product_SKU = reader["Product_SKU"].ToString(),
                        Product_Price = Convert.ToDecimal(reader["Product_Price"]),
                        Product_IsActive = Convert.ToBoolean(reader["Product_Status"]),
                        Product_Image_Path = reader["Product_Img_Path"].ToString()
                    };

                    products.Add(product);
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return products;
        }

        public Product_Model Product_By_ID(int Product_ID)
        {
            Product_Model product = new Product_Model();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "SelectProductByID"; // Ensure you create this stored procedure
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Product_ID", Product_ID);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    product.Product_ID = Convert.ToInt32(reader["Product_ID"]);
                    product.Product_Name = reader["Product_Name"].ToString();
                    product.Product_SKU = reader["Product_SKU"].ToString();
                    product.Product_Price = Convert.ToDecimal(reader["Product_Price"]);
                    product.Product_IsActive = Convert.ToBoolean(reader["Product_Status"]);
                    product.Product_Image_Path = reader["Product_Image_Path"].ToString();
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return product;
        }

        private string SaveProductImage(IFormFile file, string productName)
        {
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/product-img");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            string uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmss}-{productName}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(uploadPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"/uploads/product-img/{uniqueFileName}";
        }
    }
}
