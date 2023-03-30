using System.Collections.Generic;
using Xunit;
using MailBodyPack;

namespace Tests
{
    public class MailBodyTest
    {
        [Fact]
        public void Simple()
        {
            var body = MailBody
                .CreateBody()
                .Paragraph("Please confirm your email address by clicking the link below.")
                .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.")
                .Button("https://example.com/", "Confirm Email Address")
                .Paragraph("— [Insert company name here]")
                .ToString();

            Assert.NotEmpty(body);
        }

        [Fact]
        public void WithFooter()
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

            Assert.NotEmpty(body);
        }

        [Fact]
        public void CustomThemeAndRawHtml()
        {
            var template = MailBodyTemplate.GetDefaultTemplate()
                .Paragraph(m => $"<p style='color:blue;'>{m.Content}</p>")
                .Body(m => "<html><body>" + m.Content + "<br />" + m.Footer + "</body></html>");

            var footer = MailBody
                .CreateBlock()
                .Text("Follow ")
                .Link("http://twitter.com/example", "@Example")
                .Text(" on Twitter.");

            var body = MailBody
                .CreateBody(template, footer)
                .Paragraph("Please confirm your email address by clicking the link below.")
                .Raw("<p>We may need to send you <strong>critical information</strong> about our service and it is important that we have an accurate email address.</p>")
                .Button("https://www.example.com/", "Confirm Email Address")
                .Paragraph("— [Insert company name here]")
                .ToString();

            Assert.NotEmpty(body);
        }

        [Fact]
        public void RunExampleProject()
        {
            Example.Program.Main(new string[0]);
        }

        public class CssAttributes
        {
            public string FontSize { get; set; }
        }

        [Fact]
        public void ElementHasAttributeFromAnonymousObject()
        {
            var element = new ContentElement
            {
                Content = "<p>test</p>",
                Attributes = new { fontSize = "12px" }
            };

            Assert.True(element.HasAttribute("fontSize"));
            Assert.False(element.HasAttribute("color"));
        }

        [Fact]
        public void ElementHasAttributeFromDictionary()
        {
            var element = new ContentElement
            {
                Content = "<p>test</p>",
                Attributes = new Dictionary<string, string>() { ["fontSize"] = "12px" }
            };

            Assert.True(element.HasAttribute("fontSize"));
            Assert.False(element.HasAttribute("color"));
        }

        [Fact]
        public void ElementHasAttributeFromClass()
        {
            var element = new ContentElement
            {
                Content = "<p>test</p>",
                Attributes = new CssAttributes { FontSize = "12px" }
            };

            Assert.True(element.HasAttribute("FontSize"));
            Assert.False(element.HasAttribute("color"));
        }

        [Fact]
        public void ElementTryGetAttributeFromAnonymousObject()
        {
            var element = new ContentElement
            {
                Content = "<p>test</p>",
                Attributes = new { fontSize = "12px" }
            };

            string size = null;
            bool sizeExist = element.TryGetAttribute("fontSize", out size);

            Assert.True(sizeExist);
            Assert.Equal("12px", size);

            string color = null;
            bool colorExist = element.TryGetAttribute("color", out size);

            Assert.False(colorExist);
            Assert.Null(color);
        }

        [Fact]
        public void ElementTryGetAttributeFromDictionary()
        {
            var element = new ContentElement
            {
                Content = "<p>test</p>",
                Attributes = new Dictionary<string, string>() { ["fontSize"] = "12px" }
            };

            string size = null;
            bool sizeExist = element.TryGetAttribute("fontSize", out size);

            Assert.True(sizeExist);
            Assert.Equal("12px", size);

            string color = null;
            bool colorExist = element.TryGetAttribute("color", out size);

            Assert.False(colorExist);
            Assert.Null(color);
        }

        [Fact]
        public void ElementTryGetAttributeFromClass()
        {
            var element = new ContentElement
            {
                Content = "<p>test</p>",
                Attributes = new CssAttributes { FontSize = "12px" }
            };

            string size = null;
            bool sizeExist = element.TryGetAttribute("FontSize", out size);

            Assert.True(sizeExist);
            Assert.Equal("12px", size);

            string color = null;
            bool colorExist = element.TryGetAttribute("color", out size);

            Assert.False(colorExist);
            Assert.Null(color);
        }

        [Fact]
        public void DifferentAssemblyDynamicAttributesTest()
        {
            string text = "test";
            string size = "12px";

            var template = Example.Program.GetOnlyParagraphWithFontSizeStyleTemplate();

            var html = MailBody
                .CreateBody(template)
                .Paragraph(text, new { fontSize = size })
                .GenerateHtml();

            Assert.Equal($"<p style='font-size: {size};'>{text}</p>", html);
        }
    }
}
