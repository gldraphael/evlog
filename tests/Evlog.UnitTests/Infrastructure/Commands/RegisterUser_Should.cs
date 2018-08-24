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
    public class RegisterUser_Should : IDisposable
    {
        [Fact]
        public async Task Create_registration()
        {
            // Arrange
            const string slug = "hey-there";
            const string email = "jane@doe.com";
            db.Events.InsertOne(new EventPostDM {
                Slug = slug
            });
            var mock = new Mock<IRegistrationInitiatedHandler>();
            var command = new RegisterUserCommand(db.Events, mock.Object);

            // Act
            await command.Execute(eventSlug: slug, userEmail: email);

            // Assert
            var @event = db.Events.Find(_ => _.Slug == slug).Single();
            Assert.Single(@event.Registrations);

            var registration = @event.Registrations.First();
            Assert.Equal(email, registration.Email);
        }

        [Fact]
        public void Do_nothing_if_already_registered()
        {

        }



        private readonly MongoDbContext db;
        public RegisterUser_Should()
        {
            db = new MongoDbContextBuilder()
                    .UseDefaultConfiguration()
                    .Build();
        }

        public void Dispose()
        {
            db.Client.DropDatabase(db.Database.DatabaseNamespace.DatabaseName);
        }
    }
}
