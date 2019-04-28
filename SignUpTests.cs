using NUnit.Framework;
using System;
using System.Threading;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class SignUpTests : Test
    {
        public SignUpTests(Platform platform) : base(platform) { }

        /*Registration in construction

        [Test]
        public void Verify_Card_Registration()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.WaitForElement("web_view_login");
                    app.WaitForElement("text_join_bcycle_login");
                    app.TapOption("text_join_bcycle_login");
                    app.TapOption("text_name_membership_plan_list_item_template");
                    app.TapOption("button_buy_rfid_card_membership_card_request");
                    app.WaitForElement("content_firstname_create_account");
                    app.FillFieldsRegistration(includeMembership: true, includeDashPinCode: true);
                    app.TapOption("button_continue_create_account");
                    app.WaitForElement("content_review_membership");
                    app.ScrollToAndTap("check_eula_review_membership");
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyCreated")), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.TapOption("bar_button_join_bcycle_login");
                    app.TapOption("cell_membership_type_membership_plan");
                    app.FillFieldsRegistration(includeMembership: true);
                    app.TapOption("button_next_create_account");
                    app.WaitForElement("content_review_membership");
                    app.ScrollToAndTap("toggle_terms_account_terms_cell");
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyCreated")), true);
                    break;
            }
        }


        [Test]
        public void Verify_Registration()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.WaitForElement("web_view_login");
                    app.WaitForElement("text_join_bcycle_login");
                    app.TapOption("text_join_bcycle_login");
                    app.TapOption("text_name_membership_plan_list_item_template");
                    app.WaitForElement("content_firstname_create_account");
                    app.FillFieldsRegistration(includeDashPinCode: true);
                    app.TapOption("button_continue_create_account");
                    app.WaitForElement("content_review_membership");
                    app.ScrollToAndTap("check_eula_review_membership");
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyCreated")), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SeeListOfAllLocations"));
                    app.ScrollDownToAndTap(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
                    app.TapProfile();
                    app.TapOption("bar_button_join_bcycle_login");
                    app.TapOption("cell_membership_type_membership_plan");
                    app.FillFieldsRegistration(includeDashPinCode: true);
                    app.TapOption("button_next_create_account");
                    app.WaitForElement("content_review_membership");
                    app.ScrollToAndTap("toggle_terms_account_terms_cell");
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyCreated")), true, 80);
                    break;
            }
        }

        [Test]
        public void Verify_Edit_Profile()
        {
            //duplicates verify_edit_profile? maybe we can set one to madison and one to redbarn?
            //editing every single field seems to take a while
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL_EDIT, EMAIL_PASSWORD_EDIT);
                    app.TapProfile();
                    app.TapOption(app.GetLabel("EditProfile"));
                    //needs an if it asks for passward, then do the following
                    app.LoginOnlyPassword(EMAIL_PASSWORD_EDIT);
                    app.WaitForElement("content_edit_account");
                    app.TapOption(app.GetLabel("NavigateUp"));
                    app.TapOption("image_payment_account_info");
                    app.FillFieldsEdit(includeDashPinCode: true);
                    app.TapOption(app.GetLabel("Done"));
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
                    app.TapProfile();
                    app.TapOption(app.GetLabel("EditProfile"));
                    app.RevertFields(includeDashPinCode: true);
                    app.TapOption(app.GetLabel("Done"));
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SeeListOfAllLocations"));
                    app.WaitForElement("cell_location_list");
                    app.ScrollDownTo(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
                    app.TapOption(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
                    app.TapProfile();
                    app.Login(EMAIL_EDIT, EMAIL_PASSWORD_EDIT);
                    app.TapProfile();
                    app.TapOption("button_edit_acount_info");
                    app.LoginOnlyPassword(DEFAULT_PASSWORD);
                    app.FillFieldsEdit(includeDashPinCode: true);
                    app.TapOption("button_save_edit_account");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
                    break;
            }
        }

        [Test]
        public void Verify_Edit_Dash_Profile_Cancellation()
        {
            //duplicates cancel_edit_profile?
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL_REDBARN, EMAIL_PASSWORD_REDBARN);
                    app.TapProfile();
                    app.TapOption(app.GetLabel("EditProfile"));
                    app.LoginOnlyPassword(EMAIL_PASSWORD_REDBARN);
                    app.WaitForElement("content_edit_account");
                    app.TapOption(app.GetLabel("NavigateUp"));
                    app.Assert("content_account_detail", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SeeListOfAllLocations"));
                    app.WaitForElement("cell_location_list");
                    app.ScrollDownToAndTap(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
                    app.TapProfile();
                    app.Login(EMAIL_REDBARN, DEFAULT_PASSWORD);
                    app.TapProfile();
                    app.TapOption("button_edit_acount_info");
                    app.LoginOnlyPassword(DEFAULT_PASSWORD);
                    app.WaitForElement("edit_text_account_edit_cell");
                    app.TapOption("button_cancel_edit_account");
                    app.Assert("mapview_map", true);
                    break;
            }
        }


        [Test]
        public void Verify_Card_Registration_Cancellation()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL_REDBARN, EMAIL_PASSWORD_REDBARN);
                    app.TapProfile();
                    app.TapOption(app.GetLabel("EditProfile"));
                    app.LoginOnlyPassword(EMAIL_PASSWORD_REDBARN);
                    app.WaitForElement("content_edit_account");
                    app.TapOption(app.GetLabel("NavigateUp"));
                    app.Assert("content_account_detail", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SeeListOfAllLocations"));
                    app.WaitForElement("cell_location_list");
                    app.ScrollDownToAndTap(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
                    app.TapProfile();
                    app.Login(EMAIL_REDBARN, DEFAULT_PASSWORD);
                    app.TapProfile();
                    app.TapOption("button_edit_acount_info");
                    app.LoginOnlyPassword(DEFAULT_PASSWORD);
                    app.WaitForElement("edit_text_account_edit_cell");
                    app.TapOption("button_cancel_edit_account");
                    app.Assert("mapview_map", true);
                    break;
            }
        }
        /*
    }
}
