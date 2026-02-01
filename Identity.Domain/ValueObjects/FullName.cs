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
            // Validate firstName and lastName (e.g., not null or empty, valid characters, etc.)
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new InvalidFullNameException("First name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new InvalidFullNameException("Last name cannot be null or empty.");
            }
            FirstName = firstName;
            LastName = lastName;
        }

        // add a method to normalize the full name (e.g,trim spaces, add check regex to prevent invalid characters, etc.)

        private static string Normalize(string value)
        {
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
