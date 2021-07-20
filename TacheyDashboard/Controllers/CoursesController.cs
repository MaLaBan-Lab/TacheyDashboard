using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using TacheyDashboard.Models;
using TacheyDashboard.Service;
using TacheyDashboard.ViewModel.Courses;
using Newtonsoft.Json;

namespace TacheyDashboard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CoursesController : Controller
    {
        private readonly TacheyContext _context;

        private CoursesService _coursesService;

        public CoursesController(CoursesService coursesService)
        {
            _context = new TacheyContext();

            _coursesService = coursesService;
        }
        public IActionResult Product()
        {
            var result = _coursesService.GetAllCourseProduct();

            string Jsonresult = JsonConvert.SerializeObject(result);

            ViewBag.Labels = Jsonresult;

            return View();
        }

        public IActionResult Verify(bool? CreateVerify, string CourseId )
        {
            _coursesService.UpdateStepCreateVerify(CreateVerify,CourseId);

            return Redirect("Product");

        }

        public IActionResult Application()
        {
            return View();
        }
    }
}
