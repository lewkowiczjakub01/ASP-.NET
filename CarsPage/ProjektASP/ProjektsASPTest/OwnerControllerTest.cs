using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektASP.Controllers;
using ProjektASP.Models;

namespace ProjektsASPTest {
    public class OwnerControllerTest {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CheckIfTestsWorks() {
            Assert.Pass();
        }

        [Test]
        public async Task CheckIfCreatingOwnersWorks() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "TestDB0")
                .Options);
            var controller = new OwnerController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };

            // Act
            var result = await controller.Create(owner);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual(1, dbContext.Owner.Count());
        }

        [Test]
        public async Task CheckIfUpdatingOwnerWorks() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "TestDB1")
                .Options);
            var controller = new OwnerController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };
            dbContext.Owner.Add(owner);
            await dbContext.SaveChangesAsync();
            owner.Name = "Jane";
            owner.Surname = "Doe";
            // Act
            var result = await controller.Update(owner);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual(1, dbContext.Owner.Count());
            Assert.AreEqual("Jane", dbContext.Owner.FirstOrDefault().Name);
            Assert.AreEqual("Doe", dbContext.Owner.FirstOrDefault().Surname);
        }

        [Test]
        public async Task CheckIfDeletingOwnerWorks() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "TestDB2")
                .Options);
            var controller = new OwnerController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };
            dbContext.Owner.Add(owner);
            await dbContext.SaveChangesAsync();

            // Act
            var result = await controller.Delete(owner.Id);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual(0, dbContext.Owner.Count());
        }
        [Test]
        public void CheckIfCanCreateFewOwners() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "TestDB3")
                .Options);
            var controller = new OwnerController(dbContext, null);
            Owner o1 = new Owner { Name = "John", Surname = "Doe" };
            Owner o2 = new Owner { Name = "Jane", Surname = "Smith" };
            Owner o3 = new Owner { Name = "Bob", Surname = "Johnson" };
            controller.Create(o1);
            controller.Create(o2);
            controller.Create(o3);
            dbContext.SaveChanges();

            // Act
            var result = controller.Index(1);

            // Assert
            var viewResult = (ViewResult)result;
            var model = (List<Owner>)viewResult.Model;
            Assert.AreEqual(3, model.Count());
        }
    }
}