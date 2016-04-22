using System.Net.Mail;

namespace Framework.Email
{
	public class EmailService : IEmailService
	{
		public void Send(MailMessage message)
		{
			var client = new SmtpClient();

			client.Send(message);
		}

		public void Send(string from, string to, string subject, string body)
		{
			Send(new MailMessage(from, to, subject, body));
		}
	}
}