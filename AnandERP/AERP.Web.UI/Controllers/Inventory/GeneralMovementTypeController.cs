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
    public class GeneralMovementTypeController : BaseController
    {
        IGeneralMovementTypeBA _GeneralMovementTypeBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralMovementTypeController()
        {
            _GeneralMovementTypeBA = new GeneralMovementTypeBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralMovementType/Index.cshtml");
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
                GeneralMovementTypeViewModel model = new GeneralMovementTypeViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralMovementType/List.cshtml", model);
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
            GeneralMovementTypeViewModel model = new GeneralMovementTypeViewModel();

            return PartialView("/Views/Inventory/GeneralMovementType/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult CreateMovementTypeRules(string IDs)
        {
            GeneralMovementTypeViewModel model = new GeneralMovementTypeViewModel();
            string[] IDsArray = IDs.Split('~');
            model.ID = Convert.ToInt16(IDsArray[0]);
            model.MovementType = IDsArray[3];
            model.MovementCode = IDsArray[2];



            //**********************Transaction type ********************
            List<SelectListItem> TransactionType = new List<SelectListItem>();
            ViewBag.TransactionType = new SelectList(TransactionType, "Value", "Text");
            List<SelectListItem> li_TransactionType = new List<SelectListItem>();
            li_TransactionType.Add(new SelectListItem { Text = "Customer Sale", Value = "1" });
            li_TransactionType.Add(new SelectListItem { Text = "GR", Value = "2" });
            li_TransactionType.Add(new SelectListItem { Text = "Waste And Shrink", Value = "3" });
            li_TransactionType.Add(new SelectListItem { Text = "Production", Value = "4" });
            li_TransactionType.Add(new SelectListItem { Text = "Sales Order Delivery", Value = "5" });
            ViewData["TransactionType"] = li_TransactionType;

            //**********************Direction ********************
            List<SelectListItem> Direction = new List<SelectListItem>();
            ViewBag.Direction = new SelectList(Direction, "Value", "Text");
            List<SelectListItem> li_Direction = new List<SelectListItem>();
            li_Direction.Add(new SelectListItem { Text = "Inward", Value = "1" });
            li_Direction.Add(new SelectListItem { Text = "Outward", Value = "2" });
            //li_Direction.Add(new SelectListItem { Text = "Issue", Value = "3" });
            li_Direction.Add(new SelectListItem { Text = "Intransit", Value = "4" });
            ViewData["Direction"] = li_Direction;

            //**********************Behaviour ********************
            List<SelectListItem> Behaviour = new List<SelectListItem>();
            ViewBag.Behaviour = new SelectList(Behaviour, "Value", "Text");
            List<SelectListItem> li_Behaviour = new List<SelectListItem>();
            li_Behaviour.Add(new SelectListItem { Text = "Internal", Value = "Internal" });
            li_Behaviour.Add(new SelectListItem { Text = "External", Value = "External" });
            ViewData["Behaviour"] = li_Behaviour;

            //*************************Action ********************
            List<SelectListItem> Action = new List<SelectListItem>();
            ViewBag.ItemType = new SelectList(Action, "Value", "Text");
            List<SelectListItem> li_Action = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_Action.Add(new SelectListItem { Text = "Damaged", Value = "1" });
            li_Action.Add(new SelectListItem { Text = "Sample", Value = "2" });
            li_Action.Add(new SelectListItem { Text = "Blocked For Inspection", Value = "3" });
            li_Action.Add(new SelectListItem { Text = "PI-Positive", Value = "4" });
            li_Action.Add(new SelectListItem { Text = "PI-Negative", Value = "5" });
            li_Action.Add(new SelectListItem { Text = "Wastage", Value = "6" });
            li_Action.Add(new SelectListItem { Text = "Shrinkage ", Value = "7" });
            li_Action.Add(new SelectListItem { Text = "FreeBie", Value = "8" });
            li_Action.Add(new SelectListItem { Text = "Manual Consumption", Value = "9" });
            li_Action.Add(new SelectListItem { Text = "Manufacturing", Value = "10" });
            ViewData["Action"] = li_Action;


            return PartialView("/Views/Inventory/GeneralMovementType/CreateMovementTypeRules.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralMovementTypeViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralMovementTypeDTO != null)
                {
                    model.GeneralMovementTypeDTO.ConnectionString = _connectioString;
                    model.GeneralMovementTypeDTO.MovementType = model.MovementType;
                    model.GeneralMovementTypeDTO.MovementCode = model.MovementCode;
                    model.GeneralMovementTypeDTO.IsActive = model.IsActive;
                    model.GeneralMovementTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralMovementType> response = _GeneralMovementTypeBA.InsertGeneralMovementType(model.GeneralMovementTypeDTO);

                    model.GeneralMovementTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralMovementTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateMovementTypeRules(GeneralMovementTypeViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralMovementTypeDTO != null)
                {
                    model.GeneralMovementTypeDTO.ConnectionString = _connectioString;
                    model.GeneralMovementTypeDTO.ID = model.ID;
                    model.GeneralMovementTypeDTO.TransactionType = model.TransactionType;
                    model.GeneralMovementTypeDTO.Direction = model.Direction;
                    model.GeneralMovementTypeDTO.Behaviour = model.Behaviour;
                    model.GeneralMovementTypeDTO.Action = model.Action;
                    model.GeneralMovementTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralMovementType> response = _GeneralMovementTypeBA.InsertGeneralMovementTypeRules(model.GeneralMovementTypeDTO);

                    model.GeneralMovementTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralMovementTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    GeneralMovementTypeViewModel model = new GeneralMovementTypeViewModel();
        //    try
        //    {
        //        model.GeneralMovementTypeDTO = new GeneralMovementType();
        //        model.GeneralMovementTypeDTO.ID = id;
        //        model.GeneralMovementTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralMovementType> response = _GeneralMovementTypeBA.SelectByID(model.GeneralMovementTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralMovementTypeDTO.ID = response.Entity.ID;
        //            model.GeneralMovementTypeDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralMovementTypeDTO.GroupCode = response.Entity.GroupCode;
        //            model.GeneralMovementTypeDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult Edit(GeneralMovementTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralMovementTypeDTO != null)
                {
                    if (model != null && model.GeneralMovementTypeDTO != null)
                    {
                        model.GeneralMovementTypeDTO.ConnectionString = _connectioString;
                        model.GeneralMovementTypeDTO.MovementType = model.MovementType;
                        model.GeneralMovementTypeDTO.MovementCode = model.MovementCode;
                        model.GeneralMovementTypeDTO.IsActive = model.IsActive;

                        model.GeneralMovementTypeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralMovementType> response = _GeneralMovementTypeBA.UpdateGeneralMovementType(model.GeneralMovementTypeDTO);
                        model.GeneralMovementTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralMovementTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralMovementTypeViewModel model = new GeneralMovementTypeViewModel();
        //        model.GeneralMovementTypeDTO = new GeneralMovementType();
        //        model.GeneralMovementTypeDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralMovementTypeDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralMovementType> response = _GeneralMovementTypeBA.SelectByID(model.GeneralMovementTypeDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralMovementTypeDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralMovementTypeDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralMovementTypeDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralMovementTypeDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralMovementType/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralMovementType> response = null;
                GeneralMovementType GeneralMovementTypeDTO = new GeneralMovementType();
                GeneralMovementTypeDTO.ConnectionString = _connectioString;
                GeneralMovementTypeDTO.ID = Convert.ToInt16(ID);
                GeneralMovementTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralMovementTypeBA.DeleteGeneralMovementType(GeneralMovementTypeDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralMovementTypeViewModel> GetGeneralMovementType(out int TotalRecords)
        {
            GeneralMovementTypeSearchRequest searchRequest = new GeneralMovementTypeSearchRequest();
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
            List<GeneralMovementTypeViewModel> listGeneralMovementTypeViewModel = new List<GeneralMovementTypeViewModel>();
            List<GeneralMovementType> listGeneralMovementType = new List<GeneralMovementType>();
            IBaseEntityCollectionResponse<GeneralMovementType> baseEntityCollectionResponse = _GeneralMovementTypeBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralMovementType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralMovementType item in listGeneralMovementType)
                    {
                        GeneralMovementTypeViewModel GeneralMovementTypeViewModel = new GeneralMovementTypeViewModel();
                        GeneralMovementTypeViewModel.GeneralMovementTypeDTO = item;
                        listGeneralMovementTypeViewModel.Add(GeneralMovementTypeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralMovementTypeViewModel;
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

                IEnumerable<GeneralMovementTypeViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.MovementType Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.MovementType Like '%" + param.sSearch + "%' or A.MovementCode Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            //_searchBy = string.Empty;
                            _searchBy = "A.ID Like '%" + param.sSearch + "%'";

                        }
                        else
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.MovementType Like '%" + param.sSearch + "%' or A.MovementCode Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.MovementType Like '%" + param.sSearch + "%' or A.MovementCode Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.ID,B.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or B.ID Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ID Like '%" + param.sSearch + "%' or A.MovementType Like '%" + param.sSearch + "%' or A.MovementCode Like '%" + param.sSearch + "%' or B.Direction Like '%" + param.sSearch + "%' or B.RequisitionBehaviour Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralMovementType(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                //var result = from c in records select new[] { Convert.ToString(c.MovementType), Convert.ToString(c.MovementCode), Convert.ToString(c.IsActive), Convert.ToString(c.ID) };
                var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.MovementCode) + " " + "-" + " " + Convert.ToString(c.MovementType), Convert.ToString(c.TransactionType), Convert.ToString(c.MovementTypeRulesID), Convert.ToString(c.Direction), Convert.ToString(c.Behaviour), Convert.ToString(c.MovementCode), Convert.ToString(c.MovementType) };
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