using Xunit;
using Moq;
using Imagine.Business.Services; // UserService'in bulunduğu namespace
using Imagine.DataAccess.Entities; // User ve diğer entity'lerin bulunduğu namespace
using Imagine.DataAccess.Interfaces; // IUserRepository'in bulunduğu namespace

namespace TestProject
{
    public class ServiceTest
    {
        [Fact]
        public void GetUser_ReturnsExpectedName()
        {
            // Arrange: Test için gerekli olan nesneleri ve durumu oluşturun
            var mockUserRepository = new Mock<IUserRepository>();
            var expectedName = "Enis";
            var expectedUser = new User { Name = expectedName };

            // Mock davranışını ayarlayın: Get metodunun beklenen kullanıcıyı döndürmesini sağlayın
            mockUserRepository.Setup(repo => repo.Get(It.IsAny<Func<User, bool>>()))
                .Returns((Func<User, bool> predicate) => expectedUser);

            var userService = new UserService(mockUserRepository.Object);

            // Act: Test edilecek metodu çağırın
            var result = userService.GetUser(u => u.Name == expectedName);

            // Assert: Sonuçları doğrulayın
            Assert.Equal(expectedName, result.Name);
        }
    }
}