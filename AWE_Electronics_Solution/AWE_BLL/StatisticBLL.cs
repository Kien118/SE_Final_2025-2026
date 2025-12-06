using AWE_DAL;
using AWE_DTO;
using System.Collections.Generic;

namespace AWE_BLL
{
    public class StatisticBLL
    {
        private StatisticDAL dal = new StatisticDAL();

        public GeneralStat GetGeneralReport()
        {
            return dal.GetGeneralStats();
        }

        public List<CategoryStat> GetChartData()
        {
            return dal.GetStockByCategory();
        }
    }
}