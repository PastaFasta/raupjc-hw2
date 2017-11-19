using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;

namespace Zad31
{
    [TestClass()]
    public class TodoItemTests
    {
        [TestMethod()]
        public void TodoItemTest()
        {
            TodoItem testItem = new TodoItem("TodoItem");
            Assert.IsNotNull(testItem);
            Assert.AreEqual("TodoItem", testItem.Text);
            Assert.IsFalse(testItem.IsCompleted);
            Assert.IsNull(testItem.DateCompleted);
            Assert.IsNotNull(testItem.DateCreated);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem testItem = new TodoItem("TodoItem");
            Assert.IsTrue(testItem.MarkAsCompleted());
            Assert.IsTrue(testItem.IsCompleted);
            Assert.IsFalse(testItem.MarkAsCompleted());
        }

        [TestMethod()]
        public void EqualsTest()
        {
            TodoItem testItem1 = new TodoItem("TodoItem1");
            TodoItem testItem2 = new TodoItem("TodoItem2");
            TodoItem testItem3 = testItem1;

            Assert.IsFalse(testItem1.Equals(testItem2));
            Assert.IsTrue(testItem1.Equals(testItem3));
            Assert.IsFalse(testItem1 == testItem2);
            Assert.IsTrue(testItem1 == testItem3);
        }
        
        [TestMethod()]
        public void GetHashCodeTest()
        {
            TodoItem testItem = new TodoItem("TodoItem");
            Assert.IsNotNull(testItem.GetHashCode());
            Assert.AreEqual(testItem.Id.GetHashCode(), testItem.GetHashCode());
        }
    }
}