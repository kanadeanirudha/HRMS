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
using System.Globalization;
namespace AERP.Web.UI.Controllers
{
    public class SaleContractSalaryWageSheetReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;
        ISaleContractSalaryWageSheetReportBA _SaleContractSalaryWageSheetReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _ContractNumber = string.Empty;
        protected static string _SaleContractBillingSpanName = string.Empty;
        protected static Int64 _SaleContractMasterID = 0;
        protected static Int64 _SaleContractBillingSpanID = 0;
        protected static byte _ReportType = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleContractSalaryWageSheetReportController()
        {
            _SaleContractSalaryWageSheetReportBA = new SaleContractSalaryWageSheetReportBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                SaleContractSalaryWageSheetReportViewModel model = new SaleContractSalaryWageSheetReportViewModel();

                List<SelectListItem> li_ReportType = new List<SelectListItem>();
                li_ReportType.Add(new SelectListItem { Text = "For Submit Salary", Value = "1" });
                li_ReportType.Add(new SelectListItem { Text = "For Save Salary", Value = "2" });
                ViewBag.ReportTypeList = new SelectList(li_ReportType, "Value", "Text");

                return View("/Views/Contract/Report/SaleContractSalaryWageSheetReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SaleContractSalaryWageSheetReportViewModel model)
        {
            if (model.IsPosted == true)
            {
                _SaleContractMasterID = model.SaleContractMasterID;
                _ContractNumber = model.ContractNumber;
                _SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                _SaleContractBillingSpanName = model.SaleContractBillingSpanName;
                _ReportType = model.ReportType;
                model.IsPosted = false;
            }
            else
            {
                model.SaleContractMasterID = _SaleContractMasterID;
                model.ContractNumber = _ContractNumber;
                model.SaleContractBillingSpanID = _SaleContractBillingSpanID;
                model.SaleContractBillingSpanName = _SaleContractBillingSpanName;
                model.ReportType = _ReportType;
            }

            model.SaleContractSpanList = GetSpanListBySaleContractMaster(model.SaleContractMasterID);
            
            List<SelectListItem> li_ReportType = new List<SelectListItem>();
            li_ReportType.Add(new SelectListItem { Text = "For Submit Salary", Value = "1" });
            li_ReportType.Add(new SelectListItem { Text = "For Save Salary", Value = "2" });
            ViewBag.ReportTypeList = new SelectList(li_ReportType, "Value", "Text");

            return View("/Views/Contract/Report/SaleContractSalaryWageSheetReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        protected List<SaleContractAttendance> GetSpanListBySaleContractMaster(Int64 SaleContractMasterID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSpanListBySaleContractMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        public List<SaleContractSalaryWageSheetReport> GetSaleContractSalaryWageSheetReportList()
        {
            try
            {
                List<SaleContractSalaryWageSheetReport> listSaleContractSalaryWageSheetReport = new List<SaleContractSalaryWageSheetReport>();
                SaleContractSalaryWageSheetReportSearchRequest searchRequest = new SaleContractSalaryWageSheetReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                
                if (_SaleContractMasterID > 0 && _SaleContractBillingSpanID > 0)
                {
                    searchRequest.SaleContractMasterID = _SaleContractMasterID;
                    searchRequest.ContractNumber = _ContractNumber;
                    searchRequest.SaleContractBillingSpanID = _SaleContractBillingSpanID;
                    searchRequest.SaleContractBillingSpanName = _SaleContractBillingSpanName;
                    searchRequest.ReportType = _ReportType;
                    IBaseEntityCollectionResponse<SaleContractSalaryWageSheetReport> baseEntityCollectionResponse = _SaleContractSalaryWageSheetReportBA.GetSaleContractSalaryWageSheetReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSaleContractSalaryWageSheetReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSaleContractSalaryWageSheetReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion        
    }
}
