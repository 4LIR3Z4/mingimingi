﻿using LanguageLearning.Core.Application.Common.Behaviors;
using LanguageLearning.Core.Application.Common.Framework;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Commands;
using LanguageLearning.Core.Application.Common.Framework.MediatorWrappers.Queries;
using LanguageLearning.Core.Application.UserProfiles.Commands;
using LanguageLearning.Core.Application.UserProfiles.Commands.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Core.Application.Common.Extensions;
public static class DependencyInjection
{
    public static void InitApplication(this IServiceCollection services)
    {
        services.AddSingleton<IDomainEventDispatcher>(sp =>
        {
            var dispatcher = new DomainEventDispatcher();
            //var emailService = sp.GetRequiredService<IEmailService>();

            //dispatcher.RegisterHandler<ProfileCreatedEvent>(async (domainEvent, cancellationToken) =>
            //{
            //    var handler = new ProfileCreatedEmailHandler(emailService);
            //    await handler.Handle(domainEvent, cancellationToken);
            //});
            return (IDomainEventDispatcher)dispatcher;
        });

        services.AddTransient<ICommandHandler<CreateUserProfileCommand, CreateProfileResponse>, CreateUserProfileCommandHandler>();

        services.AddValidatorsFromAssemblyContaining<IIdGenerator>(includeInternalTypes: true);

        services.AddScoped<ValidationBehavior<CreateUserProfileCommand, CreateProfileResponse>>();
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
        
    }
}