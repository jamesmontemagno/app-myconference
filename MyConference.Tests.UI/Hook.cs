namespace MyConference.Tests.UI;

[Binding]
public sealed class Hook
{
    private readonly TestContext _testContext;
    private int _stepCounter;
    private static readonly LifeCycle _lifeCycle = new();
    private static ExtentReport _testReport;

    public Hook(TestContext testContext)
    {
        _testContext = testContext;
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        var name = featureContext.FeatureInfo.Title;
        var tags = featureContext.FeatureInfo.Tags;

        _lifeCycle.BeginTestSuite(name);
        _testReport.CreateFeature(name, tags);
    }

    [AfterFeature]
    public static void AfterFeature(FeatureContext featureContext)
    {
        _lifeCycle.EndTestSuite();
    }

    [BeforeScenario]
    public void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var name = scenarioContext.ScenarioInfo.Title;
        var description = scenarioContext.ScenarioInfo.Description ?? "";
        var scenarioTags = scenarioContext.ScenarioInfo.Tags;
        _testReport.CreateTestCase(name, description, scenarioTags);

        _testContext.WriteLine("----------------------------------------- \r\n");
        _testContext.WriteLine($"Feature: {featureContext.FeatureInfo.Title}");
        _testContext.WriteLine($"   Scenario: {scenarioContext.ScenarioInfo.Title} \r\n");

        _stepCounter = 1;
        var tags = GetTags(featureContext, scenarioContext);
        _lifeCycle.BeginTestCase(scenarioContext.ScenarioInfo.Title, tags);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _testReport.SetTestcaseOutcome(_testContext.CurrentTestOutcome);
        _lifeCycle.EndTestCase();
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        _lifeCycle.BeginTestExecution();
        _testReport = new ExtentReport(_lifeCycle.GetCurrentResultsDirectory());
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        _lifeCycle.EndTestExecution();
        _testReport.CreateTestReportFile();
    }

    [BeforeStep]
    public void BeforeStep(ScenarioContext scenarioContext)
    {
        var name = scenarioContext.CurrentScenarioBlock.ToString();
        var description = scenarioContext.StepContext.StepInfo.Text;
        _testReport.CreateStep(name, description);

        var stepId = $"{_stepCounter:00} {description}";
        _stepCounter++;
        _lifeCycle.BeginTestStep(stepId);
    }

    [AfterStep]
    public void AfterStep(ScenarioContext scenarioContext)
    {
        _lifeCycle.EndTestStep();
        var evidencesPath = _lifeCycle.GetStepEvidences();

        foreach (var evidence in evidencesPath)
        {
            _testReport.AddScreenshotToStep(evidence);
            _testContext.AddResultFile(evidence);
        }
    }

    private static List<string> GetTags(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        var tags = featureContext.FeatureInfo.Tags.ToList();
        tags.AddRange(scenarioContext.ScenarioInfo.Tags.ToList());
        return tags;
    }
}
