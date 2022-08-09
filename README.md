# Programming Challenge

At Careview we send notifications to our clients when interesting thing happen in our application. For e.g. when a client’s invoice is approved we will send an SMS notification. We will send an email when an invoice is generated with the invoice as attachment.

You are tasked with designing an object model for the different types of notifications. As  described above the notifications could be SMS, or Email or Mobile App notifications. However the design should be extensible for adding different types of notifications in future. Below are the business rules we expect you to implement.

- Emails could be sent to one or more Clients
- Emails could be cc’d to one or more Clients
- Emails should be able to use a template for substituting different values in the Email body. For e.g. Client’s First and Last Name
- SMS’s are sent to a particular Client’s Phone Number
- There is a limit for the body of an SMS
- Notifications sent to mobile apps should have an option to show a preview.

The solution should be implemented in C#. You can use .NET core or .NET Framework. Your Implementation should

- Be reusable and testable
- Have tests, as you would for production code
- Not have a UI, CLI, or database
- Should not have any external dependencies, like sendgrid or any other SMS provider

The solution should be to a standard you are proud of, ready for the-interview

### Questions and Assumptions

While you are completing the exercise, you may encounter some questions or impediments. Rather than being blocked, please make assumptions based on what you think is the best approach. Also, make a note of these assumptions to help as we explore the solution together.

### Ideas and Improvements

While you are completing the exercise you may come up with some ideas for enhancements to the Notification feature. Make a note of them, and come prepared to have a brief discussion with us about them.

## The Interview

During the interview, we will explore the implementation you've developed to solve the problem. We'll then introduce a new scenario to consider, and extend your solution to cater for it.