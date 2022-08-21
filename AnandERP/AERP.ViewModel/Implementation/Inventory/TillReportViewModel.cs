using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class TillReportViewModel
    {
        public TillReportViewModel()
        {
            TillReportDTO = new TillReport();
            ListGeneralCounter = new List<GeneralCounterMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<GeneralCounterMaster> ListGeneralCounter
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGeneralCounterItems
        {
            get
            {
                return new SelectList(ListGeneralCounter, "ID", "UnitName");
            }
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public TillReport TillReportDTO { get; set; }

        public string TransactionDate
        {
            get
            {
                return (TillReportDTO != null) ? TillReportDTO.TransactionDate : string.Empty;
            }
            set
            {
                TillReportDTO.TransactionDate = value;
            }
        }
        public Int16 CounterId
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.CounterId > 0) ? TillReportDTO.CounterId : new Int16();
            }
            set
            {
                TillReportDTO.CounterId = value;
            }
        }
        public Decimal TotalBillRetailCard
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalBillRetailCard > 0) ? TillReportDTO.TotalBillRetailCard : new Decimal();
            }
            set
            {
                TillReportDTO.TotalBillRetailCard = value;
            }
        }
        public Decimal TotalBillRetailCash
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalBillRetailCash > 0) ? TillReportDTO.TotalBillRetailCash : new Decimal();
            }
            set
            {
                TillReportDTO.TotalBillRetailCash = value;
            }
        }
        public Decimal TotalBillRestaurantCard
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalBillRestaurantCard > 0) ? TillReportDTO.TotalBillRestaurantCard : new Decimal();
            }
            set
            {
                TillReportDTO.TotalBillRestaurantCard = value;
            }
        }
        public Decimal TotalBillRestaurantCash
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalBillRestaurantCash > 0) ? TillReportDTO.TotalBillRestaurantCash : new Decimal();
            }
            set
            {
                TillReportDTO.TotalBillRestaurantCash = value;
            }
        }
        public Decimal TotalCardPayment
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalCardPayment > 0) ? TillReportDTO.TotalCardPayment : new Decimal();
            }
            set
            {
                TillReportDTO.TotalCardPayment = value;
            }
        }
        public Decimal TotalCashPayment
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalCashPayment > 0) ? TillReportDTO.TotalCashPayment : new Decimal();
            }
            set
            {
                TillReportDTO.TotalCashPayment = value;
            }
        }
        public Decimal TotalReatailPayment
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalReatailPayment > 0) ? TillReportDTO.TotalReatailPayment : new Decimal();
            }
            set
            {
                TillReportDTO.TotalReatailPayment = value;
            }
        }
        public Decimal TotalRestaurantPayment
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.TotalRestaurantPayment > 0) ? TillReportDTO.TotalRestaurantPayment : new Decimal();
            }
            set
            {
                TillReportDTO.TotalRestaurantPayment = value;
            }
        }
        public Decimal CashReceived
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.CashReceived > 0) ? TillReportDTO.CashReceived : new Decimal();
            }
            set
            {
                TillReportDTO.CashReceived = value;
            }
        }
        public Decimal DescripancyInCash
        {
            get
            {
                return (TillReportDTO != null && TillReportDTO.DescripancyInCash > 0) ? TillReportDTO.DescripancyInCash : new Decimal();
            }
            set
            {
                TillReportDTO.DescripancyInCash = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (TillReportDTO != null) ? TillReportDTO.CentreCode : string.Empty;
            }
            set
            {
                TillReportDTO.CentreCode = value;
            }
        }
    }
}

