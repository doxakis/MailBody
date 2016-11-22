using System.Collections.Generic;
using System.Text;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    public class CustomMailBlock : MailBlockFluent
    {
        private static ICustomizableMailTemplate _mailTemplate;

        private CustomMailBlock(MailBodyTemplate template, MailBlockFluent footer) : base(template, footer)
        {
        }

        public static CustomMailBlock CreateBlock(ICustomizableMailTemplate mailTemplate)
        {
            _mailTemplate = mailTemplate;
            return new CustomMailBlock(null, null);
        }

        public override MailBlockFluent Title(string content)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetTitle(content)));
            return this;
        }

        public override MailBlockFluent SubTitle(string content)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetSubTitle(content)));
            return this;
        }

        public override MailBlockFluent Paragraph(string content)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetParagraph(content)));
            return this;
        }

        public override MailBlockFluent Paragraph(MailBlockFluent block)
        {
            return base.Paragraph(block);
        }

        public override MailBlockFluent Link(string link)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetLink(link, link)));
            return this;
        }

        public override MailBlockFluent Link(string link, string text)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetLink(link, text)));
            return this;
        }

        public override MailBlockFluent Button(string link, string text)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetButton(link, text)));
            return this;
        }

        public override MailBlockFluent Text(string text)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetText(text)));
            return this;
        }

        public override MailBlockFluent StrongText(string text)
        {
            Body.Append(MailBody.HtmlEncode(_mailTemplate.GetStrongText(text)));
            return this;
        }

        public override MailBlockFluent Raw(string html)
        {
            return base.Raw(html);
        }

        public override MailBlockFluent LineBreak()
        {
            Body.Append(_mailTemplate.GetLineBreak());
            return this;
        }

        public override MailBlockFluent UnorderedList(IEnumerable<MailBlockFluent> items)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(MailBody.HtmlEncode(_mailTemplate.GetListItem(item.ToString())));
            }
            Body.Append(_mailTemplate.GetUnorderedList(builder.ToString()));
            return this;
        }

        public override MailBlockFluent OrderedList(IEnumerable<MailBlockFluent> items)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(MailBody.HtmlEncode(_mailTemplate.GetListItem(item.ToString())));
            }
            Body.Append(_mailTemplate.GetOrderedList(builder.ToString()));
            return this;
        }

        public override string ToString()
        {
            return _mailTemplate.GetBody(Body.ToString());
        }
    }
}