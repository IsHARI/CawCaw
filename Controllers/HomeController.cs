using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CawCaw.Models;
using System.ComponentModel.DataAnnotations;
using CawCaw.Views.Home;
using CawCaw.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CawCaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public Index IndexModel { get; set; }

        public IActionResult Index()
        {
            List<Post> PostList = _db.Post.Include("Author").ToList();
            IndexModel = new Index {Posts = PostList};
            return View(IndexModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Index indexModel)
        {
            if(ModelState.IsValid)
            {
                var AuthorUser = await _userManager.GetUserAsync(User);
                Post Post = new Post {PostText = indexModel.InputText, Timestamp = DateTime.Now, Author = AuthorUser};
                _db.Add(Post);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            List<Post> PostList = _db.Post.Include("Author").ToList();
            IndexModel = new Index {Posts = PostList};
            return View(IndexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
