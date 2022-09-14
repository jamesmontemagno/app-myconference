namespace MyConference.Tests.UI.POM.AppShell.Interfaces;

internal interface IAppShellPage
{
    internal IWebElement ScheduleTab { get; }
    internal IWebElement ScheduleDay1Tab { get; }
    internal IWebElement ScheduleDay2Tab { get; }
    internal IWebElement MyAgendaTab { get; }
    internal IWebElement MyAgendaDay1Tab { get; }
    internal IWebElement MyAgendaDay2Tab { get; }
    internal IWebElement SponsorsTab { get; }

    void ClickSchedulerTab(int day);
    void ClickMyAgendaTab(int day);
    void ClickSponsorTab();
}
