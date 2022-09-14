namespace MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
public interface IMyAgendaPage
{
    internal IWebElement MyAgendaList { get; }
    string GetScheduleItems();
}
