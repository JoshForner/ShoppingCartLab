using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartLab.Models;

namespace ShoppingCartLab.Controllers
{
    public class MovieController : Controller
    {
        public List<Movie> movies = new List<Movie>()
        {
            new Movie("Superbad", 120),
            new Movie("Zombieland", 140),
            new Movie("Avatar", 200)
        };

        public List<Movie> cart = new List<Movie>();
            
        public IActionResult Index()
        {
            string movielistjson = JsonSerializer.Serialize(movies);
            HttpContext.Session.SetString("Movies", movielistjson);
            string cartjson = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString("Cart", cartjson);
            return RedirectToAction("MovieList");
        }

        public IActionResult Movielist(Movie a)
        {
            return View(a);
        }

        public IActionResult Cart(Movie a) 
        {
            string movie = JsonSerializer.Serialize(a);
            HttpContext.Session.SetString("Movie", movie);
            return RedirectToAction("AddToCart");
        }

        public IActionResult AddToCart(Movie a)
        {
            string cartlist = HttpContext.Session.GetString("Cart");
            List<Movie> cart = JsonSerializer.Deserialize<List<Movie>>(cartlist);
            
            if (cart.Count == 0)
            {
                cart.Add(a);
                cartlist = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString("Cart", cartlist);
            }
            else
            {
                
               
                    if (cart.Any(x => x.Title == a.Title))
                    {
                        return View("ErrorPage");
                    }            
                    
                    
              
                        cart.Add(a);
                        cartlist = JsonSerializer.Serialize(cart);
                        HttpContext.Session.SetString("Cart", cartlist);
            }
            return RedirectToAction("MovieList");
        }

        public IActionResult CartList()
        {
            return View();
        }

        public IActionResult Receipt()
        {
            
            return View();
        }

    }
}
