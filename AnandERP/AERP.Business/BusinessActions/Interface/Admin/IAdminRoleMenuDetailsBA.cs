using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAdminRoleMenuDetailsBA
    {
        IBaseEntityResponse<AdminRoleMenuDetails> InsertAdminRoleMenuDetails(AdminRoleMenuDetails item);

        IBaseEntityResponse<AdminRoleMenuDetails> UpdateAdminRoleMenuDetails(AdminRoleMenuDetails item);

        IBaseEntityResponse<AdminRoleMenuDetails> DeleteAdminRoleMenuDetails(AdminRoleMenuDetails item);

        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearch(AdminRoleMenuDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleMenuDetails> SelectByID(AdminRoleMenuDetails item);

        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchModuleList(AdminRoleMenuDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchAdminMenuList(AdminRoleMenuDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleMenuDetails> CheckMenuApplicableOrNotByAdminRoleID(AdminRoleMenuDetails item); 
    }
}
