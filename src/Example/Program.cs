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
            var body = MailBody
                .CreateBody()
                .Paragraph("Hi there,")
                .Paragraph("Sometimes you just want to send a simple HTML email with a simple design and clear call to action.This is it.")
                .Button("https://google.ca", "Call To Action")
                .Paragraph("This is a really simple email template. It's sole purpose is to get the recipient to click the button with no distractions.")
                .Paragraph("Good luck! Hope it works.")
                .ToString();
            Console.WriteLine(body);
            Console.ReadKey();

            // Save on disk (for testing)
            //File.WriteAllText(@"C:\temp\index.html", body);
        }
    }
}
