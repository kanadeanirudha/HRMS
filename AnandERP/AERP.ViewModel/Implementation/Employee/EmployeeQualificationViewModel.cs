using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeQualificationViewModel
    {
        public EmployeeQualificationViewModel()
        {
            EmployeeQualificationDTO = new EmployeeQualification();
        }
        public EmployeeQualification EmployeeQualificationDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.ID > 0) ? EmployeeQualificationDTO.ID : new int();
            }
            set
            {
                EmployeeQualificationDTO.ID = value;
            }
        }       

        public int EmployeeID
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.EmployeeID > 0) ? EmployeeQualificationDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeQualificationDTO.EmployeeID = value;
            }
        }

        [Display(Name = "From Year")]
        public string FromYear
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.FromYear : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.FromYear = value;
            }
        }
        [Display(Name = "Upto Year")]
        public string UptoYear
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.UptoYear : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.UptoYear = value;
            }
        }

        [Display(Name = "Year Of Passing")]
        public string YearOfPassing
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.YearOfPassing : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.YearOfPassing = value;
            }
        }

        [Display(Name = "Passing Division")]
        public string PassingDivision
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.PassingDivision : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.PassingDivision = value;
            }
        }

          [Display(Name = "No Of Attempts")]
        public byte NoOfAttempts
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.NoOfAttempts : new byte();         //review this       
            }
            set
            {
                EmployeeQualificationDTO.NoOfAttempts = value;
            }
        }

        [Display(Name = "Name Of Institution")]
        public string NameOfInstitution
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.NameOfInstitution : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.NameOfInstitution = value;
            }
        }

        [Display(Name = "Education Type")]
        public int EducationTypeID
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.EducationTypeID > 0) ? EmployeeQualificationDTO.EducationTypeID : new int();
            }
            set
            {
                EmployeeQualificationDTO.EducationTypeID = value;
            }
        }

        public int EducationID
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.EducationID > 0) ? EmployeeQualificationDTO.EducationID : new int();
            }
            set
            {
                EmployeeQualificationDTO.EducationID = value;
            }
        }


         [Display(Name = "Education Year")]
        public string EducationYear
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.EducationYear : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.EducationYear = value;
            }
        }

         [Display(Name = "Board/University")]
        public int BoardUniversityID
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.BoardUniversityID > 0) ? EmployeeQualificationDTO.BoardUniversityID : new int();
            }
            set
            {
                EmployeeQualificationDTO.BoardUniversityID = value;
            }
        }

       [Display(Name = "Aggregate Percentage")]
       [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double AggregatePercentage
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.AggregatePercentage > 0) ? EmployeeQualificationDTO.AggregatePercentage : new double();
            }
            set
            {
                EmployeeQualificationDTO.AggregatePercentage = value;
            }
        }

        [Display(Name = "Final Year Percentage")]
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double FinalYearPercentage
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.FinalYearPercentage > 0) ? EmployeeQualificationDTO.FinalYearPercentage : new double();
            }
            set
            {
                EmployeeQualificationDTO.FinalYearPercentage = value;
            }
        }

        [Display(Name = "Rank")]
        public byte Rank
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.Rank : new byte();         //review this       
            }
            set
            {
                EmployeeQualificationDTO.Rank = value;
            }
        }


        [Display(Name = "Remark")]
        public string Remark
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.Remark : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.Remark = value;
            }
        }

        [Display(Name = "Specailisation In")]
        public string SpecailisationIn
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.SpecailisationIn : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.SpecailisationIn = value;
            }
        }

        public int Period
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.Period > 0) ? EmployeeQualificationDTO.Period : new int();
            }
            set
            {
                EmployeeQualificationDTO.Period = value;
            }
        }

        public string Unit
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.Unit : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.Unit = value;
            }
        }

        public string EducationType
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.EducationType : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.EducationType = value;
            }
        }



        [Display(Name = "Education Name")]
        public string EducationName
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.EducationName : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.EducationName = value;
            }
        }

        [Display(Name = "University Name")]
        public string UniversityName
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.UniversityName : string.Empty;
            }
            set
            {
                EmployeeQualificationDTO.UniversityName = value;
            }
        }

        [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.IsActive : false;
            }
            set
            {
                EmployeeQualificationDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.IsDeleted : false;
            }
            set
            {
                EmployeeQualificationDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.CreatedBy > 0) ? EmployeeQualificationDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeQualificationDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeQualificationDTO != null) ? EmployeeQualificationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeQualificationDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.ModifiedBy.HasValue) ? EmployeeQualificationDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeQualificationDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.ModifiedDate.HasValue) ? EmployeeQualificationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeQualificationDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.DeletedBy.HasValue) ? EmployeeQualificationDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeQualificationDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeQualificationDTO != null && EmployeeQualificationDTO.DeletedDate.HasValue) ? EmployeeQualificationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeQualificationDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

         [Display(Name = "Selected Education")]
        public string SelectedEducationID { get; set; }

        public int QualificationID { get; set; }
    }
}
