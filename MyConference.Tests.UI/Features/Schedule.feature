Feature: Schedule

A short summary of the feature

@WinAppDriver
Scenario: Testing Schedule Page on windows
	Given The user navigate to scheduler day 1 page
	Then Conferences hours should be
		| Hours    |
		| 8:30 AM  |
		| 9:30 AM  |
		| 10:30 AM |
		| 11:30 AM |
		| 12:30 PM |
		| 1:30 PM  |
		| 2:30 PM  |

@Appiumdriver
@AndroidDriver
Scenario: Testing Schedule Page on android
	Given The user navigate to scheduler day 1 page
	Then Conferences hours should be
		| Hours    |
		| 8:30 AM  |
		| 9:30 AM  |
		| 10:30 AM |
		| 11:30 AM |
		| 12:30 PM |
		| 1:30 PM  |
		| 2:30 PM  |