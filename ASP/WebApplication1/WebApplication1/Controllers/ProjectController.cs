using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using System.Linq;

namespace Lisa.Website.Controllers
{
    public class ProjectsController : BaseController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(GetProject());
        }

        [PasswordCheck]
        public ActionResult Admin()
        {
            return View(GetProject());
        }

        [PasswordCheck]
        public ActionResult Delete(int? id)
        {
            var project = _db.Projects.Find(id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        [HttpPost]
        public ActionResult Delete(int id, string confirmed)
        {
            var project = _db.Projects.Find(id);

            if (confirmed == "Verwijderen")
            {
                _db.Projects.Remove(project);
                _db.SaveChanges();
            }

            return RedirectToAction("Admin");
        }

        [PasswordCheck]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Project project)
        {
            _db.Podcasts.Add(new Podcast
            {
                Title = project.Title,
                Image = project.Image,
                Content = project.Content,
                Author = project.Author,
                References = project.References,
                Date = DateTime.Now
            });
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }

        [PasswordCheck]
        public ActionResult Edit(int id)
        {
            var project = _db.Projects.Find(id);
            return View(project);
        }

        [HttpPost]
        public ActionResult Edit(int id, Project NewProject)
        {
            NewProject.Id = id;
            _db.Entry(NewProject).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Admin");
        }

        private IEnumerable<Project> GetProject()
        {
            return _db.Projects.AsEnumerable();
        }

        private WebsiteContext _db = new WebsiteContext();
    }
}