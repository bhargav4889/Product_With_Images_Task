using Microsoft.AspNetCore.Mvc;
using Product_With_Images_Task.BAL;
using Product_With_Images_Task.Models;

namespace Product_With_Images_Task.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly BAL_Auth bal_Auth;

        private readonly BAL_User bal_User;

        public AuthController(IConfiguration configuration)
        {
            bal_Auth = new BAL_Auth(configuration);
            bal_User = new BAL_User(configuration);
        }


        public IActionResult Register()
        {
            return  View();
        }


        [HttpPost]
        public IActionResult Register(User_Model auth_user)
        {
            bool isInstered = bal_User.Add_User(auth_user);

            if (isInstered)
            {
                TempData["AuthRegisterSuccessMsg"] = "Success: Account registered successfully! Please login.";
                return RedirectToAction("Login");
            }

            ViewBag.InsertFaliMsg = "Error : Fail to Registion of User";

            return View(auth_user);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Auth_Model auth)
        {

            Auth_Model authModel = bal_Auth.Auth_Login(auth);

            if (authModel != null && authModel.User_ID > 0 && !string.IsNullOrEmpty(authModel.User_Name))
            {
                HttpContext.Session.SetInt32("User_ID", authModel.User_ID);
                HttpContext.Session.SetString("User_Name", authModel.User_Name);
                HttpContext.Session.SetString("User_Email", authModel.User_Email);

                return RedirectToAction("Index", "Home");
            }


            ViewBag.FailAuthMsg = "Error : Invalid Username or Password !!";

            return View(auth);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
