using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeServiceDetailsViewModel
    {
        public EmployeeServiceDetailsViewModel()
        {
            EmployeeServiceDetailsDTO = new EmployeeServiceDetails();
        }

        public EmployeeServiceDetails EmployeeServiceDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.ID > 0) ? EmployeeServiceDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.ID = value;
            }
        }

        public int CurrentID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.CurrentID > 0) ? EmployeeServiceDetailsDTO.CurrentID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.CurrentID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.EmployeeID > 0) ? EmployeeServiceDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.EmployeeName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeName = value;
            }
        }

        [Display(Name = "Employee Code")]
        public string EmployeeCode
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeCode = value;
            }
        }

        public int SequenceNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.SequenceNumber > 0) ? EmployeeServiceDetailsDTO.SequenceNumber : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.SequenceNumber = value;
            }
        }

        [Display(Name = "Order Number")]
        [Required(ErrorMessage ="Order Number Required")]
        public string OrderNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OrderNumber : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OrderNumber = value;
            }
        }


        [Display(Name = "Order Date")]
        [Required(ErrorMessage ="Order Date Required")]
        public string OrderDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OrderDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OrderDate = value;
            }
        }

        [Display(Name = "Accepted By Employee")]
        public string AcceptedByEmployee
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.AcceptedByEmployee : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.AcceptedByEmployee = value;
            }
        }

        [Display(Name = "Promotion/Demotion Flag")]
        public string PromotionDemotionFlag
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.PromotionDemotionFlag : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.PromotionDemotionFlag = value;
            }
        }

        [Display(Name = "Promotion/Demotion Date")]
        [Required(ErrorMessage ="Promotion/Demotion Date Required")]
        public string PromotionDemotionDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.PromotionDemotionDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.PromotionDemotionDate = value;
            }
        }

        [Display(Name = "Previous Promotion/Demotion Date")]
        public string PreviousPromotionDemotionDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.PreviousPromotionDemotionDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.PreviousPromotionDemotionDate = value;
            }
        }

        [Display(Name = "Employee Designation")]
        [Required(ErrorMessage ="Employee Designation Required")]
        public int EmployeeDesignationMasterID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.EmployeeDesignationMasterID > 0) ? EmployeeServiceDetailsDTO.EmployeeDesignationMasterID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeDesignationMasterID = value;
            }
        }

        public string EmployeeDesignation
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.EmployeeDesignation : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.EmployeeDesignation = value;
            }
        }

        [Display(Name = "Department")]
        [Required(ErrorMessage ="Department Required")]
        public int DepartmentID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.DepartmentID > 0) ? EmployeeServiceDetailsDTO.DepartmentID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.DepartmentID = value;
            }
        }
        public string DepartmentName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.DepartmentName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.DepartmentName = value;
            }
        }

        [Display(Name = "Charge Taking Date")]
        public string ChargeTakingDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.ChargeTakingDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.ChargeTakingDate = value;
            }
        }

        [Display(Name = "Old Designation")]
        public int OldDesignationID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.OldDesignationID > 0) ? EmployeeServiceDetailsDTO.OldDesignationID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.OldDesignationID = value;
            }
        }

        public int OldDepartmentID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.OldDepartmentID > 0) ? EmployeeServiceDetailsDTO.OldDepartmentID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.OldDepartmentID = value;
            }
        }

        [Display(Name = "Old Department Name")]
        public string OldDepartmentName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OldDepartmentName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OldDepartmentName = value;
            }
        }

        [Display(Name = "Approval Date")]
        public string CollegeApprovalDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CollegeApprovalDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CollegeApprovalDate = value;
            }
        }

        [Display(Name = "University Approval Date")]
        public string UniversityApprovalDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.UniversityApprovalDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.UniversityApprovalDate = value;
            }
        }

        [Display(Name = "College Approval Number")]
        public string CollegeApprovalNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CollegeApprovalNumber : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CollegeApprovalNumber = value;
            }
        }

        [Display(Name = "University Approval Number")]
        public string UniversityApprovalNumber
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.UniversityApprovalNumber : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.UniversityApprovalNumber = value;
            }
        }

        [Display(Name = "Nature Of Duty")]
        public string NatureOfDuty
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.NatureOfDuty : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.NatureOfDuty = value;
            }
        }

        [Display(Name = "Basic Amount")]
        public decimal BasicAmount
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.BasicAmount > 0) ? EmployeeServiceDetailsDTO.BasicAmount : new decimal();
            }
            set
            {
                EmployeeServiceDetailsDTO.BasicAmount = value;
            }
        }
        
        public string ApprovedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.ApprovedBy : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.ApprovedBy = value;
            }
        }

        [Display(Name = "New Grade")]
        //  [Display(Name = "NewGrade")]
        public decimal NewGrade
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.NewGrade > 0) ? EmployeeServiceDetailsDTO.NewGrade : new decimal();
            }
            set
            {
                EmployeeServiceDetailsDTO.NewGrade = value;
            }
        }

        [Display(Name = "New Pay Scale")]
        public int NewPayscaleID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.NewPayscaleID > 0) ? EmployeeServiceDetailsDTO.NewPayscaleID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.NewPayscaleID = value;
            }
        }

        [Display(Name = "Nature Of Appointment")]
        public string NatureOfAppointment
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.NatureOfAppointment : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.NatureOfAppointment = value;
            }
        }
        
        public string UniversityApprovalType
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.UniversityApprovalType : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.UniversityApprovalType = value;
            }
        }

        [Display(Name = "Board/University")]
        [Required(ErrorMessage ="Board/University")]
        public int GeneralBoardUniversityID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.GeneralBoardUniversityID > 0) ? EmployeeServiceDetailsDTO.GeneralBoardUniversityID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.GeneralBoardUniversityID = value;
            }
        }

        [Display(Name = "Subject For Approval")]
        public string SubjectForApproval
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.SubjectForApproval : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.SubjectForApproval = value;
            }
        }

        [Display(Name = "Granted Promotion Date")]
        public string GrantedPromotionDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.GrantedPromotionDate : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.GrantedPromotionDate = value;
            }
        }

        [Display(Name = "Granted Promotion Designation")]
        [Required(ErrorMessage ="Granted Promotion Designation Required")]
        public int GrantedPromotionDesignationID
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.GrantedPromotionDesignationID > 0) ? EmployeeServiceDetailsDTO.GrantedPromotionDesignationID : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.GrantedPromotionDesignationID = value;
            }
        }

        [Display(Name = "Granted Promotion Level")]
        public string GrantedPromotionLevel
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.GrantedPromotionLevel : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.GrantedPromotionLevel = value;
            }
        }

        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeServiceDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeServiceDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.CreatedBy > 0) ? EmployeeServiceDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeServiceDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.ModifiedBy.HasValue) ? EmployeeServiceDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.ModifiedDate.HasValue) ? EmployeeServiceDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeServiceDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.DeletedBy.HasValue) ? EmployeeServiceDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeServiceDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null && EmployeeServiceDetailsDTO.DeletedDate.HasValue) ? EmployeeServiceDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeServiceDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "Centre")]
        [Required(ErrorMessage ="Centre Required")]
        public string CentreCode
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CentreCode = value;
            }
        }

        [Display(Name = "Old Centre Flag")]
        public string OldCentreCode
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.OldCentreCode : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.OldCentreCode = value;
            }
        }
        [Display(Name = "Is Current Flag")]
        public bool IsCurrentFlag
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.IsCurrentFlag : false;
            }
            set
            {
                EmployeeServiceDetailsDTO.IsCurrentFlag = value;
            }
        }

        [Display(Name = "Centre")]
        public string CentreName
        {
            get
            {
                return (EmployeeServiceDetailsDTO != null) ? EmployeeServiceDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                EmployeeServiceDetailsDTO.CentreName = value;
            }
        }
    }
}
