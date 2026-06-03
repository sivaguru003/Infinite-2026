using System.Web.Mvc;
using MoviesMVC.Models;
using MoviesMVC.Repository;

namespace MoviesMVC.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepository repo = new MovieRepository();

         public ActionResult Index()
        {
            return View(repo.GetAll());
        }

         public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            repo.Save();

            return RedirectToAction("Index");
        }

         public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            repo.Save();

            return RedirectToAction("Index");
        }

         public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            repo.Delete(movie.Mid);
            repo.Save();

            return RedirectToAction("Index");
        }

         public ActionResult MoviesByYear(int year)
        {
            var data = repo.MoviesByYear(year);

            return View(data);
        }

         public ActionResult MoviesByDirector(string director)
        {
            var data = repo.MoviesByDirector(director);

            return View(data);
        }
    }
}