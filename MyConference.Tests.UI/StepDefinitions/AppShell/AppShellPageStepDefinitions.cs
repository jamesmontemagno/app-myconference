using MyConference.Tests.UI.POM.AppShell.Interfaces;
using TestWare.Core;

namespace MyConference.Tests.UI.StepDefinitions.AppShell;

[Binding]
public class AppShellPageStepDefinitions
{
    private readonly IAppShellPage appShellPage;

    public AppShellPageStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var tags = featureContext.FeatureInfo.Tags.Concat(scenarioContext.ScenarioInfo.Tags).Select(x => x.ToLower());
        var winAppDriver = TestWare.Engines.Appium.WinAppDriver.Factory.ConfigurationTags.winappdriver.ToString();
        var appium = TestWare.Engines.Appium.Factory.ConfigurationTags.appiumdriver.ToString();

        if (tags.Any(item => item == winAppDriver))
        {
            appShellPage = ContainerManager.GetTestWareComponent<IWindowsAppShellPage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "androiddriver"))
        {
            appShellPage = ContainerManager.GetTestWareComponent<IAndroidAppShellPage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "iosdriver"))
        {
            appShellPage = ContainerManager.GetTestWareComponent<IIOsAppShellPage>();
        }
        else
        {
            throw new Exception(" No Page has been resolved");
        }
    }

    [Given(@"The user navigate to scheduler day (.*) page")]
    public void GivenTheUserNavigateToSchedulerDayPage(int day)
    {
        appShellPage.ClickSchedulerTab(day);
    }

    [Given(@"The user navigate to my agenda day (.*) page")]
    public void GivenTheUserNavigateToMyAgendaDayPage(int day)
    {
        appShellPage.ClickMyAgendaTab(day);
    }

    [Given(@"The user navigate to sponsors page")]
    public void GivenTheUserNavigateToSponsorsPage()
    {
        appShellPage.ClickSponsorTab();
    }
}
