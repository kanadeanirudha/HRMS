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
    public class SaleContractWiseComplianceReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;
        ISaleContractWiseComplianceReportBA _SaleContractWiseComplianceReportBA = null;
        private readonly ILogger _logException;
        protected static string _SalaryYear = string.Empty;
        protected static string _SalaryMonth = string.Empty;
        protected static string _SalaryMonthDisplay = string.Empty;
        protected static string _ReportType = string.Empty;
        protected static string _SaleContractBillingSpanName = string.Empty;
        protected static Int64 _SaleContractMasterID = 0;
        protected static Int64 _SaleContractBillingSpanID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public SaleContractWiseComplianceReportController()
        {
            _SaleContractWiseComplianceReportBA = new SaleContractWiseComplianceReportBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                _SalaryYear = string.Empty;
                _SalaryMonth = string.Empty;
                _ReportType = string.Empty;
                _SalaryMonthDisplay = string.Empty;

                SaleContractWiseComplianceReportViewModel model = new SaleContractWiseComplianceReportViewModel();

                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "PF", Value = "PF" });
                li1.Add(new SelectListItem { Text = "ESIC", Value = "ESIC" });
                li1.Add(new SelectListItem { Text = "PT", Value = "PT" });
                ViewData["ReportType"] = li1;

                List<SelectListItem> MonthList = new List<SelectListItem>();
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                ViewBag.MonthList = new SelectList(MonthList, "Value", "Text");
                List<SelectListItem> li_MonthList = new List<SelectListItem>();
                li_MonthList.Add(new SelectListItem { Text = "--Select month -- ", Value = "0" });
                for (int i = 1; i < 13; i++)
                {
                    ViewBag.MonthList = new SelectList(info.GetMonthName(i), i.ToString());
                    li_MonthList.Add(new SelectListItem { Text = info.GetMonthName(i), Value = (i).ToString() });
                }
                ViewData["SalaryMonth"] = new SelectList(li_MonthList, "Value", "Text");
                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> li_YearList = new List<SelectListItem>();
                ViewBag.YearList = new SelectList(li_YearList, "Value", "Text");
                li_YearList.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_YearList.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["SalaryYear"] = new SelectList(li_YearList, "Value", "Text");

                return View("/Views/Contract/Report/SaleContractWiseComplianceReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(SaleContractWiseComplianceReportViewModel model)
        {

            List<SelectListItem> li1 = new List<SelectListItem>();
            li1.Add(new SelectListItem { Text = "PF", Value = "PF" });
            li1.Add(new SelectListItem { Text = "ESIC", Value = "ESIC" });
            li1.Add(new SelectListItem { Text = "PT", Value = "PT" });
            

            List<SelectListItem> MonthList = new List<SelectListItem>();
            DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
            ViewBag.MonthList = new SelectList(MonthList, "Value", "Text");
            List<SelectListItem> li_MonthList = new List<SelectListItem>();
            li_MonthList.Add(new SelectListItem { Text = "--Select month -- ", Value = "0" });
            for (int i = 1; i < 13; i++)
            {
                ViewBag.MonthList = new SelectList(info.GetMonthName(i), i.ToString());
                li_MonthList.Add(new SelectListItem { Text = info.GetMonthName(i), Value = (i).ToString() });
            }
           
            //For Year
            int year = DateTime.Now.Year - 65;
            List<SelectListItem> li_YearList = new List<SelectListItem>();
            ViewBag.YearList = new SelectList(li_YearList, "Value", "Text");
            li_YearList.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
            for (int i = DateTime.Now.Year; year <= i; i--)
            {
                li_YearList.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            

            if (model.IsPosted == true)
            {
                _SalaryMonth = model.SalaryMonth;
                _SalaryYear = model.SalaryYear;
                _ReportType = model.ReportType;
                _SalaryMonthDisplay = model.SalaryMonthDisplay;
                model.IsPosted = false;
            }
            else
            {
                model.SalaryMonth = _SalaryMonth;
                model.SalaryYear = _SalaryYear;
                model.ReportType = _ReportType;
                model.SalaryMonthDisplay = _SalaryMonthDisplay;
            }

            ViewData["ReportType"] = new SelectList(li1, "Value", "Text", model.ReportType);
            ViewData["SalaryMonth"] = new SelectList(li_MonthList, "Value", "Text", model.SalaryMonth);
            ViewData["SalaryYear"] = new SelectList(li_YearList, "Value", "Text", model.SalaryYear);

            model.SaleContractSpanList = GetSpanListBySaleContractMaster(model.SaleContractMasterID);

            return View("/Views/Contract/Report/SaleContractWiseComplianceReport/Index.cshtml", model);
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

        public List<SaleContractWiseComplianceReport> GetSaleContractWiseComplianceReportList()
        {
            try
            {
                List<SaleContractWiseComplianceReport> listSaleContractWiseComplianceReport = new List<SaleContractWiseComplianceReport>();
                SaleContractWiseComplianceReportSearchRequest searchRequest = new SaleContractWiseComplianceReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_SalaryMonth != string.Empty && _SalaryYear != string.Empty)
                {
                    searchRequest.SalaryMonth = _SalaryMonth;
                    searchRequest.SalaryYear = _SalaryYear;
                    searchRequest.ReportType = _ReportType;
                    searchRequest.SalaryMonthDisplay = _SalaryMonthDisplay;
                    IBaseEntityCollectionResponse<SaleContractWiseComplianceReport> baseEntityCollectionResponse = _SaleContractWiseComplianceReportBA.GetSaleContractWiseComplianceReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listSaleContractWiseComplianceReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listSaleContractWiseComplianceReport;
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
