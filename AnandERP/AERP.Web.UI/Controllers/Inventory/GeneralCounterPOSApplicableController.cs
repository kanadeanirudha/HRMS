using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class GeneralCounterPOSApplicableController : BaseController
    {
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        IGeneralCounterPOSAndPosOperatorServiceAccess _GeneralCounterPOSAndPosOperatorServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralCounterPOSApplicableController()
        {
            _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
            _GeneralCounterPOSAndPosOperatorServiceAccess = new GeneralCounterPOSAndPosOperatorServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/GeneralCounterPOSApplicable/Index.cshtml");

        }

        public ActionResult List(string CentreCode,string actionMode)
        {
            try
            {
                GeneralCounterPOSAndPosOperatorViewModel model = new GeneralCounterPOSAndPosOperatorViewModel();
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
                    a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                }
                model.GeneralCounterPOSAndPosOperatorDTO.CentreCode = CentreCode;

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }



                return PartialView("/Views/Inventory_1/GeneralCounterPOSApplicable/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string CentreCode)
        {
            GeneralCounterPOSAndPosOperatorViewModel model = new GeneralCounterPOSAndPosOperatorViewModel();
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
                    a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }

                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                }
                model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);

                //*******************************************************************************************************

                List<GeneralCounterPOSAndPosOperator> CounterMaster = GetListCounterMaster();
                List<SelectListItem> CounterMasterList = new List<SelectListItem>();
                foreach (GeneralCounterPOSAndPosOperator item in CounterMaster)
                {
                    CounterMasterList.Add(new SelectListItem { Text = item.GeneralCounterMasterName, Value = Convert.ToString(item.GeneralCounterMasterId) });
                }
                ViewBag.CounterMasterList = new SelectList(CounterMasterList, "Value", "Text");

                //*******************************************************************************************************

                List<GeneralCounterPOSAndPosOperator> POSMaster = GetListPOSMaster();
                List<SelectListItem> POSMasterList = new List<SelectListItem>();
                foreach (GeneralCounterPOSAndPosOperator item in POSMaster)
                {
                    POSMasterList.Add(new SelectListItem { Text = item.GeneralPOSMasterDeviceCode, Value = Convert.ToString(item.GeneralPOSMasterId) });
                }
                ViewBag.POSMasterList = new SelectList(POSMasterList, "Value", "Text");

                return PartialView("/Views/Inventory_1/GeneralCounterPOSApplicable/Create.cshtml", model);
            
        }

        [HttpPost]
        public ActionResult Create(GeneralCounterPOSAndPosOperatorViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralCounterPOSAndPosOperatorDTO != null)
                {
                    model.GeneralCounterPOSAndPosOperatorDTO.ConnectionString = _connectioString;
                    model.GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterId = model.GeneralCounterMasterId;
                    model.GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterId = model.GeneralPOSMasterId;
                    model.GeneralCounterPOSAndPosOperatorDTO.DateFrom = model.DateFrom;
                    model.GeneralCounterPOSAndPosOperatorDTO.DateUpto = model.DateUpto;
                    model.GeneralCounterPOSAndPosOperatorDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralCounterPOSAndPosOperator> response = _GeneralCounterPOSAndPosOperatorServiceAccess.InsertGeneralCounterPOSAndPosOperator(model.GeneralCounterPOSAndPosOperatorDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.GeneralCounterPOSAndPosOperatorDTO.errorMessage = "Cannot allocate POS to Counter,warning";
                    }
                    else
                    {
                        model.GeneralCounterPOSAndPosOperatorDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralCounterPOSAndPosOperatorDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralCounterPOSAndPosOperator> response = null;
                GeneralCounterPOSAndPosOperatorViewModel model = new GeneralCounterPOSAndPosOperatorViewModel();
              //  GeneralCounterPOSAndPosOperator GeneralCounterPOSAndPosOperatorDTO = new GeneralCounterPOSAndPosOperator();
                model.GeneralCounterPOSAndPosOperatorDTO.ConnectionString = _connectioString;
                model.GeneralCounterPOSAndPosOperatorDTO.ID = ID;
                model.GeneralCounterPOSAndPosOperatorDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralCounterPOSAndPosOperatorServiceAccess.DeleteGeneralCounterPOSAndPosOperator(model.GeneralCounterPOSAndPosOperatorDTO);
               string errorMessageDis = string.Empty;
                string colorCode = string.Empty;
                string mode = string.Empty;
                if (response.Entity.ErrorCode == 77)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "danger";
                }
                else if (response.Entity.ErrorCode == 0)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "success";
                }
                string[] arrayList = { errorMessageDis, colorCode, mode };
                errorMessage = string.Join(",", arrayList);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id,string CentreCode)
        {
            GeneralCounterPOSAndPosOperatorViewModel model = new GeneralCounterPOSAndPosOperatorViewModel();
            try
            {
                
                model.GeneralCounterPOSAndPosOperatorDTO = new GeneralCounterPOSAndPosOperator();
                model.GeneralCounterPOSAndPosOperatorDTO.ID = Convert.ToInt16(id);
                model.GeneralCounterPOSAndPosOperatorDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralCounterPOSAndPosOperator> response = _GeneralCounterPOSAndPosOperatorServiceAccess.SelectByID(model.GeneralCounterPOSAndPosOperatorDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsID = response.Entity.GeneralUnitsID;
                    model.GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterId = response.Entity.GeneralCounterMasterId;
                    model.GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterId = response.Entity.GeneralPOSMasterId;
                    model.GeneralCounterPOSAndPosOperatorDTO.DateUpto = response.Entity.DateUpto;
                    model.GeneralCounterPOSAndPosOperatorDTO.CreatedBy = response.Entity.CreatedBy;

                }

                List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
                List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
                foreach (GeneralUnits item in GeneralUnits)
                {
                    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text",response.Entity.GeneralUnitsID);

                //*******************************************************************************************************

                List<GeneralCounterPOSAndPosOperator> CounterMaster = GetListCounterMaster();
                List<SelectListItem> CounterMasterList = new List<SelectListItem>();
                foreach (GeneralCounterPOSAndPosOperator item in CounterMaster)
                {
                    CounterMasterList.Add(new SelectListItem { Text = item.GeneralCounterMasterName, Value = Convert.ToString(item.GeneralCounterMasterId) });
                }
                ViewBag.CounterMasterList = new SelectList(CounterMasterList, "Value", "Text",response.Entity.GeneralCounterMasterId);

                //*******************************************************************************************************

                List<GeneralCounterPOSAndPosOperator> POSMaster = GetListPOSMaster();
                List<SelectListItem> POSMasterList = new List<SelectListItem>();
                foreach (GeneralCounterPOSAndPosOperator item in POSMaster)
                {
                    POSMasterList.Add(new SelectListItem { Text = item.GeneralPOSMasterDeviceCode, Value = Convert.ToString(item.GeneralPOSMasterId) });
                }
                ViewBag.POSMasterList = new SelectList(POSMasterList, "Value", "Text", response.Entity.GeneralPOSMasterId);

                return PartialView("/Views/Inventory_1/GeneralCounterPOSApplicable/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralCounterPOSAndPosOperatorViewModel model)
        {
           
                if (model != null && model.GeneralCounterPOSAndPosOperatorDTO != null)
                {
                    if (model != null && model.GeneralCounterPOSAndPosOperatorDTO != null)
                    {
                        model.GeneralCounterPOSAndPosOperatorDTO.ConnectionString = _connectioString;
                        model.GeneralCounterPOSAndPosOperatorDTO.ID = model.ID;
                        model.GeneralCounterPOSAndPosOperatorDTO.DateUpto = model.DateUpto;
                        model.GeneralCounterPOSAndPosOperatorDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCounterPOSAndPosOperator> response = _GeneralCounterPOSAndPosOperatorServiceAccess.UpdateGeneralCounterPOSAndPosOperator(model.GeneralCounterPOSAndPosOperatorDTO);
                        model.GeneralCounterPOSAndPosOperatorDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.GeneralCounterPOSAndPosOperatorDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(model, JsonRequestBehavior.AllowGet);
        }



        #endregion

        // Non-Action Method
        #region Methods
        public ActionResult GetGeneralUnitsForItemmasterList(string CentreCode)
        {

            var UOMCodeDesc = GetGeneralUnitsForItemmaster(CentreCode);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitName

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        //Dropdown for General Item Merchantise Department
        protected List<GeneralCounterPOSAndPosOperator> GetListCounterMaster()
        {
            GeneralCounterPOSAndPosOperatorSearchRequest searchRequest = new GeneralCounterPOSAndPosOperatorSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCounterPOSAndPosOperator> ListCounterMaster = new List<GeneralCounterPOSAndPosOperator>();
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> baseEntityCollectionResponse = _GeneralCounterPOSAndPosOperatorServiceAccess.GetListCounterMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListCounterMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListCounterMaster;
        }


        protected List<GeneralCounterPOSAndPosOperator> GetListPOSMaster()
        {
            GeneralCounterPOSAndPosOperatorSearchRequest searchRequest = new GeneralCounterPOSAndPosOperatorSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCounterPOSAndPosOperator> ListPOSMaster = new List<GeneralCounterPOSAndPosOperator>();
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> baseEntityCollectionResponse = _GeneralCounterPOSAndPosOperatorServiceAccess.GetListPOSMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListPOSMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListPOSMaster;
        }

        public IEnumerable<GeneralCounterPOSAndPosOperatorViewModel> GetGeneralCounterPOSApplicable(string CentreCode, out int TotalRecords)
        {
            GeneralCounterPOSAndPosOperatorSearchRequest searchRequest = new GeneralCounterPOSAndPosOperatorSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
            }
            List<GeneralCounterPOSAndPosOperatorViewModel> listGeneralCounterPOSApplicableViewModel = new List<GeneralCounterPOSAndPosOperatorViewModel>();
            List<GeneralCounterPOSAndPosOperator> listGeneralCounterPOSApplicable = new List<GeneralCounterPOSAndPosOperator>();
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> baseEntityCollectionResponse = _GeneralCounterPOSAndPosOperatorServiceAccess.GetGeneralCounterPOSApplicableBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCounterPOSApplicable = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralCounterPOSAndPosOperator item in listGeneralCounterPOSApplicable)
                    {
                        GeneralCounterPOSAndPosOperatorViewModel GeneralCounterPOSAndPosOperatorViewModel = new GeneralCounterPOSAndPosOperatorViewModel();
                        GeneralCounterPOSAndPosOperatorViewModel.GeneralCounterPOSAndPosOperatorDTO = item;
                        listGeneralCounterPOSApplicableViewModel.Add(GeneralCounterPOSAndPosOperatorViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralCounterPOSApplicableViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralCounterPOSAndPosOperatorViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.UnitName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.UnitName Like '%" + param.sSearch + "%' or C.CounterName Like '%" + param.sSearch + "%' or  D.DeviceCode Like '%" + param.sSearch + "%' or A.DateFrom Like '%" + param.sSearch + "%'";  
                        }
                        break;
                    case 1:
                        _sortBy = "C.CounterName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.UnitName Like '%" + param.sSearch + "%' or C.CounterName Like '%" + param.sSearch + "%' or  D.DeviceCode Like '%" + param.sSearch + "%' or A.DateFrom Like '%" + param.sSearch + "%'";  
                        }
                        break;
                    case 2:
                        _sortBy = "D.DeviceCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.UnitName Like '%" + param.sSearch + "%' or C.CounterName Like '%" + param.sSearch + "%' or  D.DeviceCode Like '%" + param.sSearch + "%' or A.DateFrom Like '%" + param.sSearch + "%'";  
                        }
                        break;
                    case 3:
                        _sortBy = "A.DateFrom";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.UnitName Like '%" + param.sSearch + "%' or C.CounterName Like '%" + param.sSearch + "%' or  D.DeviceCode Like '%" + param.sSearch + "%' or A.DateFrom Like '%" + param.sSearch + "%'";  
                        }
                        break;
                    case 4:
                        _sortBy = "A.DateUpto";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "B.UnitName Like '%" + param.sSearch + "%' or C.CounterName Like '%" + param.sSearch + "%' or  D.DeviceCode Like '%" + param.sSearch + "%' or A.DateUpto Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    CentreCode = splitCentreCode[0];
                }
                filteredGroupDescription = GetGeneralCounterPOSApplicable(CentreCode,out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.GeneralUnitsName), Convert.ToString(c.GeneralCounterMasterName), Convert.ToString(c.GeneralPOSMasterDeviceCode), Convert.ToString(c.DateFrom), Convert.ToString(c.DateUpto), Convert.ToString(c.IsCurrent) };

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