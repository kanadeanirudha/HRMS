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
    public class GeneralUnitTypeController : BaseController
    {
        IGeneralUnitTypeBA _GeneralUnitTypeBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralUnitTypeController()
        {
            _GeneralUnitTypeBA = new GeneralUnitTypeBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/GeneralMaster/GeneralUnitType/Index.cshtml");
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
                GeneralUnitTypeViewModel model = new GeneralUnitTypeViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralUnitType/List.cshtml", model);
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
            GeneralUnitTypeViewModel model = new GeneralUnitTypeViewModel();
            //List<SelectListItem> li = new List<SelectListItem>();

            // li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
            // li.Add(new SelectListItem { Text = "Sales ", Value = "2" });
            //li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
            //li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
            //li.Add(new SelectListItem { Text = "Processing", Value = "5" });

            List<SelectListItem> RelatedWith = new List<SelectListItem>();
            ViewBag.RelatedWith = new SelectList(RelatedWith, "Value", "Text");
            List<SelectListItem> li_RelatedWith = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_RelatedWith.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
            li_RelatedWith.Add(new SelectListItem { Text = "Sales", Value = "2" });
            li_RelatedWith.Add(new SelectListItem { Text = "Purchase", Value = "3" });
            li_RelatedWith.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
            li_RelatedWith.Add(new SelectListItem { Text = "Processing", Value = "5" });

            ViewData["RelatedWith"] = li_RelatedWith;


            return PartialView("/Views/GeneralMaster/GeneralUnitType/Create.cshtml", model);



        }

        [HttpPost]
        public ActionResult Create(GeneralUnitTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralUnitTypeDTO != null)
                    {
                        model.GeneralUnitTypeDTO.ConnectionString = _connectioString;
                        model.GeneralUnitTypeDTO.UnitType = model.UnitType;
                        // model.GeneralUnitTypeDTO.SeqNo = model.SeqNo; ;
                        model.GeneralUnitTypeDTO.RelatedWith = model.RelatedWith;
                        //model.GeneralUnitTypeDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralUnitTypeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralUnitType> response = _GeneralUnitTypeBA.InsertGeneralUnitType(model.GeneralUnitTypeDTO);

                        model.GeneralUnitTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }

                    return Json(model.GeneralUnitTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralUnitTypeViewModel model = new GeneralUnitTypeViewModel();
            try
            {
                model.GeneralUnitTypeDTO = new GeneralUnitType();
                model.GeneralUnitTypeDTO.ID = id;
                model.GeneralUnitTypeDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralUnitType> response = _GeneralUnitTypeBA.SelectByID(model.GeneralUnitTypeDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralUnitTypeDTO.ID = response.Entity.ID;
                    model.GeneralUnitTypeDTO.UnitType = response.Entity.UnitType;
                    model.GeneralUnitTypeDTO.RelatedWith = response.Entity.RelatedWith;
                    model.GeneralUnitTypeDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/GeneralMaster/GeneralUnitType/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralUnitTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralUnitTypeDTO != null)
                {
                    if (model != null && model.GeneralUnitTypeDTO != null)
                    {
                        model.GeneralUnitTypeDTO.ConnectionString = _connectioString;
                        model.GeneralUnitTypeDTO.UnitType = model.UnitType;
                        // model.GeneralUnitTypeDTO.SeqNo = model.SeqNo;
                        model.GeneralUnitTypeDTO.RelatedWith = model.RelatedWith;
                        //model.GeneralUnitTypeDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralUnitTypeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralUnitType> response = _GeneralUnitTypeBA.UpdateGeneralUnitType(model.GeneralUnitTypeDTO);
                        model.GeneralUnitTypeDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralUnitTypeDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                GeneralUnitTypeViewModel model = new GeneralUnitTypeViewModel();
                model.GeneralUnitTypeDTO = new GeneralUnitType();
                model.GeneralUnitTypeDTO.ID = Convert.ToInt16(ID);
                model.GeneralUnitTypeDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralUnitType> response = _GeneralUnitTypeBA.SelectByID(model.GeneralUnitTypeDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralUnitTypeDTO.UnitType = response.Entity.UnitType;
                    model.GeneralUnitTypeDTO.RelatedWith = response.Entity.RelatedWith;
                }

                List<SelectListItem> RelatedWith = new List<SelectListItem>();
                ViewBag.RelatedWith = new SelectList(RelatedWith, "Value", "Text");
                List<SelectListItem> RelatedWith_li = new List<SelectListItem>();
                RelatedWith_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
                RelatedWith_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
                RelatedWith_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
                RelatedWith_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
                RelatedWith_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
                ViewData["RelatedWith"] = new SelectList(RelatedWith_li, "Value", "Text", model.GeneralUnitTypeDTO.RelatedWith);


                //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
                //    {
                //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
                //    }
                //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralUnitTypeDTO.GenServiceRequiredID);

                return PartialView("/Views/GeneralMaster/GeneralUnitType/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralUnitType> response = null;
                GeneralUnitType GeneralUnitTypeDTO = new GeneralUnitType();
                GeneralUnitTypeDTO.ConnectionString = _connectioString;
                GeneralUnitTypeDTO.ID = ID;
                GeneralUnitTypeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralUnitTypeBA.DeleteGeneralUnitType(GeneralUnitTypeDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralUnitTypeViewModel> GetGeneralUnitType(out int TotalRecords)
        {
            GeneralUnitTypeSearchRequest searchRequest = new GeneralUnitTypeSearchRequest();
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
            List<GeneralUnitTypeViewModel> listGeneralUnitTypeViewModel = new List<GeneralUnitTypeViewModel>();
            List<GeneralUnitType> listGeneralUnitType = new List<GeneralUnitType>();
            IBaseEntityCollectionResponse<GeneralUnitType> baseEntityCollectionResponse = _GeneralUnitTypeBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralUnitType = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralUnitType item in listGeneralUnitType)
                    {
                        GeneralUnitTypeViewModel GeneralUnitTypeViewModel = new GeneralUnitTypeViewModel();
                        GeneralUnitTypeViewModel.GeneralUnitTypeDTO = item;
                        listGeneralUnitTypeViewModel.Add(GeneralUnitTypeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralUnitTypeViewModel;
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

                IEnumerable<GeneralUnitTypeViewModel> filteredUnitType;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "UnitType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.UnitType Like '%" + param.sSearch + "%' or A.RelatedWith Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "RelatedWith";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "UnitType Like '%" + param.sSearch + "%' or RelatedWith Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredUnitType = GetGeneralUnitType(out TotalRecords);
                var records = filteredUnitType.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.UnitType), Convert.ToString(c.RelatedWith), Convert.ToString(c.ID) };

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