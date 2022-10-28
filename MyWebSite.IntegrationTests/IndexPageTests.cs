using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace MyWebSite.IntegrationTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class IndexPageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestIndexPage()
        {
            //playwright
            using var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://rawatpankaj.com");
            var isExist = await page.Locator("text=Welcome to my blog").IsVisibleAsync();
            var response = await page.WaitForResponseAsync("**/");
            var status = response.Status;
            Assert.IsTrue(isExist);
        }

        [Test]
        public async Task TestIndexPageByScreenshot()
        {
            //playwright
            using var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //Page
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://rawatpankaj.com");
            var isExist = await page.Locator("text=Welcome to my blog").IsVisibleAsync();
            Assert.IsTrue(isExist);
            //capture screenshot
            //https://playwright.dev/dotnet/docs/screenshots
            await page.ScreenshotAsync(new()
            {
                Path = "index.png",
                FullPage = true
            });
        }
    }
}