using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IEmployeePaperPresentDataProvider
    {
        IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresent(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresent(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresent(EmployeePaperPresent item);
        IBaseEntityCollectionResponse<EmployeePaperPresent> GetEmployeePaperPresentBySearch(EmployeePaperPresentSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePaperPresent> GetEmployeePaperPresentByID(EmployeePaperPresent item);
        IBaseEntityCollectionResponse<EmployeePaperPresent> GetEmployeePaperPresentAppliedDetails(EmployeePaperPresentSearchRequest searchRequest);
        

        IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresenter(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresenter(EmployeePaperPresent item);
        IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresenter(EmployeePaperPresent item);
        IBaseEntityCollectionResponse<EmployeePaperPresent> GetEmployeePaperPresenterBySearch(EmployeePaperPresentSearchRequest searchRequest);
        IBaseEntityResponse<EmployeePaperPresent> GetEmployeePaperPresenterByID(EmployeePaperPresent item);

    }
}
