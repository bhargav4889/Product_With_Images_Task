using Product_With_Images_Task.DAL;
using Product_With_Images_Task.Models;

namespace Product_With_Images_Task.BAL
{
    public class BAL_Auth
    {
        private readonly DAL_Auth dal_Auth;

        public BAL_Auth(IConfiguration configuration)
        {
            dal_Auth = new DAL_Auth(configuration);
        }


        public Auth_Model Auth_Login(Auth_Model auth)
        {
            Auth_Model authDetails = dal_Auth.Auth_Login(auth);

            return authDetails;
        }


    }
}
