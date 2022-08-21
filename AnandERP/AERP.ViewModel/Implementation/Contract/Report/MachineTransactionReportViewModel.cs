using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class MachineTransactionReportViewModel
    {

        public MachineTransactionReportViewModel()
        {
            MachineTransactionReportDTO = new MachineTransactionReport();
            MachineTransactionReportList = new List<MachineTransactionReport>();
        }
        
       
        public List<MachineTransactionReport> MachineTransactionReportList { get; set; }
       
       
      
        public MachineTransactionReport MachineTransactionReportDTO
        {
            get;
            set;
        }
        public bool IsPosted { get; set; }
        public Int64 ID
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.ID > 0) ? MachineTransactionReportDTO.ID : new Int64();
            }
            set
            {
                MachineTransactionReportDTO.ID = value;
            }
        }
        public Int32 MachineMasterID
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.MachineMasterID > 0) ? MachineTransactionReportDTO.MachineMasterID : new int();
            }
            set
            {
                MachineTransactionReportDTO.MachineMasterID = value;
            }
        }
        [Display(Name = "Machine Name")]
        public string MachineMasterName
        {
            get
            {
                return (MachineTransactionReportDTO != null) ? MachineTransactionReportDTO.MachineMasterName : string.Empty;
            }
            set
            {
                MachineTransactionReportDTO.MachineMasterName = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (MachineTransactionReportDTO != null) ? MachineTransactionReportDTO.IsDeleted : false;
            }
            set
            {
                MachineTransactionReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.CreatedBy > 0) ? MachineTransactionReportDTO.CreatedBy : new int();
            }
            set
            {
                MachineTransactionReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (MachineTransactionReportDTO != null) ? MachineTransactionReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                MachineTransactionReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.ModifiedBy > 0) ? MachineTransactionReportDTO.ModifiedBy : new int();
            }
            set
            {
                MachineTransactionReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.ModifiedDate.HasValue) ? MachineTransactionReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                MachineTransactionReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.DeletedBy > 0) ? MachineTransactionReportDTO.DeletedBy : new int();
            }
            set
            {
                MachineTransactionReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (MachineTransactionReportDTO != null && MachineTransactionReportDTO.DeletedDate.HasValue) ? MachineTransactionReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                MachineTransactionReportDTO.DeletedDate = value;
            }
        }
       
        public string errorMessage { get; set; }
    }
}

