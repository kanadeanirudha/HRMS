using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class AccountYearEndJobController : BaseController
    {
        IAccountSessionMasterBA _AccountSessionMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountYearEndJobController()
        {
            _AccountSessionMasterServiceAcess = new AccountSessionMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
            model.AccountSessionMasterDTO.ConnectionString = _connectioString;
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByFinanceManager(AdminRoleMasterID);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            model.CentreListXML = GetCentreListXML;

            model.GetBalncesheetList = GetBalncesheetList(model.CentreListXML);

            IBaseEntityResponse<AccountSessionMaster> response = _AccountSessionMasterServiceAcess.GetCurrentAccountSession_AccountYearEnd(model.AccountSessionMasterDTO);
            if (response != null && response.Entity != null)
            {
                model.AccountSessionMasterDTO.CurrenntSessionYearFromDatetime = response.Entity.CurrenntSessionYearFromDatetime;
                model.AccountSessionMasterDTO.CurrenntSessionYearUptoDatetime = response.Entity.CurrenntSessionYearUptoDatetime;
                model.AccountSessionMasterDTO.NextSessionYearFromDatetime = response.Entity.NextSessionYearFromDatetime;
                model.AccountSessionMasterDTO.NextSessionYearUptoDatetime = response.Entity.NextSessionYearUptoDatetime;
                model.AccountSessionMasterDTO.CurrentYearSessionID = response.Entity.CurrentYearSessionID;
                model.AccountSessionMasterDTO.NextYearSessionID = response.Entity.NextYearSessionID;
                model.AccountSessionMasterDTO.OutPutFlag = response.Entity.OutPutFlag;


            }

            return View("/Views/Accounts/AccountYearEndJob/Index.cshtml", model);

        }
        [HttpPost]
        public ActionResult Create(AccountSessionMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.AccountSessionMasterDTO != null)
                {
                    model.AccountSessionMasterDTO.ConnectionString = _connectioString;
                    model.AccountSessionMasterDTO.CurrentYearSessionID = model.CurrentYearSessionID;
                    model.AccountSessionMasterDTO.CurrenntSessionYearFromDatetime = model.CurrenntSessionYearFromDatetime;
                    model.AccountSessionMasterDTO.CurrenntSessionYearUptoDatetime = model.CurrenntSessionYearUptoDatetime;

                    model.AccountSessionMasterDTO.NextYearSessionID = model.NextYearSessionID;
                    model.AccountSessionMasterDTO.NextSessionYearFromDatetime = model.NextSessionYearFromDatetime;
                    model.AccountSessionMasterDTO.NextSessionYearUptoDatetime = model.NextSessionYearUptoDatetime;
                    model.AccountSessionMasterDTO.OutPutFlag = model.OutPutFlag;
                    model.AccountSessionMasterDTO.IsCarryForward = model.IsCarryForward;
                    model.AccountSessionMasterDTO.CentreListXML = model.CentreListXML;

                    if (model.OutPutFlag==1 && model.IsCarryForward ==false)
                    {
                        model.AccountSessionMasterDTO.YearEndTypeFlag = 0;
                    }
                    else if (model.OutPutFlag == 1 && model.IsCarryForward == true)
                    {
                        model.AccountSessionMasterDTO.YearEndTypeFlag = 1;
                    }
                    else if (model.OutPutFlag == 2 && model.IsCarryForward == true)
                    {
                        model.AccountSessionMasterDTO.YearEndTypeFlag = 2;
                    }
                    model.AccountSessionMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountSessionMaster> response = _AccountSessionMasterServiceAcess.InsertAccountYearEndJob(model.AccountSessionMasterDTO);

                    model.AccountSessionMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.AccountSessionMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #endregion

        // Non-Action Method
        #region Methods

        protected List<AccountSessionMaster> GetBalncesheetList(string CentreListXML)
        {
            AccountSessionMasterSearchRequest searchRequest = new AccountSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreListXML = CentreListXML;
            List<AccountSessionMaster> listGeneralTaxMaster = new List<AccountSessionMaster>();
            IBaseEntityCollectionResponse<AccountSessionMaster> baseEntityCollectionResponse = _AccountSessionMasterServiceAcess.GetCentreWiseBalncesheetForYearEndJobList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.AccBalsheetHeadDesc).ToList();
                }
            }
            return listGeneralTaxMaster;
        }
        public IEnumerable<AccountSessionMasterViewModel> GetAccountSessionMaster(out int TotalRecords)
        {
            AccountSessionMasterSearchRequest searchRequest = new AccountSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<AccountSessionMasterViewModel> listAccountSessionMasterViewModel = new List<AccountSessionMasterViewModel>();
            List<AccountSessionMaster> listAccountSessionMaster = new List<AccountSessionMaster>();
            IBaseEntityCollectionResponse<AccountSessionMaster> baseEntityCollectionResponse = _AccountSessionMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AccountSessionMaster item in listAccountSessionMaster)
                    {
                        AccountSessionMasterViewModel AccountSessionMasterViewModel = new AccountSessionMasterViewModel();
                        AccountSessionMasterViewModel.AccountSessionMasterDTO = item;
                        listAccountSessionMasterViewModel.Add(AccountSessionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountSessionMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<AccountSessionMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TransactionTypeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.TransactionTypeName Like '%" + param.sSearch + "%' or A.TransactionTypeCode Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.TransactionTypeCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.TransactionTypeCode Like '%" + param.sSearch + "%' or A.TransactionTypeName Like '%" + param.sSearch + "%'"; //this "if" block is added for search functionality
                        }
                        break;
                }
                //case 1:
                //    _sortBy = "A.AttributeName";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        // _searchBy = "A.MarchandiseGroupCode like '%'";
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                //        _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.AttributeName Like '%" + param.sSearch + "%'";
                //    }
                //    break;

                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetAccountSessionMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CurrenntSessionYearFromDatetime), Convert.ToString(c.CurrenntSessionYearUptoDatetime), Convert.ToString(c.NextSessionYearFromDatetime), Convert.ToString(c.NextSessionYearUptoDatetime) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}