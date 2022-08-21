using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{

    public interface IOrganisationStudyCentrePrintingFormatViewModel
    {
        OrganisationStudyCentrePrintingFormat OrganisationStudyCentrePrintingFormatDTO
        {
            get;
            set;
        }
         int ID
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }

         string CentreName
         {
             get;
             set;
         }

         string CentrePrintingLine
        {
            get;
            set;
        }
        
         string PrintingLine1
        {
            get;
            set;
        }
         string PrintingLine2
        {
            get;
            set;
        }
         string PrintingLine3
        {
            get;
            set;
        }
         string PrintingLine4
        {
            get;
            set;
        }
         byte[] Logo
         {
             get;
             set;
         }

         string LogoType
         {
             get;
             set;
         }
         string LogoFilename
         {
             get;

             set;

         }

         string LogoFileWidth
         {
             get;

             set;
         }


         string LogoFileHeight
         {
             get;
             set;
         }


         string LogoFileSize
         {
             get;
             set;
         }



        bool StatusFlag
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
