using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCDataAssignment_V2.Models.ViewModels;
using MVCDataAssignment_V2.Models;
namespace MVCDataAssignment_V2.Controllers
{
    //[Authorize(Roles ="SuperAdmin")]
    public class AccountPersonController : Controller
    {   
        private readonly UserManager<AccountPerson> _userManager;
        private readonly SignInManager<AccountPerson> _signInManager;

        
        public AccountPersonController(UserManager<AccountPerson> userManager, SignInManager<AccountPerson> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

       
        [AllowAnonymous]
        [HttpGet]
        public  IActionResult RegisterUser()
        {

            return View();
        }

        public async Task<IActionResult> RegisterUser(CreateAccountPersonViewModel createAccount)
        {
            if (ModelState.IsValid) {
                AccountPerson accountPerson = new AccountPerson()
                {
                    UserName = createAccount.Username,
                    Email = createAccount.EMail,
                    FirstName = createAccount.FirstName,
                    LastName = createAccount.LastName,
                    DateOfBirth = createAccount.DateOfBirth,
                };

                IdentityResult result = await _userManager.CreateAsync(accountPerson, createAccount.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "AccountPerson");
                }

                foreach (IdentityError identityError in result.Errors)
                {
                    ModelState.AddModelError(identityError.Code, identityError.Description);
                }
                
            }
            
            return View();

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        async public Task<IActionResult> Login(string userName, string password)
        {
            Microsoft.AspNetCore.Identity.SignInResult result =
                await _signInManager.PasswordSignInAsync(userName, password, true, false);
            
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
