Feature: Sponsors

A short summary of the feature

@WinAppDriver
Scenario: Testing Sponsors Page on windows
	Given The user navigate to sponsors page
	Then User will see "Welcome to .NET MAUI!" as list of sponsors

@Appiumdriver
@AndroidDriver
Scenario: Testing Sponsors Page on android
	Given The user navigate to sponsors page
	Then User will see "Welcome to .NET MAUI!" as list of sponsors
