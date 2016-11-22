using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBodyPack
{
    public class MailTemplateBuilder
    {
        private Func<string, string> _paragraphFunc;
        private Func<string, string, string> _linkFunc;
        private Func<string, string> _subTitleFunc;
        private Func<string, string> _textFunc;
        private Func<string, string> _strongTextFunc;
        private Func<string, string> _unorderedListFunc;
        private Func<string, string> _orderedListFunc;
        private Func<string, string> _listItemFunc;
        private Func<string> _lineBreakFunc;
        private Func<string, string, string> _buttonFunc;
        private Func<string> _styleFunc;

        private MailTemplateBuilder()
        {

        }

        public static MailTemplateBuilder CreatTemplate() =>
            new MailTemplateBuilder();

        public MailTemplateBuilder DocumentStyle(Func<string> styleFunc)
        {
            _styleFunc = styleFunc;
            return this;
        }

        public MailTemplateBuilder ParagraphStyle(Func<string, string> paragraphFunc)
        {
            _paragraphFunc = paragraphFunc;
            return this;
        }

        public MailTemplateBuilder LinkStyle(Func<string, string, string> linkFunc)
        {
            _linkFunc = linkFunc;
            return this;
        }

        public MailTemplateBuilder SubTitleStyle(Func<string, string> subTitleFunc)
        {
            _subTitleFunc = subTitleFunc;
            return this;
        }

        public MailTemplateBuilder TextStyle(Func<string, string> textFunc)
        {
            _textFunc = textFunc;
            return this;
        }

        public MailTemplateBuilder StrongTextStyle(Func<string, string> strongTextFunc)
        {
            _strongTextFunc = strongTextFunc;
            return this;
        }

        public MailTemplateBuilder UnorderedListStyle(Func<string, string> unorderedListFunc)
        {
            _unorderedListFunc = unorderedListFunc;
            return this;
        }

        public MailTemplateBuilder OrderedListStyle(Func<string, string> orderedListFunc)
        {
            _orderedListFunc = orderedListFunc;
            return this;
        }

        public MailTemplateBuilder ListItemStyle(Func<string, string> listItemFunc)
        {
            _listItemFunc = listItemFunc;
            return this;
        }

        public MailTemplateBuilder LineBreakStyle(Func<string> lineBreakFunc)
        {
            _lineBreakFunc = lineBreakFunc;
            return this;
        }

        public MailTemplateBuilder ButtonStyle(Func<string, string, string> buttonFunc)
        {
            _buttonFunc = buttonFunc;
            return this;
        }
    }


}
