using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationSubjectMasterViewModel
    {

        OrganisationSubjectMaster OrganisationSubjectMasterDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        string SubjectCode
        {
            get;
            set;
        }
        string Descriptions
        {
            get;
            set;
        }
        string SubjectIntroYear
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        int UniversityID
        {
            get;
            set;
        }
        int LanguageID
        {
            get;
            set;
        }
        string PaperCode
        {
            get;
            set;
        }
        bool IsDeleted
        {
            get;
            set;
        }
        int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
        DateTime? ModifiedDate
        {
            get;
            set;
        }
        int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
    }
    interface IOrganisationSubjectMasterBaseViewModel
    {
        List<OrganisationSubjectMaster> ListOrganisationSubjectMaster
        {
            get;
            set;
        }
    }
}
