using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ABSA_CIB_Digital_Tech___Assessment.Models;
using ABSA_CIB_Digital_Tech___Assessment.Repository;

namespace ABSA_CIB_Digital_Tech___Assessment.Controllers
{
    public class PhoneBookController : Controller
    {
        ABSAEntities Entities = new ABSAEntities();
        protected List<string> info = new List<string>();
        
        // GET: PhoneBook
        [HttpPost]
        public ActionResult Index(string name)
        {
            try
            {
                if (name != "")
                {
                   
                    string[] phonebk = name.Trim().Split(new string[] { "" }, StringSplitOptions.RemoveEmptyEntries);
                    this.info = phonebk.ToList();
                    PhonebookDetails access = new PhonebookDetails();
                    List<PhoneBook> collection = access.Search(this.info);
                    ViewBag.ListPhonebook = collection.ToList();// phonebk.ToList();
                    return View(collection);

                }
                else
                {

                    ViewBag.ListPhonebook = this.Entities.PhoneBooks.ToList();
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/ApiPhoneBook/GetAllPhoneBook");
                    response.EnsureSuccessStatusCode();
                    List<Models.PhoneBookViewModel> phonebk = response.Content.ReadAsAsync<List<Models.PhoneBookViewModel>>().Result;
                    ViewBag.Title = "All Phone Numbers";
                    return View(phonebk);
                }
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        public ActionResult Index( )
        {


            try
            {
                ViewBag.ListPhonebook = this.Entities.PhoneBooks.ToList();
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/ApiPhoneBook/GetAllPhoneBook");
                response.EnsureSuccessStatusCode();
                List<Models.PhoneBook> phonebk = response.Content.ReadAsAsync<List<Models.PhoneBook>>().Result;
                ViewBag.Title = "All Phone Numbers";
                return View(phonebk);
            }
            catch (Exception)
            {
                throw;
            }


        }


        // GET: PhoneBook/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhoneBook/Create
        public ActionResult Create( )
        {
            return View();
        }

        // POST: PhoneBook/Create

        [HttpPost]
        public ActionResult Create(PhoneBook phonebook)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/ApiPhoneBook/PostNewPhonebook", phonebook);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");

            }
            // GET: PhoneBook/Edit/5
            public ActionResult Edit(int id)
        {
            PhoneBookViewModel phonebook = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44302/api/");
                //HTTP GET
                var responseTask = client.GetAsync("ApiPhonebook?id=" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<PhoneBookViewModel>();
                    readTask.Wait();
                    phonebook = readTask.Result;
                }
            }
            return View(phonebook);
        }

        // POST: PhoneBook/Edit/5
        [HttpPost]

        public ActionResult Edit(PhoneBookViewModel phonebook)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44302/api/ApiPhonebook");
                //HTTP POST
                var putTask = client.PutAsJsonAsync<PhoneBookViewModel>("ApiPhonebook", phonebook);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(phonebook);
        }
        // GET: PhoneBook/Delete/5
        public ActionResult Delete(string name)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44302/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("ApiPhonebook/" + name.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}
