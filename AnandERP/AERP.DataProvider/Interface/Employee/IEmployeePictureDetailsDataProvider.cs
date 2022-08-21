using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeePictureDetailsDataProvider
    {
        IBaseEntityResponse<EmployeePictureDetails> InsertEmployeePictureDetails(EmployeePictureDetails item);
        IBaseEntityResponse<EmployeePictureDetails> UpdateEmployeePictureDetails(EmployeePictureDetails item);
        IBaseEntityResponse<EmployeePictureDetails> DeleteEmployeePictureDetails(EmployeePictureDetails item);
        IBaseEntityCollectionResponse<EmployeePictureDetails> GetEmployeePictureDetailsBySearch(EmployeePictureDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePictureDetails> GetEmployeePictureDetailsByID(EmployeePictureDetails item);
    }
}
