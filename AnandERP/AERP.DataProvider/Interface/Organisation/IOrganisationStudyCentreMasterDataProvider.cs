using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IOrganisationStudyCentreMasterDataProvider
    {
        IBaseEntityResponse<OrganisationStudyCentreMaster> InsertOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item);
        IBaseEntityResponse<OrganisationStudyCentreMaster> UpdateOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item);
        IBaseEntityResponse<OrganisationStudyCentreMaster> DeleteOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreListBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterGetListHORO(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreListRoleWise(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterByID(OrganisationStudyCentreMaster item);
        IBaseEntityResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreMasterHOROCount(OrganisationStudyCentreMaster item);
    }
}
