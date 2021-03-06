﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCinema.DB.DataModels;

namespace OnlineCinema.DB.Repository
{
    public class EFGenreRepository : IGenreRepository
    {
        private OnlineCinemaDataModel _context;

        public EFGenreRepository(OnlineCinemaDataModel context)
        {
            _context = context;
        }

        public int Add(Genre genre)
        {
            _context.Genre.Add(genre);

            return genre.Id;
        }

        public void Delete(int id)
        {
            var genre = GetDeteils(id);

            if(genre == null)
                throw new Exception("Genre not found.");

            if (genre.Movie.Count > 0)
                throw new Exception("You can't delete genre what releted to existin movie. Should delete movie first.");

            genre.IsDeleted = true;

        }

        public List<Genre> Get()
        {
            return _context.Genre
                .Where(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value)
                .ToList();
        }

        public Genre GetDeteils(int id)
        {

            return _context.Genre
                .Where(x => !x.IsDeleted.HasValue || !x.IsDeleted.Value)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Genre genre)
        {
            var OldGenre = GetDeteils(genre.Id);

            OldGenre.IsDeleted = genre.IsDeleted;
            OldGenre.Name = genre.Name;
        }
    }
}
