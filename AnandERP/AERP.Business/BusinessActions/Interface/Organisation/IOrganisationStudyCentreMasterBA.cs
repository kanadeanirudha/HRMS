using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IOrganisationStudyCentreMasterBA
    {
        IBaseEntityResponse<OrganisationStudyCentreMaster> InsertOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item);
        IBaseEntityResponse<OrganisationStudyCentreMaster> UpdateOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item);
        IBaseEntityResponse<OrganisationStudyCentreMaster> DeleteOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetListHORO(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreList(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreListRoleWise(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(OrganisationStudyCentreMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationStudyCentreMaster> SelectByID(OrganisationStudyCentreMaster item);
        IBaseEntityResponse<OrganisationStudyCentreMaster> SelectHOROCount(OrganisationStudyCentreMaster item);
    }
}
