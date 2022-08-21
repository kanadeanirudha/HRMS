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
    public class SalePromotionActivityMasterAndDetailsController : BaseController
    {
        ISalePromotionActivityMasterAndDetailsServiceAccess _SalePromotionActivityMasterAndDetailsServiceAcess = null;
        ISalePromotionPlanAndDetailsServiceAccess _SalePromotionPlanAndDetailsServiceAcess = null;
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;
        IGeneralUnitsServiceAccess _GeneralUnitsServiceAccess = null;
        IInventoryUoMMasterServiceAccess _InventoryUoMMasterServiceAccess = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalePromotionActivityMasterAndDetailsController()
        {
            _SalePromotionActivityMasterAndDetailsServiceAcess = new SalePromotionActivityMasterAndDetailsServiceAccess();
            _SalePromotionPlanAndDetailsServiceAcess = new SalePromotionPlanAndDetailsServiceAccess();
            _GeneralUnitsServiceAccess = new GeneralUnitsServiceAccess();
            _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
            _InventoryUoMMasterServiceAccess = new InventoryUoMMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/Index.cshtml");


        }

        public ActionResult List(string GeneralUnitsID,string CentreCode, string actionMode)
        {
            try
            {
                SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
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

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
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

                model.SalePromotionActivityMasterAndDetailsDTO.CentreCode = CentreCode;

                //****************************************************************************************************************//
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
                return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(int GeneralUnitsID)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            //****************************************************************************************************************//
            List<SalePromotionPlanAndDetails> SalePromotionPlanAndDetails = GetPlanTypeCode();
            List<SelectListItem> SalePromotionPlanAndDetailsList = new List<SelectListItem>();
            foreach (SalePromotionPlanAndDetails item in SalePromotionPlanAndDetails)
            {
                SalePromotionPlanAndDetailsList.Add(new SelectListItem { Text = item.PlanTypeName + " (" + item.PlanTypeCode + ") ", Value = Convert.ToString(item.PlanTypeCode) });
            }
            ViewBag.SalePromotionPlanAndDetailsList = new SelectList(SalePromotionPlanAndDetailsList, "Value", "Text");
            
            //********************Plan Concession Free********************//
            List<SelectListItem> PlanCode = new List<SelectListItem>();
            ViewBag.PlanCode = new SelectList(PlanCode, "Value", "Text");
            List<SelectListItem> PlanCode_li = new List<SelectListItem>();

            PlanCode_li.Add(new SelectListItem { Text = "---Select Concession Free Type---", Value = "0" });
            PlanCode_li.Add(new SelectListItem { Text = "For Same Item", Value = "1" });
            PlanCode_li.Add(new SelectListItem { Text = "Any of selected Items", Value = "2" });
            //PlanCode_li.Add(new SelectListItem { Text = "Specific Item", Value = "3" });
            ViewData["ProductConcessionFreeType"] = PlanCode_li;
            //********************Promotion for********************//
            List<SelectListItem> PromotionFor = new List<SelectListItem>();
            ViewBag.PromotionFor = new SelectList(PromotionFor, "Value", "Text");
            List<SelectListItem> PromotionFor_li = new List<SelectListItem>();

            //PromotionFor_li.Add(new SelectListItem { Text = "---Select Promotion ---", Value = "0" });
            PromotionFor_li.Add(new SelectListItem { Text = "ALL", Value = "0" });
            PromotionFor_li.Add(new SelectListItem { Text = "Retail", Value = "1" });
            PromotionFor_li.Add(new SelectListItem { Text = "Cafe", Value = "2" });
          
            ViewData["PromotionFor"] = PromotionFor_li;
            //********************Plan Description********************//
            List<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsForPlanDescription = GetPlanDescriptionByCode();
            List<SelectListItem> SalePromotionPlanAndDetailsForPlanDescriptionList = new List<SelectListItem>();
            foreach (SalePromotionPlanAndDetails item in SalePromotionPlanAndDetailsForPlanDescription)
            {
                SalePromotionPlanAndDetailsForPlanDescriptionList.Add(new SelectListItem { Text = item.PlanDescription, Value = Convert.ToString(item.SalePromotionPlanDetailsID) });
            }
            ViewBag.SalepromotionPlanDescriptionList = new SelectList(SalePromotionPlanAndDetailsForPlanDescriptionList, "Value", "Text");
            //********************Plan Description********************//

            //**************************************************************************************************************//

            model.GeneralUnitsID = GeneralUnitsID;
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult CreateSalePromotionActivity(string IDs)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            string[] IDsArray = IDs.Split('~');
           
            //model.PlanTypeName = Convert.ToString(IDsArray[1]);

               model.SalePromotionActivityMasterID = Convert.ToInt32(IDsArray[0]);
                model.GetPlanList = GetSalePlanList(model.SalePromotionActivityMasterID);
                model.PlanTypeName = model.GetPlanList[0].PlanTypeName;
                model.ExternalFlag = model.GetPlanList[0].ExternalFlag;
                model.IsCoupanOrGiftVoucherApplicable = model.GetPlanList[0].IsCoupanOrGiftVoucherApplicable;
                model.IsCommon = model.GetPlanList[0].IsCommon;
            
            //********************External Flag********************//
            if (model.ExternalFlag > 0)
            {
                List<SelectListItem> ExternalFlag = new List<SelectListItem>();
                ViewBag.ExternalFlag = new SelectList(ExternalFlag, "Value", "Text");
                List<SelectListItem> ExternalFlag_li = new List<SelectListItem>();

                ExternalFlag_li.Add(new SelectListItem { Text = "Internal", Value = "1" });
                ExternalFlag_li.Add(new SelectListItem { Text = "External", Value = "2" });
                ViewData["ExternalFlag"] = new SelectList(ExternalFlag_li, "Value", "Text", (model.SalePromotionActivityMasterAndDetailsDTO.ExternalFlag).ToString().Trim());
               
            }
            else
            {
                List<SelectListItem> ExternalFlag = new List<SelectListItem>();
                ViewBag.ExternalFlag = new SelectList(ExternalFlag, "Value", "Text");
                List<SelectListItem> ExternalFlag_li = new List<SelectListItem>();

                ExternalFlag_li.Add(new SelectListItem { Text = "Internal", Value = "1" });
                ExternalFlag_li.Add(new SelectListItem { Text = "External", Value = "2" });
                ViewData["ExternalFlag"] = ExternalFlag_li;
            }
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/CreateSalePromotionActivity.cshtml", model);
        }

        [HttpGet]
        public ActionResult CreateItemDetails(int ID, int DetailID, int GeneralUnitsID,string PlanTypeCode)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            model.SalePromotionActivityMasterID = ID;
            model.SalePromotionActivityDetailsID = DetailID;
            model.GeneralUnitsID = GeneralUnitsID;
            model.PlanTypeCode = PlanTypeCode;
            model.GetItemList = GetLIstForItemDetails(ID);
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/CreateItemDetails.cshtml", model);
        }
        [HttpGet]
        public ActionResult CreateGiftVoucherDetails(int ID, int DetailID, int GeneralUnitsID, string PlanTypeCode)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            model.SalePromotionActivityMasterID = ID;
            model.SalePromotionActivityDetailsID = DetailID;
            model.GeneralUnitsID = GeneralUnitsID;
            //********************Bill Amount Range********************//
            List<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsForBillRange= GetBillAmountRangeByPlanCode();
            List<SelectListItem> SalePromotionPlanAndDetailsForBillRangeList = new List<SelectListItem>();
            foreach (SalePromotionPlanAndDetails item in SalePromotionPlanAndDetailsForBillRange)
            {
                SalePromotionPlanAndDetailsForBillRangeList.Add(new SelectListItem { Text = item.BillRangeList, Value = Convert.ToString(item.SalePromotionPlanDetailsID) });
            }
            ViewBag.SalePromotionPlanAndDetailsForBillRangeList = new SelectList(SalePromotionPlanAndDetailsForBillRangeList, "Value", "Text");
            //********************Bill Amount Range********************//


            model.PlanTypeCode = PlanTypeCode;
         
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/CreateGiftVoucher.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateGiftVoucherDetails(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForGiftVouchar = model.ParameterXmlForGiftVouchar;
                    model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityDetailsID = model.SalePromotionActivityDetailsID;
                    model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = model.PlanTypeCode;
                   

                    model.SalePromotionActivityMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.InsertSalePromotionGiftVocherDetails(model.SalePromotionActivityMasterAndDetailsDTO);

                    model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public ActionResult CreateSalePromotionActivityForFreeConcession(string IDs)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            string[] IDsArray = IDs.Split('~');
            model.SalePromotionActivityMasterID = Convert.ToInt32(IDsArray[0]);
            model.GeneralUnitsID = Convert.ToInt32(IDsArray[1]);

            //********************Plan Concession Free********************//
            List<SelectListItem> PlanCode = new List<SelectListItem>();
            ViewBag.PlanCode = new SelectList(PlanCode, "Value", "Text");
            List<SelectListItem> PlanCode_li = new List<SelectListItem>();

            PlanCode_li.Add(new SelectListItem { Text = "For Same Item", Value = "1" });
            PlanCode_li.Add(new SelectListItem { Text = "Any of selected Items", Value = "2" });
            //PlanCode_li.Add(new SelectListItem { Text = "Specific Item", Value = "3" });
            ViewData["ProductConcessionFreeType"] = PlanCode_li;
            //********************Plan Concession Free********************//

            //********************Plan Description********************//
            List<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsForPlanDescription = GetPlanDescriptionByCode();
            List<SelectListItem> SalePromotionPlanAndDetailsForPlanDescriptionList = new List<SelectListItem>();
            foreach (SalePromotionPlanAndDetails item in SalePromotionPlanAndDetailsForPlanDescription)
            {
                SalePromotionPlanAndDetailsForPlanDescriptionList.Add(new SelectListItem { Text = item.PlanDescription, Value = Convert.ToString(item.SalePromotionPlanDetailsID) });
            }
            ViewBag.SalepromotionPlanDescriptionList = new SelectList(SalePromotionPlanAndDetailsForPlanDescriptionList, "Value", "Text");
            //********************Plan Description********************//
                                          
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/CreateConcessionFreeActivity.cshtml", model);
        }
        [HttpPost]
        public ActionResult CreateItemDetails(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForItemDetails = model.ParameterXmlForItemDetails;
                    model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityDetailsID = model.SalePromotionActivityDetailsID;
                    model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = model.PlanTypeCode;
                    model.SalePromotionActivityMasterAndDetailsDTO.ProductConcessionFreeType = model.ProductConcessionFreeType;

                    model.SalePromotionActivityMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.InsertItemDetails(model.SalePromotionActivityMasterAndDetailsDTO);

                    model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult CreateFreeTypeItemList(int GeneralUnitsID, int DetailID, string PlanTypeCode, byte ProductConcessionFreeType)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
           // model.SalePromotionActivityMasterID = ID;
            model.SalePromotionActivityDetailsID = DetailID;
            model.GeneralUnitsID = GeneralUnitsID;
            model.PlanTypeCode = PlanTypeCode;
            model.ProductConcessionFreeType = ProductConcessionFreeType;
            model.GetConsessionItemList = GetConsessionFreeItemList(model.GeneralUnitsID,model.SalePromotionActivityDetailsID);
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/CreateFreeTypeItemList.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateFreeTypeItemList(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = model.PlanTypeCode;
                    model.SalePromotionActivityMasterAndDetailsDTO.ProductConcessionFreeType = model.ProductConcessionFreeType;
                    model.SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForItemDetails = model.ParameterXmlForItemDetails;
                    model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityDetailsID = model.SalePromotionActivityDetailsID;
                    model.SalePromotionActivityMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.InsertItemDetails(model.SalePromotionActivityMasterAndDetailsDTO);

                    model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionActivityMasterAndDetailsDTO.Name = model.Name;
                    model.SalePromotionActivityMasterAndDetailsDTO.FromDate = model.FromDate;
                    model.SalePromotionActivityMasterAndDetailsDTO.UptoDate = model.UptoDate;
                    model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = model.PlanTypeCode;
                    model.SalePromotionActivityMasterAndDetailsDTO.PlanDescription = model.PlanDescription;
                    model.SalePromotionActivityMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalePromotionActivityMasterAndDetailsDTO.XMLstring = model.XMLstring;
                    model.SalePromotionActivityMasterAndDetailsDTO.PromotionFor = model.PromotionFor;
                    model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionPlanDetailsID = model.SalePromotionPlanDetailsID;

                    model.SalePromotionActivityMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.InsertSalePromotionActivityMasterAndDetails(model.SalePromotionActivityMasterAndDetailsDTO);

                    model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateSalePromotionActivity(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalePromotionActivityMasterAndDetailsDTO.ExternalFlag = model.ExternalFlag;
                    model.SalePromotionActivityMasterAndDetailsDTO.IsCoupanOrGiftVoucherApplicable = model.IsCoupanOrGiftVoucherApplicable;
                    model.SalePromotionActivityMasterAndDetailsDTO.IsCommon = model.IsCommon;
                    model.SalePromotionActivityMasterAndDetailsDTO.ParameterXmlForFixedData = model.ParameterXmlForFixedData;
                    model.SalePromotionActivityMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.InsertSalePromotionActivityMasterAndDetailsRules(model.SalePromotionActivityMasterAndDetailsDTO);

                    model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                    {
                        model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                        //model.SalePromotionActivityMasterAndDetailsDTO.MovementType = model.MovementType;
                        //model.SalePromotionActivityMasterAndDetailsDTO.MovementCode = model.MovementCode;
                        //model.SalePromotionActivityMasterAndDetailsDTO.IsActive = model.IsActive;
                      
                        model.SalePromotionActivityMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.UpdateSalePromotionActivityMasterAndDetails(model.SalePromotionActivityMasterAndDetailsDTO);
                        model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = null;
                SalePromotionActivityMasterAndDetails SalePromotionActivityMasterAndDetailsDTO = new SalePromotionActivityMasterAndDetails();
                SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                SalePromotionActivityMasterAndDetailsDTO.ID = Convert.ToInt16(ID);
                SalePromotionActivityMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalePromotionActivityMasterAndDetailsServiceAcess.DeleteSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteDiscountItemList(int PromotionActivityDiscounteItemListID)
        {
            var errorMessage = string.Empty;
            if (PromotionActivityDiscounteItemListID > 0)
            {
                IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = null;
                SalePromotionActivityMasterAndDetails SalePromotionActivityMasterAndDetailsDTO = new SalePromotionActivityMasterAndDetails();
                SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                SalePromotionActivityMasterAndDetailsDTO.ID = Convert.ToInt16(PromotionActivityDiscounteItemListID);
                SalePromotionActivityMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _SalePromotionActivityMasterAndDetailsServiceAcess.DeletePromotionActivityDiscounteItemList(SalePromotionActivityMasterAndDetailsDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewFixAmount(int ID, int DetailsID)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            try
            {
                model.SalePromotionActivityMasterAndDetailsDTO = new SalePromotionActivityMasterAndDetails();
                model.SalePromotionActivityMasterAndDetailsDTO.ID = ID;
                model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityDetailsID = DetailsID;
                model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;

                model.GetFixAmountList = GetFixAmountDetails(ID, DetailsID);

                return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/ViewFixAmount.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewItemDetails(int ID,string PlanTypeCode)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            try
            {
                model.SalePromotionActivityMasterAndDetailsDTO = new SalePromotionActivityMasterAndDetails();
                model.SalePromotionActivityMasterAndDetailsDTO.ID = ID;
                model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = PlanTypeCode;
                model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;

                model.GetItemList = GetLIstForItemDetails(ID);

                return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/ViewItemDetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult ViewGiftVoucherDetails(int ID, string PlanTypeCode)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();
            try
            {
                model.SalePromotionActivityMasterAndDetailsDTO = new SalePromotionActivityMasterAndDetails();
                model.SalePromotionActivityMasterAndDetailsDTO.ID = ID;
                model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = PlanTypeCode;
                model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;

                model.GetGiftVocherList = GetListForGiftVoucherdetils(ID);

                return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/ViewGiftVoucherDetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateDeActivateActivity(string IDs)
        {
            SalePromotionActivityMasterAndDetailsViewModel model = new SalePromotionActivityMasterAndDetailsViewModel();

            string[] IDsArray = IDs.Split('~');
            model.GeneralUnitsID = Convert.ToInt16(IDsArray[1]);
            model.SalePromotionActivityMasterID = Convert.ToInt16(IDsArray[0]);
           
            model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.SelectByID(model.SalePromotionActivityMasterAndDetailsDTO);
            if (response != null && response.Entity != null)
            {
                model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityMasterID = response.Entity.SalePromotionActivityMasterID;
                model.SalePromotionActivityMasterAndDetailsDTO.FromDate = response.Entity.FromDate;
                model.SalePromotionActivityMasterAndDetailsDTO.UptoDate = response.Entity.UptoDate;
                model.SalePromotionActivityMasterAndDetailsDTO.Name = response.Entity.Name;
                model.SalePromotionActivityMasterAndDetailsDTO.PlanTypeCode = response.Entity.PlanTypeCode;
                model.SalePromotionActivityMasterAndDetailsDTO.IsActivted = response.Entity.IsActivted;
                model.SalePromotionActivityMasterAndDetailsDTO.PromotionFor = response.Entity.PromotionFor;
               
            }
            List<SelectListItem> PromotionFor = new List<SelectListItem>();
            ViewBag.PromotionFor = new SelectList(PromotionFor, "Value", "Text");
            List<SelectListItem> PromotionFor_li = new List<SelectListItem>();

         
            PromotionFor_li.Add(new SelectListItem { Text = "ALL", Value = "0" });
            PromotionFor_li.Add(new SelectListItem { Text = "Retail", Value = "1" });
            PromotionFor_li.Add(new SelectListItem { Text = "Cafe", Value = "2" });
            ViewData["PromotionFor"] = new SelectList(PromotionFor_li, "Value", "Text", (model.SalePromotionActivityMasterAndDetailsDTO.PromotionFor).ToString().Trim());
            return PartialView("/Views/Inventory_1/SalesPromotion/SalePromotionActivityMasterAndDetails/CreateDeActivateActivity.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateDeActivateActivity(SalePromotionActivityMasterAndDetailsViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                {
                    if (model != null && model.SalePromotionActivityMasterAndDetailsDTO != null)
                    {
                        model.SalePromotionActivityMasterAndDetailsDTO.ConnectionString = _connectioString;
                        model.SalePromotionActivityMasterAndDetailsDTO.UptoDate = model.UptoDate;
                        model.SalePromotionActivityMasterAndDetailsDTO.SalePromotionActivityMasterID = model.SalePromotionActivityMasterID;
                        model.SalePromotionActivityMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                        model.SalePromotionActivityMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<SalePromotionActivityMasterAndDetails> response = _SalePromotionActivityMasterAndDetailsServiceAcess.UpdateSalePromotionActivityMasterAndDetails(model.SalePromotionActivityMasterAndDetailsDTO);
                        //model.SalePromotionActivityMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
               // }
                //return Json(model.SalePromotionActivityMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        protected List<SalePromotionActivityMasterAndDetails> GetSalePlanList(int ID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalePromotionActivityMasterID = ID;
            List<SalePromotionActivityMasterAndDetails> ListSalePromotionActivityMasterAndDetails = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetPlanForFixedAmount(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListSalePromotionActivityMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListSalePromotionActivityMasterAndDetails;
        }
        protected List<SalePromotionActivityMasterAndDetails> GetLIstForItemDetails(int ID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            List<SalePromotionActivityMasterAndDetails> ListSalePromotionActivityMasterAndDetails = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetItemList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListSalePromotionActivityMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListSalePromotionActivityMasterAndDetails;
        }
        //View Gift Voucher Details
        protected List<SalePromotionActivityMasterAndDetails> GetListForGiftVoucherdetils(int SalePromotionActivityDetailsID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SalePromotionActivityDetailsID = SalePromotionActivityDetailsID;
            List<SalePromotionActivityMasterAndDetails> ListSalePromotionActivityMasterAndDetails = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetSalePromotionGiftVocherDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListSalePromotionActivityMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListSalePromotionActivityMasterAndDetails;
        }

        protected List<SalePromotionActivityMasterAndDetails> GetConsessionFreeItemList(int GeneralUnitsID,int SalePromotionActivityDetailsID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralUnitsID = GeneralUnitsID;
            searchRequest.SalePromotionActivityDetailsID = SalePromotionActivityDetailsID;
            List<SalePromotionActivityMasterAndDetails> ListSalePromotionActivityMasterAndDetails = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetSelectedItemOfConcessionType(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListSalePromotionActivityMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListSalePromotionActivityMasterAndDetails;
        }

        protected List<SalePromotionActivityMasterAndDetails> GetFixAmountDetails(int ID,int DetailsID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            searchRequest.SalePromotionActivityDetailsID = DetailsID;
            List<SalePromotionActivityMasterAndDetails> ListSalePromotionActivityMasterAndDetails = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetFixAmountDetails(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListSalePromotionActivityMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListSalePromotionActivityMasterAndDetails;
        }

        public ActionResult GetUoMCodeByItemNumber(string ItemNumber)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberList(ItemNumber);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UomCode,
                              //name = string.IsNullOrEmpty(s.UomCode) ? "EA" : s.UomCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryUoMMaster> GetUoMCodeByItemNumberList(string ItemNumber)
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            List<InventoryUoMMaster> listOrganisationDepartmentMaster = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterServiceAccess.GetInventoryUoMMasterDropDownforSaleUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        public ActionResult GetSelectedItemFreeConcessionTypeList(string GeneralUnitsID)
        {

            var UOMCodeDesc = GetItemFreeConcessionTypeList(GeneralUnitsID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.MenuDescription,
                              BaseUOMCode = s.UOMCode,
                              GeneralItemMasterID = s.GeneralItemMasterID,
                              InventoryVariationMasterID = s.InventoryVariationMasterID,
                              ItemDescription = s.ItemDescription,
                              ItemNumber = s.ItemNumber,
                              SaleUOMCode = s.SaleUOMCode
                              //name = string.IsNullOrEmpty(s.UomCode) ? "EA" : s.UomCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<SalePromotionActivityMasterAndDetails> GetItemFreeConcessionTypeList(string GeneralUnitsID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralUnitsID = Convert.ToInt32(GeneralUnitsID);
            List<SalePromotionActivityMasterAndDetails> listOrganisationDepartmentMaster = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetSelectedItemFreeConcessionTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        //Dropdown for GetPlandecriptionForPlanCode
        protected List<SalePromotionPlanAndDetails> GetPlanDescriptionByCode()
        {
            SalePromotionPlanAndDetailsSearchRequest searchRequest = new SalePromotionPlanAndDetailsSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalePromotionPlanAndDetails> ListGetPlanDescriptionByPlanCode = new List<SalePromotionPlanAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> baseEntityCollectionResponse = _SalePromotionPlanAndDetailsServiceAcess.GetPlanDescriptionByPlanCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGetPlanDescriptionByPlanCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGetPlanDescriptionByPlanCode;
        }
        //Dropdown for BillAmountRange
        protected List<SalePromotionPlanAndDetails> GetBillAmountRangeByPlanCode()
        {
            SalePromotionPlanAndDetailsSearchRequest searchRequest = new SalePromotionPlanAndDetailsSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalePromotionPlanAndDetails> ListGetPlanDescriptionByPlanCode = new List<SalePromotionPlanAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> baseEntityCollectionResponse = _SalePromotionPlanAndDetailsServiceAcess.GetBillAmountrangeForGiftVoucher(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGetPlanDescriptionByPlanCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGetPlanDescriptionByPlanCode;
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<SalePromotionActivityMasterAndDetailsViewModel> GetSalePromotionActivityMasterAndDetails(string GeneralUnitsID,string CentreCode, out int TotalRecords)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
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
                    searchRequest.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
                searchRequest.CentreCode = CentreCode;
            }
            List<SalePromotionActivityMasterAndDetailsViewModel> listSalePromotionActivityMasterAndDetailsViewModel = new List<SalePromotionActivityMasterAndDetailsViewModel>();
            List<SalePromotionActivityMasterAndDetails> listSalePromotionActivityMasterAndDetails = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalePromotionActivityMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalePromotionActivityMasterAndDetails item in listSalePromotionActivityMasterAndDetails)
                    {
                        SalePromotionActivityMasterAndDetailsViewModel SalePromotionActivityMasterAndDetailsViewModel = new SalePromotionActivityMasterAndDetailsViewModel();
                        SalePromotionActivityMasterAndDetailsViewModel.SalePromotionActivityMasterAndDetailsDTO = item;
                        listSalePromotionActivityMasterAndDetailsViewModel.Add(SalePromotionActivityMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalePromotionActivityMasterAndDetailsViewModel;
        }

        //Dropdown for GetPlanTypeCode
        protected List<SalePromotionPlanAndDetails> GetPlanTypeCode()
        {
            SalePromotionPlanAndDetailsSearchRequest searchRequest = new SalePromotionPlanAndDetailsSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<SalePromotionPlanAndDetails> ListInventoryUoMMasterForSaleUomCode = new List<SalePromotionPlanAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> baseEntityCollectionResponse = _SalePromotionPlanAndDetailsServiceAcess.GetSalePromotionPlanAndDetailsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForSaleUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForSaleUomCode;
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

        //Dropdown for General Units
        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsServiceAccess.GetGeneralUnitsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        [HttpPost]
        public JsonResult GetItemSearchListForVarientsMenu(string term, int GeneralUnitsID)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.GeneralUnitsID = GeneralUnitsID;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterServiceAcess.GetItemSearchListForVarientsMenu(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              id = r.GeneralItemMasterID,
                              name = r.MenuDescription,
                              ItemNumber = r.ItemNumber,
                              BaseUOMCode = r.BaseUOMCode,
                              InventoryVariationMasterID = r.InventoryVariationMasterID,
                              MenuDescription = r.MenuDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetItemSearchListForConcessionFreeItems(string term, int GeneralUnitsID)
        {
            SalePromotionActivityMasterAndDetailsSearchRequest searchRequest = new SalePromotionActivityMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.GeneralUnitsID = GeneralUnitsID;
            List<SalePromotionActivityMasterAndDetails> listFeeSubType = new List<SalePromotionActivityMasterAndDetails>();
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> baseEntityCollectionResponse = _SalePromotionActivityMasterAndDetailsServiceAcess.GetConcessionfreeItemsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              GeneralItemMasterID = r.GeneralItemMasterID,
                              name = r.MenuDescription,
                              ItemNumber = r.ItemNumber,
                              BaseUOMCode = r.UOMCode,
                              InventoryVariationMasterID = r.InventoryVariationMasterID,
                              MenuDescription = r.MenuDescription,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion  

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string GeneralUnitsID,string CentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalePromotionActivityMasterAndDetailsViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.PlanTypeCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PlanTypeCode Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%'or A.FromDate Like '%" + param.sSearch + "%'or A.UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.ActivityName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%'";
                           
                            
                        }
                        else
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%'or A.FromDate Like '%" + param.sSearch + "%'or A.UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.FromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.FromDate Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%'or A.FromDate Like '%" + param.sSearch + "%'or A.UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.UptoDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.FromDate Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%'or A.FromDate Like '%" + param.sSearch + "%'or A.UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 4:
                        _sortBy = "A.PlanTypeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PlanTypeName Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%'or A.FromDate Like '%" + param.sSearch + "%'or A.UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 5:
                        _sortBy = "A.PlanTypeName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PlanTypeName Like '%" + param.sSearch + "%'";
                        }
                        else
                        {
                            _searchBy = "A.ActivityName Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%' or A.PlanTypeCode Like '%" + param.sSearch + "%'or A.FromDate Like '%" + param.sSearch + "%'or A.UptoDate Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(CentreCode))
                {
                    string[] splitCentreCode = CentreCode.Split(':');
                    CentreCode = splitCentreCode[0];
                }
                filteredGroupDescription = GetSalePromotionActivityMasterAndDetails( GeneralUnitsID, CentreCode, out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                //var result = from c in records select new[] { Convert.ToString(c.SalePromotionPlanID), Convert.ToString(c.PlanTypeCode), Convert.ToString(c.Name), Convert.ToString(c.PlanTypeName), Convert.ToString(c.FromDate), Convert.ToString(c.UptoDate), Convert.ToString(c.SalePromotionActivityMasterID), Convert.ToString(c.SalePromotionPlanDetailsID), Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.SalePromotionActivityDetailsID) };
                var result = from c in records select new[] { Convert.ToString(c.PlanTypeCode), Convert.ToString(c.Name), Convert.ToString(c.FromDate), Convert.ToString(c.UptoDate), Convert.ToString(c.SalePromotionActivityMasterID), Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.SalePromotionActivityDetailsID), Convert.ToString(c.SubActivityName), Convert.ToString(c.IsActivted), Convert.ToString(c.PlanTypeName), Convert.ToString(c.ProductConcessionFreeType) };
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