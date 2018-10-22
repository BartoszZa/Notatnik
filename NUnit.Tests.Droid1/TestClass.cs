using NOTATNIK.ViewModels;
using NUnit.Framework;

namespace NUnit.Tests.Droid1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestId()
        {
            AddTaskViewModel AddTaskVM = new AddTaskViewModel();
            int id = 1;
            GetTask getTask = new GetTask();
            AddTaskVM.Load(getTask, id);
            Assert.AreEqual(1, getTask.Task.Id);
        }

        [Test]
        public void TestSubject()
        {
            AddTaskViewModel AddTaskVM = new AddTaskViewModel();
            int id = 1;
            GetTask getTask = new GetTask();
            AddTaskVM.Load(getTask, id);
            Assert.AreEqual("test", getTask.Task.Subject);
        }

        [Test]
        public void TestContent()
        {
            AddTaskViewModel AddTaskVM = new AddTaskViewModel();
            int id = 1;
            GetTask getTask = new GetTask();
            AddTaskVM.Load(getTask, id);
            Assert.AreEqual("test", getTask.Task.Content);
        }
    }
}
