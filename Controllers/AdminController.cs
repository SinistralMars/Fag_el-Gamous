using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fag_el_Gamous.Models;

// This controller handles administrative tasks such as listing and deleting users
// in the Fag_el_Gamous web application



namespace Fag_el_Gamous.Controllers
{
    public class AdminController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        // Constructor for dependency injection of UserManager and SignInManager
        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Action method to display a list of users
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;

            return View(users);
        }

        // Action method to delete a user by their userId
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Sign the user out if they are currently signed in
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

