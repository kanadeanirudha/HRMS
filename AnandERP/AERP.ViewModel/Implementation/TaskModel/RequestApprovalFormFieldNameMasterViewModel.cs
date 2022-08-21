using System;
using System.Collections.Generic;
using System.Linq;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class RequestApprovalFormFieldNameMasterViewModel : IRequestApprovalFormFieldNameMasterViewModel
    {

        public RequestApprovalFormFieldNameMasterViewModel()
        {
            RequestApprovalFormFieldNameMasterDTO = new RequestApprovalFormFieldNameMaster();
            RequestCodeList = new List<GeneralRequestMaster>();
           
        }

        public List<GeneralRequestMaster> RequestCodeList { get; set; }
        public IEnumerable<SelectListItem> RequestCodeListItems { get { return new SelectList(RequestCodeList, "RequestCode", "RequestName"); } }
      
        public RequestApprovalFormFieldNameMaster RequestApprovalFormFieldNameMasterDTO
        {
            get;
            set;
        }

        public Int32 RequestApprovalFormFieldNameMasterID
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null && RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldNameMasterID > 0) ? RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldNameMasterID : new Int32();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldNameMasterID = value;
            }
        }

        [Required(ErrorMessage = "Form Name should not be blank.")]
        [Display(Name = "Form Name")]
        public string FormName
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.FormName : string.Empty;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.FormName = value;
            }
        }

        [Required(ErrorMessage = "Request Code should not be blank.")]
        [Display(Name = "Request Code")]
        public string RequestCode
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.RequestCode : string.Empty;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.RequestCode = value;
            }
        }
       
        [Required(ErrorMessage = "View Name should not be blank.")]
        [Display(Name = "View Name")]
        public string ViewName
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.ViewName : string.Empty;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.ViewName = value;
            }
        }
        [Required(ErrorMessage = "Insert Update Procedure should not be blank.")]
        [Display(Name = "Insert Update Procedure")]
        public string InsertUpdateProcedure
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.InsertUpdateProcedure : string.Empty;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.InsertUpdateProcedure = value;
            }
        }
        //Fields From RequestApprovalFormFieldNameMasterDetails

        public Int32 RequestApprovalFormFieldNameDetailsID
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldNameDetailsID : new Int32();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldNameDetailsID = value;
            }
        }

        public Int32 RequestApprovalFormFieldMasterId
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldMasterId : new Int32();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.RequestApprovalFormFieldMasterId = value;
            }
        }


        [Required(ErrorMessage = "LableName should not be blank.")]
        [Display(Name = "LableName")]
        public string LableName
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.LableName : string.Empty;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.LableName = value;
            }
        }
        [Required(ErrorMessage = "SequenceNumber should not be blank.")]
        [Display(Name = "SequenceNumber")]
        public byte SequenceNumber
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.SequenceNumber : new byte();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.SequenceNumber = value;
            }
        }
        [Required(ErrorMessage = "ColumnNumber should not be blank.")]
        [Display(Name = "ColumnNumber")]
        public byte ColumnNumber
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.ColumnNumber : new byte();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.ColumnNumber = value;
            }
        }
        [Required(ErrorMessage = "FieldName should not be blank.")]
        [Display(Name = "FieldName")]
        public String FieldName
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.FieldName : String.Empty;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.FieldName = value;
            }
        }
        public String XMLString
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.XMLString : String.Empty; 
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.XMLString = value; 
            }
        }
        
         [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null && RequestApprovalFormFieldNameMasterDTO.CreatedBy > 0) ? RequestApprovalFormFieldNameMasterDTO.CreatedBy : new int();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.ModifiedBy : new int();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.DeletedBy : new int();
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (RequestApprovalFormFieldNameMasterDTO != null) ? RequestApprovalFormFieldNameMasterDTO.IsDeleted : false;
            }
            set
            {
                RequestApprovalFormFieldNameMasterDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }

       }
}


