using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Hanselman.UI.Tests
{
    [TestFixture]
    public class Tests
    {
        private IApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                //.ApkFile(@"C:\Users\mmueller\ReposDemo\Hanselman.Forms\Hanselman.Android\bin\Debug\com.refractored.hanselman.apk")
                //.ApkFile(@"C:\Users\mmueller\ReposDemo\Hanselman.Forms\Hanselman.Android\bin\Release\com.refractored.hanselman.apk")
                .StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void ClickThroughTest()
        {
            this.TestMenuItem("About");
            this.TestMenuItem("Blog");
            this.TestMenuItem("Twitter");
            this.TestMenuItem("Hanselminutes");
            this.TestMenuItem("Ratchet");
            this.TestMenuItem("Developers Life");
        }

        //[Test]
        //public void ReplDemo()
        //{
        //    // REPL (read-eval-print-loop)
        //    app.Repl();

        //    //tree
        //    //app.Tap("OK)
        //    //app.Tap(x => x.Marked("Hanselminutes"))

        //    //app.Tap("OK");
        //    //app.Tap("Hanselminutes");
        //}


        private void TestMenuItem(string name)
        {
            app.WaitForElement(x => x.Marked("OK"));
            app.Tap(x => x.Marked("OK"));

            app.WaitForElement(x => x.Marked(name));
            app.Tap(x => x.Text(name));

            app.Screenshot(name);
        }
    }
}
