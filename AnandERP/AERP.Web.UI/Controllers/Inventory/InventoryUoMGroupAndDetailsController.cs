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
    public class InventoryUoMGroupAndDetailsController : BaseController
    {
        IInventoryUoMGroupAndDetailsBA _InventoryUoMGroupAndDetailsBA = null;
        IGeneralCityMasterBA _generalCityMasterBA = null;
        IInventoryUoMMasterBA _InventoryUoMMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryUoMGroupAndDetailsController()
        {
            _InventoryUoMGroupAndDetailsBA = new InventoryUoMGroupAndDetailsBA();
            _generalCityMasterBA = new GeneralCityMasterBA();
            _InventoryUoMMasterBA = new InventoryUoMMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/InventoryUoMGroupAndDetails/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                InventoryUoMGroupAndDetailsViewModel model = new InventoryUoMGroupAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryUoMGroupAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult CreateGroup()
        {

            InventoryUoMGroupAndDetailsViewModel model = new InventoryUoMGroupAndDetailsViewModel();
            //************************** Drop Down For General Item Marchandise Category***********************************************
            List<InventoryUoMMaster> InventoryUoMMaster = GetListInventoryUoMMasterForUomCode();
            List<SelectListItem> InventoryUoMMasterList = new List<SelectListItem>();
            foreach (InventoryUoMMaster item in InventoryUoMMaster)
            {
                InventoryUoMMasterList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
            }
            ViewBag.InventoryUoMMasterForUomCodeList = new SelectList(InventoryUoMMasterList, "Value", "Text");
            return PartialView("/Views/Inventory/InventoryUoMGroupAndDetails/CreateGroup.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateGroup(InventoryUoMGroupAndDetailsViewModel model)
        {
            try
            {
                if (model != null && model.InventoryUoMGroupAndDetailsDTO != null)
                {
                    model.InventoryUoMGroupAndDetailsDTO.ConnectionString = _connectioString;
                    model.InventoryUoMGroupAndDetailsDTO.GroupCode = model.GroupCode;
                    model.InventoryUoMGroupAndDetailsDTO.GroupDescription = model.GroupDescription;
                    model.InventoryUoMGroupAndDetailsDTO.BaseUomCode = model.BaseUomCode;
                    model.InventoryUoMGroupAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryUoMGroupAndDetails> response = _InventoryUoMGroupAndDetailsBA.InsertInventoryUoMGroup(model.InventoryUoMGroupAndDetailsDTO);
                    model.InventoryUoMGroupAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryUoMGroupAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult CreateGroupDetails(string IDs)
        {

            InventoryUoMGroupAndDetailsViewModel model = new InventoryUoMGroupAndDetailsViewModel();
            string[] IDsArray = IDs.Split('~');
            model.InventoryUoMGroupID = Convert.ToInt16(IDsArray[0]);
            model.GroupCode = IDsArray[1];
            model.BaseUomCode = IDsArray[2];

            List<SelectListItem> UsedFor = new List<SelectListItem>();
            ViewBag.UsedFor = new SelectList(UsedFor, "Value", "Text");
            List<SelectListItem> UsedFor_li = new List<SelectListItem>();

            UsedFor_li.Add(new SelectListItem { Text = "--Select--", Value = " " });
            UsedFor_li.Add(new SelectListItem { Text = "Sales", Value = "1" });
            UsedFor_li.Add(new SelectListItem { Text = "Purchase", Value = "2" });
            UsedFor_li.Add(new SelectListItem { Text = "Both", Value = "3" });
            ViewData["UsedFor"] = UsedFor_li;

            InventoryUoMGroupAndDetailsSearchRequest searchRequest = new InventoryUoMGroupAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.InventoryUoMGroupID = Convert.ToInt16(IDsArray[0]);
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> baseEntityCollectionResponse = _InventoryUoMGroupAndDetailsBA.SelectByInventoryUoMGroupID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.InventoryUoMGroupDetailsList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }


            return PartialView("/Views/Inventory/InventoryUoMGroupAndDetails/CreateGroupDetails.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateGroupDetails(InventoryUoMGroupAndDetailsViewModel model)
        {
            try
            {
                if (model != null && model.InventoryUoMGroupAndDetailsDTO != null)
                {
                    model.InventoryUoMGroupAndDetailsDTO.ConnectionString = _connectioString;

                    model.InventoryUoMGroupAndDetailsDTO.GroupCode = model.GroupCode;
                    model.InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupID = model.InventoryUoMGroupID;
                    model.InventoryUoMGroupAndDetailsDTO.AlternativeUomName = model.AlternativeUomName;
                    model.InventoryUoMGroupAndDetailsDTO.AlternativeUomCode = model.AlternativeUomCode;
                    model.InventoryUoMGroupAndDetailsDTO.AlternativeQuantity = model.AlternativeQuantity;
                    model.InventoryUoMGroupAndDetailsDTO.BaseUomCode = model.BaseUomCode;
                    model.InventoryUoMGroupAndDetailsDTO.BaseUoMQuantity = model.BaseUoMQuantity;
                    model.InventoryUoMGroupAndDetailsDTO.BasePriceReducedBy = model.BasePriceReducedBy;
                    model.InventoryUoMGroupAndDetailsDTO.UsedFor = model.UsedFor;
                    model.InventoryUoMGroupAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryUoMGroupAndDetails> response = _InventoryUoMGroupAndDetailsBA.InsertInventoryUoMGroupAndDetails(model.InventoryUoMGroupAndDetailsDTO);
                    model.InventoryUoMGroupAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryUoMGroupAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewDetails(Int16 id)
        {
            InventoryUoMGroupAndDetailsViewModel model = new InventoryUoMGroupAndDetailsViewModel();
            try
            {
                model.InventoryUoMGroupAndDetailsDTO = new InventoryUoMGroupAndDetails();
                // model.InventoryUoMGroupAndDetailsDTO.ID = id;
                model.InventoryUoMGroupAndDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryUoMGroupAndDetails> response = _InventoryUoMGroupAndDetailsBA.SelectByID(model.InventoryUoMGroupAndDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    //model.InventoryUoMGroupAndDetailsDTO.ID = response.Entity.ID;
                    //model.InventoryUoMGroupAndDetailsDTO.CityName = response.Entity.CityName;
                    //model.InventoryUoMGroupAndDetailsDTO.UnitName = response.Entity.UnitName;
                    //model.InventoryUoMGroupAndDetailsDTO.GeneralUnitTypeID = response.Entity.GeneralUnitTypeID;
                    //model.InventoryUoMGroupAndDetailsDTO.CentreName = response.Entity.CentreName;
                    //model.InventoryUoMGroupAndDetailsDTO.DepartmentID = response.Entity.DepartmentID;
                    //model.InventoryUoMGroupAndDetailsDTO.LocationAddress = response.Entity.LocationAddress;
                    //model.InventoryUoMGroupAndDetailsDTO.CityId = response.Entity.CityId;
                    //model.InventoryUoMGroupAndDetailsDTO.UnitType = response.Entity.UnitType;
                    //model.InventoryUoMGroupAndDetailsDTO.RelatedwithUnitType = response.Entity.RelatedwithUnitType;
                    //model.InventoryUoMGroupAndDetailsDTO.CentreName = response.Entity.CentreName;
                    //model.InventoryUoMGroupAndDetailsDTO.DepartmentName = response.Entity.DepartmentName;

                    model.InventoryUoMGroupAndDetailsDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/InventoryUoMGroupAndDetails/View.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<InventoryUoMGroupAndDetails> response = null;
                InventoryUoMGroupAndDetails InventoryUoMGroupAndDetailsDTO = new InventoryUoMGroupAndDetails();
                InventoryUoMGroupAndDetailsDTO.ConnectionString = _connectioString;
                InventoryUoMGroupAndDetailsDTO.InventoryUoMGroupDetailsID = ID;
                InventoryUoMGroupAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryUoMGroupAndDetailsBA.DeleteInventoryUoMGroupAndDetails(InventoryUoMGroupAndDetailsDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods

        //Dropdown for General Item Merchantise Department
        protected List<InventoryUoMMaster> GetListInventoryUoMMasterForUomCode()
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryUoMMaster> ListInventoryUoMMasterForUomCode = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForUomCode;
        }
        public IEnumerable<InventoryUoMGroupAndDetailsViewModel> GetInventoryUoMGroupAndDetails(out int TotalRecords)
        {
            InventoryUoMGroupAndDetailsSearchRequest searchRequest = new InventoryUoMGroupAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate,A.GroupCode";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
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
            List<InventoryUoMGroupAndDetailsViewModel> listInventoryUoMGroupAndDetailsViewModel = new List<InventoryUoMGroupAndDetailsViewModel>();
            List<InventoryUoMGroupAndDetails> listInventoryUoMGroupAndDetails = new List<InventoryUoMGroupAndDetails>();
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> baseEntityCollectionResponse = _InventoryUoMGroupAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryUoMGroupAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryUoMGroupAndDetails item in listInventoryUoMGroupAndDetails)
                    {
                        InventoryUoMGroupAndDetailsViewModel InventoryUoMGroupAndDetailsViewModel = new InventoryUoMGroupAndDetailsViewModel();
                        InventoryUoMGroupAndDetailsViewModel.InventoryUoMGroupAndDetailsDTO = item;
                        listInventoryUoMGroupAndDetailsViewModel.Add(InventoryUoMGroupAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryUoMGroupAndDetailsViewModel;
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

                IEnumerable<InventoryUoMGroupAndDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.GroupCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.GroupCode like '%'";
                        }
                        else
                        {
                            _searchBy = "A.GroupCode Like '%" + param.sSearch + "%' or B.AlternativeUomName Like '%" + param.sSearch + "%' or B.AlternativeUomCode Like '%" + param.sSearch + "%' or B.BaseUomCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "B.AlternativeUomName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.AlternativeUomName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.GroupCode Like '%" + param.sSearch + "%' or B.AlternativeUomName Like '%" + param.sSearch + "%' or B.AlternativeUomCode Like '%" + param.sSearch + "%' or B.BaseUomCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "B.AlternativeUomCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.AlternativeUomCode like '%'";
                        }
                        else
                        {
                            _searchBy = "A.GroupCode Like '%" + param.sSearch + "%' or B.AlternativeUomName Like '%" + param.sSearch + "%' or B.AlternativeUomCode Like '%" + param.sSearch + "%' or B.BaseUomCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 3:
                        _sortBy = "B.BaseUomCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.AlternativeQuantity like '%'";
                        }
                        else
                        {
                            _searchBy = "A.GroupCode Like '%" + param.sSearch + "%' or B.AlternativeUomName Like '%" + param.sSearch + "%' or B.AlternativeUomCode Like '%" + param.sSearch + "%' or B.BaseUomCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 5:
                        _sortBy = "B.UsedFor";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.UsedFor like '%'";
                        }
                        else
                        {
                            _searchBy = "A.GroupCode Like '%" + param.sSearch + "%' or B.AlternativeUomName Like '%" + param.sSearch + "%' or B.AlternativeUomCode Like '%" + param.sSearch + "%' or B.BaseUomCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;


                filteredCountryMaster = GetInventoryUoMGroupAndDetails(out TotalRecords);
                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<InventoryUoMGroupAndDetailsViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.InventoryUoMGroupID), Convert.ToString(c.GroupCode), Convert.ToString(c.GroupDescription), Convert.ToString(c.AlternativeUomName), Convert.ToString(c.AlternativeUomCode), Convert.ToString(c.AlternativeQuantity), Convert.ToString(c.BaseUomCode), Convert.ToString(c.BaseUoMQuantity), Convert.ToString(c.InventoryUoMGroupDetailsID), Convert.ToString(c.BasePriceReducedBy), Convert.ToString(c.UsedFor) };
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