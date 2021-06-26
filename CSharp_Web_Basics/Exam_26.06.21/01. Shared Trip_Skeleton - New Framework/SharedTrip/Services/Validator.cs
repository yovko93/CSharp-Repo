namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using SharedTrip.ViewModels.Users;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Validator : IValidator
    {
        private const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public ICollection<string> ValidateUser(RegisterInputModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < 5 || model.Username.Length > 20)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < 6 || model.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between 6 and 20 characters long.");
            }
            
            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(AddTripFormModel model)
        {
            var errors = new List<string>();

            if (model.Id == null)
            {
                errors.Add("Id cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errors.Add($"EndPoint cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add($"EndPoint cannot be null.");
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                errors.Add($"Seats must be between 2 and 6");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 80)
            {
                errors.Add($"Description cannot be empty or more than 80 characters.");
            }

            if (!DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                errors.Add("Invalid departure time. Please use dd.MM.yyyy HH:mm format.");
            }

            return errors;
        }
    }
}
