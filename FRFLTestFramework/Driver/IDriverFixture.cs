using Microsoft.Playwright;

namespace FRFLTestFramework.Driver
{
    public interface IDriverFixture
    {
        Task<IPage> GetPageAsync();
    }
}