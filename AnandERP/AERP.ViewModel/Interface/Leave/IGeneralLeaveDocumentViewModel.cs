
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IGeneralLeaveDocumentViewModel
    {
        GeneralLeaveDocument GeneralLeaveDocumentDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        string DocumentName
        {
            get;
            set;
        }
        string DocumentType
        {
            get;
            set;
        }
        string DocumentDescription
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
