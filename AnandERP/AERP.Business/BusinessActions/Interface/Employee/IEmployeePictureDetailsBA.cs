using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IEmployeePictureDetailsBA
    {
        IBaseEntityResponse<EmployeePictureDetails> InsertEmployeePictureDetails(EmployeePictureDetails item);
        IBaseEntityResponse<EmployeePictureDetails> UpdateEmployeePictureDetails(EmployeePictureDetails item);
        IBaseEntityResponse<EmployeePictureDetails> DeleteEmployeePictureDetails(EmployeePictureDetails item);
        IBaseEntityCollectionResponse<EmployeePictureDetails> GetBySearch(EmployeePictureDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePictureDetails> SelectByID(EmployeePictureDetails item);
    }
}
