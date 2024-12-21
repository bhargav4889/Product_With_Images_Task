namespace Product_With_Images_Task.Auth
{
    public class Stored_Details
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Stored_Details(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? User_Name()
        {
            return _httpContextAccessor.HttpContext.Session.GetString("User_Name");
        }
    }
}
