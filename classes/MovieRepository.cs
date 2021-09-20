using System;
using System.Collections.Generic;
using app_for_movie_registration.interfaces;

namespace app_for_movie_registration.classes
{
    public class MovieRepository : InterfaceRepo<Movie>
    {
        private List<Movie> moviesList = new List<Movie>();
        public List<Movie> ListAll()
        {
            return moviesList;
        }

        public Movie GetById(int id)
        {
            return moviesList[id];
        }

        public void Insert(Movie movie)
        {
            moviesList.Add(movie);
        }

        public void Delete(int id)
        {
            moviesList[id].Delete();
        }

        public void Update(int id, Movie movie) 
        {
            moviesList[id] = movie;
        }

        public int NextId()
        {
            return moviesList.Count;
        }
    }
}