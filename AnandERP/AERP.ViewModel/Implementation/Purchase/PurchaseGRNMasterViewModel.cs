using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;


namespace AERP.ViewModel
{
    public class PurchaseGRNMasterViewModel : IPurchaseGRNMasterViewModel
    {
        public PurchaseGRNMasterViewModel()
        {
            PurchaseGRNMasterDTO = new PurchaseGRNMaster();
            PurchaseGRNMasterListFromPO = new List<PurchaseGRNMaster>();
        }
       
        public PurchaseGRNMaster PurchaseGRNMasterDTO { get; set; }
        public List<PurchaseGRNMaster> PurchaseGRNMasterListFromPO { get; set; }
        /// <summary>
        /// Properties for PurchaseGRNMaster table
        /// </summary>
        public int ID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ID > 0) ? PurchaseGRNMasterDTO.ID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.ID = value;
            }
        }
        public int AdminRoleID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.AdminRoleID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.AdminRoleID = value;
            }
        }
        public int PurchaseOrderMasterID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.PurchaseOrderMasterID > 0) ? PurchaseGRNMasterDTO.PurchaseOrderMasterID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.PurchaseOrderMasterID = value;
            }
        }
        public int PurchaseOrderDetailID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.PurchaseOrderDetailID > 0) ? PurchaseGRNMasterDTO.PurchaseOrderDetailID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.PurchaseOrderDetailID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ItemNumber > 0) ? PurchaseGRNMasterDTO.ItemNumber : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.ItemNumber = value;
            }
        }
        public int PurchaseOrderType
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.PurchaseOrderType > 0) ? PurchaseGRNMasterDTO.PurchaseOrderType : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.PurchaseOrderType = value;
            }
        }
        [Required(ErrorMessage = "GRN Number should not be blank.")]
        [Display(Name = "GRN Number")]
        public string GRNNumber
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.GRNNumber : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.GRNNumber = value;
            }
        }
        
        public string GRNTransDate
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.GRNTransDate : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.GRNTransDate = value;
            }
        }
        public bool FOC
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.FOC : false;
            }
            set
            {
                PurchaseGRNMasterDTO.FOC = value;
            }
        }
        public bool IsLocked
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.IsLocked : false;
            }
            set
            {
                PurchaseGRNMasterDTO.IsLocked = value;
            }
        }
          [Display(Name = "Complete PO")]
        public bool IsCompletePO
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.IsCompletePO : false;
            }
            set
            {
                PurchaseGRNMasterDTO.IsCompletePO = value;
            }
        }
          [Required(ErrorMessage = "Please select Vendor.")]
          public string Vender
          {
              get
              {
                  return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Vender : string.Empty;
              }
              set
              {
                  PurchaseGRNMasterDTO.Vender = value;
              }
          }
        public int CreatedBy
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.CreatedBy > 0) ? PurchaseGRNMasterDTO.CreatedBy : new short();
            }
            set
            {
                PurchaseGRNMasterDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                PurchaseGRNMasterDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ModifiedBy > 0) ? PurchaseGRNMasterDTO.ModifiedBy : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                PurchaseGRNMasterDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.IsDeleted : false;
            }
            set
            {
                PurchaseGRNMasterDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

        public string PurchaseOrderNumber
        {
             get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.PurchaseOrderNumber : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.PurchaseOrderNumber = value;
            }
        }
        public string PurchaseOrderDate
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.PurchaseOrderDate : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.PurchaseOrderDate = value;
            }
        }

        /// <summary>
        /// Properties for PurchaseRequirementDetails table
        /// </summary>
        public int PurchaseGRNDetailsID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.PurchaseGRNDetailsID > 0) ? PurchaseGRNMasterDTO.PurchaseGRNDetailsID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.PurchaseGRNDetailsID = value;
            }
        }
        public int ItemID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ItemID > 0) ? PurchaseGRNMasterDTO.ItemID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.ItemID = value;
            }
        }
        public decimal Quantity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.Quantity > 0) ? PurchaseGRNMasterDTO.Quantity : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.Quantity = value;
            }
        }
        public decimal FOCReceivedQuantity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.FOCReceivedQuantity > 0) ? PurchaseGRNMasterDTO.FOCReceivedQuantity : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.FOCReceivedQuantity = value;
            }
        }
        public decimal ReceivedQuantity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ReceivedQuantity > 0) ? PurchaseGRNMasterDTO.ReceivedQuantity : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.ReceivedQuantity = value;
            }
        }
        public decimal RemainingQuantity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.RemainingQuantity > 0) ? PurchaseGRNMasterDTO.RemainingQuantity : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.RemainingQuantity = value;
            }
        }
        public decimal Rate
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.Rate > 0) ? PurchaseGRNMasterDTO.Rate : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.Rate = value;
            }
        }
        public int ReceivingLocationID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ReceivingLocationID > 0) ? PurchaseGRNMasterDTO.ReceivingLocationID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.ReceivingLocationID = value;
            }
        }
        public int StorageLocationID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.StorageLocationID > 0) ? PurchaseGRNMasterDTO.StorageLocationID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.StorageLocationID = value;
            }
        }
        public string ReceivingLocationName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ReceivingLocationName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ReceivingLocationName = value;
            }
        }
        public string StorageLocationName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.StorageLocationName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.StorageLocationName = value;
            }
        }
        public string ItemName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ItemName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ItemName = value;
            }
        }
        public Int16 PriorityFlag
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.PriorityFlag > 0) ? PurchaseGRNMasterDTO.PriorityFlag : new Int16();
            }
            set
            {
                PurchaseGRNMasterDTO.ID = value;
            }
        }
        public string Priority
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Priority : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.Priority = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.XMLstring = value;
            }
        }
        public string XMLstringForVouchar
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.XMLstringForVouchar : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.XMLstringForVouchar = value;
            }
        }

        public string Remark
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Remark : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.Remark = value;
            }
        }
        public bool Isexpiry
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Isexpiry : false;
            }
            set
            {
                PurchaseGRNMasterDTO.Isexpiry = value;
            }
        }
        public int BatchID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.BatchID > 0) ? PurchaseGRNMasterDTO.BatchID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.BatchID = value;
            }
        }
        public decimal BatchQuantity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.BatchQuantity > 0) ? PurchaseGRNMasterDTO.BatchQuantity : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.BatchQuantity = value;
            }
        }
        public string BatchNumber
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.BatchNumber : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.BatchNumber = value;
            }
        }
        public string ExpiryDate
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ExpiryDate : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ExpiryDate = value;
            }
        }
        [Display(Name = "Item Managed By")]
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                PurchaseGRNMasterDTO.SerialAndBatchManagedBy = value;
            }
        }

        public bool GRNIsLockedStatusFlag
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.GRNIsLockedStatusFlag : false;
            }
            set
            {
                PurchaseGRNMasterDTO.GRNIsLockedStatusFlag = value;
            }
        }
        public decimal DamagedQuantity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.DamagedQuantity > 0) ? PurchaseGRNMasterDTO.DamagedQuantity : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.DamagedQuantity = value;
            }
        }

        public decimal GrossAmount
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.GrossAmount > 0) ? PurchaseGRNMasterDTO.GrossAmount : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.GrossAmount = value;
            }
        }
        public decimal TotalTaxAmount
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.TotalTaxAmount > 0) ? PurchaseGRNMasterDTO.TotalTaxAmount : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.TotalTaxAmount = value;
            }
        }
        public decimal Discount
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.Discount > 0) ? PurchaseGRNMasterDTO.Discount : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.Discount = value;
            }
        }
        public decimal Freight
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.Freight > 0) ? PurchaseGRNMasterDTO.Freight : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.Freight = value;
            }
        }
        public decimal ShippingHandling
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.ShippingHandling > 0) ? PurchaseGRNMasterDTO.ShippingHandling : new decimal();
            }
            set
            {
                PurchaseGRNMasterDTO.ShippingHandling = value;
            }
        }
        [Display(Name = "Total Shelf Life(Days)")]
        public string ShelfLife
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ShelfLife : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ShelfLife = value;
            }
        }
        [Display(Name = "Remaining Shelf Life(Days)")]
        public string RemainingShelfLife
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.RemainingShelfLife : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.RemainingShelfLife = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.VendorID > 0) ? PurchaseGRNMasterDTO.VendorID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.VendorID = value;
            }
        }
        public bool ReturnGoods
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ReturnGoods : false;
            }
            set
            {
                PurchaseGRNMasterDTO.ReturnGoods = value;
            }
        }

        public string LocationAddress
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.LocationAddress : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.LocationAddress = value;
            }
        }
        public string Pincode
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Pincode : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.Pincode = value;
            }
        }
        public string City
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.City : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.City = value;
            }
        }

        #region -------------- TaskNotification Properties---------------
        public int TaskNotificationMasterID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.TaskNotificationMasterID > 0) ? PurchaseGRNMasterDTO.TaskNotificationMasterID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.TaskNotificationMasterID = value;
            }
        }
        //[Display(Name = "DisplayName_LeaveCode", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LeaveCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.TaskCode = value;
            }
        }

        public int TaskNotificationDetailsID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.TaskNotificationDetailsID > 0) ? PurchaseGRNMasterDTO.TaskNotificationDetailsID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.TaskNotificationDetailsID = value;
            }
        }
        public int GeneralTaskReportingDetailsID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.GeneralTaskReportingDetailsID > 0) ? PurchaseGRNMasterDTO.GeneralTaskReportingDetailsID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.GeneralTaskReportingDetailsID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.PersonID > 0) ? PurchaseGRNMasterDTO.PersonID : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.PersonID = value;
            }
        }

        public int StageSequenceNumber
        {
            get
            {
                return (PurchaseGRNMasterDTO != null && PurchaseGRNMasterDTO.StageSequenceNumber > 0) ? PurchaseGRNMasterDTO.StageSequenceNumber : new int();
            }
            set
            {
                PurchaseGRNMasterDTO.StageSequenceNumber = value;
            }
        }
        public bool IsLastRecord
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.IsLastRecord : false;
            }
            set
            {
                PurchaseGRNMasterDTO.IsLastRecord = value;
            }
        }
        #endregion



        //GRN PDF

        public string ToUnitName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ToUnitName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ToUnitName = value;
            }
        }
        public string ToCity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ToCity : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ToCity = value;
            }
        }
        public string Topincode
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Topincode : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.Topincode = value;
            }
        }
        public string ToLocationAddress
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ToLocationAddress : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ToLocationAddress = value;
            }
        }
        public string ToLocationName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.ToLocationName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.ToLocationName = value;
            }
        }


        public string FromLocationName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.FromLocationName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.FromLocationName = value;
            }
        }
        public string FromUnitName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.FromUnitName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.FromUnitName = value;
            }
        }
        public string FromCity
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.FromCity : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.FromCity = value;
            }
        }
        public string Frompincode
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.Frompincode : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.Frompincode = value;
            }
        }
        public string FromLocationAddress
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.FromLocationAddress : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.FromLocationAddress = value;
            }
        }
        public string MonthName
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.MonthName : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.MonthName = value;
            }
        }
        public string MonthYear
        {
            get
            {
                return (PurchaseGRNMasterDTO != null) ? PurchaseGRNMasterDTO.MonthYear : string.Empty;
            }
            set
            {
                PurchaseGRNMasterDTO.MonthYear = value;
            }
        }
    }
}
