namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        [Test]
        [TestCase(null, "Lumia")]
        [TestCase("", "Lumia")]
        [TestCase("Nokia", "")]
        [TestCase("Nokia", null)]
        public void ConstructorShouldThrowArgumentExceptionIfGivenParametersAreInvalid(string make, string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }
        [Test]
        public void ConstructorShouldWorkCorrctly()
        {
            var phone = new Phone("Salamsung", "Space");
            Assert.AreEqual("Salamsung", phone.Make);
            Assert.AreEqual("Space", phone.Model);
        }
        [Test]
        public void CounterShouldIncreaseByOneWhenPhoneIsAdded()
        {
            var phone = new Phone("Salamsung", "Space");
            Assert.AreEqual(0, phone.Count);
            phone.AddContact("Nikolay", "93-500");
            Assert.AreEqual(1, phone.Count);
        }
        [Test]
        public void MethodAddContactShouldThrowInvalidOperationExceptionIfGivenNameAlreadyExists()
        {
            var phone = new Phone("Salamsung", "Space");
            phone.AddContact("Nikolay", "93-500");
            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Nikolay", "029141841"));
        }
        [Test]
        public void MethodCallShouldThrowInvalidOperationExceptionIfGivenNameDoesntExistInPhonebook()
        {
            var phone = new Phone("Salamsung", "Space");
            phone.AddContact("Nikolay", "93-500");
            Assert.Throws<InvalidOperationException>(() => phone.Call("Koko"));
        }
        [Test]
        public void MethodCallShouldReturnCorectllyNameAndNumberIfTheNameExistInThePhonebook()
        {
            var phone = new Phone("Salamsung", "Space");
            phone.AddContact("Nikolay", "93-500");
            var expectedString = "Calling Nikolay - 93-500...";
            Assert.AreEqual(expectedString, phone.Call("Nikolay"));
        }
    }
}