using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zad2;

namespace Zad31
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            TodoItem testItem = new TodoItem("TodoItem");
            TodoRepository repo = new TodoRepository();
            TodoItem returned = repo.Add(testItem);
            Assert.IsNotNull(returned);
            Assert.AreEqual(returned, testItem);
        }

        [TestMethod()]
        public void TodoRepositoryTest()
        {
            TodoRepository repo1 = new TodoRepository();
            GenericList<TodoItem> testList = new GenericList<TodoItem>(3);
            TodoRepository repo2 = new TodoRepository(testList);
            Assert.IsNotNull(repo1);
            Assert.IsNotNull(repo2);
        }

        [TestMethod()]
        public void GetTest()
        {
            TodoRepository repo1 = new TodoRepository();
            TodoItem testItem1 = new TodoItem("Todo1");
            TodoItem testItem2 = new TodoItem("Todo2");
            TodoItem addedItem = repo1.Add(testItem1);
            TodoItem gottenItem = repo1.Get(addedItem.Id);
            Assert.IsNotNull(gottenItem);
            Assert.IsNotNull(addedItem.Equals(gottenItem));
            Assert.IsNull(repo1.Get(testItem2.Id));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem testItem = new TodoItem("Todo1");
            repo.Add(testItem);
            Assert.IsTrue(repo.Remove(testItem.Id));
            Assert.IsFalse(repo.Remove(testItem.Id));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem testItem1 = new TodoItem("Todo1");
            TodoItem testItem2 = new TodoItem("Todo2");
            repository.Add(testItem1);
            string beforeUpdate = testItem1.Text;
            testItem1.Text = "tododo1";
            string afterUpdate = repository.Update(testItem1).Text;
            Assert.AreNotEqual(beforeUpdate, afterUpdate);
            Assert.IsNotNull(repository.Update(testItem2));
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem testItem = new TodoItem("Todo");
            Assert.IsFalse(repo.MarkAsCompleted(testItem.Id));
            repo.Add(testItem);
            Assert.IsTrue(repo.MarkAsCompleted(testItem.Id));
            Assert.IsFalse(repo.MarkAsCompleted(testItem.Id));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem testItem1 = new TodoItem("Todo1");
            TodoItem testItem2 = new TodoItem("Todo2");
            TodoItem testItem3 = new TodoItem("Todo3");
            TodoItem testItem4 = new TodoItem("Todo4");
            repo.Add(testItem1);
            repo.Add(testItem2);
            repo.Add(testItem3);
            repo.Add(testItem4);

            List<TodoItem> result = repo.GetAll();

            Assert.AreEqual(4, result.Count);
            Assert.AreEqual(testItem4.DateCreated, result[0].DateCreated);
            Assert.AreEqual(testItem3.DateCreated, result[1].DateCreated);
            Assert.AreEqual(testItem2.DateCreated, result[2].DateCreated);
            Assert.AreEqual(testItem1.DateCreated, result[3].DateCreated);
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem testItem1 = new TodoItem("Todo1");
            TodoItem testItem2 = new TodoItem("Todo2");
            TodoItem testItem3 = new TodoItem("Todo3");
            TodoItem testItem4 = new TodoItem("Todo4");
            testItem4.MarkAsCompleted();
            repository.Add(testItem1);
            repository.Add(testItem2);
            repository.Add(testItem3);
            repository.Add(testItem4);
            List<TodoItem> result = repository.GetActive();
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(testItem3.DateCreated, result[0].DateCreated);
            Assert.AreEqual(testItem2.DateCreated, result[1].DateCreated);
            Assert.AreEqual(testItem1.DateCreated, result[2].DateCreated);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem testItem1 = new TodoItem("Todo1");
            TodoItem testItem2 = new TodoItem("Todo2");
            TodoItem testItem3 = new TodoItem("Todo3");
            TodoItem testItem4 = new TodoItem("Todo4");
            testItem4.MarkAsCompleted();
            testItem3.MarkAsCompleted();
            testItem2.MarkAsCompleted();
            repository.Add(testItem1);
            repository.Add(testItem2);
            repository.Add(testItem3);
            repository.Add(testItem4);

            List<TodoItem> result = repository.GetCompleted();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(testItem4.DateCreated, result[0].DateCreated);
            Assert.AreEqual(testItem3.DateCreated, result[1].DateCreated);
            Assert.AreEqual(testItem2.DateCreated, result[2].DateCreated);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem testItem1 = new TodoItem("Todo1");
            TodoItem testItem2 = new TodoItem("Todo2");
            TodoItem testItem3 = new TodoItem("Todo3");
            TodoItem testItem4 = new TodoItem("Todo4");
            TodoItem testItem5 = new TodoItem("Todo1");
            repository.Add(testItem1);
            repository.Add(testItem2);
            repository.Add(testItem3);
            repository.Add(testItem4);
            repository.Add(testItem5);

            List<TodoItem> result = repository.GetFiltered(i => i.Text == "Todo1");

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(testItem5.DateCreated, result[0].DateCreated);
            Assert.AreEqual(testItem1.DateCreated, result[1].DateCreated);
            Assert.AreEqual(0, repository.GetFiltered(i => i.Text == "tododo1").Count);
        }
    }
}