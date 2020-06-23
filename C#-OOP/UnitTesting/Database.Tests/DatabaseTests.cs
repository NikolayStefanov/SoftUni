namespace Tests
{
    using NUnit.Framework;
    using System;
    using Database;
    public class DatabaseTests
    { 
        private Database testDatabase;

        [SetUp]
        public void SetUpMethod()
        {
        }

        [Test]
        public void DatabaseConstructorShouldHaveSixElements()
        {
            testDatabase = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            Assert.AreEqual(16, testDatabase.Count);
        }
        [Test]
        public void DatabaseConstructorShouldThrowInvalidOperationExceptionIfCountIsOver16()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }));
        }
        [Test]
        public void DatabaseMethodAddShouldAddElementOnTheNextFreeCell()
        {
            testDatabase = new Database(new int[] { 1, 2, 3, 4, 5 });
            testDatabase.Add(6);
            var currArr = testDatabase.Fetch();
            Assert.AreEqual(6, currArr[5]);
        }
        [Test]
        public void DatabaseMethodAddShouldThrowInvalidOperationExceptionIfTryToAdd17Element()
        {
            testDatabase = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });
            Assert.Throws<InvalidOperationException>(() => testDatabase.Add(17));
        }
        [Test]
        public void DatabaseMethodRemoveShouldRemoveOnlyTheLastElement()
        {
            testDatabase = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            testDatabase.Remove();
            var arr = testDatabase.Fetch();
            Assert.AreEqual(6, arr[5]);
            Assert.AreEqual(6, arr.Length);
        }
        [Test]
        public void DatabaseMethodRemoveShouldThrowExceptionIfTryToRemoveUnrealElement()
        {
            testDatabase = new Database();
            Assert.Throws<InvalidOperationException>(() => testDatabase.Remove());
        }
        [Test]
        public void DatabaseMethodFetchShouldReturnArrayWithTheElements()
        {
            testDatabase = new Database(1, 2, 3);

            int[] databaseElements = testDatabase.Fetch();
            int[] expectedDatabaseElements = new int[] { 1, 2, 3 };

            CollectionAssert.AreEqual(expectedDatabaseElements, databaseElements);
        }
    }
}