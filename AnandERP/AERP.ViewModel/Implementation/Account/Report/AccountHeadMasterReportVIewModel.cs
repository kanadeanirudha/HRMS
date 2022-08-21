using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
    public class AccountHeadMasterReportViewModel: IAccountHeadMasterReportViewModel
    {
        public AccountHeadMasterReportViewModel()
        {
            AccountHeadMasterReportDTO = new AccountHeadMasterReport();
            ListAccountHeadMasterReport = new List<AccountHeadMasterReport>();
        }

        public AccountHeadMasterReport AccountHeadMasterReportDTO { get; set; }

        public List<AccountHeadMasterReport> ListAccountHeadMasterReport { get; set; }

        public byte ID
        {
            get
            {
                return (AccountHeadMasterReportDTO != null && AccountHeadMasterReportDTO.ID > 0) ? AccountHeadMasterReportDTO.ID : new byte();
            }
            set
            {
                AccountHeadMasterReportDTO.ID = value;
            }
        }


        public string HeadCode
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.HeadCode : string.Empty;
            }
            set
            {
                AccountHeadMasterReportDTO.HeadCode = value;
            }
        }
        public string HeadName
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.HeadName : string.Empty;
            }
            set
            {
                AccountHeadMasterReportDTO.HeadName = value;
            }
        }

        public Nullable<int> PrintingSequence
        {
            get
            {
                return (AccountHeadMasterReportDTO != null && AccountHeadMasterReportDTO.PrintingSequence > 0) ? AccountHeadMasterReportDTO.PrintingSequence : new int();
            }
            set
            {
                AccountHeadMasterReportDTO.PrintingSequence = value;
            }
        }

        public Nullable<bool> IsActive
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.IsActive : false;
            }
            set
            {
                AccountHeadMasterReportDTO.IsActive = value;
            }
        }

        public int AccBalsheetMstID
        {
            get
            {
                return (AccountHeadMasterReportDTO != null ) ? AccountHeadMasterReportDTO.AccBalsheetMstID : new int();
            }
            set
            {
                AccountHeadMasterReportDTO.AccBalsheetMstID = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (AccountHeadMasterReportDTO != null && AccountHeadMasterReportDTO.CreatedBy > 0) ? AccountHeadMasterReportDTO.CreatedBy : new int();
            }
            set
            {
                AccountHeadMasterReportDTO.CreatedBy = value;
            }
        }


        public Nullable<System.DateTime> CreatedDate
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.CreatedDate : null;
            }
            set
            {
                AccountHeadMasterReportDTO.CreatedDate = value;
            }
        }


        public Nullable<int> ModifiedBy
        {
            get
            {
                return (AccountHeadMasterReportDTO != null && AccountHeadMasterReportDTO.ModifiedBy > 0) ? AccountHeadMasterReportDTO.ModifiedBy : new int();
            }
            set
            {
                AccountHeadMasterReportDTO.ModifiedBy = value;
            }
        }


        public Nullable<System.DateTime> ModifiedDate
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.ModifiedDate : null;
            }
            set
            {
                AccountHeadMasterReportDTO.ModifiedDate = value;
            }
        }

        public Nullable<int> DeletedBy
        {
            get
            {
                return (AccountHeadMasterReportDTO != null && AccountHeadMasterReportDTO.DeletedBy > 0) ? AccountHeadMasterReportDTO.DeletedBy : new int();
            }
            set
            {
                AccountHeadMasterReportDTO.DeletedBy = value;
            }
        }


        public Nullable<System.DateTime> DeletedDate
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.DeletedDate : null;
            }
            set
            {
                AccountHeadMasterReportDTO.DeletedDate = value;
            }
        }

        public Nullable<bool> IsDeleted
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.IsDeleted : false;
            }
            set
            {
                AccountHeadMasterReportDTO.IsDeleted = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (AccountHeadMasterReportDTO != null) ? AccountHeadMasterReportDTO.IsPosted : false;
            }
            set
            {
                AccountHeadMasterReportDTO.IsPosted = value;
            }
        }
    }
}
