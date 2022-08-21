using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeeOtherCollegeSpecialLectureDetailsDataProvider
    {
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> InsertEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> UpdateEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> GetEmployeeOtherCollegeSpecialLectureDetailsBySearch(EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> GetEmployeeOtherCollegeSpecialLectureDetailsByID(EmployeeOtherCollegeSpecialLectureDetails item);
    }
}
