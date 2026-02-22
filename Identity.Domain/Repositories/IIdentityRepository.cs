using Identity.Domain.Aggregates.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Domain.Repositories
{
    public interface IIdentityRepository
    {
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task AddAsync(User user, CancellationToken cancellationToken);
    }
}
