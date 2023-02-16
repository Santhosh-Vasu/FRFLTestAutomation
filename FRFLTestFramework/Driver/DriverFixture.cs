using FRFLTestFramework.Config;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Playwright;


namespace FRFLTestFramework.Driver
{

    public class DriverFixture : IDriverFixture , IDisposable
    {
        private readonly TestSettings _testsettings;
        public IBrowser? _browser;
        private readonly Task<IPage> _page;

        public DriverFixture(TestSettings testsettings)
        {
            _testsettings = testsettings;
            _page = GetPage();
            //string url1 = _testsettings.ApplicationUrlUat;
           // Page.GotoAsync(_testsettings.ApplicationUrlUat);
            
            
            //NavigateToWebsite();
        }
        

        public IPage Page => _page.Result;

        //public async Task NavigateToWebsite()
        //{
        //    await Page.GotoAsync(_testsettings.ApplicationUrlUat);

        //}

        private async Task<IPage> GetPage()
        {
            if (_testsettings.BrowserType == BrowserType.Chromium)
            {
                //Initalize Playwright
                var playwright = await Playwright.CreateAsync();
                //Insantiate the Chrome Browser
                _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });
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

