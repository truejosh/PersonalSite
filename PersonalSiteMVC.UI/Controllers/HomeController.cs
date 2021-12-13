using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSiteMVC.UI.Models;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace PersonalSiteMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Classmates()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }
          
            string message = $"{cvm.Subject}<br/>You have received the following message from {cvm.Name}<br/>Message:{cvm.Message}<br/>. {cvm.Name}'s contact email is {cvm.Email}";

            MailMessage mm = new MailMessage(
             ConfigurationManager.AppSettings["EmailUser"].ToString(),
               ConfigurationManager.AppSettings["Emailto"].ToString(),
               cvm.Subject,//adds 
               message //?
                );
           
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;

            mm.ReplyToList.Add(cvm.Email);//?

            //Assemble the smtpclient - the vehicle by which the message is sent
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

            //add the credentails to the smtpclient
            client.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["EmailUser"].ToString(),
                ConfigurationManager.AppSettings["EmailPass"].ToString()
                );

            try
            {
               client.Send(mm); 
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = $"We are sorry your request could not be sent. Please try again in a few minutes.<br/>Error Message: <br/> {ex.StackTrace}";
                return View(cvm);

            }

            return View("EmailConfirmation", cvm);
        }
    }
}