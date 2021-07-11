@Weather
Feature: Weather values should be properly loaded in page

Scenario: Load weather values
	Given the page is loaded
	When the weather table is also loaded
	Then page should contain many weather values