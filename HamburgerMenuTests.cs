using NUnit.Framework;
using System;
using System.Diagnostics;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class HamburgerMenuTests : Test
    {
		public HamburgerMenuTests(Platform platform) : base(platform) { }

        [Test]
        public void Verify_All_Locations_Option()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.TapOption("All Locations");
                    app.Screenshot("Hamburger Menu: All Locations").MoveTo($"C:\\Screenshots\\HamburgerMenu_AllLocations__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Marked("text_go_to_location_map"), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("AllLocations")));
                    app.Assert("text_or_tap_here_locations_map", true);
                    break;
            }
        }

        [Test]
        public void Verify_Hamburger_Menu_Options_Not_Signed_In_With_Location()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapAllLocations();
                    app.GoTo(SYSTEM_DASH);
                    app.SkipWalkthrough();
                    app.TapHamburgerMenu();
                    app.Screenshot("Hamburger Menu: Not Signed In").MoveTo($"C:\\Screenshots\\HamburgerMenu_NoSignInNoLocation__{Guid.NewGuid()}.png"); ;
                    app.Assert("text_sign_in_nav_header", true);
                    app.Assert("text_new_to_bcycle_nav_header", true);
                    app.Assert("text_join_now_nav_header", true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Map")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Stations")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("About")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("AllLocations")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Support")), true);
                    break;

                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();
                    app.Assert("button_sign_in_main_menu", true);
                    app.Assert("button_new_to_bcycle_main_menu", true);
                    app.Assert("button_join_now_main_menu", true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Map")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Stations")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("About")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("AllLocations")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")), true);
                    break;
            }
        }

        [Test]
        public void Verify_Hamburger_Menu_Options_Signed_In()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL_DASH, EMAIL_PASSWORD_DASH);
                    app.TapHamburgerMenu();
                    app.Screenshot("Hamburger Menu: Signed In").MoveTo($"C:\\Screenshots\\HamburgerMenu_SignedIn__{Guid.NewGuid()}.png");
                    app.Assert("text_fullname_nav_header", true);

                    //check if "Renew Membership" is displayed? and if not, then check for nav_header?
                    app.Assert("text_user_plan_nav_header", true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Map")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Stations")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("About")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("AllLocations")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Support")), true);
                    app.TapOption("fab_gps_fixed_map");
                    break;

                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL_DASH, EMAIL_PASSWORD_DASH);
                    app.TapHamburgerMenu();
                    app.Assert("button_fullname_main_menu", true);
                    app.Assert("button_membership_main_menu", true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Map")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Stations")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("About")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("AllLocations")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Support")), true);
                    break;
            }
        }

        [Test]
        public void Verify_Hamburger_Menu_Options_Without_Location()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.TapOption("Select a different location on map");
                    app.TapHamburgerMenu();
                    app.Screenshot("Hamburger Menu: No Location").MoveTo($"C:\\Screenshots\\HamburgerMenu_NoLocation__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("Map")), true);
                    app.Assert(e => e.Id("design_menu_item_text").Marked(app.GetLabel("AllLocations")), true);
                    break;

                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.Tap(e => e.Text("Select a different location on map"));
                    app.TapHamburgerMenu();    
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Map")), true);
                    app.Assert(e => e.Id("cell_text_main_menu").Text(app.GetLabel("AllLocations")), true);
                    break;
            }
        }

        [Test]
        public void Verify_Map_Option()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapHamburgerMenu();
                    app.Assert(e => e.Id("design_menu_item_text"), true);
                    app.Assert("mapview_map", true);
                    app.TapOption("fab_gps_fixed_map");
                    app.Screenshot("Hamburger Menu: Map Option").MoveTo($"C:\\Screenshots\\Maps_DashMap__{Guid.NewGuid()}.png");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();   
                    app.Assert("button_close_main_menu", true);
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Map")));  
                    app.Assert("button_close_main_menu", false);
                    app.Assert("mapview_map", true);                  
                    break;
            }
        }

        [Test]
        public void Verify_Stations_Option()
        {
            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.RestartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.CheckLocation(SYSTEM);
                    app.TapHamburgerMenu();
                    app.TapOption("Stations");
                    app.Screenshot("Hamburger Menu: Stations List").MoveTo($"C:\\Screenshots\\Stations_StationsList__{Guid.NewGuid()}.png");
                    app.TapOption("search_button");
                    app.EnterTextAndDismissKeyboard("search_src_text", SYSTEM_STATION);   
                    app.Assert(e => e.Id("text_name_station_list_item_template").Marked(SYSTEM_STATION), true);
                    app.Tap(e => e.Text(SYSTEM_STATION));
                    app.Screenshot("Stations: Station Details").MoveTo($"C:\\Screenshots\\Stations_StationDetails__{Guid.NewGuid()}.png");


                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapHamburgerMenu();  
                    app.TapOption(e => e.Id("cell_text_main_menu").Text(app.GetLabel("Stations")));
                    app.EnterTextAndDismissKeyboard("search_station_list", SYSTEM_STATION);    
                    app.Assert(e => e.Id("cell_text_station_list").Marked(SYSTEM_STATION), true);
                    break;
            }
        }
    }
}