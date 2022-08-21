﻿using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IOrganisationStandardMasterViewModel
    {
        OrganisationStandardMaster OrganisationStandardMasterDTO
        {
            get;
            set;
        }

         int ID
        {
            get;
            set;
        }

         int StandardNumber
        {
            get;
            set;
        }

         string Description
        {
            get;
            set;
        }

         string CodeShortCode
        {
            get;
            set;
        }

         string PrintShortCode
        {
            get;
            set;
        }
         bool IsUserDefined { get; set; }
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
}
