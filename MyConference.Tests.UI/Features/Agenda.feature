Feature: Agenda

A short summary of the feature

@WinAppDriver
Scenario: Testing Agenda Page on windows
	Given The user navigate to my agenda day 2 page
	Then User will see "Welcome to .NET MAUI!" text

@AppiumDriver
@AndroidDriver
Scenario: Testing Agenda Page on android
	Given The user navigate to my agenda day 2 page
	Then User will see "Welcome to .NET MAUI!" text
