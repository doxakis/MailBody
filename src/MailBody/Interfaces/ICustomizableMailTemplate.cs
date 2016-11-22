using System;

namespace MailBodyPack.Interfaces
{
    public interface ICustomizableMailTemplate
    {
        Func<string, string> GetParagraph { get; }
        Func<string, string, string> GetLink { get; }
        Func<string, string> GetTitle { get; }
        Func<string, string> GetSubTitle { get; }
        Func<string, string> GetBody { get; }
        Func<string, string> GetText { get; }
        Func<string, string> GetStrongText { get; }
        Func<string, string> GetUnorderedList { get; }
        Func<string, string> GetOrderedList { get; }
        Func<string, string> GetListItem { get; }
        Func<string> GetLineBreak { get; }
        Func<string, string, string> GetButton { get; }
        Func<string> GetStyle { get; }
    }
}