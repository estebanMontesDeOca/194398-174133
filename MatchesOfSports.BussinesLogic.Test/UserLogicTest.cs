using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchesOfSports.BussinesLogic.Test
{
    [TestClass]
    public class UserLogicTest
    {
        /*
            [TestMethod]
            public void CreateValidUserTest()
            {
                var user = new User();
                {
                    Name="Name";  
                    Surname = "Surname";
                    UserName="Username";
                    Password="email";
                    Email="pasword";
                };
                var mock = new Mock<IRepositoryOf<User>>(MockBehavior.Strict);
                mock.Setup(m => m.Add(It.IsAny<User>()));
                mock.Setup(m => m.Save());
                var userLogic = new UserService(mock.Object);

                var result = UserService.Create(user);

                mock.VerifyAll();
                Assert.AreEqual(user.UserName, result.UserName);
            }

              [TestMethod]
            [ExpectedException(System.InvalidOperationException)]
            public void CreateNullUserTest()
            {
                var mock = new Mock<IRepository<User>>(MockBehavior.Strict);
                var userLogic = new UserService(mock.Object);

                var result = UserService.CreateUser(null);
    }*/
    }
}
