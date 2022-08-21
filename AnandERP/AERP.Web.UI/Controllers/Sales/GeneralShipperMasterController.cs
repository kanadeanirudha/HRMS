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
    public class GeneralShipperMasterController : BaseController
    {
        IGeneralShipperMasterBA _GeneralShipperMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralShipperMasterController()
        {
            _GeneralShipperMasterBA = new GeneralShipperMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))

            {
                return View("/Views/Sales/GeneralShipperMaster/Index.cshtml");
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
                GeneralShipperMasterViewModel model = new GeneralShipperMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Sales/GeneralShipperMaster/List.cshtml", model);
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
            GeneralShipperMasterViewModel model = new GeneralShipperMasterViewModel();
            return PartialView("/Views/Sales/GeneralShipperMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralShipperMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralShipperMasterDTO != null)
                {
                    model.GeneralShipperMasterDTO.ConnectionString = _connectioString;
                    model.GeneralShipperMasterDTO.CompanyName = model.CompanyName;
                    model.GeneralShipperMasterDTO.Email = model.Email;
                    model.GeneralShipperMasterDTO.PhoneNumber = model.PhoneNumber;
                    model.GeneralShipperMasterDTO.MobileNumber = model.MobileNumber;

                    model.GeneralShipperMasterDTO.IsActive = model.IsActive;
                    model.GeneralShipperMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralShipperMaster> response = _GeneralShipperMasterBA.InsertGeneralShipperMaster(model.GeneralShipperMasterDTO);

                    model.GeneralShipperMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralShipperMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

   

        [HttpPost]
        public ActionResult Edit(GeneralShipperMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralShipperMasterDTO != null)
                {
                    if (model != null && model.GeneralShipperMasterDTO != null)
                    {
                        model.GeneralShipperMasterDTO.ConnectionString = _connectioString;
                        model.GeneralShipperMasterDTO.CompanyName = model.CompanyName;

                        model.GeneralShipperMasterDTO.IsActive = model.IsActive;

                        model.GeneralShipperMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralShipperMaster> response = _GeneralShipperMasterBA.UpdateGeneralShipperMaster(model.GeneralShipperMasterDTO);
                        model.GeneralShipperMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralShipperMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

   

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralShipperMaster> response = null;
                GeneralShipperMaster GeneralShipperMasterDTO = new GeneralShipperMaster();
                GeneralShipperMasterDTO.ConnectionString = _connectioString;
                GeneralShipperMasterDTO.ID = Convert.ToInt16(ID);
                GeneralShipperMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralShipperMasterBA.DeleteGeneralShipperMaster(GeneralShipperMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralShipperMasterViewModel> GetGeneralShipperMaster(out int TotalRecords)
        {
            GeneralShipperMasterSearchRequest searchRequest = new GeneralShipperMasterSearchRequest();
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
            List<GeneralShipperMasterViewModel> listGeneralShipperMasterViewModel = new List<GeneralShipperMasterViewModel>();
            List<GeneralShipperMaster> listGeneralShipperMaster = new List<GeneralShipperMaster>();
            IBaseEntityCollectionResponse<GeneralShipperMaster> baseEntityCollectionResponse = _GeneralShipperMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralShipperMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralShipperMaster item in listGeneralShipperMaster)
                    {
                        GeneralShipperMasterViewModel GeneralShipperMasterViewModel = new GeneralShipperMasterViewModel();
                        GeneralShipperMasterViewModel.GeneralShipperMasterDTO = item;
                        listGeneralShipperMasterViewModel.Add(GeneralShipperMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralShipperMasterViewModel;
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

                IEnumerable<GeneralShipperMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CompanyName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.CompanyName Like '%" + param.sSearch + "%'";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralShipperMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CompanyName), Convert.ToString(c.Email), Convert.ToString(c.PhoneNumber), Convert.ToString(c.MobileNumber), Convert.ToString(c.ID) };

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