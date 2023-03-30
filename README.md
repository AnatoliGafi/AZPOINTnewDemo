# AZPOINTnewDemo
## Proposed Improvement to Arizona Protective Order Initiation and Notification Tool.

Original web application has 11 page long form, so some customers need a brake to fill it out. When customer wants to continue, form is lost, because customer forgot to click Save button.

My solution was to create new form and immediately save it into database, form gets ID, which is used to automatically update form at the end of each page. 

For example,  line 19 of **Court Controller** creates instance of Case class (inside of GetNewCase endpoint) and SaveNewCase endpoint returns saved record on line 34. UI uses async-await to call SaveNewCase immediately after GetNewCase responded.


**Dropdown Controller** is created to provide exact options for dropdowns "Eye color", "Gender", "Race" that matches criminal database.

Account Controller manages logins, password change and external logins using social media accounts.

