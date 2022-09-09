using MyConference.Tests.UI.POM.SchedulePage.Interfaces;
using System.Diagnostics;
using TestWare.Engines.Appium.WinAppDriver.Pages;

namespace MyConference.Tests.UI.POM.SchedulePage;

internal class WindowsSchedulePage : WinAppDriverPage, IWindowsSchedulePage
{
    [FindsBy(How = How.AccessibilityId, Using = "SchedulerAgendaList")]
    private IWebElement SchedulerAgendaList { get; set; }

    public WindowsSchedulePage(IWindowsDriver driver) : base(driver)
    {
    }

    public IEnumerable<string> GetScheduleItems()
    {
        var children = SchedulerAgendaList.FindElements(By.XPath("//*")).Cast<WebElement>();
        var texts = children.Select(x => x.Text).ToList();

        var time = new TimeOnly();
        var result = new List<string>();
        foreach (var child in texts.Where(x => TimeOnly.TryParse(x, out time)))
        {
            Debug.WriteLine(child);

            if (TimeOnly.TryParse(child, out time))
            {
                result.Add(child);
            }
        }

        return result;
    }
}