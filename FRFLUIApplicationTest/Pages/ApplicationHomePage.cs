
using FRFLTestFramework.Config;
using FRFLTestFramework.Driver;
using Microsoft.Playwright;


namespace FRFLApplicationTest.Pages
{
   public interface IApplicationHomePage
    {
        Task acceptAll();
        Task acceptAndProceed();
        Task appApplyNowBtn();
        Task appFinish();
        Task appNextBtn();
        Task<bool> decisionVisible();
        Task FillAdditionalInfo(string howDidYouHearAboutUs);
        Task FillEmploymentDetails(string employmentType, string occupation, string companyName, string workcity, string employmentTelephone, string employmentTimeSpentInJobYr, string employmentTimeSpentInJobM, string employmentTakeHomePay, string employmentIncomeFrequency);
        Task FillMainAddressDetails(string flatNumber, string buildingName, string buildingNumber, string street, string town, string city, string county, string postcode, string timeAtAddressYrs, string timeAtAddressMths, string residency);
        Task FillMainApplicant(string title, string forename, string middlename, string surname, string dobDay, string dobMonth, string dobYear, string status, string dependants, string hometel, string mobiletel, string email);
        Task FillVehicleDetails(string vehicleReg, string vehicleType, string vehicleManufacturer, string vehicleMileage, string vehiclePrice, string cashDeposit, string partExchangeDeposit);
        Task<bool> IsApplyButtonVisible();
        Task<bool> IsForenameVisible();
        Task VerifyDetailsAndClickApplyButton();
    }

    public class ApplicationHomePage : IApplicationHomePage
    {


        private readonly IDriverFixture _driverFixture;
        public ApplicationHomePage(IDriverFixture driverFixture)
        {
            _driverFixture = driverFixture;
        }

        private ILocator _applyNowBtn => _driverFixture.Page.Locator("text=Apply now");
        private ILocator _acceptAll => _driverFixture.Page.Locator("text=Accept All");

        private ILocator _acceptAndProceed => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div:nth-child(1) > da-terms-step > frf-wizard-step > div > div > div.col-sm-8.body > form > div.row.btn-row > div.col-xs-8.col-sm-10 > div > label > input");


        private ILocator _appnNext => _driverFixture.Page.Locator("id=next");
        private ILocator _forenameVisible => _driverFixture.Page.Locator("id=forename");


        private ILocator _title => _driverFixture.Page.Locator("id=title");

        private ILocator _forename => _driverFixture.Page.Locator("id=forename");

        private ILocator _middlename => _driverFixture.Page.Locator("id=middlename");
        private ILocator _surnmae => _driverFixture.Page.Locator("id=surname");
        private ILocator _dobDay => _driverFixture.Page.Locator("id=dobDay");
        private ILocator _dobMonth => _driverFixture.Page.Locator("id=dobMonth");
        private ILocator _dobYear => _driverFixture.Page.Locator("id=dobYear");
        private ILocator _maritalStatus => _driverFixture.Page.Locator("id=status");
        private ILocator _dependants => _driverFixture.Page.Locator("id=dependants");
        private ILocator _homeTel => _driverFixture.Page.Locator("da-primary-applicant-step #hometel");
        private ILocator _mobileTel => _driverFixture.Page.Locator("da-primary-applicant-step #mobiletel");
        private ILocator _email => _driverFixture.Page.Locator("id=email");
        private ILocator _manualAddressCheck => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div:nth-child(1) > da-primary-applicant-step > frf-wizard-step > div > div > div.col-sm-8.body > form > da-address > form > div:nth-child(2) > div.col-sm-6.col-sm-offset-1 > div > label > input");

        private ILocator _flatNum => _driverFixture.Page.Locator("id=flatNumber");
        private ILocator _buildingName => _driverFixture.Page.Locator("id=buildingName");
        private ILocator _buildingNum => _driverFixture.Page.Locator("id=buildingNumber");
        private ILocator _street => _driverFixture.Page.Locator("id=street");
        private ILocator _town => _driverFixture.Page.Locator("id=town");
        private ILocator _city => _driverFixture.Page.Locator("id=city");
        private ILocator _county => _driverFixture.Page.Locator("id=county");
        private ILocator _postcode => _driverFixture.Page.Locator("id=postcode");
        private ILocator _timeAtAddressYrs => _driverFixture.Page.Locator("id=timeAtAddressYrs");
        private ILocator _timeAtAddressMths => _driverFixture.Page.Locator("id=timeAtAddressMths");
        private ILocator _residency => _driverFixture.Page.Locator("id=residency");

        private ILocator _mainApplicantPageNext => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div.row.btn-row > div > div > div > div.pull-right.col-xs-6 > button");
        private ILocator _employmentType => _driverFixture.Page.Locator("id=employmentType");
        private ILocator _occupation => _driverFixture.Page.Locator("id=occupation");
        private ILocator _companyName => _driverFixture.Page.Locator("id=companyName");
        private ILocator _workCity => _driverFixture.Page.Locator("id=city");
        private ILocator _workTelephone => _driverFixture.Page.Locator("id=employmentTelephone");
        private ILocator _employmentInJobYr => _driverFixture.Page.Locator("id=employmentTimeSpentInJobYr");
        private ILocator _employmentInJobMnth => _driverFixture.Page.Locator("id=employmentTimeSpentInJobM");
        private ILocator _employmentTakeHome => _driverFixture.Page.Locator("id=employmentTakeHomePay");
        private ILocator _incomeFrequency => _driverFixture.Page.Locator("id=employmentIncomeFrequency");
        private ILocator _employmentPageNext => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div.row.btn-row > div > div > div > div > button");
        private ILocator _additionalIncome => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div:nth-child(1) > da-additional-income-decision-step > frf-wizard-step > div > div > div.col-sm-8.body > form > div > div.col-sm-6 > label:nth-child(2) > input");
        private ILocator _additionalIncomePageNext => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div.row.btn-row > div > div > div > div.pull-right.col-xs-6 > button");
        private ILocator _howDidYouHearAboutUs => _driverFixture.Page.Locator("id=howDidYouHearAboutUs");
        private ILocator _chosenVehicle => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div:nth-child(1) > da-additional-info-step > frf-wizard-step > div > div > div.col-sm-8.body > form > div:nth-child(2) > div.col-sm-6.col-sm-offset-1 > label:nth-child(1)");
        private ILocator _vehicleReg => _driverFixture.Page.Locator("id=vehicleReg");
        private ILocator _vehicleType => _driverFixture.Page.Locator("id=vehicleType");
        private ILocator _vehicleManufacturer => _driverFixture.Page.Locator("id=vehicleManufacturer");
        private ILocator _vehicleMileage => _driverFixture.Page.Locator("id=vehicleMileage");
        private ILocator _vehiclePrice => _driverFixture.Page.Locator("id=vehiclePrice");
        private ILocator _cashDeposit => _driverFixture.Page.Locator("id=cashDeposit");
        private ILocator _partExchangeDeposit => _driverFixture.Page.Locator("id=partExchangeDeposit");
        private ILocator _additionalInfoNext => _driverFixture.Page.Locator("#consumer-form > frf-wizard > div > div:nth-child(2) > div > div > div > div.row.btn-row > div > div > div > div.pull-right.col-xs-6 > button");
        private ILocator _verifyApplyButtonVisible => _driverFixture.Page.Locator("text=Apply!");
        private ILocator _clickApplyButton => _driverFixture.Page.Locator("text=Apply!");

        private ILocator _decision => _driverFixture.Page.Locator("da-decision-step #decision");

        private ILocator _appFinishButton => _driverFixture.Page.Locator("text=Finish");





        //public async Task NavigateToWebsite()
        //{
        //    await Page.GotoAsync(_testsettings.ApplicationUrlUat);

        //}

        public async Task appApplyNowBtn() => await _applyNowBtn.ClickAsync();
        public async Task acceptAll() => await _acceptAll.ClickAsync();
        public async Task acceptAndProceed() => await _acceptAndProceed.CheckAsync();
        public async Task appNextBtn() => await _appnNext.ClickAsync();


        public async Task<bool> IsForenameVisible() => await _forenameVisible.IsDisabledAsync();
        public async Task<bool> IsApplyButtonVisible() => await _verifyApplyButtonVisible.IsDisabledAsync();

        public async Task<bool> decisionVisible() => await _decision.IsDisabledAsync();

        public async Task appFinish() => await _appFinishButton.ClickAsync();


        public async Task FillMainApplicant(string title, string forename, string middlename, string surname, string dobDay, string dobMonth, string dobYear, string status, string dependants, string hometel, string mobiletel, string email)
        {

            await _title.SelectOptionAsync(title);
            await _forename.FillAsync(forename);
            await _middlename.FillAsync(middlename);
            await _surnmae.FillAsync(surname);
            await _dobDay.SelectOptionAsync(dobDay);
            await _dobMonth.SelectOptionAsync(dobMonth);
            await _dobYear.SelectOptionAsync(dobYear);
            await _maritalStatus.SelectOptionAsync(status);
            await _dependants.SelectOptionAsync(dependants);
            await _homeTel.FillAsync(hometel);
            await _mobileTel.FillAsync(mobiletel);
            await _email.FillAsync(email);
            await _manualAddressCheck.ClickAsync();
        }

        public async Task FillMainAddressDetails(string flatNumber, string buildingName, string buildingNumber, string street, string town, string city, string county, string postcode, string timeAtAddressYrs, string timeAtAddressMths, string residency)
        {
            await _flatNum.FillAsync(flatNumber);
            await _buildingName.FillAsync(buildingName);
            await _buildingNum.FillAsync(buildingNumber);
            await _street.FillAsync(street);
            await _town.FillAsync(town);
            await _city.FillAsync(city);
            await _county.FillAsync(county);
            await _postcode.FillAsync(postcode);
            await _timeAtAddressYrs.SelectOptionAsync(timeAtAddressYrs);
            await _timeAtAddressMths.SelectOptionAsync(timeAtAddressMths);
            await _residency.SelectOptionAsync(residency);
        }


        public async Task FillEmploymentDetails(string employmentType, string occupation, string companyName, string workcity, string employmentTelephone, string employmentTimeSpentInJobYr, string employmentTimeSpentInJobM, string employmentTakeHomePay, string employmentIncomeFrequency)
        {
            await _mainApplicantPageNext.ClickAsync();
            await _employmentType.SelectOptionAsync(employmentType);
            await _occupation.FillAsync(occupation);
            await _companyName.FillAsync(companyName);
            await _workCity.FillAsync(workcity);
            await _workTelephone.FillAsync(employmentTelephone);
            await _employmentInJobYr.SelectOptionAsync(employmentTimeSpentInJobYr);
            await _employmentInJobMnth.SelectOptionAsync(employmentTimeSpentInJobM);
            await _employmentTakeHome.FillAsync(employmentTakeHomePay);
            await _incomeFrequency.SelectOptionAsync(employmentIncomeFrequency);
        }



        public async Task FillAdditionalInfo(string howDidYouHearAboutUs)
        {
            await _employmentPageNext.ClickAsync();
            await _additionalIncome.ClickAsync();
            await _additionalIncomePageNext.ClickAsync();
            await _howDidYouHearAboutUs.SelectOptionAsync(howDidYouHearAboutUs);

        }

        public async Task FillVehicleDetails(string vehicleReg, string vehicleType, string vehicleManufacturer, string vehicleMileage, string vehiclePrice, string cashDeposit, string partExchangeDeposit)
        {
            await _chosenVehicle.ClickAsync();
            await _vehicleReg.FillAsync(vehicleReg);
            await _vehicleType.SelectOptionAsync(vehicleType);
            await _vehicleManufacturer.FillAsync(vehicleManufacturer);
            await _vehicleMileage.FillAsync(vehicleMileage);
            await _vehiclePrice.FillAsync(vehiclePrice);
            await _cashDeposit.FillAsync(cashDeposit);
            await _partExchangeDeposit.FillAsync(partExchangeDeposit);
            await _additionalInfoNext.ClickAsync();
        }


        public async Task VerifyDetailsAndClickApplyButton()
        {


            //await _page.WaitForResponseAsync(x => x.Url.EndsWith("/portalapi/application/v1/multistep") && x.Status == 200);
            await _clickApplyButton.ClickAsync();

        }

    }
}
