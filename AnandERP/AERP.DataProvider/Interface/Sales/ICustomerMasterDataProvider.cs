using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ICustomerMasterDataProvider
    {
        IBaseEntityResponse<CustomerMaster> InsertCustomerMaster(CustomerMaster item);
        IBaseEntityResponse<CustomerMaster> InsertCustomerMasterContactDetails(CustomerMaster item);
        IBaseEntityResponse<CustomerMaster> InsertCustomerMasterBranchDetails(CustomerMaster item);
        IBaseEntityResponse<CustomerMaster> UpdateCustomerMaster(CustomerMaster item);
        IBaseEntityResponse<CustomerMaster> DeleteCustomerMaster(CustomerMaster item);

        IBaseEntityCollectionResponse<CustomerMaster> GetCustomerMasterBySearch(CustomerMasterSearchRequest searchRequest);
        IBaseEntityResponse<CustomerMaster> GetCustomerMasterByID(CustomerMaster item);
        IBaseEntityCollectionResponse<CustomerMaster> GetCustomerMasterSearchList(CustomerMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CustomerMaster> GetCustomerBranchMasterSearchList(CustomerMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CustomerMaster> GetCustomerContactDetilsSearchList(CustomerMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CustomerMaster> GetContactDetailsByCustomerMasterID(CustomerMasterSearchRequest searchRequest);

        IBaseEntityResponse<CustomerMaster> GetCustomerMasterDetailsByCustomerMasterID(CustomerMaster item);
        IBaseEntityResponse<CustomerMaster> UpdateCustomerMasterByCustomerMasterID(CustomerMaster item);





    }
}
