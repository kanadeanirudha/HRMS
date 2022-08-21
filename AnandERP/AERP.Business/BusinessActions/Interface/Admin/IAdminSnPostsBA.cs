using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAdminSnPostsBA
    {
        IBaseEntityResponse<AdminSnPosts> InsertAdminSnPosts(AdminSnPosts item);

        IBaseEntityResponse<AdminSnPosts> UpdateAdminSnPosts(AdminSnPosts item);

        IBaseEntityResponse<AdminSnPosts> DeleteAdminSnPosts(AdminSnPosts item);

        IBaseEntityCollectionResponse<AdminSnPosts> GetBySearch(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentID(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentIDForSPD(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityResponse<AdminSnPosts> SelectByID(AdminSnPosts item);
    }
}
