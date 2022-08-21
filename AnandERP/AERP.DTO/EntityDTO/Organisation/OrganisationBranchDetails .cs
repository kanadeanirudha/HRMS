using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationBranchDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        
        public int BranchID
        {
            get;
            set;
        }
        public int BranchDetailID
        {
            get;
            set;
        } 
        public int SelectedStreamID
        {
            get;
            set;
        }

        public bool StatusFlag 
        {
            get;
            set;
        }
        
        public string BranchDescription
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int PresentIntake
        {
            get;
            set;
        }
        public int IntroductionYear
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public string DteCode
        {
            get;
            set;
        }
        public int BranchPrintingSequence
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
