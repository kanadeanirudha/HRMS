using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeExperienceDataProvider
    {
        IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item);
        IBaseEntityCollectionResponse<EmployeeExperience> GetEmployeeExperienceBySearch(EmployeeExperienceSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeExperience> GetEmployeeExperienceByID(EmployeeExperience item);
    }
}
