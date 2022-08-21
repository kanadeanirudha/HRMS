using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationUniversityMasterBR
    {

        /// <summary>
        /// business rule interface of insert new record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertOrganisationUniversityMasterValidate(OrganisationUniversityMaster item);

        /// <summary>
        /// business rule interface of update record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateOrganisationUniversityMasterValidate(OrganisationUniversityMaster item);

        /// <summary>
        /// business rule interface of dalete record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteOrganisationUniversityMasterValidate(OrganisationUniversityMaster item);
    }
}
