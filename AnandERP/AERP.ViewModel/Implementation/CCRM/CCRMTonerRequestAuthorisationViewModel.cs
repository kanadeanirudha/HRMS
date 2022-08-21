using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;


namespace AERP.ViewModel
{
   public class CCRMTonerRequestAuthorisationViewModel:ICCRMTonerRequestAuthorisationViewModel
    {
        public CCRMTonerRequestAuthorisationViewModel()
        {
            CCRMTonerRequestAuthorisationDTO = new CCRMTonerRequestAuthorisation();
        }
        public CCRMTonerRequestAuthorisation CCRMTonerRequestAuthorisationDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null && CCRMTonerRequestAuthorisationDTO.ID > 0) ? CCRMTonerRequestAuthorisationDTO.ID : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ID = value;
            }
        }
        [Display(Name = "Serial No")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.SerialNo = value;
            }
        }
        [Display(Name = "Model No")]
        public string ModelNo
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ModelNo = value;
            }
        }
        [Display(Name = "MIF Name")]
        public string MIFName
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.MIFName = value;
            }
        }
        public Int16 MachineFamilyID
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.MachineFamilyID : new Int16();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.MachineFamilyID = value;
            }
        }
        [Display(Name = "Machine Family ")]
        public string MachineFamilyName
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.MachineFamilyName = value;
            }
        }
        [Display(Name = "Contract Code")]
        public string ContractCode
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ContractCode : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ContractCode = value;
            }
        }
        [Display(Name = "Call Date")]
        public string CallDate
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CallDate = value;
            }
        }
        [Display(Name = "Call Tkt No")]

        public string CallTktNo
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CallTktNo = value;
            }
        }
        public Int32 MIFID
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.MIFID : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.MIFID = value;
            }
        }
        public Int32 ContractID
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ContractID : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ContractID = value;
            }
        }
        [Display(Name = "Part No")]

        public string PartNO
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.PartNO : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.PartNO = value;
            }
        }
        [Display(Name = "Part Name")]

        public string PartName
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.PartName : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.PartName = value;
            }
        }
        public Int32 BalanceQuantity
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.BalanceQuantity : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.BalanceQuantity = value;
            }
        }
        public Int32 CallId
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CallId : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CallId = value;
            }
        }
        [Display(Name = "Caller Name")]

        public string CallerName
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CallerName = value;
            }
        }
        [Display(Name = "Caller Phone")]

        public string CallerPh
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CallerPh : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CallerPh = value;
            }
        }
        [Display(Name = "Part Name")]

        public string ItemName
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ItemName : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ItemName = value;
            }
        }
        public string ItemCategoryCode
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ItemCategoryCode = value;
            }
        }
        [Display(Name = "Current Mtr Read")]
        public Int32 CurrentMeterRead
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CurrentMeterRead : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CurrentMeterRead = value;
            }
        }
        [Display(Name = "Quantity")]
        public Int32 Quantity
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.Quantity : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.Quantity = value;
            }
        }
        [Display(Name = "FOC")]
        public bool FOC
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.FOC : new bool();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.FOC = value;
            }
        }
        [Display(Name = "Last Call Date")]

        public string LastCallDate
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.LastCallDate : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.LastCallDate = value;
            }
        }
        [Display(Name = "Last Call No")]
        public Int32 LastCallNo
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.LastCallNo : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.LastCallNo = value;
            }
        }
        [Display(Name = "Last Quantity")]
        public Int32 LastQuantity
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.LastQuantity : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.LastQuantity = value;
            }
        }
        [Display(Name = "Last Mtr Read")]
        public Int32 LastMtrRead
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.LastMtrRead : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.LastMtrRead = value;
            }
        }
        [Display(Name = "Consumption")]
        public Int32 Consumption
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.Consumption : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.Consumption = value;
            }
        }
        [Display(Name = "Remarks")]

        public string Remarks
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.Remarks : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.Remarks = value;
            }
        }
        [Display(Name = "Standard Copy")]
        public Int32 StandardCopy
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.StandardCopy : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.StandardCopy = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null && CCRMTonerRequestAuthorisationDTO.CreatedBy > 0) ? CCRMTonerRequestAuthorisationDTO.CreatedBy : new int();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.IsDeleted : false;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null && CCRMTonerRequestAuthorisationDTO.ModifiedBy.HasValue) ? CCRMTonerRequestAuthorisationDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null && CCRMTonerRequestAuthorisationDTO.ModifiedDate.HasValue) ? CCRMTonerRequestAuthorisationDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null && CCRMTonerRequestAuthorisationDTO.DeletedBy.HasValue) ? CCRMTonerRequestAuthorisationDTO.DeletedBy : new int();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null && CCRMTonerRequestAuthorisationDTO.DeletedDate.HasValue) ? CCRMTonerRequestAuthorisationDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsActive
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.IsDeleted : false;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.IsDeleted = value;
            }
        }
        public Int32 ContractTypeID
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ContractTypeID : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ContractTypeID = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ItemDescription = value;
            }
        }
        public Int32 PartNOID
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.PartNOID : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.PartNOID = value;
            }
        }
        public Int32 CallNo
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.CallNo : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.CallNo = value;
            }
        }
        public Int32 ItemNumber
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.ItemNumber : new Int32();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Status")]
        public byte Authorised
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.Authorised : new byte();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.Authorised = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.FromDate : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.UptoDate : string.Empty;
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.UptoDate = value;
            }
        }
        public bool Date
        {

            get
            {
                return (CCRMTonerRequestAuthorisationDTO != null) ? CCRMTonerRequestAuthorisationDTO.Date : new bool();
            }
            set
            {
                CCRMTonerRequestAuthorisationDTO.Date = value;
            }
        }
    }
}
