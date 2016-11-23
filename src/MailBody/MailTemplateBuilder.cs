using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    public interface IHead
    {
        IBody Head(string headTag);
    }

    public interface IBody
    {
        IParagraph Body(Func<string, string> bodyFunc);
    }

    public interface IParagraph
    {
        ILink ParagraphStyle(Func<string, string> paragraphFunc);
    }

    public interface ILink
    {
        ITitle LinkStyle(Func<string, string, string> linkFunc);
    }

    public interface ITitle
    {
        ISubTitle TitleStyle(Func<string, string> titleFunc);
    }

    public interface ISubTitle
    {
        IText SubTitleStyle(Func<string, string> subTitleFunc);
    }

    public interface IText
    {
        IStrongText TextStyle(Func<string, string> textFunc);
    }

    public interface IStrongText
    {
        IUnorderedList StrongTextStyle(Func<string, string> strongTextFunc);
    }

    public interface IUnorderedList
    {
        IOrderedList UnorderedListStyle(Func<string, string> unorderedListFunc);
    }

    public interface IOrderedList
    {
        IListItem OrderedListStyle(Func<string, string> orderedListFunc);
    }

    public interface IListItem
    {
        ILineBreak ListItemStyle(Func<string, string> listItemFunc);
    }

    public interface ILineBreak
    {
        IButton LineBreakStyle(string lineBreak);
    }

    public interface IButton
    {
        IBuild ButtonStyle(Func<string, string, string> buttonFunc);
    }

    public interface IBuild
    {
        ICustomizableMailTemplate Build();
    }

    public class MailTemplateBuilder : IHead, IParagraph, ILink, ITitle, ISubTitle, IBody, IText, IStrongText, IUnorderedList, IOrderedList, IListItem, ILineBreak, IButton, IBuild
    {
        private string _headTag;
        private Func<string, string> _paragraphFunc;
        private Func<string, string, string> _linkFunc;
        private Func<string, string> _titleFunc;
        private Func<string, string> _subTitleFunc;
        private Func<string, string> _bodyFunc;
        private Func<string, string, string> _buttonFunc;
        private Func<string, string> _textFunc;
        private Func<string, string> _strongTextFunc;
        private string _lineBreak;
        private Func<string, string> _unorderedListFunc;
        private Func<string, string> _orderedListFunc;
        private Func<string, string> _listItemFunc;

        private MailTemplateBuilder()
        {
        }

        public static IHead CreatTemplate() =>
            new MailTemplateBuilder();

        public IBody Head(string headTag)
        {
            _headTag = headTag;
            return this;
        }

        public IParagraph Body(Func<string, string> bodyFunc)
        {
            _bodyFunc = bodyFunc;
            return this;
        }

        public ILink ParagraphStyle(Func<string, string> paragraphFunc)
        {
            _paragraphFunc = paragraphFunc;
            return this;
        }

        public ITitle LinkStyle(Func<string, string, string> linkFunc)
        {
            _linkFunc = linkFunc;
            return this;
        }

        public ISubTitle TitleStyle(Func<string, string> titleFunc)
        {
            _titleFunc = titleFunc;
            return this;
        }

        public IText SubTitleStyle(Func<string, string> subTitleFunc)
        {
            _subTitleFunc = subTitleFunc;
            return this;
        }

        public IStrongText TextStyle(Func<string, string> textFunc)
        {
            _textFunc = textFunc;
            return this;
        }

        public IUnorderedList StrongTextStyle(Func<string, string> strongTextFunc)
        {
            _strongTextFunc = strongTextFunc;
            return this;
        }

        public IOrderedList UnorderedListStyle(Func<string, string> unorderedListFunc)
        {
            _unorderedListFunc = unorderedListFunc;
            return this;
        }

        public IListItem OrderedListStyle(Func<string, string> orderedListFunc)
        {
            _orderedListFunc = orderedListFunc;
            return this;
        }

        public ILineBreak ListItemStyle(Func<string, string> listItemFunc)
        {
            _listItemFunc = listItemFunc;
            return this;
        }

        public IButton LineBreakStyle(string lineBreak)
        {
            _lineBreak = lineBreak;
            return this;
        }

        public IBuild ButtonStyle(Func<string, string, string> buttonFunc)
        {
            _buttonFunc = buttonFunc;
            return this;
        }

        public ICustomizableMailTemplate Build()
        {
            return new CustomizableMailTemplate(_headTag, _bodyFunc,
                    _paragraphFunc, _linkFunc, _titleFunc, _subTitleFunc,
                    _textFunc, _strongTextFunc, _unorderedListFunc,
                    _orderedListFunc, _listItemFunc,_lineBreak,
                    _buttonFunc
                );
        }
    }
}
