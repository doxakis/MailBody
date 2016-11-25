using System;
using System.Collections.Generic;
using System.Text;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    public class CustomMailBlock : MailBlockFluent
    {
        private ICustomMailTemplate _mailTemplate;

        private CustomMailBlock(MailBodyTemplate template, MailBlockFluent footer, ICustomMailTemplate mailTemplate)
            : base(template, footer)
        {
            _mailTemplate = mailTemplate;

        }

        public static CustomMailBlock CreateBlock(ICustomMailTemplate mailTemplate) =>
            new CustomMailBlock(null, null, mailTemplate);
        

        public override MailBlockFluent Title(string content)
        {
            Body.Append(_mailTemplate.Title(content));
            return this;
        }

        public override MailBlockFluent SubTitle(string content)
        {
            Body.Append(_mailTemplate.SubTitleTag(content));
            return this;
        }

        public override MailBlockFluent Paragraph(string content)
        {
            Body.Append(_mailTemplate.Paragraph(content));
            return this;
        }

        public override MailBlockFluent Paragraph(MailBlockFluent block)
        {
            Body.Append(_mailTemplate.Paragraph(block.ToString()));
            return this;
        }

        public override MailBlockFluent Link(string link)
        {
            Body.Append(_mailTemplate.Link(link, link));
            return this;
        }

        public override MailBlockFluent Link(string link, string text)
        {
            Body.Append(_mailTemplate.Link(link, text));
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
                builder.Append(_mailTemplate.ListItem(item.ToString()));
            }
            Body.Append(_mailTemplate.UnorderedList(builder.ToString()));
            return this;
        }

        public override MailBlockFluent OrderedList(IEnumerable<MailBlockFluent> items)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(_mailTemplate.ListItem(item.ToString()));
            }
            Body.Append(_mailTemplate.OrderedList(builder.ToString()));
            return this;
        }

        public override string ToString()
        {
            var html =$@"<!doctype html>
<html>
    <head>
        {_mailTemplate.Head}
    </head>
        {_mailTemplate.Body(Body.ToString(), FooterContent)}
</html>";

            return html;
        }

        public override string GenerateHtml() =>
            ToString();

        public override MailBlockFluent Paragraph(Func<ICustomMailTemplate, string> blockFunc)
        {
            return Paragraph(blockFunc(_mailTemplate));
        }

        public override MailBlockFluent Block(Func<ICustomMailTemplate, MailBlockFluent> blockFunc)
        {
            return base.Block(blockFunc(_mailTemplate));
        }

        public override MailBlockFluent Footer(Func<ICustomMailTemplate, MailBlockFluent> blockFunc)
        {
            return base.Footer(blockFunc(_mailTemplate));
        }
    }
}