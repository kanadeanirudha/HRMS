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
    public class CCRMTonerRequestAuthorisationController : BaseController
    {
        ICCRMTonerRequestAuthorisationBA _CCRMTonerRequestAuthorisationBA = null;
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

        public CCRMTonerRequestAuthorisationController()
        {
            _CCRMTonerRequestAuthorisationBA = new CCRMTonerRequestAuthorisationBA();

        }
        #region Controller Methods
        // GET: CCRMTonerRequestAuthorisation
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMTonerRequestAuthorisation/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        public ActionResult List(string actionMode, string FromDate, string UptoDate)
        {
            try
            {
                CCRMTonerRequestAuthorisationViewModel model = new CCRMTonerRequestAuthorisationViewModel();
                model.FromDate = FromDate;
                model.UptoDate = UptoDate;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;

                }
                return PartialView("/Views/CCRM/CCRMTonerRequestAuthorisation/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult Edit(Int32 id)
        {
            CCRMTonerRequestAuthorisationViewModel model = new CCRMTonerRequestAuthorisationViewModel();
            // CCRMTonerRequestAuthorisationSearchRequest searchRequest = new CCRMTonerRequestAuthorisationSearchRequest();
            //*********************Authorised*********************//
            List<SelectListItem> Authorised = new List<SelectListItem>();
            ViewBag.Authorised = new SelectList(Authorised, "Value", "Text");
            List<SelectListItem> li_Authorised = new List<SelectListItem>();

            if (model.CCRMTonerRequestAuthorisationDTO.Authorised > 0)
            {
                li_Authorised.Add(new SelectListItem { Text = "Pending", Value = "1" });
                li_Authorised.Add(new SelectListItem { Text = "Allow", Value = "2" });
                li_Authorised.Add(new SelectListItem { Text = "Low Yield", Value = "3" });
                li_Authorised.Add(new SelectListItem { Text = "Reject", Value = "4" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["Authorised"] = new SelectList(li_Authorised, "Value", "Text", (model.CCRMTonerRequestAuthorisationDTO.Authorised).ToString().Trim());
            }
            else
            {

                li_Authorised.Add(new SelectListItem { Text = "Pending", Value = "1" });
                li_Authorised.Add(new SelectListItem { Text = "Allow", Value = "2" });
                li_Authorised.Add(new SelectListItem { Text = "Low Yield", Value = "3" });
                li_Authorised.Add(new SelectListItem { Text = "Reject", Value = "4" });
                ViewData["Authorised"] = li_Authorised;
            }
            try
            {



                model.CCRMTonerRequestAuthorisationDTO = new CCRMTonerRequestAuthorisation();
                model.CCRMTonerRequestAuthorisationDTO.ID = id;
                model.CCRMTonerRequestAuthorisationDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMTonerRequestAuthorisation> response = _CCRMTonerRequestAuthorisationBA.SelectByID(model.CCRMTonerRequestAuthorisationDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMTonerRequestAuthorisationDTO.ID = response.Entity.ID;
                    model.CCRMTonerRequestAuthorisationDTO.PartNO = response.Entity.PartNO;
                    model.CCRMTonerRequestAuthorisationDTO.MachineFamilyName = response.Entity.MachineFamilyName;
                    model.CCRMTonerRequestAuthorisationDTO.PartName = response.Entity.PartName;
                    model.CCRMTonerRequestAuthorisationDTO.LastMtrRead = response.Entity.LastMtrRead;
                    model.CCRMTonerRequestAuthorisationDTO.CurrentMeterRead = response.Entity.CurrentMeterRead;
                    model.CCRMTonerRequestAuthorisationDTO.Consumption = response.Entity.Consumption;
                    model.CCRMTonerRequestAuthorisationDTO.StandardCopy = response.Entity.StandardCopy;
                    model.CCRMTonerRequestAuthorisationDTO.BalanceQuantity = response.Entity.BalanceQuantity;
                    model.CCRMTonerRequestAuthorisationDTO.LastQuantity = response.Entity.LastQuantity;
                    model.CCRMTonerRequestAuthorisationDTO.Quantity = response.Entity.Quantity;

                    model.CCRMTonerRequestAuthorisationDTO.CallTktNo = response.Entity.CallTktNo;
                    model.CCRMTonerRequestAuthorisationDTO.CallDate = response.Entity.CallDate;
                    model.CCRMTonerRequestAuthorisationDTO.SerialNo = response.Entity.SerialNo;
                    model.CCRMTonerRequestAuthorisationDTO.ItemDescription = response.Entity.ItemDescription;
                    model.CCRMTonerRequestAuthorisationDTO.MIFName = response.Entity.MIFName;
                    model.CCRMTonerRequestAuthorisationDTO.Remarks = response.Entity.Remarks;

                }
                //******************************************//
                //searchRequest.ConnectionString = _connectioString;
                //searchRequest.CCRMTonerRequestAuthorisationID = id;

                //IBaseEntityCollectionResponse<CCRMTonerRequestAuthorisation> baseEntityCollectionResponse = _CCRMTonerRequestAuthorisationBA.GetListPendingCallByID(searchRequest);

                //if (baseEntityCollectionResponse != null)
                //{
                //    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                //    {
                //        model.PendingCallByCCRMTonerRequestAuthorisationID = baseEntityCollectionResponse.CollectionResponse.ToList();

                //    }
                //}
                //******************************************//
                return PartialView("/Views/CCRM/CCRMTonerRequestAuthorisation/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMTonerRequestAuthorisationViewModel model)
        {
            try
            {

                if (model != null && model.CCRMTonerRequestAuthorisationDTO != null)
                {
                    if (model != null && model.CCRMTonerRequestAuthorisationDTO != null)
                    {
                        model.CCRMTonerRequestAuthorisationDTO.ConnectionString = _connectioString;
                        model.CCRMTonerRequestAuthorisationDTO.CurrentMeterRead = model.CurrentMeterRead;
                        model.CCRMTonerRequestAuthorisationDTO.Authorised = model.Authorised;
                        model.CCRMTonerRequestAuthorisationDTO.ID = model.ID;
                        //model.CCRMTonerRequestAuthorisationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        model.CCRMTonerRequestAuthorisationDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMTonerRequestAuthorisation> response = _CCRMTonerRequestAuthorisationBA.UpdateCCRMTonerRequestAuthorisation(model.CCRMTonerRequestAuthorisationDTO);
                        model.CCRMTonerRequestAuthorisationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.CCRMTonerRequestAuthorisationDTO.errorMessage, JsonRequestBehavior.AllowGet);



            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult Delete(Int32 ID)
        {
            CCRMTonerRequestAuthorisationViewModel model = new CCRMTonerRequestAuthorisationViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMTonerRequestAuthorisation CCRMTonerRequestAuthorisationDTO = new CCRMTonerRequestAuthorisation();
                        CCRMTonerRequestAuthorisationDTO.ConnectionString = _connectioString;
                        CCRMTonerRequestAuthorisationDTO.ID = ID;
                        CCRMTonerRequestAuthorisationDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMTonerRequestAuthorisation> response = _CCRMTonerRequestAuthorisationBA.DeleteCCRMTonerRequestAuthorisation(CCRMTonerRequestAuthorisationDTO);
                        model.CCRMTonerRequestAuthorisationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMTonerRequestAuthorisationDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        // Non-Action Method
        #region Methods
        public IEnumerable<CCRMTonerRequestAuthorisationViewModel> GetCCRMTonerRequestAuthorisation(string FromDate, string UptoDate, out int TotalRecords)
        {
            CCRMTonerRequestAuthorisationSearchRequest searchRequest = new CCRMTonerRequestAuthorisationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.FromDate = FromDate;
            searchRequest.UptoDate = UptoDate;
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
            List<CCRMTonerRequestAuthorisationViewModel> listCCRMTonerRequestAuthorisationViewModel = new List<CCRMTonerRequestAuthorisationViewModel>();
            List<CCRMTonerRequestAuthorisation> listCCRMTonerRequestAuthorisation = new List<CCRMTonerRequestAuthorisation>();
            IBaseEntityCollectionResponse<CCRMTonerRequestAuthorisation> baseEntityCollectionResponse = _CCRMTonerRequestAuthorisationBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMTonerRequestAuthorisation = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMTonerRequestAuthorisation item in listCCRMTonerRequestAuthorisation)
                    {
                        CCRMTonerRequestAuthorisationViewModel CCRMTonerRequestAuthorisationViewModel = new CCRMTonerRequestAuthorisationViewModel();
                        CCRMTonerRequestAuthorisationViewModel.CCRMTonerRequestAuthorisationDTO = item;
                        listCCRMTonerRequestAuthorisationViewModel.Add(CCRMTonerRequestAuthorisationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMTonerRequestAuthorisationViewModel;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string FromDate, string UptoDate)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMTonerRequestAuthorisationViewModel> filteredCCRMTonerRequestAuthorisationViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.CallTktNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.CallTktNo Like '%" + param.sSearch + "%' or A.SerialNo Like '%" + param.sSearch + "%' or A.MIFName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.SerialNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.CallTktNo Like '%" + param.sSearch + "%' or A.SerialNo Like '%" + param.sSearch + "%' or A.MIFName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.MIFName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.CallTktNo Like '%" + param.sSearch + "%' or A.SerialNo Like '%" + param.sSearch + "%' or A.MIFName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMTonerRequestAuthorisationViewModel = GetCCRMTonerRequestAuthorisation(FromDate, UptoDate, out TotalRecords);
            var records = filteredCCRMTonerRequestAuthorisationViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.CallTktNo), Convert.ToString(c.ID), Convert.ToString(c.CallDate), Convert.ToString(c.SerialNo), Convert.ToString(c.ModelNo), Convert.ToString(c.MIFName), Convert.ToString(c.ItemDescription), Convert.ToString(c.Remarks), Convert.ToString(c.Authorised) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}