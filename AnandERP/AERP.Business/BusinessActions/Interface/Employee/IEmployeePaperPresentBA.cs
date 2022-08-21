using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IEmployeePaperPresentBA
    {
        IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresent(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresent(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresent(EmployeePaperPresent item);
        IBaseEntityCollectionResponse<EmployeePaperPresent> GetBySearch(EmployeePaperPresentSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePaperPresent> SelectByID(EmployeePaperPresent item);
        IBaseEntityCollectionResponse<EmployeePaperPresent> GetAppliedDetails(EmployeePaperPresentSearchRequest searchRequest);

        IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresenter(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresenter(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresenter(EmployeePaperPresent item);
        IBaseEntityCollectionResponse<EmployeePaperPresent> GetBySearchEmployeePaperPresenter(EmployeePaperPresentSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePaperPresent> SelectByIDEmployeePaperPresenter(EmployeePaperPresent item);

    }
}
