using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IEmployeeDocumentRequiredBA
    {
        IBaseEntityResponse<EmployeeDocumentRequired> InsertEmployeeDocumentRequired(EmployeeDocumentRequired item);
        IBaseEntityResponse<EmployeeDocumentRequired> UpdateEmployeeDocumentRequired(EmployeeDocumentRequired item);
        IBaseEntityResponse<EmployeeDocumentRequired> DeleteEmployeeDocumentRequired(EmployeeDocumentRequired item);
        IBaseEntityCollectionResponse<EmployeeDocumentRequired> GetBySearch(EmployeeDocumentRequiredSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeDocumentRequired> SelectByID(EmployeeDocumentRequired item);
        IBaseEntityCollectionResponse<EmployeeDocumentRequired> SelectByLeaveRuleMasterID(EmployeeDocumentRequiredSearchRequest searchRequest);
    }
}
