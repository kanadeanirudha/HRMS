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
    public class SaleContractServiceItemAttendanceController : BaseController
    {
        ISaleContractServiceItemAttendanceBA _SaleContractServiceItemAttendanceBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;

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

        public SaleContractServiceItemAttendanceController()
        {
            _SaleContractServiceItemAttendanceBA = new SaleContractServiceItemAttendanceBA();
            _generalItemMasterBA = new GeneralItemMasterBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
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
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0) && IsApplied == true))
            {
                SaleContractServiceItemAttendanceViewModel _SaleContractServiceItemAttendanceViewModel = new SaleContractServiceItemAttendanceViewModel();

                return View("/Views/Contract/SaleContractServiceItemAttendance/Index.cshtml", _SaleContractServiceItemAttendanceViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractServiceItemAttendanceViewModel model = new SaleContractServiceItemAttendanceViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.ListSaleContractServiceItemAttendance = GetListSaleContractMachineAttendance(SaleContractMasterID, SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractServiceItemAttendance/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewTransactions(string SaleContractMasterID)
        {
            SaleContractServiceItemAttendanceViewModel model = new SaleContractServiceItemAttendanceViewModel();
            try
            {
                model.ListSaleContractServiceItemAttendance = GetListSaleContractServiceItemAttendance(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractServiceItemAttendance/ViewTransactions.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string SaleContractMasterID)
        {
            SaleContractServiceItemAttendanceViewModel model = new SaleContractServiceItemAttendanceViewModel();
            try
            {
                model.SaleContractServiceItemAttendanceDTO.ConnectionString = _connectioString;
                model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.ListSaleContractBillingSpan = GetSpanListBySaleContractMaster(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractServiceItemAttendance/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult GetAttendanceForMonthWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractServiceItemAttendanceViewModel model = new SaleContractServiceItemAttendanceViewModel();

            model.ListSaleContractServiceItemAttendance = GetListSaleContractMachineAttendance(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractServiceItemAttendance/GetAttendanceForMonthWise.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SaleContractServiceItemAttendanceViewModel model)
        {
            try
            {

                if (model != null && model.SaleContractServiceItemAttendanceDTO != null)
                {
                    model.SaleContractServiceItemAttendanceDTO.ConnectionString = _connectioString;

                    model.SaleContractServiceItemAttendanceDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractServiceItemAttendanceDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractServiceItemAttendanceDTO.XMLstringForAttendance = model.XMLstringForAttendance;

                    model.SaleContractServiceItemAttendanceDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractServiceItemAttendance> response = _SaleContractServiceItemAttendanceBA.InsertSaleContractServiceItemAttendance(model.SaleContractServiceItemAttendanceDTO);
                    model.SaleContractServiceItemAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SaleContractServiceItemAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult RemoveServiceItem(SaleContractServiceItemAttendanceViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractServiceItemAttendanceDTO != null)
                {
                    model.SaleContractServiceItemAttendanceDTO.ConnectionString = _connectioString;

                    model.SaleContractServiceItemAttendanceDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractServiceItemAttendanceDTO.SaleContractMachineAssignID = model.SaleContractMachineAssignID;
                    model.SaleContractServiceItemAttendanceDTO.MachineAssignUptoDate = model.MachineAssignUptoDate;

                    model.SaleContractServiceItemAttendanceDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractServiceItemAttendance> response = _SaleContractServiceItemAttendanceBA.RemoveSaleContractServiceItemAttendance(model.SaleContractServiceItemAttendanceDTO);
                    model.SaleContractServiceItemAttendanceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.SaleContractServiceItemAttendanceDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region Methods

        protected List<SaleContractServiceItemAttendance> GetListSaleContractServiceItemAttendance(string SaleContractMasterID)
        {

            SaleContractServiceItemAttendanceSearchRequest searchRequest = new SaleContractServiceItemAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractServiceItemAttendance> listSaleContractAttendance = new List<SaleContractServiceItemAttendance>();
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> baseEntityCollectionResponse = _SaleContractServiceItemAttendanceBA.GetListSaleContractServiceItemAttendance(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractServiceItemAttendance> GetListSaleContractMachineAttendance(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractServiceItemAttendanceSearchRequest searchRequest = new SaleContractServiceItemAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractServiceItemAttendance> listSaleContractAttendance = new List<SaleContractServiceItemAttendance>();
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> baseEntityCollectionResponse = _SaleContractServiceItemAttendanceBA.GetListSaleContractMachineAttendance(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractAttendance> GetSpanListBySaleContractMaster(string SaleContractMasterID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSpanListBySaleContractMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        [HttpPost]
        public JsonResult GetMachineMasterSearchList(string term)
        {
            SaleContractServiceItemAttendanceSearchRequest searchRequest = new SaleContractServiceItemAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<SaleContractServiceItemAttendance> listFeeSubType = new List<SaleContractServiceItemAttendance>();
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> baseEntityCollectionResponse = _SaleContractServiceItemAttendanceBA.GetMachineMasterBySearchWord(searchRequest);
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
        public IEnumerable<SaleContractServiceItemAttendanceViewModel> GetSaleContractServiceItemAttendance(string centerCode, out int TotalRecords)
        {
            try
            {
                SaleContractServiceItemAttendanceSearchRequest searchRequest = new SaleContractServiceItemAttendanceSearchRequest();
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

                List<SaleContractServiceItemAttendanceViewModel> listSaleContractServiceItemAttendanceViewModel = new List<SaleContractServiceItemAttendanceViewModel>();
                List<SaleContractServiceItemAttendance> listSaleContractServiceItemAttendance = new List<SaleContractServiceItemAttendance>();
                IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> baseEntityCollectionResponse = _SaleContractServiceItemAttendanceBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractServiceItemAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractServiceItemAttendance item in listSaleContractServiceItemAttendance)
                        {
                            SaleContractServiceItemAttendanceViewModel SaleContractServiceItemAttendanceViewModel = new SaleContractServiceItemAttendanceViewModel();
                            SaleContractServiceItemAttendanceViewModel.SaleContractServiceItemAttendanceDTO = item;
                            listSaleContractServiceItemAttendanceViewModel.Add(SaleContractServiceItemAttendanceViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractServiceItemAttendanceViewModel;
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
            IEnumerable<SaleContractServiceItemAttendanceViewModel> filteredSaleContractServiceItemAttendance;

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
                filteredSaleContractServiceItemAttendance = GetSaleContractServiceItemAttendance(splitCentreCode[0], out TotalRecords);
            }
            else
            {
                filteredSaleContractServiceItemAttendance = new List<SaleContractServiceItemAttendanceViewModel>();
                TotalRecords = 0;
            }
            var records = filteredSaleContractServiceItemAttendance.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.Name), Convert.ToString(c.ItemDescription), Convert.ToString(c.SerialNumber), Convert.ToString(c.CustomerName), Convert.ToString(c.LocationName) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


