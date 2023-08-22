﻿using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace eCommerceSite.Controllers
{
    public class MembersController : Controller
    {
        private readonly VideoGameContext _context;
        public MembersController(VideoGameContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {

            if (ModelState.IsValid)
            {
                //Map regModel data to member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password,
                };
                
                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                LogUserIn(newMember.Email);

                return RedirectToAction("Index", "Home");
            }

            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Member? m = (from member in _context.Members
                            where member.Email == loginModel.Email &&
                            member.Password == loginModel.Password
                            select member).SingleOrDefault();

                if (m != null)
                {
                    LogUserIn(loginModel.Email);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Credentials not found!");
            }

            return View(loginModel);
        }

        private void LogUserIn(string email)
        {
            HttpContext.Session.SetString("Email", email);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
