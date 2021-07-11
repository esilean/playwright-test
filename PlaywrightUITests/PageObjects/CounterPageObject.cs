using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightUITests.PageObjects
{
    public class CounterPageObject : BasePageObject
    {
        public override string PagePath => "http://localhost:5000/counter";

        public override IPage Page { get; set; }

        public override IBrowser Browser { get; }

        public CounterPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public async Task ClickIncreaseButton() => await Page.ClickAsync("#increase-btn");

        public async Task<int> CounterValue() => int.Parse(await Page.InnerTextAsync("#counter-val"));
    }
}
