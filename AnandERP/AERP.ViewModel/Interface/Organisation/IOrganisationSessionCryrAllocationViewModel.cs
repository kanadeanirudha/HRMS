using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationSessionCryrAllocationViewModel
    {

        OrganisationSessionCryrAllocation OrganisationSessionCryrAllocationDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int SessionID
        {
            get;
            set;
        }

        string CentreCode
        {
            get;
            set;
        }

        int SemesterMasterID
        {
            get;
            set;
        }


        string SemesterType
        {
            get;
            set;
        }
        int CourseYearSemesterID
        {
            get;
            set;
        }

        string SemesterFromDate
        {
            get;
            set;
        }


        string SemesterUptoDate
        {
            get;
            set;
        }
        bool CurrentActiveSemesterFlag
        {
            get;
            set;
        }

        int TotalExpectedWeeks
        {
            get;
            set;
        }
        string PeriodStartDate
        {
            get;
            set;
        }


        string PeriodEndDate
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
    public interface IOrganisationSessionCryrAllocationBaseViewModel
    {


    }
}
