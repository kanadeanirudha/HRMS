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
    public class ContractSalaryATMReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IContractSalaryATMReportBA _ContractSalaryATMReportBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static byte _BankMasterID = 0;
        protected static string _BankName = string.Empty;
        protected static byte _ReportType = 0;
        protected static string _SalaryMonth = string.Empty;
        protected static string _SalaryYear = string.Empty;
        protected static string _SearchFor = string.Empty;
        protected static string _SearchForDisplay = string.Empty;
        protected static string _SearchForXML = string.Empty;
        protected static bool _IsRemovalForAdjustment = false;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ContractSalaryATMReportController()
        {
            _ContractSalaryATMReportBA = new ContractSalaryATMReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                _centreCode = string.Empty;
                _centreName = string.Empty;
                _ReportType = 0;
                _BankMasterID = 0;
                _BankName = string.Empty;
                _SalaryMonth = string.Empty;
                _SalaryYear = string.Empty;
                _SearchFor = string.Empty;
                _SearchForDisplay = string.Empty;
                _SearchForXML = string.Empty;
                _IsRemovalForAdjustment = false;

                ContractSalaryATMReportViewModel model = new ContractSalaryATMReportViewModel();
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                model.ListGetAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);

                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "Cash", Value = "1" });
                li1.Add(new SelectListItem { Text = "Bank", Value = "2" });
                ViewData["ReportType"] = li1;

                model.ListBankMaster= GetListBankMaster();

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

                return View("/Views/Contract/Report/ContractSalaryATMReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(ContractSalaryATMReportViewModel model)
        {

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            model.ListGetAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);

            List<SelectListItem> li1 = new List<SelectListItem>();
            li1.Add(new SelectListItem { Text = "Cash", Value = "1" });
            li1.Add(new SelectListItem { Text = "Bank", Value = "2" });
            ViewData["ReportType"] = new SelectList(li1, "Value", "Text", model.ReportType);

            model.ListBankMaster = GetListBankMaster();

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

            if (model.IsPosted == true)
            {
                _centreCode = model.CentreCode;
                _centreName = model.CentreName;
                _ReportType = model.ReportType;
                _BankMasterID = model.BankMasterID;
                _BankName = model.BankName;
                _SalaryMonth = model.SalaryMonth;
                _SalaryYear = model.SalaryYear;
                _SearchFor = model.SearchFor;
                _SearchForDisplay = model.SearchForDisplay;
                _SearchForXML = model.SearchForXML;
                _IsRemovalForAdjustment = model.IsRemovalForAdjustment;
                model.IsPosted = false;
            }
            else
            {
                model.CentreCode = _centreCode;
                model.CentreName = _centreName;
                model.ReportType = _ReportType;
                model.BankMasterID = _BankMasterID;
                model.BankName = _BankName;
                model.SalaryMonth = _SalaryMonth;
                model.SalaryYear = _SalaryYear;
                model.SearchFor= _SearchFor;
                model.SearchForDisplay= _SearchForDisplay;
                model.SearchForXML = _SearchForXML;
                model.IsRemovalForAdjustment = _IsRemovalForAdjustment;
            }

            return View("/Views/Contract/Report/ContractSalaryATMReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<AdminRoleApplicableDetails> GetCentreListByRoleAuthorization()
        {
            ContractSalaryATMReportViewModel model = new ContractSalaryATMReportViewModel();
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
            AdminRoleApplicableDetails a = null;
            foreach (var item in listAdminRoleApplicableDetails)
            {
                a = new AdminRoleApplicableDetails();
                a.CentreCode = item.CentreCode;
                a.CentreName = item.CentreName;
                model.ListGetAdminRoleApplicableCentre.Add(a);
            }
            return model.ListGetAdminRoleApplicableCentre;
        }

        public List<ContractSalaryATMReport> GetContractSalaryATMReportList()
        {
            try
            {
                List<ContractSalaryATMReport> listContractSalaryATMReport = new List<ContractSalaryATMReport>();
                ContractSalaryATMReportSearchRequest searchRequest = new ContractSalaryATMReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_centreCode != string.Empty)
                {
                    searchRequest.CentreCode = _centreCode;
                    searchRequest.CentreName= _centreName;
                    searchRequest.ReportType = _ReportType;
                    searchRequest.BankMasterID = _BankMasterID;
                    searchRequest.BankName = _BankName;
                    searchRequest.SalaryMonth = _SalaryMonth;
                    searchRequest.SalaryYear = _SalaryYear;
                    searchRequest.SearchFor = _SearchFor;
                    searchRequest.SearchForDisplay = _SearchForDisplay;
                    searchRequest.SearchForXML = _SearchForXML;
                    searchRequest.IsRemovalForAdjustment = _IsRemovalForAdjustment;
                    IBaseEntityCollectionResponse<ContractSalaryATMReport> baseEntityCollectionResponse = _ContractSalaryATMReportBA.GetContractSalaryATMReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listContractSalaryATMReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listContractSalaryATMReport;
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
