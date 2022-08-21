using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IEmployeeExperienceBA
    {
        IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item);
        IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item);
        IBaseEntityCollectionResponse<EmployeeExperience> GetBySearch(EmployeeExperienceSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeExperience> SelectByID(EmployeeExperience item);
    }
}
