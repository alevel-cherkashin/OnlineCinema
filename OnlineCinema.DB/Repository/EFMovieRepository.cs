﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCinema.DB.DataModels;

namespace OnlineCinema.DB.Repository
{
    public class EFMovieRepository : IMovieRepository
    {
        private OnlineCinemaDataModel _context;

        public EFMovieRepository(OnlineCinemaDataModel context)
        {
            _context = context;
        }

        public int Add(Movie movie)
        {
            _context.Movie.Add(movie);

            return movie.Id;
        }

        public void Delete(int id)
        {
            var movie = GetDeteils(id);

            movie.IsDeleted = true;
        }

        public List<Movie> Get()
        {
            return _context.Movie.ToList();
        }

        public Movie GetDeteils(int id)
        {
            return _context.Movie.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movie movie)
        {
            var OldMovie = GetDeteils(movie.Id);

            OldMovie.Image = movie.Image;
            OldMovie.IsDeleted = movie.IsDeleted;
            OldMovie.Name = movie.Name;
            OldMovie.VideoLink = movie.VideoLink;
            OldMovie.GenreId = movie.GenreId;
            OldMovie.Genre = movie.Genre;
        }
    }
}