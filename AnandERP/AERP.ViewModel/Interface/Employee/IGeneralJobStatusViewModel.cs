﻿using System;
using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{

    public interface IGeneralJobStatusViewModel
    {
        GeneralJobStatus GeneralJobStatusDTO
        {
            get;
            set;
        }

       int ID
        {
            get;
            set;
        }
       string JobStatusDescription
        {
            get;
            set;
        }
        string JobStatusCode
        {
            get;
            set;
        }
        bool IsActive
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
        string errorMessage { get; set; }
    }
}

