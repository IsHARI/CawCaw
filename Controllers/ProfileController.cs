using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CawCaw.Data;
using CawCaw.Models;
using CawCaw.Views.Profile;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CawCaw.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public Profile ProfileModel { get; set; }

        public async Task<IActionResult> Index(string userName)
        {
            // TODO: Handle "/Profile" route graciously
            ApplicationUser ProfileUser = await _userManager.FindByNameAsync(userName);
            ApplicationUser CurrentUser = await _userManager.GetUserAsync(User);
            List<Post> PostList = _db.Post.Include("Author").Where(post => post.Author.Equals(ProfileUser)).ToList();
            ProfileModel = new Profile {Posts = PostList, ProfileUser = ProfileUser, Current = CurrentUser.Equals(ProfileUser)};
            return View(ProfileModel);
        }
    }
}