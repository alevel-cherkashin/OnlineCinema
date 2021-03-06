﻿

using OnlineCinema.BL.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineCinema.BL.Model
{
    public class GenreView
    {
        public int Id { get; set; }

        [Required(ErrorMessage  = "Required field")]
        public string Name { get; set; }
    }
}
