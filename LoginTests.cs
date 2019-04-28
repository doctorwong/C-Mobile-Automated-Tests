using NUnit.Framework;
using System;
using System.Threading;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class LoginTests : Test
    {
        public LoginTests(Platform platform) : base(platform) { }

        [Test]
        public void Check_Login_Options()
        {

            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Screenshot("Login Options").MoveTo($"C:\\Screenshots\\Login_LogInOptions__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Id("text_join_bcycle_login").Text(app.GetLabel("JoinBCycle")), true);
                    app.Assert(e => e.Id("text_forgot_password_login").Text(app.GetLabel("ForgotPassword")), true);
                    app.Tap(e => e.Marked("Navigate up"));
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Assert(e => e.Id("bar_button_join_bcycle_login").Marked(app.GetLabel("JoinBCycle")), true);
                    app.Assert(e => e.Id("bar_button_forgot_password_login").Marked(app.GetLabel("ForgotPassword")), true);
                    break;
            }
        }

        [Test]
        public void Verify_Invalid_Login_Email()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("Open Navigation Drawer", SYSTEM_DASH);
                    app.TapProfile();
                    app.Login(INVALID_EMAIL, EMAIL_PASSWORD);
                    app.Screenshot("Invalid Login Message").MoveTo($"C:\\Screenshots\\Login_InvalidLogin__{Guid.NewGuid()}.png");
                    app.Assert(e => e.WebView().Css("div.alert"), true);
                    app.Tap(e => e.Marked("Navigate up"));
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(INVALID_EMAIL, EMAIL_PASSWORD, false);
                    app.Assert(e => e.WebView().Css("div.alert"), true);
                    break;
            }
        }

        [Test]
        public void Verify_Login_Logout_Email()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("Open Navigation Drawer", SYSTEM_DASH);
                    app.TapProfile();
                    app.Login(EMAIL_DASH, EMAIL_PASSWORD_DASH);
                    app.Assert(e => e.Text("Successfully logged in"), true);
                    app.Screenshot("Logged In Message").MoveTo($"C:\\Screenshots\\Login_ClassicLoggedInMessage__{Guid.NewGuid()}.png");                                    
                    app.TapProfile();
                    app.WaitForElement("content_user_data_account_info");
                    app.ScrollDownTo("text_sign_out_account_info");
                    app.TapOption("text_sign_out_account_info");
                    app.Assert(e => e.Text("Successfully logged out"), true);
                    app.Screenshot("Logged Out Message").MoveTo($"C:\\Screenshots\\Login_LoggedOutMessage__{Guid.NewGuid()}.png"); ;                 
                    break;

                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD, false);
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("SuccessfullyLoggedIn")), true);
                    app.WaitForNoElement(e => e.Property("text").StartsWith(app.GetLabel("SuccessfullyLoggedIn")), timeout: TimeSpan.FromSeconds(45));
                    app.TapProfile();
                    app.WaitForElement("content_account_info");
                    app.ScrollDownTo("button_sign_out_account_info");
                    app.TapOption("button_sign_out_account_info");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("SuccessfullyLoggedOut")), true);
                    break;
            }
        }
    }
}


 