using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBodyPack
{
    public class MailBodyTemplate
    {
        public Func<ContentElement, string> _paragraph { get; set; }
        public Func<ActionElement, string> _link { get; set; }
        public Func<ContentElement, string> _title { get; set; }
        public Func<ContentElement, string> _subTitle { get; set; }
        public Func<BodyElement, string> _body { get; set; }
        public Func<ContentElement, string> _block { get; set; }
        public Func<ActionElement, string> _button { get; set; }
        public Func<ContentElement, string> _text { get; set; }
        public Func<ContentElement, string> _strongText { get; set; }
        public Func<ContentElement, string> _lineBreak { get; set; }
        public Func<ContentElement, string> _unorderedList { get; set; }
        public Func<ContentElement, string> _orderedList { get; set; }
        public Func<ContentElement, string> _listItem { get; set; }

        public Func<ContentElement, string> Paragraph() => _paragraph;
        public Func<ActionElement, string> Link() => _link;
        public Func<ContentElement, string> Title() => _title;
        public Func<ContentElement, string> SubTitle() => _subTitle;
        public Func<BodyElement, string> Body() => _body;
        public Func<ContentElement, string> Block() => _block;
        public Func<ActionElement, string> Button() => _button;
        public Func<ContentElement, string> Text() => _text;
        public Func<ContentElement, string> StrongText() => _strongText;
        public Func<ContentElement, string> LineBreak() => _lineBreak;
        public Func<ContentElement, string> UnorderedList() => _unorderedList;
        public Func<ContentElement, string> OrderedList() => _orderedList;
        public Func<ContentElement, string> ListItem() => _listItem;

        public MailBodyTemplate Paragraph(Func<ContentElement, string> newFunc)
        {
            _paragraph = newFunc;
            return this;
        }

        public MailBodyTemplate Link(Func<ActionElement, string> newFunc)
        {
            _link = newFunc;
            return this;
        }

        public MailBodyTemplate Title(Func<ContentElement, string> newFunc)
        {
            _title = newFunc;
            return this;
        }

        public MailBodyTemplate SubTitle(Func<ContentElement, string> newFunc)
        {
            _subTitle = newFunc;
            return this;
        }

        public MailBodyTemplate Body(Func<BodyElement, string> newFunc)
        {
            _body = newFunc;
            return this;
        }

        public MailBodyTemplate Block(Func<ContentElement, string> newFunc)
        {
            _block = newFunc;
            return this;
        }

        public MailBodyTemplate Button(Func<ActionElement, string> newFunc)
        {
            _button = newFunc;
            return this;
        }

        public MailBodyTemplate Text(Func<ContentElement, string> newFunc)
        {
            _text = newFunc;
            return this;
        }

        public MailBodyTemplate StrongText(Func<ContentElement, string> newFunc)
        {
            _strongText = newFunc;
            return this;
        }

        public MailBodyTemplate LineBreak(Func<ContentElement, string> newFunc)
        {
            _lineBreak = newFunc;
            return this;
        }

        public MailBodyTemplate UnorderedList(Func<ContentElement, string> newFunc)
        {
            _unorderedList = newFunc;
            return this;
        }

        public MailBodyTemplate OrderedList(Func<ContentElement, string> newFunc)
        {
            _orderedList = newFunc;
            return this;
        }

        public MailBodyTemplate ListItem(Func<ContentElement, string> newFunc)
        {
            _listItem = newFunc;
            return this;
        }
        
        /// <summary>
        /// Get the default template for body.
        /// </summary>
        /// <returns></returns>
        public static MailBodyTemplate GetDefaultTemplate()
        {
            return new MailBodyTemplate()
                .Paragraph(m => $"<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>{m.Content}</p>")
                .Link(m => $"<a href='{m.Link}'>{m.Content}</a>")
                .Title(m => $"<h1>{m.Content}</h1>")
                .SubTitle(m => $"<h2>{m.Content}</h2>")
                .Text(m => $"{m.Content}")
                .StrongText(m => $"<strong>{m.Content}</strong>")
                .UnorderedList(m => $"<ul>{m.Content}</ul>")
                .OrderedList(m => $"<ol>{m.Content}</ol>")
                .ListItem(m => $"<li>{m.Content}</li>")
                .LineBreak(m => $"</br>")
                .Button(m => @"<table border='0' cellpadding='0' cellspacing='0' class='btn btn-primary' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; box-sizing: border-box;' width='100%'>
    <tbody>
    <tr>
        <td align='left' style='font-family: sans-serif; font-size: 14px; vertical-align: top; padding-bottom: 15px;' valign='top'>
        <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: auto;'>
            <tbody>
            <tr>
                <td style='font-family: sans-serif; font-size: 14px; vertical-align: top; background-color: #3498db; border-radius: 5px; text-align: center;' valign='top' bgcolor='#3498db' align='center'> <a href='" + m.Link + @"' target='_blank' style='display: inline-block; color: #ffffff; background-color: #3498db; border: solid 1px #3498db; border-radius: 5px; box-sizing: border-box; cursor: pointer; text-decoration: none; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; border-color: #3498db;'>" + m.Content + @"</a> </td>
            </tr>
            </tbody>
        </table>
        </td>
    </tr>
    </tbody>
</table>")
                .Block(m => m.Content)
                .Body(m => @"<!doctype html>
<html>
  <head>
    <meta name='viewport' content='width=device-width'>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
    <title></title>
    <style media='all' type='text/css'>
    @media all {
      .btn-primary table td:hover {
        background-color: #34495e !important;
      }
      .btn-primary a:hover {
        background-color: #34495e !important;
        border-color: #34495e !important;
      }
    }
    
    @media all {
      .btn-secondary a:hover {
        border-color: #34495e !important;
        color: #34495e !important;
      }
    }
    
    @media only screen and (max-width: 620px) {
      table[class=body] h1 {
        font-size: 28px !important;
        margin-bottom: 10px !important;
      }
      table[class=body] h2 {
        font-size: 22px !important;
        margin-bottom: 10px !important;
      }
      table[class=body] h3 {
        font-size: 16px !important;
        margin-bottom: 10px !important;
      }
      table[class=body] p,
      table[class=body] ul,
      table[class=body] ol,
      table[class=body] td,
      table[class=body] span,
      table[class=body] a {
        font-size: 16px !important;
      }
      table[class=body] .wrapper,
      table[class=body] .article {
        padding: 10px !important;
      }
      table[class=body] .content {
        padding: 0 !important;
      }
      table[class=body] .container {
        padding: 0 !important;
        width: 100% !important;
      }
      table[class=body] .header {
        margin-bottom: 10px !important;
      }
      table[class=body] .main {
        border-left-width: 0 !important;
        border-radius: 0 !important;
        border-right-width: 0 !important;
      }
      table[class=body] .btn table {
        width: 100% !important;
      }
      table[class=body] .btn a {
        width: 100% !important;
      }
      table[class=body] .img-responsive {
        height: auto !important;
        max-width: 100% !important;
        width: auto !important;
      }
      table[class=body] .alert td {
        border-radius: 0 !important;
        padding: 10px !important;
      }
      table[class=body] .span-2,
      table[class=body] .span-3 {
        max-width: none !important;
        width: 100% !important;
      }
      table[class=body] .receipt {
        width: 100% !important;
      }
    }
    
    @media all {
      .ExternalClass {
        width: 100%;
      }
      .ExternalClass,
      .ExternalClass p,
      .ExternalClass span,
      .ExternalClass font,
      .ExternalClass td,
      .ExternalClass div {
        line-height: 100%;
      }
      .apple-link a {
        color: inherit !important;
        font-family: inherit !important;
        font-size: inherit !important;
        font-weight: inherit !important;
        line-height: inherit !important;
        text-decoration: none !important;
      }
    }
    </style>
  </head>
  <body class='' style='font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; background-color: #f6f6f6; margin: 0; padding: 0;'>
    <table border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;' width='100%' bgcolor='#f6f6f6'>
      <tr>
        <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'>&nbsp;</td>
        <td class='container' style='font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto !important; max-width: 580px; padding: 10px; width: 580px;' width='580' valign='top'>
          <div class='content' style='box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;'>

            <!-- START CENTERED WHITE CONTAINER -->
            <table class='main' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #fff; border-radius: 3px;' width='100%'>

              <!-- START MAIN CONTENT AREA -->
              <tr>
                <td class='wrapper' style='font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;' valign='top'>
                  <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;' width='100%'>
                    <tr>
                      <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'>
                        " + m.Content + @"
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>

              <!-- END MAIN CONTENT AREA -->
              </table>

            <!-- START FOOTER -->
            <div class='footer' style='clear: both; padding-top: 10px; text-align: center; width: 100%;'>
              <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;' width='100%'>
                <tr>
                  <td class='content-block' style='font-family: sans-serif; vertical-align: top; padding-top: 10px; padding-bottom: 10px; font-size: 12px; color: #999999; text-align: center;' valign='top' align='center'>
                    <span class='apple-link' style='color: #999999; font-size: 12px; text-align: center;'>" + m.Footer + @"</span>
                  </td>
                </tr>
              </table>
            </div>

            <!-- END FOOTER -->
            
            <!-- END CENTERED WHITE CONTAINER --></div>
        </td>
        <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'>&nbsp;</td>
      </tr>
    </table>
  </body>
</html>");
        }
    }
}
