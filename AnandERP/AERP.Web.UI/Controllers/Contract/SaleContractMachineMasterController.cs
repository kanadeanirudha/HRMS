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

namespace AERP.Web.UI.Controllers
{
    public class SaleContractMachineMasterController : BaseController
    {
        ISaleContractMachineMasterBA _SaleContractMachineMasterBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;

        string _centreCode = string.Empty;
        string _designationId = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractMachineMasterController()
        {
            _SaleContractMachineMasterBA = new SaleContractMachineMasterBA();
            _generalItemMasterBA = new GeneralItemMasterBA();

        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["Sales Manager"]) > 0 && IsApplied == true))
            {
                SaleContractMachineMasterViewModel _SaleContractMachineMasterViewModel = new SaleContractMachineMasterViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listSaleContractMachineMaster = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listSaleContractMachineMaster)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _SaleContractMachineMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
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

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableCentre = GetAdminRoleApplicableCentreBySalesManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableCentre)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _SaleContractMachineMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                return View("/Views/Contract/SaleContractMachineMaster/Index.cshtml", _SaleContractMachineMasterViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string centerCode, string departmentID, string actionMode)
        {
            try
            {
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Contract/SaleContractMachineMaster/List.cshtml");

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
            SaleContractMachineMasterViewModel model = new SaleContractMachineMasterViewModel();
            try
            {
                string[] splitCentreCode = CentreCode.Split(':');
                model.CentreCode = splitCentreCode[0];

                List<SelectListItem> li_MachineType = new List<SelectListItem>();
                li_MachineType.Add(new SelectListItem { Text = "Machine", Value = "1" });
                li_MachineType.Add(new SelectListItem { Text = "Tools", Value = "2" });
                ViewBag.MachineTypeList = new SelectList(li_MachineType, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractMachineMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractMachineMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SaleContractMachineMasterDTO != null)
                    {
                        model.SaleContractMachineMasterDTO.ConnectionString = _connectioString;
                        string[] splitCentreCode = model.CentreCode.Split(':');
                        model.SaleContractMachineMasterDTO.CentreCode = splitCentreCode[0];
                        model.SaleContractMachineMasterDTO.ItemNumber = model.ItemNumber;
                        model.SaleContractMachineMasterDTO.SerialNumber = model.SerialNumber;
                        model.SaleContractMachineMasterDTO.PurchaseDate = model.PurchaseDate;
                        model.SaleContractMachineMasterDTO.NextMaintanceDate = model.NextMaintanceDate;
                        model.SaleContractMachineMasterDTO.MachineType = model.MachineType;
                        model.SaleContractMachineMasterDTO.MachineUseFor = model.MachineUseFor;
                        model.SaleContractMachineMasterDTO.ModelNumber = model.ModelNumber;
                        model.SaleContractMachineMasterDTO.MakeBy = model.MakeBy;
                        model.SaleContractMachineMasterDTO.PurchaseCost = model.PurchaseCost;

                        model.SaleContractMachineMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SaleContractMachineMaster> response = _SaleContractMachineMasterBA.InsertSaleContractMachineMaster(model.SaleContractMachineMasterDTO);
                        model.SaleContractMachineMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.SaleContractMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            SaleContractMachineMasterViewModel model = new SaleContractMachineMasterViewModel();
            try
            {
                model.SaleContractMachineMasterDTO = new SaleContractMachineMaster();
                model.SaleContractMachineMasterDTO.ID = ID;
                model.SaleContractMachineMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<SaleContractMachineMaster> response = _SaleContractMachineMasterBA.SelectByID(model.SaleContractMachineMasterDTO);

                if (response != null && response.Entity != null)
                {
                    model.SaleContractMachineMasterDTO.ID = response.Entity.ID;
                    model.SaleContractMachineMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.SaleContractMachineMasterDTO.ItemNumber = response.Entity.ItemNumber;
                    model.SaleContractMachineMasterDTO.Name = response.Entity.Name;
                    model.SaleContractMachineMasterDTO.ItemDescription = response.Entity.ItemDescription;
                    model.SaleContractMachineMasterDTO.SerialNumber = response.Entity.SerialNumber;
                    model.SaleContractMachineMasterDTO.PurchaseDate = response.Entity.PurchaseDate;
                    model.SaleContractMachineMasterDTO.NextMaintanceDate = response.Entity.NextMaintanceDate;
                    model.SaleContractMachineMasterDTO.MachineType = response.Entity.MachineType;
                    model.SaleContractMachineMasterDTO.MachineUseFor = response.Entity.MachineUseFor;
                    model.SaleContractMachineMasterDTO.ModelNumber = response.Entity.ModelNumber;
                    model.SaleContractMachineMasterDTO.MakeBy = response.Entity.MakeBy;
                    model.SaleContractMachineMasterDTO.PurchaseCost = response.Entity.PurchaseCost;
                }

                List<SelectListItem> li_MachineType = new List<SelectListItem>();
                li_MachineType.Add(new SelectListItem { Text = "Machine", Value = "1" });
                li_MachineType.Add(new SelectListItem { Text = "Tools", Value = "2" });
                ViewBag.MachineTypeList = new SelectList(li_MachineType, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractMachineMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SaleContractMachineMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SaleContractMachineMasterDTO != null)
                    {
                        model.SaleContractMachineMasterDTO.ConnectionString = _connectioString;
                        model.SaleContractMachineMasterDTO.ID = model.ID;
                        model.SaleContractMachineMasterDTO.ItemNumber = model.ItemNumber;
                        model.SaleContractMachineMasterDTO.SerialNumber = model.SerialNumber;
                        model.SaleContractMachineMasterDTO.PurchaseDate = model.PurchaseDate;
                        model.SaleContractMachineMasterDTO.NextMaintanceDate = model.NextMaintanceDate;
                        model.SaleContractMachineMasterDTO.PurchaseCost = model.PurchaseCost;

                        model.SaleContractMachineMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SaleContractMachineMaster> response = _SaleContractMachineMasterBA.UpdateSaleContractMachineMaster(model.SaleContractMachineMasterDTO);
                        model.SaleContractMachineMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.SaleContractMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Methods
        [HttpPost]
        public JsonResult GetMachineMasterSearchList(string term)
        {
            SaleContractMachineMasterSearchRequest searchRequest = new SaleContractMachineMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<SaleContractMachineMaster> listFeeSubType = new List<SaleContractMachineMaster>();
            IBaseEntityCollectionResponse<SaleContractMachineMaster> baseEntityCollectionResponse = _SaleContractMachineMasterBA.GetMachineMasterBySearchWord(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              MachineMasterID = r.ID,
                              MachineMasterName = r.Name,
                              MachineMasterSerialNumber = r.SerialNumber
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItemSearchList(string term)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _generalItemMasterBA.GetGeneralServiceItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              ItemNumber = r.ItemNumber,
                              ItemDescription = r.ItemDescription,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [NonAction]
        public IEnumerable<SaleContractMachineMasterViewModel> GetSaleContractMachineMaster(string centerCode, out int TotalRecords)
        {
            try
            {
                SaleContractMachineMasterSearchRequest searchRequest = new SaleContractMachineMasterSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);
                if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
                {
                    if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                    {
                        searchRequest.CentreCode = centerCode;
                        searchRequest.SortBy = "A.CreatedDate";
                        searchRequest.StartRow = 0;
                        searchRequest.EndRow = 10;
                        searchRequest.SearchBy = string.Empty;
                        searchRequest.SortDirection = "Desc";
                    }
                    if (actionModeEnum == ActionModeEnum.Update)
                    {
                        searchRequest.CentreCode = centerCode;
                        searchRequest.SortBy = "A.ModifiedDate";
                        searchRequest.StartRow = 0;
                        searchRequest.EndRow = 10;
                        searchRequest.SearchBy = string.Empty;
                        searchRequest.SortDirection = "Desc";
                    }
                }
                else
                {
                    searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminPostApplicableToRole_SelectAll)
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                    searchRequest.CentreCode = centerCode;
                }

                List<SaleContractMachineMasterViewModel> listSaleContractMachineMasterViewModel = new List<SaleContractMachineMasterViewModel>();
                List<SaleContractMachineMaster> listSaleContractMachineMaster = new List<SaleContractMachineMaster>();
                IBaseEntityCollectionResponse<SaleContractMachineMaster> baseEntityCollectionResponse = _SaleContractMachineMasterBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMachineMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractMachineMaster item in listSaleContractMachineMaster)
                        {
                            SaleContractMachineMasterViewModel SaleContractMachineMasterViewModel = new SaleContractMachineMasterViewModel();
                            SaleContractMachineMasterViewModel.SaleContractMachineMasterDTO = item;
                            listSaleContractMachineMasterViewModel.Add(SaleContractMachineMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractMachineMasterViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractMachineMasterViewModel> filteredSaleContractMachineMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.ItemDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or A.Name Like '%" + param.sSearch + "%' or A.SerialNumber Like '%" + param.sSearch + "%' or CustomerName Like '%" + param.sSearch + "%' or LocationName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.Name";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or A.Name Like '%" + param.sSearch + "%' or A.SerialNumber Like '%" + param.sSearch + "%' or CustomerName Like '%" + param.sSearch + "%' or LocationName Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.SerialNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or A.Name Like '%" + param.sSearch + "%' or A.SerialNumber Like '%" + param.sSearch + "%' or CustomerName Like '%" + param.sSearch + "%' or LocationName Like '%" + param.sSearch + "%'";   //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "CustomerName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or A.Name Like '%" + param.sSearch + "%' or A.SerialNumber Like '%" + param.sSearch + "%' or CustomerName Like '%" + param.sSearch + "%' or LocationName Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "LocationName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ItemDescription Like '%" + param.sSearch + "%' or A.Name Like '%" + param.sSearch + "%' or A.SerialNumber Like '%" + param.sSearch + "%' or CustomerName Like '%" + param.sSearch + "%' or LocationName Like '%" + param.sSearch + "%'";  //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(Convert.ToString(CentreCode)))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                filteredSaleContractMachineMaster = GetSaleContractMachineMaster(splitCentreCode[0], out TotalRecords);
            }
            else
            {
                filteredSaleContractMachineMaster = new List<SaleContractMachineMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredSaleContractMachineMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.Name), Convert.ToString(c.ItemDescription), Convert.ToString(c.SerialNumber), Convert.ToString(c.CustomerName), Convert.ToString(c.LocationName) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


