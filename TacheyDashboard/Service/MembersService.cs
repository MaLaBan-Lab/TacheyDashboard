using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tachey001.Repository;

namespace TacheyDashboard.Service
{
    public class MembersService
    {
        //跟Repository拿資料
        private TacheyRepository _tacheyRepository;
        //初始化資料庫邏輯
        public MembersService()
        {
            //_tacheyRepository = new TacheyRepository(new TacheyContext());
        }
    }
}
