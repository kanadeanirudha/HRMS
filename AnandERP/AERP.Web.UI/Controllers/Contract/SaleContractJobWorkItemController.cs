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
    public class SaleContractJobWorkItemController : BaseController
    {
        ISaleContractJobWorkItemBA _SaleContractJobWorkItemBA = null;
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

        public SaleContractJobWorkItemController()
        {
            _SaleContractJobWorkItemBA = new SaleContractJobWorkItemBA();
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
                SaleContractJobWorkItemViewModel _SaleContractJobWorkItemViewModel = new SaleContractJobWorkItemViewModel();

                return View("/Views/Contract/SaleContractJobWorkItem/Index.cshtml", _SaleContractJobWorkItemViewModel);
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
                return PartialView("/Views/Contract/SaleContractJobWorkItem/List.cshtml");

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
            SaleContractJobWorkItemViewModel model = new SaleContractJobWorkItemViewModel();
            try
            {

                return PartialView("/Views/Contract/SaleContractJobWorkItem/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractJobWorkItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SaleContractJobWorkItemDTO != null)
                    {
                        model.SaleContractJobWorkItemDTO.ConnectionString = _connectioString;
                        model.SaleContractJobWorkItemDTO.ItemNumber = model.ItemNumber;
                        model.SaleContractJobWorkItemDTO.Name = model.Name;
                        model.SaleContractJobWorkItemDTO.Rate = model.Rate;

                        model.SaleContractJobWorkItemDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SaleContractJobWorkItem> response = _SaleContractJobWorkItemBA.InsertSaleContractJobWorkItem(model.SaleContractJobWorkItemDTO);
                        model.SaleContractJobWorkItemDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.SaleContractJobWorkItemDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetJobWorkItemSearchList(string term)
        {
            SaleContractJobWorkItemSearchRequest searchRequest = new SaleContractJobWorkItemSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<SaleContractJobWorkItem> listFeeSubType = new List<SaleContractJobWorkItem>();
            IBaseEntityCollectionResponse<SaleContractJobWorkItem> baseEntityCollectionResponse = _SaleContractJobWorkItemBA.GetJobWorkItemBySearchWord(searchRequest);
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
                              JobWorkItemID = r.ID,
                              JobWorkItemName = r.Name,
                              JobWorkItemRate = r.Rate
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
        public IEnumerable<SaleContractJobWorkItemViewModel> GetSaleContractJobWorkItem(out int TotalRecords)
        {
            try
            {
                SaleContractJobWorkItemSearchRequest searchRequest = new SaleContractJobWorkItemSearchRequest();
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
                }

                List<SaleContractJobWorkItemViewModel> listSaleContractJobWorkItemViewModel = new List<SaleContractJobWorkItemViewModel>();
                List<SaleContractJobWorkItem> listSaleContractJobWorkItem = new List<SaleContractJobWorkItem>();
                IBaseEntityCollectionResponse<SaleContractJobWorkItem> baseEntityCollectionResponse = _SaleContractJobWorkItemBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractJobWorkItem = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractJobWorkItem item in listSaleContractJobWorkItem)
                        {
                            SaleContractJobWorkItemViewModel SaleContractJobWorkItemViewModel = new SaleContractJobWorkItemViewModel();
                            SaleContractJobWorkItemViewModel.SaleContractJobWorkItemDTO = item;
                            listSaleContractJobWorkItemViewModel.Add(SaleContractJobWorkItemViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractJobWorkItemViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractJobWorkItemViewModel> filteredSaleContractJobWorkItem;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "Name";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Name Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "Name";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Name Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSaleContractJobWorkItem = GetSaleContractJobWorkItem(out TotalRecords);

            var records = filteredSaleContractJobWorkItem.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.Name), Convert.ToString(c.ItemDescription), Convert.ToString(c.Rate), Convert.ToString(c.ItemNumber) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


