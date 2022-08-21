using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ViewModel;
using System;
using AMS.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using System.IO;

namespace AMS.Web.UI.Controllers
{
    public class AccountStudentPersonalLedgerReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountGeneralLedgerReportServiceAccess _accountGeneralLedgerReportServiceAccessServiceAccess = null;

        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountStudentPersonalLedgerReportController()
        {
            _accountGeneralLedgerReportServiceAccessServiceAccess = new AccountGeneralLedgerReportServiceAccess();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        [HttpGet]
        public ActionResult Index()
        {
            try
            {

                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                    AccountGeneralLedgerReportViewModel model = new AccountGeneralLedgerReportViewModel();
                  
                    model.ListIndividualAccountNameReport = GetPersonNameListByPersonTypeAndAccountId(model.AccountGeneralLedgerReportDTO.AccountID, "S");

                    return View("/Views/Accounts/AccountStudentPersonalLedgerReport/Index.cshtml", model);
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

                if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
                {
                    _balanesheetMstID = model.AccountBalsheetMstID;
                    model.ListIndividualAccountNameReport = GetPersonNameListByPersonTypeAndAccountId(model.AccountGeneralLedgerReportDTO.AccountID, "S");

                    return View("/Views/Accounts/AccountStudentPersonalLedgerReport/Index.cshtml", model);
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
        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(_centreCode,_balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }
        protected List<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(int AccountID, string PersonType)
        {

            AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountGeneralLedgerReport> listAccountGeneralLedgerReport = new List<AccountGeneralLedgerReport>();
            searchRequest.AccountID = AccountID;
            searchRequest.PersonType = PersonType;
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportServiceAccessServiceAccess.GetPersonNameListByPersonTypeAndAccountId(searchRequest);
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
            //OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();

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



        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetPersonNameByPersonTypeAndAccountId(int AccountID, string PersonType)
        {
            //OrganisationSyllabusGroupMasterViewModel model = new OrganisationSyllabusGroupMasterViewModel();

            if (String.IsNullOrEmpty(PersonType))
            {
                throw new ArgumentNullException("PersonType");
            }
            //   int id = 0;
            // bool isValid = Int32.TryParse(PersonType, out id);
            var PersonNameWithIndividualID = GetPersonNameListByPersonTypeAndAccountId(AccountID, PersonType);
            var result = (from s in PersonNameWithIndividualID
                          select new
                          {
                              id = s.IndividualOpeningBalanceID,
                              name = s.PersonName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<AccountGeneralLedgerReport> GetAccountDetailsForReport()
        {
            try
            {
                List<AccountGeneralLedgerReport> listaccountDayBookReport = new List<AccountGeneralLedgerReport>();
                AccountGeneralLedgerReportSearchRequest searchRequest = new AccountGeneralLedgerReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                Session["SuperUser"].ToString();
                if (Convert.ToInt32(Session["BalancesheetID"]) > 0)
                {
                    // searchRequest.AccBalsheetMstID = Convert.ToInt16(Session["BalancesheetID"]);

                    IBaseEntityCollectionResponse<AccountGeneralLedgerReport> baseEntityCollectionResponse = _accountGeneralLedgerReportServiceAccessServiceAccess.GetBySearch(searchRequest);
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
            finally
            {
                _balanesheetMstID = 0;
            }

        }
        #endregion
    }
}