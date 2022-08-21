using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IAdminRoleMenuDetailsDataProvider
    {
        IBaseEntityResponse<AdminRoleMenuDetails> InsertAdminRoleMenuDetails(AdminRoleMenuDetails item);
        IBaseEntityResponse<AdminRoleMenuDetails> UpdateAdminRoleMenuDetails(AdminRoleMenuDetails item);
        IBaseEntityResponse<AdminRoleMenuDetails> DeleteAdminRoleMenuDetails(AdminRoleMenuDetails item);
        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetAdminRoleMenuDetailsBySearch(AdminRoleMenuDetailsSearchRequest searchRequest);
        IBaseEntityResponse<AdminRoleMenuDetails> GetAdminRoleMenuDetailsByID(AdminRoleMenuDetails item);
        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetAdminModuleBySearch(AdminRoleMenuDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetAdminMenuBySearch(AdminRoleMenuDetailsSearchRequest searchRequest);
        IBaseEntityResponse<AdminRoleMenuDetails> CheckMenuApplicableOrNotByAdminRoleID(AdminRoleMenuDetails item);
    }
}
