using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Services
{
    public class AuthMessageSender : IEmailSender
    {
        public AuthMessageSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public EmailSettings _emailSettings { get; }

        public Task SendEmailAsync(string email, string subject, string solicitante, string message)
        {
            try
            {
                Execute(email, subject, solicitante, message).Wait();
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        public async Task Execute(string email, string subject, string solicitante, string message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Solicitação de Peças")
                };

                mail.To.Add(new MailAddress(toEmail));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));
                //mail.Subject = "Beauty Home" + subject;
                mail.Subject = subject;
                mail.Body = "<h4>Uma solicitação foi feita através do sistema [Estoque]</h4><br />";
                mail.Body += "<strong>Solicitante: </strong>" + solicitante + "<br /><br />";
                mail.Body += "<strong>Solicitacao: </strong>" + message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                //outras opções
                //mail.Attachments.Add(new Attachment(arquivo));
                //

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
