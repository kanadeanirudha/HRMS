using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationElectiveGrpMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string GroupShortCode
        {
            get;
            set;
        }
        public string GroupName
        {
            get;
            set;
        }
        public int SubjectRuleGrpNumber
        {
            get;
            set;
        }
        public string GroupCompulsoryFlag
        {
            get;
            set;
        }
        public int NoOfSubGroups
        {
            get;
            set;
        }
        public int NoOfCompulsorySubGrp
        {
            get;
            set;
        }
        public int NoOfSubGrpSubjectSelect
        {
            get;
            set;
        }
        public string ElectiveCommonGroup
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
        