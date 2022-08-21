using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IEmployeeBulkAttendenceDataProvider
    {
        IBaseEntityResponse<EmployeeBulkAttendenceMaster> InsertEmployeeBulkAttendenceMasterExcelUpload(EmployeeBulkAttendenceMaster item);
        IBaseEntityResponse<EmployeeBulkAttendenceMaster> GetEmployeeAttendenceByID(EmployeeBulkAttendenceMaster item);
        IBaseEntityResponse<EmployeeBulkAttendenceMaster> UpdateEmployeeAttendence(EmployeeBulkAttendenceMaster item);
        IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> GetEmployeeListCentreAndDepartmentWise(EmployeeBulkAttendenceMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> GetEmployeeListForDownloadExcel(EmployeeBulkAttendenceMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeBulkAttendenceMaster> InsertEmployeeAttendenceForSingleOne(EmployeeBulkAttendenceMaster item);
    }
}
