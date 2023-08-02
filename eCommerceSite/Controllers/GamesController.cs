﻿using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;
        public GamesController(VideoGameContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            //Get all games from db
            List<Game> games = await _context.Games.ToListAsync();

            //show them on the page

            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(Game g)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(g); //prepares insert
                await _context.SaveChangesAsync(); //Executes pending insert
                // Show success message on page
                ViewData["Message"] = $"{g.Title} was added successfully";
                return View();
            }

            return View(g);
        }
    }
}
