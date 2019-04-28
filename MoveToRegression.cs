using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.UITest;

/* These tests are to be moved to regression
 * 
 * 
namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Xamarin.UITest.Platform.Android)]
    [TestFixture(Xamarin.UITest.Platform.iOS)]

    //GBFS
    public class GBFS : Test
    {
        public GBFS(Xamarin.UITest.Platform platform) : base(platform) { }
        IWebDriver driver;

        public void adminChangeLocation()
        {
            //open web browser
            driver = new ChromeDriver("C:\\dev");

            //login
            driver.Url = "https://admin-den.smartbikedev.com/Admin/Program/SubscriptionTypeList.aspx";
            driver.FindElement(By.CssSelector("input[id = 'ctl00_body_ctlLogOn_UserName']")).SendKeys("bcycle_wwong");
            driver.FindElement(By.CssSelector("input[id = 'ctl00_body_ctlLogOn_Password']")).SendKeys("%fG5lPA8HilZ");
            driver.FindElement(By.CssSelector("input[name='ctl00$body$ctlLogOn$Login']")).Click();

            //select red barn
            driver.FindElement(By.CssSelector("select[id='ctl00_body_ctlSelectProgram_ddlPrograms']")).Click();
            driver.FindElement(By.CssSelector("option[value='4576']")).Click();
            driver.FindElement(By.CssSelector("input[name='ctl00$body$ctlSelectProgram$btnSelectProgram']")).Click();

            //get to membership types
            driver.Url = "https://admin-den.smartbikedev.com/Admin/Program/SubscriptionTypeEdit.aspx?id=2310168";

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input[id = 'name']")).Clear();
            driver.FindElement(By.CssSelector("input[id = 'name']")).SendKeys(MEMBERSHIP_NAME);
            Thread.Sleep(3000);

            //scroll to and click the save button
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.CssSelector("button[id='save-btn']"))).Perform();
            driver.FindElement(By.CssSelector("button[id='save-btn']")).Click();

            //open mobile app

        }

        [Test]
        public void Verify_Membership_Edit()
        {
            app = AppInitializer.StartApp(platform);
            AppExtension.SetPlatform(platform);

            switch (platform)
            {
                case Xamarin.UITest.Platform.Android:
                    //Join BCycle on RedBarn on app
                    app.WaitForElement(e => e.Text("See a list of all locations"), timeout: TimeSpan.FromSeconds(120));
                    app.Tap(e => e.Text("See a list of all locations"));
                    app.ScrollDownTo(c => c.All().Text("Red Barn"));
                    app.WaitForElement(e => e.Text("Red Barn"));
                    app.Tap(e => e.Text("Red Barn"));
                    app.SkipWalkthrough();
                    app.WaitForElement(e => e.Marked("item_profile_toolbar_menu"), timeout: TimeSpan.FromSeconds(120));
                    app.TapProfile();
                    app.WaitForElement(e => e.Text("Join BCycle"));
                    app.Tap(e => e.Text("Join BCycle"));

                    //Verify the new membership name is present
                    app.Assert(e => e.Text(MEMBERSHIP_NAME), true);
                    break;

                case Xamarin.UITest.Platform.iOS:
                    break;
            }
        }

        public void adminChangeLocationBack()
        {
            //open web browser
            driver = new ChromeDriver("C:\\dev");

            //login
            driver.Url = "https://admin-den.smartbikedev.com/Admin/Program/SubscriptionTypeList.aspx";
            driver.FindElement(By.CssSelector("input[id = 'ctl00_body_ctlLogOn_UserName']")).SendKeys("bcycle_wwong");
            driver.FindElement(By.CssSelector("input[id = 'ctl00_body_ctlLogOn_Password']")).SendKeys("%fG5lPA8HilZ");
            driver.FindElement(By.CssSelector("input[name='ctl00$body$ctlLogOn$Login']")).Click();

            //select red barn
            driver.FindElement(By.CssSelector("select[id='ctl00_body_ctlSelectProgram_ddlPrograms']")).Click();
            driver.FindElement(By.CssSelector("option[value='4576']")).Click();
            driver.FindElement(By.CssSelector("input[name='ctl00$body$ctlSelectProgram$btnSelectProgram']")).Click();

            //get to membership types
            driver.Url = "https://admin-den.smartbikedev.com/Admin/Program/SubscriptionTypeEdit.aspx?id=2310168";

            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("input[id = 'name']")).Clear();
            driver.FindElement(By.CssSelector("input[id = 'name']")).SendKeys("back to normal");
            Thread.Sleep(3000);

            //scroll to and click the save button
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.CssSelector("button[id='save-btn']"))).Perform();
            driver.FindElement(By.CssSelector("button[id='save-btn']")).Click();

            //open mobile app

        }



//every screenshot of the walkthrough
//pictures of the sign in screen

[Test]
public void Verify_Email_Reset_Password()
{
    switch (platform)
    {
        case Platform.Android:
            app.TapAllLocations();
            app.GoTo(SYSTEM);
            app.SkipWalkthrough();
            app.TapProfile();
            app.WaitForElement(e => e.Text("Sign In"));
            app.Tap(e => e.Text("Forgot password?"));
            app.TapOption("edit_text_location_forgot_password");
            app.WaitForElement("content_location_list_item_template");
            app.GoTo(SYSTEM);
            app.EnterTextAndDismissKeyboard("edit_text_user_forgot_password", USERNAME);
            app.TapOption("button_reset_forgot_password");
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
            app.EnterTextAndDismissKeyboard("username", EMAIL);
            app.TapOption("button_send_forgot_password");

            //are will still sending a reset password confirmation?
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("ResetPasswordConfirmation")), true);
            break;
    }
}

        [Test]
        public void Verify_Bike_Check_Out_Far_Location_Then_Close_Location()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL_REDBARN, EMAIL_PASSWORD_REDBARN);
                    app.EnableTest();
                    app.Invoke("TapPinOnMap", DASH_STATION);
                    app.Assert("fab_navigate_station_details", true);
                    app.Device.SetLocation(OGDEN_MARSHALL_LATITUDE, OGDEN_MARSHALL_LONGITUDE);
                    app.Assert("fab_checkout_station_details", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.WaitForElement("web_view_login");
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.EnableTest();
                    app.Invoke("TapStationPinOnMap:", DASH_STATION);
                    app.Assert(e => e.Marked("button_action_station_detail").Marked(app.GetLabel("GetDirections")), true);
                    app.Device.SetLocation(OGDEN_MARSHALL_LATITUDE, OGDEN_MARSHALL_LONGITUDE);
                    app.Assert(e => e.Marked("button_action_station_detail").Marked(app.GetLabel("GetABike")), true);
                    break;
            }
        }

        [Test]
        public void Verify_Bike_Check_Out_Is_Successful()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.Invoke("TapPinOnMap", DASH_STATION);
                    app.EnableTest();
                    app.TapOption("fab_checkout_station_details");
                    app.Checkout(VALID_DOCK);
                    app.Assert("text_dock_number_bike_checkout", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL_DASH, EMAIL_PASSWORD_DASH);
                    app.Invoke("TapStationPinOnMap:", DASH_STATION);
                    app.EnableTest();
                    app.TapOption("button_action_station_detail");
                    app.Checkout(VALID_DOCK);
                    app.Assert("text_bike_unlocked_checkout_success", true);
                    break;
            }
        }

        [Test]
        public void Verify_Bike_Check_Out_Fails()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.Invoke("TapPinOnMap", SYSTEM_STATION);
                    app.EnableTest();
                    app.TapOption("fab_checkout_station_details");
                    app.Checkout(INVALID_DOCK);
                    app.Assert("edit_text_bike_number_bike_checkout_alert", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.Invoke("TapStationPinOnMap:", DASH_STATION);
                    app.EnableTest();
                    app.TapOption("button_action_station_detail");
                    app.Checkout(INVALID_DOCK);
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("FailedToCheckoutBikeAtDock", INVALID_DOCK)), true);
                    break;
            }
        }


    [Test]
    public void Verify_Login_Logout_Username()
    {
        switch (platform)
        {
            case Platform.Android:
                app.CheckPage("toolbar_map", SYSTEM_DASH);
                app.TapProfile();
                app.Login(USERNAME, USERNAME_PASSWORD, false);
                app.Assert(e => e.Property("text").StartsWith(app.GetLabel("SuccessfullyLoggedIn")), true);
                app.TapProfile();
                app.WaitForElement("content_user_data_account_info");
                app.ScrollDownTo("text_sign_out_account_info");
                app.WaitForElement("text_sign_out_account_info");
                app.Tap(e => e.Text("SIGN OUT"));
                app.Assert(e => e.Property("text").StartsWith(app.GetLabel("Successfullyloggedout")), true);
                break;
            case Platform.iOS:
                app.SkipWalkthrough();
                app.GoTo(SYSTEM);
                app.TapProfile();
                app.Login(USERNAME, DEFAULT_PASSWORD, false);
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

/* UI for this is similar to above, moved to regression
[Test]
public void Verify_Invalid_Login_Username()
{
switch (platform)
{
    case Platform.Android:
        app.CheckPage("toolbar_map", SYSTEM_DASH);
        app.TapProfile();
        app.Login(INVALID_USERNAME, EMAIL_PASSWORD_REDBARN, false);
        app.Tap(e => e.Marked("Navigate up"));
        break;
    case Platform.iOS:
        app.SkipWalkthrough();
        app.GoTo(SYSTEM);
        app.TapProfile();
        app.Login(INVALID_USERNAME, DEFAULT_PASSWORD, false);
        app.Assert(e => e.WebView().Css("div.alert"), true);
        break;
}
}

[Test]
public void Verify_Valid_Login_Email_Incorrect_Location()
{
switch (platform)
{
    case Platform.Android:
        app.CheckPage("toolbar_map", SYSTEM);
        app.TapOption(app.GetLabel("Navigate up"));
        app.TapHamburgerMenu();
        app.Tap(e => e.Text("All Locations"));
        app.Tap(e => e.Marked("text_go_to_location_map"));
        app.GoTo(SYSTEM_DASH);
        app.TapProfile();
        app.Login(EMAIL_REDBARN, EMAIL_PASSWORD_REDBARN, true);

        //logout
        app.TapProfile();
        app.WaitForElement("content_user_data_account_info");
        app.ScrollDownTo("text_sign_out_account_info");
        app.WaitForElement("text_sign_out_account_info");
        app.Tap(e => e.Text("SIGN OUT"));
        break;

    case Platform.iOS:
        app.SkipWalkthrough();
        app.GoTo(SYSTEM_DASH);
        app.TapProfile();
        app.Login(EMAIL, EMAIL_PASSWORD, false);
        app.Assert(e => e.WebView().Css("div.alert"), true);
        break;
}
}


[Test]
public void Verify_Valid_Login_Username_Incorrect_Location()
{
app.Device.SetLocation(WATERLOO_LATITUDE, WATERLOO_LONGITUDE);
switch (platform)
{
    case Platform.Android:
        app.CheckPage("toolbar_map", SYSTEM_DASH);
        app.TapProfile();
        app.Login(USERNAME, USERNAME_PASSWORD, true);

        //logout
        app.TapProfile();
        app.WaitForElement("content_user_data_account_info");
        app.ScrollDownTo("text_sign_out_account_info");
        app.WaitForElement("text_sign_out_account_info");
        app.Tap(e => e.Text("SIGN OUT"));
        break;

    case Platform.iOS:
        app.SkipWalkthrough();
        app.GoTo(SYSTEM_DASH);
        app.TapProfile();
        app.Login(USERNAME, DEFAULT_PASSWORD, false);
        app.Assert(e => e.WebView().Css("div.alert"), true);
        break;
}
}

[Test]
public void Verify_Validate_Fields_In_Login()
{
    switch (platform)
    {
        case Platform.Android:
            app.CheckPage("toolbar_map", SYSTEM_DASH);
            app.TapProfile();
            app.TapOption(e => e.Css("button#signIn"));
            app.Assert("main_text", true);
            app.EnterText(e => e.Css("input#username"), EMAIL);
            app.TapOption(e => e.Css("button#signIn"));
            app.Assert("main_text", true);
            app.EnterText(e => e.Css("input#password"), EMAIL_PASSWORD);
            app.TapOption(e => e.Css("button#signIn"));
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("SuccessfullyLoggedIn")), true);
            break;
        case Platform.iOS:
            app.SkipWalkthrough();
            app.GoTo(SYSTEM);
            app.TapProfile();
            app.TapOption(e => e.Css("button#signIn"));  
            app.Assert(e => e.Css("div#errorDiv"), true);
            app.EnterText(e => e.Css("input#username"), EMAIL);
            app.DoubleTap("content_login");   
            app.TapOption(e => e.Css("button#signIn")); 
            app.Assert(e => e.Css("div#errorDiv"), true);              
            app.EnterText(e => e.Css("input#password"), EMAIL_PASSWORD);
            app.DoubleTap("content_login");
            app.TapOption(e => e.Css("button#signIn"));
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("SuccessfullyLoggedIn")), true);
            break;
    }
}

            /* Similar to test above
        [Test]
        public void Verify_Renew_Membership_With_Promo_Code()
        {
            //this test needs valid promo codes for Madison and RedBarn
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL_MADISON, EMAIL_PASSWORD_MADISON);
                    app.TapProfile();
                    app.WaitForElement("content_user_data_account_info");
                    app.ScrollDownTo("text_renew_membership_account_info");
                    app.TapOption("text_renew_membership_account_info");
                    app.LoginOnlyPassword(EMAIL_PASSWORD_MADISON);
                    app.TapOption("text_name_membership_plan_list_item_template");
                    app.WaitForElement("content_main_review_membership");                
                    app.ScrollTo("edit_text_promo_code_review_membership");
                    //
                    //app.EnterTextAndDismissKeyboard("edit_text_promo_code_review_membership", VALID_PROMO_CODE);
                    app.TapOption("text_apply_review_membership");
                    app.Assert("text_promo_code_saved_review_membership", true);
                    app.TapOption("button_buy_now_review_membership"); 
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("MembershipRenewalSuccessfullyCompleted")), true);
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
                    app.LoginOnlyPassword(EMAIL_PASSWORD_MADISON);
                    app.WaitForElement("cell_membership_type_membership_plan");
                    app.TapOption("cell_membership_type_membership_plan");
                    app.WaitForElement("content_review_membership");
                    app.ScrollTo("renew_membership_promo_code");
                    app.EnterTextAndDismissKeyboard("renew_membership_promo_code", VALID_PROMO_CODE);
                    app.TapOption("button_apply_account_apply_promo_code_cell");
                    app.Assert("button_account_remove_promo_code_cell", true);                  
                    app.TapOption("button_buy_now_review_membership");   
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("MembershipRenewalSuccessfullyCompleted")), true); 
                    break;
            }
        }



        /* This is currently being redesigned

        [Test]
        public void Verify_Edit_Profile()
        {
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
                    //needs an if it asks for passward, then do the following otherwise apss
                    app.LoginOnlyPassword(EMAIL_PASSWORD_EDIT);
                    app.WaitForElement("content_edit_account");
                    app.TapOption(app.GetLabel("NavigateUp"));
                    app.TapOption("image_payment_account_info");
                    app.FillFieldsEdit(includeDashPinCode: false);
                    app.TapOption(app.GetLabel("Done"));
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
                    app.TapProfile();
                    app.TapOption(app.GetLabel("EditProfile"));
                    app.RevertFields(includeDashPinCode: false);
                    app.TapOption(app.GetLabel("Done"));
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.TapOption("button_edit_acount_info");                 
                    app.LoginOnlyPassword(EMAIL_PASSWORD);
                    app.FillFieldsEdit();
                    app.TapAndAssert("button_save_edit_account", e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")));                
                    break;
            }
        }


    [Test]
    public void Verify_Cancel_Edit_Profile()
    {
        switch (platform)
        {
            case Platform.Android:
                //app.TapAllLocations();
                app.TapOption("Go to " + SYSTEM);
                app.SkipWalkthrough();
                app.TapProfile();
                app.Login(EMAIL_MADISON, EMAIL_PASSWORD_MADISON);
                app.TapProfile();
                app.TapOption(app.GetLabel("EditProfile"));
                app.LoginOnlyPassword(EMAIL_PASSWORD_MADISON);
                app.WaitForElement("content_edit_account");
                app.TapOption(app.GetLabel("NavigateUp"));
                app.Assert("content_account_detail", true);
                break;
            case Platform.iOS:
                app.SkipWalkthrough();
                app.GoTo(SYSTEM);
                app.TapProfile();
                app.Login(EMAIL, EMAIL_PASSWORD);
                app.TapProfile();
                app.TapOption("button_edit_acount_info");
                app.LoginOnlyPassword(EMAIL_PASSWORD);
                app.WaitForElement("edit_text_account_edit_cell");
                app.TapOption("button_cancel_edit_account");
                app.Assert("mapview_map", true);
                break;
        }
    }

[Test]
public void Verify_Validate_Fields_In_Edit_Profile()
{
    switch (platform)
    {
        case Platform.Android:
            app.SkipWalkthrough();
            app.GoTo(SYSTEM);
            app.TapProfile();
            app.Login(EMAIL, EMAIL_PASSWORD);
            app.TapProfile();
            app.TapOption(app.GetLabel("EditProfile"));
            app.LoginOnlyPassword(EMAIL_PASSWORD); 
            //This needs work
            app.ValidateFieldsEdit();
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
            break;
        case Platform.iOS:
            app.SkipWalkthrough();
            app.GoTo(SYSTEM);
            app.TapProfile();
            app.Login(EMAIL, EMAIL_PASSWORD);
            app.TapProfile();        
            app.TapOption("button_edit_acount_info");
            app.LoginOnlyPassword(EMAIL_PASSWORD);
            app.ValidateFieldsEdit();
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
            break;
    }
}

[Test]
public void Verify_Validate_Fields_In_Edit_Dash_Profile()
{
    app.Device.SetLocation(WATERLOO_LATITUDE, WATERLOO_LONGITUDE);
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

            //This needs work
            app.ValidateFieldsEdit(includeDashPinCode:true);
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);

            break;
        case Platform.iOS:
            app.SkipWalkthrough();
            app.GoTo(SYSTEM_DASH);                 
            app.TapProfile();
            app.Login(EMAIL_REDBARN, DEFAULT_PASSWORD);
            app.TapProfile();             
            app.TapOption("button_edit_acount_info");
            app.LoginOnlyPassword(DEFAULT_PASSWORD);
            app.ValidateFieldsEdit(includeDashPinCode:true);
            app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyUpdated")), true);
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
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.WaitForElement("web_view_login");
                    app.WaitForElement("text_join_bcycle_login");
                    app.TapOption("text_join_bcycle_login");
                    app.TapOption("text_name_membership_plan_list_item_template");
                    app.TapOption("button_maybe_later_membership_card_request");
                    app.WaitForElement("content_firstname_create_account");
                    app.FillFieldsRegistration();
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
                    app.FillFieldsRegistration();
                    app.TapOption("button_next_create_account");
                    app.WaitForElement("content_review_membership");                
                    app.ScrollToAndTap("toggle_terms_account_terms_cell");
                    app.ScrollToAndTap("button_buy_now_review_membership");
                    app.Assert(e => e.Property("text").StartsWith(app.GetLabel("AccountSuccessfullyCreated")), true);                
                    break;
            }
        }


        [Test]
        public void Verify_Cancel_Registration()
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
                    app.FillFieldsRegistration(includeDashPinCode: true);
                    app.TapOption("button_continue_create_account");
                    app.TapOption(e => e.Id("toolbar_review_membership").Class("ImageButton"));
                    app.WaitForElement(app.GetLabel("CancelRegistration"));
                    app.TapOption(app.GetLabel("Yes"));
                    app.Assert("mapview_map", true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();                   
                    app.TapOption("bar_button_join_bcycle_login");                  
                    app.TapOption("cell_membership_type_membership_plan");
                    app.FillFieldsRegistration();
                    app.TapOption("button_next_create_account");
                    app.WaitForElement("content_review_membership");
                    app.TapOption(app.GetLabel("Cancel"));
                    app.WaitForElement(e => e.Text(app.GetLabel("CancelRegistration")));
                    app.TapOption(app.GetLabel("Yes"));
                    app.Assert("mapview_map", true);
                    break;
            }
        }

        /* combined with test above for interest of time

        [Test]
        public void Verify_Cancel_Dash_Registration()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapProfile();

                    //sometimes this button won't respond because of webview?
                    app.WaitForElement("web_view_login");
                    app.WaitForElement("text_join_bcycle_login");
                    app.TapOption("text_join_bcycle_login");
                    app.TapOption("text_name_membership_plan_list_item_template");
                    app.FillFieldsRegistration(includeDashPinCode:true);
                    app.TapOption("button_continue_create_account");                   
                    app.TapOption(e => e.Id("toolbar_review_membership").Class("ImageButton"));
                    app.WaitForElement(app.GetLabel("CancelRegistration"));
                    app.TapOption(app.GetLabel("Yes"));
                    app.Assert("mapview_map", true);
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
                    app.TapOption(app.GetLabel("Cancel"));
                    app.WaitForElement(e => e.Text(app.GetLabel("CancelRegistration")));
                    app.TapOption(app.GetLabel("Yes"));
                    app.Assert("mapview_map", true);
                    break;
            }
        }
        */


/* Move to regression tests

[Test]
public void Verify_Validate_Fields_In_Registration_With_Membership_Card()
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

        app.ValidateFieldsRegistration(includeMembership: true);
        //app.TapOption("text_name_membership_plan_list_item_template");
        //app.TapOption("button_buy_rfid_card_membership_card_request");
        app.Assert("content_review_membership", true);
        break;
    case Platform.iOS:
        app.SkipWalkthrough();
        app.GoTo(SYSTEM);
        app.TapProfile();
        app.TapOption("bar_button_join_bcycle_login");
        app.WaitForElement("cell_membership_type_membership_plan");
        app.TapOption("cell_membership_type_membership_plan");
        app.TapOption("button_buy_rfid_card_membership_card_request");
        app.ValidateFieldsRegistration(includeMembership:true);
        app.Assert("content_review_membership", true);
        break;
}
}

[Test]
public void Verify_Validate_Fields_In_Registration()
{
switch (platform)
{
    case Platform.Android:
        app.SkipWalkthrough();
        app.GoTo(SYSTEM);
        app.TapProfile();
        app.WaitForElement("web_view_login");
        app.WaitForElement("text_join_bcycle_login");
        app.TapOption("text_join_bcycle_login");            
        app.TapOption("text_name_membership_plan_list_item_template");
        app.TapOption("button_maybe_later_membership_card_request");
        app.ValidateFieldsRegistration();
        app.Assert("content_review_membership", true);
        break;
    case Platform.iOS:
        app.SkipWalkthrough();
        app.GoTo(SYSTEM);
        app.TapProfile();      
        app.TapOption("bar_button_join_bcycle_login");
        app.WaitForElement("cell_membership_type_membership_plan");
        app.TapOption("cell_membership_type_membership_plan");
        app.TapOption("button_maybe_later_membership_card_request");
        app.ValidateFieldsRegistration();
        app.Assert("content_review_membership", true);
        break;
}
}

[Test]
public void Verify_Validate_Fields_In_Dash_Registration()
{
switch (platform)
{
    case Platform.Android:
        app.SkipWalkthrough();
        app.WaitForElement(app.GetLabel("SeeListOfAllLocations"), timeout: TimeSpan.FromSeconds(45));
        app.TapOption(app.GetLabel("SeeListOfAllLocations"));
        app.WaitForElement("content_location_list_item_template");
        app.ScrollDownTo(e => e.Id("name_location_list_item_template").Marked(SYSTEM_DASH));
        app.TapOption(e => e.Id("name_location_list_item_template").Marked(SYSTEM_DASH));
        app.WaitForElement("item_profile_toolbar_menu", timeout: TimeSpan.FromSeconds(45));
        app.TapOption("item_profile_toolbar_menu");
        app.WaitForElement("web_view_login");
        app.WaitForElement("text_join_bcycle_login");
        app.TapOption("text_join_bcycle_login");
        app.WaitForElement("text_name_membership_plan_list_item_template");
        app.TapOption("text_name_membership_plan_list_item_template");
        app.ValidateFieldsRegistration(includeDashPinCode:true);                   
        app.Assert("content_review_membership", true);
        break;
    case Platform.iOS:
        app.SkipWalkthrough();
        app.WaitForElement(app.GetLabel("SeeListOfAllLocations"), timeout: TimeSpan.FromSeconds(45));
        app.TapOption(app.GetLabel("SeeListOfAllLocations"));
        app.ScrollDownTo(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
        app.TapOption(e => e.Id("cell_location_list").Text(SYSTEM_DASH));
        app.WaitForElement("bar_button_profile_map", timeout: TimeSpan.FromSeconds(45));
        app.TapOption("bar_button_profile_map");
        app.WaitForElement("web_view_login");
        app.WaitForElement("bar_button_join_bcycle_login");
        app.TapOption("bar_button_join_bcycle_login");
        app.WaitForElement("cell_membership_type_membership_plan");
        app.TapOption("cell_membership_type_membership_plan");
        app.ValidateFieldsRegistration(includeDashPinCode:true);  
        app.Assert("content_review_membership", true);
        break;

}
}

    */
