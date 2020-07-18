//using System.Threading.Tasks;
//using Evlog.Infrastructure.DataModels;
//using Evlog.Infrastructure.Queries;
//using Xunit;

//namespace Evlog.UnitTests.Infrastructure.Queries
//{
//    public class UserExistsQuery_should : MySqlTestBed
//    {
//        [Fact]
//        public async Task Return_true_if_user_exists()
//        {
//            // Arrange
//            const string email = "jane@doe.com";
//            UserDM user = new UserDM{
//                Email = email
//            };
//            await Db.Users.AddAsync(user);
//            await Db.SaveChangesAsync();

//            // Act
//            var result = await new UserExistsQuery(Db).QueryAsync(email);

//            // Assert
//            Assert.True(result);
//        }

//        [Fact]
//        public async Task Return_false_if_user_doesnt_exists()
//        {
//            // Arrange
//            const string email = "jane@doe.com";

//            // Act
//            var result = await new UserExistsQuery(Db).QueryAsync(email);

//            // Assert
//            Assert.False(result);
//        }
//    }
//}