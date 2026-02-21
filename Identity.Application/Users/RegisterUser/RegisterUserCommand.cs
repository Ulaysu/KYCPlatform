using BuildingBlocks.Application.Abstractions.Messaging;
using BuildingBlocks.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Identity.Application.Users.RegisterUser
{
    public sealed record RegisterUserCommand
    (
        string FirstName,
        string LastName,
        string Email,
        string Password


    ) : ICommand<Result<Guid>>;
    

    
}
