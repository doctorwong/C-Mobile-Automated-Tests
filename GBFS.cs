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

/* Moved to regression
namespace BCycleMobile.UITest.Tests
{
    [TestFixture(Xamarin.UITest.Platform.Android)]
    [TestFixture(Xamarin.UITest.Platform.iOS)]
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

        [TearDown]
        public void closeBrowser()

        {
            driver.Close();
        }
    }
}

    */