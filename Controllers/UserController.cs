using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurants.Models;
using System.Net.Mail;

namespace Restaurants.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.Users.ToList());
            }
        }

        // GET: User/Details/5
        public ActionResult Details(String email)
        {

            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.Users.Where(x => x.email.Equals(email)).FirstOrDefault());
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
        
            try
            {
                // TODO: Add insert logic here
                using (DBModels dbModel = new DBModels())
                {
                  
                    dbModel.Users.Add(user);
                    dbModel.SaveChanges();
                    MailMessage mailMessage = new MailMessage("bulmaBula@gmail.com", user.email, "Registration is confirmed","You can now access the website with your credentials" );
                    mailMessage.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("bulmaBula@gmail.com", "Test123$");
                    Console.WriteLine("Sending email");
                    client.Send(mailMessage);

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(String email)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.Users.Where(x => x.email.Equals(email)).FirstOrDefault());
            }
        
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                using (DBModels dbModel = new DBModels())
                {
                    dbModel.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    dbModel.SaveChanges();
                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(String email)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.Users.Where(x => x.email.Equals(email)).FirstOrDefault());
            }

        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(String email, User user)
        {
            try
            {
                using (DBModels dbModel = new DBModels())
                {
                    user = dbModel.Users.Where(x => x.email.Equals(email)).FirstOrDefault();
                    dbModel.Users.Remove(user);
                    dbModel.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
