using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrimerProyectoAspNetCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerProyectoAspNetCore.Controllers
{
    public class AccountController : Controller
    {


        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;


        public AccountController(UserManager<IdentityUser> UserManager,
                                 SignInManager<IdentityUser> SignInManager)
        {
            userManager = UserManager;
            signInManager = SignInManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(LoginUsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                var result =  await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Login fallido");
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("index", "home");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(RegisterUsuarioModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View(model);

        }



    }
}
