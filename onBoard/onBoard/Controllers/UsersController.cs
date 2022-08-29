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
using onBoard.DBRepo;

namespace onBoard.Controllers
{
    public class UsersController : Controller
    {
        //private readonly ProjectContext _context;
        private IDBRepo _db;
        //public UsersController(ProjectContext context)
        //{
        //    _context = context;
        //}
        public UsersController(DBRepoMongo db)
        {
            _db = db;
        }

        // GET: Users
        public async Task<IActionResult> Index(int? pageNumber)
        {

            var hours = _db.GetList();
            if (hours == null)
            {
                return NotFound();
            }

            int pagesize = 10;
            return View(await PaginatedList<Hour>
                .CreateAsync(
                hours, 
                pageNumber ?? 1, 
                pagesize)
                );

        }

        // GET: Users/Create
        public async Task<IActionResult> Create(TimeSpan? hour)
        {
            return View();
        }

        // POST: Users/GetHour
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<JsonResult> GetHour()
        {
            TimeSpan currentHour = DateTime.Now.TimeOfDay;
            await _db.AsyncStoreTimeSpan(currentHour,getName());
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

        private string getName()
        {
            var name = User.Identity.Name;
            var pos = name.IndexOf("\\", 0, name.Length, 0) + 1;
            return name.Substring(pos, name.Length - pos);
        }

        [HttpGet]
        public async Task<JsonResult> GetNameLayout()
        {
            var name = getName();
            return Json(name);
        }
    }
}
