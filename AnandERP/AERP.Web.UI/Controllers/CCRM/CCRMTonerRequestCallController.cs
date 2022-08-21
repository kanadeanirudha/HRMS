using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System.Web.Mvc;
using System.Configuration;

namespace AERP.Web.UI.Controllers
{
    public class CCRMTonerRequestCallController : BaseController
    {
        ICCRMTonerRequestCallBA _CCRMTonerRequestCallBA = null;
        ICCRMMachineFamilyMasterBA _CCRMMachineFamilyMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMTonerRequestCallController()
        {
            _CCRMTonerRequestCallBA = new CCRMTonerRequestCallBA();
            _CCRMMachineFamilyMasterBA = new CCRMMachineFamilyMasterBA();
        }
        #region Controller Methods
        // GET: CCRMTonerRequestCall
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMTonerRequestCall/Index.cshtml");
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
                CCRMTonerRequestCallViewModel model = new CCRMTonerRequestCallViewModel();
                //*********************MachineFamily*********************//
                List<CCRMMachineFamilyMaster> CCRMMachineFamilyMaster = GetCCRMMachineFamilyMaster();
                List<SelectListItem> CCRMMachineFamilyMasterList = new List<SelectListItem>();
                foreach (CCRMMachineFamilyMaster item in CCRMMachineFamilyMaster)
                {
                    CCRMMachineFamilyMasterList.Add(new SelectListItem { Text = item.MachineFamilyName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.CCRMMachineFamilyMasterList = new SelectList(CCRMMachineFamilyMasterList, "Value", "Text", model.MachineFamilyID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMTonerRequestCall/List.cshtml", model);
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
            CCRMTonerRequestCallViewModel model = new CCRMTonerRequestCallViewModel();

            return PartialView("/Views/CCRM/CCRMTonerRequestCall/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMTonerRequestCallViewModel model)
        {
            try
            {
               
                    if (model != null && model.CCRMTonerRequestCallDTO != null)
                    {
                        model.CCRMTonerRequestCallDTO.ConnectionString = _connectioString;

                        model.CCRMTonerRequestCallDTO.CallDate = model.CallDate;
                        model.CCRMTonerRequestCallDTO.CallTktNo = model.CallTktNo;
                        model.CCRMTonerRequestCallDTO.SerialNo = model.SerialNo;
                        model.CCRMTonerRequestCallDTO.ContractID = model.ContractID;
                        model.CCRMTonerRequestCallDTO.ContractCode = model.ContractCode;
                        model.CCRMTonerRequestCallDTO.MIFID = model.MIFID;
                        model.CCRMTonerRequestCallDTO.MIFName = model.MIFName;
                        model.CCRMTonerRequestCallDTO.ModelNo = model.ModelNo;
                        model.CCRMTonerRequestCallDTO.MachineFamilyID = model.MachineFamilyID;
                        model.CCRMTonerRequestCallDTO.PartNO = model.PartNO;
                        model.CCRMTonerRequestCallDTO.PartName = model.PartName;
                        model.CCRMTonerRequestCallDTO.BalanceQuantity = model.BalanceQuantity;
                        model.CCRMTonerRequestCallDTO.Quantity = model.Quantity;
                        model.CCRMTonerRequestCallDTO.FOC = model.FOC;
                        model.CCRMTonerRequestCallDTO.CurrentMeterRead = model.CurrentMeterRead;
                        model.CCRMTonerRequestCallDTO.CallerName = model.CallerName;
                        model.CCRMTonerRequestCallDTO.CallerPh = model.CallerPh;
                        model.CCRMTonerRequestCallDTO.Remarks = model.Remarks;
                        model.CCRMTonerRequestCallDTO.CallNo = model.CallNo;
                    model.CCRMTonerRequestCallDTO.LastCallDate = model.LastCallDate;
                    model.CCRMTonerRequestCallDTO.LastCallNo = model.LastCallNo;
                    model.CCRMTonerRequestCallDTO.LastQuantity = model.LastQuantity;
                    model.CCRMTonerRequestCallDTO.LastMtrRead = model.LastMtrRead;
                    model.CCRMTonerRequestCallDTO.Consumption = model.Consumption;
                    model.CCRMTonerRequestCallDTO.StandardCopy = model.StandardCopy;

                    model.CCRMTonerRequestCallDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMTonerRequestCall> response = _CCRMTonerRequestCallBA.InsertCCRMTonerRequestCall(model.CCRMTonerRequestCallDTO);
                        model.CCRMTonerRequestCallDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMTonerRequestCallDTO.errorMessage, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        // Non-Action Method
        #region Methods
        public IEnumerable<CCRMTonerRequestCallViewModel> GetCCRMTonerRequestCall(out int TotalRecords)
        {
            CCRMTonerRequestCallSearchRequest searchRequest = new CCRMTonerRequestCallSearchRequest();
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
            List<CCRMTonerRequestCallViewModel> listCCRMTonerRequestCallViewModel = new List<CCRMTonerRequestCallViewModel>();
            List<CCRMTonerRequestCall> listCCRMTonerRequestCall = new List<CCRMTonerRequestCall>();
            IBaseEntityCollectionResponse<CCRMTonerRequestCall> baseEntityCollectionResponse = _CCRMTonerRequestCallBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMTonerRequestCall = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMTonerRequestCall item in listCCRMTonerRequestCall)
                    {
                        CCRMTonerRequestCallViewModel CCRMTonerRequestCallViewModel = new CCRMTonerRequestCallViewModel();
                        CCRMTonerRequestCallViewModel.CCRMTonerRequestCallDTO = item;
                        listCCRMTonerRequestCallViewModel.Add(CCRMTonerRequestCallViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMTonerRequestCallViewModel;
        }
        protected List<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMaster()
        {
            CCRMMachineFamilyMasterSearchRequest searchRequest = new CCRMMachineFamilyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMMachineFamilyMaster> listCCRMMachineFamilyMaster = new List<CCRMMachineFamilyMaster>();
            IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> baseEntityCollectionResponse = _CCRMMachineFamilyMasterBA.GetCCRMMachineFamilyMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMachineFamilyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMMachineFamilyMaster;
        }
        [HttpPost]
        public JsonResult GetLastCallByModelNo(string ModelNo)
        {
            CCRMTonerRequestCallSearchRequest searchRequest = new CCRMTonerRequestCallSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ModelNo = ModelNo;

            List<CCRMTonerRequestCall> listFeeSubType = new List<CCRMTonerRequestCall>();
            IBaseEntityCollectionResponse<CCRMTonerRequestCall> baseEntityCollectionResponse = _CCRMTonerRequestCallBA.GetLastCallByModelNo(searchRequest);
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
                              ID = r.ID,

                              PartNO = r.PartNO,

                              LastCallNo = r.LastCallNo,
                              LastCallDate = r.LastCallDate,
                              LastQuantity = r.LastQuantity,
                              LastMtrRead = r.LastMtrRead,
                             // ModelNo=r.ModelNo,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMTonerRequestCallViewModel> filteredCCRMTonerRequestCallViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BankName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "BankName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ID Like '%" + param.sSearch + "%' or BankName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMTonerRequestCallViewModel = GetCCRMTonerRequestCall(out TotalRecords);
            var records = filteredCCRMTonerRequestCallViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] {  Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}