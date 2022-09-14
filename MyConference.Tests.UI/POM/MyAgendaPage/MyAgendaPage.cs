using MyConference.Tests.UI.POM.AppShell.Interfaces;
using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWare.Engines.Selenium.Pages;

namespace MyConference.Tests.UI.POM.MyAgendaPage;

internal class MyAgendaPage: PageBase
{
    private IMyAgendaPage _page;

    internal MyAgendaPage(PageBase Page)
    {
        _page = (IMyAgendaPage)Page;
        Driver = Page.Driver;
    }

    public string GetScheduleItems()
    {
        return _page.MyAgendaList?.Text;
    }
}
