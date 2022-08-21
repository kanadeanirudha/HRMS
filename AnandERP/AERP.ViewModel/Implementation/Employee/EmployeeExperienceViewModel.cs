using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeExperienceViewModel
    {
        public EmployeeExperienceViewModel()
        {
            EmployeeExperienceDTO = new EmployeeExperience();
        }
        public EmployeeExperience EmployeeExperienceDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ID > 0) ? EmployeeExperienceDTO.ID : new int();
            }
            set
            {
                EmployeeExperienceDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.EmployeeID > 0) ? EmployeeExperienceDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeExperienceDTO.EmployeeID = value;
            }
        }

        [Display(Name = "Experience From Year")]
        [Required(ErrorMessage ="Experience From Year Required")]
        public string ExperienceFromYear
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.ExperienceFromYear : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.ExperienceFromYear = value;
            }
        }

        [Display(Name = "Experience To Year")]
        [Required(ErrorMessage ="Experience To Year Required")]
        public string ExperienceToYear
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.ExperienceToYear : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.ExperienceToYear = value;
            }
        }
        [Display(Name = "Experience In Month")]
        public Int16 ExperienceInMonth
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ExperienceInMonth > 0) ? EmployeeExperienceDTO.ExperienceInMonth : new Int16();
            }
            set
            {
                EmployeeExperienceDTO.ExperienceInMonth = value;
            }
        }

        [Display(Name = "Previous Organisation Name")]
        [Required(ErrorMessage ="Previous Organisation Name Required")]
        public string PreviousOrganisationName
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.PreviousOrganisationName : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.PreviousOrganisationName = value;
            }
        }

        [Display(Name = "Previous Organisation Address")]
        public string PreviousOrganisationAddress
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.PreviousOrganisationAddress : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.PreviousOrganisationAddress = value;
            }
        }

        [Display(Name = "Designation")]
        [Required(ErrorMessage ="Designation Required")]
        public string Designation
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.Designation : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.Designation = value;
            }
        }

        [Display(Name = "Remarks")]
        public string Remarks
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.Remarks : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.Remarks = value;
            }
        }

        [Display(Name = "Experience Type")]
        [Required(ErrorMessage ="Experience Type Required")]
        public int GeneralExperienceTypeMasterID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.GeneralExperienceTypeMasterID > 0) ? EmployeeExperienceDTO.GeneralExperienceTypeMasterID : new int();
            }
            set
            {
                EmployeeExperienceDTO.GeneralExperienceTypeMasterID = value;
            }
        }

        [Display(Name = "Experience Type")]
        public string GeneralExperienceType
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.GeneralExperienceType : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.GeneralExperienceType = value;
            }
        }

        [Display(Name = "Last Pay Drawn PayScale")]
        public string LastPayDrawnPayScale
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.LastPayDrawnPayScale : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.LastPayDrawnPayScale = value;
            }
        }

        [Display(Name = "Nature Of Appointment")]
        [Required(ErrorMessage ="Nature Of Appointment Required")]
        public string NatureOfAppointment
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.NatureOfAppointment : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.NatureOfAppointment = value;
            }
        }

        [Display(Name = "Job Status")]
        public int GeneralJobStatusID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.GeneralJobStatusID > 0) ? EmployeeExperienceDTO.GeneralJobStatusID : new int();
            }
            set
            {
                EmployeeExperienceDTO.GeneralJobStatusID = value;
            }
        }

        [Display(Name = "Job Status")]
        public string GeneralJobStatus
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.GeneralJobStatus : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.GeneralJobStatus = value;
            }
        }

        [Display(Name = "Appointment Order Number")]
        public string AppointmentOrderNumber
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.AppointmentOrderNumber : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.AppointmentOrderNumber = value;
            }
        }

        [Display(Name = "Appointment Order Date")]
        public string AppointmentOrderDate
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.AppointmentOrderDate : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.AppointmentOrderDate = value;
            }
        }

        [Display(Name = "University Approval Number")]
        public string UniversityApprovalNumber
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.UniversityApprovalNumber : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.UniversityApprovalNumber = value;
            }
        }


        [Display(Name = "University Approval Date")]
        public string UniversityApprovalDate
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.UniversityApprovalDate : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.UniversityApprovalDate = value;
            }
        }

        [Display(Name = "Board/University")]
        public int GeneralBoardUniversityID
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.GeneralBoardUniversityID > 0) ? EmployeeExperienceDTO.GeneralBoardUniversityID : new int();
            }
            set
            {
                EmployeeExperienceDTO.GeneralBoardUniversityID = value;
            }
        }

        [Display(Name = "Board/University Name")]
        public string GeneralBoardUniversityName
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.GeneralBoardUniversityName : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.GeneralBoardUniversityName = value;
            }
        }

        [Display(Name = "Subject For Approval")]
        public string SubjectForApproval
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.SubjectForApproval : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.SubjectForApproval = value;
            }
        }

        [Display(Name = "University Approval Type")]
        [Required(ErrorMessage ="University Approval Type Required")]
        public string UniversityApprovalType
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.UniversityApprovalType : string.Empty;
            }
            set
            {
                EmployeeExperienceDTO.UniversityApprovalType = value;
            }
        }

        [Display(Name = "Month Of Approval")]
        public Int16 MonthOfApproval
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.MonthOfApproval > 0) ? EmployeeExperienceDTO.MonthOfApproval : new Int16();
            }
            set
            {
                EmployeeExperienceDTO.MonthOfApproval = value;
            }
        }

        [Display(Name = "Year Of Approval")]
        public Int16 YearOfApproval
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.YearOfApproval > 0) ? EmployeeExperienceDTO.YearOfApproval : new Int16();
            }
            set
            {
                EmployeeExperienceDTO.YearOfApproval = value;
            }
        }
        [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.IsActive : false;
            }
            set
            {
                EmployeeExperienceDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.IsDeleted : false;
            }
            set
            {
                EmployeeExperienceDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.CreatedBy > 0) ? EmployeeExperienceDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeExperienceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeExperienceDTO != null) ? EmployeeExperienceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeExperienceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ModifiedBy.HasValue) ? EmployeeExperienceDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeExperienceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.ModifiedDate.HasValue) ? EmployeeExperienceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeExperienceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.DeletedBy.HasValue) ? EmployeeExperienceDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeExperienceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeExperienceDTO != null && EmployeeExperienceDTO.DeletedDate.HasValue) ? EmployeeExperienceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeExperienceDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }



        public int ExperienceID { get; set; }
    }
}
