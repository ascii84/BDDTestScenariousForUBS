Feature: Login
	In order to manage my account
	As a user
	I want to be able to login to my bank

Scenario Outline: Unsuccessful Login with wrong credentials
	Given I Navigate to the Login page for US client
	When I login with Username '<username>' and Password '<password>' on the Login Page
	Then I Should See Error Message '<errorMsg>' displayed on the Login Page

Examples: 
 | name             | username | password | errorMsg                                                                                 |
 | Blank Username   |          | password | Enter your user name														         |
 | Blank Password   | admin    |          | Enter your password															     |
 | invalid Password | admin    | blabla   | The user name and/or password you entered do not match our records.						 |
 | invalid username | 123456   | password | The user name and/or password you entered do not match our records.                      |

