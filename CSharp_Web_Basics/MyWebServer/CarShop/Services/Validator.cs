using CarShop.ViewModels.Cars;
using CarShop.ViewModels.Issues;
using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CarShop.Services
{
    public class Validator : IValidator
    {
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string CarPlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";

        public ICollection<string> ValidateCar(AddCarFormModel car)
        {
            var errors = new List<string>();

            if (car.Model == null || car.Model.Length < 5 || car.Model.Length > 20)
            {
                errors.Add($"Model '{car.Model}' is not valid. It must be between 5 and 20 characters long.");
            }

            if (car.Year < 1900 || car.Year > 2100)
            {
                errors.Add($"Year '{car.Year}' is not valid. It must be between 1900 and 2100.");
            }

            if (car.Image == null || !Uri.IsWellFormedUriString(car.Image, UriKind.Absolute))
            {
                errors.Add($"Image '{car.Image}' is not valid. It must be a valid URL.");
            }

            if (car.PlateNumber == null || !Regex.IsMatch(car.PlateNumber, CarPlateNumberRegularExpression))
            {
                errors.Add($"Plate number '{car.PlateNumber}' is not valid. It should be in 'XX0000XX' format.");
            }

            return errors;
        }

        public ICollection<string> ValidateIssue(AddIssueFormModel issue)
        {
            var errors = new List<string>();

            if (issue.CarId == null)
            {
                errors.Add($"Car ID cannot be empty.");
            }

            if (issue.Description == null || issue.Description.Length < 5)
            {
                errors.Add($"Description '{issue.Description}' is not valid. It must have more than 4 characters.");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterInputFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < 4 || user.Username.Length > 20)
            {
                errors.Add($"Username '{user.Username}' is not valid. It must be between 4 and 20 characters long.");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not a valid e-mail address.");
            }

            if (user.Password == null || user.Password.Length < 5 || user.Password.Length > 20)
            {
                errors.Add($"The provided password is not valid. It must be between 5 and 20 characters long.");
            }

            if (user.Password != null && user.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            if (user.UserType != "Client" && user.UserType != "Mechanic")
            {
                errors.Add($"The user can be either a 'Client' or a 'Mechanic'.");
            }

            return errors;
        }
    }
}
