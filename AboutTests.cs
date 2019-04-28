using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class AboutTests : Test
    {
        public AboutTests(Platform platform) : base(platform) { }

        [Test]
        public void Verify_About_System()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Marked("About"));
                    app.Screenshot("About: About Menu").MoveTo($"C:\\Screenshots\\About_AboutMenu__{Guid.NewGuid()}test.com");
                    app.TapOption(e => e.Marked("About " + SYSTEM));
                    app.Screenshot("About: About Website").MoveTo($"C:\\Screenshots\\AboutMenu_AboutWebsite__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(app.GetLabel("About"));                 
                    app.Assert(app.GetLabel("AboutLocation", SYSTEM), true);
                    app.TapOption(app.GetLabel("AboutLocation", SYSTEM));   
                    break;
            }
        }

        [Test]
        public void Verify_FAQ()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Marked("About"));
                    app.TapOption(e => e.Marked("FAQ"));
                    app.Screenshot("About: FAQ Page").MoveTo($"C:\\Screenshots\\AboutMenu_FAQPage__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(app.GetLabel("About"));
                    app.TapOption(app.GetLabel("Faq")); 
                    break;
            }
        }

        [Test]
        public void Verify_Report_Bike_Problem()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(app.GetLabel("About"));
                    app.TapOption(e => e.Marked("Report a Bike Problem"));
                    app.Screenshot("About: Report Bike Problem").MoveTo($"C:\\Screenshots\\AboutMenu_ReportBikeProblem__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(app.GetLabel("About"));
                    app.Assert(app.GetLabel("ReportABikeProblem"), true);
                    break;
            }
        }

        [Test]
        public void Verify_Sponsors_And_Promotions()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Marked("About"));
                    app.TapOption(e => e.Marked("Sponsors & Promotions"));
                    app.Screenshot("About: Sponsors & Promotions").MoveTo($"C:\\Screenshots\\AboutMenu_SponsorsPromotions__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(app.GetLabel("About"));   
                    app.Assert(app.GetLabel("text_sponsors_about_menu"), true);               
                    app.TapOption(app.GetLabel("text_sponsors_about_menu"));
                    break;
            }
        }

        [Test]
        public void Verify_Terms_And_Conditions()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapHamburgerMenu();      
                    app.TapOption(app.GetLabel("About"));
                    app.TapOption(e => e.Marked("text_terms_about_menu"));
                    app.Screenshot("About: Terms & Conditions").MoveTo($"C:\\Screenshots\\AboutMenu_TermsConditions__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(app.GetLabel("About"));
                    app.TapOption(app.GetLabel("EulaDescription"));
                    break;
            }
        }
    }
}