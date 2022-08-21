using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeDependents : BaseDTO
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
        public int SequenceNumber
        {
            get;
            set;
        }
        public string NameTitle
        {
            get;
            set;
        }
        public string DependentName
        {
            get;
            set;
        }

        public string GenderCode
        {
            get;
            set;
        }

        public string RelationshipType
        {
            get;
            set;
        }
        public string Address1
        {
            get;
            set;
        }
        public string Address2
        {
            get;
            set;
        }

        public int CountryID
        {
            get;
            set;
        }

        public int RegionID
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string EmployeeDependentQualification
        {
            get;
            set;
        }
        public string EmployeeDependentDesignation
        {
            get;
            set;
        }
        public bool GotAnyMedal
        {
            get;
            set;
        }
        public string MedalReceivedDate
        {
            get;
            set;
        }
        public string MedalDescription
        {
            get;
            set;
        }
        public bool IsScholarshipReceived
        {
            get;
            set;
        }
        public decimal ScholarshipAmount
        {
            get;
            set;
        }
        public string ScholarshipStartDate
        {
            get;
            set;
        }
        public string ScholarshipUptoDate
        {
            get;
            set;
        }
        public string ScholarshipDescription
        {
            get;
            set;
        }
        public string Hobbies
        {
            get;
            set;
        }
        public string CurriculumActivity
        {
            get;
            set;
        }
        public string DateOfBirth
        {
            get;
            set;
        }
        public string PlaceOfBirth
        {
            get;
            set;
        }
        public int GeneralRelationshipTypeMasterID
        {
            get;
            set;
        }
        public int MotherTongueID
        {
            get;
            set;
        }
        public string LanguageKnown
        {
            get;
            set;
        }
        public int NationalityID
        {
            get;
            set;
        }
        public int ReligionID
        {
            get;
            set;
        }
        public int CasteID
        {
            get;
            set;
        }
        public int SubCasteID
        {
            get;
            set;
        }
        public int CategoryID
        {
            get;
            set;
        }
        public string WeddingAnniversaryDate
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
        public bool IsNominee
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string AdharCardNumber { get; set; }
    }
}
