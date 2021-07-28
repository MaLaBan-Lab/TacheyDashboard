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
                             CategoryId = d.CategoryId,
                             DetailID = d.DetailId,
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

        public CoursesViewModel GetLastCategoryDetailId()
        {
            var category = _tacheyRepository.GetAll<CourseCategory>();

            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var categoryviewmodel = from c in detail
                                    select new CoursesViewModel
                                    {
                                        CategoryId = c.CategoryId,
                                        DetailID = c.DetailId,
                                        DetailName = c.DetailName
                                    };


            var result = categoryviewmodel.OrderByDescending(u => u.CategoryId).FirstOrDefault();

            return result;
        }

        public int GetLastCategoryDetailId(string id)
        {
            var detail = _tacheyRepository.GetAll<CategoryDetail>();

            var categoryviewmodel = from c in detail
                                    select new CoursesViewModel
                                    {
                                        CategoryId = c.CategoryId,
                                        DetailID = c.DetailId,
                                        DetailName = c.DetailName
                                    };

            var lastnum = categoryviewmodel.Where(x => x.DetailID.ToString().Substring(0, id.Length).Contains($"{id}") && x.DetailID.ToString().Length == (4 + id.Length)).OrderByDescending(x => x.DetailID).FirstOrDefault();

            var result = lastnum == null ? (id + "0001") : lastnum.DetailID.ToString();

            //if (lastnum == null)
            //{
            //    result = (id + "0001");
            //}
            //else 
            //{
            //    result = lastnum.DetailID.ToString();
            //}

            return int.Parse(result);
        }

        public void UpdateParentChoice(int CategoryId, string CategoryName)
        {
            var result = _tacheyRepository.Get<CourseCategory>(x => x.CategoryId == CategoryId);

            result.CategoryName = CategoryName;

            _tacheyRepository.SaveChanges();
        }

        public void AddParentChoice(int CategoryId, string CategoryName)
        {
            //var result = _tacheyRepository.GetAll<CourseCategory>();
            //foreach (var item in result)
            //{
            //    CourseCategory t = new CourseCategory { CategoryId = item.CategoryId, CategoryName = item.CategoryName };
            //    _tacheyRepository.Create<CourseCategory>(t);

            //}
            //_tacheyRepository.SaveChanges();

            var ToF = _tacheyRepository.Get<CourseCategory>(x => x.CategoryId == CategoryId && x.CategoryName == CategoryName);
            if (ToF == null)
            {
                var result = new CourseCategory { CategoryId = CategoryId, CategoryName = CategoryName };
                _tacheyRepository.Create(result);
            }
            else
            {
                _tacheyRepository.Delete(ToF);
            }
            _tacheyRepository.SaveChanges();


            //var result = _tacheyRepository.Get<Models.Member>(x => x.MemberID == id);

            //result.Sex = id;

            //_tacheyRepository.SaveChanges()

        }

        public void DeleteParentChoice(int CategoryId)
        {
            var result = _tacheyRepository.Get<CourseCategory>(x => x.CategoryId == CategoryId);
            _tacheyRepository.Delete(result);
            _tacheyRepository.SaveChanges();

        }

        public void UpdateSonChoice(int CategoryId, int DetailID, string DetailName)
        {
            var result = _tacheyRepository.Get<CategoryDetail>(x => x.CategoryId == CategoryId && x.DetailId == DetailID);

            result.DetailName = DetailName;

            _tacheyRepository.SaveChanges();
        }

        public void AddSonChoice(int CategoryId, int DetailID, string DetailName)
        {
            var ToF = _tacheyRepository.Get<CategoryDetail>(x => x.CategoryId == CategoryId && x.DetailId == DetailID && x.DetailName == DetailName);
            if (ToF == null)
            {
                var result = new CategoryDetail { CategoryId = CategoryId, DetailId = DetailID, DetailName = DetailName };
                _tacheyRepository.Create(result);
            }
            else
            {
                _tacheyRepository.Delete(ToF);
            }
            _tacheyRepository.SaveChanges();
        }

        public void DeleteSonChoice(int DetailID)
        {
            var result = _tacheyRepository.Get<CategoryDetail>(x => x.DetailId == DetailID);
            _tacheyRepository.Delete(result);
            _tacheyRepository.SaveChanges();

        }
    }
}
