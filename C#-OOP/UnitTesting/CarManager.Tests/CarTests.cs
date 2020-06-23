using NUnit.Framework;
using System;
using CarManager;
namespace Tests
{
    
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, "406", 12.5, 40)]
        [TestCase("Peugeot", null, 12.5, 40)]
        [TestCase("Peugeot", "406", -12.5, 40)]
        [TestCase("Peugeot", "406", 0, 40)]
        [TestCase("Peugeot", "406", 12.5, -1)]
        [TestCase("Peugeot", "406", 12.5, 0)]

        public void WhenCarIsInitializedAndSomeValueIsNothValidShouldThrowArgumentException(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            Assert.AreEqual("Peugeot", car.Make);
            Assert.AreEqual("406", car.Model);
            Assert.AreEqual(12.5, car.FuelConsumption);
            Assert.AreEqual(40, car.FuelCapacity);
        }
        [Test]
        public void RefuelMethodShouldThrowArgumentExceptionIfTheValueIsBelowZero()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            Assert.Throws<ArgumentException>(() => car.Refuel(-16));
        }
        [Test]
        public void RefuelMethodShouldThrowArgumentExceptionIfTheValueIsZero()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }
        [Test]
        public void RefuelMethodShouldFillUpTillTheCapacityIfYouGiveItMoreThanCapacity()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            car.Refuel(45);
            Assert.AreEqual(40, car.FuelAmount);
        }
        [Test]
        public void RefuelMethodShouldWorkNormally()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            car.Refuel(14.143);
            Assert.AreEqual(14.143, car.FuelAmount);
        }
        [Test]
        public void CarShouldThrowExceptionIfYouTryToDriveMoreThanFuelAmount()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            car.Refuel(5);
            Assert.Throws<InvalidOperationException>(() => car.Drive(120.5));
        }
        [Test]
        public void CarMethodDriveShouldWorkNormallyAndDecreaceFuelAmount()
        {
            var car = new Car("Peugeot", "406", 12.5, 40);
            car.Refuel(25);
            car.Drive(50);
            Assert.AreEqual(18.75, car.FuelAmount);

        }
    }
}