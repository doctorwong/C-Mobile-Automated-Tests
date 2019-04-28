using NUnit.Framework;
using System.Linq;
using System;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class ProfileSettingsTests : Test
    {
		public ProfileSettingsTests(Platform platform) : base(platform) { }

        [Test]
        public void Verify_Settings_Toggle_Options()
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
                    app.SwipeRightToLeft();  
                    app.WaitForElement("toggle_send_push_account_settings");
                    app.Screenshot("Toggle Options Menu").MoveTo($"C:\\Screeenshots\\Profile_ToggleOptionsMenu__{Guid.NewGuid()}.png");
                    var sendPush = app.Query(e => e.Marked("toggle_send_push_account_settings").Invoke("isChecked").Value<bool>()).First();
                    var sendEmail = app.Query(e => e.Marked("toggle_send_email_account_settings").Invoke("isChecked").Value<bool>()).First();
                    var sendText = app.Query(e => e.Marked("toggle_send_text_messages_account_settings").Invoke("isChecked").Value<bool>()).First();
                    var trackTrips = app.Query(e => e.Marked("toggle_track_trips_account_settings").Invoke("isChecked").Value<bool>()).First();
                    var autoRefresh = app.Query(e => e.Marked("toggle_refresh_auto_account_settings").Invoke("isChecked").Value<bool>()).First();
                    app.TapOption("toggle_send_push_account_settings");
                    app.TapOption("toggle_send_email_account_settings");
                    app.TapOption("toggle_send_text_messages_account_settings");
                    app.TapOption("toggle_track_trips_account_settings");
                    app.TapOption("toggle_refresh_auto_account_settings");
                    var sendPushFinal = app.Query(e => e.Marked("toggle_send_push_account_settings").Invoke("isChecked").Value<bool>()).First();
                    Assert.AreEqual(!sendPush, sendPushFinal);
                    var sendEmailFinal = app.Query(e => e.Marked("toggle_send_email_account_settings").Invoke("isChecked").Value<bool>()).First();
                    Assert.AreEqual(!sendEmail, sendEmailFinal);
                    var sendTextFinal = app.Query(e => e.Marked("toggle_send_text_messages_account_settings").Invoke("isChecked").Value<bool>()).First();
                    Assert.AreEqual(!sendText, sendTextFinal);
                    var trackTripsFinal = app.Query(e => e.Marked("toggle_track_trips_account_settings").Invoke("isChecked").Value<bool>()).First();
                    Assert.AreEqual(!trackTrips, trackTripsFinal);
                    var autoRefreshFinal = app.Query(e => e.Marked("toggle_refresh_auto_account_settings").Invoke("isChecked").Value<bool>()).First();
                    Assert.AreEqual(!autoRefresh, autoRefreshFinal);
                    break;
                case Platform.iOS:
                    app.SkipWalkthrough();
                    app.GoTo(SYSTEM);
                    app.TapProfile();
                    app.Login(EMAIL, EMAIL_PASSWORD);
                    app.TapProfile();
                    app.WaitForElement("content_account_info");
                    app.TapOption("tabbar_item_settings_account_detail");
                    app.WaitForElement("toggle_push_notifications_account_settings");
                    var sendIPush = app.Query(e => e.Marked("toggle_push_notifications_account_settings").Invoke("isOn").Value<int>()).First();
                    var sendIEmail = app.Query(e => e.Marked("toggle_email_notifications_account_settings").Invoke("isOn").Value<int>()).First();
                    var sendIText = app.Query(e => e.Marked("toggle_text_messages_account_settings").Invoke("isOn").Value<int>()).First();
                    var trackITrips = app.Query(e => e.Marked("toggle_track_trips_account_settings").Invoke("isOn").Value<int>()).First();
                    var autoIRefresh = app.Query(e => e.Marked("toggle_refresh_automatically_account_settings").Invoke("isOn").Value<int>()).First();
                    app.TapOption("toggle_push_notifications_account_settings");
                    app.TapOption("toggle_email_notifications_account_settings");
                    app.TapOption("toggle_text_messages_account_settings");
                    app.TapOption("toggle_track_trips_account_settings");
                    app.TapOption("toggle_refresh_automatically_account_settings");
                    var sendIPushFinal = app.Query(e => e.Marked("toggle_push_notifications_account_settings").Invoke("isOn").Value<int>()).First();
                    Assert.AreEqual(!Convert.ToBoolean(sendIPush), Convert.ToBoolean(sendIPushFinal));
                    var sendIEmailFinal = app.Query(e => e.Marked("toggle_email_notifications_account_settings").Invoke("isOn").Value<int>()).First();
                    Assert.AreEqual(!Convert.ToBoolean(sendIEmail), Convert.ToBoolean(sendIEmailFinal));
                    var sendITextFinal = app.Query(e => e.Marked("toggle_text_messages_account_settings").Invoke("isOn").Value<int>()).First();
                    Assert.AreEqual(!Convert.ToBoolean(sendIText), Convert.ToBoolean(sendITextFinal));
                    var trackITripsFinal = app.Query(e => e.Marked("toggle_track_trips_account_settings").Invoke("isOn").Value<int>()).First();
                    Assert.AreEqual(!Convert.ToBoolean(trackITrips), Convert.ToBoolean(trackITripsFinal));
                    var autoIRefreshFinal = app.Query(e => e.Marked("toggle_refresh_automatically_account_settings").Invoke("isOn").Value<int>()).First();
                    Assert.AreEqual(!Convert.ToBoolean(autoIRefresh), Convert.ToBoolean(autoIRefreshFinal));
                    break;
            }
        }
    }
}