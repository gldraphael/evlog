using System.Threading.Tasks;
using Evlog.Infrastructure.DataModels;
using Evlog.Infrastructure.Queries;
using Xunit;

namespace Evlog.UnitTests.Infrastructure.Queries
{
    public class UserQuery_Should : MongoTestBed
    {
        [Fact]
        public async Task Return_user()
        {
            // Arrange
            const string email = "jane@doe.com";
            UserDM user = new UserDM {
                Email = email
            };
            Db.Users.InsertOne(user);

            // Act
            var result = await new UserQuery(Db).QueryAsync(email);

            // Assert
            Assert.Equal(user.Email, result.Email);
        }

        [Fact]
        public async Task Return_null_if_user_doesnt_exists()
        {
            // Arrange
            const string email = "jane@doe.com";

            // Act
            var result = await new UserQuery(Db).QueryAsync(email);

            // Assert
            Assert.Null(result);
        }
    }
}