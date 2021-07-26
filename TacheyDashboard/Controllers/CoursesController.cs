using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TacheyDashboard.Models;
using TacheyDashboard.Service;

namespace TacheyDashboard.Controllers
{
    [Authorize]
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
            return View();
        }

        public IActionResult Application()
        {
            return View();
        }

        public IActionResult CourseCategory()
        {
            var resultData = _coursesService.GetAllCourseCategory();

            string JsonResultData = JsonConvert.SerializeObject(resultData);

            ViewBag.Labels = JsonResultData;

            var resultDataDetail = _coursesService.GetAllCategoryDetail();

            string JsonResultDataDetail = JsonConvert.SerializeObject(resultDataDetail);

            ViewBag.LabelsDetail = JsonResultDataDetail;

            var resultId = _coursesService.GetLastCourseCategoryId();

            string JsonResultId = JsonConvert.SerializeObject(resultId);

            ViewBag.LastLabelsId = JsonResultId;

            return View();
        }
    }
}
