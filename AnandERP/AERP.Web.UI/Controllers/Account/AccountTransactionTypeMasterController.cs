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
    public class AccountTransactionTypeMasterController : BaseController
    {
        IAccountTransactionTypeMasterBA _AccountTransactionTypeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountTransactionTypeMasterController()
        {
            _AccountTransactionTypeMasterBA = new AccountTransactionTypeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Accounts/AccountTransactionTypeMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                AccountTransactionTypeMasterViewModel model = new AccountTransactionTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountTransactionTypeMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create()
        {
            AccountTransactionTypeMasterViewModel model = new AccountTransactionTypeMasterViewModel();

            return PartialView("/Views/Accounts/AccountTransactionTypeMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(AccountTransactionTypeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.AccountTransactionTypeMasterDTO != null)
                {
                    model.AccountTransactionTypeMasterDTO.ConnectionString = _connectioString;
                    model.AccountTransactionTypeMasterDTO.TransactionTypeCode = model.TransactionTypeCode;
                    model.AccountTransactionTypeMasterDTO.TransactionTypeName = model.TransactionTypeName;
                    model.AccountTransactionTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountTransactionTypeMaster> response = _AccountTransactionTypeMasterBA.InsertAccountTransactionTypeMaster(model.AccountTransactionTypeMasterDTO);

                    model.AccountTransactionTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.AccountTransactionTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    AccountTransactionTypeMasterViewModel model = new AccountTransactionTypeMasterViewModel();
        //    try
        //    {
        //        model.AccountTransactionTypeMasterDTO = new AccountTransactionTypeMaster();
        //        model.AccountTransactionTypeMasterDTO.ID = id;
        //        model.AccountTransactionTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<AccountTransactionTypeMaster> response = _AccountTransactionTypeMasterBA.SelectByID(model.AccountTransactionTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.AccountTransactionTypeMasterDTO.ID = response.Entity.ID;
        //            model.AccountTransactionTypeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.AccountTransactionTypeMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.AccountTransactionTypeMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

      
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            AccountTransactionTypeMasterViewModel model = new AccountTransactionTypeMasterViewModel();
            try
            {
                model.AccountTransactionTypeMasterDTO = new AccountTransactionTypeMaster();
                model.AccountTransactionTypeMasterDTO.ConnectionString = _connectioString;
                model.AccountTransactionTypeMasterDTO.AccountTransactionTypeMasterID = ID;

                IBaseEntityResponse<AccountTransactionTypeMaster> response = _AccountTransactionTypeMasterBA.SelectByID(model.AccountTransactionTypeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.AccountTransactionTypeMasterDTO.AccountTransactionTypeMasterID = response.Entity.AccountTransactionTypeMasterID;
                    model.AccountTransactionTypeMasterDTO.TransactionTypeCode= response.Entity.TransactionTypeCode;
                    model.AccountTransactionTypeMasterDTO.TransactionTypeName = response.Entity.TransactionTypeName;
                    model.AccountTransactionTypeMasterDTO.IsActive = response.Entity.IsActive;
              
                }
                return PartialView("/Views/Accounts/AccountTransactionTypeMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountTransactionTypeMasterViewModel model)
        {
            try
            {
                if (model != null && model.AccountTransactionTypeMasterDTO != null)
                {
                    model.AccountTransactionTypeMasterDTO.ConnectionString = _connectioString;
                    model.AccountTransactionTypeMasterDTO.AccountTransactionTypeMasterID = model.AccountTransactionTypeMasterID;
                   // model.AccountTransactionTypeMasterDTO.TransactionTypeCode = model.TransactionTypeCode;
                    model.AccountTransactionTypeMasterDTO.TransactionTypeName = model.TransactionTypeName;
                    //model.AccountTransactionTypeMasterDTO.IsActive = model.IsActive;


                    model.AccountTransactionTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountTransactionTypeMaster> response = _AccountTransactionTypeMasterBA.UpdateAccountTransactionTypeMaster(model.AccountTransactionTypeMasterDTO);
                    model.AccountTransactionTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.AccountTransactionTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
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


        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        AccountTransactionTypeMasterViewModel model = new AccountTransactionTypeMasterViewModel();
        //        model.AccountTransactionTypeMasterDTO = new AccountTransactionTypeMaster();
        //        model.AccountTransactionTypeMasterDTO.ID = Convert.ToInt16(ID);
        //        model.AccountTransactionTypeMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<AccountTransactionTypeMaster> response = _AccountTransactionTypeMasterBA.SelectByID(model.AccountTransactionTypeMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.AccountTransactionTypeMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.AccountTransactionTypeMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.AccountTransactionTypeMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.AccountTransactionTypeMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/AccountTransactionTypeMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<AccountTransactionTypeMaster> response = null;
                AccountTransactionTypeMaster AccountTransactionTypeMasterDTO = new AccountTransactionTypeMaster();
                AccountTransactionTypeMasterDTO.ConnectionString = _connectioString;
                AccountTransactionTypeMasterDTO.AccountTransactionTypeMasterID = Convert.ToInt32(ID);
                AccountTransactionTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _AccountTransactionTypeMasterBA.DeleteAccountTransactionTypeMaster(AccountTransactionTypeMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<AccountTransactionTypeMasterViewModel> GetAccountTransactionTypeMaster(out int TotalRecords)
        {
            AccountTransactionTypeMasterSearchRequest searchRequest = new AccountTransactionTypeMasterSearchRequest();
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
            List<AccountTransactionTypeMasterViewModel> listAccountTransactionTypeMasterViewModel = new List<AccountTransactionTypeMasterViewModel>();
            List<AccountTransactionTypeMaster> listAccountTransactionTypeMaster = new List<AccountTransactionTypeMaster>();
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> baseEntityCollectionResponse = _AccountTransactionTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AccountTransactionTypeMaster item in listAccountTransactionTypeMaster)
                    {
                        AccountTransactionTypeMasterViewModel AccountTransactionTypeMasterViewModel = new AccountTransactionTypeMasterViewModel();
                        AccountTransactionTypeMasterViewModel.AccountTransactionTypeMasterDTO = item;
                        listAccountTransactionTypeMasterViewModel.Add(AccountTransactionTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountTransactionTypeMasterViewModel;
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

                IEnumerable<AccountTransactionTypeMasterViewModel> filteredGroupDescription;
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
                filteredGroupDescription = GetAccountTransactionTypeMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.TransactionTypeCode), Convert.ToString(c.TransactionTypeName),Convert.ToString(c.IsActive), Convert.ToString(c.AccountTransactionTypeMasterID) };

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