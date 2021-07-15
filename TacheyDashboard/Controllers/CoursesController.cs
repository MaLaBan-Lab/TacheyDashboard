using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
using TacheyDashboard.ViewModel.Course;
using Newtonsoft.Json;

namespace TacheyDashboard.Controllers
{
    public class CoursesController : Controller
    {
        private readonly TacheyContext _context;

        private CoursesService _coursesService;

        public CoursesController()
        {
            _context = new TacheyContext();

            _coursesService = new CoursesService();
        }
        public IActionResult Product()
        {
            var result = _coursesService.GetAllCourse();

            string Jsonresult = JsonConvert.SerializeObject(result);

            ViewBag.Labels = Jsonresult;

            return View();
        }

        public IActionResult Application()
        {
            return View();
        }
    }
}
