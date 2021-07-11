using PlaywrightUITests.PageObjects;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace PlaywrightUITests.Steps
{
    [Binding]
    public class CounterSteps
    {
        private readonly CounterPageObject _counterPageObject;

        public CounterSteps(CounterPageObject counterPageObject)
        {
            _counterPageObject = counterPageObject;
        }

        [Given(@"a user in the counter page")]
        public async Task GivenAUserInTheCounterPage()
        {
            await _counterPageObject.NavigateAsync();
        }

        [When(@"the increase button is clicked (.*) times")]
        public async Task WhenTheIncreaseButtonIsClickedTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                await _counterPageObject.ClickIncreaseButton();
            }
        }

        [Then(@"the counter value is (.*)")]
        public async Task ThenTheCounterValueIs(int value)
        {
            var responseValue = await _counterPageObject.CounterValue();
            Assert.Equal(value, responseValue);
        }

    }
}
