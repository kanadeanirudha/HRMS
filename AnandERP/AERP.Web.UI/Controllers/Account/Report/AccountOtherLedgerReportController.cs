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
    public class AccountOtherLedgerReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountGeneralLedgerReportBA _accountGeneralLedgerReportBA = null;

        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static string _sessionFromDate = string.Empty;
        protected static string _sessionUptoDate = string.Empty;
        protected static int _accountID;
        protected static int _personID;
        protected static string _personName = string.Empty;
        protected static string _personType = string.Empty;
        protected static string _accountName = string.Empty;
        protected static int _balanesheetMstID;
        protected static int _accountSessionID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountOtherLedgerReportController()
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
                    model.UserTypeList = GetUserTypeMaster();
                    model.ListAccountNameReport = GetAccountList(string.Empty, "S");
                    return View("/Views/Accounts/Report/AccountOtherLedgerReport/Index.cshtml", model);
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

                model.ListIndividualAccountNameReport = GetPersonNameListByPersonTypeAndAccountId(model.AccountGeneralLedgerReportDTO.AccountID, model.AccountGeneralLedgerReportDTO.AccountBalsheetMstID, model.AccountGeneralLedgerReportDTO.ControlHead);

                ///Allocate selected parameters to local variables

                if (model.IsPosted == true)
                {

                    /// Allocate parameters to local variable
                    _sessionFromDate = model.FromDate;
                    _sessionUptoDate = model.ToDate;
                    _accountSessionID = model.AccountSessionID;
                    _accountID = model.AccountID;
                    _accountName = model.AccountName;
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    _personID = model.IndividualAccountID;
                    _personName = model.PersonName;
                    _personType = model.ControlHead;
                    model.IsPosted = false;

                }
                else
                {
                    model.FromDate = _sessionFromDate;
                    model.ToDate = _sessionUptoDate;
                    model.AccountSessionID = _accountSessionID;
                    model.AccountID = _accountID;
                    model.AccountName = _accountName;
                    model.AccountBalsheetMstID = _balanesheetMstID;
                    model.IndividualAccountID = _personID;
                    model.PersonName = _personName;
                    model.ControlHead = _personType;

                }

                return View("/Views/Accounts/Report/AccountOtherLedgerReport/Index.cshtml", model);
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
            try
            {
                List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
                listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(_centreCode, _balanesheetMstID);
                return listOrganisationStudyCentreMaster;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        protected List<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(int AccountID, int AccBalsheetMstID, string PersonType)
        {
            try
            {
                AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                List<AccountGeneralLedgerReport> listAccountGeneralLedgerReport = new List<AccountGeneralLedgerReport>();
                searchRequest.AccountID = AccountID;
                searchRequest.PersonType = PersonType;
                searchRequest.AccBalsheetMstID = AccBalsheetMstID;
                IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportBA.GetPersonNameListByPersonTypeAndAccountId(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountGeneralLedgerReport = baseEntityCollectionResponse.CollectionResponse.ToList();

                    }
                }
                return listAccountGeneralLedgerReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAccountByCashBankFlag(string PersonType)
        {
            try
            {
                if (String.IsNullOrEmpty(PersonType))
                {
                    throw new ArgumentNullException("PersonType");
                }
                int id = 0;
                bool isValid = Int32.TryParse(PersonType, out id);
                var accountName = GetAccountList(string.Empty, PersonType);
                var result = (from s in accountName
                              select new
                              {
                                  id = s.ID,
                                  name = s.AccountName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetPersonNameByPersonTypeAndAccountId(int AccountID, int AccBalsheetMstID, string PersonType)
        {
            try
            {
                if (String.IsNullOrEmpty(PersonType))
                {
                    throw new ArgumentNullException("PersonType");
                }

                var PersonNameWithIndividualID = GetPersonNameListByPersonTypeAndAccountId(AccountID, AccBalsheetMstID, PersonType);
                var result = (from s in PersonNameWithIndividualID
                              select new
                              {
                                  id = s.PersonID,
                                  name = s.PersonName,
                              }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public List<AccountGeneralLedgerReport> GetAccountOtherLedgerReportData(string centreCode)
        {
            try
            {
                List<AccountGeneralLedgerReport> listAccountGeneralLedgerReport = new List<AccountGeneralLedgerReport>();
                if (_balanesheetMstID > 0 && _accountID > 0 && _personID > 0 && centreCode != string.Empty)
                {
                    AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
                    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                    searchRequest.SessionFromDate = _sessionFromDate;
                    searchRequest.SessionUptoDate = _sessionUptoDate;
                    searchRequest.AccountID = _accountID;
                    searchRequest.AccountName = _accountName;
                    searchRequest.PersonName = _personName;
                    searchRequest.PersonType = _personType;
                    searchRequest.PersonID = _personID;
                    searchRequest.AccBalsheetMstID = _balanesheetMstID;
                    searchRequest.AccountSessionID = _accountSessionID;
                    searchRequest.CentreCode = centreCode;

                    IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportBA.GetOtherLedgerBySearch(searchRequest);
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
                _sessionFromDate = string.Empty;
                _sessionUptoDate = string.Empty;
                _accountID = 0;
                _accountName = string.Empty;
                _accountSessionID = 0;
                _balanesheetMstID = 0;
                _personID = 0;
                _personType = string.Empty;
            }
        }
        #endregion
    }
}