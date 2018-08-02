using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Framework;
namespace NHAXE.Controllers
{
    public class TuyenDuongController : Controller
    {
        // GET: TuyenDuong
        public ActionResult Index()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            var iplTDuong = new TuyenDuongModel();
            var model = iplTDuong.listAll();
            return View(model);
        }
      
        public ActionResult TuyenDuong()
        {
            if (Session["User"] != null)
                ViewBag.User = Session["User"].ToString();
            var iplTDuong = new TuyenDuongModel();
            var model = iplTDuong.listAll();

            //Dictionary<string, System.Collections.ArrayList> tuyenDuong = new Dictionary<string, System.Collections.ArrayList>();

            //while(model.Count > 0)
            //{
            //    if (!tuyenDuong.ContainsKey(model[0].BENDI))
            //    {
            //        System.Collections.ArrayList list = new System.Collections.ArrayList();
            //        list.Add(model[0]);
            //        tuyenDuong.Add(model[0].BENDI, list);
            //    }else
            //    {
            //        System.Collections.ArrayList list = tuyenDuong[model[0].BENDI];
            //        list.Add(model[0]);
            //        tuyenDuong[model[0].BENDI] = list;
            //    }
            //    model.RemoveAt(0);
            //}

            return View(model);
        }

        // GET: TuyenDuong/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TuyenDuong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TuyenDuong/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TuyenDuong/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TuyenDuong/Edit/5
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

        // GET: TuyenDuong/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TuyenDuong/Delete/5
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
