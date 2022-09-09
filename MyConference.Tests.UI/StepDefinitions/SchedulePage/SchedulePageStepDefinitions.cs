using FluentAssertions;
using FluentAssertions.Execution;
using MyConference.Tests.UI.POM.SchedulePage.Interfaces;
using TestWare.Core;

namespace MyConference.Tests.UI.StepDefinitions.SchedulePage;

[Binding]
public class SchedulePageStepDefinitions
{
    private readonly ISchedulePage schedulePage;

    public SchedulePageStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var tags = featureContext.FeatureInfo.Tags.Concat(scenarioContext.ScenarioInfo.Tags).Select(x => x.ToLower());
        var winAppDriver = TestWare.Engines.Appium.WinAppDriver.Factory.ConfigurationTags.winappdriver.ToString();
        var appium = TestWare.Engines.Appium.Factory.ConfigurationTags.appiumdriver.ToString();

        if (tags.Any(item => item == winAppDriver))
        {
            schedulePage = ContainerManager.GetTestWareComponent<IWindowsSchedulePage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "androiddriver"))
        {
            schedulePage = ContainerManager.GetTestWareComponent<IAndroidSchedulePage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "iosdriver"))
        {
            schedulePage = ContainerManager.GetTestWareComponent<IIOsSchedulePage>();
        }
        else
        {
            throw new Exception(" No Page has been resolved");
        }
    }

    [Then(@"Conferences hours should be")]
    public void ThenConferencesHoursShouldBe(Table table)
    {
        var expectedItems = new List<string>(table.Rows.SelectMany(x => x.Values));
        var items = schedulePage.GetScheduleItems();
        using (new AssertionScope())
        {
            items.Should().NotBeEmpty();
            items.Should().BeEquivalentTo(expectedItems);
        }
    }
}
