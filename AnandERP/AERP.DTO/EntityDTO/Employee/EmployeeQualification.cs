using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeQualification : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string FromYear
        {
            get;
            set;
        }
        public string UptoYear
        {
            get;
            set;
        }
        public string YearOfPassing
        {
            get;
            set;
        }
        public string PassingDivision
        {
            get;
            set;
        }
        public byte NoOfAttempts
        {
            get;
            set;
        }
        public string NameOfInstitution
        {
            get;
            set;
        }

        public int EducationTypeID
        {
            get;
            set;
        }
        public int EducationID
        {
            get;
            set;
        }
        public string EducationYear
        {
            get;
            set;
        }
        public int BoardUniversityID
        {
            get;
            set;
        }
        public double AggregatePercentage
        {
            get;
            set;
        }
        public double FinalYearPercentage
        {
            get;
            set;
        }
        public byte Rank
        {
            get;
            set;
        }
        public string Remark
        {
            get;
            set;
        }
        public string SpecailisationIn
        {
            get;
            set;
        }

        public int Period
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string EducationType
        {
            get;
            set;
        }

        
        public string EducationName
        {
            get;
            set;
        }

        public string UniversityName
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }       
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set; 
        }
    }
}
