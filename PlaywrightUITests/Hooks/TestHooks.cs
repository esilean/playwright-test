using BoDi;
using Microsoft.Playwright;
using PlaywrightUITests.PageObjects;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace PlaywrightUITests.Hooks
{
    [Binding]
    public class TestHooks
    {

        [BeforeScenario("Counter")]
        public async Task BeforeCounterScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(
                                                new BrowserTypeLaunchOptions
                                                {
                                                    Headless = true
                                                });
            var pageObject = new CounterPageObject(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageObject);
        }

        [BeforeScenario("Weather")]
        public async Task BeforeWeatherScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(
                                                new BrowserTypeLaunchOptions
                                                {
                                                    Headless = true,
                                                    SlowMo = 2000
                                                });
            var pageObject = new WeatherPageObject(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageObject);
        }

        [AfterScenario]
        public async Task AfterCounterScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            playwright.Dispose();
        }

    }
}
