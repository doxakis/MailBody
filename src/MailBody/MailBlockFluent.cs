using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace MailBodyPack
{
    public class MailBlockFluent
    {
        private StringBuilder _body = new StringBuilder();
        private MailBodyTemplate _template;
        private MailBlockFluent _footer;

        public MailBlockFluent(MailBodyTemplate template, MailBlockFluent footer)
        {
            _template = template;
            _footer = footer;
        }

        /// <summary>
        /// Add a new title.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public MailBlockFluent Title(string content, dynamic attributes = null)
        {
            var element = new ContentElement { Content = MailBody.HtmlEncode(content), Attributes = attributes };
            _body.Append(_template.Title()(element));
            return this;
        }

        /// <summary>
        /// Add a new subtitle.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public MailBlockFluent SubTitle(string content, dynamic attributes = null)
        {
            var element = new ContentElement { Content = MailBody.HtmlEncode(content), Attributes = attributes };
            _body.Append(_template.SubTitle()(element));
            return this;
        }

        /// <summary>
        /// Add a new paragraph.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public MailBlockFluent Paragraph(string content, dynamic attributes = null)
        {
            var element = new ContentElement { Content = MailBody.HtmlEncode(content), Attributes = attributes };
            _body.Append(_template.Paragraph()(element));
            return this;
        }

        /// <summary>
        /// Add a new paragraph
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        public MailBlockFluent Paragraph(MailBlockFluent block, dynamic attributes = null)
        {
            var element = new ContentElement { Content = block.ToString() };
            _body.Append(_template.Paragraph()(element));
            return this;
        }

        /// <summary>
        /// Add a new link
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public MailBlockFluent Link(string link, dynamic attributes = null)
        {
            return Link(link, link);
        }

        /// <summary>
        /// Add a new link.
        /// </summary>
        /// <param name="link"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public MailBlockFluent Link(string link, string text, dynamic attributes = null)
        {
            var element = new ActionElement { Content = MailBody.HtmlEncode(text), Link = MailBody.AttributeEncode(link), Attributes = attributes };
            _body.Append(_template.Link()(element));

            return this;
        }

        /// <summary>
        /// Add a button with a link.
        /// </summary>
        /// <param name="link"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public MailBlockFluent Button(string link, string text, ExpandoObject attributes = null)
        {
            var element = new ActionElement { Content = MailBody.HtmlEncode(text), Link = MailBody.AttributeEncode(link), Attributes = attributes };
            _body.Append(_template.Button()(element));

            return this;
        }

        /// <summary>
        /// Add plain text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public MailBlockFluent Text(string text, dynamic attributes = null)
        {
            var element = new ContentElement { Content = MailBody.HtmlEncode(text), Attributes = attributes };
            _body.Append(_template.Text()(element));
            return this;
        }

        /// <summary>
        /// Add a strong text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public MailBlockFluent StrongText(string text, dynamic attributes = null)
        {
            var element = new ContentElement { Content = MailBody.HtmlEncode(text), Attributes = attributes };
            _body.Append(_template.StrongText()(element));
            return this;
        }

        /// <summary>
        /// Add raw html. This allows you to add custom html.
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public MailBlockFluent Raw(string html)
        {
            _body.Append(html);
            return this;
        }

        /// <summary>
        /// Add a new break line.
        /// </summary>
        /// <returns></returns>
        public MailBlockFluent LineBreak(dynamic attributes = null)
        {
            var element = new ContentElement { Content = string.Empty, Attributes = attributes };
            _body.Append(_template.LineBreak()(element));
            return this;
        }

        /// <summary>
        /// Add a unordered list.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public MailBlockFluent UnorderedList(IEnumerable<MailBlockFluent> items, dynamic attributes = null)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                var itemElement = new ContentElement { Content = MailBody.HtmlEncode(item.ToString()), Attributes = attributes };
                _body.Append(_template.ListItem()(itemElement));
            }
            var element = new ContentElement { Content = builder.ToString(), Attributes = attributes };
            _body.Append(_template.UnorderedList()(element));
            return this;
        }

        /// <summary>
        /// Add a ordered list.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public MailBlockFluent OrderedList(IEnumerable<MailBlockFluent> items, dynamic attributes = null)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                var itemElement = new ContentElement { Content = MailBody.HtmlEncode(item.ToString()), Attributes = attributes };
                _body.Append(_template.ListItem()(itemElement));
            }
            var element = new ContentElement { Content = builder.ToString(), Attributes = attributes };
            _body.Append(_template.OrderedList()(element));
            return this;
        }

        /// <summary>
        /// Add a block list.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public MailBlockFluent AddBlocksList(IEnumerable<MailBlockFluent> items)
        {
            var builder = new StringBuilder();
            foreach (var item in items)
            {
                builder.Append(item.ToString());
            }
            _body.Append(builder.ToString());
            return this;
        }

        /// <summary>
        /// Generate the html.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => GenerateHtml();
        
        /// <summary>
        /// Generate the html
        /// </summary>
        /// <returns></returns>
        public string GenerateHtml(dynamic attributes = null)
        {
            var element = new BodyElement
            {
                Content = _body.ToString(),
                Attributes = attributes,
                Footer = _footer != null ? _footer.ToString() : string.Empty
            };

            return _template.Body()(element);
        }
    }
}
