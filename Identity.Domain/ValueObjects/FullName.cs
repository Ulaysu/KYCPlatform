using BuildingBlocks.Domain.Common;
using Identity.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Identity.Domain.ValueObjects
{
    // TODO: Implement FullName value object

    public sealed class FullName : ValueObject
    {
        public string FirstName { get; }
        public string LastName { get; }
        private FullName(string firstName, string lastName)
        {
            
            FirstName = firstName;
            LastName = lastName;
        }

        public static FullName Create(string firstName, string lastName)
        {
            var normalizedFirstName = Normalize(firstName);
            var normalizedLastName = Normalize(lastName);

            return new FullName(normalizedFirstName, normalizedFirstName);
        }
        private static string Normalize(string value)
        {
            // Validate (e.g., not null or empty, valid characters, etc.)
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidFullNameException("Name cannot be null or empty.");
            }
           
            value = value.Trim();

            if (!Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                throw new InvalidFullNameException("Name contains invalid characters.");

            return value;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
