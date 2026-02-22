using BuildingBlocks.Application.Abstractions.Events;
using BuildingBlocks.Application.Abstractions.Messaging;
using BuildingBlocks.Application.Abstractions.Persistence;
using BuildingBlocks.Application.Common;
using Identity.Domain.Aggregates.UserAggregate;
using Identity.Domain.Repositories;
using Identity.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Identity.Application.Users.RegisterUser
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, Result<Guid>>
    {
        private readonly IIdentityRepository _repository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IEventPublish _eventPublisher;

        public RegisterUserCommandHandler( 
            IIdentityRepository repository, IUnitOfWork unitOfWork, IEventPublish eventPublisher)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        public async Task<Result<Guid>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var email = Email.Create(command.Email);

            // Check if user already exists
            var existingUser = await _repository.GetByEmailAsync(email.Value, cancellationToken);
            if (existingUser is not null) 
            {
                return Result<Guid>.Failure(
                    new Error("User.Email.Exists", "User with this Email already exists", ErrorType.Conflict));
            }

            var fullName = FullName.Create(command.FirstName, command.LastName);

            // TODO: Role should come from an explicit registration workflow/command contract.
            var user = User.Register(email, fullName, userRole.EmployerAdmin);

            await _repository.AddAsync(user, cancellationToken);    
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result<Guid>.Success(user.Id);





        }

    }
}
