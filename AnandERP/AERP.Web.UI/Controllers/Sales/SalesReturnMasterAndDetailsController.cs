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
    public class SalesReturnMasterAndDetailsController : BaseController
    {
        ISalesReturnMasterAndDetailsBA _SalesReturnMasterAndDetailsBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalesReturnMasterAndDetailsController()
        {
            _SalesReturnMasterAndDetailsBA = new SalesReturnMasterAndDetailsBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                SalesReturnMasterAndDetailsViewModel model = new SalesReturnMasterAndDetailsViewModel();
                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
                {
                    return View("/Views/Sales/SalesReturnMasterAndDetails/Index.cshtml");
                }
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
                SalesReturnMasterAndDetailsViewModel model = new SalesReturnMasterAndDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Sales/SalesReturnMasterAndDetails/List.cshtml", model);
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
            SalesReturnMasterAndDetailsViewModel model = new SalesReturnMasterAndDetailsViewModel();
            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
            List<SelectListItem> listLocationMaster = new List<SelectListItem>();
            foreach (InventoryLocationMaster item in locationMasterList)
            {
                listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            return PartialView("/Views/Sales/SalesReturnMasterAndDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalesReturnMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalesReturnMasterAndDetailsDTO != null)
                {
                    model.SalesReturnMasterAndDetailsDTO.ConnectionString = _connectioString;
                    //model.SalesReturnMasterAndDetailsDTO.CompanyName = model.CompanyName;
                    //model.SalesReturnMasterAndDetailsDTO.Email = model.Email;
                    //model.SalesReturnMasterAndDetailsDTO.PhoneNumber = model.PhoneNumber;
                    //model.SalesReturnMasterAndDetailsDTO.MobileNumber = model.MobileNumber;

                    model.SalesReturnMasterAndDetailsDTO.IsActive = model.IsActive;
                    model.SalesReturnMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesReturnMasterAndDetails> response = _SalesReturnMasterAndDetailsBA.InsertSalesReturnMasterAndDetails(model.SalesReturnMasterAndDetailsDTO);

                    model.SalesReturnMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesReturnMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(SalesReturnMasterAndDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.SalesReturnMasterAndDetailsDTO != null)
                {
                    if (model != null && model.SalesReturnMasterAndDetailsDTO != null)
                    {
                        model.SalesReturnMasterAndDetailsDTO.ConnectionString = _connectioString;
                        // model.SalesReturnMasterAndDetailsDTO.CompanyName = model.CompanyName;

                        model.SalesReturnMasterAndDetailsDTO.IsActive = model.IsActive;

                        model.SalesReturnMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SalesReturnMasterAndDetails> response = _SalesReturnMasterAndDetailsBA.UpdateSalesReturnMasterAndDetails(model.SalesReturnMasterAndDetailsDTO);
                        model.SalesReturnMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.SalesReturnMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                IBaseEntityResponse<SalesReturnMasterAndDetails> response = null;
                SalesReturnMasterAndDetails SalesReturnMasterAndDetailsDTO = new SalesReturnMasterAndDetails();
                SalesReturnMasterAndDetailsDTO.ConnectionString = _connectioString;
                SalesReturnMasterAndDetailsDTO.ID = Convert.ToInt16(ID);
                SalesReturnMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalesReturnMasterAndDetailsBA.DeleteSalesReturnMasterAndDetails(SalesReturnMasterAndDetailsDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int AdminRoleID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleID = AdminRoleID;
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterlistByAdminRole(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalesReturnMasterAndDetailsViewModel> GetSalesReturnMasterAndDetails(out int TotalRecords)
        {
            SalesReturnMasterAndDetailsSearchRequest searchRequest = new SalesReturnMasterAndDetailsSearchRequest();
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
            List<SalesReturnMasterAndDetailsViewModel> listSalesReturnMasterAndDetailsViewModel = new List<SalesReturnMasterAndDetailsViewModel>();
            List<SalesReturnMasterAndDetails> listSalesReturnMasterAndDetails = new List<SalesReturnMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> baseEntityCollectionResponse = _SalesReturnMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesReturnMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesReturnMasterAndDetails item in listSalesReturnMasterAndDetails)
                    {
                        SalesReturnMasterAndDetailsViewModel SalesReturnMasterAndDetailsViewModel = new SalesReturnMasterAndDetailsViewModel();
                        SalesReturnMasterAndDetailsViewModel.SalesReturnMasterAndDetailsDTO = item;
                        listSalesReturnMasterAndDetailsViewModel.Add(SalesReturnMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesReturnMasterAndDetailsViewModel;
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

                IEnumerable<SalesReturnMasterAndDetailsViewModel> filteredGroupDescription;
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
                filteredGroupDescription = GetSalesReturnMasterAndDetails(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ID) };

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