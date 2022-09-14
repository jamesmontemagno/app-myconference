using MyConference.Tests.UI.POM.SchedulePage.Interfaces;
using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWare.Engines.Selenium.Pages;

namespace MyConference.Tests.UI.POM.SchedulePage;

internal class SchedulePage : PageBase
{
    private ISchedulePage _page;

    internal SchedulePage(PageBase page)
    {
        _page = (ISchedulePage)page;
        Driver = page.Driver;
    }

    public IEnumerable<string> ParseStringsToTime(IEnumerable<string> texts)
    {

        var time = new TimeOnly();
        var result = new List<string>();
        foreach (var child in texts.Where(x => TimeOnly.TryParse(x, out time)))
        {
            if (TimeOnly.TryParse(child, out time))
            {
                result.Add(child);
            }
        }

        return result;
    }
}
