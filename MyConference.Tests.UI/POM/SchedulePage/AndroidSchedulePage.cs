using MyConference.Tests.UI.POM.AppShell.Interfaces;
using MyConference.Tests.UI.POM.SchedulePage.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Diagnostics;

namespace MyConference.Tests.UI.POM.SchedulePage;

internal class AndroidSchedulePage : MobilePage, IAndroidSchedulePage
{
    [FindsBy(How = How.Id, Using = "com.companyname.myconference:id/SchedulerAgendaList")]
    private IWebElement SchedulerAgendaList { get; set; }

 
    public AndroidSchedulePage(IAppiumDriver driver) : base(driver)
    {
    }

    public IEnumerable<string> GetScheduleItems()
    {
        var children = SchedulerAgendaList.FindElements(By.ClassName("android.widget.TextView")).Cast<WebElement>();
        var texts = children.Select(x => x.Text).ToList();
        var firstItem = children.FirstOrDefault();
        var lastItem = children.LastOrDefault();

        while (true)
        {
            try
            {
                ScrollFromLoactionAtoLocationB(lastItem.Location, firstItem.Location);
                var findItems = SchedulerAgendaList.FindElements(By.ClassName("android.widget.TextView")).Cast<WebElement>().ToList();
                var itemsToAdd = findItems.Select(x => x.Text).Except(texts);

                if (itemsToAdd.Count() == 0)
                {
                    break;
                }

                firstItem = findItems.FirstOrDefault();
                lastItem = findItems.LastOrDefault();
                texts.AddRange(itemsToAdd);
            }
            catch (Exception e)
            {
            }
        }

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
