using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IEmployeeAttendanceReportDataProvider
    {
        IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportSelectAll(EmployeeAttendanceReportSearchRequest searchRequest);

        IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeCentreAndDepartmentWise(EmployeeAttendanceReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportData(EmployeeAttendanceReportSearchRequest searchRequest);
    }
}
