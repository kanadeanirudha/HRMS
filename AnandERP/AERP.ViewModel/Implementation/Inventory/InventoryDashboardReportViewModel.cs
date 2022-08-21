using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;


namespace AMS.ViewModel
{
    public class InventoryDashboardReportViewModel : IInventoryDashboardReportViewModel
    {
        public InventoryDashboardReportViewModel()
        {
            InventoryDashboardReportDTO = new InventoryDashboardReport();
            PolicyAnswerByPolicyStatus = new List<GeneralPolicyRules>();
            InventoryPurchaseRequirementListForRequisition = new List<InventoryDashboardReport>();
            InventoryDashboardReportList = new List<InventoryDashboardReport>();
            BelowStocksafetyLevelListForRequisition = new List<InventoryDashboardReport>();
        }
        public List<InventoryDashboardReport> InventoryPurchaseRequirementListForRequisition { get; set; }
        public List<InventoryDashboardReport> BelowStocksafetyLevelListForRequisition { get; set; }
        public List<InventoryDashboardReport> InventoryDashboardReportList { get; set; }
        public InventoryDashboardReport InventoryDashboardReportDTO { get; set; }
        public List<GeneralPolicyRules> PolicyAnswerByPolicyStatus { get; set; }
        /// <summary>
        /// Properties for InventoryDashboardReport table
        /// </summary>
        public int ID
        {
            get
            {
                return (InventoryDashboardReportDTO != null && InventoryDashboardReportDTO.ID > 0) ? InventoryDashboardReportDTO.ID : new int();
            }
            set
            {
                InventoryDashboardReportDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Requirement No. should not be blank.")]
        [Display(Name = "Requirement No.")]
        public string PurchaseRequirementNumber
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.PurchaseRequirementNumber : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.PurchaseRequirementNumber = value;
            }
        }
        [Display(Name = "Conversion")]
        public string Convertion
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.Convertion : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.Convertion = value;
            }
        }
        [Required(ErrorMessage = "Requisition No. should not be blank.")]
        [Display(Name = "Requisition No.")]
        public string PurchaseRequisitionNumber
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.PurchaseRequisitionNumber : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.PurchaseRequisitionNumber = value;
            }
        }
        [Required(ErrorMessage = "Transaction Date should not be blank.")]
        [Display(Name = " Transaction Date")]
        public string TransDate
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.TransDate : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.TransDate = value;
            }
        }

        public string Days
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.Days : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.Days = value;
            }
        }
        public string Months
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.Months : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.Months = value;
            }
        }
        public string ReportList
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.ReportList : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.ReportList = value;
            }
        }

        public string TotalInvoiceAmountList
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.TotalInvoiceAmountList : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.TotalInvoiceAmountList = value;
            }
        }


        public string BillRelevantTo
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.BillRelevantTo : string.Empty;
            }
            set
            {
                InventoryDashboardReportDTO.BillRelevantTo = value;
            }
        }

        public decimal SaleAmount
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.SaleAmount : new decimal();
            }
            set
            {
                InventoryDashboardReportDTO.SaleAmount = value;
            }
        }


        public int CreatedBy
        {
            get
            {
                return (InventoryDashboardReportDTO != null && InventoryDashboardReportDTO.CreatedBy > 0) ? InventoryDashboardReportDTO.CreatedBy : new short();
            }
            set
            {
                InventoryDashboardReportDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryDashboardReportDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (InventoryDashboardReportDTO != null && InventoryDashboardReportDTO.ModifiedBy > 0) ? InventoryDashboardReportDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryDashboardReportDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryDashboardReportDTO.ModifiedDate = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (InventoryDashboardReportDTO != null) ? InventoryDashboardReportDTO.IsDeleted : false;
            }
            set
            {
                InventoryDashboardReportDTO.IsDeleted = value;
            }
        }
        public string errorMessage { get; set; }

        /// <summary>
        /// Properties for PurchaseRequirementDetails table
        /// </summary>
      

     
    }
}
