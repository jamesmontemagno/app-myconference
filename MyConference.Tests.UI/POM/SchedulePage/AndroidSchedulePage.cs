using MyConference.Tests.UI.POM.AppShell.Interfaces;
using MyConference.Tests.UI.POM.SchedulePage.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Diagnostics;
using TestWare.Engines.Selenium.Pages;

namespace MyConference.Tests.UI.POM.SchedulePage;

internal class AndroidSchedulePage : MobilePage, IAndroidSchedulePage
{
    private SchedulePage _commonLogic;

    [FindsBy(How = How.Id, Using = "com.companyname.myconference:id/SchedulerAgendaList")]
    private IWebElement SchedulerAgendaList { get; set; }


    public AndroidSchedulePage(IAppiumDriver driver): base(driver)
    {
        _commonLogic = new SchedulePage(this);
    }

    public IEnumerable<string> GetScheduleItems()
    {
        var textsFound = new List<string>();
        while (true)
        {
            var elementsOnView = SchedulerAgendaList.FindElements(By.ClassName("android.widget.TextView"));
            var newElementTexts = elementsOnView.Select(x => x.Text).Except(textsFound);

            if (!newElementTexts.Any())
            {
                break;
            }

            textsFound.AddRange(newElementTexts);
            var firstItem = elementsOnView.FirstOrDefault();
            var lastItem = elementsOnView.LastOrDefault();
            ScrollFromLoactionAtoLocationB(lastItem.Location, firstItem.Location);


        }

        var times_found = _commonLogic.ParseStringsToTime(textsFound);
        return times_found;
    }
}
