using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationSubjectGroupDetailsViewModel
    {

        OrganisationSubjectGroupDetails OrganisationSubjectGroupDetailsDTO
        {
            get;
            set;
        }
        
        int ID
        {
            get;
            set;
        }

        int SubjectID
        {
            get;
            set;
        }

        string ShortDescription
        {
            get;
            set;
        }
          string Description
        {
            get;
            set;
        }
        int OrgSemesterMstID
        {
            get;
            set;
        }

        int CourseYearDetailID
        {
            get;
            set;
        }

        int SubjectRuleGrpNumber
        {
            get;
            set;
        }
          string CompulsoryOptionalFlag
        {
            get;
            set;
        }
            string UniversityCode
        {
            get;
            set;
        }  
              string Pattern
        {
            get;
            set;
        }  
              string ElectiveGroupFlag
        {
            get;
            set;
        }  
            int OrgElectiveGrpID
        {
            get;
            set;
        }
              string ElectiveSubGroupFlag
        {
            get;
            set;
        }  
            int OrgSubElectiveGrpID	
        {
            get;
            set;
        }
              string ElectiveSubjectCompFlag
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
    public interface IOrganisationSubjectGroupDetailsBaseViewModel
    {

      
    }
}
