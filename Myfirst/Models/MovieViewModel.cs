using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Myfirst.Models;

namespace Myfirst.Models
{
    public class MovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> GetGenres { get; set; }
    }
}