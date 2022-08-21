using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IOrganisationStandardMasterBA
    {

        IBaseEntityResponse<OrganisationStandardMaster> InsertOrganisationStandardMaster(OrganisationStandardMaster item);

        IBaseEntityResponse<OrganisationStandardMaster> UpdateOrganisationStandardMaster(OrganisationStandardMaster item);

        IBaseEntityResponse<OrganisationStandardMaster> DeleteOrganisationStandardMaster(OrganisationStandardMaster item);

        IBaseEntityCollectionResponse<OrganisationStandardMaster> GetBySearch(OrganisationStandardMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationStandardMaster> SelectByID(OrganisationStandardMaster item);

        IBaseEntityCollectionResponse<OrganisationStandardMaster> GetBySearchList(OrganisationStandardMasterSearchRequest searchRequest);
    }
}
