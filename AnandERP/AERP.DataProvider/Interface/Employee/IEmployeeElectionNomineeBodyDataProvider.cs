using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeElectionNomineeBodyDataProvider
    {
        IBaseEntityResponse<EmployeeElectionNomineeBody> InsertEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item);
        IBaseEntityResponse<EmployeeElectionNomineeBody> UpdateEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item);
        IBaseEntityResponse<EmployeeElectionNomineeBody> DeleteEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item);
        IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> GetEmployeeElectionNomineeBodyBySearch(EmployeeElectionNomineeBodySearchRequest searchRequest);
        IBaseEntityResponse<EmployeeElectionNomineeBody> GetEmployeeElectionNomineeBodyByID(EmployeeElectionNomineeBody item);
    }
}
