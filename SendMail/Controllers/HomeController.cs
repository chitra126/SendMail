using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SendMail.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                bool fSSL = true;

                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
                if (fSSL)
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "YOUR_GMAIL_UserID");
                //message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "YOUR_GMAIL_Passwors");

                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", WebConfigurationManager.AppSettings["SMTPUserName"].ToString());
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", WebConfigurationManager.AppSettings["SMTPPassword"].ToString());

                //Preparing the message object....


                message.From = "xyz@gmail.com";

                message.To = "xyz@gmail.com";
                //message.Cc = "xyz.com";
                message.Subject = "test mail from webmyne";
                message.BodyFormat = System.Web.Mail.MailFormat.Html;
                message.Body = "test mail";
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
                System.Web.Mail.SmtpMail.Send(message);
                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}