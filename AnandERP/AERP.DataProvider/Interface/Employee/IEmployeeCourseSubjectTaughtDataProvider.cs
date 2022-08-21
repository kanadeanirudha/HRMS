using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeCourseSubjectTaughtDataProvider
    {
        IBaseEntityResponse<EmployeeCourseSubjectTaught> InsertEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item);
        IBaseEntityResponse<EmployeeCourseSubjectTaught> UpdateEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item);
        IBaseEntityResponse<EmployeeCourseSubjectTaught> DeleteEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item);
        IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> GetEmployeeCourseSubjectTaughtBySearch(EmployeeCourseSubjectTaughtSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeCourseSubjectTaught> GetEmployeeCourseSubjectTaughtByID(EmployeeCourseSubjectTaught item);
    }
}
