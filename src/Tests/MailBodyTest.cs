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

        [Theory]
        [InlineData("fontSize", true)]
        [InlineData("color", false)]
        public void HasAttribute_AndAnonymousObject_AndVaryPropertyName(string propertyName, bool expected)
        {
            var element = new ContentElement
            {
                Attributes = new { fontSize = "12px" }
            };

            var actual = element.HasAttribute(propertyName);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("fontSize", true)]
        [InlineData("color", false)]
        public void HasAttribute_AndDictionary_AndVaryPropertyName(string propertyName, bool expected)
        {
            var element = new ContentElement
            {
                Attributes = new Dictionary<string, string> { ["fontSize"] = "12px" }
            };

            var actual = element.HasAttribute(propertyName);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("FontSize", true)]
        [InlineData("color", false)]
        public void HasAttribute_AndClass_AndVaryPropertyName(string propertyName, bool expected)
        {
            var element = new ContentElement
            {
                Attributes = new CssAttributes { FontSize = "12px" }
            };

            var actual = element.HasAttribute(propertyName);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryGetAttribute_AndAnonymousObject_AndPropertyExists()
        {
            var element = new ContentElement
            {
                Attributes = new { fontSize = "12px" }
            };

            var actual = element.TryGetAttribute("fontSize", out string size);

            Assert.True(actual);
            Assert.Equal("12px", size);
        }

        [Fact]
        public void TryGetAttribute_AndAnonymousObject_AndPropertyIsMissing()
        {
            var element = new ContentElement
            {
                Attributes = new { fontSize = "12px" }
            };

            var actual = element.TryGetAttribute("color", out string color);

            Assert.False(actual);
            Assert.Null(color);
        }

        [Fact]
        public void TryGetAttribute_AndDictionary_AndPropertyExists()
        {
            var element = new ContentElement
            {
                Attributes = new Dictionary<string, string> { ["fontSize"] = "12px" }
            };

            var actual = element.TryGetAttribute("fontSize", out string size);

            Assert.True(actual);
            Assert.Equal("12px", size);
        }

        [Fact]
        public void TryGetAttribute_AndDictionary_AndPropertyIsMissing()
        {
            var element = new ContentElement
            {
                Attributes = new Dictionary<string, string> { ["fontSize"] = "12px" }
            };

            var actual = element.TryGetAttribute("color", out string color);

            Assert.False(actual);
            Assert.Null(color);
        }

        [Fact]
        public void TryGetAttribute_AndClass_AndPropertyExists()
        {
            var element = new ContentElement
            {
                Attributes = new CssAttributes { FontSize = "12px" }
            };

            var actual = element.TryGetAttribute("FontSize", out string size);

            Assert.True(actual);
            Assert.Equal("12px", size);
        }

        [Fact]
        public void TryGetAttribute_AndClass_AndPropertyIsMissing()
        {
            var element = new ContentElement
            {
                Attributes = new CssAttributes { FontSize = "12px" }
            };

            var actual = element.TryGetAttribute("color", out string color);

            Assert.False(actual);
            Assert.Null(color);
        }

        [Fact]
        public void DifferentAssemblyDynamicAttributesTest()
        {
            const string text = "test";
            const string size = "12px";
            var template = Example.Program.GetOnlyParagraphWithFontSizeStyleTemplate();

            var html = MailBody
                .CreateBody(template)
                .Paragraph(text, new { fontSize = size })
                .GenerateHtml();

            Assert.Equal($"<p style='font-size: {size};'>{text}</p>", html);
        }
    }
}
