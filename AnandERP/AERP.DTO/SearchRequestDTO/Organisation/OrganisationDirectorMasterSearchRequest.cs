using AMS.Base.DTO;
using System;

namespace AMS.DTO
{
    public class OrganisationDirectorMasterSearchRequest : Request
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
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
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




        //--------------------Extra Feild-------------------//
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public string SearchWord { get; set; }
    }
}
