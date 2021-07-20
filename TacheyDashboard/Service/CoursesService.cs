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
        //初始化資料庫邏輯
        private TacheyRepository _tacheyRepository;
        public CoursesService(TacheyRepository tacheyRepository)
        {
            _tacheyRepository = tacheyRepository;
        }
        public List<CoursesViewModel> GetAllCourseProduct()
        {
            var course = _tacheyRepository.GetAll<Course>();

            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var chapter = _tacheyRepository.GetAll<CourseChapter>();

            var unit = _tacheyRepository.GetAll<CourseUnit>();

            var result = from c in course
                         join cat in category on c.CategoryId equals cat.CategoryId
                         join det in detail on c.CategoryDetailsId equals det.DetailId
                         select new CoursesViewModel
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
                             CategoryName = cat.CategoryName,
                             DetailID = c.CategoryDetailsId,
                             DetailName = det.DetailName,
                             CreateDate = c.CreateDate,
                             CreateFinish = c.CreateFinish,
                             CreateVerify = c.CreateVerify,
                             PreviewVideo = c.PreviewVideo,
                             CustomUrl = c.CustomUrl,
                             MainClick = c.MainClick,
                             CustomClick = c.CustomClick,
                             courseChapters = chapter.Where(x => x.CourseId == c.CourseId).ToList(),
                             courseUnits = unit.Where(x => x.CourseId == c.CourseId).ToList()
                         };

            return result.ToList();
        }

        public void UpdateStepCreateVerify(bool? CreateVerify,string CourseId)
        {
            var result = _tacheyRepository.Get<Course>(x => x.CourseId == CourseId);

            result.CreateVerify = CreateVerify;

            _tacheyRepository.SaveChanges();
        }

    }
}
