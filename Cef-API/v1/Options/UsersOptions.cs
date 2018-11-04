namespace Cef_API.v1.Options
{
    public class UsersOptions
    {
        public Users[] Users { get; set; }
    }

    public class Users
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
