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
    public class InventoryLocationMasterController : BaseController
    {
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryLocationMasterController()
        {
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                return View("/Views/Inventory/InventoryLocationMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }


        }

        public ActionResult List(string actionMode, string centerCode)
        {
            try
            {
                InventoryLocationMasterViewModel model = new InventoryLocationMasterViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
                   
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                model.SelectedCentreCode = centerCode;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryLocationMaster/List.cshtml", model);
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
            InventoryLocationMasterViewModel model = new InventoryLocationMasterViewModel();
            return PartialView("/Views/Inventory/InventoryLocationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryLocationMasterViewModel model)
        {
            try
            {


                if (model != null && model.InventoryLocationMasterDTO != null)
                {
                    model.InventoryLocationMasterDTO.ConnectionString = _connectioString;
                    model.InventoryLocationMasterDTO.LocationName = model.LocationName;

                    string[] SplitedcenterCode = model.SelectedCentreCode.Split(':');
                    model.InventoryLocationMasterDTO.CentreCode = SplitedcenterCode[0];

                    // model.InventoryLocationMasterDTO.AccBalanceSheetID = model.AccBalanceSheetID;
                    model.InventoryLocationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryLocationMaster> response = _InventoryLocationMasterBA.InsertInventoryLocationMaster(model.InventoryLocationMasterDTO);
                    model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);

                }

                return Json("Please review your form");


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            InventoryLocationMasterViewModel model = new InventoryLocationMasterViewModel();
            try
            {
                model.InventoryLocationMasterDTO = new InventoryLocationMaster();
                model.InventoryLocationMasterDTO.ID = id;
                model.InventoryLocationMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryLocationMaster> response = _InventoryLocationMasterBA.SelectByID(model.InventoryLocationMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryLocationMasterDTO.ID = response.Entity.ID;
                    model.InventoryLocationMasterDTO.LocationName = response.Entity.LocationName;
                    // model.InventoryLocationMasterDTO.SeqNo = response.Entity.SeqNo;
                    // model.InventoryLocationMasterDTO.AccBalanceSheetID = response.Entity.AccBalanceSheetID;
                    // model.InventoryLocationMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.InventoryLocationMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/InventoryLocationMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(InventoryLocationMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryLocationMasterDTO != null)
                {
                    if (model != null && model.InventoryLocationMasterDTO != null)
                    {
                        model.InventoryLocationMasterDTO.ConnectionString = _connectioString;
                        model.InventoryLocationMasterDTO.ID = model.ID;
                        model.InventoryLocationMasterDTO.LocationName = model.LocationName;
                        model.InventoryLocationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryLocationMaster> response = _InventoryLocationMasterBA.UpdateInventoryLocationMaster(model.InventoryLocationMasterDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            InventoryLocationMasterViewModel model = new InventoryLocationMasterViewModel();
            model.InventoryLocationMasterDTO = new InventoryLocationMaster();
            model.InventoryLocationMasterDTO.ID = ID;
            return PartialView("/Views/Inventory/InventoryLocationMaster/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(InventoryLocationMasterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                if (model.ID > 0)
                {
                    InventoryLocationMaster InventoryLocationMasterDTO = new InventoryLocationMaster();
                    InventoryLocationMasterDTO.ConnectionString = _connectioString;
                    InventoryLocationMasterDTO.ID = model.ID;
                    InventoryLocationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryLocationMaster> response = _InventoryLocationMasterBA.DeleteInventoryLocationMaster(InventoryLocationMasterDTO);
                    model.InventoryLocationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.InventoryLocationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryLocationMaster> GetInventoryLocationMaster(string centreCode, out int TotalRecords)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            List<InventoryLocationMaster> listInventoryLocationMaster = new List<InventoryLocationMaster>();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    //searchRequest.CentreCode = Convert.ToString(Session["CentreCode"]);
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    //  searchRequest.CentreCode = Convert.ToString(Session["CentreCode"]);
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                // searchRequest.CentreCode = Convert.ToString(Session["CentreCode"]);
                string[] Centre_code = centreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
            }

            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryLocationMaster;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SelectedCentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<InventoryLocationMaster> filteredLocationMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "LocationName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "LocationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                        //case 1:
                        //    _sortBy = "CategoryCode";
                        //    if (string.IsNullOrEmpty(param.sSearch))
                        //    {
                        //        _searchBy = string.Empty;
                        //    }
                        //    else
                        //    {
                        //        _searchBy = "LocationName Like '%" + param.sSearch + "%' or CategoryCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        //    }
                        //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(SelectedCentreCode))
                {
                    filteredLocationMaster = GetInventoryLocationMaster(SelectedCentreCode, out TotalRecords);
                }
                else
                {
                    filteredLocationMaster = new List<InventoryLocationMaster>();
                    TotalRecords = 0;
                }

                if ((filteredLocationMaster.Count()) == 0)
                {
                    filteredLocationMaster = new List<InventoryLocationMaster>();
                    TotalRecords = 0;
                }

                var records = filteredLocationMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.LocationName.ToString(), c.AccBalanceSheetID.ToString(), Convert.ToString(c.ID) };

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