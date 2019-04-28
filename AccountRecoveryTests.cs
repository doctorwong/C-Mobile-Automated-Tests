using NUnit.Framework;
using System;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
    public class AccountRecoveryTests : Test
    {		
        public AccountRecoveryTests(Platform platform) : base(platform) { }

        [Test]
        public void Verify_Contact_Customer_Service()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapProfile();
                    app.WaitForElement(e => e.Text("Sign In"));
                    app.Tap(e => e.Marked("text_forgot_password_login"));
                    app.Screenshot("Account Recovery: Reset Password Screen").MoveTo($"C:\\Screenshots\\AccountRecovery_ResetPasswordScreen__{Guid.NewGuid()}.png");
                    app.TapOption("text_contact_customer_service_forgot_password");
                    app.Assert(e => e.Marked("content_support_menu"), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.TapOption("bar_button_forgot_password_login");
                    app.TapOption("text_contact_customer_service_forgot_password");
                    app.Assert("content_support", true);
                    break;
            }
        }

        [Test]
        public void Verify_Join_BCycle()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapProfile();
                    app.WaitForElement(e => e.Text("Sign In"));
                    app.Tap(e => e.Text("Join BCycle"));
                    app.Assert(e => e.Marked("list_plans_membership_plan"), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.TapOption("bar_button_join_bcycle_login");
                    app.Assert("content_membership_plan", true);
                    break;
            }
        }

        [Test]
        public void Verify_Username_Reset_Password()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapProfile();
                    app.WaitForElement(e => e.Text("Sign In"));
                    app.Tap(e => e.Text("Forgot password?"));
                    app.TapOption("edit_text_location_forgot_password");
                    app.WaitForElement("content_location_list_item_template");
                    app.GoTo(SYSTEM);
                    app.EnterTextAndDismissKeyboard("edit_text_user_forgot_password", USERNAME);
                    app.TapOption("button_reset_forgot_password");
                    app.Screenshot("Account Recovery: Reset Password Confirmation Message").MoveTo($"C:\\Screenshots\\AccountRecovery_ResetPWConfirmation__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Id("alertTitle").Property("text").StartsWith(app.GetLabel("ResetPasswordConfirmation")), true);
                    app.TapOption("button1");
                    app.Assert(e => e.Text("Sign In"), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.TapOption("bar_button_forgot_password_login");
                    app.TapOption("button_select_location_forgot_password");      
                    app.WaitForElement("content_location_list", timeout: TimeSpan.FromSeconds(45));
                    app.TapElementInList(SYSTEM);
                    app.EnterTextAndDismissKeyboard("edit_text_username_forgot_password", USERNAME);
                    app.TapOption("button_send_forgot_password");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("ResetPasswordConfirmation")), true);                 
                    break;
            }
        }
    }
}