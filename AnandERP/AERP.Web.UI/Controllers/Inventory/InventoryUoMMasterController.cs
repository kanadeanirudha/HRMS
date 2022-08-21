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
    public class InventoryUoMMasterController : BaseController
    {
        IInventoryUoMMasterBA _InventoryUoMMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryUoMMasterController()
        {
            _InventoryUoMMasterBA = new InventoryUoMMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/InventoryUoMMaster/Index.cshtml");
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
                InventoryUoMMasterViewModel model = new InventoryUoMMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryUoMMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string IDs)
        {
            InventoryUoMMasterViewModel model = new InventoryUoMMasterViewModel();
            //string[] IDsArray = IDs.Split('~');

            //model.InventoryDimentionUnitMasterID = Convert.ToInt16(IDsArray[0]);
            //model.DimensionCode = IDsArray[1];

            return PartialView("/Views/Inventory/InventoryUoMMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryUoMMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryUoMMasterDTO != null)
                {
                    model.InventoryUoMMasterDTO.ConnectionString = _connectioString;
                    //model.InventoryUoMMasterDTO.DimensionCode = model.DimensionCode;
                    //model.InventoryUoMMasterDTO.DimensionDescription = model.DimensionDescription;
                    model.InventoryUoMMasterDTO.UomCode = model.UomCode;
                    model.InventoryUoMMasterDTO.UoMDescription = model.UoMDescription;
                    //model.InventoryUoMMasterDTO.CommercialDescription = model.CommercialDescription;
                    //model.InventoryUoMMasterDTO.DimensionUnitMasterID = model.InventoryDimentionUnitMasterID;
                    //model.InventoryUoMMasterDTO.ConvertionFactor = model.ConvertionFactor;
                    //model.InventoryUoMMasterDTO.AdditiveConstant = model.AdditiveConstant;
                    //model.InventoryUoMMasterDTO.DecimalPlacesUpto = model.DecimalPlacesUpto;
                    //model.InventoryUoMMasterDTO.DecimalRounding = model.DecimalRounding;
                    //model.InventoryUoMMasterDTO.IsAlternativeUom = model.IsAlternativeUom;

                    model.InventoryUoMMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryUoMMaster> response = _InventoryUoMMasterBA.InsertInventoryUoMMaster(model.InventoryUoMMasterDTO);

                    model.InventoryUoMMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryUoMMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    InventoryUoMMasterViewModel model = new InventoryUoMMasterViewModel();
        //    try
        //    {
        //        model.InventoryUoMMasterDTO = new InventoryUoMMaster();
        //        model.InventoryUoMMasterDTO.ID = id;
        //        model.InventoryUoMMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<InventoryUoMMaster> response = _InventoryUoMMasterBA.SelectByID(model.InventoryUoMMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.InventoryUoMMasterDTO.ID = response.Entity.ID;
        //            model.InventoryUoMMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.InventoryUoMMasterDTO.GroupCode = response.Entity.GroupCode;
        //            model.InventoryUoMMasterDTO.CreatedBy = response.Entity.CreatedBy;
        //        }
        //        return PartialView(model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(InventoryUoMMasterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model != null && model.InventoryUoMMasterDTO != null)
        //        {
        //            if (model != null && model.InventoryUoMMasterDTO != null)
        //            {
        //                model.InventoryUoMMasterDTO.ConnectionString = _connectioString;
        //                model.InventoryUoMMasterDTO.GroupDescription = model.GroupDescription;
        //                // model.InventoryUoMMasterDTO.SeqNo = model.SeqNo;
        //                model.InventoryUoMMasterDTO.MarchandiseGroupCode = model.MarchandiseGroupCode;
        //                //model.InventoryUoMMasterDTO.DefaultFlag = model.DefaultFlag;
        //                model.InventoryUoMMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<InventoryUoMMaster> response = _InventoryUoMMasterBA.UpdateInventoryUoMMaster(model.InventoryUoMMasterDTO);
        //                model.InventoryUoMMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //        }
        //        return Json(model.InventoryUoMMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        [HttpGet]
        public ActionResult ViewDetails(string ID)
        {
            try
            {
                InventoryUoMMasterViewModel model = new InventoryUoMMasterViewModel();
                model.InventoryUoMMasterDTO = new InventoryUoMMaster();
                model.InventoryUoMMasterDTO.ID = Convert.ToInt16(ID);
                model.InventoryUoMMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<InventoryUoMMaster> response = _InventoryUoMMasterBA.SelectByID(model.InventoryUoMMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryUoMMasterDTO.UomCode = response.Entity.UomCode;

                    model.InventoryUoMMasterDTO.UoMDescription = response.Entity.UoMDescription;
                    //model.InventoryUoMMasterDTO.CommercialDescription = response.Entity.CommercialDescription;
                    //model.InventoryUoMMasterDTO.DimensionUnitMasterID = response.Entity.DimensionUnitMasterID;s
                    //model.InventoryUoMMasterDTO.ConvertionFactor = response.Entity.ConvertionFactor;
                    //model.InventoryUoMMasterDTO.AdditiveConstant = response.Entity.AdditiveConstant;
                    //model.InventoryUoMMasterDTO.DecimalPlacesUpto = response.Entity.DecimalPlacesUpto;
                    //model.InventoryUoMMasterDTO.DecimalRounding = response.Entity.DecimalRounding;
                    //model.InventoryUoMMasterDTO.IsAlternativeUom = response.Entity.IsAlternativeUom;
                }

                return PartialView("/Views/Inventory/InventoryUoMMaster/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<InventoryUoMMaster> response = null;
                InventoryUoMMaster InventoryUoMMasterDTO = new InventoryUoMMaster();
                InventoryUoMMasterDTO.ConnectionString = _connectioString;
                InventoryUoMMasterDTO.InventoryUoMMasterID = ID;
                InventoryUoMMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryUoMMasterBA.DeleteInventoryUoMMaster(InventoryUoMMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryUoMMasterViewModel> GetInventoryUoMMaster(out int TotalRecords)
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
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
            List<InventoryUoMMasterViewModel> listInventoryUoMMasterViewModel = new List<InventoryUoMMasterViewModel>();
            List<InventoryUoMMaster> listInventoryUoMMaster = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryUoMMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryUoMMaster item in listInventoryUoMMaster)
                    {
                        InventoryUoMMasterViewModel InventoryUoMMasterViewModel = new InventoryUoMMasterViewModel();
                        InventoryUoMMasterViewModel.InventoryUoMMasterDTO = item;
                        listInventoryUoMMasterViewModel.Add(InventoryUoMMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryUoMMasterViewModel;
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

                IEnumerable<InventoryUoMMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    //case 0:
                    //    _sortBy = "A.ID";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {

                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //               //this "if" block is added for search functionality
                    //        _searchBy = "A.ID Like '%" + param.sSearch + "%' or B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%' or B.ConvertionFactor Like '%" + param.sSearch + "%'";
                    //    }
                    //    break;
                    case 0:
                        _sortBy = "B.UomCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = "B.UomCode like '%'";
                            // _searchBy = string.Empty;
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%' or B.ConvertionFactor Like '%" + param.sSearch + "%'";
                            _searchBy = "B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "B.UoMDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = string.Empty;
                            _searchBy = "B.UoMDescription like '%'";
                        }
                        else
                        {
                            //this "if" block is added for search functionality
                            //_searchBy = "A.ID Like '%" + param.sSearch + "%' or B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%' or B.ConvertionFactor Like '%" + param.sSearch + "%'";
                            _searchBy = "B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%'";


                        }
                        break;
                        //case 3:
                        //    _sortBy = "B.ConvertionFactor";
                        //    if (string.IsNullOrEmpty(param.sSearch))
                        //    {
                        //        //_searchBy = string.Empty;
                        //        _searchBy = "B.ConvertionFactor like '%'";
                        //    }
                        //    else
                        //    {
                        //              //this "if" block is added for search functionality
                        //        _searchBy = "A.ID Like '%" + param.sSearch + "%' or B.UomCode Like '%" + param.sSearch + "%' or B.UoMDescription Like '%" + param.sSearch + "%' or B.ConvertionFactor Like '%" + param.sSearch + "%'";
                        //    }
                        //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryUoMMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                //var result = from c in records select new[] { Convert.ToString(c.InventoryDimentionUnitMasterID), Convert.ToString(c.DimensionCode), Convert.ToString(c.UomCode), Convert.ToString(c.UoMDescription), Convert.ToString(c.DimensionDescription), Convert.ToString(c.CommercialDescription), Convert.ToString(c.InventoryUoMMasterID), Convert.ToString(c.ConvertionFactor), Convert.ToString(c.AdditiveConstant), Convert.ToString(c.DecimalPlacesUpto), Convert.ToString(c.DecimalRounding), Convert.ToString(c.IsAlternativeUom) };
                var result = from c in records select new[] { Convert.ToString(c.InventoryUoMMasterID), Convert.ToString(c.UomCode), Convert.ToString(c.UoMDescription) };

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