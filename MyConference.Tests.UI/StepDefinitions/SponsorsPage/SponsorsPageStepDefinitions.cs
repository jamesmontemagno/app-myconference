using FluentAssertions;
using FluentAssertions.Execution;
using MyConference.Tests.UI.StepDefinitions.SponsorsPage.Interfaces;
using TestWare.Core;

namespace MyConference.Tests.UI.StepDefinitions.SponsorsPage;
[Binding]
public class SponsorsPageStepDefinitions
{
    private readonly ISponsorsPage sponsorsPage;

    public SponsorsPageStepDefinitions(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var tags = featureContext.FeatureInfo.Tags.Concat(scenarioContext.ScenarioInfo.Tags).Select(x => x.ToLower());
        var winAppDriver = TestWare.Engines.Appium.WinAppDriver.Factory.ConfigurationTags.winappdriver.ToString();
        var appium = TestWare.Engines.Appium.Factory.ConfigurationTags.appiumdriver.ToString();

        if (tags.Any(item => item == winAppDriver))
        {
            sponsorsPage = ContainerManager.GetTestWareComponent<IWindowsSponsorsPage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "androiddriver"))
        {
            sponsorsPage = ContainerManager.GetTestWareComponent<IAndroidSponsorsPage>();
        }
        else if (tags.Any(item => item == appium) && tags.Any(item => item == "iosdriver"))
        {
            sponsorsPage = ContainerManager.GetTestWareComponent<IIOsSponsorsPage>();
        }
        else
        {
            throw new Exception(" No Page has been resolved");
        }
    }

    [Then(@"User will see ""([^""]*)"" as list of sponsors")]
    public void ThenUserWillSeeAsListOfSponsors(string expectedSponsorsList)
    {
        var sponsors = sponsorsPage.GetSponsors();

        using (new AssertionScope())
        {
            sponsors.Should().NotBeNullOrEmpty();
            sponsors.Should().Be(expectedSponsorsList);
        }
    }
}
