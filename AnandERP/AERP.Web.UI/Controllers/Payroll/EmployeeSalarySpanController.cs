using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AERP.Web.UI.Controllers.Payroll
{
    public class EmployeeSalarySpanController : BaseController
    {
        IEmployeeSalarySpanBA _EmployeeSalarySpanBA = null;
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

        public EmployeeSalarySpanController()
        {
            _EmployeeSalarySpanBA = new EmployeeSalarySpanBA();
        }
        // GET: EmployeeSalarySpan
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["HR Manager"]) > 0 && IsApplied == true))
            {
                return View("/Views/Payroll/EmployeeSalarySpan/index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List()
        {
            try
            {
                EmployeeSalarySpanViewModel model = new EmployeeSalarySpanViewModel();
                return PartialView("/Views/Payroll/EmployeeSalarySpan/List.cshtml", model);
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
            EmployeeSalarySpanViewModel model = new EmployeeSalarySpanViewModel();
            return PartialView("/Views/Payroll/EmployeeSalarySpan/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeSalarySpanViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.EmployeeSalarySpanDTO != null)
                {
                    model.EmployeeSalarySpanDTO.ConnectionString = _connectioString;
                    model.EmployeeSalarySpanDTO.FromDate = model.FromDate;
                    model.EmployeeSalarySpanDTO.UptoDate = model.UptoDate;
                 

                    model.EmployeeSalarySpanDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeSalarySpan> response = _EmployeeSalarySpanBA.InsertEmployeeSalarySpan(model.EmployeeSalarySpanDTO);

                    model.EmployeeSalarySpanDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EmployeeSalarySpanDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(Int16 ID)
        {
            EmployeeSalarySpanViewModel model = new EmployeeSalarySpanViewModel();
            try
            {
                model.EmployeeSalarySpanDTO = new EmployeeSalarySpan();
                model.EmployeeSalarySpanDTO.ID = ID;
                model.EmployeeSalarySpanDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmployeeSalarySpan> response = _EmployeeSalarySpanBA.SelectByID(model.EmployeeSalarySpanDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeSalarySpanDTO.ID = response.Entity.ID;
                    model.EmployeeSalarySpanDTO.FromDate = response.Entity.FromDate;
                    model.EmployeeSalarySpanDTO.UptoDate = response.Entity.UptoDate;
                    model.EmployeeSalarySpanDTO.IsActive = response.Entity.IsActive;
                    model.EmployeeSalarySpanDTO.IsSalaryGenerated = response.Entity.IsSalaryGenerated;
                    model.EmployeeSalarySpanDTO.CompletionDate = response.Entity.CompletionDate;

                }
                return PartialView("/Views/Payroll/EmployeeSalarySpan/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeSalarySpanViewModel model)
        {
            //  if (ModelState.IsValid)
            {
                if (model != null && model.EmployeeSalarySpanDTO != null)
                {
                    if (model != null && model.EmployeeSalarySpanDTO != null)
                    {
                        model.EmployeeSalarySpanDTO.ConnectionString = _connectioString;
                        model.EmployeeSalarySpanDTO.ID = model.ID;
                        model.EmployeeSalarySpanDTO.IsActive = model.IsActive;
                        model.EmployeeSalarySpanDTO.IsSalaryGenerated = model.IsSalaryGenerated;
                        model.EmployeeSalarySpanDTO.CompletionDate = model.CompletionDate;

                        model.EmployeeSalarySpanDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeSalarySpan> response = _EmployeeSalarySpanBA.UpdateEmployeeSalarySpan(model.EmployeeSalarySpanDTO);
                        model.EmployeeSalarySpanDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmployeeSalarySpanDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            /*   else
               {
                   return Json("Please review your form");
               }*/
        }

        #region Methods
        public IEnumerable<EmployeeSalarySpanViewModel> GetEmployeeSalarySpan(out int TotalRecords)
        {
            EmployeeSalarySpanSearchRequest searchRequest = new EmployeeSalarySpanSearchRequest();
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
                searchRequest.SortBy = "CreatedDate";                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = "Desc";
            }
            List<EmployeeSalarySpanViewModel> listEmployeeSalarySpanViewModel = new List<EmployeeSalarySpanViewModel>();
            List<EmployeeSalarySpan> listEmployeeSalarySpan = new List<EmployeeSalarySpan>();
            IBaseEntityCollectionResponse<EmployeeSalarySpan> baseEntityCollectionResponse = _EmployeeSalarySpanBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSalarySpan = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeSalarySpan item in listEmployeeSalarySpan)
                    {
                        EmployeeSalarySpanViewModel EmployeeSalarySpanViewModel = new EmployeeSalarySpanViewModel();
                        EmployeeSalarySpanViewModel.EmployeeSalarySpanDTO = item;
                        listEmployeeSalarySpanViewModel.Add(EmployeeSalarySpanViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeSalarySpanViewModel;
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EmployeeSalarySpanViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CreatedDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "FromDate Like '%" + param.sSearch + "%' || UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = "Asc";
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetEmployeeSalarySpan(out TotalRecords);

                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.FromDate), Convert.ToString(c.UptoDate), Convert.ToString(c.ID) };

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