using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using InvoiceApplication.Data;
using InvoiceApplication.Models.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InvoiceApplication.Services.Companies.Tests
{
    [TestClass()]
    public class AddresServiceTests
    {
        // Test dla metody CreateAddressAsync
        [Fact]
        public async Task CreateAddressAsync_ShouldCreateAddressSuccessfully()
        {
            // Arrange
            // Tworzenie przykładowego obiektu Address
            var address = new Address
            {
                // Ustaw odpowiednie właściwości
                Street = "Test Street",
                City = "Test City",
                PostalCode = "12345",
                BuyerId = 1, // Przykładowe ID kupującego
                SellerId = 2, // Przykładowe ID sprzedającego
                Country = "Test Country",
                IsActive = true
            };

            // Utwórz mock dla IDbContextFactory<AppDbContext>
            var dbContextFactoryMock = new Mock<IDbContextFactory<AppDbContext>>();

            // Utwórz mock dla AppDbContext
            var dbContextMock = new Mock<AppDbContext>();

            // Ustaw odpowiednią konfigurację dla mocka dbContextFactoryMock
            dbContextFactoryMock.Setup(f => f.CreateDbContext()).Returns(dbContextMock.Object);

            // Utwórz instancję AddresService, używając mocka IDbContextFactory
            var addressService = new AddresService(dbContextFactoryMock.Object);

            // Act
            // Wywołaj metodę CreateAddressAsync
            await addressService.CreateAddressAsync(address);

            // Assert
            // Sprawdź, czy metoda SaveChangesAsync została wywołana raz
            dbContextMock.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            // Możesz dodać dodatkowe asercje w zależności od potrzeb
        }
    }

}