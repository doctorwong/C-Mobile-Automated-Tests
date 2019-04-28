using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using BCycleMobile.UITest.Android;
using BCycleMobile.UITest.IOS;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class GeneralTests
    {
        IApp app;
        TaskSystem tasks;
        Platform platform;

        public GeneralTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            tasks = AppInitializer.StartApp(platform);
            this.app = tasks.GetApp();

		}
    }
}


