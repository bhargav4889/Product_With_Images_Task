using Product_With_Images_Task.Models;
using System.Data.SqlClient;

namespace Product_With_Images_Task.DAL
{
    public class DAL_Auth : DAL_Connection
    {
        private readonly IConfiguration _Config;

        public DAL_Auth(IConfiguration configuration)
        {
            _Config = configuration;
        }



        public Auth_Model Auth_Login(Auth_Model auth)
        {
            SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_Config));

            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.CommandText = "UserAuth";

            sqlCommand.Parameters.AddWithValue("@User_Email", auth.User_Email);

            sqlCommand.Parameters.AddWithValue("@User_Pass", auth.User_Password);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            Auth_Model auth_info = new Auth_Model();

            while (sqlDataReader.Read())
            {
                auth_info.User_ID = Convert.ToInt32(sqlDataReader.GetInt32(0));

                auth_info.User_Name = sqlDataReader.GetString(1);

                auth_info.User_Email = sqlDataReader.GetString(2);

                auth_info.User_Password = sqlDataReader.GetString(3);

            }

            return auth_info;

        }
    }
}
