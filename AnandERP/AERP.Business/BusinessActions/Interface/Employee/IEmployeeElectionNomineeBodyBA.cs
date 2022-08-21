using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeElectionNomineeBodyBA
    {
        IBaseEntityResponse<EmployeeElectionNomineeBody> InsertEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item);
        IBaseEntityResponse<EmployeeElectionNomineeBody> UpdateEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item);
        IBaseEntityResponse<EmployeeElectionNomineeBody> DeleteEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item);
        IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> GetBySearch(EmployeeElectionNomineeBodySearchRequest searchRequest);
        IBaseEntityResponse<EmployeeElectionNomineeBody> SelectByID(EmployeeElectionNomineeBody item);
    }
}
