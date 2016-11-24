using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    public interface IHead
    {
        IParagraph Head(string headTag);
        IParagraph Head();
    }

    public interface IParagraph
    {
        ILink ParagraphStyle(Func<string, string> paragraphFunc);
        ILink ParagraphStyle();
    }

    public interface ILink
    {
        ITitle LinkStyle(Func<string, string, string> linkFunc);
        ITitle LinkStyle();
    }

    public interface ITitle
    {
        ISubTitle TitleStyle(Func<string, string> titleFunc);
        ISubTitle TitleStyle();
    }

    public interface ISubTitle
    {
        IUnorderedList SubTitleStyle(Func<string, string> subTitleFunc);
        IUnorderedList SubTitleStyle();
    }

    public interface IUnorderedList
    {
        IOrderedList UnorderedListStyle(Func<string, string> unorderedListFunc);
        IOrderedList UnorderedListStyle();
    }

    public interface IOrderedList
    {
        IListItem OrderedListStyle(Func<string, string> orderedListFunc);
        IListItem OrderedListStyle();
    }

    public interface IListItem
    {
        IButton ListItemStyle(Func<string, string> listItemFunc);
        IButton ListItemStyle();
    }

    public interface IButton
    {
        IBuild ButtonStyle(Func<string, string, string> buttonFunc);
        IBuild ButtonStyle();
    }

    public interface IBuild
    {
        ICustomizableMailTemplate Build();
    }

    public class MailTemplateBuilder : IHead, IParagraph, ILink, ITitle,
        ISubTitle, IUnorderedList, IOrderedList, IListItem, IButton, IBuild
    {
        private string _headTag;
        private Func<string, string> _paragraphFunc;
        private Func<string, string, string> _linkFunc;
        private Func<string, string> _titleFunc;
        private Func<string, string> _subTitleFunc;
        private Func<string, string> _bodyFunc = b => b;
        private Func<string, string, string> _buttonFunc;
        private Func<string, string> _textFunc = t => t;
        private Func<string, string> _strongTextFunc => t => $"<strong>{t}</strong>";
        private string _lineBreak => "</br>";
        private Func<string, string> _unorderedListFunc;
        private Func<string, string> _orderedListFunc;
        private Func<string, string> _listItemFunc;

        private MailTemplateBuilder()
        {
        }

        public static IHead CreatTemplate() =>
            new MailTemplateBuilder();

        public IParagraph Head() => Head("");
        public IParagraph Head(string headTag)
        {
            _headTag = headTag;
            return this;
        }

        public ILink ParagraphStyle() => ParagraphStyle(p => $"<p>{p}</p>");
        public ILink ParagraphStyle(Func<string, string> paragraphFunc)
        {
            if (paragraphFunc == null) return ParagraphStyle();
            _paragraphFunc = paragraphFunc;
            return this;
        }

        public ITitle LinkStyle() => LinkStyle((href, text) => $"<a href='{href}'>{text}</a>");
        public ITitle LinkStyle(Func<string, string, string> linkFunc)
        {
            if (linkFunc == null) return LinkStyle();
            _linkFunc = linkFunc;
            return this;
        }

        public ISubTitle TitleStyle() => TitleStyle(t => $"<h1>{t}</h1>");
        public ISubTitle TitleStyle(Func<string, string> titleFunc)
        {
            if (titleFunc == null) return TitleStyle();
            _titleFunc = titleFunc;
            return this;
        }

        public IUnorderedList SubTitleStyle() => SubTitleStyle(t => $"<h2>{t}</h2>");
        public IUnorderedList SubTitleStyle(Func<string, string> subTitleFunc)
        {
            if (subTitleFunc == null) return SubTitleStyle();
            _subTitleFunc = subTitleFunc;
            return this;
        }

        public IOrderedList UnorderedListStyle() => UnorderedListStyle(u => $"<ul>{u}</ul>");
        public IOrderedList UnorderedListStyle(Func<string, string> unorderedListFunc)
        {
            if (unorderedListFunc == null) return UnorderedListStyle();
            _unorderedListFunc = unorderedListFunc;
            return this;
        }

        public IListItem OrderedListStyle() => OrderedListStyle(o => $"<ol>{o}</ol>");
        public IListItem OrderedListStyle(Func<string, string> orderedListFunc)
        {
            if (orderedListFunc == null) return OrderedListStyle();
            _orderedListFunc = orderedListFunc;
            return this;
        }

        public IButton ListItemStyle() => ListItemStyle(i => $"<li>{i}</li>");
        public IButton ListItemStyle(Func<string, string> listItemFunc)
        {
            if (listItemFunc == null) return ListItemStyle();
            _listItemFunc = listItemFunc;
            return this;
        }

        public IBuild ButtonStyle() => ButtonStyle((href, text) => 
            $"<a href='{href}'> <button>{text}</button </a>");
        public IBuild ButtonStyle(Func<string, string, string> buttonFunc)
        {
            if (buttonFunc == null) return ButtonStyle();
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
