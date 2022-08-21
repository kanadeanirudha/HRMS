using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IEmployeeShiftMasterBA
    {
        IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMaster(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMaster(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> DeleteEmployeeShiftMaster(EmployeeShiftMaster item);
        IBaseEntityCollectionResponse<EmployeeShiftMaster> GetBySearch(EmployeeShiftMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeShiftMaster> GetBySearchList(EmployeeShiftMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeShiftMaster> SelectByEmployeeShiftMasterID(EmployeeShiftMaster item);
        IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySearch(EmployeeShiftMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMasterDetails(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> SelectByEmployeeShiftMasterDetailsID(EmployeeShiftMaster item);
        IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMasterDetails(EmployeeShiftMaster item);
        
    }
}
