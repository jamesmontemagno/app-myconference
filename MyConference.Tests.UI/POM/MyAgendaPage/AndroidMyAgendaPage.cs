using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;

namespace MyConference.Tests.UI.POM.MyAgendaPage;
internal class AndroidMyAgendaPage : MobilePage, IAndroidMyAgendaPage
{
    private MyAgendaPage _commonLogic;

    [FindsBy(How = How.Id, Using = "com.companyname.myconference:id/MyAgendaList")]
    public IWebElement MyAgendaList { get; set; }

    public AndroidMyAgendaPage(IAppiumDriver driver): base(driver)
    {
        _commonLogic = new(this);
    }

    public string GetScheduleItems()
    {
        return _commonLogic.GetScheduleItems();
    }
}
