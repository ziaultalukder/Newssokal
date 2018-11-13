using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApplicationFile.BLL;
using ApplicationFile.Model.Models;
using DoinikSokal.BLL.Contracts;

namespace ApplicationFile.Controllers
{
    public class PostController : Controller
    {
        IPostManager _postManager;
        ICatagoryManager _catagoryManager;

        public PostController(IPostManager postManager, ICatagoryManager catagoryManager)
        {
            this._postManager = postManager;
            this._catagoryManager = catagoryManager;
        }
        
        // GET: Post
        public ActionResult Index()
        {
            var allPost = _postManager.GetAll();
            var allCat = _catagoryManager.GetAll();

            List<Post> postList = new List<Post>();
            foreach (var post in allPost)
            {
                var postVM = new Post
                {
                    Id = post.Id,
                    Title = post.Title,
                    Details = post.Details,
                    Tags = post.Tags,
                    Catagory = allCat.Where(x => x.Id == post.CatagoryId).FirstOrDefault()
                };
                postList.Add(postVM);
            }
            return View(postList);
            //return Json(new {data = postList}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            PostViewModel postViewModel = new PostViewModel();
            var catagory = _catagoryManager.GetAll();
            postViewModel.Catagories = catagory;
            return View(postViewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel postViewModel)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post
                {
                    Title = postViewModel.Title,
                    Details = postViewModel.Details,
                    Tags = postViewModel.Tags,
                    CatagoryId = postViewModel.CatagoryId
                };
                bool isSaved = _postManager.Add(post);
                if (isSaved)
                {
                    TempData["msg"] = "Post Inserted Successfully";
                    return RedirectToAction("Create");
                }
            }
            return View(postViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = _postManager.GetById((int)id);
            PostViewModel postViewModel = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Details = post.Details,
                Tags = post.Tags,
                CatagoryId = post.CatagoryId
            };
            ViewBag.CategoryId = new SelectList(_catagoryManager.GetAll(), "Id","Name",post.CatagoryId);
            return View(postViewModel);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(PostViewModel postViewModel)
        {
            Post post = new Post
            {
                Id = postViewModel.Id,
                Title = postViewModel.Title,
                Details = postViewModel.Details,
                Tags = postViewModel.Tags,
                CatagoryId = postViewModel.CatagoryId
            };
            bool isUpdate = _postManager.Update(post);
            if (isUpdate)
            {
                RedirectToAction("Index");
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
            Post post = _postManager.GetById((int)id);
            bool isDeleted = _postManager.Remove(post);
            if (isDeleted)
            {
                TempData["msg"] = "Post Deleted Successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}