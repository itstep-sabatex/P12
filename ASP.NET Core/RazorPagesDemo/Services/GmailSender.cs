using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace RazorPagesDemo.Services
{
    public class GmailSender : IEmailSender
    {
        record EmailDescription(string Password);

        readonly IConfiguration configuration;
        public GmailSender(IConfiguration  configuration)
        {
            this.configuration = configuration;  
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var emailconfig = new EmailDescription("");
            configuration.Bind("Email",emailconfig);
            throw new NotImplementedException();
        }
        
        public string GetVersion()
        {
            return "1.0.0";
        }
    }
}
