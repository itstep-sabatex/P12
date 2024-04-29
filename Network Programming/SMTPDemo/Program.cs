// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

Console.WriteLine("Hello, World!");
var Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddUserSecrets<Program>().Build();


var mailserver = "smtp.gmail.com";
var password = "0000 0000 0000 0000";
password = Configuration.GetSection("password").Value;
var login = "fake@gmail.com";


var smtpClient = new SmtpClient()
{
    Host = mailserver,
    Port = 587, //25
    EnableSsl = true,
    Credentials = new NetworkCredential(login, password)
};
using (var mail = new MailMessage(login,"destination@gmail.com","Hello my dear Frend","This is a test letter"))
{
    mail.IsBodyHtml = true;
    await smtpClient.SendMailAsync(mail);
}
