using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSubjectGrpRuleBA
    {
        IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item);
        IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item);
        IBaseEntityResponse<OrganisationSubjectGrpRule> DeleteOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetForOrgSubGrpRuleSessionwise(OrganisationSubjectGrpRuleSearchRequest searchRequest); 
        IBaseEntityResponse<OrganisationSubjectGrpRule> SelectByID(OrganisationSubjectGrpRule item);

        //Interface methods for table OrgElectiveGrpMaster
        IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgElectiveGrpMaster(OrganisationSubjectGrpRule item);
        IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgElectiveGrpMaster(OrganisationSubjectGrpRule item);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgElectiveGrpMasterByID(OrganisationSubjectGrpRule item);

        //Interface methods for table OrgSub    ElectiveGrpMaster
        IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item);
        IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubjectGroupRuleSearchList(OrganisationSubjectGrpRuleSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgSubElectiveGrpMasterByID(OrganisationSubjectGrpRule item);

    }
}
