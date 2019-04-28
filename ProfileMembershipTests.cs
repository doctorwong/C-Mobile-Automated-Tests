using NUnit.Framework;
using System;
using System.Threading;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class ProfileMembershipTests : Test
    {
		public ProfileMembershipTests(Platform platform) : base(platform) { }

        [Test]
        public void Verify_Membership_Renewal()
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
                    app.Login(EMAIL_DASH, EMAIL_PASSWORD_DASH);
                    app.TapProfile();
                    app.WaitForElement("content_user_data_account_info");
                    app.ScrollDownTo("text_renew_membership_account_info");
                    app.TapOption("text_renew_membership_account_info");
                    app.Screenshot("Reenter Password").MoveTo($"C:\\Screenshots\\Renewal_ReenterPassword__{Guid.NewGuid()}.png");
                    app.LoginOnlyPassword(EMAIL_PASSWORD_DASH);             
                    app.TapOption("Barn365");
                    app.WaitForElement("content_main_review_membership");
                    app.Screenshot("Review Screen").MoveTo($"C:\\Screenshots\\Renewal_ReviewScreen__{Guid.NewGuid()}.png");
                    app.ScrollToAndTap("check_eula_review_membership");            
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.Screenshot("AgreeToTerms").MoveTo($"C:\\Screenshots\\Renewal_AgreeToTerms__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Id("message").Property("text").StartsWith(app.GetLabel("IAgreeToTerms")), true);
                    app.TapOption(app.GetLabel("Ok"));
                    app.TapOption("check_eula_review_membership");
                    app.TapOption("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("MembershipRenewalSuccessfullyCompleted")), true);
                    app.Screenshot("RenewSuccessful").MoveTo($"C:\\Screenshots\\Renewal_RenewSuccessful__{Guid.NewGuid()}.png");

                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.WaitForElement("content_account_info");
                    app.ScrollToAndTap("button_renew_account_detail_ride_cell");                 
                    app.LoginOnlyPassword(EMAIL_PASSWORD);
                    app.TapOption("cell_membership_type_membership_plan");
                    app.WaitForElement("content_review_membership");              
                    app.ScrollToAndTap("toggle_terms_account_terms_cell");                  
                    app.ScrollToAndTap("button_buy_now_review_membership");  
                    app.Assert(e => e.Property("text").StartsWith("Error"), true);                   
                    app.TapOption(app.GetLabel("Ok"));
                    app.TapOption("toggle_terms_account_terms_cell");
                    app.TapOption("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("MembershipRenewalSuccessfullyCompleted")), true);
                    break;                  
            }
        }

        [Test]
        public void Verify_Membership_Renewal_Cancellation()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("fab_bike_checkout_map", SYSTEM_DASH);
                    app.TapProfile();
                    app.WaitForElement("content_user_data_account_info");
                    app.ScrollDownTo("text_renew_membership_account_info");
                    app.TapOption("text_renew_membership_account_info");
                    app.TapOption(e => e.Id("toolbar_membership_plan").Class("ImageButton"));
                    app.WaitForElement(app.GetLabel("CancelRenewal"));
                    app.Screenshot("Cancel Renewal Confirmation").MoveTo($"C:\\Screenshots\\Renewal_CancelRenewal__{Guid.NewGuid()}.png");
                    app.TapOption(app.GetLabel("Yes"));
                    app.WaitForElement("mapview_map");
                    app.Assert("mapview_map", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.WaitForElement("content_account_info");
                    app.ScrollDownTo("button_renew_account_detail_ride_cell");
                    app.TapOption("button_renew_account_detail_ride_cell");
                    app.LoginOnlyPassword(EMAIL_PASSWORD);
                    app.WaitForElement("cell_membership_type_membership_plan");
                    app.TapOption(app.GetLabel("Cancel"));
                    app.WaitForElement(app.GetLabel("CancelRenewal"));
                    app.TapOption(app.GetLabel("Yes"));
                    app.Assert("mapview_map", true);
                    break;
            }
        }

        [Test]
        public void Verify_Profile_Summary()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("fab_bike_checkout_map", SYSTEM_DASH);
                    app.TapProfile();
                    app.WaitForElement("content_user_data_account_info");
                    app.Screenshot("ProfileSummaryTop").MoveTo($"C:\\Screenshots\\Profile_ProfileSummaryTop__{Guid.NewGuid()}.png");
                    app.ScrollDownTo("text_renew_membership_account_info");
                    app.Assert("text_renew_membership_account_info", true);
                    //app.ScrollDownTo("text_request_rfid_account_info");
                    //app.Assert("text_request_rfid_account_info", true);               
                    app.ScrollDownTo("text_my_statements_account_info");
                    app.Assert("text_my_statements_account_info", true);
                    app.ScrollDownTo("text_sign_out_account_info");
                    app.Screenshot("ProfileSummaryBottom").MoveTo($"C:\\Screenshots\\Profile_ProfileSummaryBottom__{Guid.NewGuid()}.png");
                    app.Assert("text_sign_out_account_info", true);
                    app.TapOption("Navigate up");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.WaitForElement("content_account_info");
                    app.ScrollDownTo("button_renew_account_detail_ride_cell");
                    app.Assert("button_renew_account_detail_ride_cell", true);
                    app.ScrollDownTo("button_request_rfid_account_detail_ride_cell");
                    app.Assert("button_request_rfid_account_detail_ride_cell", true);
                    app.ScrollDownTo("button_my_statements_account_user_statements_cell");
                    app.Assert("button_my_statements_account_user_statements_cell", true);
                    app.ScrollDownTo("button_sign_out_account_info");
                    app.Assert("button_sign_out_account_info", true);
                    break;
            }
        }

        [Test]
        public void Verify_Profile_Summary_Statements()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("fab_bike_checkout_map", SYSTEM_DASH);
                    app.TapProfile();
                    app.ScrollToAndTap("text_my_statements_account_info");
                    app.Screenshot("MyStatements").MoveTo($"C:\\Screenshots\\Profile_MyStatements__{Guid.NewGuid()}.png");
                    app.Assert("text_amount_user_statements_item_template", true);
                    app.TapOption("Navigate up");
                    app.TapOption("Navigate up");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.WaitForElement("content_account_info");
                    app.ScrollToAndTap("button_renew_account_detail_ride_cell");
                    app.LoginOnlyPassword(EMAIL_PASSWORD);
                    app.TapOption("cell_membership_type_membership_plan");
                    app.WaitForElement("content_review_membership");
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.WaitForElement(e => e.Property("text").StartsWith(app.GetLabel("MembershipRenewalSuccessfullyCompleted")), timeout: TimeSpan.FromSeconds(45));
                    app.WaitForNoElement(e => e.Property("text").StartsWith(app.GetLabel("MembershipRenewalSuccessfullyCompleted")), timeout: TimeSpan.FromSeconds(45));
                    app.TapProfile();
                    app.ScrollToAndTap("button_my_statements_account_user_statements_cell");
                    app.Assert("cell_user_statements", true);
                    int index = DateTime.Today.Day == 1 ? 1 : 0;
                    app.TapOption(e => e.Class("Factorymind_Components_CalendarDayView").Index(index));
                    app.Assert("cell_user_statements", false);
                    break;
            }
        }

        [Test]
        public void Verify_Trips_Visualization()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("fab_bike_checkout_map", SYSTEM_DASH);
                    app.TapProfile();
                    app.WaitForElement("content_user_data_account_info");
                    app.Invoke("CreateMockTrip");
                    app.SwipeRightToLeft();
                    app.SwipeRightToLeft();
                    app.WaitForElement("calendar_view_account_trips");
                    app.Screenshot("My Trips Screen").MoveTo($"C:\\Profile_MyTripsScreen__{Guid.NewGuid()}.png");
                    app.TapOption("2");
                    app.Assert("text_start_date_account_trip_template", false);
                    app.TapOption("1");
                    app.Assert("text_start_date_account_trip_template", true);
                    app.TapOption("text_start_date_account_trip_template");
                    app.Screenshot("Trip Details").MoveTo($"C:\\Profile_MyTrips_TripDetails__{Guid.NewGuid()}.png");


                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.TapOption("tabbar_item_my_trips_account_detail");
                    app.Invoke("CreateMockTrip");
                    app.TapOption(e => e.Class("Factorymind_Components_CalendarDayView").Index(1));
                    app.Assert("cell_trip_my_trips", false);
                    app.TapOption(e => e.Class("Factorymind_Components_CalendarDayView").Index(0));
                    app.Assert("cell_trip_my_trips", true);
                    break;
            }
        }
    }
        }

      