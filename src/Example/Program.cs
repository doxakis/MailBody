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

            //var body = MailBody
            //    .CreateBody()
            //    .Paragraph("Please confirm your email address by clicking the link below.")
            //    .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
            //    .Button("https://example.com/", "Confirm Email Address")
            //    .Paragraph("— [Insert company name here]")
            //    .ToString();

            // Save on disk (for testing)
            File.WriteAllText(@"C:\temp\index.html", body);
        }
    }
}
