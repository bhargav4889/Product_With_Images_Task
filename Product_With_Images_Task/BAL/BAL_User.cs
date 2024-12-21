using Product_With_Images_Task.DAL;
using Product_With_Images_Task.Models;

namespace Product_With_Images_Task.BAL
{
    public class BAL_User
    {
        private readonly DAL_User dal_User;

        public BAL_User(IConfiguration configuration)
        {
            dal_User = new DAL_User(configuration);
        }


        public bool Add_User(User_Model user)
        {
            bool isSuccessInserted = dal_User.Add_User(user);

            return isSuccessInserted;
        }

        public bool Update_User(User_Model user)
        {
            bool isSuccessUpdated = dal_User.Update_User(user);

            return isSuccessUpdated;
        }

        public bool Delete_User(int User_ID)
        {
            bool isSuccessDelete = dal_User.Delete_User(User_ID);

            return isSuccessDelete;
        }

        public List<User_Model> Get_Users()
        {
            List<User_Model> users = dal_User.Get_All_Users();

            return users;
        }

        public User_Model Get_User_By_ID(int User_ID)
        {
            User_Model user = dal_User.User_By_ID(User_ID);

            return user;
        }

    }
}
