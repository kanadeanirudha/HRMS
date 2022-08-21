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

namespace AMS.Web.UI.Controllers
{
    public class EmployeeAssociatesProfessionalBodiesController : BaseController
    {
        IEmployeeAssociatesProfessionalBodiesServiceAccess _EmployeeAssociatesProfessionalBodiesServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeAssociatesProfessionalBodiesController()
        {
            _EmployeeAssociatesProfessionalBodiesServiceAccess = new EmployeeAssociatesProfessionalBodiesServiceAccess();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeAssociatesProfessionalBodies/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeAssociatesProfessionalBodiesViewModel model = new EmployeeAssociatesProfessionalBodiesViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.EmployeeAssociatesProfessionalBodiesDTO.EmployeeID = EmployeeID;
                model.EmployeeAssociatesProfessionalBodiesDTO.ConnectionString = _connectioString;
                model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeeAssociatesProfessionalBodies/List.cshtml", model);
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
            EmployeeAssociatesProfessionalBodiesViewModel model = new EmployeeAssociatesProfessionalBodiesViewModel();
            return PartialView("/Views/Employee/EmployeeAssociatesProfessionalBodies/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeAssociatesProfessionalBodiesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeAssociatesProfessionalBodiesDTO != null)
                    {
                        model.EmployeeAssociatesProfessionalBodiesDTO.ConnectionString = _connectioString;
                        model.EmployeeAssociatesProfessionalBodiesDTO.EmployeeID = model.EmployeeID;                        
                        model.EmployeeAssociatesProfessionalBodiesDTO.ActivityName = model.ActivityName;
                        model.EmployeeAssociatesProfessionalBodiesDTO.FromPeriod = model.FromPeriod;
                        model.EmployeeAssociatesProfessionalBodiesDTO.UptoPeriod = model.UptoPeriod;
                        model.EmployeeAssociatesProfessionalBodiesDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> response = _EmployeeAssociatesProfessionalBodiesServiceAccess .InsertEmployeeAssociatesProfessionalBodies(model.EmployeeAssociatesProfessionalBodiesDTO);
                        model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            EmployeeAssociatesProfessionalBodiesViewModel model = new EmployeeAssociatesProfessionalBodiesViewModel();
            model.EmployeeAssociatesProfessionalBodiesDTO = new EmployeeAssociatesProfessionalBodies();
            model.EmployeeAssociatesProfessionalBodiesDTO.ID = ID;
            model.EmployeeAssociatesProfessionalBodiesDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> response = _EmployeeAssociatesProfessionalBodiesServiceAccess .SelectByID(model.EmployeeAssociatesProfessionalBodiesDTO);

            if (response != null && response.Entity != null)
            {
              
                model.EmployeeAssociatesProfessionalBodiesDTO.ID = response.Entity.ID;
                model.EmployeeAssociatesProfessionalBodiesDTO.EmployeeID = response.Entity.EmployeeID;
                model.EmployeeAssociatesProfessionalBodiesDTO.ActivityName = response.Entity.ActivityName;
                model.EmployeeAssociatesProfessionalBodiesDTO.FromPeriod = response.Entity.FromPeriod;
                model.EmployeeAssociatesProfessionalBodiesDTO.UptoPeriod = response.Entity.UptoPeriod;
            }
            return PartialView("/Views/Employee/EmployeeAssociatesProfessionalBodies/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeAssociatesProfessionalBodiesViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeAssociatesProfessionalBodiesDTO != null)
                    {
                        if (model != null && model.EmployeeAssociatesProfessionalBodiesDTO != null)
                        {
                            model.EmployeeAssociatesProfessionalBodiesDTO.ConnectionString = _connectioString;
                            model.EmployeeAssociatesProfessionalBodiesDTO.ID = model.ID;
                            model.EmployeeAssociatesProfessionalBodiesDTO.EmployeeID = model.EmployeeID;
                            model.EmployeeAssociatesProfessionalBodiesDTO.ActivityName = model.ActivityName;
                            model.EmployeeAssociatesProfessionalBodiesDTO.FromPeriod = model.FromPeriod;
                            model.EmployeeAssociatesProfessionalBodiesDTO.UptoPeriod = model.UptoPeriod;
                            model.EmployeeAssociatesProfessionalBodiesDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> response = _EmployeeAssociatesProfessionalBodiesServiceAccess .UpdateEmployeeAssociatesProfessionalBodies(model.EmployeeAssociatesProfessionalBodiesDTO);
                            model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeAssociatesProfessionalBodiesViewModel model = new EmployeeAssociatesProfessionalBodiesViewModel();
        //    model.EmployeeAssociatesProfessionalBodiesDTO = new EmployeeAssociatesProfessionalBodies();
        //    model.EmployeeAssociatesProfessionalBodiesDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeAssociatesProfessionalBodies/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeeAssociatesProfessionalBodiesViewModel model)
        //{
        //    try
        //    {

        //        if (model.ID > 0)
        //        {
        //            if (model != null && model.EmployeeAssociatesProfessionalBodiesDTO != null)
        //            {
        //                EmployeeAssociatesProfessionalBodies EmployeeAssociatesProfessionalBodiesDTO = new EmployeeAssociatesProfessionalBodies();
        //                EmployeeAssociatesProfessionalBodiesDTO.ConnectionString = _connectioString;
        //                EmployeeAssociatesProfessionalBodiesDTO.ID = model.ID;
        //                EmployeeAssociatesProfessionalBodiesDTO.DeletedBy = model.DeletedBy;
        //                EmployeeAssociatesProfessionalBodiesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> response = _EmployeeAssociatesProfessionalBodiesServiceAccess .DeleteEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodiesDTO);
        //                model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }
        //            return Json(model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            EmployeeAssociatesProfessionalBodiesViewModel model = new EmployeeAssociatesProfessionalBodiesViewModel();
            try
            {

                if (ID > 0)
                {
                    
                        EmployeeAssociatesProfessionalBodies EmployeeAssociatesProfessionalBodiesDTO = new EmployeeAssociatesProfessionalBodies();
                        EmployeeAssociatesProfessionalBodiesDTO.ConnectionString = _connectioString;
                        EmployeeAssociatesProfessionalBodiesDTO.ID = ID;
                        EmployeeAssociatesProfessionalBodiesDTO.DeletedBy = model.DeletedBy;
                        EmployeeAssociatesProfessionalBodiesDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> response = _EmployeeAssociatesProfessionalBodiesServiceAccess.DeleteEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodiesDTO);
                        model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.EmployeeAssociatesProfessionalBodiesDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Methods
        #region Methods
        public IEnumerable<EmployeeAssociatesProfessionalBodiesViewModel> GetEmployeeAssociatesProfessionalBodiesDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeAssociatesProfessionalBodiesSearchRequest searchRequest = new EmployeeAssociatesProfessionalBodiesSearchRequest();
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
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
            }
            List<EmployeeAssociatesProfessionalBodiesViewModel> listEmployeeAssociatesProfessionalBodiesViewModel = new List<EmployeeAssociatesProfessionalBodiesViewModel>();
            List<EmployeeAssociatesProfessionalBodies> listEmployeeAssociatesProfessionalBodies = new List<EmployeeAssociatesProfessionalBodies>();
            IBaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies> baseEntityCollectionResponse = _EmployeeAssociatesProfessionalBodiesServiceAccess .GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeAssociatesProfessionalBodies = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeAssociatesProfessionalBodies item in listEmployeeAssociatesProfessionalBodies)
                    {
                        EmployeeAssociatesProfessionalBodiesViewModel _EmployeeAssociatesProfessionalBodiesViewModel = new EmployeeAssociatesProfessionalBodiesViewModel();
                        _EmployeeAssociatesProfessionalBodiesViewModel.EmployeeAssociatesProfessionalBodiesDTO = item;
                        listEmployeeAssociatesProfessionalBodiesViewModel.Add(_EmployeeAssociatesProfessionalBodiesViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeAssociatesProfessionalBodiesViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeAssociatesProfessionalBodiesViewModel> filteredEmployeeAssociatesProfessionalBodies;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ActivityName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ActivityName Like '%" + param.sSearch + "%' or FromPeriod Like '%" + param.sSearch + "%' or UptoPeriod Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "FromPeriod";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "Description Like '%" + param.sSearch + "%' or FromPeriod Like '%" + param.sSearch + "%' or UptoPeriod Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "UptoPeriod";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ActivityName Like '%" + param.sSearch + "%' or FromPeriod Like '%" + param.sSearch + "%' or UptoPeriod Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeAssociatesProfessionalBodies = GetEmployeeAssociatesProfessionalBodiesDetails(EmployeeID, out TotalRecords);
            var records = filteredEmployeeAssociatesProfessionalBodies.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] {Convert.ToString(c.ActivityName), c.FromPeriod.ToString(), c.UptoPeriod.ToString(),Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


