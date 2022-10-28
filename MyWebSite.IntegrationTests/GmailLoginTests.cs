using Microsoft.Playwright.NUnit;

namespace MyWebSite.IntegrationTests
{
    public class GmailLoginTests : PageTest
    {
        [SetUp]
        public async Task Setup()
        {
            await Page.GotoAsync("https://mail.google.com");
        }

        [Test]
        public async Task Login()
        {
            Page.SetDefaultTimeout(10000);
            await Page.Locator("input[type='email']").IsVisibleAsync();
            await Page.FillAsync("#identifierId", "pankajrawat.333@gmail.com");
            await Page.ClickAsync("text=Next");
            
            //var password = Page.Locator("input", new Microsoft.Playwright.PageLocatorOptions { HasTextString = "password" });
            //await password.FillAsync("Password");
            //await Page.ClickAsync("text=Next");
        }
    }
}