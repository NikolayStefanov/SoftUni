using ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExtendedDatabaseConstructorShouldThrowExceptionIfYouGiveItMoreThan16Elements()
        {
            var people = new Person[17];
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }
        [Test]
        public void ExtendedDatabaseConstructorShouldAddPeopleAndIncreaseCountCorrectly()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.AreEqual(3, database.Count);
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfPeopleAreMoreThan16()
        {
            var people = new List<Person>();
            for (int i = 0; i < 16; i++)
            {
                var currPerson = new Person(100 + i, "Nikolay" + "St" + i);
                people.Add(currPerson);
            }
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(3534534, "Koko")));
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfThereAreTwoPeopleWithSameName()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(12313123, "Nikolay");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<InvalidOperationException>(() => database.Add(person4));
        }
        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfThereAreTwoPeopleWithSameID()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(0876757337, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<InvalidOperationException>(() => database.Add(person4));
        }
        [Test]
        public void AddMethodShouldIncreaseTheCountAndAddPersonCorrectly()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            database.Add(person4);
            Assert.AreEqual(4, database.Count);
        }
        [Test]
        public void RemoveMethodShouldThrowExceptionIfYouTryToRemovePersonWhenCountIsZero()
        {
            // var person1 = new Person(0876757337, "Nikolay");
            // var people = new List<Person>();
            // people.Add(person1);
            var database = new ExtendedDatabase.ExtendedDatabase();
            // database.Remove();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveMethodShouldDecreaseCountAndRemoveCorrectly()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.AreEqual(4, database.Count);
            database.Remove();
            Assert.AreEqual(3, database.Count);
            var targetPerson = database.FindByUsername("Cvetelina");
            Assert.AreEqual("Cvetelina", targetPerson.UserName);
        }
        [Test]
        public void FindByUsernameShouldThrowArgumentNullExceptionIfNameIsNull()
        {

            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }
        [Test]
        public void FindByUsernameMethodShouldThrowInvalidOperationExceptionIfReceiveUnrealName()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Plamen"));
        }
        [Test]
        public void FindByUsernameMethodShouldWorkCorrectly()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            var actualPerson = database.FindByUsername("Nikolay");
            Assert.AreEqual(person1, actualPerson);
        }
        [Test]
        public void FindByIdMethodShouldThrowArgumentOutOfRangeExceptionIfGivenIdIsLessThanZero()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-0876757337));
        }
        [Test]
        public void FindByIdMethodShouldThrowInvalidOperationExceptionIfGivenIdDoesntExist()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            Assert.Throws<InvalidOperationException>(() => database.FindById(87675737));
            //IF ID STARTS WITH 0 , there is BUG
        }
        [Test]
        public void FindByIdMethodShouldWorkCorrectly()
        {
            var person1 = new Person(0876757337, "Nikolay");
            var person2 = new Person(0886645486, "Stefan");
            var person3 = new Person(1111111111, "Cvetelina");
            var person4 = new Person(19971967, "Karakonjo");
            var people = new List<Person>();
            people.Add(person1);
            people.Add(person2);
            people.Add(person3);
            people.Add(person4);
            var database = new ExtendedDatabase.ExtendedDatabase(people.ToArray());
            var targetPerson = database.FindById(0876757337);
            Assert.AreEqual(person1, targetPerson);
        }


    }
}