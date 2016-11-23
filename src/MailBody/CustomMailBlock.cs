using System;
using System.Collections.Generic;
using System.Text;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    public class CustomMailBlock : MailBlockFluent
    {
        private ICustomizableMailTemplate _mailTemplate;

        private CustomMailBlock(MailBodyTemplate template, MailBlockFluent footer, ICustomizableMailTemplate mailTemplate)
            : base(template, footer)
        {
            _mailTemplate = mailTemplate;

        }

        public static CustomMailBlock CreateBlock(ICustomizableMailTemplate mailTemplate)
        {
            return new CustomMailBlock(null, null, mailTemplate);
        }

        public override MailBlockFluent Title(string content)
        {
            Body.Append(_mailTemplate.TitleTag(content));
            return this;
        }

        public override MailBlockFluent SubTitle(string content)
        {
            Body.Append(_mailTemplate.SubTitleTag(content));
            return this;
        }

        public override MailBlockFluent Paragraph(string content)
        {
            Body.Append(_mailTemplate.ParagraphTag(content));
            return this;
        }

        public override MailBlockFluent Paragraph(MailBlockFluent block)
        {
            Body.Append(_mailTemplate.ParagraphTag(block.ToString()));
            return this;
        }

        public override MailBlockFluent Link(string link)
        {
            Body.Append(_mailTemplate.LinkTag(link, link));
            return this;
        }

        public override MailBlockFluent Link(string link, string text)
        {
            Body.Append(_mailTemplate.LinkTag(link, text));
            return this;
        }

        public override MailBlockFluent Button(string link, string text)
        {
            Body.Append(_mailTemplate.Button(link, text));
            return this;
        }

        public override MailBlockFluent Text(string text)
        {
            Body.Append(_mailTemplate.Text(text));
            return this;
        }

        public override MailBlockFluent StrongText(string text)
        {
            Body.Append(_mailTemplate.StrongText(text));
            return this;
        }

        public override MailBlockFluent Raw(string html)
        {
            return base.Raw(html);
        }

        public override MailBlockFluent LineBreak()
        {
            Body.Append(_mailTemplate.LineBreak);
            return this;
        }

        public override MailBlockFluent UnorderedList(IEnumerable<MailBlockFluent> items)
        {
            
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(_mailTemplate.ListItemTag(item.ToString()));
            }
            Body.Append(_mailTemplate.UnorderedListTag(builder.ToString()));
            return this;
        }

        public override MailBlockFluent OrderedList(IEnumerable<MailBlockFluent> items)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(_mailTemplate.ListItemTag(item.ToString()));
            }
            Body.Append(_mailTemplate.OrderedListTag(builder.ToString()));
            return this;
        }

        public override string ToString()
        {
            var html =$@"<!doctype html>
<html>
    <head>
        {_mailTemplate.Head}
    </head>
    <body>
        {_mailTemplate.Body(Body.ToString())}
    </body>
</html>";

            return html;
        }

        public override string ToBody() =>
            ToString();

        public override MailBlockFluent Paragraph(Func<ICustomizableMailTemplate, string> blockFunc)
        {
            return Paragraph(blockFunc(_mailTemplate));
        }

        public override MailBlockFluent Block(Func<ICustomizableMailTemplate, string> blockFunc)
        {
            return base.Block(blockFunc(_mailTemplate));
        }
    }
}