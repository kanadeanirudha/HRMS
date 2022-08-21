using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmpEmployeeMasterDataProvider
    {
        IBaseEntityResponse<EmpEmployeeMaster> InsertEmpEmployeeMaster(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMaster(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterPersonalInformation(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterOfficeDetails(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> DeleteEmpEmployeeMaster(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterBySearch(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmpEmployeeMaster> GetEmpEmployeeMasterByID(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByCentreCodeAndDeptID(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmpEmployeeMaster> GetCurrentPassword(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> InsertNewPassword(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetCallerEmployeeList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByEmployeeInCRMSales(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForCRMSalesGroup(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForTargetException(EmpEmployeeMasterSearchRequest searchRequest);
    //For Staff Allocation
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeNameList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeDetailsForImportExcel(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmpEmployeeMaster> GetDataValidationListsForEmployeeMasterExcel(EmpEmployeeMaster item);
        IBaseEntityResponse<EmpEmployeeMaster> InsertEmployeeMasterExcelUpload(EmpEmployeeMaster item);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterServiceList(EmpEmployeeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterExecutive(EmpEmployeeMasterSearchRequest searchRequest);

    }
}
