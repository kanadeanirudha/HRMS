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
using System.Web.Mvc.Ajax;
//using Microsoft.Reporting.WebForms;
using System.IO;

namespace AERP.Web.UI.Controllers
{
    public class AccountCategoryMasterReportController : BaseController, IDisposable
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountCategoryMasterReportBA _accountCategoryMasterReportBA = null;
        IAccountHeadMasterReportBA _accountHeadMasterReportBA = null;
        private readonly ILogger _logException;
        protected static int _headID;
        protected static int _categoryID;
        protected static string _centreCode = "";
        protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountCategoryMasterReportController()
        {
            _accountCategoryMasterReportBA = new AccountCategoryMasterReportBA();
            _accountHeadMasterReportBA = new AccountHeadMasterReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                AccountCategoryMasterReportViewModel model = new AccountCategoryMasterReportViewModel();
                model.ListAccountHeadMasterReport = GetListAccountHeadMaster();
                return View("/Views/Accounts/Report/AccountCategoryMasterReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        [HttpPost]
        public ActionResult Index(AccountCategoryMasterReportViewModel model)//string SelectedHeadID, string SelectedCategoryID)
        {
            model.ListAccountHeadMasterReport = GetListAccountHeadMaster();
            model.ListAccountCategoryMasterReport = GetCategoryList(Convert.ToInt32(model.SelectedHeadID));

            if (model.IsPosted == true)
            {
                _headID = Convert.ToInt32(model.SelectedHeadID);
                _categoryID = Convert.ToInt32(model.SelectedCategoryID);
                _balanesheetMstID = model.AccBalsheetMstId;
                model.IsPosted = false;

            }
            else
            {
                model.SelectedHeadID = Convert.ToString(_headID);
                model.SelectedCategoryID = Convert.ToString(_categoryID);
                model.AccBalsheetMstId = _balanesheetMstID;
            }
            return View("/Views/Accounts/Report/AccountCategoryMasterReport/Index.cshtml", model);
        }


        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        [NonAction]
        public List<AccountHeadMasterReport> GetListAccountHeadMaster()
        {
            List<AccountHeadMasterReport> listAccountHeadMaster = new List<AccountHeadMasterReport>();
            AccountHeadMasterReportSearchRequest searchRequest = new AccountHeadMasterReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            IBaseEntityCollectionResponse<AccountHeadMasterReport> baseEntityCollectionResponse = _accountHeadMasterReportBA.GetAccountHeadMasterReportBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountHeadMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountHeadMaster;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCategoryAccountHeadWise(int SelectedHeadID)
        {
            try
            {
                var category = GetCategoryList(SelectedHeadID);
                var result = (from s in category select new { id = s.ID, name = s.CategoryDescription, }).ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public List<AccountCategoryMasterReport> GetCategoryList(int headID)
        {
            List<AccountCategoryMasterReport> listAccountCategoryMasterReport = new List<AccountCategoryMasterReport>();
            AccountCategoryMasterReportSearchRequest searchRequest = new AccountCategoryMasterReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.HeadID = headID;
            IBaseEntityCollectionResponse<AccountCategoryMasterReport> baseEntityCollectionResponse = _accountCategoryMasterReportBA.GetCategoryList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountCategoryMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountCategoryMasterReport;
        }

        public List<AccountCategoryMasterReport> GetCategoryDetailsForReport()
        {
            try
            {
                List<AccountCategoryMasterReport> listAccountCategoryMasterReport = new List<AccountCategoryMasterReport>();
                AccountCategoryMasterReportSearchRequest searchRequest = new AccountCategoryMasterReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                //if (_headID > 0 && _categoryID > 0)
                //{
                searchRequest.HeadID = _headID;
                searchRequest.ID = _categoryID;
                IBaseEntityCollectionResponse<AccountCategoryMasterReport> baseEntityCollectionResponse = _accountCategoryMasterReportBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAccountCategoryMasterReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                //}
                return listAccountCategoryMasterReport;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _headID = 0;
                _categoryID = 0;
                //    _balanesheetMstID = 0;
            }

        }


        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();

            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(_centreCode, _balanesheetMstID);


            return listOrganisationStudyCentreMaster;
        }
        #endregion



    }
}
