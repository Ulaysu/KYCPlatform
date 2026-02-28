using BuildingBlocks.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Identity.Application.Users.RegisterUser
{
    
        public sealed class RegisterUserCommandValidator
        {
            private static readonly Regex EmailRegex = new(
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

            public Error? Validate(RegisterUserCommand command)
            {
                if (string.IsNullOrWhiteSpace(command.FirstName))
                {
                    return new Error(
                        "User.FirstName.Required",
                        "First name is required.",
                        ErrorType.Validation);
                }

                if (command.FirstName.Trim().Length > 100)
                {
                    return new Error(
                        "User.FirstName.TooLong",
                        "First name cannot exceed 100 characters.",
                        ErrorType.Validation);
                }

                if (string.IsNullOrWhiteSpace(command.LastName))
                {
                    return new Error(
                        "User.LastName.Required",
                        "Last name is required.",
                        ErrorType.Validation);
                }

                if (command.LastName.Trim().Length > 100)
                {
                    return new Error(
                        "User.LastName.TooLong",
                        "Last name cannot exceed 100 characters.",
                        ErrorType.Validation);
                }

                if (string.IsNullOrWhiteSpace(command.Email))
                {
                    return new Error(
                        "User.Email.Required",
                        "Email is required.",
                        ErrorType.Validation);
                }

                if (!EmailRegex.IsMatch(command.Email.Trim()))
                {
                    return new Error(
                        "User.Email.Invalid",
                        "Email format is invalid.",
                        ErrorType.Validation);
                }

                if (string.IsNullOrWhiteSpace(command.Password))
                {
                    return new Error(
                        "User.Password.Required",
                        "Password is required.",
                        ErrorType.Validation);
                }

                if (command.Password.Length < 8)
                {
                    return new Error(
                        "User.Password.TooShort",
                        "Password must be at least 8 characters.",
                        ErrorType.Validation);
                }

                var hasUpper = command.Password.Any(char.IsUpper);
                var hasLower = command.Password.Any(char.IsLower);
                var hasDigit = command.Password.Any(char.IsDigit);

                if (!hasUpper || !hasLower || !hasDigit)
                {
                    return new Error(
                        "User.Password.Weak",
                        "Password must include at least one uppercase letter, one lowercase letter, and one digit.",
                        ErrorType.Validation);
                }

                return null;
            }
        }
    }


