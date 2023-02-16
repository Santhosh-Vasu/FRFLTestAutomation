using FRFLApplicationTest._pages;
using FRFLApplicationTest.Pages;
using FRFLTestFramework.Config;
using FRFLTestFramework.Driver;


namespace FRFLUIApplicationTest.StepDefinitions
{
    [Binding]
    public class HPLoanApplicationStepDefinitions
    {
        private readonly TestSettings _testsettings;
        //private readonly IScenarioContext _scenariocontext;
        private readonly IDriverFixture _driverfixture;

        private ApplicationHomePage _applicationHomePage;
        public HPLoanApplicationStepDefinitions(TestSettings testsettings, IDriverFixture driverFixture)
        {
            //_scenariocontext = scenariocontext;
            _testsettings = testsettings;
            _driverfixture = driverFixture;
        }

        [Given(@"the user on the FRFL Website")]
        public async Task GivenTheUserOnTheFRFLWebsite()
        {
            var page = await _driverfixture.GetPageAsync();
            _applicationHomePage = new ApplicationHomePage(page);
            await _applicationHomePage.appApplyNowBtn();
            await _applicationHomePage.acceptAll();
            await _applicationHomePage.acceptAndProceed();
            await _applicationHomePage.appNextBtn();

        }

        [When(@"the user fills the main applicant details (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public async Task WhenTheUserFillsTheMainApplicantDetailsAsync(string title, string forename, string middlename, string surname, string dobDay, string dobMonth, string dobYear, string status, string dependants, string hometel, string mobiletel, string email)
        {
            await _applicationHomePage.FillMainApplicant(title, forename, middlename, surname, dobDay, dobMonth, dobYear, status, dependants, hometel, mobiletel, email);
        }

        //[When(@"the address (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        //public async Task WhenTheAddressDetails(string flatNumber, string buildingName, string buildingNumber, string street, string town, string city, string county, string postcode, string timeAtAddressYrs, string timeAtAddressMths, string residency)
        //{
        //    await _applicationPage.FillMainAddressDetails(flatNumber, buildingName, buildingNumber, street, town, city, county, postcode, timeAtAddressYrs, timeAtAddressMths, residency);
        //}


        //[When(@"fills in the employment details (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        //public async Task WhenFillsInTheEmploymentDetailsAsync(string employmentType, string occupation, string companyName, string workcity, string employmentTelephone, string employmentTimeSpentInJobYr, string employmentTimeSpentInJobM, string employmentTakeHomePay, string employmentIncomeFrequency)
        //{
        //    await _applicationPage.FillEmploymentDetails(employmentType, occupation, companyName, workcity, employmentTelephone, employmentTimeSpentInJobYr, employmentTimeSpentInJobM, employmentTakeHomePay, employmentIncomeFrequency);
        //}

        //[When(@"fills in the additional Info (.*)")]
        //public async Task WhenFillsInTheAdditionalInfoAsync(string howDidYouHearAboutUs)
        //{
        //    await _applicationPage.FillAdditionalInfo(howDidYouHearAboutUs);
        //}

        //[When(@"fills in the vehicle details (.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        //public async Task WhenFillsInTheVehicleDetailsAsync(string vehicleReg, string vehicleType, string vehicleManufacturer, string vehicleMileage, string vehiclePrice, string cashDeposit, string partExchangeDeposit)
        //{
        //    await _applicationPage.FillVehicleDetails(vehicleReg, vehicleType, vehicleManufacturer, vehicleMileage, vehiclePrice, cashDeposit, partExchangeDeposit);
        //}

        //[When(@"verify the information and click Apply! button")]
        //public async Task WhenVerifyTheInformationAndClickApplyButton()
        //{
        //    await _applicationPage.VerifyDetailsAndClickApplyButton();

        //}



        //[Then(@"the application should be submitted and gets the decision page")]
        //public async Task ThenTheApplicationShouldBeSubmittedAndGetsTheDecisionPage()
        //{
        //    await _applicationPage.decisionVisible();
        //}


        //[Then(@"click on the finish and close the page")]
        //public async Task ThenClickOnTheFinishAndCloseThePage()
        //{
        //    await _applicationPage.appFinish();
        //}

    }
}
