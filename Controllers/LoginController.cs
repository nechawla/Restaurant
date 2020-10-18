using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Restaurants.Models;

namespace Restaurants.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

            [HttpPost]
            public ActionResult Authorize(User user)
            {
                using (DBModels dbModel = new DBModels())
                {
                    var userDetail = dbModel.Users.Where(x => x.email == user.email && x.password == user.password).FirstOrDefault();
                    if(userDetail == null)
                    {
                        user.LoginErrorMessage = "Wrong email id or password";
                        return View("Index", user);
                    }
                    else
                    {
                        Session["userId"] = user.email;
                    HttpCookie kt = new HttpCookie("userEmail", userDetail.firstName);
                    Response.Cookies.Add(kt);
                    Response.Redirect("/Home/Index");

                    }
                 }
                return View();
            }

        
        public ActionResult Logout()
        {
            HttpCookie aCookie = Response.Cookies["userEmail"];
            aCookie.Expires = DateTime.Now.AddDays(-10);
            aCookie.Value = "";
           Response.Cookies.Add(aCookie);
           
            Response.Redirect("/Login/Index");
            return View();
        }
            // GET: Login/Details/5
            public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                using (DBModels dbModel = new DBModels())
                {

                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
