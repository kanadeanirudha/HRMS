using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeShiftMasterDataProvider
    {
        IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMaster(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMaster(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> DeleteEmployeeShiftMaster(EmployeeShiftMaster item);
        IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterBySearch(EmployeeShiftMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterBySearchList(EmployeeShiftMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeShiftMaster> GetEmployeeShiftMasterBySelectByEmployeeShiftMasterID(EmployeeShiftMaster item);
        IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySearch(EmployeeShiftMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMasterDetails(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySelectByEmployeeShiftMasterDetailsID(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMasterDetails(EmployeeShiftMaster item);        
    }
}
