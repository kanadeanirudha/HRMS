using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeeOtherCollegeSpecialLectureDetailsBA
    {
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> InsertEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> UpdateEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item);
        IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> GetBySearch(EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> SelectByID(EmployeeOtherCollegeSpecialLectureDetails item);
    }
}
