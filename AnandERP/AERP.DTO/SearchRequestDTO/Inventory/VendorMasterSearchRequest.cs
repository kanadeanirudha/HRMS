﻿using AERP.Base.DTO;

namespace AERP.DTO
{
    public class VendorMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        //public string MovementType { get; set; }
        //public string MovementCode { get; set; }
        //public bool IsActive { get; set; }

        public bool IsDeleted
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

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
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
    }
}
