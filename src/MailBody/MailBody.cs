using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailBodyPack
{
    public class MailBody
    {
        /// <summary>
        /// Starting point for creating a body.
        /// </summary>
        /// <returns></returns>
        public static MailBlockFluent CreateBody()
        {
            var template = MailBodyTemplate.GetDefaultTemplate();
            var instance = new MailBlockFluent(template, null);
            return instance;
        }

        /// <summary>
        /// Starting point for creating a body with a footer.
        /// </summary>
        /// <param name="footer"></param>
        /// <returns></returns>
        public static MailBlockFluent CreateBody(MailBlockFluent footer)
        {
            var template = MailBodyTemplate.GetDefaultTemplate();
            var instance = new MailBlockFluent(template, footer);
            return instance;
        }

        /// <summary>
        /// Starting point for creating a body with a custom template and a footer.
        /// </summary>
        /// <param name="template"></param>
        /// <param name="footer"></param>
        /// <returns></returns>
        public static MailBlockFluent CreateBody(MailBodyTemplate template, MailBlockFluent footer)
        {
            var instance = new MailBlockFluent(template, footer);
            return instance;
        }

        /// <summary>
        /// Starting point for creating a block of html.
        /// </summary>
        /// <returns></returns>
        public static MailBlockFluent CreateBlock(MailBodyTemplate template = null)
        {
            template = template ?? MailBodyTemplate.BlockTemplate();
            var instance = CreateBody(template, null);
            return instance;
        }

        /// <summary>
        /// Escape greater-than sign and less-than sign characters.
        /// </summary>
        /// <param name="unescapeText"></param>
        /// <returns></returns>
        public static string HtmlEncode(string unescapeText)
        {
            var builder = new StringBuilder();
            foreach (var item in unescapeText)
            {
                switch (item)
                {
                    case '<':
                        builder.Append("&lt;");
                        break;
                    case '>':
                        builder.Append("&gt;");
                        break;
                    default:
                        builder.Append(item);
                        break;
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Escape ", ', greater-than sign and less-than sign characters.
        /// </summary>
        /// <param name="unescapeText"></param>
        /// <returns></returns>
        public static string AttributeEncode(string unescapeText)
        {
            var builder = new StringBuilder();
            foreach (var item in unescapeText)
            {
                switch (item)
                {
                    case '"':
                        builder.Append("&quot;");
                        break;
                    case '\'':
                        builder.Append("&#x27;");
                        break;
                    case '<':
                        builder.Append("&lt;");
                        break;
                    case '>':
                        builder.Append("&gt;");
                        break;
                    default:
                        builder.Append(item);
                        break;
                }
            }
            return builder.ToString();
        }
    }
}
