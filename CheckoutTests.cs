using NUnit.Framework;
using System;
using System.Threading;
using Xamarin.UITest;


namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class CheckoutTests : Test
    {
        public CheckoutTests(Platform platform) : base(platform) { }

        [Test]
        public void Classic_Checkouts_Station_Details()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapAllLocations();
                    app.GoTo(SYSTEM);
                    app.SkipWalkthrough();
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapHamburgerMenu();
                    app.TapOption("Debug Settings");
                    app.TapOption("switch_mock_proximity_debug");
                    app.TapOption("Navigate up");
                    app.TapOption("Stations");
                    app.TapOption("content_station_list_item_template");
                    //Assert Get Bike Icon commented out because no stations currently have bikes for checkout
                    app.Screenshot("Checkouts: Station Details Bike Icon").MoveTo($"C:\\Screenshots\\Checkouts_Station_Details_Bike_Icon__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.Invoke("TapStationPinOnMap:", DASH_STATION);
                    app.TapOption("bar_button_directions_map");
                    app.TapOption("BCycle");
                    app.Screenshot("BCycle Route");
                    app.TapOption(app.GetLabel("Walk"));
                    app.Screenshot("Walk Route");
                    app.Assert("BCycle", true);
                    app.Assert(app.GetLabel("Walk"), true);
                    app.Assert("bar_button_center_map", true);
                    break;
            }
        }


        /* Get Directions Button not responding consistently from stations
        [Test]
        public void Classic_Navigation()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.Repl();
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_MADISON);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption("Stations");
                    app.WaitForElement("text_name_station_list_item_template");
                    app.Tap("text_name_station_list_item_template");
                    app.TapOption("fab_navigate_station_details");
                    app.Screenshot("Navigation: Classic Route").MoveTo($"C:\\Screenshots\\Navigation_ClassicRoute{Guid.NewGuid()}.png");
                    app.TapOption("text_details_route_navigation_footer");
                    app.Screenshot("Navigation: Classic Route Details").MoveTo($"C:\\Screenshots\\Navigation_ClassicRouteDetails{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.Invoke("TapStationPinOnMap:", DASH_STATION);
                    app.TapOption("bar_button_directions_map");
                    app.TapOption("BCycle");
                    app.Screenshot("BCycle Route");
                    app.TapOption(app.GetLabel("Walk"));
                    app.Screenshot("Walk Route");
                    app.Assert("BCycle", true);
                    app.Assert(app.GetLabel("Walk"), true);
                    app.Assert("bar_button_center_map", true);
                    break;
            }
        }
        */

        [Test]
        public void Dash_Checkout()
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
                    app.WaitForElement("fab_bike_checkout_map");
                    app.Screenshot("Checkouts: Dash Bike Icon").MoveTo($"C:\\Screenshots\\Checkouts_DashLoggedIn__{Guid.NewGuid()}.png");
                    app.Assert("fab_bike_checkout_map", true);
                    app.TapOption("fab_bike_checkout_map");
                    app.Assert("edit_text_bike_number_bike_checkout_alert", true);
                    app.Screenshot("Checkouts: Dash Unlock Code Screen").MoveTo($"C:\\Screenshots\\Checkouts_DashUnlockCodeScreen__{Guid.NewGuid()}.png");
                    app.Checkout(INVALID_DOCK);
                    //Added because there is no selector for the "Failed to checkout Dash bike" error message
                    Thread.Sleep(3000);
                    app.Screenshot("Checkouts: Dash Unlock Code Error Screen").MoveTo($"C:\\Screenshots\\CheckOuts_DashUnlockCodeErrorScreen__{Guid.NewGuid()}.png");
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

      /* Current Potential Issues:
       * Get Dash Directions button not responding consistently from map (usually just when activated with a script)
       * Clicking Route Details occasionally brings me back to the map with no details
       * Clicking done from route details occasionally does not respond
 
        [Test]
        public void Dash_Navigation()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.CheckPageForElement("fab_directions_map", SYSTEM_MADISON);
                    app.TapOption("fab_directions_map");
                    app.TapOption("text_name_template_poi_cell");
                    app.Screenshot("Navigation: Dash BCycle Route").MoveTo($"C:\\Screenshots\\Navigation_DashBCycleRoute{Guid.NewGuid()}.png");
                    app.TapOption("WALK");
                    app.Screenshot("Navigation: Dash Walk Route").MoveTo($"C:\\Screenshots\\Navigation_DashWalkRoute{Guid.NewGuid()}.png");

                    app.TapOption("text_details_route_navigation_footer");
                    app.Screenshot("Navigation: Dash Route Details").MoveTo($"C:\\Screenshots\\Navigation_DashRouteDetails{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.Invoke("TapStationPinOnMap:", DASH_STATION);
                    app.TapOption("bar_button_directions_map");
                    app.TapOption("BCycle");
                    app.Screenshot("BCycle Route");
                    app.TapOption(app.GetLabel("Walk"));
                    app.Screenshot("Walk Route");
                    app.Assert("BCycle", true);
                    app.Assert(app.GetLabel("Walk"), true);
                    app.Assert("bar_button_center_map", true);
                    break;
            }
        }
        */
    }
}
 