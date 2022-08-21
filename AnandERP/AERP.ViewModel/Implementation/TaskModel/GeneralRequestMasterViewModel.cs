using System;
using System.Collections.Generic;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralRequestMasterViewModel : IGeneralRequestMasterViewModel
    {

        public GeneralRequestMasterViewModel()
        {
            GeneralRequestMasterDTO = new GeneralRequestMaster();
            MenuCodeList = new List<GeneralTaskModel>();

            TaskApprovalBasedTableList = new List<GeneralTaskReportingDetails>();
            //LinkMenuCodeList = new List<GeneralRequestMasterl>();
        }
        public List<GeneralTaskModel> MenuCodeList { get; set; }
        public IEnumerable<SelectListItem> MenuCodeListItems { get { return new SelectList(MenuCodeList, "MenuCode", "MenuName"); } }

        public List<GeneralTaskReportingDetails> TaskApprovalBasedTableList { get; set; }
        public IEnumerable<SelectListItem> TaskApprovalBasedTableListItems { get { return new SelectList(TaskApprovalBasedTableList, "TableName", "TableName"); } }
        
        public GeneralRequestMaster GeneralRequestMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (GeneralRequestMasterDTO != null && GeneralRequestMasterDTO.ID > 0) ? GeneralRequestMasterDTO.ID : new Int32();
            }
            set
            {
                GeneralRequestMasterDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Request Codeshould not be blank.")]
        [Display(Name = "RequestCode")]
        public string RequestCode
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.RequestCode : string.Empty;
            }
            set
            {
                GeneralRequestMasterDTO.RequestCode = value;
            }
        }

        [Required(ErrorMessage = "Request Description should not be blank.")]
        [Display(Name = "Description ")]
        public string RequestDescription
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.RequestDescription : string.Empty;
            }
            set
            {
                GeneralRequestMasterDTO.RequestDescription = value;
            }
        }
        [Required(ErrorMessage = "Menu Code should not be blank.")]
        [Display(Name = "MenuCode")]
        public string MenuCode
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.MenuCode : string.Empty;
            }
            set
            {
                GeneralRequestMasterDTO.MenuCode = value;
            }
        }
        [Required(ErrorMessage = "Request Approval Based Table should not be blank.")]
        [Display(Name = "BasedTable ")]
        public string RequestApprovalBasedTable
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.RequestApprovalBasedTable : string.Empty;
            }
            set
            {
                GeneralRequestMasterDTO.RequestApprovalBasedTable = value;
            }
        }
        [Required(ErrorMessage = "Request Approval Param PrimaryKey should not be blank.")]
        [Display(Name = "PrimaryKey ")]
        public string RequestApprovalParamPrimaryKey
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.RequestApprovalParamPrimaryKey : string.Empty;
            }
            set
            {
                GeneralRequestMasterDTO.RequestApprovalParamPrimaryKey = value;
            }
        }
        [Required(ErrorMessage = "LinkMenuCode should not be blank.")]
        [Display(Name = "LinkMenuCode ")]
        public string LinkMenuCode
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.LinkMenuCode : string.Empty;
            }
            set
            {
                GeneralRequestMasterDTO.LinkMenuCode = value;
            }
        }
         [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralRequestMasterDTO != null && GeneralRequestMasterDTO.CreatedBy > 0) ? GeneralRequestMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralRequestMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralRequestMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralRequestMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralRequestMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralRequestMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralRequestMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralRequestMasterDTO != null) ? GeneralRequestMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralRequestMasterDTO.IsDeleted = value;
            }
        }

        public string errorMessage { get; set; }

       }
}


