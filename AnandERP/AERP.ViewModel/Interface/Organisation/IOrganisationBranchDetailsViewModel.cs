using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationBranchDetailsViewModel
    {

        OrganisationBranchDetails OrganisationBranchDetailsDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int BranchID
        {
            get;
            set;
        }

        string CentreCode
        {
            get;
            set;
        }

        int PresentIntake
        {
            get;
            set;
        }

        int IntroductionYear
        {
            get;
            set;
        }

        int StreamID
        {
            get;
            set;
        }

        string DteCode
        {
            get;
            set;
        }

        int BranchPrintingSequence
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
    public interface IOrganisationBranchDetailsBaseViewModel
    {

      
    }
}
