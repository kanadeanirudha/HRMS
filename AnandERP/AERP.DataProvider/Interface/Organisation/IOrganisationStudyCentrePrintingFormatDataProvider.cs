using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IOrganisationanizationStudyCentrePrintingFormatDataProvider
    {
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> InsertOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item);
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> UpdateOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item);
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> DeleteOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item);
        IBaseEntityCollectionResponse<OrganisationStudyCentrePrintingFormat> GetOrganisationStudyCentrePrintingFormatBySearch(OrganisationStudyCentrePrintingFormatSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> GetOrganisationStudyCentrePrintingFormatByID(OrganisationStudyCentrePrintingFormat item);
    }
}
