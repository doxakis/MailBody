using System;

namespace MailBodyPack.Interfaces
{
    public interface ICustomMailTemplate
    {
        string Head { get; }
        Func<string, string, string> Body { get; }
        Func<string, string> Paragraph { get; }
        Func<string, string, string> Link { get; }
        Func<string, string> Title { get; }
        Func<string, string> SubTitleTag { get; }
        Func<string, string> Text { get; }
        Func<string, string> StrongText { get; }
        Func<string, string> UnorderedList { get; }
        Func<string, string> OrderedList { get; }
        Func<string, string> ListItem { get; }
        string LineBreak { get; }
        Func<string, string, string> Button { get; }
    }
}