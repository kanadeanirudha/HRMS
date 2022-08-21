using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationStudyCentrePrintingFormat : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string CentrePrintingLine
        {
            get;
            set;
        }

        public string PrintingLine1
        {
            get;
            set;
        }
        public string PrintingLine2
        {
            get;
            set;
        }
        public string PrintingLine3
        {
            get;
            set;
        }
        public string PrintingLine4
        {
            get;
            set;
        }
        public byte[] Logo
        {
            get;
            set;
        }

        public string LogoType
        {
            get;
            set;
        }
        public string LogoFilename
        {
            get;

            set;

        }

        public string LogoFileWidth
        {
            get;

            set;
        }


        public string LogoFileHeight
        {
            get;
            set;
        }


        public string LogoFileSize
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

        public bool StatusFlag
        {
            get;
            set;
        }

        public string ErrorMessage { get; set; }

    }
}
