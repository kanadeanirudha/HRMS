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
    public class AccountIndividualBalanceReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountGeneralLedgerReportBA _accountGeneralLedgerReportBABA = null;

        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        protected static string _sessionFromDate = string.Empty;
        protected static string _sessionUptoDate = string.Empty;
        protected static int _accountId;
        protected static string _accountName = string.Empty;
        protected static string _personTypeName = string.Empty;
        protected static int _accSessionId;
        protected static string _personType = string.Empty;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountIndividualBalanceReportController()
        {
            _accountGeneralLedgerReportBABA = new AccountGeneralLedgerReportBA();
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
                    model.UserTypeList = GetUserTypeMaster();
                    model.ListAccountNameReport = GetAccountList(string.Empty, "S");
                    return View("/Views/Accounts/Report/AccountIndividualBalanceReport/Index.cshtml", model);
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
        public ActionResult Index(AccountGeneralLedgerReportViewModel model)
        {
            try
            {
                model.ListAccountSessionMasterReport = GetAllAccountSession();
                model.UserTypeList = GetUserTypeMaster();
                model.ListAccountNameReport = GetAccountList(string.Empty, model.AccountGeneralLedgerReportDTO.ControlHead);

                if (model.IsPosted == true)
                {
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    _sessionFromDate = model.FromDate;
                    _sessionUptoDate = model.ToDate;
                    _accountId = model.AccountID;
                    _accountName = model.AccountName;
                    _personTypeName = model.PersonTypeName;
                    _accSessionId = model.AccountSessionID;
                    _personType = model.ControlHead;
                    model.IsPosted = false;
                }
                else
                {
                    model.AccountBalsheetMstID = _balanesheetMstID  ;
                    model.FromDate =_sessionFromDate;
                    model.ToDate = _sessionUptoDate  ;
                    model.AccountID = _accountId  ;
                    model.AccountName = _accountName  ;
                    model.PersonTypeName = _personTypeName  ;
                    model.AccountSessionID = _accSessionId  ;
                    model.ControlHead = _personType;
                }
                return View("/Views/Accounts/Report/AccountIndividualBalanceReport/Index.cshtml", model);
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

        protected List<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(int AccountID, string PersonType)
        {

            AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountGeneralLedgerReport> listAccountGeneralLedgerReport = new List<AccountGeneralLedgerReport>();
            searchRequest.AccountID = AccountID;
            searchRequest.PersonType = PersonType;
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportBABA.GetPersonNameListByPersonTypeAndAccountId(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountGeneralLedgerReport = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAccountGeneralLedgerReport;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAccountByCashBankFlag(string PersonType)
        {
            if (String.IsNullOrEmpty(PersonType))
            {
                throw new ArgumentNullException("PersonType");
            }
            int id = 0;
            bool isValid = Int32.TryParse(PersonType, out id);
            var accountName = GetAccountList(string.Empty, PersonType);
            var result = (from s in accountName select new { id = s.ID, name = s.AccountName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<AccountGeneralLedgerReport> GetAccountDetailsForReport()
        {
            try
            {
                List<AccountGeneralLedgerReport> listaccountDayBookReport = new List<AccountGeneralLedgerReport>();
                AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_balanesheetMstID > 0 && _sessionFromDate != string.Empty && _sessionUptoDate != string.Empty && _accountId != 0 && _accSessionId != 0 && _personType != string.Empty)
                {
                    searchRequest.AccBalsheetMstID = _balanesheetMstID;
                    searchRequest.SessionFromDate = _sessionFromDate;
                    searchRequest.SessionUptoDate = _sessionUptoDate;
                    searchRequest.AccountID = _accountId;
                    searchRequest.AccountSessionID = _accSessionId;
                    searchRequest.PersonType = _personType;
                    searchRequest.AccountName = _accountName;
                    searchRequest.PersonTypeName = _personTypeName;
                    IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportBABA.GetByIndividualBalanceReportSearch(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listaccountDayBookReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
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