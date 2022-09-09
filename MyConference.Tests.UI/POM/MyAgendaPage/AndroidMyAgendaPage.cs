using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;

namespace MyConference.Tests.UI.POM.MyAgendaPage;
internal class AndroidMyAgendaPage : MobilePage, IAndroidMyAgendaPage
{
    //com.companyname.myconference:id/WelcomeToNetMaui

    [FindsBy(How = How.Id, Using = "com.companyname.myconference:id/MyAgendaList")]
    private IWebElement MyAgendaList { get; set; }

    public AndroidMyAgendaPage(IAppiumDriver driver) : base(driver)
    {
    }

    public string GetScheduleItems()
    {
        return MyAgendaList?.Text;
    }
}
