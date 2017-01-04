using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hanselman.Portable.Manager;
using System.Threading.Tasks;
using Hanselman.Portable;
using System.Linq;

namespace Hanselman.Tests
{
    [TestClass]
    public class Tests
    {
        [TestInitialize]
        public void Init()
        {
            ManagerFactory.IsMocked = true;
        }

        [TestMethod]
        public async Task LoadTweets()
        {
            var viewModel = new TwitterViewModel();
            var task = viewModel.ExecuteLoadTweetsCommand();

            await CheckIfBusy(task, viewModel);

            Assert.IsTrue(viewModel.Tweets.Any());
        }

        private async Task CheckIfBusy(Task task, BaseViewModel model)
        {
            Assert.IsTrue(model.IsBusy);
            Assert.IsFalse(model.IsNotBusy);

            await task;

            Assert.IsFalse(model.IsBusy);
            Assert.IsTrue(model.IsNotBusy);
        }
    }
}
