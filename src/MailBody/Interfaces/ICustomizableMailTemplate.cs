using System;

namespace MailBodyPack.Interfaces
{
    public interface ICustomizableMailTemplate
    {
        string Head { get; }
        Func<string, string> Body { get; }
        Func<string, string> ParagraphTag { get; }
        Func<string, string, string> LinkTag { get; }
        Func<string, string> TitleTag { get; }
        Func<string, string> SubTitleTag { get; }
        Func<string, string> Text { get; }
        Func<string, string> StrongText { get; }
        Func<string, string> UnorderedListTag { get; }
        Func<string, string> OrderedListTag { get; }
        Func<string, string> ListItemTag { get; }
        string LineBreak { get; }
        Func<string, string, string> Button { get; }
    }
}