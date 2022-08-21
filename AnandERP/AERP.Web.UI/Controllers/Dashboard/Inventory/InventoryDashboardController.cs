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
    public class InventoryDashboardController : BaseController
    {
        IInventoryDashboardReportBA _InventoryDashboardReportBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;  
        string _sortBy = string.Empty;   
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryDashboardController()
        {
            _InventoryDashboardReportBA = new InventoryDashboardReportBA();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Dashboard/InventoryDashboard/Index.cshtml");
        }

        public ActionResult MonthlySaleReport()
        {
            return PartialView("/Views/Dashboard/Inventory/MonthlySaleReport.cshtml");
        }
        #endregion

        // Non-Action Method
        #region Methods
        [HttpGet]
        public JsonResult GetMonthlySaleReport()
        {

            var SaleContractRevenuDetails = MonthlySaleReportList(Convert.ToInt32(Session["PersonID"]), Convert.ToInt32(Session["DefaultRoleID"]));
            var result = (from s in SaleContractRevenuDetails
                          select new
                          {
                              totalInvoiceAmountList = s.TotalInvoiceAmountList,
                              invoiceMonth = s.InvoiceMonth,
                              CentreList = s.CentreList,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<InventoryDashboardReport> MonthlySaleReportList(int employeeID, int adminRoleID)
        {
            InventoryDashboardReportSearchRequest searchRequest = new InventoryDashboardReportSearchRequest();
            searchRequest.EmployeeID = employeeID;
            searchRequest.AdminRoleID = adminRoleID;

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryDashboardReport> CRMCallerCallDetailsList = new List<InventoryDashboardReport>();

            IBaseEntityCollectionResponse<InventoryDashboardReport> baseEntityCollectionResponse = _InventoryDashboardReportBA.GetMonthlySaleReport(searchRequest);
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
