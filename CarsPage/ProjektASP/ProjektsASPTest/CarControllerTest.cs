using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektASP.Controllers;
using ProjektASP.Models;

namespace ProjektsASPTest {
    public class CarControllerTest {

        [SetUp]
        public void Setup() {
        }
        [Test]
        public void CheckIfTestsWorks() {
            Assert.Pass();
        }

        [Test]
        public async Task CheckIfCanCreateCarAndAddOwnerToIt() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "DbTest")
                .Options);
            var controller = new CarController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };
            dbContext.Owner.Add(owner);
            dbContext.SaveChanges();
            var car = new Car { Mark = "Scoda", Model = "Octavia I",YearOfProduction = 2005, Plate = "GDA 12345", Owner_R = owner };

            // Act
            var result = await controller.Create(car);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual(1, dbContext.Car.Count());
            Assert.AreEqual(owner, dbContext.Car.First().Owner_R);
        }
        [Test]
        public async Task CheckIfUpdatingWorks() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "DbTest2")
                .Options);
            var controller = new CarController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };
            var car = new Car { Mark = "Scoda", Model = "Octavia I", YearOfProduction = 2005, Plate = "GDA 12345", Owner_R = owner };
            dbContext.Owner.Add(owner);
            dbContext.Car.Add(car);
            dbContext.SaveChanges();

            car.Plate = "GD 12345";
            car.Owner_R = new Owner { Name = "Jane", Surname = "Smith" };

            // Act
            var result = await controller.Update(car);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual(1, dbContext.Car.Count());
            Assert.AreEqual("GD 12345", dbContext.Car.First().Plate);
            Assert.AreEqual("Jane", dbContext.Car.First().Owner_R.Name);
            Assert.AreEqual("Smith", dbContext.Car.First().Owner_R.Surname);
        }
        [Test]
        public async Task CheckIfDeletingWorks() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "DbTest3")
                .Options);
            var controller = new CarController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };
            var car = new Car { Mark = "Scoda", Model = "Octavia I", YearOfProduction = 2005, Plate = "GDA 12345", Owner_R = owner };
            dbContext.Owner.Add(owner);
            dbContext.Car.Add(car);
            dbContext.SaveChanges();

            // Act
            var result = await controller.Delete(1);

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
            Assert.AreEqual(0, dbContext.Car.Count());
        }
        [Test]
        public void CheckIfSearchingWorks() {
            // Arrange
            var dbContext = new CarContext(new DbContextOptionsBuilder<CarContext>()
                .UseInMemoryDatabase(databaseName: "DbTest4")
                .Options);
            var controller = new CarController(dbContext, null);
            var owner = new Owner { Name = "John", Surname = "Doe" };
            var car1 = new Car { Mark = "Scoda", Model = "Octavia I", YearOfProduction = 2005, Plate = "GDA 12345", Owner_R = owner };
            var car2 = new Car { Mark = "Audi", Model = "A3", YearOfProduction = 2001, Plate = "GD 12345", Owner_R = owner };
            var car3 = new Car { Mark = "Scoda", Model = "Octavia III", YearOfProduction = 2015, Plate = "WA 12345", Owner_R = owner };
            dbContext.Owner.Add(owner);
            dbContext.Car.AddRange(new List<Car> { car1, car2, car3 });
            dbContext.SaveChanges();
            // Act
            var result = controller.Search("GDA 12345");

            // Assert
            var viewResult = (ViewResult)result;
            var cars = (IEnumerable<Car>)viewResult.Model;
            Assert.AreEqual(1, cars.Count());
            Assert.AreEqual(car1.Plate, cars.ElementAt(0).Plate);
        }
        }
}
