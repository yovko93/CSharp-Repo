namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using SharedTrip.Data;
    using SharedTrip.Models;
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            var modelErrors = validator.ValidateUser(model);

            if (data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Redirect("/Users/Register");
            }

            var user = new User
            {
                Username = model.Username,
                Password = passwordHasher.HashPassword(model.Password),
                Email = model.Email
            };

            data.Users.Add(user);

            data.SaveChanges();

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            var hashedPassword = passwordHasher.HashPassword(model.Password);

            var userId = data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        public HttpResponse Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
