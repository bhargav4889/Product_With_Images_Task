using Product_With_Images_Task.Models;
using System.Data.SqlClient;

namespace Product_With_Images_Task.DAL
{
    public class DAL_User : DAL_Connection
    {
        private readonly IConfiguration _configuration;

        public DAL_User(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Add_User(User_Model user)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "InsertUser";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@User_Name", user.User_Name);

                sqlCommand.Parameters.AddWithValue("@User_Email", user.User_Email);

                sqlCommand.Parameters.AddWithValue("@User_Phone", user.User_Phone);

                sqlCommand.Parameters.AddWithValue("@User_Password", user.User_Password);

                int isInserted = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isInserted > 0;


            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public bool Update_User(User_Model user)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "UpdateUser";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@User_ID", user.User_ID);


                sqlCommand.Parameters.AddWithValue("@User_Name", user.User_Name);

                sqlCommand.Parameters.AddWithValue("@User_Email", user.User_Email);

                sqlCommand.Parameters.AddWithValue("@User_Phone", user.User_Phone);

                sqlCommand.Parameters.AddWithValue("@User_Password", user.User_Password);

                int isUpdate = sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();

                return isUpdate > 0;


            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public bool Delete_User(int User_ID)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "DeleteUser";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@User_ID", User_ID);

                int isDelete = sqlCommand.ExecuteNonQuery();

                return isDelete > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<User_Model> Get_All_Users()
        {
            List<User_Model> users = new List<User_Model>();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "SelectAllUsers";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    User_Model user = new User_Model
                    {
                        User_ID = Convert.ToInt32(reader["User_ID"].ToString()),
                        User_Name = reader["User_Name"].ToString(),
                        User_Email = reader["User_Email"].ToString(),
                        User_Phone = reader["User_Phone"].ToString(),

                    };

                    users.Add(user);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

            return users;
        }

        public User_Model User_By_ID(int User_ID)
        {

            User_Model user = new User_Model();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(GetDatabaseConnection(_configuration));

                sqlConnection.Open();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "AUTH_EMPLOYEE_BY_ID";

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@User_ID", User_ID);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {


                    user.User_ID = Convert.ToInt32(reader["User_ID"].ToString());
                    user.User_Name = reader["User_Name"].ToString();
                    user.User_Email = reader["User_Email"].ToString();
                    user.User_Phone = reader["User_Phone"].ToString();


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return user;
        }
    }
}
