﻿using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.BL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;

namespace OnlineCinema.API.Controllers
{
    [Authorize]
    public class MovieController : ApiController
    {
        [Inject]
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var _moviesList = _movieService.GetAll().Select(b => b.ToViewModel()).OrderBy(f => f.Name);
            return Ok(_moviesList);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _movieService.GetItem(id).ToViewModel();

            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]MovieView movie)
        {
            if (ModelState.IsValid)
            {
                int clientId = _movieService.Add(movie.ToDtoModel());
                return Ok(clientId);
            }
            return BadRequest("You've entered invalid values!");
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] MovieView model)
        {
            if (ModelState.IsValid)
            {
                _movieService.Update(model.ToDtoModel());
                return Ok();
            }
            return BadRequest("You've entered invalid values!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _movieService.Delete(id);

            return Ok();
        }
    }
}
