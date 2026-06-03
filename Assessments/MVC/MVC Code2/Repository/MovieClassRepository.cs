using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MoviesMVC.Models;

namespace MoviesMVC.Repository
{
    public class MovieRepository : IMovieRepository
    {
        MovieContext db = new MovieContext();

        public List<Movie> GetAll()
        {
            return db.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return db.Movies.Find(id);
        }

        public void Insert(Movie movie)
        {
            db.Movies.Add(movie);
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Movie m = db.Movies.Find(id);

            if (m != null)
            {
                db.Movies.Remove(m);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public List<Movie> MoviesByYear(int year)
        {
            return db.Movies
                     .Where(x => x.DateOfRelease.Year == year)
                     .ToList();
        }

        public List<Movie> MoviesByDirector(string director)
        {
            return db.Movies
                     .Where(x => x.DirectorName == director)
                     .ToList();
        }
    }
}