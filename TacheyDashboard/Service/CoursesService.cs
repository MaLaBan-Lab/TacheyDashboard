using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel.Courses;

namespace TacheyDashboard.Service
{
    public class CoursesService
    {
        private TacheyRepository _tacheyRepository;
        public CoursesService(TacheyRepository tacheyRepository)
        {
            _tacheyRepository = tacheyRepository;
        }

        public List<CoursesViewModel> GetAllCourseCategory()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            //var result = from c in category
            //             join det in detail on c.CategoryId equals det.CategoryId
            //             //group c by new { c.CategoryId, c.CategoryName } into g
            //             select new CoursesViewModel
            //             {
            //                 CategoryId = c.CategoryId,
            //                 CategoryName = c.CategoryName,
            //                 DetailName = det.DetailName
            //             };

            //var result = from c in category
            //             join det in detail on c.CategoryId equals det.CategoryId

            //             group c by new { c.CategoryId, c.CategoryName } into g
            //             select new
            //             {
            //                 CategoryId = g.Key.CategoryId,
            //                 CategoryName = g.Key.CategoryName
            //             };

            //List<object> myLists = new List<object>();

            //var result = categoryResult.GroupBy(x => x.CategoryId).Select(g => myLists.Add(g.Key));

            var result = from c in category
                         select new CoursesViewModel
                         {
                             CategoryId = c.CategoryId,
                             CategoryName = c.CategoryName
                         };

            return result.ToList();
        }

        public List<CoursesViewModel> GetAllCategoryDetail()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var result = from d in detail
                         select new CoursesViewModel
                         {
                             DetailName = d.DetailName
                         };

            return result.ToList();
        }

        public List<CoursesViewModel> GetAllCategoryDetail(int CategoryId)
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var result = from d in detail
                         where d.CategoryId == CategoryId
                         select new CoursesViewModel
                         {
                             DetailName = d.DetailName
                         };

            return result.ToList();
        }

        public CoursesViewModel GetLastCourseCategoryId()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var categoryviewmodel = from c in category
                         select new CoursesViewModel
                         {
                             CategoryId = c.CategoryId,
                             CategoryName = c.CategoryName
                         };


            var result = categoryviewmodel.OrderByDescending(u => u.CategoryId).FirstOrDefault();

            return result;
        }
    }
}
