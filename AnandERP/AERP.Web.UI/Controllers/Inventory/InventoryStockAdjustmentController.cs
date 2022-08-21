using System;
using System.Collections.Generic;
using System.Linq;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System.Configuration;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class InventoryStockAdjustmentController : BaseController
    {
        IInventoryStockAdjustmentBA _InventoryStockAdjustmentBA = null;
        IGeneralItemMasterBA _GeneralItemMasterBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryStockAdjustmentController()
        {
            _InventoryStockAdjustmentBA = new InventoryStockAdjustmentBA();
            _GeneralItemMasterBA = new GeneralItemMasterBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
            _GeneralUnitsBA = new GeneralUnitsBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string CentreCode)
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToInt32(Session["Store Manager:Entity"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                InventoryStockAdjustmentViewModel model = new InventoryStockAdjustmentViewModel();
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
                //li_Action.Add(new SelectListItem { Text = "Manual Consupmtion", Value = "9" });
                ViewData["Action"] = li_Action;

                //********Drop down for location master *********************************//
                List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList();
                List<SelectListItem> listLocationMaster = new List<SelectListItem>();
                foreach (InventoryLocationMaster item in locationMasterList)
                {
                    listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");

                ////********Drop down for Units *********************************//
                //List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
                //List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
                //foreach (GeneralUnits item in GeneralUnits)
                //{
                //    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
                //}  
                //ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }
                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    model.CentreCode = splitCentreCode[0];
                }
                model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);

                //   model.InventoryStockAdjustmentDTO.CentreCode = CentreCode;
                ////********Drop down for Batch Details *********************************//
                //List<InventoryStockAdjustment> InventoryItemBatchdetails = GetInventoryItemBatchMasterList(model.ItemNumber, model.GeneralunitsID);
                //List<SelectListItem> InventoryItemBatchdetailsList = new List<SelectListItem>();
                //foreach (InventoryStockAdjustment item in InventoryItemBatchdetails)
                //{
                //    InventoryItemBatchdetailsList.Add(new SelectListItem { Text = item.BatchNumber, Value = Convert.ToString(item.BatchMasterID) });
                //}
                //ViewBag.InventoryItemBatchdetailsList = new SelectList(InventoryItemBatchdetailsList, "Value", "Text");
                model.CreatedBy = Convert.ToInt32(Session["UserID"]);

                return View("/Views/Inventory/InventoryStockAdjustment/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }
        public ActionResult RestaurantItemIndex(string CentreCode)
        {
            InventoryStockAdjustmentViewModel model = new InventoryStockAdjustmentViewModel();
            List<SelectListItem> Action = new List<SelectListItem>();
            ViewBag.ItemType = new SelectList(Action, "Value", "Text");
            List<SelectListItem> li_Action = new List<SelectListItem>();
            //     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });
            li_Action.Add(new SelectListItem { Text = "Wastage", Value = "6" });
            li_Action.Add(new SelectListItem { Text = "FreeBie", Value = "8" });
            li_Action.Add(new SelectListItem { Text = "Manual Consumption", Value = "9" });
            ViewData["Action"] = li_Action;

            //********Drop down for location master *********************************//
            List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList();
            List<SelectListItem> listLocationMaster = new List<SelectListItem>();
            foreach (InventoryLocationMaster item in locationMasterList)
            {
                listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");

            //********Drop down for Units *********************************//
            //List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
            //List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            //foreach (GeneralUnits item in GeneralUnits)
            //{
            //    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");

            if (Convert.ToString(Session["UserType"]) == "A")
            {
                List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {

                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode + ":Centre";
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);

                }
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
            }
            if (!string.IsNullOrEmpty(CentreCode))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                model.CentreCode = splitCentreCode[0];
            }
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);

            model.CreatedBy = Convert.ToInt32(Session["UserID"]);

            return PartialView("/Views/Inventory/InventoryStockAdjustment/RestaurantItemIndex.cshtml", model);

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                InventoryStockAdjustmentViewModel model = new InventoryStockAdjustmentViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/InventoryStockAdjustment/List.cshtml", model);
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
            InventoryStockAdjustmentViewModel model = new InventoryStockAdjustmentViewModel();

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
            ViewData["Action"] = li_Action;

            //********Drop down for location master *********************************//
            List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList();
            List<SelectListItem> listLocationMaster = new List<SelectListItem>();
            foreach (InventoryLocationMaster item in locationMasterList)
            {
                listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");

            ////********Drop down for Units *********************************//
            //List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster();
            //List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            //foreach (GeneralUnits item in GeneralUnits)
            //{
            //    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");



            return PartialView("/Views/Inventory/InventoryStockAdjustment/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(InventoryStockAdjustmentViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryStockAdjustmentDTO != null)
                {
                    model.InventoryStockAdjustmentDTO.ConnectionString = _connectioString;
                    model.InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentID = model.InventoryPhysicalStockAdjustmentID;
                    model.InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentMasterID = model.InventoryPhysicalStockAdjustmentMasterID;

                    model.InventoryStockAdjustmentDTO.TransDate = model.TransDate;
                    model.InventoryStockAdjustmentDTO.ItemNumber = model.ItemNumber;
                    model.InventoryStockAdjustmentDTO.BarCode = model.BarCode;
                    model.InventoryStockAdjustmentDTO.Rate = model.Rate;
                    model.InventoryStockAdjustmentDTO.Quantity = model.Quantity;
                    model.InventoryStockAdjustmentDTO.Action = model.Action;
                    model.InventoryStockAdjustmentDTO.IssueFromLocationID = model.IssueFromLocationID;
                    model.InventoryStockAdjustmentDTO.UnrestrictedStock = model.UnrestrictedStock;
                    model.InventoryStockAdjustmentDTO.ConvFact = model.ConvFact;
                    model.InventoryStockAdjustmentDTO.UOM = model.UOM;
                    model.InventoryStockAdjustmentDTO.BatchMasterID = model.BatchMasterID;



                    model.InventoryStockAdjustmentDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryStockAdjustment> response = _InventoryStockAdjustmentBA.InsertInventoryStockAdjustment(model.InventoryStockAdjustmentDTO);
                    model.InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentID = response.Entity.InventoryPhysicalStockAdjustmentID;
                    model.InventoryStockAdjustmentDTO.ID = response.Entity.ID;
                    model.InventoryStockAdjustmentDTO.InventoryPhysicalStockAdjustmentMasterID = model.InventoryPhysicalStockAdjustmentMasterID;
                    model.InventoryStockAdjustmentDTO.IsCurrentStock = model.IsCurrentStock;

                    model.InventoryStockAdjustmentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    // return Json(model.InventoryStockAdjustmentDTO.errorMessage, JsonRequestBehavior.AllowGet);
                    return Json(model.InventoryStockAdjustmentDTO, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateBtnAdd(InventoryStockAdjustmentViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {

                if (model != null && model.InventoryStockAdjustmentDTO != null)
                {
                    model.InventoryStockAdjustmentDTO.ConnectionString = _connectioString;

                    model.InventoryStockAdjustmentDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.InventoryStockAdjustmentDTO.TransDate = model.TransDate;
                    model.InventoryStockAdjustmentDTO.XMLstring = model.XMLstring;

                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionSample = model.ParameterVoucherXmlForActionSample;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionDamaged = model.ParameterVoucherXmlForActionDamaged;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForInsp = model.ParameterVoucherXmlForActionBlockedForInsp;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionPIPostive = model.ParameterVoucherXmlForActionPIPostive;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionPINegative = model.ParameterVoucherXmlForActionPINegative;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionWastage = model.ParameterVoucherXmlForActionWastage;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionShrinkage = model.ParameterVoucherXmlForActionShrinkage;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForFreeBie = model.ParameterVoucherXmlForActionBlockedForFreeBie;
                    model.InventoryStockAdjustmentDTO.GeneralUnitsID = model.GeneralUnitsID;

                    IBaseEntityResponse<InventoryStockAdjustment> response = _InventoryStockAdjustmentBA.InsertInventoryStockAdjustmentXML(model.InventoryStockAdjustmentDTO);


                    model.InventoryStockAdjustmentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryStockAdjustmentDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public ActionResult CreateRecipeItemStockAdjustment(InventoryStockAdjustmentViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {

                if (model != null && model.InventoryStockAdjustmentDTO != null)
                {
                    model.InventoryStockAdjustmentDTO.ConnectionString = _connectioString;

                    model.InventoryStockAdjustmentDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.InventoryStockAdjustmentDTO.TransDate = model.TransDate;
                    model.InventoryStockAdjustmentDTO.XMLstring = model.XMLstring;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionWastage = model.ParameterVoucherXmlForActionWastage;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionManualConsumption = model.ParameterVoucherXmlForActionManualConsumption;
                    model.InventoryStockAdjustmentDTO.ParameterVoucherXmlForActionBlockedForFreeBie = model.ParameterVoucherXmlForActionBlockedForFreeBie;
                    model.InventoryStockAdjustmentDTO.GeneralUnitsID = model.GeneralUnitsID;

                    IBaseEntityResponse<InventoryStockAdjustment> response = _InventoryStockAdjustmentBA.InsertInventoryStockAdjustmentXMLForRecipe(model.InventoryStockAdjustmentDTO);


                    model.InventoryStockAdjustmentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryStockAdjustmentDTO.errorMessage, JsonRequestBehavior.AllowGet);

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


        public ActionResult Delete(int InventoryPhysicalStockAdjustmentID)
        {
            var errorMessage = string.Empty;
            if (InventoryPhysicalStockAdjustmentID > 0)
            {
                IBaseEntityResponse<InventoryStockAdjustment> response = null;
                InventoryStockAdjustment InventoryStockAdjustmentDTO = new InventoryStockAdjustment();
                InventoryStockAdjustmentDTO.ConnectionString = _connectioString;
                InventoryStockAdjustmentDTO.ID = Convert.ToInt16(InventoryPhysicalStockAdjustmentID);
                InventoryStockAdjustmentDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryStockAdjustmentBA.DeleteInventoryStockAdjustment(InventoryStockAdjustmentDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);

        }


        #endregion
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList()
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }
        public ActionResult GetGeneralUnitsForItemmasterList(string CentreCode)
        {

            var UOMCodeDesc = GetGeneralUnitsForItemmaster(CentreCode);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UnitName

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = new BaseEntityCollectionResponse<GeneralUnits>();
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchList(searchRequest);
            }
            else if(Convert.ToInt32(Session["Store Manager:Entity"]) > 0)
            {
                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchListByAdminRoleIDAndCentre(searchRequest);
            }
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }

        public ActionResult GetInventoryItemBatchMaster(int ItemNumber, Int16 GeneralUnitsID)
        {

            var UOMCodeDesc = GetInventoryItemBatchMasterList(ItemNumber, GeneralUnitsID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.BatchMasterID,
                              name = s.BatchNumber,
                              ExpiryDate = s.ExpiryDate,
                              BatchQuantity = s.BatchQuantity

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryStockAdjustment> GetInventoryItemBatchMasterList(int ItemNumber, Int16 GeneralUnitsID)
        {
            InventoryStockAdjustmentSearchRequest searchRequest = new InventoryStockAdjustmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = ItemNumber;
            searchRequest.GeneralUnitsID = GeneralUnitsID;
            List<InventoryStockAdjustment> ListInventoryItemBatchMaster = new List<InventoryStockAdjustment>();
            IBaseEntityCollectionResponse<InventoryStockAdjustment> baseEntityCollectionResponse = _InventoryStockAdjustmentBA.GetInventoryItemBatchMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryItemBatchMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryItemBatchMaster;
        }
        public JsonResult GetItemDescriptionDetails(string term, int GeneralUnitsID, string CurrentStockStatus)
        {
            //var CurrentStockStatus1 = Convert.ToBoolean(CurrentStockStatus);
            var data = GetItemDescriptionDetailsdata(term, GeneralUnitsID, CurrentStockStatus);
            var result = (from r in data
                          select new
                          {

                              //id = r.GeneralItemMasterID,

                              ItemDescription = r.ItemName,
                              UOM = r.UOM,
                              ConvFact = r.ConvFact,
                              Barcode = r.BarCode,
                              itemnumber = r.ItemNumber,
                              TotalStock = r.TotalStock,
                              LowerUom = r.LowerUom,
                              Rate = r.Rate,
                              IssueFromLocationID = r.IssueFromLocationID,
                              masterid = r.InventoryPhysicalStockAdjustmentMasterID,
                              stockadjid = r.InventoryPhysicalStockAdjustmentID,
                              SerialAndBatchManagedBy = r.SerialAndBatchManagedBy,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetRecipeItemDescriptionDetails(string term, int GeneralUnitsID)
        {
            var data = GetRecipeItemDescriptionDetailsdata(term, GeneralUnitsID);
            var result = (from r in data
                          select new
                          {

                              //id = r.GeneralItemMasterID,

                              ItemDescription = r.ItemName,
                              InventoryRecipeMasterID = r.InventoryRecipeMasterID,
                              RecipeTitle = r.RecipeTitle,
                              RecipeDescription = r.RecipeDescription,
                              PrimaryItemOutputID = r.PrimaryItemOutputID,
                              InventoryVariationMasterID = r.InventoryVariationMasterID,
                              RecipeVariationTitle = r.RecipeVariationTitle,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<InventoryStockAdjustment> GetItemDescriptionDetailsdata(string SearchKeyWord, int GeneralUnitsID, string CurrentStockStatus)
        {
            InventoryStockAdjustmentSearchRequest searchRequest = new InventoryStockAdjustmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.InvLocationMasterID = GeneralUnitsID;
            searchRequest.CurrentStockStatus = CurrentStockStatus;
            List<InventoryStockAdjustment> listAccount = new List<InventoryStockAdjustment>();
            IBaseEntityCollectionResponse<InventoryStockAdjustment> baseEntityCollectionResponse = _InventoryStockAdjustmentBA.GetItemNameForCurrentStock(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }
        public List<InventoryStockAdjustment> GetRecipeItemDescriptionDetailsdata(string SearchKeyWord, int GeneralUnitsID)
        {
            InventoryStockAdjustmentSearchRequest searchRequest = new InventoryStockAdjustmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = SearchKeyWord;
            searchRequest.InvLocationMasterID = GeneralUnitsID;
            List<InventoryStockAdjustment> listAccount = new List<InventoryStockAdjustment>();
            IBaseEntityCollectionResponse<InventoryStockAdjustment> baseEntityCollectionResponse = _InventoryStockAdjustmentBA.GetInventoryStockAdjustmentSearchListForRecipeItem(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }
        public JsonResult GetInventoryStockAdjustmentIngridentListForRecipeItem(int InventoryRecipeMasterID, int GeneralUnitsID, int InventoryVariationMasterID)
        {
            var data = GetInventoryStockAdjustmentIngridentListForRecipeItemData(InventoryRecipeMasterID, GeneralUnitsID, InventoryVariationMasterID);
            var result = (from r in data
                          select new
                          {

                              //id = r.GeneralItemMasterID,

                              ItemDescription = r.ItemName,
                              RecipeTitle = r.RecipeTitle,
                              IngridentItemnumber = r.IngridentItemnumber,
                              IngridentQty = r.IngridentQty,
                              IngridentUomCode = r.IngridentUomCode,
                              InventoryVariationMasterID = r.InventoryVariationMasterID,
                              CurrentStockQty = r.CurrentStockQty,
                              ConvFact = r.ConvFact,
                              LowerUom = r.LowerUom,
                              ConsumptionPrice = r.ConsumptionPrice,
                              LastPurchasePrice = r.LastPurchasePrice,
                              BaseUomPrice = r.BaseUomPrice,
                              BarCode = r.BarCode,
                              OrderingUOM = r.OrderingUOM,


                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<InventoryStockAdjustment> GetInventoryStockAdjustmentIngridentListForRecipeItemData(int InventoryRecipeMasterID, int GeneralUnitsID, int InventoryVariationMasterID)
        {
            InventoryStockAdjustmentSearchRequest searchRequest = new InventoryStockAdjustmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.InventoryRecipeMasterID = InventoryRecipeMasterID;
            searchRequest.InvLocationMasterID = GeneralUnitsID;
            searchRequest.InventoryVariationMasterID = InventoryVariationMasterID;
            List<InventoryStockAdjustment> listAccount = new List<InventoryStockAdjustment>();
            IBaseEntityCollectionResponse<InventoryStockAdjustment> baseEntityCollectionResponse = _InventoryStockAdjustmentBA.GetInventoryStockAdjustmentIngridentListForRecipeItem(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryStockAdjustmentViewModel> GetInventoryStockAdjustment(out int TotalRecords)
        {
            InventoryStockAdjustmentSearchRequest searchRequest = new InventoryStockAdjustmentSearchRequest();
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
            List<InventoryStockAdjustmentViewModel> listInventoryStockAdjustmentViewModel = new List<InventoryStockAdjustmentViewModel>();
            List<InventoryStockAdjustment> listInventoryStockAdjustment = new List<InventoryStockAdjustment>();
            IBaseEntityCollectionResponse<InventoryStockAdjustment> baseEntityCollectionResponse = _InventoryStockAdjustmentBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInventoryStockAdjustment = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (InventoryStockAdjustment item in listInventoryStockAdjustment)
                    {
                        InventoryStockAdjustmentViewModel InventoryStockAdjustmentViewModel = new InventoryStockAdjustmentViewModel();
                        InventoryStockAdjustmentViewModel.InventoryStockAdjustmentDTO = item;
                        listInventoryStockAdjustmentViewModel.Add(InventoryStockAdjustmentViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInventoryStockAdjustmentViewModel;
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

                IEnumerable<InventoryStockAdjustmentViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    //case 0:
                    //    _sortBy = "A.CounterName";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        // _searchBy = "A.GroupDescription like '%'";
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //        _searchBy = "A.CounterCode Like '%" + param.sSearch + "%' or A.CounterName Like '%" + param.sSearch + "%'";
                    //    }
                    //    break;
                    //case 1:
                    //    _sortBy = "A.CounterCode";
                    //    if (string.IsNullOrEmpty(param.sSearch))
                    //    {
                    //        // _searchBy = "A.MarchandiseGroupCode like '%'";
                    //        _searchBy = string.Empty;
                    //    }
                    //    else
                    //    {
                    //        //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    //        _searchBy = "A.CounterName Like '%" + param.sSearch + "%' or A.CounterCode Like '%" + param.sSearch + "%'";
                    //    }
                    //    break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetInventoryStockAdjustment(out TotalRecords);


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