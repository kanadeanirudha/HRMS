using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAdminSnPostsDataProvider
    {
        IBaseEntityCollectionResponse<AdminSnPosts> GetAdminSnPostsBySearch(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminSnPosts> GetAdminSnPostsBySearchCentreCodeAndDepartmentID(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminSnPosts> GetAdminSnPostsBySearchCentreCodeAndDepartmentIDForSPD(AdminSnPostsSearchRequest searchRequest);

        IBaseEntityResponse<AdminSnPosts> GetAdminSnPostsByID(AdminSnPosts item);//int id

        IBaseEntityResponse<AdminSnPosts> InsertAdminSnPosts(AdminSnPosts item);

        IBaseEntityResponse<AdminSnPosts> UpdateAdminSnPosts(AdminSnPosts item);

        IBaseEntityResponse<AdminSnPosts> DeleteAdminSnPosts(AdminSnPosts item);
    }
}
