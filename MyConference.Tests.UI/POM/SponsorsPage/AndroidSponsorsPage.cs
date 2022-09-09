using MyConference.Tests.UI.StepDefinitions.SponsorsPage.Interfaces;

namespace MyConference.Tests.UI.POM.SponsorsPage;
public class AndroidSponsorsPage : MobilePage, IAndroidSponsorsPage
{
    [FindsBy(How = How.Id, Using = "com.companyname.myconference:id/SponsorsList")]
    private IWebElement SponsorsList { get; set; }

    public AndroidSponsorsPage(IAppiumDriver driver) : base(driver)
    {
    }

    public string GetSponsors()
    {
        return SponsorsList?.Text;
    }
}
