using FluentAssertions;
using FluentAssertions.Execution;
using MyConference.Tests.UI.StepDefinitions.MyAgendaPage.Interfaces;
using TestWare.Core;

namespace MyConference.Tests.UI.StepDefinitions.MyAgendaPage;

[Binding]
public class MyAgendaPageStepDefinitions
{
    private readonly IMyAgendaPage myAgendaPage;

    public MyAgendaPageStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var tags = featureContext.FeatureInfo.Tags.Concat(scenarioContext.ScenarioInfo.Tags).Select(x => x.ToLower());
        var winAppDriver = TestWare.Engines.Appium.WinAppDriver.Factory.ConfigurationTags.winappdriver.ToString();
        var appium = TestWare.Engines.Appium.Factory.ConfigurationTags.appiumdriver.ToString();

        if (tags.Any(item => item == winAppDriver))
        {
            myAgendaPage = ContainerManager.GetTestWareComponent<IWindowsMyAgendaPage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "androiddriver"))
        {
            myAgendaPage = ContainerManager.GetTestWareComponent<IAndroidMyAgendaPage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "iosdriver"))
        {
            myAgendaPage = ContainerManager.GetTestWareComponent<IIOsMyAgendaPage>();
        }
        else
        {
            throw new Exception(" No Page has been resolved");
        }
    }

    [Then(@"User will see ""([^""]*)"" text")]
    public void ThenUserWillSeeText(string expectedText)
    {
        var items = myAgendaPage.GetScheduleItems();
        using (new AssertionScope())
        {
            items.Should().NotBeNullOrEmpty();
            items.Should().Be(expectedText);
        }
    }

}
