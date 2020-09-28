using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Myfirst.Models;
using System.Data.Entity;
using System.Web.UI.WebControls;


namespace Myfirst.Controllers
{
    [RoutePrefix("Movie")]
    [Authorize]
    public class MovieController : Controller
    {
        private ApplicationDbContext dbContext = null;
        public MovieController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        // GET: Movie
        public ActionResult Index()
        {


            //Movie movie = new Movie();
            //movie. Name = "Adda";
            //movie.Releasedate = DateTime.Now;
            //movie.Hero = "Sushanth";
            var movie = GetMovies();


            return View(movie);
        }

        [Route("GetMovie/{movieId}")]
        [AllowAnonymous]
        public ActionResult GetmovieByid(int movieId)
        {
            return Content($"Movie Id is:{movieId}");
        }
        [Route("SearchMovie/{HeroName?}/{release?}")]
        public ActionResult SearchMovie(string HeroName, DateTime? release)
        {
            if (String.IsNullOrEmpty(HeroName))
            {
                HeroName = "default";
            }
            if (!release.HasValue)
            {
                release = DateTime.Now;
            }
            return Content($"Hero Name:{HeroName}, release:{release.Value}");


        }
        [HandleError(ExceptionType =typeof(NullReferenceException),View ="Nullref")]

        public ActionResult Details(int id)
        {
            throw new NullReferenceException(nameof(id));
            //Lambda Expression
            //var movie = GetMovies().FirstOrDefault(movie1 => movie1.Id == id);
            //var movie = dbContext.movies.Include(movie1 => movie1.Genre).FirstOrDefault(m => m.Id == id);
            //return View(movie);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var ViewModel = new MovieViewModel
            {
                Movie = new Movie(),
                GetGenres = dbContext.Genres.ToList()
            };
            //var genres = GenerateGenres();
            //ViewBag.GenreId = GenerateGenres();
            return View("CreateNew",ViewModel);
        }
        [HttpPost]
        [Authorize(Users ="nishitha999@gmail.com")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var ViewModel = new MovieViewModel
                {
                    Movie = movie,
                    GetGenres = dbContext.Genres.ToList()
                };
                return View("CreateNew", ViewModel);
            }
            dbContext.movies.Add(movie);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Movie");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Delete(int id)
        {
            var movie = dbContext.movies.SingleOrDefault(m => m.Id == id);
            
                if (movie != null)
                {
                    dbContext.movies.Remove(movie);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index", "Movie");
                }
            
            return HttpNotFound();
        }
        [NonAction]
        public IEnumerable<SelectListItem> GenerateGenres()
        {
            var genres = dbContext.Genres.AsEnumerable().Select(g => new SelectListItem
            {
                Text = g.GenreName,
                Value = g.Id.ToString()

            }); 
            return genres;
        }
        [HttpGet]
        [HandleError(ExceptionType =typeof(NullReferenceException),View="Nullref")]
        public ActionResult Edit(int id)
        {
            var movie = dbContext.movies.SingleOrDefault(m => m.Id == id);
            if (movie != null)
            {
                var ViewModel = new MovieViewModel
                {
                    Movie = movie,
                    GetGenres = dbContext.Genres.ToList()
                };


                return View(ViewModel);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Movie movie)
        {
            var movie1 = dbContext.movies.SingleOrDefault(m => m.Id == id);
                if (movie1 != null)
                {
                movie1.Name = movie.Name;
                movie1.DirectorName = movie.DirectorName;
                movie1.Hero = movie.Hero;
                movie1.Releasedate = movie.Releasedate;
                movie1.GenreId = movie.GenreId;
                dbContext.SaveChanges();
                return RedirectToAction("Index","Movie");

                }
            return HttpNotFound();
        }
      

        [NonAction]
        public List<Movie> GetMovies()
        {
            return dbContext.movies.ToList();
            //return new List<Movie>
            //{
            //new Movie { Name = "Saaho", Releasedate = DateTime.Now.AddYears(-2), Hero = "Prabhas" },
            // new Movie { Name = "Remo", Releasedate = DateTime.Now.AddYears(-7), Hero = "Sk" },
            // new Movie { Name = "Buny", Releasedate = DateTime.Now.AddYears(-5), Hero = "Arjun" },
            // new Movie { Name = "Uppenaa", Releasedate = DateTime.Now.AddYears(1), Hero = "Tej" },
            // new Movie { Name = "kshnam", Releasedate = DateTime.Now.AddYears(3), Hero = "Sesh" },
            //};
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
    }
}