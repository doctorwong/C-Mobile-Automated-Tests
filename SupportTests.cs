using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class SupportTests : Test
    {
        public SupportTests(Platform platform) : base(platform) { }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            AppExtension.SetPlatform(platform);
        }


        [Test]
        public void Verify_BCycle_Global_Website()
        {
            //opens external browser

            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Text("Support"));
                    app.Assert(e => e.Text("Bcycle Global Website"), true);
                    app.Tap(e => e.Text("Bcycle Global Website"));
                    app.Screenshot("Support Bcycle Website").MoveTo($"C:\\Screenshots\\Support_BCycleWebsite__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")));
                    app.Assert(e => e.Id("cell_text_support").Marked(app.GetLabel("BcycleGlobalWebsite", SYSTEM)), true);
                    app.TapOption(e => e.Id("cell_text_support").Text(app.GetLabel("BcycleGlobalWebsite")));
                    break;
            }
        }

        [Test]
        public void Verify_Call_System()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.WaitForElement(e => e.Text("Support"));
                    app.Tap(e => e.Text("Support"));
                    app.Assert(e => e.Text("Call " + SYSTEM), true);
                    app.Tap(e => e.Text("Call " + SYSTEM));
                    app.Screenshot("Support Call Sytem").MoveTo($"C:\\Screenshots\\Support_CallSystem__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")));
                    app.Assert(e => e.Id("cell_text_support").Marked(app.GetLabel("CallLocation", SYSTEM)), true);
                    app.TapOption(e => e.Id("cell_text_support").Text(app.GetLabel("CallLocation", SYSTEM)));
                    break;
            }
        }

        [Test]
        public void Verify_Email_System()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Text("Support"));
                    app.Assert(e => e.Text("Email " + SYSTEM), true);
                    app.Tap(e => e.Text("Email " + SYSTEM));
                    app.Screenshot("Support Email System").MoveTo($"C:\\Screenshots\\Support_EmailSystem__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();                  
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();              
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")));
                    app.Assert(e => e.Id("cell_text_support").Text(app.GetLabel("EmailLocation", SYSTEM)), true);
                    app.TapOption(e => e.Id("cell_text_support").Text(app.GetLabel("EmailLocation", SYSTEM)));
                    break;
            }
        }

        [Test]
        public void Verify_Go_To_System_Website()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Text("Support"));
                    app.Assert(e => e.Text("Go to " + SYSTEM + " Website"), true);
                    app.Tap(e => e.Text("Go to " + SYSTEM + " Website"));
                    app.Screenshot("Go to system website").MoveTo($"C:\\Screenshots\\Support_GoToSystem__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")));
                    app.Assert(e => e.Id("cell_text_support").Marked(app.GetLabel("GoToLocationWebsite", SYSTEM)), true);
                    app.TapOption(e => e.Id("cell_text_support").Text(app.GetLabel("GoToLocationWebsite", SYSTEM)));
                    break;
            }
        }

        [Test]
        public void Verify_Report_A_Bike_Problem()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Text("Support"));
                    app.Assert(e => e.Text("Report a Bike Problem"), true);
                    app.Tap(e => e.Text("Report a Bike Problem"));
                    app.Screenshot("Report a Bike Problem Site").MoveTo($"C:\\Screenshots\\Support_ReportBikeProblem__{Guid.NewGuid()}.png");
                    break;

                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")));               
                    app.Assert(e => e.Id("cell_text_support").Marked(app.GetLabel("ReportABikeProblem", SYSTEM)), true);
                    app.TapOption(e => e.Id("cell_text_support").Text(app.GetLabel("ReportABikeProblem")));
                    break;
            }
        }


    }
}