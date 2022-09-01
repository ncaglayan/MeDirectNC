Feature: Login

This feature provides us to be able to login and check the result

@scopedBinding
Scenario: User should be able to login
Given User navigates to login page
When User enters valid credentials 'standard_user' and 'secret_sauce'
Then User should be able to login
Then Browser is closed

@scopedBinding
Scenario: User should not be able to login
Given User navigates to login page
When User enters invalid credentials 'locked_out_user' and 'secret_sauce'
Then User should not be able to login
Then Browser is closed

@scopedBinding
Scenario: After successfull login check the items name and images
Given User navigates to login page
When User enters invalid credentials 'problem_user' and 'secret_sauce'
Then User should be able to see the item names are different from product details
Then Browser is closed

@scopedBinding
Scenario: User should be able to purchase product
Given User navigates to login page
When User enters invalid credentials 'performance_glitch_user' and 'secret_sauce'
Then User should be able to see the items are same with product details
When User add a product
Then User should be able to purchase the product
Then Browser is closed