using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel.Course;

namespace TacheyDashboard.Service
{
    public class CoursesService
    {
        private readonly TacheyContext _context;

        private TacheyRepository _tacheyRepository;
        //初始化資料庫邏輯
        public CoursesService()
        {
            _tacheyRepository = new TacheyRepository(new TacheyContext());

            _context = new TacheyContext();
        }

        public List<CourseViewModel> GetAllCourse()
        {
            var getcourses = _context.Courses;
            var category = _context.CourseCategories;
            var chapter = _context.CourseChapters;
            var unit = _context.CourseUnits;

            var result = from c in getcourses
                         select new CourseViewModel
                         {
                             CourseId = c.CourseId,
                             Title = c.Title,
                             Description = c.Description,
                             TitlePageImageUrl = c.TitlePageImageUrl,
                             MarketingImageUrl = c.MarketingImageUrl,
                             Tool = c.Tool,
                             CourseLevel = c.CourseLevel,
                             Effect = c.Effect,
                             CoursePerson = c.CoursePerson,
                             OriginalPrice = c.OriginalPrice,
                             PreOrderPrice = c.PreOrderPrice,
                             TotalMinTime = c.TotalMinTime,
                             Introduction = c.Introduction,
                             MemberId = c.MemberId,
                             LecturerIdentity = c.LecturerIdentity,
                             CategoryId = c.CategoryId,
                             CategoryDetailsId = c.CategoryDetailsId,
                             CreateDate = c.CreateDate,
                             CreateFinish = c.CreateFinish,
                             CreateVerify = c.CreateVerify,
                             PreviewVideo = c.PreviewVideo,
                             CustomUrl = c.CustomUrl,
                             MainClick = c.MainClick,
                             CustomClick = c.CustomClick,
                         };

            return result.ToList();
        }

        //public List<CourseViewModel> GetAllCourseProduct()
        //{
        //    var course = _tacheyRepository.GetAll<Course>();
        //    var category = _tacheyRepository.GetAll<CourseCategory>();
        //    var chapter = _tacheyRepository.GetAll<CourseChapter>();
        //    var unit = _tacheyRepository.GetAll<CourseUnit>();
        //    var result = from c in course
        //                 join cat in category on c.CategoryId equals cat.CategoryId
        //                 join ch in chapter on c.CourseId equals ch.CourseId
        //                 join u in unit on c.CourseId equals u.CourseId
        //                 select new CourseViewModel
        //                 {
        //                     CourseId = c.CourseId,
        //                     Title = c.Title,
        //                     Description = c.Description,
        //                     TitlePageImageUrl = c.TitlePageImageUrl,
        //                     MarketingImageUrl = c.MarketingImageUrl,
        //                     Tool = c.Tool,
        //                     CourseLevel = c.CourseLevel,
        //                     Effect = c.Effect,
        //                     CoursePerson = c.CoursePerson,
        //                     OriginalPrice = c.OriginalPrice,
        //                     PreOrderPrice = c.PreOrderPrice,
        //                     TotalMinTime = c.TotalMinTime,
        //                     Introduction = c.Introduction,
        //                     MemberId = c.MemberId,
        //                     LecturerIdentity = c.LecturerIdentity,
        //                     CategoryId = c.CategoryId,
        //                     CategoryName = cat.CategoryName,
        //                     CategoryDetailsId = c.CategoryDetailsId,
        //                     CreateDate = c.CreateDate,
        //                     CreateFinish = c.CreateFinish,
        //                     CreateVerify = c.CreateVerify,
        //                     PreviewVideo = c.PreviewVideo,
        //                     CustomUrl = c.CustomUrl,
        //                     MainClick = c.MainClick,
        //                     CustomClick = c.CustomClick,
        //                     ChapterId = ch.ChapterId,
        //                     ChapterName = ch.ChapterName,
        //                     UnitId = u.UnitId,
        //                     UnitName = u.UnitName,
        //                     CourseUrl = u.CourseUrl
        //                 };

        //    return result.ToList();
        //}
    }
}
