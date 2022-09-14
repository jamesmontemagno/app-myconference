using MyConference.Tests.UI.POM.SchedulePage.Interfaces;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.SchedulePage;

internal class WindowsSchedulePage : WinAppDriverPage, IWindowsSchedulePage
{
    private SchedulePage _commonLogic;

    [FindsBy(How = How.AccessibilityId, Using = "SchedulerAgendaList")]
    private IWebElement SchedulerAgendaList { get; set; }

    public WindowsSchedulePage(IWindowsDriver driver): base(driver)
    {
        _commonLogic = new SchedulePage(this);
    }

    public IEnumerable<string> GetScheduleItems()
    {
        var textsFound = new List<string>();
        while (true)
        {
            var elementsOnView = SchedulerAgendaList.FindElements(By.XPath("//*"));
            var newElementTexts = elementsOnView.Select(x => x.Text).Except(textsFound);

            if (!newElementTexts.Any())
            {
                break;
            }

            textsFound.AddRange(newElementTexts);
            var lastItem = elementsOnView.LastOrDefault();
            lastItem.SendKeys(Keys.PageDown);


        }
        var times_found = _commonLogic.ParseStringsToTime(textsFound);
        return times_found;
    }
}