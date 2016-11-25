using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailBodyPack;
using MailBodyPack.Interfaces;

namespace MailBodyPack
{
    public static class MailTemplateFactory
    {
        public static ICustomMailTemplate DefaultTemplate()
        {
            return MailTemplateBuilder
                .CreatTemplate()
                .Head()
                .Body()
                .ParagraphStyle()
                .LinkStyle()
                .TitleStyle()
                .SubTitleStyle()
                .UnorderedListStyle()
                .OrderedListStyle()
                .ListItemStyle()
                .ButtonStyle()
                .Build();
        }

        public static ICustomMailTemplate ResponsiveTemplate()
        {
            return MailTemplateBuilder
                .CreatTemplate()
                .Head(Responsive.Head)
                .Body((b, f) => string.Format(Responsive.Body, b, f))
                .ParagraphStyle(p => string.Format(Responsive.Paragraph, p))
                .LinkStyle((h, t) => $"<a href'{h}'>{t}</a>")
                .TitleStyle(t => $"<h2>{t}</h2>")
                .SubTitleStyle(t => $"<h2>{t}</h2>")
                .UnorderedListStyle(u => $"<ul>{u}</ul>")
                .OrderedListStyle(o => $"<ol>{o}</ol>")
                .ListItemStyle(i => $"<li>{i}</li>")
                .ButtonStyle((h, t) => string.Format(Responsive.Button, h, t))
                .Build();
        }
    }




    public static class Responsive
    {
        public static string Head
        {
            get { return "<meta name=\"viewport\" content=\"width=device-width\">\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\r\n    <title>Simple Transactional Email</title>\r\n    <style media=\"all\" type=\"text/css\">\r\n    @media all {\r\n      .btn-primary table td:hover {\r\n        background-color: #34495e !important;\r\n      }\r\n      .btn-primary a:hover {\r\n        background-color: #34495e !important;\r\n        border-color: #34495e !important;\r\n      }\r\n    }\r\n    \r\n    @media all {\r\n      .btn-secondary a:hover {\r\n        border-color: #34495e !important;\r\n        color: #34495e !important;\r\n      }\r\n    }\r\n    \r\n    @media only screen and (max-width: 620px) {\r\n      table[class=body] h1 {\r\n        font-size: 28px !important;\r\n        margin-bottom: 10px !important;\r\n      }\r\n      table[class=body] h2 {\r\n        font-size: 22px !important;\r\n        margin-bottom: 10px !important;\r\n      }\r\n      table[class=body] h3 {\r\n        font-size: 16px !important;\r\n        margin-bottom: 10px !important;\r\n      }\r\n      table[class=body] p,\r\n      table[class=body] ul,\r\n      table[class=body] ol,\r\n      table[class=body] td,\r\n      table[class=body] span,\r\n      table[class=body] a {\r\n        font-size: 16px !important;\r\n      }\r\n      table[class=body] .wrapper,\r\n      table[class=body] .article {\r\n        padding: 10px !important;\r\n      }\r\n      table[class=body] .content {\r\n        padding: 0 !important;\r\n      }\r\n      table[class=body] .container {\r\n        padding: 0 !important;\r\n        width: 100% !important;\r\n      }\r\n      table[class=body] .header {\r\n        margin-bottom: 10px !important;\r\n      }\r\n      table[class=body] .main {\r\n        border-left-width: 0 !important;\r\n        border-radius: 0 !important;\r\n        border-right-width: 0 !important;\r\n      }\r\n      table[class=body] .btn table {\r\n        width: 100% !important;\r\n      }\r\n      table[class=body] .btn a {\r\n        width: 100% !important;\r\n      }\r\n      table[class=body] .img-responsive {\r\n        height: auto !important;\r\n        max-width: 100% !important;\r\n        width: auto !important;\r\n      }\r\n      table[class=body] .alert td {\r\n        border-radius: 0 !important;\r\n        padding: 10px !important;\r\n      }\r\n      table[class=body] .span-2,\r\n      table[class=body] .span-3 {\r\n        max-width: none !important;\r\n        width: 100% !important;\r\n      }\r\n      table[class=body] .receipt {\r\n        width: 100% !important;\r\n      }\r\n    }\r\n    \r\n    @media all {\r\n      .ExternalClass {\r\n        width: 100%;\r\n      }\r\n      .ExternalClass,\r\n      .ExternalClass p,\r\n      .ExternalClass span,\r\n      .ExternalClass font,\r\n      .ExternalClass td,\r\n      .ExternalClass div {\r\n        line-height: 100%;\r\n      }\r\n      .apple-link a {\r\n        color: inherit !important;\r\n        font-family: inherit !important;\r\n        font-size: inherit !important;\r\n        font-weight: inherit !important;\r\n        line-height: inherit !important;\r\n        text-decoration: none !important;\r\n      }\r\n    }\r\n    </style>"; }
        }

        public static string Body
        {
            get
            {
                return
                    @"<body class='' style='font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; background-color: #f6f6f6; margin: 0; padding: 0;'>
    <table border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;' width='100%' bgcolor='#f6f6f6'>
      <tr>
        <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'>&nbsp;</td>
        <td class='container' style='font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto !important; max-width: 580px; padding: 10px; width: 580px;' width='580' valign='top'>
          <div class='content' style='box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;'>

            <!-- START CENTERED WHITE CONTAINER -->
            <span class='preheader' style='color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;'>This is preheader text. Some clients will show this text as a preview.</span>
            <table class='main' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #fff; border-radius: 3px;' width='100%'>

              <!-- START MAIN CONTENT AREA -->
              <tr>
                <td class='wrapper' style='font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;' valign='top'>
                  <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;' width='100%'>
                    <tr>
                      <td style='font-family: sans-serif; font-size: 14px; vertical-align: top;' valign='top'>
                        {0}
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
                    <span class='apple-link' style='color: #999999; font-size: 12px; text-align: center;'>{1}</span>
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
  </body>";
            }
        }

        public static string Button
        {
            get
            {
                return
                    @"<table border='0' cellpadding='0' cellspacing='0' class='btn btn-primary' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; box-sizing: border-box;' width='100%'>
    <tbody>
    <tr>
        <td align='left' style='font-family: sans-serif; font-size: 14px; vertical-align: top; padding-bottom: 15px;' valign='top'>
        <table border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: auto;'>
            <tbody>
            <tr>
                <td style='font-family: sans-serif; font-size: 14px; vertical-align: top; background-color: #3498db; border-radius: 5px; text-align: center;' valign='top' bgcolor='#3498db' align='center'> <a href='{0}' target='_blank' style='display: inline-block; color: #ffffff; background-color: #3498db; border: solid 1px #3498db; border-radius: 5px; box-sizing: border-box; cursor: pointer; text-decoration: none; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; border-color: #3498db;'>{1}</a> </td>
            </tr>
            </tbody>
        </table>
        </td>
    </tr>
    </tbody>
</table>";
            }
        }

        public static string Paragraph
        {
            get
            {
                return "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>{0}</p>";
            }
        }

    }
}
