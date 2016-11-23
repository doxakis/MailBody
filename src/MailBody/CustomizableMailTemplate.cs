using System;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    internal class CustomizableMailTemplate : ICustomizableMailTemplate
    {
        public CustomizableMailTemplate(string headTag, Func<string, string> bodyFunc, 
            Func<string, string> paragraph, Func<string, string, string> link, 
            Func<string, string> getTitle, Func<string, string> subTitle,
            Func<string, string> text, Func<string, string> strongText,
            Func<string, string> unorderedList, Func<string, string> orderedList,
            Func<string, string> listItem, string lineBreak, Func<string, string, string> button)
        {
            Head = headTag;
            Body = bodyFunc;
            ParagraphTag = paragraph;
            LinkTag = link;
            TitleTag = getTitle;
            SubTitleTag = subTitle;
            Text = text;
            StrongText = strongText;
            UnorderedListTag = unorderedList;
            OrderedListTag = orderedList;
            ListItemTag = listItem;
            LineBreak = lineBreak;
            Button = button;
        }

        public string Head { get; }
        public Func<string, string> Body { get; }
        public Func<string, string> ParagraphTag { get; }
        public Func<string, string, string> LinkTag { get; }
        public Func<string, string> TitleTag { get; }
        public Func<string, string> SubTitleTag { get; }
        public Func<string, string> Text { get; }
        public Func<string, string> StrongText { get; }
        public Func<string, string> UnorderedListTag { get; }
        public Func<string, string> OrderedListTag { get; }
        public Func<string, string> ListItemTag { get; }
        public string LineBreak { get; }
        public Func<string, string, string> Button { get; }
    }
}