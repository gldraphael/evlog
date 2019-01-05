using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evlog.Domain.Events.Handlers;
using Evlog.Infrastructure;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.DataModels;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Commands
{
    public class RegisterUser_Should : MongoTestBed
    {
        [Fact]
        public async Task Create_registration()
        {
            // Arrange
            const string slug = "hey-there";
            const string email = "jane@doe.com";
            Db.Events.InsertOne(new EventPostDM {
                Slug = slug
            });
            var command = new RegisterUserCommand(Db.Events, mockHandler);

            // Act
            await command.Execute(eventSlug: slug, userEmail: email);

            // Assert
            var @event = Db.Events.Find(_ => _.Slug == slug).Single();
            Assert.Single(@event.Registrations);

            var registration = @event.Registrations.First();
            Assert.Equal(email, registration.Email);
        }

        [Fact]
        public async Task Do_nothing_if_already_registered_for_same_unit()
        {
            // Arrange
            const string slug = "hey-there";
            const string email = "jane@doe.com";
            Db.Events.InsertOne(new EventPostDM {
                Slug = slug
            });
            var command = new RegisterUserCommand(Db.Events, mockHandler);

            // Act
            await command.Execute(eventSlug: slug, userEmail: email);
            await command.Execute(eventSlug: slug, userEmail: email);

            // Assert
            var @event = Db.Events.Find(_ => _.Slug == slug).Single();
            Assert.Single(@event.Registrations);

            var registration = @event.Registrations.First();
            Assert.Equal(email, registration.Email);
        }



        private readonly IRegistrationCompletedHandler mockHandler;
        public RegisterUser_Should()
        {
            mockHandler = new Mock<IRegistrationCompletedHandler>().Object;
        }
    }
}
