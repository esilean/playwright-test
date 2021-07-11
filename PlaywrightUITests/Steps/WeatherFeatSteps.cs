using Microsoft.Playwright;
using PlaywrightUITests.PageObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace PlaywrightUITests.Steps
{
    [Binding]
    public class WeatherFeatSteps
    {
        private IReadOnlyList<IElementHandle> _weatherElements;

        private readonly WeatherPageObject _weatherPageObject;

        public WeatherFeatSteps(WeatherPageObject weatherPageObject)
        {
            _weatherPageObject = weatherPageObject;
        }

        [Given(@"the page is loaded")]
        public async Task GivenThePageIsLoaded()
        {
            await _weatherPageObject.NavigateAsync();
        }

        [When(@"the weather table is also loaded")]
        public async Task WhenTheWeatherTableIsAlsoLoaded()
        {
            _weatherElements = await _weatherPageObject.GetWeatherTable();
        }

        [Then(@"page should contain many weather values")]
        public async Task ThenPageShouldContainManyWeatherValues()
        {
            var freezingValue = await _weatherElements[1].InnerTextAsync();
            Assert.Contains("Freezing", freezingValue);

        }

    }
}
