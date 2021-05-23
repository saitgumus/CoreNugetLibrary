using System;
using SG.Kernel.Response;
using SG.Kernel.Types;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace SG.Kernel.InformationEngine.Mail
{
    public class MailSender : IMailSender
    {
        MimeMessage email = new MimeMessage();
        private string userName;
        private string password;
        private int port;
        private string host;

        public MailSender(string username, string password, string host, int port)
        {
            this.userName = username;
            this.password = password;
            this.host = host;
            this.port = port;
        }


        public Response<int> Send(InformationContract contract)
        {
            var returnobject = new Response<int>();

            email.From.Add(MailboxAddress.Parse(contract.From));
            email.To.Add(MailboxAddress.Parse(contract.To));
            email.Subject = contract.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = contract.Body };

            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect(this.host, this.port, MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                    smtp.Authenticate(this.userName, this.password);
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }

                returnobject.Value = 1;
            }
            catch (Exception ex)
            {
                returnobject.AddResults(new Result { ErrorMessage = ex.Message, Severity = Severity.Lower });
            }

            return returnobject;
        }
    }
}