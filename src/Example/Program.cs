using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailBodyPack;
using System.IO;

namespace Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Directory.CreateDirectory("Output");
            File.WriteAllText(@"Output/EmailAddressConfirmation.html", GenerateEmailAddressConfirmation());
            File.WriteAllText(@"Output/PasswordReset.html", GeneratePasswordReset());
            File.WriteAllText(@"Output/OrderConfirmation.html", GenerateOrderConfirmation());
            File.WriteAllText(@"Output/Notification.html", GenerateNotification());
            File.WriteAllText(@"Output/Blocks.html", GenerateBlocks());
            File.WriteAllText(@"Output/Withfooter.html", GenerateWithfooter());
            File.WriteAllText(@"Output/CustomThemeAndRawHtml.html", GenerateCustomThemeAndRawHtml());
            File.WriteAllText(@"Output/AnotherWay.html", GenerateAnotherWay());
            File.WriteAllText(@"Output/OverrideDefaultTemplate.html", GenerateOverrideDefaultTemplate());
            File.WriteAllText(@"Output/WithImage.html", GenerateWithImages());
        }

        public static string GenerateEmailAddressConfirmation()
        {
            var body = MailBody
                .CreateBody()
                .Paragraph("Please confirm your email address by clicking the link below.")
                .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
                .Button("https://example.com/", "Confirm Email Address")
                .Paragraph("— [Insert company name here]")
                .ToString();

            return body;
        }

        public static string GenerateWithfooter()
        {
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

            return body;
        }

        public static string GenerateCustomThemeAndRawHtml()
        {
            var template = MailBodyTemplate.GetDefaultTemplate();
            template
                .Paragraph(m =>
                    "<p style='" +
                    (m.HasAttribute("color") ? $"color:{m.Attributes.color};" : string.Empty) +
                    (m.HasAttribute("backgroundColor") ? $"background-color:{m.Attributes.backgroundColor};" : string.Empty) +
                    $"'>{m.Content}</p>")
                .Body(m => "<html><body>" + m.Content + "<br />" + m.Footer + "</body></html>")
                .Text(m =>
                    $"<span style='" +
                    (m.HasAttribute("color") ? $"color:{m.Attributes.color};" : string.Empty) +
                    (m.HasAttribute("backgroundColor") ? $"background-color:{m.Attributes.backgroundColor};" : string.Empty) +
                    (m.HasAttribute("fontWeight") ? $"font-weight:{m.Attributes.fontWeight};" : string.Empty) +
                    $"'>{m.Content}</span>");

            var footer = MailBody
                .CreateBlock()
                .Text("Follow ", new { color = "red" })
                .Link("http://twitter.com/example", "@Example")
                .Text(" on Twitter.", new { color = "#009900", backgroundColor = "#CCCCCC", fontWeight = "bold" });

            var body = MailBody
                .CreateBody(template, footer)
                .Paragraph("Please confirm your email address by clicking the link below.")
                .Raw("<p>We may need to send you <strong>critical information</strong> about our service and it is important that we have an accurate email address.</p>")
                .Button("https://www.example.com/", "Confirm Email Address")
                .Paragraph("— [Insert company name here]", new { color = "white", backgroundColor = "black" })
                .ToString();

            return body;
        }

        public static string GenerateOrderConfirmation()
        {
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

            return body;
        }

        public static string GenerateNotification()
        {
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

            return body;
        }

        public static string GenerateBlocks()
        {
            var componentsArray = new string[] { "Block A", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla sagittis nisl ut tellus egestas facilisis. Nulla eget erat dictum, facilisis libero sit amet, sollicitudin tortor. Morbi iaculis, urna eu tincidunt dapibus, sapien ex dictum nibh, non congue urna tellus vitae risus." };
            var buttonsArray = new Tuple<string, string>[] { Tuple.Create<string, string>("http://www.google.com", "Button A"), Tuple.Create<string, string>("http://www.disney.com", "Button B") };

            var items = componentsArray.Select(item => MailBody.CreateBlock().Paragraph(item));
            var buttons = buttonsArray.Select(item => MailBody.CreateBlock().Button(item.Item1, item.Item2));

            var body = MailBody
                .CreateBody()
                .Paragraph("Hello,")
                .SubTitle("Here is the blocks:")
                .AddBlocksList(items)
                .AddBlocksList(buttons)
                .Paragraph("— [Insert company name here]")
                .ToString();

            return body;
        }

        public static string GeneratePasswordReset()
        {
            var appName = "My app";

            var body = MailBody
                .CreateBody()
                .Paragraph("Hi,")
                .Paragraph("You're receiving this email because someone requested a password reset for your user account at " + appName + ".")
                .Button("https://www.example.com/", "Reset password")
                .Paragraph("Thanks for using " + appName + "!")
                .Paragraph("— [Insert company name here]")
                .ToString();

            return body;
        }

        public static string GenerateAnotherWay()
        {
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

            return htmlBody;
        }

        public static string GenerateOverrideDefaultTemplate()
        {
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
                .Body(m => // The template is based on: https://github.com/wildbit/postmark-templates
@"<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
  <head>
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <title>Welcome to [Product Name], {{name}}!</title>
    <!-- 
    The style block is collapsed on page load to save you some scrolling.
    Postmark automatically inlines all CSS properties for maximum email client 
    compatibility. You can just update styles here, and Postmark does the rest.
    -->
    <style type='text/css' rel='stylesheet' media='all'>
    /* Base ------------------------------ */
    
    *:not(br):not(tr):not(html) {
      font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;
      box-sizing: border-box;
    }
    
    body {
      width: 100% !important;
      height: 100%;
      margin: 0;
      line-height: 1.4;
      background-color: #F2F4F6;
      color: #74787E;
      -webkit-text-size-adjust: none;
    }
    
    p,
    ul,
    ol,
    blockquote {
      line-height: 1.4;
      text-align: left;
    }
    
    a {
      color: #3869D4;
    }
    
    a img {
      border: none;
    }
    /* Layout ------------------------------ */
    
    .email-wrapper {
      width: 100%;
      margin: 0;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #F2F4F6;
    }
    
    .email-content {
      width: 100%;
      margin: 0;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    /* Masthead ----------------------- */
    
    .email-masthead {
      padding: 25px 0;
      text-align: center;
    }
    
    .email-masthead_logo {
      width: 94px;
    }
    
    .email-masthead_name {
      font-size: 16px;
      font-weight: bold;
      color: #bbbfc3;
      text-decoration: none;
      text-shadow: 0 1px 0 white;
    }
    /* Body ------------------------------ */
    
    .email-body {
      width: 100%;
      margin: 0;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      border-top: 1px solid #EDEFF2;
      border-bottom: 1px solid #EDEFF2;
      background-color: #FFFFFF;
    }
    
    .email-body_inner {
      width: 570px;
      margin: 0 auto;
      padding: 0;
      -premailer-width: 570px;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #FFFFFF;
    }
    
    .email-footer {
      width: 570px;
      margin: 0 auto;
      padding: 0;
      -premailer-width: 570px;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      text-align: center;
    }
    
    .email-footer p {
      color: #AEAEAE;
    }
    
    .body-action {
      width: 100%;
      margin: 30px auto;
      padding: 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      text-align: center;
    }
    
    .body-sub {
      margin-top: 25px;
      padding-top: 25px;
      border-top: 1px solid #EDEFF2;
    }
    
    .content-cell {
      padding: 35px;
    }
    
    .preheader {
      display: none !important;
    }
    /* Attribute list ------------------------------ */
    
    .attributes {
      margin: 0 0 21px;
    }
    
    .attributes_content {
      background-color: #EDEFF2;
      padding: 16px;
    }
    
    .attributes_item {
      padding: 0;
    }
    /* Related Items ------------------------------ */
    
    .related {
      width: 100%;
      margin: 0;
      padding: 25px 0 0 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    
    .related_item {
      padding: 10px 0;
      color: #74787E;
      font-size: 15px;
      line-height: 18px;
    }
    
    .related_item-title {
      display: block;
      margin: .5em 0 0;
    }
    
    .related_item-thumb {
      display: block;
      padding-bottom: 10px;
    }
    
    .related_heading {
      border-top: 1px solid #EDEFF2;
      text-align: center;
      padding: 25px 0 10px;
    }
    /* Discount Code ------------------------------ */
    
    .discount {
      width: 100%;
      margin: 0;
      padding: 24px;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
      background-color: #EDEFF2;
      border: 2px dashed #9BA2AB;
    }
    
    .discount_heading {
      text-align: center;
    }
    
    .discount_body {
      text-align: center;
      font-size: 15px;
    }
    /* Social Icons ------------------------------ */
    
    .social {
      width: auto;
    }
    
    .social td {
      padding: 0;
      width: auto;
    }
    
    .social_icon {
      height: 20px;
      margin: 0 8px 10px 8px;
      padding: 0;
    }
    /* Data table ------------------------------ */
    
    .purchase {
      width: 100%;
      margin: 0;
      padding: 35px 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    
    .purchase_content {
      width: 100%;
      margin: 0;
      padding: 25px 0 0 0;
      -premailer-width: 100%;
      -premailer-cellpadding: 0;
      -premailer-cellspacing: 0;
    }
    
    .purchase_item {
      padding: 10px 0;
      color: #74787E;
      font-size: 15px;
      line-height: 18px;
    }
    
    .purchase_heading {
      padding-bottom: 8px;
      border-bottom: 1px solid #EDEFF2;
    }
    
    .purchase_heading p {
      margin: 0;
      color: #9BA2AB;
      font-size: 12px;
    }
    
    .purchase_footer {
      padding-top: 15px;
      border-top: 1px solid #EDEFF2;
    }
    
    .purchase_total {
      margin: 0;
      text-align: right;
      font-weight: bold;
      color: #2F3133;
    }
    
    .purchase_total--label {
      padding: 0 15px 0 0;
    }
    /* Utilities ------------------------------ */
    
    .align-right {
      text-align: right;
    }
    
    .align-left {
      text-align: left;
    }
    
    .align-center {
      text-align: center;
    }
    /*Media Queries ------------------------------ */
    
    @media only screen and (max-width: 600px) {
      .email-body_inner,
      .email-footer {
        width: 100% !important;
      }
    }
    
    @media only screen and (max-width: 500px) {
      .button {
        width: 100% !important;
      }
    }
    /* Buttons ------------------------------ */
    
    .button {
      background-color: #3869D4;
      border-top: 10px solid #3869D4;
      border-right: 18px solid #3869D4;
      border-bottom: 10px solid #3869D4;
      border-left: 18px solid #3869D4;
      display: inline-block;
      color: #FFF;
      text-decoration: none;
      border-radius: 3px;
      box-shadow: 0 2px 3px rgba(0, 0, 0, 0.16);
      -webkit-text-size-adjust: none;
    }
    
    .button--green {
      background-color: #22BC66;
      border-top: 10px solid #22BC66;
      border-right: 18px solid #22BC66;
      border-bottom: 10px solid #22BC66;
      border-left: 18px solid #22BC66;
    }
    
    .button--red {
      background-color: #FF6136;
      border-top: 10px solid #FF6136;
      border-right: 18px solid #FF6136;
      border-bottom: 10px solid #FF6136;
      border-left: 18px solid #FF6136;
    }
    /* Type ------------------------------ */
    
    h1 {
      margin-top: 0;
      color: #2F3133;
      font-size: 19px;
      font-weight: bold;
      text-align: left;
    }
    
    h2 {
      margin-top: 0;
      color: #2F3133;
      font-size: 16px;
      font-weight: bold;
      text-align: left;
    }
    
    h3 {
      margin-top: 0;
      color: #2F3133;
      font-size: 14px;
      font-weight: bold;
      text-align: left;
    }
    
    p {
      margin-top: 0;
      color: #74787E;
      font-size: 16px;
      line-height: 1.5em;
      text-align: left;
    }
    
    p.sub {
      font-size: 12px;
    }
    
    p.center {
      text-align: center;
    }
    </style>
  </head>
  <body>
    <table class='email-wrapper' width='100%' cellpadding='0' cellspacing='0'>
      <tr>
        <td align='center'>
          <table class='email-content' width='100%' cellpadding='0' cellspacing='0'>
            <!-- Email Body -->
            <tr>
              <td class='email-body' width='100%' cellpadding='0' cellspacing='0'>
                <table class='email-body_inner' align='center' width='570' cellpadding='0' cellspacing='0'>
                  <!-- Body content -->
                  <tr>
                    <td class='content-cell'>" + m.Content + @"</td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr>
              <td>
                <table class='email-footer' align='center' width='570' cellpadding='0' cellspacing='0'>
                  <tr>
                    <td class='content-cell' align='center'>
                      " + m.Footer + @"
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  <script type='text/javascript'>/* <![CDATA[ */(function(d,s,a,i,j,r,l,m,t){try{l=d.getElementsByTagName('a');t=d.createElement('textarea');for(i=0;l.length-i;i++){try{a=l[i].href;s=a.indexOf('/cdn-cgi/l/email-protection');m=a.length;if(a&&s>-1&&m>28){j=28+s;s='';if(j<m){r='0x'+a.substr(j,2)|0;for(j+=2;j<m&&a.charAt(j)!='X';j+=2)s+='%'+('0'+('0x'+a.substr(j,2)^r).toString(16)).slice(-2);j++;s=decodeURIComponent(s)+a.substr(j,m-j)}t.innerHTML=s.replace(/</g,'&lt;').replace(/>/g,'&gt;');l[i].href='mailto:'+t.value}}catch(e){}}}catch(e){}})(document);/* ]]> */</script></body>
</html>");

            var body = MailBody
                .CreateBody(template)
                .Paragraph("Please confirm your email address by clicking the link below.")
                .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
                .Button("https://example.com/", "Confirm Email Address")
                .Paragraph("— [Insert company name here]")
                .ToString();

            return body;
        }

        public static string GenerateWithImages()
        {
            var body = MailBody
                .CreateBody()
                .Image("https://placehold.it/540x70/ffffff/e8117f?text=My+logo", "My company name")
                .Paragraph("Please confirm your email address by clicking the link below.")
                .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
                .Button("https://example.com/", "Confirm Email Address")
                .Paragraph("— [Insert company name here]")
                .ToString();

            return body;
        }

        public static MailBodyTemplate GetOnlyParagraphWithFontSizeStyleTemplate()
        {
            var template = MailBodyTemplate.GetDefaultTemplate()
                .Paragraph(m =>
                {
                    string fontSize = null;
                    var hasFontSize = m.TryGetAttribute<string>("fontSize", out fontSize);
                    return $"<p{(hasFontSize ? $" style='font-size: {fontSize};'" : "")}>{m.Content}</p>";
                })
                .Body(m => m.Content);

            return template;
        }
    }
}
