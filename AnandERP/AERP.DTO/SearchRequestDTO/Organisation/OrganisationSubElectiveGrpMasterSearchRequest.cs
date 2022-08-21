using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubElectiveGrpMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int OrganisationElectiveGrpID
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string ShortDescription
        {
            get;
            set;
        }
        public int TotalNoOfSubjects
        {
            get;
            set;
        }
        public bool SubGrpCompulsorySubjFlag
        {
            get;
            set;
        }
        public int AllowToSelect
        {
            get;
            set;
        }
        public bool SubGroupCompulsoryFlag
        {
            get;
            set;
        }
        public int TotalNoOfSubjectCompulsory
        {
            get;
            set;
        }
        public string ElectiveCommonSubGroup
        {
            get;
            set;
        }
        public bool FeeBased
        {
            get;
            set;
        }
        public int NextSubElectiveGrpID
        {
            get;
            set;
        }
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
    }
}
