using Microsoft.Playwright;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaywrightUITests.PageObjects
{
    public class WeatherPageObject : BasePageObject
    {
        public override string PagePath => "http://localhost:5000/fetchdata";

        public override IPage Page { get; set; }

        public override IBrowser Browser { get; }

        public WeatherPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public async Task<IReadOnlyList<IElementHandle>> GetWeatherTable() =>
            await Page.QuerySelectorAllAsync("#weather-table tr");

    }
}
