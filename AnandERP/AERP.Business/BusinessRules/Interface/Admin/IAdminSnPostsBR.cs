using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAdminSnPostsBR
    {
        IValidateBusinessRuleResponse InsertAdminSnPostsValidate(AdminSnPosts item);

        IValidateBusinessRuleResponse UpdateAdminSnPostsValidate(AdminSnPosts item);

        IValidateBusinessRuleResponse DeleteAdminSnPostsValidate(AdminSnPosts item);
    }
}
