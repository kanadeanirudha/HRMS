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
    public class SaleContractEmployeeAdvancesController : BaseController
    {
        ISaleContractEmployeeAdvancesBA _SaleContractEmployeeAdvancesBA = null;
        
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

        public SaleContractEmployeeAdvancesController()
        {
            _SaleContractEmployeeAdvancesBA = new SaleContractEmployeeAdvancesBA();
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
                SaleContractEmployeeAdvancesViewModel _SaleContractEmployeeAdvancesViewModel = new SaleContractEmployeeAdvancesViewModel();

                return View("/Views/Contract/SaleContractEmployeeAdvances/Index.cshtml", _SaleContractEmployeeAdvancesViewModel);
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
                return PartialView("/Views/Contract/SaleContractEmployeeAdvances/List.cshtml");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string ContractEmployeeMasterID,string ContractEmployeeMasterName)
        {
            SaleContractEmployeeAdvancesViewModel model = new SaleContractEmployeeAdvancesViewModel();
            try
            {
                model.ContractEmployeeMasterID = Convert.ToInt32(ContractEmployeeMasterID);
                model.ContractEmployeeMasterName = ContractEmployeeMasterName;

                List<SelectListItem> li_PaymentMode = new List<SelectListItem>();
                li_PaymentMode.Add(new SelectListItem { Text = "Card", Value = "1" });
                li_PaymentMode.Add(new SelectListItem { Text = "Cash", Value = "2" });
                ViewBag.PaymentModeList = new SelectList(li_PaymentMode, "Value", "Text");

                return PartialView("/Views/Contract/SaleContractEmployeeAdvances/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(SaleContractEmployeeAdvancesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.SaleContractEmployeeAdvancesDTO != null)
                    {
                        model.SaleContractEmployeeAdvancesDTO.ConnectionString = _connectioString;
                        model.SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterID = model.ContractEmployeeMasterID;
                        model.SaleContractEmployeeAdvancesDTO.ContractEmployeeMasterName = model.ContractEmployeeMasterName;
                        model.SaleContractEmployeeAdvancesDTO.TransactionDate = model.TransactionDate;
                        model.SaleContractEmployeeAdvancesDTO.AdvanceAmount = model.AdvanceAmount;
                        model.SaleContractEmployeeAdvancesDTO.PaymentMode = model.PaymentMode;

                        model.SaleContractEmployeeAdvancesDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);

                        IBaseEntityResponse<SaleContractEmployeeAdvances> response = _SaleContractEmployeeAdvancesBA.InsertSaleContractEmployeeAdvances(model.SaleContractEmployeeAdvancesDTO);
                        model.SaleContractEmployeeAdvancesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.SaleContractEmployeeAdvancesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        [NonAction]
        public IEnumerable<SaleContractEmployeeAdvancesViewModel> GetSaleContractEmployeeAdvances(out int TotalRecords,string ContractEmployeeMasterID)
        {
            try
            {
                SaleContractEmployeeAdvancesSearchRequest searchRequest = new SaleContractEmployeeAdvancesSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.ContractEmployeeMasterID = Convert.ToInt32(ContractEmployeeMasterID);
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

                List<SaleContractEmployeeAdvancesViewModel> listSaleContractEmployeeAdvancesViewModel = new List<SaleContractEmployeeAdvancesViewModel>();
                List<SaleContractEmployeeAdvances> listSaleContractEmployeeAdvances = new List<SaleContractEmployeeAdvances>();
                IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> baseEntityCollectionResponse = _SaleContractEmployeeAdvancesBA.GetBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractEmployeeAdvances = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractEmployeeAdvances item in listSaleContractEmployeeAdvances)
                        {
                            SaleContractEmployeeAdvancesViewModel SaleContractEmployeeAdvancesViewModel = new SaleContractEmployeeAdvancesViewModel();
                            SaleContractEmployeeAdvancesViewModel.SaleContractEmployeeAdvancesDTO = item;
                            listSaleContractEmployeeAdvancesViewModel.Add(SaleContractEmployeeAdvancesViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractEmployeeAdvancesViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,string ContractEmployeeMasterID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractEmployeeAdvancesViewModel> filteredSaleContractEmployeeAdvances;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TransactionDate";
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

            filteredSaleContractEmployeeAdvances = GetSaleContractEmployeeAdvances(out TotalRecords, ContractEmployeeMasterID);

            var records = filteredSaleContractEmployeeAdvances.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.TransactionDate), Convert.ToString(c.AdvanceAmount), Convert.ToString(c.RefundDate),Convert.ToString(c.RefundAmount),Convert.ToString(c.IsRefund) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


