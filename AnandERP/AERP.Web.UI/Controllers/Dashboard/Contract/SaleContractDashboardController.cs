using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class SaleContractDashboardController : BaseController
    {
        ISaleContractDashboardReportBA _SaleContractDashboardReportBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;  
        string _sortBy = string.Empty;   
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractDashboardController()
        {
            _SaleContractDashboardReportBA = new SaleContractDashboardReportBA();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Dashboard/SaleContractDashboard/Index.cshtml");
        }

        public ActionResult MonthWiseManPowerSale()
        {
            return PartialView("/Views/Dashboard/Contract/MonthWiseManPowerSale.cshtml");
        }

        public ActionResult TotalSaleContract()
        {
            SaleContractDashboardReportViewModel model = new SaleContractDashboardReportViewModel();
            try
            {
                model.SaleContractDashboardReportDTO = new SaleContractDashboardReport();
                model.SaleContractDashboardReportDTO.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                model.SaleContractDashboardReportDTO.AdminRoleID = Convert.ToInt32(Session["DefaultRoleID"]);
                model.SaleContractDashboardReportDTO.DataFor = "TotalSaleContract";
                model.SaleContractDashboardReportDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SaleContractDashboardReport> response = _SaleContractDashboardReportBA.SaleContractDashboardSparklineChartsReportByEmployeeID(model.SaleContractDashboardReportDTO);
                if (response != null && response.Entity != null)
                {
                    model.SaleContractDashboardReportDTO.ReportCount = response.Entity.ReportCount;
                    model.SaleContractDashboardReportDTO.ReportList = response.Entity.ReportList;
                }
                return PartialView("/Views/Dashboard/Contract/TotalSaleContract.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        // Non-Action Method
        #region Methods
        [HttpGet]
        public JsonResult SaleContractGetMonthlySaleReport()
        {

            var SaleContractRevenuDetails = SaleContractGetMonthlySaleReportList(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in SaleContractRevenuDetails
                          select new
                          {
                              totalInvoiceAmountList = s.TotalInvoiceAmountList,
                              invoiceMonth = s.InvoiceMonth,
                              CentreList = s.CentreList,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<SaleContractDashboardReport> SaleContractGetMonthlySaleReportList(int employeeID, int adminRoleID)
        {
            SaleContractDashboardReportSearchRequest searchRequest = new SaleContractDashboardReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SaleContractDashboardReport> CRMCallerCallDetailsList = new List<SaleContractDashboardReport>();

            IBaseEntityCollectionResponse<SaleContractDashboardReport> baseEntityCollectionResponse = _SaleContractDashboardReportBA.GetSaleContractMonthlySaleReportList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    CRMCallerCallDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return CRMCallerCallDetailsList;
        }
        #endregion


        // AjaxHandler Method
        #region

        #endregion
    }
}
