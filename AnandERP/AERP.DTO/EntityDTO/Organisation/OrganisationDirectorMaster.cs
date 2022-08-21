using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class OrganisationDirectorMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int OrganisationMembersMasterID
        {
            get;
            set;
        }
        public bool IsLifeTimeDirector
        {
            get;
            set;
        }
        public int DesignationID
        {
            get;
            set;
        }
        public string JoiningDate
        {
            get;
            set;
        }
        public string LeavingDate
        {
            get;
            set;
        }
        public int PrintingSeqOrder
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public bool IsCurrentDirector
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
        public int PersonID
        {
            get;
            set;
        }
        public string PersonType
        {
            get; 
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }


        //-----------------------Extra Field----------------------------//
        public string CentreName
        {
            get;
            set;
        }

        public string EntityLevel
        {
            get;
            set;
        }
        public string Designation
        {
            get;
            set;
        }
        public int UserID { get; set; }
        public int Status { get; set; }
    }
}
