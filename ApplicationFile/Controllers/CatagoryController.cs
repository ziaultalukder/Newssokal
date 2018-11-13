using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationFile.BLL;
using ApplicationFile.Model.Models;
using ApplicationFile.Repository;
using DoinikSokal.BLL.Contracts;

namespace ApplicationFile.Controllers
{
    public class CatagoryController : Controller
    {
        ICatagoryManager _manager;

        public CatagoryController(ICatagoryManager _catagoryManager)
        {
            _manager = _catagoryManager; 
        }
        // GET: Catagory
        public ActionResult Index()
        {
            var Catagories = _manager.GetAll();
            return View(Catagories);
        }

        [HttpPost]
        public ActionResult Create(CatagoryViewModel catagoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Catagory catagory = new Catagory()
                {
                    Name = catagoryViewModel.Name,
                    CategoryId = catagoryViewModel.CatagoryId
                };
                bool isAdded = _manager.Add(catagory);
                if (isAdded)
                {
                    TempData["msg"] = "Category Inserted Successfully!";
                    return RedirectToAction("Create");
                }
            }
            return View(catagoryViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CatagoryViewModel catagoryViewModel = new CatagoryViewModel();
            var catagoryList = _manager.GetAll();
            catagoryViewModel.Catagories = catagoryList;
            return View(catagoryViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagoryValue =  _manager.GetById((int)id);
            ViewBag.CategoryId = new SelectList(_manager.GetAll(), "Id", "Name", catagoryValue.CategoryId);
            return View(catagoryValue);
        }
        
        [HttpPost]
        public ActionResult Edit(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                _manager.Update(catagory);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catagory catagory = _manager.GetById((int) id);
            bool isDeleted = _manager.Remove(catagory);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }
            return View(catagory);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Catagory cat = _manager.GetById(id);
            _manager.Remove(cat);
            return RedirectToAction("Index");
        }
    }
}