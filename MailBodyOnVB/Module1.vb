Imports MailBodyPack

Module Module1

    Sub Main()

        Dim body As String = MailBody.CreateBody() _
             .Paragraph("Please confirm your email address by clicking the link below.") _
            .Paragraph("We may need to send you critical information about our service and it is important that we have an accurate email address.") _
            .Button("https://example.com/", "Confirm Email Address") _
            .Paragraph("— [Insert company name here]") _
            .ToString()

        Console.WriteLine(body)
        Console.ReadLine()

    End Sub

End Module
