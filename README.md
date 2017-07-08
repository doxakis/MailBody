# MailBody [![Build Status](https://travis-ci.org/doxakis/MailBody.svg?branch=master)](https://travis-ci.org/doxakis/MailBody) [![NuGet Status](https://badge.fury.io/nu/mailbody.svg)](https://www.nuget.org/packages/MailBody)
MailBody is a library for generating transactional email by using a fluent interface.

The current mail template is based on https://github.com/leemunroe/responsive-html-email-template
(MIT License 2013 Lee Munroe)

# Supported framework
- dotnet core 1.0
- .net framework 4.5 (c#, vb)

# Install from Nuget
To get the latest version:
```
Install-Package MailBody
```

# Quick Examples

## Email Address Confirmation

### C# syntax:
```
var body = MailBody
    .CreateBody()
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
    .Button("https://example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

### Visual Basic syntax:
```
Dim body As String = MailBody.CreateBody() _
    .Paragraph("Please confirm your email address by clicking the link below.") _
    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.") _
    .Button("https://example.com/", "Confirm Email Address") _
    .Paragraph("— [Insert company name here]") _
    .ToString()
```
[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/EmailAddressConfirmation.html)

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

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/PasswordReset.html)

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

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/OrderConfirmation.html)

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

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/Notification.html)

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

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/Withfooter.html)

## With image
**Please note** You can use CID Embedded Images, Base64 Encoding or use absolute url.
Image may not appear on all email client. So, make sure to do some tests.

```
var body = MailBody
    .CreateBody()
    .Image("https://placehold.it/540x70/ffffff/e8117f?text=My+logo", "My company name")
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
    .Button("https://example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/WithImage.html)

## Custom theme & Raw html
```
var template = MailBodyTemplate.GetDefaultTemplate();
template
    .Paragraph(m =>
        "<p style='" +
        (m.IsProperty(() => m.Attributes.color) ? $"color:{m.Attributes.color};" : string.Empty) +
        (m.IsProperty(() => m.Attributes.backgroundColor) ? $"background-color:{m.Attributes.backgroundColor};" : string.Empty) +
        $"'>{m.Content}</p>")
    .Body(m => "<html><body>" + m.Content + "<br />" + m.Footer + "</body></html>")
    .Text(m =>
        $"<span style='" +
        (m.IsProperty(() => m.Attributes.color) ? $"color:{m.Attributes.color};" : string.Empty) +
        (m.IsProperty(() => m.Attributes.backgroundColor) ? $"background-color:{m.Attributes.backgroundColor};" : string.Empty) +
        (m.IsProperty(() => m.Attributes.fontWeight) ? $"font-weight:{m.Attributes.fontWeight};" : string.Empty) +
        $"'>{m.Content}</span>");

var footer = MailBody
    .CreateBlock()
    .Text("Follow ", new { color = "red"})
    .Link("http://twitter.com/example", "@Example")
    .Text(" on Twitter.", new { color = "#009900", backgroundColor = "#CCCCCC", fontWeight = "bold" });
            
var body = MailBody
    .CreateBody(template, footer)
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Raw("<p>We may need to send you <strong>critical information</strong> about our service and it is important that we have an accurate email address.</p>")
    .Button("https://www.example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]", new { color = "white", backgroundColor = "black" })
    .ToString();
```

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/CustomThemeAndRawHtml.html)

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

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/AnotherWay.html)

## Override the default template
This example is based on [Postmark templates](https://github.com/wildbit/postmark-templates).

```
var template = MailBodyTemplate.GetDefaultTemplate()
    .Paragraph(m => $"<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>{m.Content}</p>")
    .Link(m => $"<a href='{m.Link}'>{m.Content}</a>")
    .Title(m => $"<h1>{m.Content}</h1>")
    .SubTitle(m => $"<h2>{m.Content}</h2>")
    .Text(m => $"{m.Content}")
    .StrongText(m => $"<strong>{m.Content}</strong>")
    .UnorderedList(m => $"<ul>{m.Content}</ul>")
    .OrderedList(m => $"<ol>{m.Content}</ol>")
    .ListItem(m => $"<li>{m.Content}</li>")
    .LineBreak(m => $"</br>")
    .Button(m => @"<table class='body-action' align='center' width='100%' cellpadding='0' cellspacing='0'>
            <tr>
                <td align='center'>
                <table width='100%' border='0' cellspacing='0' cellpadding='0'>
                    <tr>
                    <td align='center'>
                        <table border='0' cellspacing='0' cellpadding='0'>
                        <tr>
                            <td>
                            <a href='" + m.Link + @"' class='button button--' target='_blank'>" + m.Content + @"</a>
                            </td>
                        </tr>
                        </table>
                    </td>
                    </tr>
                </table>
                </td>
            </tr>
            </table>")
    .Block(m => m.Content)
    .Body(m => @"<html>... (see the examples for the complete source) ...</html>");

var body = MailBody
    .CreateBody(template)
    .Paragraph("Please confirm your email address by clicking the link below.")
    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
    .Button("https://example.com/", "Confirm Email Address")
    .Paragraph("— [Insert company name here]")
    .ToString();
```

[Preview](https://rawgit.com/doxakis/MailBody/master/src/Example/Output/OverrideDefaultTemplate.html)

# Copyright and license
Code released under the MIT license.
