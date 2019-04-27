using System.Linq;
using System.Threading.Tasks;
using Evlog.Domain.Events.Handlers;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Commands
{
    public class RegisterUser_Should : MySqlTestBed
    {
        [Fact]
        public async Task Create_registration()
        {
            // Arrange
            const string slug = "hey-there";
            const string email = "jane@doe.com";
            await Db.Events.AddAsync(new EventPostDM {
                Slug = slug
            });
            await Db.SaveChangesAsync();
            var command = new RegisterUserCommand(Db, mockHandler);

            // Act
            await command.Execute(eventSlug: slug, userEmail: email);

            // Assert
            var @event = await Db.Events.SingleOrDefaultAsync(_ => _.Slug == slug);
            Assert.Single(@event.Registrations);

            var registration = @event.Registrations.First();
            Assert.Equal(email, registration.Email);
        }

        [Fact(Skip = "Will come back to this later.")]
        public async Task Do_nothing_if_already_registered_for_same_unit()
        {
            // Arrange
            const string slug = "hey-there";
            const string email = "jane@doe.com";
            await Db.Events.AddAsync(new EventPostDM {
                Slug = slug
            });
            await Db.SaveChangesAsync();
            var command = new RegisterUserCommand(Db, mockHandler);

            // Act
            await command.Execute(eventSlug: slug, userEmail: email);
            await command.Execute(eventSlug: slug, userEmail: email);

            // Assert
            var @event = await Db.Events.SingleOrDefaultAsync(_ => _.Slug == slug);
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
