using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using DoctorEntity;

namespace AssignmentMVC.Controllers
{
    public class Doctor1Controller : Controller
    {

        // GET: Doctor1
        public ActionResult Index()
        {
            var Doctors = GetDoctors();
            return View(Doctors);
        }

        private List<DoctorModel> GetDoctors()
        {
            var DoctorsList = new List<DoctorModel>();
            try
            {
                var Client = new HttpClient();
                var getDataTask = Client.GetAsync("http://localhost:52239/api/Doctor1").
                    ContinueWith(response =>
                    {
                        var result = response.Result;
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var readresult = result.Content.ReadAsAsync<List<DoctorModel>>();
                            readresult.Wait();
                            DoctorsList = readresult.Result;
                        }
                    }
                );
                getDataTask.Wait();
                return DoctorsList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




  

        // GET: Doctor1/Details/5
        public ActionResult Details(int id)
        {
            var DoctorsList = new List<DoctorModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52239/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                        );
                    HttpResponseMessage response = client.GetAsync("$api/Doctor1/{id}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                       // response.Content.ReadAsAsync<DoctorModel>().Result;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        // GET: Doctor1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor1/Create
        [HttpPost]
        public ActionResult Create(DoctorModel collection)
        {
            try
            {
                // TODO: Add insert logic here

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:52239/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                        );
                    HttpResponseMessage response = client.PostAsJsonAsync("api/Doctor1", collection).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //response.Content.ReadAsAsync<DoctorModel>.Result;
                    }
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor1/Edit/5
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

        // GET: Doctor1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Doctor1/Delete/5
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
