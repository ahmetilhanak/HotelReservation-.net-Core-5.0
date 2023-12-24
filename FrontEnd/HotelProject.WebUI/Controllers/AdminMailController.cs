using HotelProject.WebUI.Models.AdminMail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            //Email FROM
            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "ilhanahmetakbas24@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            //Email TO
            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //Email Content
            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = model.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();

            //Email Title
            mimeMessage.Subject = model.Subject;

            //Email Sending
            //SmtpClient client = new SmtpClient();
            //client.Connect("smtp.gmail.com",587,false);
            //client.Authenticate("ilhanahmetakbas24@gmail.com", "esxrctpmoymtuclc");
            //client.Send(mimeMessage);
            //client.Disconnect(true);

            using (var smtp = new SmtpClient())
            {
                smtp.CheckCertificateRevocation = false;
                smtp.Connect("smtp.gmail.com", 587, false);

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate("ilhanahmetakbas24@gmail.com", "esxrctpmoymtuclc");

                smtp.Send(mimeMessage);
                smtp.Disconnect(true);
            }
;
            return View();
        }
    }
}
