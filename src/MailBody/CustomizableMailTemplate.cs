using System;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    internal class CustomizableMailTemplate : ICustomizableMailTemplate
    {
        public CustomizableMailTemplate(Func<string, string> paragraph,
            Func<string, string, string> link, Func<string, string> getTitle, Func<string, string> subTitle,
            Func<string, string> getBody, Func<string, string> text, Func<string, string> strongText,
            Func<string, string> unorderedList, Func<string, string> orderedList,
            Func<string, string> listItem, Func<string> lineBreak,
            Func<string, string, string> button, Func<string> style)
        {
            GetParagraph = paragraph;
            GetLink = link;
            GetSubTitle = subTitle;
            GetText = text;
            GetStrongText = strongText;
            GetUnorderedList = unorderedList;
            GetOrderedList = orderedList;
            GetListItem = listItem;
            GetLineBreak = lineBreak;
            GetButton = button;
            GetStyle = style;
            GetBody = getBody;
            GetTitle = getTitle;
        }

        public Func<string, string> GetParagraph {get;}
        public Func<string, string, string> GetLink {get;}
        public Func<string, string> GetTitle { get; }
        public Func<string, string> GetSubTitle {get;}
        public Func<string, string> GetBody { get; }
        public Func<string, string> GetText {get;}
        public Func<string, string> GetStrongText {get;}
        public Func<string, string> GetUnorderedList {get;}
        public Func<string, string> GetOrderedList {get;}
        public Func<string, string> GetListItem {get;}
        public Func<string> GetLineBreak {get;}
        public Func<string, string, string> GetButton {get;}
        public Func<string> GetStyle {get;}
    }
}