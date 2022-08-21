using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeePatentReceivedDetailsBA
    {
        IBaseEntityResponse<EmployeePatentReceivedDetails> InsertEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item);
        IBaseEntityResponse<EmployeePatentReceivedDetails> UpdateEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item);
        IBaseEntityResponse<EmployeePatentReceivedDetails> DeleteEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item);
        IBaseEntityCollectionResponse<EmployeePatentReceivedDetails> GetBySearch(EmployeePatentReceivedDetailsSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePatentReceivedDetails> SelectByID(EmployeePatentReceivedDetails item);
    }
}
