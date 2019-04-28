using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using Xamarin.UITest;

namespace BCycleMobile.UITest.Tests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
    public class ApplicationLaunchTests : Test
    {
		public ApplicationLaunchTests(Platform platform) : base(platform) { }
	
		[Test]
		public void Verify_Application_Launches_On_Fresh_Install()
		{
            //If first time install, click OK
            //otherwise, perform the action below

            switch (platform)
            {
                case Platform.Android:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.WaitForElement(e => e.Text("See a list of all locations"), timeout: TimeSpan.FromSeconds(120));
                    app.Screenshot("Application Launch: Fresh Install").MoveTo($"C:\\Screenshots\\Launch_FreshInstall__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Text("See a list of all locations"), true);
                    break;
				case Platform.iOS:
                    app = AppInitializer.StartApp(platform);
                    AppExtension.SetPlatform(platform);
                    app.WaitForElement(e => e.Text("See a list of all locations"), timeout: TimeSpan.FromSeconds(120));
                    app.Assert(e => e.Text("See a list of all locations"), true);
                    break;
            }
		}

		[Test]
		public void Verify_Walkthrough()
		{
			switch (platform)
			{
				case Platform.Android:
                    app.WaitForElement(e => e.Text("See a list of all locations"), timeout: TimeSpan.FromSeconds(120));
                    app.Tap(e => e.Text("See a list of all locations"));
                    app.WaitForElement(e => e.Text("Austin B-cycle"));
                    app.Tap(e => e.Text("Austin B-cycle"));
                    app.Screenshot("Walkthrough: Page 1").MoveTo($"C:\\Screenshots\\Walkthrough1__{Guid.NewGuid()}.png");
                    app.SwipeRightToLeft();
                    app.Screenshot("Walkthrough: Page 2").MoveTo($"C:\\Screenshots\\Walkthrough2__{Guid.NewGuid()}.png");
                    app.SwipeRightToLeft();
                    app.Screenshot("Walkthrough: Page 3").MoveTo($"C:\\Screenshots\\Walkthrough_Walkthrough3__{Guid.NewGuid()}.png");
                    app.SwipeRightToLeft();
                    app.Screenshot("Walkthrough: Final Page").MoveTo($"C:\\Screenshots\\Walkthrough_WalkthroughFinal__{Guid.NewGuid()}.png");
                    app.Assert(e => e.Id("button_finish_walkthrough_walkthrough").Text(app.GetLabel("OkayGotItCaps")), true);								
					break;
				case Platform.iOS:
                    app.WaitForElement(e => e.Text("See a list of all locations"), timeout: TimeSpan.FromSeconds(120));
                    app.Tap(e => e.Text("See a list of all locations"));
                    app.WaitForElement(e => e.Text("Austin B-cycle"));
                    app.Tap(e => e.Text("Austin B-cycle"));
                    app.Assert(e => e.Id("text_skip_walkthrough_walkthrough").Text(app.GetLabel("SkipWalkthroughCaps")), true);
                    app.SwipeRightToLeft();
                    app.Assert(e => e.Id("text_skip_walkthrough_walkthrough").Text(app.GetLabel("SkipWalkthroughCaps")), true);
                    app.SwipeRightToLeft();
                    app.Assert(e => e.Id("text_skip_walkthrough_walkthrough").Text(app.GetLabel("SkipWalkthroughCaps")), true);
                    app.SwipeRightToLeft();
                    app.Assert(e => e.Id("button_finish_walkthrough_walkthrough").Text(app.GetLabel("OkayGotItCaps")), true);
                    //app.WaitFor(() => { Thread.Sleep(2000); return true; }); //Allow button to reflect new label.
                    //app.Assert(e => e.Id("button_action_walkthrough").Marked(app.GetLabel("OkayGotIt")), true);
                    break;
			}
		}
	}
}