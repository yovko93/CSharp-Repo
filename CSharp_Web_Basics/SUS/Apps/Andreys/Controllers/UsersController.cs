using Andreys.Services;
using Andreys.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormModel model)
        {
            var userId = this.usersService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormModel model)
        {
            if (string.IsNullOrEmpty(model.Username) || model.Username.Length < 4 || model.Username.Length > 10)
            {
                return this.Error("Username is required and should be between 5 and 20 characters.");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("Username already taken.");
            }

            if (string.IsNullOrEmpty(model.Email) || !new EmailAddressAttribute().IsValid(model.Email))
            {
                return this.Error("Invalid email address.");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("Email already taken.");
            }

            if (string.IsNullOrEmpty(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 charaters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match.");
            }

            this.usersService.CreateUser(model.Username, model.Email, model.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can logout.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
