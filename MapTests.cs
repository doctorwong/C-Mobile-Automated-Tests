using NUnit.Framework;
using System;
using Xamarin.UITest;

/* revisit these when map is redesigned

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class MapTests : Test
    {
        public MapTests(Platform platform) : base(platform) { }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            AppExtension.SetPlatform(platform);
        }

        [Test]
        public void Verify_Popup_Options_For_Location()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.WaitForElement("mapview_map", timeout: TimeSpan.FromSeconds(45));
                    app.Invoke("TapPinOnMap", SYSTEM);
                    app.WaitForElement("select_dialog_listview");
                    app.Assert(app.GetLabel("GoToLocation", SYSTEM), true);
                    app.Assert(app.GetLabel("SelectDifferentLocationOnMap"), true);
                    app.Assert(app.GetLabel("SeeListOfAllLocations"), true);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.Invoke("TapLocationPinOnMap:", SYSTEM);
                    app.WaitForElement(app.GetLabel("GoToLocation", SYSTEM), timeout: TimeSpan.FromSeconds(45));
                    app.Assert(app.GetLabel("GoToLocation", SYSTEM), true);
                    app.Assert(app.GetLabel("SelectDifferentLocationOnMap"), true);
                    app.Assert(app.GetLabel("SeeListOfAllLocations"), true);
                    break;
            }
        }

        [Test]
        public void Verify_Select_System_By_Pin()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.WaitForElement("mapview_map", timeout: TimeSpan.FromSeconds(45));
                    app.Screenshot("Map showing all locations");
                    app.Invoke("TapPinOnMap", SYSTEM);
                    app.WaitForElement(e => e.Text("Go to " + SYSTEM));
                    app.Tap(e => e.Text("Go to " + SYSTEM));
                    app.SkipWalkthrough();
                    app.Screenshot($"Map showing {SYSTEM} stations");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.WaitForElement("mapview_map", timeout: TimeSpan.FromSeconds(45));
                    app.Screenshot("Map showing all locations");
                    app.Invoke("TapLocationPinOnMap:", SYSTEM);
                    app.GoTo(SYSTEM);
                    app.Screenshot($"Map showing {SYSTEM} stations");
                    break;
            }
        }

        [Test]
        public void Verify_Map_Zoom_See_A_List()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.Screenshot("Before selecting a location");
                    app.TapOption(app.GetLabel("SeeListOfAllLocations"));
                    app.TapOption(e => e.Id("name_location_list_item_template").Text(SYSTEM));
                    app.WaitForElement("fab_gps_fixed_map");
                    app.Screenshot($"Map after selecting {SYSTEM}");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.Screenshot("Before selecting a location");
                    app.TapOption(app.GetLabel("SeeListOfAllLocations"));
                    app.TapOption(e => e.Id("cell_location_list").Text(SYSTEM));
                    app.WaitForElement("bar_button_center_map");
                    app.Screenshot($"Map after selecting {SYSTEM}");
                    break;
            }
        }

        [Test]
        public void Verify_Map_Zoom_Or_See_A_List()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.WaitForElement("mapview_map", timeout: TimeSpan.FromSeconds(45));
                    app.Screenshot("Map before selecting a location");
                    app.TapOption("text_go_to_location_map");
                    app.TapOption(e => e.Id("name_location_list_item_template").Marked(SYSTEM));
                    app.WaitForElement("fab_gps_fixed_map");
                    app.Screenshot($"Map after selecting {SYSTEM}");
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.WaitForElement("mapview_map", timeout: TimeSpan.FromSeconds(45));
                    app.Screenshot("Map before selecting a location.");
                    app.TapOption("text_or_tap_here_locations_map");
                    app.TapOption(e => e.Id("cell_location_list").Text(SYSTEM));
                    app.WaitForElement("bar_button_center_map");
                    app.Screenshot($"Map after selecting {SYSTEM}");
                    break;
            }
        }
        
        [Test]
        public void Verify_List_Of_Locations()
        {
            switch (platform)
            {
                case Platform.Android:
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.TapOption("text_go_to_location_map");
                    app.WaitForElement("content_location_list_item_template");
                    foreach (var location in Locations)
                    {
                        app.ScrollDownTo(location, null, ScrollStrategy.Gesture, 0.4, 100);
                        app.Assert(location, true);
                    }
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.TapOption(app.GetLabel("SelectDifferentLocationOnMap"));
                    app.TapOption("text_or_tap_here_locations_map");
                    app.WaitForElement("cell_location_list");
                    foreach (var location in Locations)
                    {
                        app.ScrollDownTo(location, null, ScrollStrategy.Gesture, 0.4, 100);
                        app.Assert(location, true);
                    }
                    break;
            }
        }
    }
}

    */