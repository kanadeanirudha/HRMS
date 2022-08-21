using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
  public  class CCRMTonerRequestCallViewModel :ICCRMTonerRequestCallViewModel
    {
        public CCRMTonerRequestCallViewModel()
        {
            CCRMTonerRequestCallDTO = new CCRMTonerRequestCall();
        }
        public CCRMTonerRequestCall CCRMTonerRequestCallDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null && CCRMTonerRequestCallDTO.ID > 0) ? CCRMTonerRequestCallDTO.ID : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.ID = value;
            }
        }
        [Display(Name = "Serial No")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public string SerialNo
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.SerialNo = value;
            }
        }
        [Display(Name = "Model No")]
        public string ModelNo
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.ModelNo = value;
            }
        }
        [Display(Name = "MIF Name")]
        public string MIFName
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.MIFName : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.MIFName = value;
            }
        }
        public Int16 MachineFamilyID
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.MachineFamilyID : new Int16();
            }
            set
            {
                CCRMTonerRequestCallDTO.MachineFamilyID = value;
            }
        }
        [Display(Name = "Machine Family ")]
        public string MachineFamilyName
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.MachineFamilyName = value;
            }
        }
        [Display(Name = "Contract Code")]
        public string ContractCode
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ContractCode : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.ContractCode = value;
            }
        }
        [Display(Name = "Call Date")]
        public string CallDate
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CallDate : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.CallDate = value;
            }
        }
        [Display(Name = "Call Tkt No")]

        public string CallTktNo
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CallTktNo : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.CallTktNo = value;
            }
        }
        public Int32 MIFID
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.MIFID : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.MIFID = value;
            }
        }
        public Int32 ContractID
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ContractID : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.ContractID = value;
            }
        }
        [Display(Name = "Part No")]

        public string PartNO
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.PartNO : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.PartNO = value;
            }
        }
        [Display(Name = "Part Name")]

        public string PartName
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.PartName : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.PartName = value;
            }
        }
        public Int32 BalanceQuantity
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.BalanceQuantity : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.BalanceQuantity = value;
            }
        }
        public Int32 CallId
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CallId : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.CallId = value;
            }
        }
        [Display(Name = "Caller Name")]

        public string CallerName
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.CallerName = value;
            }
        }
        [Display(Name = "Caller Phone")]

        public string CallerPh
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CallerPh : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.CallerPh = value;
            }
        }
        [Display(Name = "Part Name")]

        public string ItemName
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ItemName : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.ItemName = value;
            }
        }
        public string ItemCategoryCode
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.ItemCategoryCode = value;
            }
        }
        [Display(Name = "Current Mtr Read")]
        public Int32 CurrentMeterRead
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CurrentMeterRead : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.CurrentMeterRead = value;
            }
        }
        [Display(Name = "Quantity")]
        public Int32 Quantity
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.Quantity : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.Quantity = value;
            }
        }
        [Display(Name = "FOC")]
        public bool FOC
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.FOC : new bool();
            }
            set
            {
                CCRMTonerRequestCallDTO.FOC = value;
            }
        }
        [Display(Name = "Last Call Date")]

        public string LastCallDate
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.LastCallDate : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.LastCallDate = value;
            }
        }
        [Display(Name = "Last Call No")]
        public Int32 LastCallNo
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.LastCallNo : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.LastCallNo = value;
            }
        }
        [Display(Name = "Last Quantity")]
        public Int32 LastQuantity
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.LastQuantity : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.LastQuantity = value;
            }
        }
        [Display(Name = "Last Mtr Read")]
        public Int32 LastMtrRead
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.LastMtrRead : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.LastMtrRead = value;
            }
        }
        [Display(Name = "Consumption")]
        public Int32 Consumption
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.Consumption : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.Consumption = value;
            }
        }
        [Display(Name = "Remarks")]

        public string Remarks
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.Remarks : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.Remarks = value;
            }
        }
        [Display(Name = "Standard Copy")]
        public Int32 StandardCopy
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.StandardCopy : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.StandardCopy = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null && CCRMTonerRequestCallDTO.CreatedBy > 0) ? CCRMTonerRequestCallDTO.CreatedBy : new int();
            }
            set
            {
                CCRMTonerRequestCallDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.IsDeleted : false;
            }
            set
            {
                CCRMTonerRequestCallDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMTonerRequestCallDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null && CCRMTonerRequestCallDTO.ModifiedBy.HasValue) ? CCRMTonerRequestCallDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMTonerRequestCallDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null && CCRMTonerRequestCallDTO.ModifiedDate.HasValue) ? CCRMTonerRequestCallDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMTonerRequestCallDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null && CCRMTonerRequestCallDTO.DeletedBy.HasValue) ? CCRMTonerRequestCallDTO.DeletedBy : new int();
            }
            set
            {
                CCRMTonerRequestCallDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null && CCRMTonerRequestCallDTO.DeletedDate.HasValue) ? CCRMTonerRequestCallDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMTonerRequestCallDTO.DeletedDate = value;
            }
        }
        public Nullable<bool> IsActive
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.IsDeleted : false;
            }
            set
            {
                CCRMTonerRequestCallDTO.IsDeleted = value;
            }
        }
        public Int32 ContractTypeID
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ContractTypeID : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.ContractTypeID = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMTonerRequestCallDTO.ItemDescription = value;
            }
        }
        public Int32 PartNOID
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.PartNOID : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.PartNOID = value;
            }
        }
        public Int32 CallNo
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.CallNo : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.CallNo = value;
            }
        }
        public Int32 ItemNumber
        {

            get
            {
                return (CCRMTonerRequestCallDTO != null) ? CCRMTonerRequestCallDTO.ItemNumber : new Int32();
            }
            set
            {
                CCRMTonerRequestCallDTO.ItemNumber = value;
            }
        }
    }
}
