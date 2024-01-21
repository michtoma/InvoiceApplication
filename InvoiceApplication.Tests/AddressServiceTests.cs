using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using InvoiceApplication.Services.Companies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections;

namespace InvoiceApplication.Tests
{
    [TestClass]
    public class AddressServiceTests : TestContext
    {
        public override IDictionary Properties => throw new NotImplementedException();

        public override void AddResultFile(string fileName)
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task CreateAddressAsync_ShouldCreateAddressSuccessfully()
        {
            // Arrange
            // Utwórz przykładowy obiekt Address
            var address = new Address
            {
                Street = "Test Street",
                City = "Test City",
                PostalCode = "12345",
                BuyerId = 1,
                SellerId = 2,
                Country = "Test Country",
                IsActive = true
            };

            // Utwórz mock dla IAddresService
            var addressServiceMock = new Mock<IAddresService>();

            // Skonfiguruj zachowanie mocka dla metody CreateAddressAsync
            addressServiceMock.Setup(a => a.CreateAddressAsync(It.IsAny<Address>()))
                              .Returns(Task.CompletedTask);

            // Assert
            // Sprawdź, czy metoda CreateAddressAsync została wywołana raz z odpowiednimi argumentami
            addressServiceMock.Verify(a => a.CreateAddressAsync(It.Is<Address>(
                adr => adr.Street == "Test Street" &&
                       adr.City == "Test City" &&
                       adr.PostalCode == "12345" &&
                       adr.BuyerId == 1 &&
                       adr.SellerId == 2 &&
                       adr.Country == "Test Country" &&
                       adr.IsActive == true)), Times.Once);
        }

        public override void Write(string? message)
        {
            throw new NotImplementedException();
        }

        public override void Write(string format, params object?[] args)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string? message)
        {
            throw new NotImplementedException();
        }

        public override void WriteLine(string format, params object?[] args)
        {
            throw new NotImplementedException();
        }
    }
}

