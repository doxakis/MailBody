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
            var buttonsArray = new Tuple<string,string>[] { Tuple.Create<string,string>("http://www.google.com", "Button A"), Tuple.Create<string, string>("http://www.disney.com", "Button B") };
            
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
    }
}
