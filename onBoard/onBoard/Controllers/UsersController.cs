using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using onBoard.Data;
using onBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Newtonsoft.Json;

namespace onBoard.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProjectContext _context;

        public UsersController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {

            var hours = _context.Hours.AsNoTracking();
            if (hours == null)
            {
                return NotFound();
            }
            return View(await hours.ToListAsync());

        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string? id)
        {

           
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Name == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public async Task<IActionResult> Create(TimeSpan? hour)
        {
            //if( hour != null)
            //{
            //    ViewData["Hour"] = hour?.Hours.ToString();
            //    ViewData["Minute"] = hour?.Minutes.ToString();
            //    ViewData["Second"] = hour?.Seconds.ToString();
            //}
            return View();
        }

        // POST: Users/GetHour
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<JsonResult> GetHour()
        {
            TimeSpan currentHour = DateTime.Now.TimeOfDay;
            await UpdateDatabase(currentHour);
            string hours = currentHour.Hours.ToString();
            string minutes = currentHour.Minutes.ToString();
            string seconds = currentHour.Seconds.ToString();

            var myData = new
            {
                hours,
                minutes,
                seconds
            };

            //Tranform it to Json object
            return Json(myData);
        }

        public async Task UpdateDatabase(TimeSpan currentHour)
        {
            if (_context.Users.Find(getName()) is null)
            {
                User user = new User { Name = getName() };
                _context.Add(user);
            }
            Hour hour = new Hour { UserName = getName(), HourPressed = currentHour };

            _context.Add(hour);
            await _context.SaveChangesAsync();
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name")] User user)
        {
            if (id != user.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Name))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Name == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ProjectContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
          return (_context.Users?.Any(e => e.Name == id)).GetValueOrDefault();
        }

        private string getName()
        {
            var nombre = User.Identity.Name;
            var pos = nombre.IndexOf("\\", 0, nombre.Length, 0) + 1;
            return nombre.Substring(pos, nombre.Length - pos);
        }
    }
}
