using BuildingBlocks.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using BuildingBlocks.Domain.Exceptions;
using Identity.Domain.Exceptions;

namespace Identity.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public string Value { get; private set; }

        private Email( string value) 
        { 
            Value = value;
        }

        public static Email Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidEmailException("Email cannot be empty.");

            value = value.Trim().ToLowerInvariant();

            if (!IsValid(value))
                throw new InvalidEmailException("Invalid email format.");

            return new Email(value);
        }

        private static bool IsValid(string email)
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase
            );
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
