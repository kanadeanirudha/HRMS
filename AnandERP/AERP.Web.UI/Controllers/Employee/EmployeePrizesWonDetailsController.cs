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
    public class EmployeePrizesWonDetailsController : BaseController
    {
        IEmployeePrizesWonDetailsServiceAccess _EmployeePrizesWonDetailsServiceAcess = null;
        IGeneralLevelMasterServiceAccess _generalLevelMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeePrizesWonDetailsController()
        {
            _EmployeePrizesWonDetailsServiceAcess = new EmployeePrizesWonDetailsServiceAccess();
            _generalLevelMasterServiceAccess = new GeneralLevelMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();

            model.EmployeeID = ID;
            ViewBag.EmployeeID = ID;
            //ViewBag.EmpID = ID;
            return View("~/Views/Employee/EmployeePrizesWonDetails/Index.cshtml");

        }

        public ActionResult List(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();

                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return View("~/Views/Employee/EmployeePrizesWonDetails/List.cshtml", model);
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
            EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();

            model.EmployeeID = Convert.ToInt32(Id);
            List<GeneralLevelMaster> GeneralLevelMasterList = GetListGeneralLevelMaster();
            List<SelectListItem> GeneralLevelMaster = new List<SelectListItem>();
            foreach (GeneralLevelMaster item in GeneralLevelMasterList)
            {
                GeneralLevelMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }
            ViewBag.GeneralLevelMaster = new SelectList(GeneralLevelMaster, "Value", "Text");
            return PartialView("~/Views/Employee/EmployeePrizesWonDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeePrizesWonDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeePrizesWonDetailsDTO != null)
                    {
                        model.EmployeePrizesWonDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeePrizesWonDetailsDTO.GeneralLevelMasterID = model.GeneralLevelMasterID;
                        model.EmployeePrizesWonDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeePrizesWonDetailsDTO.PrizeName = model.PrizeName;
                        model.EmployeePrizesWonDetailsDTO.PrizeGivenBy = model.PrizeGivenBy;
                        model.EmployeePrizesWonDetailsDTO.Remark = model.Remark;
                        model.EmployeePrizesWonDetailsDTO.PrizeIssuingAuthority = model.PrizeIssuingAuthority;
                        model.EmployeePrizesWonDetailsDTO.PrizeReceivingDate = model.PrizeReceivingDate;
                        model.EmployeePrizesWonDetailsDTO.IsActive = model.IsActive;
                        model.EmployeePrizesWonDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeePrizesWonDetails> response = _EmployeePrizesWonDetailsServiceAcess.InsertEmployeePrizesWonDetails(model.EmployeePrizesWonDetailsDTO);
                        model.EmployeePrizesWonDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeePrizesWonDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();
            try
            {
                model.EmployeePrizesWonDetailsDTO = new EmployeePrizesWonDetails();
                model.EmployeePrizesWonDetailsDTO.ID = id;
                model.EmployeePrizesWonDetailsDTO.ConnectionString = _connectioString;
                List<GeneralLevelMaster> GeneralLevelMasterList = GetListGeneralLevelMaster();
                List<SelectListItem> GeneralLevelMaster = new List<SelectListItem>();
                foreach (GeneralLevelMaster item in GeneralLevelMasterList)
                {
                    GeneralLevelMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
              
                IBaseEntityResponse<EmployeePrizesWonDetails> response = _EmployeePrizesWonDetailsServiceAcess.SelectByID(model.EmployeePrizesWonDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeePrizesWonDetailsDTO.ID = response.Entity.ID;
                    model.EmployeePrizesWonDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeePrizesWonDetailsDTO.GeneralLevelMasterID = response.Entity.GeneralLevelMasterID;
                    model.EmployeePrizesWonDetailsDTO.PrizeName = response.Entity.PrizeName;
                    model.EmployeePrizesWonDetailsDTO.PrizeGivenBy = response.Entity.PrizeGivenBy;
                      model.EmployeePrizesWonDetailsDTO.PrizeIssuingAuthority = response.Entity.PrizeIssuingAuthority;
                      model.EmployeePrizesWonDetailsDTO.PrizeReceivingDate = response.Entity.PrizeReceivingDate;
                    model.EmployeePrizesWonDetailsDTO.Remark = response.Entity.Remark;
                  
           
                }

                ViewBag.GeneralLevelMaster = new SelectList(GeneralLevelMaster, "Value", "Text");

                return PartialView("~/Views/Employee/EmployeePrizesWonDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeePrizesWonDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.EmployeePrizesWonDetailsDTO != null)
                {
                    if (model != null && model.EmployeePrizesWonDetailsDTO != null)
                    {
                        model.EmployeePrizesWonDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeePrizesWonDetailsDTO.GeneralLevelMasterID = model.GeneralLevelMasterID;
                        model.EmployeePrizesWonDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeePrizesWonDetailsDTO.PrizeName = model.PrizeName;
                        model.EmployeePrizesWonDetailsDTO.PrizeGivenBy = model.PrizeGivenBy;
                        model.EmployeePrizesWonDetailsDTO.Remark = model.Remark;
                        model.EmployeePrizesWonDetailsDTO.PrizeIssuingAuthority = model.PrizeIssuingAuthority;
                        model.EmployeePrizesWonDetailsDTO.PrizeReceivingDate = model.PrizeReceivingDate;
                        model.EmployeePrizesWonDetailsDTO.IsActive = model.IsActive;
                        model.EmployeePrizesWonDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeePrizesWonDetails> response = _EmployeePrizesWonDetailsServiceAcess.UpdateEmployeePrizesWonDetails(model.EmployeePrizesWonDetailsDTO);
                        model.EmployeePrizesWonDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmployeePrizesWonDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();
        //    model.EmployeePrizesWonDetailsDTO = new EmployeePrizesWonDetails();
        //    model.EmployeePrizesWonDetailsDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeePrizesWonDetails/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeePrizesWonDetailsViewModel model)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    if (model.ID > 0)
        //    {
        //        EmployeePrizesWonDetails EmployeePrizesWonDetailsDTO = new EmployeePrizesWonDetails();
        //        EmployeePrizesWonDetailsDTO.ConnectionString = _connectioString;
        //        EmployeePrizesWonDetailsDTO.ID = model.ID;
        //        EmployeePrizesWonDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //        IBaseEntityResponse<EmployeePrizesWonDetails> response = _EmployeePrizesWonDetailsServiceAcess.DeleteEmployeePrizesWonDetails(EmployeePrizesWonDetailsDTO);
        //        model.EmployeePrizesWonDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //    }
        //    return Json(model.EmployeePrizesWonDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    //}
        //    //else
        //    //{
        //    //    return Json("Please review your form");
        //    //}
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {

            EmployeePrizesWonDetailsViewModel model = new EmployeePrizesWonDetailsViewModel();
            if (ID > 0)
            {
                EmployeePrizesWonDetails EmployeePrizesWonDetailsDTO = new EmployeePrizesWonDetails();
                EmployeePrizesWonDetailsDTO.ConnectionString = _connectioString;
                EmployeePrizesWonDetailsDTO.ID = ID;
                EmployeePrizesWonDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<EmployeePrizesWonDetails> response = _EmployeePrizesWonDetailsServiceAcess.DeleteEmployeePrizesWonDetails(EmployeePrizesWonDetailsDTO);
                model.EmployeePrizesWonDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.EmployeePrizesWonDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            
        }
        #endregion

        // Non-Action Method
        #region Methods
        protected List<GeneralLevelMaster> GetListGeneralLevelMaster()
        {
            GeneralLevelMasterSearchRequest searchRequest = new GeneralLevelMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralLevelMaster> listGeneralLevelMaster = new List<GeneralLevelMaster>();
            IBaseEntityCollectionResponse<GeneralLevelMaster> baseEntityCollectionResponse = _generalLevelMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLevelMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLevelMaster;
        }
        public IEnumerable<EmployeePrizesWonDetailsViewModel> GetEmployeePrizesWonDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeePrizesWonDetailsSearchRequest searchRequest = new EmployeePrizesWonDetailsSearchRequest();
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
                    searchRequest.EmployeeID = EmployeeID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<EmployeePrizesWonDetailsViewModel> listEmployeePrizesWonDetailsViewModel = new List<EmployeePrizesWonDetailsViewModel>();
            List<EmployeePrizesWonDetails> listEmployeePrizesWonDetails = new List<EmployeePrizesWonDetails>();
            IBaseEntityCollectionResponse<EmployeePrizesWonDetails> baseEntityCollectionResponse = _EmployeePrizesWonDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeePrizesWonDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeePrizesWonDetails item in listEmployeePrizesWonDetails)
                    {
                        EmployeePrizesWonDetailsViewModel EmployeePrizesWonDetailsViewModel = new EmployeePrizesWonDetailsViewModel();
                        EmployeePrizesWonDetailsViewModel.EmployeePrizesWonDetailsDTO = item;
                        listEmployeePrizesWonDetailsViewModel.Add(EmployeePrizesWonDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeePrizesWonDetailsViewModel;
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

            IEnumerable<EmployeePrizesWonDetailsViewModel> filteredCountryMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.PrizeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.PrizeName Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%' or A.PrizeGivenBy Like '%" + param.sSearch + "%' or A.PrizeIssuingAuthority Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "B.Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.PrizeName Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%' or A.PrizeGivenBy Like '%" + param.sSearch + "%' or A.PrizeIssuingAuthority Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.PrizeGivenBy";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.PrizeName Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%' or A.PrizeGivenBy Like '%" + param.sSearch + "%' or A.PrizeIssuingAuthority Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.PrizeIssuingAuthority";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.PrizeName Like '%" + param.sSearch + "%' or B.Description Like '%" + param.sSearch + "%' or A.PrizeGivenBy Like '%" + param.sSearch + "%' or A.PrizeIssuingAuthority Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetEmployeePrizesWonDetails(Convert.ToInt32(EmployeeID), out TotalRecords);
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.PrizeName.ToString(), c.GeneralLevelName.ToString(), c.PrizeGivenBy.ToString(), c.PrizeIssuingAuthority.ToString(), Convert.ToString(c.ID) };

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