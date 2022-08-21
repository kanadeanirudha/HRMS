using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeShiftApplicableMasterDataProvider
    {
        IBaseEntityResponse<EmployeeShiftApplicableMaster> InsertEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item);
        IBaseEntityResponse<EmployeeShiftApplicableMaster> UpdateEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item);
        IBaseEntityResponse<EmployeeShiftApplicableMaster> DeleteEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item);
        IBaseEntityCollectionResponse<EmployeeShiftApplicableMaster> GetEmployeeShiftApplicableMasterBySearch(EmployeeShiftApplicableMasterSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeShiftApplicableMaster> GetEmployeeShiftApplicableMasterByID(EmployeeShiftApplicableMaster item);
    }
}
