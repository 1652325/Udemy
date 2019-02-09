using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Udemy.Models;

namespace Udemy.ViewModel
{
    public class MoviesVm
    {
        public List<Movie> lstMovies { get; set; } = new List<Movie>();
    }
}