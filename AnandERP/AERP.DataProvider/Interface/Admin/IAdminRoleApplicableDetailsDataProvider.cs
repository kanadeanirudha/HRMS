using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider 
{
    public interface IAdminRoleApplicableDetailsDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRoleApplicableDetailsBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleApplicableDetails> GetAdminRoleApplicableDetailsByID(AdminRoleApplicableDetails item);

        IBaseEntityResponse<AdminRoleApplicableDetails> InsertAdminRoleApplicableDetails(AdminRoleApplicableDetails item);

        IBaseEntityResponse<AdminRoleApplicableDetails> UpdateAdminRoleApplicableDetails(AdminRoleApplicableDetails item);

        IBaseEntityResponse<AdminRoleApplicableDetails> DeleteAdminRoleApplicableDetails(AdminRoleApplicableDetails item);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRegularListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminAdditionalListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetRoleListForLoginUserIDBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForAcademicManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForFinanceManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForPurchaseManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForStoreManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForSalesManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForHRManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest);
        IBaseEntityResponse<AdminRoleApplicableDetails> SelectActiveAdminRoleCodeByEmployeeID(AdminRoleApplicableDetails item);
    }
}
