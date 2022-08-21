using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeCourseSubjectTaughtBA
    {
        IBaseEntityResponse<EmployeeCourseSubjectTaught> InsertEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item);
        IBaseEntityResponse<EmployeeCourseSubjectTaught> UpdateEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item);
        IBaseEntityResponse<EmployeeCourseSubjectTaught> DeleteEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item);
        IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> GetBySearch(EmployeeCourseSubjectTaughtSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeCourseSubjectTaught> SelectByID(EmployeeCourseSubjectTaught item);
    }
}
