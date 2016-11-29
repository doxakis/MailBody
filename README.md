# MailBody [![Build Status](https://travis-ci.org/doxakis/MailBody.svg?branch=master)](https://travis-ci.org/doxakis/MailBody)
MailBody is a library for generating transactional email by using a fluent interface.

The current mail template is based on https://github.com/leemunroe/responsive-html-email-template
(MIT License 2013 Lee Munroe)

# Supported framework
- dotnet core 1.0
- .net framework 4.5

# Install from Nuget
To get the latest version:
```
Install-Package MailBody
```

# Quick Examples

## Email Address Confirmation
```
var body = MailBody
    .CreateBody()
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
    .Button("https://example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/EmailAddressConfirmation.html)

## Password reset
```
var appName = "My app";

var body = MailBody
    .CreateBody()
    .Paragraph("Hi,")
    .Paragraph("You're receiving this email because someone requested a password reset for your user account at " + appName + ".")
    .Button("https://www.example.com/", "Reset password")
    .Paragraph("Thanks for using " + appName + "!")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/PasswordReset.html)

## Order confirmation
```
var products = new string[] { "1 x Product A", "2 x Product B", "3 x Product C" };

// Format product display.
var items = products.Select(item => MailBody.CreateBlock().Text(item));
            
var body = MailBody
    .CreateBody()
    .Title("Confirmation of your order")
    .Paragraph("Hello,")
    .Paragraph("We confirm having received your order.")
    .Paragraph("Here is the list of ordered items:")
    .UnorderedList(items)
    .Paragraph("Thank you for ordering from us!")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/OrderConfirmation.html)

## Notification
```
var productName = "ABC";
var productStatus = "available";
var productDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla sagittis nisl ut tellus egestas facilisis. Nulla eget erat dictum, facilisis libero sit amet, sollicitudin tortor. Morbi iaculis, urna eu tincidunt dapibus, sapien ex dictum nibh, non congue urna tellus vitae risus.";
var components = new string[] { "Part A", "Part B" };
            
// Format product display.
var items = components.Select(item => MailBody.CreateBlock().Text(item));
            
var body = MailBody
    .CreateBody()
    .Paragraph("Hello,")
    .Paragraph("The product " + productName + " is now " + productStatus + ".")
    .SubTitle("Here is the product summary:")
    .Paragraph(MailBody.CreateBlock()
        .StrongText("Product name: ").Text(productName))
    .Paragraph(MailBody.CreateBlock()
        .StrongText("Description: ").Text(productDescription))
    .Paragraph(MailBody.CreateBlock()
        .StrongText("Components:"))
    .UnorderedList(items)
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/Notification.html)

## With footer
```
var footer = MailBody
    .CreateBlock()
    .Text("Follow ")
    .Link("http://twitter.com/example", "@Example")
    .Text(" on Twitter.");

var body = MailBody
    .CreateBody(footer)
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
    .Button("https://www.example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/Withfooter.html)

## Custom theme & Raw html
```
var footer = MailBody
    .CreateBlock()
    .Text("Follow ")
    .Link("http://twitter.com/example", "@Example")
    .Text(" on Twitter.");

var template = MailBodyTemplate.GetDefaultTemplate();
template.Paragraph = "<p style='color:blue;'>{0}</p>";

var body = MailBody
    .CreateBody(template, footer)
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Raw("<p>We may need to send you <strong>critical information</strong> about our service and it is important that we have an accurate email address.</p>")
    .Button("https://www.example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/CustomThemeAndRawHtml.html)

## Another way to create your email
```
var body = MailBody.CreateBody();

body.Paragraph("Hi,")
    .Paragraph("First paragraph..");

// Your code

body.Button("https://www.example.com/", "First button");
body.Paragraph("Another paragraph..");

// Your code

body.Button("https://www.example.com/", "Second button")
    .Paragraph("— [Insert company name here]");

var htmlBody = body.ToString();
```

[Preview](https://cdn.rawgit.com/doxakis/MailBody/master/src/Example/Output/AnotherWay.html)

# Copyright and license
Code released under the MIT license.
