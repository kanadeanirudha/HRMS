using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeQualificationDataProvider
    {
        IBaseEntityResponse<EmployeeQualification> InsertEmployeeQualification(EmployeeQualification item);
        IBaseEntityResponse<EmployeeQualification> UpdateEmployeeQualification(EmployeeQualification item);
        IBaseEntityResponse<EmployeeQualification> DeleteEmployeeQualification(EmployeeQualification item);
        IBaseEntityCollectionResponse<EmployeeQualification> GetEmployeeQualificationBySearch(EmployeeQualificationSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeQualification> GetEmployeeQualificationByID(EmployeeQualification item);
    }
}
