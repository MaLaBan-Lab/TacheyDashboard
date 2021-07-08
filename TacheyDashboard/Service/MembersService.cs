using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;
using TacheyDashboard.Models;
using TacheyDashboard.ViewModel.Members;

namespace TacheyDashboard.Service
{
    public class MembersService
    {
        //跟Repository拿資料
        private TacheyRepository _tacheyRepository;
        //初始化資料庫邏輯
        public MembersService()
        {
            _tacheyRepository = new TacheyRepository(new TacheyContext());
        }

        public List<MemberViewModel> GetAllMemberData(string MemberId)
        {
            var member = _tacheyRepository.GetAll<Models.Member>(x => x.MemberId == MemberId);

            var result = from m in member
                         select new MemberViewModel
                         {
                             MemberID = m.MemberId,
                             Account = m.Account,
                             Password = m.Password,
                             Name = m.Name,
                             Email = m.Email,
                             EmailStatus = m.EmailStatus,
                             JoinTime = m.JoinTime,
                             Sex = m.Sex,
                             CountryRegion = m.CountryRegion,
                             City = m.City,
                             Address = m.Address,
                             PostalCode = m.PostalCode,
                             PhoneNumber = m.PhoneNumber,
                             Birthday = m.Birthday,
                             Interest = m.Interest,
                             Like = m.Like,
                             Expertise = m.Expertise,
                             About = m.About,
                             InterestContent = m.InterestContent,
                             Language = m.Language,
                             Photo = m.Photo,
                             Introduction = m.Introduction,
                             Theme = m.Theme,
                             Profession = m.Profession,
                             Point = m.Point,
                             Facebook = m.Facebook,
                             Line = m.Line,
                             Google = m.Google
                         };

            return result.ToList();
        }
    }
}
