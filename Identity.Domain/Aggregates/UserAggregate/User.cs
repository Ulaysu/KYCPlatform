using BuildingBlocks.Domain.Common;
using Identity.Domain.Events;
using Identity.Domain.Exceptions;
using Identity.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Aggregates.UserAggregate
{
    public sealed class User : AggregateRoot
    {
        public Email Email { get; private set; }

        public FullName FullName { get; private set; }

        public UserStatus Status { get; private set; }

        public userRole Role { get; private set; }

        public User(Email email, FullName fullName, UserStatus status, userRole role)
        {
            Email = email;
            FullName = fullName;
            Status = UserStatus.Pending;
            Role = role;

            AddDomainEvent(new UserRegisteredDomainEvent(Id, Email.Value));
        }

        public static User Register(Email email, FullName fullName, userRole role)
        {
            if (role == userRole.InternalAdmin)
            {
                throw new InvalidUserRoleException("Cannot register an Internal Admin user.");
            }
            return new User(email, fullName, UserStatus.Pending, role);
        }

        public void Activate()
        {
            if (Status != UserStatus.Pending)
            {
                throw new InvalidUserStateException("Only pending users can be activated.");
            }
            Status = UserStatus.Active;
        }

        public void Suspend()
        {
            if (Status != UserStatus.Active)
            {
                throw new InvalidUserStateException("Only active users can be suspended.");
            }
            Status = UserStatus.Suspended;
        }

        public void Deactivate()
        {
            if (Status == UserStatus.Deactivated)
            {
                throw new InvalidUserStateException("User is already deactivated.");
            }
            Status = UserStatus.Deactivated;
        }
    }
}