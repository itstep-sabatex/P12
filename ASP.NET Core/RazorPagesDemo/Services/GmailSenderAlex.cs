using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace RazorPagesDemo.Services
{
    public partial class GmailSender : IEmailSender
    {
        public string MySuperPuperFunction()
        {
            return "Hello World!";
        }

    }
}
