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
    public class EmployeeOtherCollegeFinancialAssistanceDetailsController : BaseController
    {
        IEmployeeOtherCollegeFinancialAssistanceDetailsServiceAccess _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeOtherCollegeFinancialAssistanceDetailsController()
        {
            _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess = new EmployeeOtherCollegeFinancialAssistanceDetailsServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();

            model.EmployeeID = ID;
            ViewBag.EmployeeID = ID;
            //ViewBag.EmpID = ID;
            return View("~/Views/Employee/EmployeeOtherCollegeFinancialAssistanceDetails/Index.cshtml");

        }

        public ActionResult List(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();

                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return View("~/Views/Employee/EmployeeOtherCollegeFinancialAssistanceDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string Id)
        {
            EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();

            model.EmployeeID = Convert.ToInt32(Id);
          
            return PartialView("~/Views/Employee/EmployeeOtherCollegeFinancialAssistanceDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null)
                    {
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.FundingAgency = model.FundingAgency;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.AmountOfGrant = model.AmountOfGrant;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.PurposeOfGrant = model.PurposeOfGrant;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.Remarks = model.Remarks;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DateOfGrantReceived = model.DateOfGrantReceived;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsActive = model.IsActive;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> response = _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess.InsertEmployeeOtherCollegeFinancialAssistanceDetails(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO);
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();
            try
            {
                model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO = new EmployeeOtherCollegeFinancialAssistanceDetails();
                model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID = id;
                model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ConnectionString = _connectioString;
             
                IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> response = _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess.SelectByID(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID = response.Entity.ID;
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.FundingAgency = response.Entity.FundingAgency;
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.AmountOfGrant = response.Entity.AmountOfGrant;
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.PurposeOfGrant = response.Entity.PurposeOfGrant;
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.Remarks = response.Entity.Remarks;
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DateOfGrantReceived = response.Entity.DateOfGrantReceived;
                
                    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsActive = response.Entity.IsActive;
          
                }

              
                return PartialView("~/Views/Employee/EmployeeOtherCollegeFinancialAssistanceDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null)
                {
                    if (model != null && model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO != null)
                    {
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.FundingAgency = model.FundingAgency;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.AmountOfGrant = model.AmountOfGrant;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.PurposeOfGrant = model.PurposeOfGrant;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.Remarks = model.Remarks;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DateOfGrantReceived = model.DateOfGrantReceived;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.IsActive = model.IsActive;
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> response = _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess.UpdateEmployeeOtherCollegeFinancialAssistanceDetails(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO);
                        model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();
        //    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO = new EmployeeOtherCollegeFinancialAssistanceDetails();
        //    model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeOtherCollegeFinancialAssistanceDetails/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //        if (model.ID > 0)
        //        {
        //            EmployeeOtherCollegeFinancialAssistanceDetails EmployeeOtherCollegeFinancialAssistanceDetailsDTO = new EmployeeOtherCollegeFinancialAssistanceDetails();
        //            EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ConnectionString = _connectioString;
        //            EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID = model.ID;
        //            EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> response = _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess.DeleteEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetailsDTO);
        //            model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    return Json("Please review your form");
        //    //}
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            EmployeeOtherCollegeFinancialAssistanceDetailsViewModel model = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();

            if (ID > 0)
            {
                EmployeeOtherCollegeFinancialAssistanceDetails EmployeeOtherCollegeFinancialAssistanceDetailsDTO = new EmployeeOtherCollegeFinancialAssistanceDetails();
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ConnectionString = _connectioString;
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.ID = ID;
                EmployeeOtherCollegeFinancialAssistanceDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> response = _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess.DeleteEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetailsDTO);
                model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.EmployeeOtherCollegeFinancialAssistanceDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeeOtherCollegeFinancialAssistanceDetailsViewModel> GetEmployeeOtherCollegeFinancialAssistanceDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest searchRequest = new EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest();
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
                    searchRequest.EmployeeID = EmployeeID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
            }
            List<EmployeeOtherCollegeFinancialAssistanceDetailsViewModel> listEmployeeOtherCollegeFinancialAssistanceDetailsViewModel = new List<EmployeeOtherCollegeFinancialAssistanceDetailsViewModel>();
            List<EmployeeOtherCollegeFinancialAssistanceDetails> listEmployeeOtherCollegeFinancialAssistanceDetails = new List<EmployeeOtherCollegeFinancialAssistanceDetails>();
            IBaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails> baseEntityCollectionResponse = _EmployeeOtherCollegeFinancialAssistanceDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeOtherCollegeFinancialAssistanceDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeOtherCollegeFinancialAssistanceDetails item in listEmployeeOtherCollegeFinancialAssistanceDetails)
                    {
                        EmployeeOtherCollegeFinancialAssistanceDetailsViewModel EmployeeOtherCollegeFinancialAssistanceDetailsViewModel = new EmployeeOtherCollegeFinancialAssistanceDetailsViewModel();
                        EmployeeOtherCollegeFinancialAssistanceDetailsViewModel.EmployeeOtherCollegeFinancialAssistanceDetailsDTO = item;
                        listEmployeeOtherCollegeFinancialAssistanceDetailsViewModel.Add(EmployeeOtherCollegeFinancialAssistanceDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeOtherCollegeFinancialAssistanceDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(string EmployeeID, JQueryDataTableParamModel param)
        {
            //if (Session["UserType"] != null)
            //{
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeOtherCollegeFinancialAssistanceDetailsViewModel> filteredCountryMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                       _sortBy = "FundingAgency";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AmountOfGrant Like '%" + param.sSearch + "%' or PurposeOfGrant Like '%" + param.sSearch + "%' or DateOfGrantReceived Like '%" + param.sSearch + "%' or FundingAgency Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DateOfGrantReceived";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AmountOfGrant Like '%" + param.sSearch + "%' or PurposeOfGrant Like '%" + param.sSearch + "%' or DateOfGrantReceived Like '%" + param.sSearch + "%' or FundingAgency Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "AmountOfGrant";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AmountOfGrant Like '%" + param.sSearch + "%' or PurposeOfGrant Like '%" + param.sSearch + "%' or DateOfGrantReceived Like '%" + param.sSearch + "%' or FundingAgency Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "PurposeOfGrant";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AmountOfGrant Like '%" + param.sSearch + "%' or PurposeOfGrant Like '%" + param.sSearch + "%' or DateOfGrantReceived Like '%" + param.sSearch + "%' or FundingAgency Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
               
               
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetEmployeeOtherCollegeFinancialAssistanceDetails(Convert.ToInt32(EmployeeID), out TotalRecords);
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.FundingAgency.ToString(), c.DateOfGrantReceived.ToString(), c.AmountOfGrant.ToString(), c.PurposeOfGrant.ToString(), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{

            //    //return View("Login","Account");
            //    //return RedirectToAction("Login", "Account");
            //    var result = 0;
            //    return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            //    // return PartialView("Login");
            //}
        }
        #endregion
    }
}