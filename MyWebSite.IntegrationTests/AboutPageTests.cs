using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace MyWebSite.IntegrationTests
{
    public class AboutPageTests : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://rawatpankaj.com");
        }

        [Test]
        public async Task TestAboutPage()
        {            
            await Page.ClickAsync("text=ABOUT ME");
            await Expect(Page).ToHaveURLAsync(new Regex(".*about"));
        }
        //To run test in headed mode
        //run test from cmd
        //HEADED=1 dotnet test
    }
}