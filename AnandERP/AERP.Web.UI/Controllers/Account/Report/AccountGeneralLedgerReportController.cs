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
    public class AccountGeneralLedgerReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountGeneralLedgerReportBA _accountGeneralLedgerReportBA = null;
        private readonly ILogger _logException;
        protected static string _sessionFromDate = string.Empty;
        protected static string _sessionUptoDate = string.Empty;
        protected static int _accountID;
        protected static string _accountName = string.Empty;
        protected static int _balanesheetMstID;
        protected static string _transactionTypeXml = string.Empty;
        protected static int _accountSessionID;
        protected static string _consolidiateType = string.Empty;
        protected static string _accountType = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountGeneralLedgerReportController()
        {
            _accountGeneralLedgerReportBA = new AccountGeneralLedgerReportBA();
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
                    AccountGeneralLedgerReportViewModel model = new AccountGeneralLedgerReportViewModel();
                    model.ListAccountSessionMasterReport = GetAllAccountSession();
                    List<SelectListItem> li_AccountType = new List<SelectListItem>();
                    li_AccountType.Add(new SelectListItem { Text = "General Ledger", Value = "L" });
                    li_AccountType.Add(new SelectListItem { Text = "Bank Ledger", Value = "B" });
                    li_AccountType.Add(new SelectListItem { Text = "Cash Ledger", Value = "C" });
                    ViewData["AccountType"] = new SelectList(li_AccountType, "Value", "Text", model.AccountGeneralLedgerReportDTO.AccountType);


                    List<SelectListItem> li_ReportParameter = new List<SelectListItem>();
                    li_ReportParameter.Add(new SelectListItem { Text = "Detailed", Value = "NOTAPPLI~Detailed" });
                    li_ReportParameter.Add(new SelectListItem { Text = "Daily Consolidated", Value = "DAILY~Daily Consolidated" });
                    li_ReportParameter.Add(new SelectListItem { Text = "Voucher Consolidated", Value = "VOUCHER~Voucher Consolidated" });
                    ViewData["ReportParameter"] = new SelectList(li_ReportParameter, "Value", "Text", model.AccountGeneralLedgerReportDTO.ReportParameter);

                    model.ListAccountNameReport = GetAccountList("L", string.Empty);

                    return View("/Views/Accounts/Report/AccountGeneralLedgerReport/Index.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Index(AccountGeneralLedgerReportViewModel model)
        {
            try
            {
                model.ListAccountSessionMasterReport = GetAllAccountSession();
                List<SelectListItem> li_AccountType = new List<SelectListItem>();
                li_AccountType.Add(new SelectListItem { Text = "General Ledger", Value = "L" });
                li_AccountType.Add(new SelectListItem { Text = "Bank Ledger", Value = "B" });
                li_AccountType.Add(new SelectListItem { Text = "Cash Ledger", Value = "C" });
               


                List<SelectListItem> li_ReportParameter = new List<SelectListItem>();
                li_ReportParameter.Add(new SelectListItem { Text = "Detailed", Value = "NOTAPPLI~Detailed" });
                li_ReportParameter.Add(new SelectListItem { Text = "Daily Consolidated", Value = "DAILY~Daily Consolidated" });
                li_ReportParameter.Add(new SelectListItem { Text = "Voucher Consolidated", Value = "VOUCHER~Voucher Consolidated" });



                if (model.IsPosted == true)
                {

                    /// Allocate parameters to local variable
                    _sessionFromDate = model.FromDate;
                    _sessionUptoDate = model.ToDate;
                    _accountSessionID = model.AccountSessionID;
                    _accountID = model.AccountID;
                    _accountType = model.AccountType;
                    _accountName = model.AccountName;
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    _consolidiateType = model.ReportParameter;
                    ViewData["AccountType"] = new SelectList(li_AccountType, "Value", "Text", model.AccountGeneralLedgerReportDTO.AccountType);
                    ViewData["ReportParameter"] = new SelectList(li_ReportParameter, "Value", "Text", model.AccountGeneralLedgerReportDTO.ReportParameter);
                    model.ListAccountNameReport = GetAccountList(model.AccountGeneralLedgerReportDTO.AccountType, string.Empty);
                    model.IsPosted = false;

                }
                else
                {
                    model.FromDate = _sessionFromDate;
                    model.ToDate = _sessionUptoDate;
                    model.AccountSessionID = _accountSessionID;
                    model.AccountID = _accountID;
                    model.AccountType = _accountType;
                    model.AccountName = _accountName;
                    model.AccountBalsheetMstID = _balanesheetMstID;
                    model.ReportParameter = _consolidiateType;
                    ViewData["AccountType"] = new SelectList(li_AccountType, "Value", "Text", model.AccountType);
                    ViewData["ReportParameter"] = new SelectList(li_ReportParameter, "Value", "Text", model.ReportParameter);
                    model.ListAccountNameReport = GetAccountList(_accountType, string.Empty);
                }


                return View("/Views/Accounts/Report/AccountGeneralLedgerReport/Index.cshtml", model);

            }
            catch (Exception)
            {

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


        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAccountByCashBankFlag(string AccountType)
        {
            var accountName = GetAccountList(AccountType, string.Empty);
            var result = (from s in accountName select new { id = s.ID, name = s.AccountName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<AccountGeneralLedgerReport> GetAccountGeneralLedgerReportData(string centreCode)
        {
            try
            {
                List<AccountGeneralLedgerReport> listAccountGeneralLedgerReport = new List<AccountGeneralLedgerReport>();
                if (_balanesheetMstID > 0)
                {
                    AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
                    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                    searchRequest.SessionFromDate = _sessionFromDate;
                    searchRequest.SessionUptoDate = _sessionUptoDate;
                    searchRequest.AccountID = _accountID;
                    searchRequest.AccountName = _accountName;
                    searchRequest.TransactionType = string.Empty;
                    searchRequest.AccBalsheetMstID = _balanesheetMstID;
                    searchRequest.AccountSessionID = _accountSessionID;
                    searchRequest.CentreCode = centreCode;
                    searchRequest.ConsolidiateType = _consolidiateType;
                    IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportBA.GetBySearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listAccountGeneralLedgerReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                    return listAccountGeneralLedgerReport;
                }
                else
                {
                    return listAccountGeneralLedgerReport;
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            finally
            {
                //_sessionFromDate = string.Empty;
                //_sessionUptoDate = string.Empty;
                //_accountID = 0;
                //_accountName = string.Empty;
                //_transactionTypeXml = string.Empty;
                //_accountSessionID = 0;
                //_balanesheetMstID = 0;
                //_consolidiateType = string.Empty;
            }
        }
        #endregion
    }
}