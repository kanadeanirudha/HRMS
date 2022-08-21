using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeDocumentRequiredDataProvider
    {
        IBaseEntityResponse<EmployeeDocumentRequired> InsertEmployeeDocumentRequired(EmployeeDocumentRequired item);
        IBaseEntityResponse<EmployeeDocumentRequired> UpdateEmployeeDocumentRequired(EmployeeDocumentRequired item);
        IBaseEntityResponse<EmployeeDocumentRequired> DeleteEmployeeDocumentRequired(EmployeeDocumentRequired item);
        IBaseEntityCollectionResponse<EmployeeDocumentRequired> GetEmployeeDocumentRequiredBySearch(EmployeeDocumentRequiredSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeDocumentRequired> GetEmployeeDocumentRequiredByID(EmployeeDocumentRequired item);
        IBaseEntityCollectionResponse<EmployeeDocumentRequired> SelectByLeaveRuleMasterID(EmployeeDocumentRequiredSearchRequest searchRequest);
        
    }
}
