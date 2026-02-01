using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Aggregates.UserAggregate
{
    public enum UserStatus
    {
        Pending = 1,
        Active = 2,
        Suspended = 3,
        Deactivated = 4
    }
}
