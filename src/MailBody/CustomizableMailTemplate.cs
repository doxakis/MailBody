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
            Paragraph = paragraph;
            Link = link;
            Title = getTitle;
            SubTitleTag = subTitle;
            Text = text;
            StrongText = strongText;
            UnorderedList = unorderedList;
            OrderedList = orderedList;
            ListItem = listItem;
            LineBreak = lineBreak;
            Button = button;
        }

        public string Head { get; }
        public Func<string, string> Body { get; }
        public Func<string, string> Paragraph { get; }
        public Func<string, string, string> Link { get; }
        public Func<string, string> Title { get; }
        public Func<string, string> SubTitleTag { get; }
        public Func<string, string> Text { get; }
        public Func<string, string> StrongText { get; }
        public Func<string, string> UnorderedList { get; }
        public Func<string, string> OrderedList { get; }
        public Func<string, string> ListItem { get; }
        public string LineBreak { get; }
        public Func<string, string, string> Button { get; }
    }
}