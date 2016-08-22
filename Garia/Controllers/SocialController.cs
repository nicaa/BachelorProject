using Garia.Core.Entities;
using Garia.Core.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Garia.Controllers
{
    public class SocialController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult Social()
        {
            List<Social> model = SocialHandler.GetAllPost();

            return View(initlikeAndComment(model));
        }
        [Authorize]
        [HttpPost]
        public ActionResult SocialPost(Social s, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                //Upload images to folder /Images
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string newName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), newName);
                    string extention = System.IO.Path.GetExtension(file.FileName);
                    // Allowed file extensions
                    if (extention.ToLower() == ".png" || extention.ToLower() == ".jpg" ||
                        extention.ToLower() == ".bmp" || extention.ToLower() == ".jpeg")
                    {
                        //Save image    
                        file.SaveAs(path);
                        s.ImagePath = newName;
                    }
                }
                SocialHandler.CreatePost(s.Text, DateTime.Now, s.ImagePath, Convert.ToInt32(User.Identity.Name));
            }

            List<Social> model = SocialHandler.GetAllPost();
            return PartialView("_SocialList", initlikeAndComment(model));
        }
        [Authorize]
        [HttpPost]
        public ActionResult SocialComment(Social model, string commentText)
        {
            if (commentText != "")
            {
                SocialHandler.CreateComment(commentText, DateTime.Now, model.Fname + " " + model.Lname, model.SocialId);
            }

            List<Social> socialList = SocialHandler.GetAllPost();
            return PartialView("_SocialList", initlikeAndComment(socialList));
        }
        [Authorize]
        [HttpPost]
        public ActionResult SocialLike(Social model)
        {
            List<Social> socialList = SocialHandler.GetAllPost();
            Like like = SocialHandler.CheckLike(Convert.ToInt32(User.Identity.Name), model.SocialId);
            if (like == null)
            {
                SocialHandler.CreateLike(Convert.ToInt32(User.Identity.Name), model.SocialId);

            }

            return PartialView("_SocialList", initlikeAndComment(socialList));
        }
        [Authorize]
        [HttpPost]
        public ActionResult SocialDisLike(Social model)
        {

            SocialHandler.DeleteLikeById(model.SocialId, Convert.ToInt32(User.Identity.Name));

            List<Social> socialList = SocialHandler.GetAllPost();
            return PartialView("_SocialList", initlikeAndComment(socialList));
        }

        [Authorize]
        [HttpPost]
        public JsonResult SocialDelete(int socialId)
        {
            SocialHandler.DeletePostById(socialId);
            return Json("OK");
        }
        public List<Social> initlikeAndComment(List<Social> model)
        {
            for (int i = 0; i < model.Count; i++)
            {
                model[i].Comments = SocialHandler.GetCommentById(model[i].SocialId);
                model[i].LikeList = SocialHandler.GetLikesById(model[i].SocialId);
            }
            return model;
        }
	}
}