using System.Net.Mail;

namespace Framework.Email
{
	public interface IEmailService
	{
		void Send(MailMessage message);
		void Send(string from, string to, string subject, string body);
	}
}