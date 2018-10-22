using NOTATNIK.Models.Database;
using NOTATNIK.Models.Interfaces;

namespace NUnit.Tests.Droid1.MockResults
{
    public class GetTask : IGetTask
    {
        public Task Task { get; set; }

        public async System.Threading.Tasks.Task DatabaseCall(int id)
        {
            Task taskDB = new Task()
            {
                  Id = 1,
                  Subject = "test",
                  Content = "test"
            };
            Task = taskDB;
        }
    }
}