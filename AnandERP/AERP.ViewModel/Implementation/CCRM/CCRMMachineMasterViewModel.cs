using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;
using AERP.Base.DTO;


namespace AERP.ViewModel
{
  public  class CCRMMachineMasterViewModel :ICCRMMachineMasterViewModel
    {
        public CCRMMachineMasterViewModel()
        {
            CCRMMachineMasterDTO = new CCRMMachineMaster();
        }
        public CCRMMachineMaster CCRMMachineMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.ID > 0) ? CCRMMachineMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMMachineMasterDTO.ID = value;
            }
        }
        [Display(Name = "Machine Name")]
        public Int32 ItemNumber
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.ItemNumber > 0) ? CCRMMachineMasterDTO.ItemNumber : new Int32();
            }
            set
            {
                CCRMMachineMasterDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Machine Family")]
        public Int32 MachineFamilyMasterID
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.MachineFamilyMasterID > 0) ? CCRMMachineMasterDTO.MachineFamilyMasterID : new Int32();
            }
            set
            {
                CCRMMachineMasterDTO.MachineFamilyMasterID = value;
            }
        }
        [Display(Name = "Machine Type")]
    
        public byte MachineType
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.MachineType : new byte();
            }
            set
            {
                CCRMMachineMasterDTO.MachineType = value;
            }
        }
        [Display(Name = "Color Mono")]
        public byte ColorMono
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.ColorMono : new byte();
            }
            set
            {
                CCRMMachineMasterDTO.ColorMono = value;
            }
        }
        [Display(Name = "Paper Size")]
        public string PaperSize
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.PaperSize : string.Empty;
            }
            set
            {
                CCRMMachineMasterDTO.PaperSize = value;
            }
        }
       
        public byte Warrenty
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.Warrenty : new byte();
            }
            set
            {
                CCRMMachineMasterDTO.Warrenty = value;
            }
        }
        [Display(Name = "Life In Years")]
        public decimal LifeInYears
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.LifeInYears : new decimal();
            }
            set
            {
                CCRMMachineMasterDTO.LifeInYears = value;
            }
        }
        [Display(Name = "life In Copies")]
        public string lifeInCopies
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.lifeInCopies : string.Empty;
            }
            set
            {
                CCRMMachineMasterDTO.lifeInCopies = value;
            }
        }
        [Display(Name = "PM Periods")]
        public string PMPeriods
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.PMPeriods : string.Empty;
            }
            set
            {
                CCRMMachineMasterDTO.PMPeriods = value;
            }
        }
        [Display(Name = "Is Returnable")]
        public bool Isreturnable
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.Isreturnable : new bool();
            }
            set
            {
                CCRMMachineMasterDTO.Isreturnable = value;
            }
        }
        public byte Frequency
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.Frequency : new byte();
            }
            set
            {
                CCRMMachineMasterDTO.Frequency = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.CreatedBy > 0) ? CCRMMachineMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMMachineMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMMachineMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMMachineMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.ModifiedBy.HasValue) ? CCRMMachineMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMMachineMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.ModifiedDate.HasValue) ? CCRMMachineMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMMachineMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.DeletedBy.HasValue) ? CCRMMachineMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMMachineMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMMachineMasterDTO != null && CCRMMachineMasterDTO.DeletedDate.HasValue) ? CCRMMachineMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMMachineMasterDTO.DeletedDate = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMMachineMasterDTO.ItemDescription = value;
            }
        }
        public string MachineFamilyName
        {
            get
            {
                return (CCRMMachineMasterDTO != null) ? CCRMMachineMasterDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMMachineMasterDTO.MachineFamilyName = value;
            }
        }
    }
}
