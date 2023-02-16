using FRFLTestFramework.Config;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Playwright;


namespace FRFLTestFramework.Driver
{

    public class DriverFixture : IDriverFixture , IDisposable
    {
        private readonly TestSettings _testsettings;
        public IBrowser? _browser;
        private readonly IPage _page;

        public DriverFixture(TestSettings testsettings)
        {
            _testsettings = testsettings;
        }

        public async Task<IPage> GetPageAsync()
        {
            if (_testsettings.BrowserType == BrowserType.Chromium)
            {
                //Initalize Playwright
                var playwright = await Playwright.CreateAsync();
                //Insantiate the Chrome Browser
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                }).ConfigureAwait(false);
                //Creating a blank page
                return await _browser.NewPageAsync();
            }

            //else if (browserType == BrowserType.Firefox)
            else if (_testsettings.BrowserType == BrowserType.Firefox)
            {
                var playwright = await Playwright.CreateAsync();

                _browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });

                return await _browser.NewPageAsync();
            }
            else
            {
                var playwright = await Playwright.CreateAsync();

                _browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });

                return await _browser.NewPageAsync();
            }

        }
        void IDisposable.Dispose()
        {
            _browser?.CloseAsync();
        }
    }

}

public enum BrowserType
{
    Chromium,
    Firefox,
    Webkit
}

