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

namespace CawCaw.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public Index IndexModel { get; set; }

        public IActionResult Index()
        {
            return View(IndexModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Index indexModel)
        {
            if(ModelState.IsValid)
            {
                Post Post = new Post {PostText = indexModel.InputText, Timestamp = DateTime.Now, Author = User.Identity.Name};
                _db.Add(Post);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

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
