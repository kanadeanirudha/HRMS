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
    public class GeneralPriceListAndListLineController : BaseController
    {
        IGeneralPriceListAndListLineBA _GeneralPriceListAndListLineBA = null;
        IGeneralPriceGroupBA _GeneralPriceGroupBA = null;
        IGeneralCityMasterBA _generalCityMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPriceListAndListLineController()
        {
            _GeneralPriceListAndListLineBA = new GeneralPriceListAndListLineBA();
            _generalCityMasterBA = new GeneralCityMasterBA();
            _GeneralPriceGroupBA = new GeneralPriceGroupBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralPriceListAndListLine/Index.cshtml");
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
                GeneralPriceListAndListLineViewModel model = new GeneralPriceListAndListLineViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralPriceListAndListLine/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult Create()
        {

            GeneralPriceListAndListLineViewModel model = new GeneralPriceListAndListLineViewModel();
            model.GeneralPriceListAndListLineDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralPriceListAndListLine> response = _GeneralPriceListAndListLineBA.GetIsRootCount(model.GeneralPriceListAndListLineDTO);
            if (response != null && response.Entity != null)
            {
                model.GeneralPriceListAndListLineDTO.IsRootCount = response.Entity.IsRootCount;
            }
            //dropdown for BasePriseListID
            List<GeneralPriceListAndListLine> GeneralPriceListAndListLineGroup = GetListGeneralPriceGroupForPriceGroupCode();
            List<SelectListItem> GeneralPriceListAndListLine = new List<SelectListItem>();
            foreach (GeneralPriceListAndListLine item in GeneralPriceListAndListLineGroup)
            {
                GeneralPriceListAndListLine.Add(new SelectListItem { Text = item.PriceListName, Value = Convert.ToString(item.GeneralPriceListID) });
            }
            ViewBag.GeneralPriceListAndListLineList = new SelectList(GeneralPriceListAndListLine, "Value", "Text");

            List<GeneralPriceGroup> GeneralPriceGroup = GetListGeneralItemPriceGroup();
            List<SelectListItem> GeneralPriceGroupList = new List<SelectListItem>();
            foreach (GeneralPriceGroup item in GeneralPriceGroup)
            {
                GeneralPriceGroupList.Add(new SelectListItem { Text = item.GeneralPriceGroupCode, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralPriceGroupList = new SelectList(GeneralPriceGroupList, "Value", "Text");

            return PartialView("/Views/Inventory/GeneralPriceListAndListLine/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPriceListAndListLineViewModel model)
        {
            try
            {
                if (model != null && model.GeneralPriceListAndListLineDTO != null)
                {
                    model.GeneralPriceListAndListLineDTO.ConnectionString = _connectioString;
                    model.GeneralPriceListAndListLineDTO.PriceListName = model.PriceListName;
                    model.GeneralPriceListAndListLineDTO.IsRoot = model.IsRoot;
                    model.GeneralPriceListAndListLineDTO.IsUpdationAutomatic = model.IsUpdationAutomatic;
                    model.GeneralPriceListAndListLineDTO.BasePriseListID = model.BasePriseListID;
                    model.GeneralPriceListAndListLineDTO.Factor = model.Factor;
                    model.GeneralPriceListAndListLineDTO.IsRounding = model.IsRounding;
                    model.GeneralPriceListAndListLineDTO.RoundingMethod = model.RoundingMethod;
                    model.GeneralPriceListAndListLineDTO.PriceGroupId = model.PriceGroupId;
                    model.GeneralPriceListAndListLineDTO.ValidFromDate = model.ValidFromDate;
                    model.GeneralPriceListAndListLineDTO.ValidUptoDate = model.ValidUptoDate;
                    model.GeneralPriceListAndListLineDTO.IsActive = model.IsActive;
                    model.GeneralPriceListAndListLineDTO.GeneralPriceGroupCode = model.GeneralPriceGroupCode;
                    model.GeneralPriceListAndListLineDTO.GeneralPriceGroupDescription = model.GeneralPriceGroupDescription;
                    model.GeneralPriceListAndListLineDTO.BasePriceListname = model.BasePriceListname;
                    
                    model.GeneralPriceListAndListLineDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPriceListAndListLine> response = _GeneralPriceListAndListLineBA.InsertGeneralPriceListAndListLine(model.GeneralPriceListAndListLineDTO);
                    model.GeneralPriceListAndListLineDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralPriceListAndListLineDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralPriceListAndListLineViewModel model = new GeneralPriceListAndListLineViewModel();
            try
            {
                model.GeneralPriceListAndListLineDTO = new GeneralPriceListAndListLine();
               // model.GeneralPriceListAndListLineDTO.ID = id;
                model.GeneralPriceListAndListLineDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralPriceListAndListLine> response = _GeneralPriceListAndListLineBA.SelectByID(model.GeneralPriceListAndListLineDTO);
                if (response != null && response.Entity != null)
                {
                    //model.GeneralPriceListAndListLineDTO.ID = response.Entity.ID;
                    //model.GeneralPriceListAndListLineDTO.ProcessUnitName = response.Entity.ProcessUnitName;
                    //model.GeneralPriceListAndListLineDTO.UnitName = response.Entity.UnitName;
                    //model.GeneralPriceListAndListLineDTO.AllocatedFromDate = response.Entity.AllocatedFromDate;
                    //model.GeneralPriceListAndListLineDTO.AllocatedUptoDate = response.Entity.AllocatedUptoDate;

                    model.GeneralPriceListAndListLineDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralPriceListAndListLine/View.cshtml", model);
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
                IBaseEntityResponse<GeneralPriceListAndListLine> response = null;
                GeneralPriceListAndListLine GeneralPriceListAndListLineDTO = new GeneralPriceListAndListLine();
                GeneralPriceListAndListLineDTO.ConnectionString = _connectioString;
                GeneralPriceListAndListLineDTO.GeneralPriceListID = ID;
                GeneralPriceListAndListLineDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralPriceListAndListLineBA.DeleteGeneralPriceListAndListLine(GeneralPriceListAndListLineDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods


       
        //drop down for process unit
        protected List<GeneralPriceListAndListLine> GetListGeneralPriceGroupForPriceGroupCode()
        {
            GeneralPriceListAndListLineSearchRequest searchRequest = new GeneralPriceListAndListLineSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPriceListAndListLine> listtGeneralPriceGroup = new List<GeneralPriceListAndListLine>();
            IBaseEntityCollectionResponse<GeneralPriceListAndListLine> baseEntityCollectionResponse = _GeneralPriceListAndListLineBA.GetGeneralPriceListAndListLineSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }

        protected List<GeneralPriceGroup> GetListGeneralItemPriceGroup()
        {
            GeneralPriceGroupSearchRequest searchRequest = new GeneralPriceGroupSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPriceGroup> listtGeneralPriceGroup = new List<GeneralPriceGroup>();
            IBaseEntityCollectionResponse<GeneralPriceGroup> baseEntityCollectionResponse = _GeneralPriceGroupBA.GetGeneralPriceGroupSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }


        public IEnumerable<GeneralPriceListAndListLineViewModel> GetGeneralPriceListAndListLine(out int TotalRecords)
        {
            GeneralPriceListAndListLineSearchRequest searchRequest = new GeneralPriceListAndListLineSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.UnitName,B.CreatedDate";
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
            List<GeneralPriceListAndListLineViewModel> listGeneralPriceListAndListLineViewModel = new List<GeneralPriceListAndListLineViewModel>();
            List<GeneralPriceListAndListLine> listGeneralPriceListAndListLine = new List<GeneralPriceListAndListLine>();
            IBaseEntityCollectionResponse<GeneralPriceListAndListLine> baseEntityCollectionResponse = _GeneralPriceListAndListLineBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPriceListAndListLine = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPriceListAndListLine item in listGeneralPriceListAndListLine)
                    {
                        GeneralPriceListAndListLineViewModel GeneralPriceListAndListLineViewModel = new GeneralPriceListAndListLineViewModel();
                        GeneralPriceListAndListLineViewModel.GeneralPriceListAndListLineDTO = item;
                        listGeneralPriceListAndListLineViewModel.Add(GeneralPriceListAndListLineViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPriceListAndListLineViewModel;
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

                IEnumerable<GeneralPriceListAndListLineViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "B.PriceListName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "B.PriceListName like '%'";
                        }
                        else
                        {
                            _searchBy = "B.PriceListName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.UnitName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.UnitName like '%'";
                        }
                        else
                        {
                            _searchBy = "A.UnitName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;


                filteredCountryMaster = GetGeneralPriceListAndListLine(out TotalRecords);

                if ((filteredCountryMaster.Count()) == 0)
                {
                    filteredCountryMaster = new List<GeneralPriceListAndListLineViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PriceListName), Convert.ToString(c.IsRoot), Convert.ToString(c.IsUpdationAutomatic), Convert.ToString(c.GeneralPriceListID), Convert.ToString(c.BasePriceListname), Convert.ToString(c.Factor), Convert.ToString(c.GeneralPriceGroupCode) };

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