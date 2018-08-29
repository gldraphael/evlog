using System.Threading.Tasks;
using Evlog.Infrastructure.Commands;
using Evlog.Infrastructure.Queries;
using MongoDB.Driver;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Commands
{
    public class CreateUser_should : MongoTestBed
    {
        [Fact]
        public async Task Create_user()
        {
            // Arrange
            const string email = "jane@doe.com";

            // Act
            await sut.ExecuteAsync(email);

            // Assert
            var count = await Db.Users.CountDocumentsAsync(_ => _.Email == email);
            Assert.Equal(1, count);
        }

        [Fact]
        public async Task Do_nothing_if_a_user_with_the_email_already_exists()
        {
            // Arrange
            const string email = "jane@doe.com";

            // Act
            await sut.ExecuteAsync(email);
            await sut.ExecuteAsync(email);

            // Assert
            var count = await Db.Users.CountDocumentsAsync(_ => _.Email == email);
            Assert.Equal(1, count);
        }

        CreateUserCommand sut;
        UserExistsQuery query;
        public CreateUser_should()
        {
            query = new UserExistsQuery(Db);
            sut = new CreateUserCommand(Db.Users, query);
        }
    }
}
