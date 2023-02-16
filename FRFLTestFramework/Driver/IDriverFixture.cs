using Microsoft.Playwright;

namespace FRFLTestFramework.Driver
{
    public interface IDriverFixture
    {
        IPage Page { get; }
    }
}