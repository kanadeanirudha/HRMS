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
    public class GeneralPackageTypeController : BaseController
    {
        IGeneralPackageTypeBA _GeneralPackageTypeBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralPackageTypeController()
        {
            _GeneralPackageTypeBA = new GeneralPackageTypeBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralPackageType/Index.cshtml");
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
                GeneralPackageTypeViewModel model = new GeneralPackageTypeViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralPackageType/List.cshtml", model);
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
            GeneralPackageTypeViewModel model = new GeneralPackageTypeViewModel();



            return PartialView("/Views/Inventory/GeneralPackageType/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralPackageTypeViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralPackageTypeDTO != null)
                {
                    model.GeneralPackageTypeDTO.ConnectionString = _connectioString;

                    model.GeneralPackageTypeDTO.PackageType = model.PackageType;
                    model.GeneralPackageTypeDTO.Height = model.Height;
                    model.GeneralPackageTypeDTO.Length = model.Length;
                    model.GeneralPackageTypeDTO.Width = model.Width;
                    model.GeneralPackageTypeDTO.Weight = model.Weight;
                    model.GeneralPackageTypeDTO.Volume = model.Volume;
                    model.GeneralPackageTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralPackageType> response = _GeneralPackageTypeBA.InsertGeneralPackageType(model.GeneralPackageTypeDTO);

                    model.GeneralPackageTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralPackageTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(GeneralPackageTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralPackageTypeDTO != null)
                {
                    if (model != null && model.GeneralPackageTypeDTO != null)
                    {
                        model.GeneralPackageTypeDTO.ConnectionString = _connectioString;
                        //model.GeneralPackageTypeDTO.GeneralPackageTypeCode = model.GeneralPackageTypeCode;
                        //model.GeneralPackageTypeDTO.GeneralPackageTypeDescription = model.GeneralPackageTypeDescription;
                        //model.GeneralPackageTypeDTO.IsRelatedTo = model.IsRelatedTo;
                        model.GeneralPackageTypeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralPackageType> response = _GeneralPackageTypeBA.UpdateGeneralPackageType(model.GeneralPackageTypeDTO);
                        model.GeneralPackageTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralPackageTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                GeneralPackageTypeViewModel model = new GeneralPackageTypeViewModel();
                model.GeneralPackageTypeDTO = new GeneralPackageType();
                model.GeneralPackageTypeDTO.ID = Convert.ToInt16(ID);
                model.GeneralPackageTypeDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralPackageType> response = _GeneralPackageTypeBA.SelectByID(model.GeneralPackageTypeDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralPackageTypeDTO.PackageType = response.Entity.PackageType;
                    model.GeneralPackageTypeDTO.Height = response.Entity.Height;
                    model.GeneralPackageTypeDTO.Length = response.Entity.Length;
                    model.GeneralPackageTypeDTO.Width = response.Entity.Width;
                    model.GeneralPackageTypeDTO.Weight = response.Entity.Weight;
                    model.GeneralPackageTypeDTO.Volume = response.Entity.Volume;
                }

                return PartialView("/Views/Inventory/GeneralPackageType/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralPackageType> response = null;
                GeneralPackageType GeneralPackageTypeDTO = new GeneralPackageType();
                GeneralPackageTypeDTO.ConnectionString = _connectioString;
                GeneralPackageTypeDTO.ID = Convert.ToInt16(ID);
                GeneralPackageTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralPackageTypeBA.DeleteGeneralPackageType(GeneralPackageTypeDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralPackageTypeViewModel> GetGeneralPackageType(out int TotalRecords)
        {
            GeneralPackageTypeSearchRequest searchRequest = new GeneralPackageTypeSearchRequest();
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
            List<GeneralPackageTypeViewModel> listGeneralPackageTypeViewModel = new List<GeneralPackageTypeViewModel>();
            List<GeneralPackageType> listGeneralPackageType = new List<GeneralPackageType>();
            IBaseEntityCollectionResponse<GeneralPackageType> baseEntityCollectionResponse = _GeneralPackageTypeBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPackageType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralPackageType item in listGeneralPackageType)
                    {
                        GeneralPackageTypeViewModel GeneralPackageTypeViewModel = new GeneralPackageTypeViewModel();
                        GeneralPackageTypeViewModel.GeneralPackageTypeDTO = item;
                        listGeneralPackageTypeViewModel.Add(GeneralPackageTypeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralPackageTypeViewModel;
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

                IEnumerable<GeneralPackageTypeViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.PackageType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.PackageType Like '%" + param.sSearch + "%' or A.Height Like '%" + param.sSearch + "%' or A.Length Like '%" + param.sSearch + "%' or A.Width Like '%" + param.sSearch + "%' or A.Weight Like '%" + param.sSearch + "%' or A.Volume Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.Height";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            _searchBy = "A.PackageType Like '%" + param.sSearch + "%' or A.Height Like '%" + param.sSearch + "%' or A.Length Like '%" + param.sSearch + "%' or A.Width Like '%" + param.sSearch + "%' or A.Weight Like '%" + param.sSearch + "%' or A.Volume Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.Length";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.PackageType Like '%" + param.sSearch + "%' or A.Height Like '%" + param.sSearch + "%' or A.Length Like '%" + param.sSearch + "%' or A.Width Like '%" + param.sSearch + "%' or A.Weight Like '%" + param.sSearch + "%' or A.Volume Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.Width";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.PackageType Like '%" + param.sSearch + "%' or A.Height Like '%" + param.sSearch + "%' or A.Length Like '%" + param.sSearch + "%' or A.Width Like '%" + param.sSearch + "%' or A.Weight Like '%" + param.sSearch + "%' or A.Volume Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.Weight";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.PackageType Like '%" + param.sSearch + "%' or A.Height Like '%" + param.sSearch + "%' or A.Length Like '%" + param.sSearch + "%' or A.Width Like '%" + param.sSearch + "%' or A.Weight Like '%" + param.sSearch + "%' or A.Volume Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "A.Volume";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.PackageType Like '%" + param.sSearch + "%' or A.Height Like '%" + param.sSearch + "%' or A.Length Like '%" + param.sSearch + "%' or A.Width Like '%" + param.sSearch + "%' or A.Weight Like '%" + param.sSearch + "%' or A.Volume Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralPackageType(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.PackageType), Convert.ToString(c.Height), Convert.ToString(c.Length), Convert.ToString(c.Width), Convert.ToString(c.Weight), Convert.ToString(c.Volume), Convert.ToString(c.ID) };

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