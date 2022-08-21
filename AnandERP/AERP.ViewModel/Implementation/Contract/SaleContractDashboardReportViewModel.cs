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
    public class SaleContractDashboardReportViewModel
    {

        public SaleContractDashboardReportViewModel()
        {
            SaleContractDashboardReportDTO = new SaleContractDashboardReport();
        }
        //CRMSaleTargetGroupWise
        public SaleContractDashboardReport SaleContractDashboardReportDTO
        {
            get;
            set;

        }
        public int EmployeeID
        {
            get
            {
                return (SaleContractDashboardReportDTO != null) ? SaleContractDashboardReportDTO.EmployeeID : new Int32();
            }
            set
            {
                SaleContractDashboardReportDTO.EmployeeID = value;
            }
        }
        
        public string ReportList
        {
            get
            {
                return (SaleContractDashboardReportDTO != null) ? SaleContractDashboardReportDTO.ReportList : string.Empty;
            }
            set
            {
                SaleContractDashboardReportDTO.ReportList = value;
            }
        }
        public string ReportCount
        {
            get
            {
                return (SaleContractDashboardReportDTO != null) ? SaleContractDashboardReportDTO.ReportCount : string.Empty;
            }
            set
            {
                SaleContractDashboardReportDTO.ReportCount = value;
            }
        }
        public string DataFor
        {
            get
            {
                return (SaleContractDashboardReportDTO != null) ? SaleContractDashboardReportDTO.DataFor : string.Empty;
            }
            set
            {
                SaleContractDashboardReportDTO.DataFor = value;
            }
        }
    }
}

