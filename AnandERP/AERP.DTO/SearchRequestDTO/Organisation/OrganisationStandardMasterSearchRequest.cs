﻿using System;
using AMS.Base.DTO;

namespace AMS.DTO
{
   public class OrganisationStandardMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }


        public string sortBy
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}