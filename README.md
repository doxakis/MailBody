# MailBody [![Build Status](https://travis-ci.org/doxakis/MailBody.svg?branch=master)](https://travis-ci.org/doxakis/MailBody)
MailBody is a library for generating simple transaction mail.
Mails are created by using a fluent interface.

The current mail template is based on https://github.com/leemunroe/responsive-html-email-template
(MIT License 2013 Lee Munroe)

# Install from Nuget
To get the latest version:
```
Install-Package MailBody
```

# Supported framework
- dotnet core 1.0
- .net framework 4.5

# Quick Examples

## Simple
```
var body = MailBody
	.CreateBody()
	.Paragraph("Please confirm your email address by clicking the link below.")
	.Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
	.Button("https://example.com/", "Confirm Email Address")
	.Paragraph("— [Insert company name here]")
	.ToString();
```

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

# Copyright and license
Code released under the MIT license.
