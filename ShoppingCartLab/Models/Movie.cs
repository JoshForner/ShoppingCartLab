using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartLab.Models
{
    public class Movie
    {
        public int Runtime { get; set; }
        public string Title { get; set; }


        public Movie() { }

        public Movie(string Title, int Runtime)
        {
            this.Title = Title;
            this.Runtime = Runtime;
        }
    }
}
