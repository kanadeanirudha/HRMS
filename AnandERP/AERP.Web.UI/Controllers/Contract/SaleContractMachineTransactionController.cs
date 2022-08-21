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
    public class SaleContractMachineTransactionController : BaseController
    {
        ISaleContractMachineTransactionBA _SaleContractMachineTransactionBA = null;
        IGeneralItemMasterBA _generalItemMasterBA = null;
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;
        ISaleContractMasterBA _SaleContractMasterBA = null;

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

        public SaleContractMachineTransactionController()
        {
            _SaleContractMachineTransactionBA = new SaleContractMachineTransactionBA();
            _generalItemMasterBA = new GeneralItemMasterBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
            _SaleContractMasterBA = new SaleContractMasterBA();
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
                SaleContractMachineTransactionViewModel _SaleContractMachineTransactionViewModel = new SaleContractMachineTransactionViewModel();

                return View("/Views/Contract/SaleContractMachineTransaction/Index.cshtml", _SaleContractMachineTransactionViewModel);
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
                SaleContractMachineTransactionViewModel model = new SaleContractMachineTransactionViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.ListSaleContractMachineTransaction = GetListSaleContractMachineAttendance(SaleContractMasterID, SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractMachineTransaction/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AddMachine(string SaleContractMasterID)
        {
            SaleContractMachineTransactionViewModel model = new SaleContractMachineTransactionViewModel();
            try
            {
                model.SaleContractMachineTransactionDTO.ConnectionString = _connectioString;
                model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

                model.SaleContractMasterListForMachineMaster = GetSaleContractMasterListForMachineMaster(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMachineTransaction/AddMachine.cshtml", model);
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
            SaleContractMachineTransactionViewModel model = new SaleContractMachineTransactionViewModel();
            try
            {
                model.ListSaleContractMachineTransaction = GetListSaleContractMachineTransaction(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMachineTransaction/ViewTransactions.cshtml", model);
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
            SaleContractMachineTransactionViewModel model = new SaleContractMachineTransactionViewModel();
            try
            {
                model.SaleContractMachineTransactionDTO.ConnectionString = _connectioString;
                model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.ListSaleContractBillingSpan = GetSpanListBySaleContractMaster(SaleContractMasterID);

                return PartialView("/Views/Contract/SaleContractMachineTransaction/Create.cshtml", model);
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
            SaleContractMachineTransactionViewModel model = new SaleContractMachineTransactionViewModel();

            model.ListSaleContractMachineTransaction = GetListSaleContractMachineAttendance(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractMachineTransaction/GetAttendanceForMonthWise.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddMachine(SaleContractMachineTransactionViewModel model)
        {
            try
            {

                if (model != null && model.SaleContractMachineTransactionDTO != null)
                {
                    model.SaleContractMachineTransactionDTO.ConnectionString = _connectioString;

                    model.SaleContractMachineTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractMachineTransactionDTO.XMLstringForAttendance = model.XMLstringForAttendance;

                    model.SaleContractMachineTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractMachineTransaction> response = _SaleContractMachineTransactionBA.AddMachineInSaleContract(model.SaleContractMachineTransactionDTO);
                    model.SaleContractMachineTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SaleContractMachineTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractMachineTransactionViewModel model)
        {
            try
            {

                if (model != null && model.SaleContractMachineTransactionDTO != null)
                {
                    model.SaleContractMachineTransactionDTO.ConnectionString = _connectioString;

                    model.SaleContractMachineTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractMachineTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractMachineTransactionDTO.XMLstringForAttendance = model.XMLstringForAttendance;

                    model.SaleContractMachineTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractMachineTransaction> response = _SaleContractMachineTransactionBA.InsertSaleContractMachineTransaction(model.SaleContractMachineTransactionDTO);
                    model.SaleContractMachineTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.SaleContractMachineTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult RemoveMachine(SaleContractMachineTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractMachineTransactionDTO != null)
                {
                    model.SaleContractMachineTransactionDTO.ConnectionString = _connectioString;

                    model.SaleContractMachineTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractMachineTransactionDTO.SaleContractMachineAssignID = model.SaleContractMachineAssignID;
                    model.SaleContractMachineTransactionDTO.MachineAssignUptoDate = model.MachineAssignUptoDate;

                    model.SaleContractMachineTransactionDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);

                    IBaseEntityResponse<SaleContractMachineTransaction> response = _SaleContractMachineTransactionBA.RemoveSaleContractMachineTransaction(model.SaleContractMachineTransactionDTO);
                    model.SaleContractMachineTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                return Json(model.SaleContractMachineTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region Methods

        protected List<SaleContractMachineTransaction> GetListSaleContractMachineTransaction(string SaleContractMasterID)
        {

            SaleContractMachineTransactionSearchRequest searchRequest = new SaleContractMachineTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractMachineTransaction> listSaleContractAttendance = new List<SaleContractMachineTransaction>();
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> baseEntityCollectionResponse = _SaleContractMachineTransactionBA.GetListSaleContractMachineTransaction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractMachineTransaction> GetListSaleContractMachineAttendance(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractMachineTransactionSearchRequest searchRequest = new SaleContractMachineTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractMachineTransaction> listSaleContractAttendance = new List<SaleContractMachineTransaction>();
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> baseEntityCollectionResponse = _SaleContractMachineTransactionBA.GetListSaleContractMachineAttendance(searchRequest);
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
            SaleContractMachineTransactionSearchRequest searchRequest = new SaleContractMachineTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<SaleContractMachineTransaction> listFeeSubType = new List<SaleContractMachineTransaction>();
            IBaseEntityCollectionResponse<SaleContractMachineTransaction> baseEntityCollectionResponse = _SaleContractMachineTransactionBA.GetMachineMasterBySearchWord(searchRequest);
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
        protected List<SaleContractMaster> GetSaleContractMasterListForMachineMaster(string SaleContractMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = Convert.ToInt64(SaleContractMasterID);
            List<SaleContractMaster> listSaleContractMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetMachineMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractMaster;
        }

        [NonAction]
        public IEnumerable<SaleContractMachineTransactionViewModel> GetSaleContractMachineTransaction(string centerCode, out int TotalRecords)
        {
            try
            {
                SaleContractMachineTransactionSearchRequest searchRequest = new SaleContractMachineTransactionSearchRequest();
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

                List<SaleContractMachineTransactionViewModel> listSaleContractMachineTransactionViewModel = new List<SaleContractMachineTransactionViewModel>();
                List<SaleContractMachineTransaction> listSaleContractMachineTransaction = new List<SaleContractMachineTransaction>();
                IBaseEntityCollectionResponse<SaleContractMachineTransaction> baseEntityCollectionResponse = _SaleContractMachineTransactionBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMachineTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractMachineTransaction item in listSaleContractMachineTransaction)
                        {
                            SaleContractMachineTransactionViewModel SaleContractMachineTransactionViewModel = new SaleContractMachineTransactionViewModel();
                            SaleContractMachineTransactionViewModel.SaleContractMachineTransactionDTO = item;
                            listSaleContractMachineTransactionViewModel.Add(SaleContractMachineTransactionViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractMachineTransactionViewModel;
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
            IEnumerable<SaleContractMachineTransactionViewModel> filteredSaleContractMachineTransaction;

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
                filteredSaleContractMachineTransaction = GetSaleContractMachineTransaction(splitCentreCode[0], out TotalRecords);
            }
            else
            {
                filteredSaleContractMachineTransaction = new List<SaleContractMachineTransactionViewModel>();
                TotalRecords = 0;
            }
            var records = filteredSaleContractMachineTransaction.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.Name), Convert.ToString(c.ItemDescription), Convert.ToString(c.SerialNumber), Convert.ToString(c.CustomerName), Convert.ToString(c.LocationName) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


