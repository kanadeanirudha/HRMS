using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IOrganisationStudyCentrePrintingFormatBR
    {
        IValidateBusinessRuleResponse InsertOrganisationStudyCentrePrintingFormatValidate(OrganisationStudyCentrePrintingFormat item);
        IValidateBusinessRuleResponse UpdateOrganisationStudyCentrePrintingFormatValidate(OrganisationStudyCentrePrintingFormat item);
        IValidateBusinessRuleResponse DeleteOrganisationStudyCentrePrintingFormatValidate(OrganisationStudyCentrePrintingFormat item);
    }
}
