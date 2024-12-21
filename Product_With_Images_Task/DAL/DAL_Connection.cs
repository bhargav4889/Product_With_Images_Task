namespace Product_With_Images_Task.DAL
{
    public class DAL_Connection
    {
        public string GetDatabaseConnection(IConfiguration configuration)
        {
            return configuration.GetConnectionString("DBConnection");
        }
    }
}
