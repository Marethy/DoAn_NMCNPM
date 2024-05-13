using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class BUL_BaoCaoTonKho
    {
        DAL.DAL_BaoCaoTonKho _dalInventoryReport;
        public BUL_BaoCaoTonKho()
        {
            _dalInventoryReport = new DAL.DAL_BaoCaoTonKho();
        }
        public void addNewInventoryReport(DTO.BAOCAOTONKHO report)
        {
            _dalInventoryReport.addNewInventoryReport(report);
        }
        public DTO.BAOCAOTONKHO getInventoryReportById(DateTime reportdate, int productid)
        {
            return _dalInventoryReport.getInventoryReportById(reportdate, productid);
        }
        public List<DTO.BAOCAOTONKHO> getInventoryReportByDate(DateTime reportdate)
        {
            return _dalInventoryReport.getInventoryReportByDate(reportdate);
        }
        public bool isReportExisted(DateTime reportdate)
        {
            return _dalInventoryReport.isReportExisted(reportdate);
        }
    }
}
