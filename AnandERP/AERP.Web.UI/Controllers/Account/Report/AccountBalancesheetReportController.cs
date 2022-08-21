using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using System.IO;

namespace AERP.Web.UI.Controllers
{
    public class AccountBalancesheetReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountBalancesheetReportBA _accountBalancesheetReportBA = null;
        private readonly ILogger _logException;
        protected static int _balanesheetMstID;
        protected static int _accSessionId;
        protected static string _balancesheetName = string.Empty;
        protected static string _sessionFromDate = string.Empty;
        protected static string _sessionUptoDate = string.Empty;
        protected static string _GroupBy = string.Empty;
        protected static int _format;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountBalancesheetReportController()
        {
            _accountBalancesheetReportBA = new AccountBalancesheetReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    AccountBalancesheetReportViewModel model = new AccountBalancesheetReportViewModel();
                    model.ListAccountSessionMasterReport = GetAllAccountSession();
                    List<SelectListItem> li_GroupBy = new List<SelectListItem>();
                    li_GroupBy.Add(new SelectListItem { Text = "Account Wise", Value = "A" });
                    li_GroupBy.Add(new SelectListItem { Text = "Group Wise", Value = "G" });
                    li_GroupBy.Add(new SelectListItem { Text = "Category Wise", Value = "C" });
                    ViewData["GroupBy"] = new SelectList(li_GroupBy, "Value", "Text", model.AccountBalancesheetReportDTO.GroupBy);

                    List<SelectListItem> li_BalanceSheetFormat = new List<SelectListItem>();
                    li_BalanceSheetFormat.Add(new SelectListItem { Text = "Format I", Value = "1" });
                    li_BalanceSheetFormat.Add(new SelectListItem { Text = "Format II", Value = "2" });
                    ViewData["Format"] = new SelectList(li_BalanceSheetFormat, "Value", "Text", model.AccountBalancesheetReportDTO.Format);

                    return View("/Views/Accounts/Report/AccountBalancesheetReport/Index.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Index(AccountBalancesheetReportViewModel model)
        {
            try
            {
                model.ListAccountSessionMasterReport = GetAllAccountSession();
                List<SelectListItem> li_GroupBy = new List<SelectListItem>();
                li_GroupBy.Add(new SelectListItem { Text = "Account Wise", Value = "A" });
                li_GroupBy.Add(new SelectListItem { Text = "Group Wise", Value = "G" });
                li_GroupBy.Add(new SelectListItem { Text = "Category Wise", Value = "C" });
                ViewData["GroupBy"] = new SelectList(li_GroupBy, "Value", "Text", model.AccountBalancesheetReportDTO.GroupBy);


                List<SelectListItem> li_BalanceSheetFormat = new List<SelectListItem>();
                li_BalanceSheetFormat.Add(new SelectListItem { Text = "Format I", Value = "1" });
                li_BalanceSheetFormat.Add(new SelectListItem { Text = "Format II", Value = "2" });
                ViewData["Format"] = new SelectList(li_BalanceSheetFormat, "Value", "Text", model.AccountBalancesheetReportDTO.Format);

                if (model.IsPosted == true)
                {
                    _balanesheetMstID = model.AccBalsheetMstId;
                    _balancesheetName = model.AccBalsheetName;
                    _accSessionId = model.AccountSessionID;
                    _sessionFromDate = model.SessionFromDate;
                    _sessionUptoDate = model.SessionUptoDate;
                    _format = model.Format;
                    _GroupBy = model.GroupBy;
                    model.IsPosted = false;
                }
                else
                {
                    model.AccBalsheetMstId = _balanesheetMstID;
                    model.AccBalsheetName = _balancesheetName;
                    model.AccountSessionID = _accSessionId;
                    model.SessionFromDate = _sessionFromDate;
                    model.SessionUptoDate = _sessionUptoDate;
                    model.Format = _format;
                    model.GroupBy = _GroupBy;
                }
                return View("/Views/Accounts/Report/AccountBalancesheetReport/Index.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        public List<AccountBalancesheetReport> GetAccountBalancesheetReport(string AssetLiabilityFlag, out int format)
        {
            try
            {
                List<AccountBalancesheetReport> listaccountDayBookReport = new List<AccountBalancesheetReport>();
                AccountBalancesheetReportSearchRequest searchRequest = new AccountBalancesheetReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_sessionFromDate != string.Empty && _sessionUptoDate != string.Empty && _GroupBy != string.Empty && _accSessionId != 0)
                {
                    searchRequest.AccBalsheetMstId = _balanesheetMstID;
                    int ID = searchRequest.AccBalsheetMstId;
                    if (ID == 0)
                    {
                        searchRequest.AccBalsheetName = "Consolidated";
                    }
                    else
                    {
                        searchRequest.AccBalsheetName = _balancesheetName;
                    }
                    searchRequest.SessionFromDate = _sessionFromDate;
                    searchRequest.SessionUptoDate = _sessionUptoDate;
                    searchRequest.GroupBy = _GroupBy;
                    searchRequest.AccountSessionID = _accSessionId;
                    searchRequest.AssetLiabilityFlag = AssetLiabilityFlag;
                    IBaseEntityCollectionResponse<AccountBalancesheetReport> baseEntityCollectionResponse = _accountBalancesheetReportBA.GetBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listaccountDayBookReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                format = _format;
                return listaccountDayBookReport;
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