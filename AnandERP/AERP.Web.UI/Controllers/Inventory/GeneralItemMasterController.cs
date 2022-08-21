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
using System.IO;
using System.Web;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using System.Net;
using System.Data;
using System.Web.Hosting;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;
using System.Web.Helpers;

namespace AERP.Web.UI.Controllers
{
    public class GeneralItemMasterController : BaseController
    {
        IGeneralItemMasterBA _GeneralItemMasterBA = null;
        IGeneralPriceListAndListLineBA _GeneralPriceListAndListLineBA = null;
        IGeneralPriceGroupBA _GeneralPriceGroupBA = null;
        IGeneralItemCategoryMasterBA _GeneralItemCategoryMasterBA = null;
        IGeneralPurchaseGroupMasterBA _GeneralPurchaseGroupMasterBA = null;
        //IGeneralSupplierMasterBA _IGeneralSupplierMasterBA = null;
        IGeneralPackageTypeBA _IGeneralPackageTypeBA = null;
        IInventoryUoMGroupAndDetailsBA _InventoryUoMGroupAndDetailsBA = null;
        IInventoryUoMMasterBA _InventoryUoMMasterBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;
        IGeneralCountryMasterBA _GeneralCountryMasterBA = null;
        IGeneralCurrencyMasterBA _GeneralCurrencyMasterBA = null;
        IOrderingAndDeliveryDayBA _OrderingAndDeliveryDayBA = null;
        IVendorMasterBA _VendorMasterBA = null;
        IGeneralTemperatureMasterBA _GeneraltemperatureMasterBA = null;
        //IInventoryRecipeMenuCategoryBA _IInventoryRecipeMenuCategoryBA = null;

        IInventoryBrandMasterBA _InventoryBrandMasterBA = null;
        InventoryAttributeMasterBA _InventoryAttributeMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        int BarcodeCount;
        int ItemCount;
        int VendorCount;
        int ItemalphanumericCount;
        static string xmlParameter = null;
        static string UomDetailsParameterXML1 = null;
        static string UomDetailsParameterXML2 = null;
        static string UomDetailsParameterXML3 = null;
        static string UomDetailsParameterXML4 = null;

        static bool IsExcelValid = true;
        static string errorMessage = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemMasterController()
        {
            _GeneralItemMasterBA = new GeneralItemMasterBA();
            _GeneralPriceListAndListLineBA = new GeneralPriceListAndListLineBA();
            _GeneralPriceGroupBA = new GeneralPriceGroupBA();
            _GeneralItemCategoryMasterBA = new GeneralItemCategoryMasterBA();
            _GeneralPurchaseGroupMasterBA = new GeneralPurchaseGroupMasterBA();
            //_IGeneralSupplierMasterBA = new GeneralSupplierMasterBA();
            _IGeneralPackageTypeBA = new GeneralPackageTypeBA();
            _InventoryUoMGroupAndDetailsBA = new InventoryUoMGroupAndDetailsBA();
            _InventoryUoMMasterBA = new InventoryUoMMasterBA();
            _GeneralUnitsBA = new GeneralUnitsBA();
            _GeneralCountryMasterBA = new GeneralCountryMasterBA();
            _GeneralCurrencyMasterBA = new GeneralCurrencyMasterBA();
            _OrderingAndDeliveryDayBA = new OrderingAndDeliveryDayBA();
            _VendorMasterBA = new VendorMasterBA();
            _GeneraltemperatureMasterBA = new GeneralTemperatureMasterBA();
            //_IInventoryRecipeMenuCategoryBA = new InventoryRecipeMenuCategoryBA();
            _InventoryBrandMasterBA = new InventoryBrandMasterBA();
            _InventoryAttributeMasterBA = new InventoryAttributeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }

                return View("/Views/Inventory/GeneralItemMaster/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string TaskCode)
        {
            try
            {
                GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();

                //List<SelectListItem> ItemType = new List<SelectListItem>();
                //ViewBag.ItemType = new SelectList(ItemType, "Value", "Text");
                //List<SelectListItem> li_ItemType = new List<SelectListItem>();
                ////     li_RelatedWith.Add(new SelectListItem { Text = " ", Value = " " });s
                //li_ItemType.Add(new SelectListItem { Text = "Retail Sale", Value = "1" });
                //li_ItemType.Add(new SelectListItem { Text = "BOM", Value = "2" });
                //li_ItemType.Add(new SelectListItem { Text = "Fixed Asset", Value = "3" });

                //ViewData["ItemType"] = li_ItemType;
                //if (!string.IsNullOrEmpty(actionMode))
                //{
                //    TempData["ActionMode"] = actionMode;
                //}


                return PartialView("/Views/Inventory/GeneralItemMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult GeneralItemUoMData(string TaskCode, string ItemNumber, string GeneralItemMasterID)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.TaskCode = TaskCode;
            model.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);

            model.GeneralItemMasterListForUoMDetails = GetGeneralItemMasterListForUoMDetails(TaskCode, ItemNumber);
            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                if (model.GeneralItemMasterListForUoMDetails.Count > 0 && model.GeneralItemMasterListForUoMDetails != null)
                {
                    // model.UomCode = model.GeneralItemMasterListForUoMDetails[0].UomCode;
                    model.BaseQty = model.GeneralItemMasterListForUoMDetails[0].BaseQty;
                }
            }

            List<InventoryUoMMaster> InventoryUoMMaster = GetListInventoryUoMMasterForUomCode();
            List<SelectListItem> InventoryUoMMasterList = new List<SelectListItem>();
            foreach (InventoryUoMMaster item in InventoryUoMMaster)
            {
                InventoryUoMMasterList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
            }
            ViewBag.InventoryUoMMasterForUomCodeList = new SelectList(InventoryUoMMasterList, "Value", "Text");



            return PartialView("/Views/Inventory/GeneralItemMaster/CreateUoMCodeData.cshtml", model);
        }
        public ActionResult CreateGeneralItemSuppliersData(string TaskCode, string ItemNumber, bool IsMultipleVendor, string ItemDescription, string GeneralVendorID)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.TaskCode = TaskCode;
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.GeneralVendorID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralVendorID) ? GeneralVendorID : null);
            model.GeneralItemMasterDTO.IsMultipleVendor = IsMultipleVendor;
            model.GeneralItemMasterDTO.ItemDescription = ItemDescription;
            if (model.GeneralItemMasterDTO.IsMultipleVendor == false)
            {
                if (model.GeneralItemMasterDTO.ItemNumber > 0)
                {

                    IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.GetGeneralItemSupliersDataByItemNumber(model.GeneralItemMasterDTO);
                    if (response != null && response.Entity != null)
                    {
                        model.GeneralItemMasterDTO.GeneralItemSupliersDataID = response.Entity.GeneralItemSupliersDataID;
                        model.GeneralItemMasterDTO.ManufacturCatalogNumber = response.Entity.ManufacturCatalogNumber;
                        model.GeneralItemMasterDTO.GenTaxGroupMasterID = response.Entity.GenTaxGroupMasterID;
                        model.GeneralItemMasterDTO.VendorName = response.Entity.VendorName;
                        model.GeneralItemMasterDTO.GeneralVendorID = response.Entity.GeneralVendorID;
                        model.GeneralItemMasterDTO.PurchaseUoMCode = response.Entity.PurchaseUoMCode;
                        model.GeneralItemMasterDTO.GeneralPurchaseGroupMasterID = response.Entity.GeneralPurchaseGroupMasterID;
                        model.GeneralItemMasterDTO.PackageType = response.Entity.PackageType;
                        model.GeneralItemMasterDTO.CreatedBy = response.Entity.CreatedBy;
                        model.GeneralItemMasterDTO.GenTaxGroupMasterID = response.Entity.GenTaxGroupMasterID;
                        model.GeneralItemMasterDTO.PurchaseOrganization = response.Entity.PurchaseOrganization;
                        model.GeneralItemMasterDTO.LeadTime = response.Entity.LeadTime;
                        model.GeneralItemMasterDTO.ShelfLife = response.Entity.ShelfLife;
                        model.GeneralItemMasterDTO.MinimumOrderquantity = response.Entity.MinimumOrderquantity;
                        model.GeneralItemMasterDTO.HSCode = response.Entity.HSCode;
                        model.GeneralItemMasterDTO.CountryOfOrigin = response.Entity.CountryOfOrigin;
                        model.GeneralItemMasterDTO.LastPurchasePrice = response.Entity.LastPurchasePrice;
                        model.GeneralItemMasterDTO.CurrencyCode = response.Entity.CurrencyCode;
                        model.GeneralItemMasterDTO.RemainingShelfLife = response.Entity.RemainingShelfLife;
                        model.GeneralItemMasterDTO.ManufacturerName = response.Entity.ManufacturerName;
                        model.GeneralItemMasterDTO.VendorNumber = response.Entity.VendorNumber;


                    }
                }
                //Muliple Vendor
                List<GeneralItemMaster> GeneralSupplierMaster = GetListMultipleVendorItemWise(model.GeneralItemMasterDTO.ItemNumber);
                List<SelectListItem> GeneralSupplierMasterList = new List<SelectListItem>();
                foreach (GeneralItemMaster item in GeneralSupplierMaster)
                {
                    GeneralSupplierMasterList.Add(new SelectListItem { Text = item.VendorName, Value = Convert.ToString(item.VendorNumber) });
                }
                ViewBag.VendorNameList = new SelectList(GeneralSupplierMasterList, "Value", "Text", model.VendorNumber);
                //End Code Muliple Vendor

                List<GeneralTaxGroupMaster> GeneralTaxGroupMaster = GetGeneralTaxGroupMaster();
                List<SelectListItem> GeneralTaxGroupMasterList = new List<SelectListItem>();
                foreach (GeneralTaxGroupMaster item in GeneralTaxGroupMaster)
                {
                    GeneralTaxGroupMasterList.Add(new SelectListItem { Text = item.TaxGroupName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralTaxGroupMasterList = new SelectList(GeneralTaxGroupMasterList, "Value", "Text", model.GenTaxGroupMasterID);
                //*****************************************************************************************************************//
                List<GeneralPurchaseGroupMaster> GeneralPurchaseGroupMaster = GetListGeneralPurchaseGroupMaster();
                List<SelectListItem> GeneralPurchaseGroupMasterList = new List<SelectListItem>();
                foreach (GeneralPurchaseGroupMaster item in GeneralPurchaseGroupMaster)
                {
                    GeneralPurchaseGroupMasterList.Add(new SelectListItem { Text = item.PurchaseGroupCode, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralPurchaseGroupMasterList = new SelectList(GeneralPurchaseGroupMasterList, "Value", "Text");
                //****************************************************************************************************************//
                List<InventoryUoMMaster> InventoryUoMMaster = GetPurchaseUomCode(ItemNumber);
                List<SelectListItem> InventoryPurchaseUomCodeList = new List<SelectListItem>();
                foreach (InventoryUoMMaster item in InventoryUoMMaster)
                {
                    InventoryPurchaseUomCodeList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
                }
                ViewBag.InventoryPurchaseUomCodeList = new SelectList(InventoryPurchaseUomCodeList, "Value", "Text");

                //**************************************************************************************************************//
                List<GeneralCountryMaster> GeneralCountryMaster = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMasterList = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMaster)
                {
                    GeneralCountryMasterList.Add(new SelectListItem { Text = item.CountryName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralCountryMasterList = new SelectList(GeneralCountryMasterList, "Value", "Text");

                //**************************************************************************************************************//
                List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
                List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
                foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
                {
                    GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = item.CurrencyCode });
                }
                ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text");
                return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemSupliersData.cshtml", model);
            }
            else
            {
                if (model.GeneralItemMasterDTO.ItemNumber > 0)
                {
                    model.MultipleVendorListDataList = GetGeneralItemSupliersDataByItemNumberandVendorIDLiSt(Convert.ToString(model.GeneralItemMasterDTO.ItemNumber), Convert.ToString(model.GeneralItemMasterDTO.GeneralVendorID));
                    if (model.MultipleVendorListDataList.Count > 0)
                    {
                        model.GeneralItemMasterDTO.GeneralItemSupliersDataID = model.MultipleVendorListDataList[0].GeneralItemSupliersDataID;
                        model.GeneralItemMasterDTO.ManufacturCatalogNumber = model.MultipleVendorListDataList[0].ManufacturCatalogNumber;
                        model.GeneralItemMasterDTO.GenTaxGroupMasterID = model.MultipleVendorListDataList[0].GenTaxGroupMasterID;
                        model.GeneralItemMasterDTO.VendorName = model.MultipleVendorListDataList[0].VendorName;
                        model.GeneralItemMasterDTO.GeneralVendorID = model.MultipleVendorListDataList[0].GeneralVendorID;
                        model.GeneralItemMasterDTO.PurchaseUoMCode = model.MultipleVendorListDataList[0].PurchaseUoMCode;
                        model.GeneralItemMasterDTO.GeneralPurchaseGroupMasterID = model.MultipleVendorListDataList[0].GeneralPurchaseGroupMasterID;
                        model.GeneralItemMasterDTO.PackageType = model.MultipleVendorListDataList[0].PackageType;
                        model.GeneralItemMasterDTO.CreatedBy = model.MultipleVendorListDataList[0].CreatedBy;
                        model.GeneralItemMasterDTO.GenTaxGroupMasterID = model.MultipleVendorListDataList[0].GenTaxGroupMasterID;
                        model.GeneralItemMasterDTO.PurchaseOrganization = model.MultipleVendorListDataList[0].PurchaseOrganization;
                        model.GeneralItemMasterDTO.LeadTime = model.MultipleVendorListDataList[0].LeadTime;
                        model.GeneralItemMasterDTO.ShelfLife = model.MultipleVendorListDataList[0].ShelfLife;
                        model.GeneralItemMasterDTO.MinimumOrderquantity = model.MultipleVendorListDataList[0].MinimumOrderquantity;
                        model.GeneralItemMasterDTO.HSCode = model.MultipleVendorListDataList[0].HSCode;
                        model.GeneralItemMasterDTO.CountryOfOrigin = model.MultipleVendorListDataList[0].CountryOfOrigin;
                        model.GeneralItemMasterDTO.LastPurchasePrice = model.MultipleVendorListDataList[0].LastPurchasePrice;
                        model.GeneralItemMasterDTO.CurrencyCode = model.MultipleVendorListDataList[0].CurrencyCode;
                        model.GeneralItemMasterDTO.RemainingShelfLife = model.MultipleVendorListDataList[0].RemainingShelfLife;
                        model.GeneralItemMasterDTO.ManufacturerName = model.MultipleVendorListDataList[0].ManufacturerName;
                        model.GeneralItemMasterDTO.VendorNumber = model.MultipleVendorListDataList[0].VendorNumber;
                        model.IsDefaultVendor = model.MultipleVendorListDataList[0].IsDefaultVendor;


                    }
                }
                //Muliple Vendor
                List<GeneralItemMaster> GeneralSupplierMaster = GetListMultipleVendorItemWise(model.GeneralItemMasterDTO.ItemNumber);
                List<SelectListItem> GeneralSupplierMasterList = new List<SelectListItem>();
                foreach (GeneralItemMaster item in GeneralSupplierMaster)
                {
                    GeneralSupplierMasterList.Add(new SelectListItem { Text = item.VendorName, Value = Convert.ToString(item.GeneralVendorID) });
                }
                ViewBag.VendorNameList = new SelectList(GeneralSupplierMasterList, "Value", "Text", model.VendorNumber);
                //End Code Muliple Vendor
                List<GeneralTaxGroupMaster> GeneralTaxGroupMaster = GetGeneralTaxGroupMaster();
                List<SelectListItem> GeneralTaxGroupMasterList = new List<SelectListItem>();
                foreach (GeneralTaxGroupMaster item in GeneralTaxGroupMaster)
                {
                    GeneralTaxGroupMasterList.Add(new SelectListItem { Text = item.TaxGroupName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralTaxGroupMasterList = new SelectList(GeneralTaxGroupMasterList, "Value", "Text", model.GenTaxGroupMasterID);
                //*****************************************************************************************************************//
                List<GeneralPurchaseGroupMaster> GeneralPurchaseGroupMaster = GetListGeneralPurchaseGroupMaster();
                List<SelectListItem> GeneralPurchaseGroupMasterList = new List<SelectListItem>();
                foreach (GeneralPurchaseGroupMaster item in GeneralPurchaseGroupMaster)
                {
                    GeneralPurchaseGroupMasterList.Add(new SelectListItem { Text = item.PurchaseGroupCode, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralPurchaseGroupMasterList = new SelectList(GeneralPurchaseGroupMasterList, "Value", "Text");
                //****************************************************************************************************************//
                List<InventoryUoMMaster> InventoryUoMMaster = GetPurchaseUomCode(ItemNumber);
                List<SelectListItem> InventoryPurchaseUomCodeList = new List<SelectListItem>();
                foreach (InventoryUoMMaster item in InventoryUoMMaster)
                {
                    InventoryPurchaseUomCodeList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
                }
                ViewBag.InventoryPurchaseUomCodeList = new SelectList(InventoryPurchaseUomCodeList, "Value", "Text");

                //**************************************************************************************************************//
                List<GeneralCountryMaster> GeneralCountryMaster = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMasterList = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMaster)
                {
                    GeneralCountryMasterList.Add(new SelectListItem { Text = item.CountryName, Value = Convert.ToString(item.ID) });
                }
                ViewBag.GeneralCountryMasterList = new SelectList(GeneralCountryMasterList, "Value", "Text");

                //**************************************************************************************************************//
                List<GeneralCurrencyMaster> GeneralCurrencyMaster = GetListGeneralCurrencyMaster();
                List<SelectListItem> GeneralCurrencyMasterList = new List<SelectListItem>();
                foreach (GeneralCurrencyMaster item in GeneralCurrencyMaster)
                {
                    GeneralCurrencyMasterList.Add(new SelectListItem { Text = item.CurrencyCode, Value = item.CurrencyCode });
                }
                ViewBag.GeneralCurrencyMasterList = new SelectList(GeneralCurrencyMasterList, "Value", "Text");
                return PartialView("/Views/Inventory/GeneralItemMaster/CreateMultipleVendor.cshtml", model);
            }
        }
        public ActionResult CreateGeneralItemGeneralData(string TaskCode, string ItemNumber)
        {

            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.TaskCode = TaskCode;
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.GetGeneralItemGeneralDataByItemNumber(model.GeneralItemMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMasterDTO.GeneralItemGeneralDataID = response.Entity.GeneralItemGeneralDataID;
                    model.GeneralItemMasterDTO.ManufacturerID = response.Entity.ManufacturerID;
                    model.GeneralItemMasterDTO.ShippingTypeId = response.Entity.ShippingTypeId;
                    model.GeneralItemMasterDTO.SerialAndBatchManagedBy = response.Entity.SerialAndBatchManagedBy;
                    model.GeneralItemMasterDTO.ManagementMethod = response.Entity.ManagementMethod;
                    model.GeneralItemMasterDTO.IssueMethod = response.Entity.IssueMethod;
                    model.GeneralItemMasterDTO.Temprature = response.Entity.Temprature;
                    //model.GeneralItemMasterDTO.TempratureUpto = response.Entity.TempratureUpto;
                    model.GeneralItemMasterDTO.CreatedBy = response.Entity.CreatedBy;
                    model.GeneralItemMasterDTO.ItemCategoryCode = response.Entity.ItemCategoryCode;
                    model.GeneralItemMasterDTO.GenTaxGroupMasterID = response.Entity.GenTaxGroupMasterID;
                    model.GenTaxGroupMasterID = response.Entity.GenTaxGroupMasterID;

                    model.GeneralItemMasterDTO.NetContentPerPiece = response.Entity.NetContentPerPiece;
                    model.GeneralItemMasterDTO.NetContentUOM = response.Entity.NetContentUOM;
                    model.GeneralItemMasterDTO.NetWeightPerPiece = response.Entity.NetWeightPerPiece;
                    model.GeneralItemMasterDTO.SpecialFeature = response.Entity.SpecialFeature;
                    model.GeneralItemMasterDTO.ShortDescription = response.Entity.ShortDescription;
                    model.GeneralItemMasterDTO.BrandName = response.Entity.BrandName;
                    model.GeneralItemMasterDTO.ArabicTransalation = response.Entity.ArabicTransalation;
                    model.GeneralItemMasterDTO.HSNCode = response.Entity.HSNCode;
                }
            }

            //**************************************************************************************************************//
            List<GeneralItemCategoryMaster> GeneralItemCategoryMaster = GetListGeneralItemCategoryMaster();
            List<SelectListItem> GeneralItemCategoryMasterList = new List<SelectListItem>();
            foreach (GeneralItemCategoryMaster item in GeneralItemCategoryMaster)
            {
                GeneralItemCategoryMasterList.Add(new SelectListItem { Text = item.ItemCategoryCode + " - " + item.ItemCategoryDescription, Value = Convert.ToString(item.ItemCategoryCode) });
            }
            ViewBag.GeneralItemCategoryMasterList = new SelectList(GeneralItemCategoryMasterList, "Value", "Text");
            //*****************************************************************************************************************//

            List<GeneralTaxGroupMaster> GeneralTaxGroupMaster = GetGeneralTaxGroupMaster();
            List<SelectListItem> GeneralTaxGroupMasterList = new List<SelectListItem>();
            foreach (GeneralTaxGroupMaster item in GeneralTaxGroupMaster)
            {
                GeneralTaxGroupMasterList.Add(new SelectListItem { Text = item.TaxGroupName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralTaxGroupMasterList = new SelectList(GeneralTaxGroupMasterList, "Value", "Text", model.GenTaxGroupMasterID);
            //*****************************************************************************************************************//

            List<SelectListItem> SerialAndBatchManagedBy = new List<SelectListItem>();
            ViewBag.SerialAndBatchManagedBy = new SelectList(SerialAndBatchManagedBy, "Value", "Text");
            List<SelectListItem> li_SerialAndBatchManagedBy = new List<SelectListItem>();

            if (model.GeneralItemMasterDTO.SerialAndBatchManagedBy > 0)
            {
                li_SerialAndBatchManagedBy.Add(new SelectListItem { Text = "None", Value = "3" });
                li_SerialAndBatchManagedBy.Add(new SelectListItem { Text = "Serial", Value = "1" });
                li_SerialAndBatchManagedBy.Add(new SelectListItem { Text = "Batch", Value = "2" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["SerialAndBatchManagedBy"] = new SelectList(li_SerialAndBatchManagedBy, "Value", "Text", (model.GeneralItemMasterDTO.SerialAndBatchManagedBy).ToString().Trim());
            }
            else
            {

                li_SerialAndBatchManagedBy.Add(new SelectListItem { Text = "None", Value = "3" });
                li_SerialAndBatchManagedBy.Add(new SelectListItem { Text = "Serial", Value = "1" });
                li_SerialAndBatchManagedBy.Add(new SelectListItem { Text = "Batch", Value = "2" });
                
                ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
            }

            List<SelectListItem> ManagementMethod = new List<SelectListItem>();
            ViewBag.ManagementMethod = new SelectList(ManagementMethod, "Value", "Text");
            List<SelectListItem> li_ManagementMethod = new List<SelectListItem>();

            if (model.GeneralItemMasterDTO.ManagementMethod > 0)
            {

                li_ManagementMethod.Add(new SelectListItem { Text = "On Every Transaction", Value = "1" });
                li_ManagementMethod.Add(new SelectListItem { Text = "On Release Only", Value = "2" });
                ViewData["ManagementMethod"] = new SelectList(li_ManagementMethod, "Value", "Text", (model.GeneralItemMasterDTO.ManagementMethod).ToString().Trim());
            }
            else
            {
                li_ManagementMethod.Add(new SelectListItem { Text = "On Every Transaction", Value = "1" });
                li_ManagementMethod.Add(new SelectListItem { Text = "On Release Only", Value = "2" });
                ViewData["ManagementMethod"] = li_ManagementMethod;
            }
            ////****************Static Dropdown for temperature field*********
            //List<SelectListItem> Temprature = new List<SelectListItem>();
            //ViewBag.Temprature = new SelectList(Temprature, "Value", "Text");
            //List<SelectListItem> li_Temprature = new List<SelectListItem>();
            //if (model.GeneralItemMasterDTO.Temprature > 0)
            //{

            //    li_Temprature.Add(new SelectListItem { Text = "0  to -10", Value = "1" });
            //    li_Temprature.Add(new SelectListItem { Text = "-10  to -20", Value = "2" });
            //    li_Temprature.Add(new SelectListItem { Text = "0  to 10", Value = "3" });
            //    li_Temprature.Add(new SelectListItem { Text = "10  to 20", Value = "4" });
            //    li_Temprature.Add(new SelectListItem { Text = "Above 20", Value = "5" });
            //    ViewData["Temprature"] = li_Temprature;


            //    ViewData["Temprature"] = new SelectList(li_Temprature, "Value", "Text", (model.GeneralItemMasterDTO.Temprature).ToString().Trim());
            //}
            //else
            //{
            //    li_Temprature.Add(new SelectListItem { Text = "0  to -10", Value = "1" });
            //    li_Temprature.Add(new SelectListItem { Text = "-10  to -20", Value = "2" });
            //    li_Temprature.Add(new SelectListItem { Text = "0  to 10", Value = "3" });
            //    li_Temprature.Add(new SelectListItem { Text = "10  to 20", Value = "4" });
            //    li_Temprature.Add(new SelectListItem { Text = "Above 20", Value = "5" });
            //    ViewData["Temprature"] = li_Temprature;
            //}

            List<GeneralTemperatureMaster> GeneralTemperatureMaster = GetListGeneralTemperatureMaster();
            List<SelectListItem> GeneralTemperatureMasterMasterList = new List<SelectListItem>();
            foreach (GeneralTemperatureMaster item in GeneralTemperatureMaster)
            {
                GeneralTemperatureMasterMasterList.Add(new SelectListItem { Text = item.TemperatureType + "(" + item.TemperatureDescription + ")", Value = Convert.ToString(item.GeneralTemperatureMasterID) });
            }
            ViewBag.GeneralTemperatureMasterMasterList = new SelectList(GeneralTemperatureMasterMasterList, "Value", "Text");


            List<InventoryUoMMaster> InventoryUoMMaster = GetListInventoryUoMMasterForUomCode();
            List<SelectListItem> InventoryUoMMasterList = new List<SelectListItem>();
            foreach (InventoryUoMMaster item in InventoryUoMMaster)
            {
                InventoryUoMMasterList.Add(new SelectListItem { Text = item.UomCode, Value = Convert.ToString(item.UomCode) });
            }
            ViewBag.InventoryUoMMasterForUomCodeList = new SelectList(InventoryUoMMasterList, "Value", "Text", model.NetContentUOM);

            //**************************************************************************************************************//
            List<InventoryBrandMaster> GeneralItemBrandMaster = GetListGeneralItemBrandMaster();
            List<SelectListItem> GeneralItemBrandName = new List<SelectListItem>();
            foreach (InventoryBrandMaster item in GeneralItemBrandMaster)
            {
                GeneralItemBrandName.Add(new SelectListItem { Text = item.BrandName, Value = Convert.ToString(item.BrandName) });
            }
            ViewBag.GeneralItemBrandName = new SelectList(GeneralItemBrandName, "Value", "Text", model.BrandName);



            return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemGeneralData.cshtml", model);
        }
        //public ActionResult CreateGeneralItemSalesData(string TaskCode, string ItemNumber, string SelectedCentreCodeForSaleTab,string GeneralUnitsID)
        //{
        //    GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
        //    model.TaskCode = TaskCode;
        //    model.GeneralItemMasterDTO.ConnectionString = _connectioString;
        //    model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);


        //    //if (Convert.ToString(Session["UserType"]) == "A")
        //    //{
        //    //    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
        //    //    AdminRoleApplicableDetails a = null;
        //    //    foreach (var item in listAdminRoleApplicableDetails)
        //    //    {

        //    //        a = new AdminRoleApplicableDetails();
        //    //        a.CentreCode = item.CentreCode + ":Centre";
        //    //        a.CentreName = item.CentreName;
        //    //        // a.ScopeIdentity = item.ScopeIdentity;
        //    //        model.ListGetAdminRoleApplicableCentre.Add(a);

        //    //    }
        //    //}
        //    //else
        //    {
        //        int AdminRoleMasterID = 0;
        //        if (Session["RoleID"] == null)
        //        {
        //            AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
        //        }

        //        else
        //        {
        //            AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
        //        }

        //    //    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
        //    //    AdminRoleApplicableDetails a = null;
        //    //    foreach (var item in listAdminRoleApplicableDetails)
        //    //    {
        //    //        a = new AdminRoleApplicableDetails();
        //    //        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
        //    //        a.CentreName = item.CentreName;
        //    //        // a.ScopeIdentity = item.ScopeIdentity;
        //    //        model.ListGetAdminRoleApplicableCentre.Add(a);
        //    //    }
        //    }
        //    //if (!string.IsNullOrEmpty(SelectedCentreCodeForSaleTab))
        //    //{
        //    //    string[] splitCentreCode = SelectedCentreCodeForSaleTab.Split(':');
        //    //    model.CentreCode = splitCentreCode[0];
        //    //}
        //    //    model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);

        //       // model.GeneralItemMasterDTO.SelectedCentreCodeForSaleTab = SelectedCentreCodeForSaleTab;
        //      //  model.GeneralItemMasterDTO.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
        //    //List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
        //    //List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
        //    //foreach (GeneralUnits item in GeneralUnits)
        //    //{
        //    //    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
        //    //}
        //    //ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");
        //    //****************************************************************************************************************//


        //        model.GeneralItemMasterListForSaleUoMDetails = GetSaleUomCode(ItemNumber);

        //    return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemSalesData.cshtml", model);
        //}
        public ActionResult SaleUomCodeData(string TaskCode, string ItemNumber, string GeneralUnitsID, string SelectedCentreCodeForSaleTab)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.TaskCode = TaskCode;
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);

            //if (!string.IsNullOrEmpty(SelectedCentreCodeForSaleTab))
            //{
            //    string[] splitCentreCode = SelectedCentreCodeForSaleTab.Split(':');
            //    model.CentreCode = splitCentreCode[0];
            //}
            //model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);

            //List<GeneralUnits> GeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
            //List<SelectListItem> GeneralUnitsList = new List<SelectListItem>();
            //foreach (GeneralUnits item in GeneralUnits)
            //{
            //    GeneralUnitsList.Add(new SelectListItem { Text = item.UnitName, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.GeneralUnitsList = new SelectList(GeneralUnitsList, "Value", "Text");
            //if (model.ListGeneralUnits.Count > 0)
            //{
            //{
            //int AdminRoleMasterID = 0;
            //if (Session["RoleID"] == null)
            //{
            //    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            //}

            //else
            //{
            //    AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            //}
            //List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
            //string GetCentreListXML = "<rows>";
            //foreach (var item in listAdminRoleApplicableDetails)
            //{
            //    GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            //}
            //GetCentreListXML = GetCentreListXML + "</rows>";

            //model.CentreListXML = GetCentreListXML;

            //  model.GeneralItemMasterListForSaleUoMDetails = GetSaleUomCode(ItemNumber);
            // }
            model.GeneralItemMasterListForSaleData = GetGeneralItemMasterListForSaleDetails(ItemNumber, model.CentreListXML);//GeneralUnitsID);
            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                if (model.GeneralItemMasterListForSaleData.Count > 0 && model.GeneralItemMasterListForSaleData != null)
                {
                    model.ItemNumber = model.GeneralItemMasterListForSaleData[0].ItemNumber;
                    model.GeneralUnitsID = model.GeneralItemMasterListForSaleData[0].GeneralUnitsID;
                }
            }

            return PartialView("/Views/Inventory/GeneralItemMaster/SaleUomCodeData.cshtml", model);
        }
        [HttpPost]
        public ActionResult Create(GeneralItemMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {

                if (model != null && model.GeneralItemMasterDTO != null)
                {
                    //GeneralItemMaster
                    model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                    model.GeneralItemMasterDTO.GeneralItemMasterID = model.GeneralItemMasterID;
                    model.GeneralItemMasterDTO.ItemNumber = model.ItemNumber;
                    model.GeneralItemMasterDTO.ItemDescription = model.ItemDescription;
                    model.GeneralItemMasterDTO.ItemType = model.ItemType;
                    model.GeneralItemMasterDTO.InventoryPurchaseGroupMasterId = model.InventoryPurchaseGroupMasterId;
                    model.GeneralItemMasterDTO.ItemCategoryCode = model.ItemCategoryCode;
                    model.GeneralItemMasterDTO.UoMGroupCode = model.UoMGroupCode;
                    model.GeneralItemMasterDTO.BaseUoMcode = model.BaseUoMcode;
                    model.GeneralItemMasterDTO.BasePriceListID = model.BasePriceListID;
                    model.GeneralItemMasterDTO.BaseBarCode = model.BaseBarCode;
                    model.GeneralItemMasterDTO.LastPurchasePrice = model.LastPurchasePrice;
                    model.GeneralItemMasterDTO.IsInventoryItem = model.IsInventoryItem;
                    model.GeneralItemMasterDTO.IsSalesItem = model.IsSalesItem;
                    model.GeneralItemMasterDTO.IsPurchaseItem = model.IsPurchaseItem;
                    model.GeneralItemMasterDTO.IsFixedAssetItem = model.IsFixedAssetItem;
                    model.GeneralItemMasterDTO.IsMultipleVendor = model.IsMultipleVendor;
                    model.GeneralItemMasterDTO.IsEComItem = model.IsEComItem;
                    model.GeneralItemMasterDTO.IsServiceItem = model.IsServiceItem;
                    model.GeneralItemMasterDTO.DisplayName = model.DisplayName;
                    model.GeneralItemMasterDTO.IsConsumable = model.IsConsumable;
                    model.GeneralItemMasterDTO.IsMachine = model.IsMachine;
                    model.GeneralItemMasterDTO.IsToner = model.IsToner;

                    model.GeneralItemMasterDTO.CurrencyCode = model.CurrencyCode;
                    model.GeneralItemMasterDTO.GenTaxGroupMasterID = model.GenTaxGroupMasterID;
                    model.GeneralItemMasterDTO.TaskCode = model.TaskCode;

                    //GeneralItemCode
                    model.GeneralItemMasterDTO.GeneralItemCodeID = model.GeneralItemCodeID;
                    //model.GeneralItemMasterDTO.LastPurchasePrice = model.Price;
                    model.GeneralItemMasterDTO.IsDefault = model.IsDefault;
                    model.GeneralItemMasterDTO.IsBaseUom = model.IsBaseUom;
                    model.GeneralItemMasterDTO.UomCode = model.BaseUoMcode;
                    model.GeneralItemMasterDTO.XMLstring = model.XMLstring;

                    //GeneralItemSupliersData
                    model.GeneralItemMasterDTO.GeneralItemSupliersDataID = model.GeneralItemSupliersDataID;
                    model.GeneralItemMasterDTO.GeneralVendorID = model.GeneralVendorID;
                    model.GeneralItemMasterDTO.ManufacturCatalogNumber = model.ManufacturCatalogNumber;
                    model.GeneralItemMasterDTO.PurchaseUoMCode = model.PurchaseUoMCode;
                    model.GeneralItemMasterDTO.GeneralPurchaseGroupMasterID = model.GeneralPurchaseGroupMasterID;
                    // model.GeneralItemMasterDTO.LastPurchasePrice = model.LastPurchasePrice;
                    //model.GeneralItemMasterDTO.PackageType = model.PackageType;
                    model.GeneralItemMasterDTO.PurchaseOrganization = model.PurchaseOrganization;
                    model.GeneralItemMasterDTO.MinimumOrderquantity = model.MinimumOrderquantity;
                    model.GeneralItemMasterDTO.LeadTime = model.LeadTime;
                    model.GeneralItemMasterDTO.ShelfLife = model.ShelfLife;
                    model.GeneralItemMasterDTO.CountryOfOrigin = model.CountryOfOrigin;
                    model.GeneralItemMasterDTO.HSCode = model.HSCode;
                    model.GeneralItemMasterDTO.CurrencyCode = model.CurrencyCode;
                    model.GeneralItemMasterDTO.RemainingShelfLife = model.RemainingShelfLife;
                    model.GeneralItemMasterDTO.ManufacturerName = model.ManufacturerName;
                    model.GeneralItemMasterDTO.VendorNumber = model.VendorNumber;
                    model.GeneralItemMasterDTO.IsDefaultVendor = model.IsDefaultVendor;




                    //GeneralItemGeneralData
                    model.GeneralItemMasterDTO.GeneralItemGeneralDataID = model.GeneralItemGeneralDataID;
                    model.GeneralItemMasterDTO.ManufacturerID = model.ManufacturerID;
                    model.GeneralItemMasterDTO.ShippingTypeId = model.ShippingTypeId;
                    model.GeneralItemMasterDTO.SerialAndBatchManagedBy = model.SerialAndBatchManagedBy;
                    model.GeneralItemMasterDTO.ManagementMethod = model.ManagementMethod;
                    model.GeneralItemMasterDTO.IssueMethod = model.IssueMethod;
                    model.GeneralItemMasterDTO.Temprature = model.Temprature;
                    model.GeneralItemMasterDTO.NetContentPerPiece = model.NetContentPerPiece;
                    model.GeneralItemMasterDTO.NetWeightPerPiece = model.NetWeightPerPiece;
                    model.GeneralItemMasterDTO.NetContentUOM = model.NetContentUOM;
                    model.GeneralItemMasterDTO.SpecialFeature = model.SpecialFeature;
                    model.GeneralItemMasterDTO.ShortDescription = model.ShortDescription;
                    model.GeneralItemMasterDTO.BrandName = model.BrandName;
                    model.GeneralItemMasterDTO.ArabicTransalation = model.ArabicTransalation;
                    //model.GeneralItemMasterDTO.TempratureUpto = model.TempratureUpto;

                    //GeneralItemSalesData
                    model.GeneralItemMasterDTO.GeneralItemSalesDataID = model.GeneralItemSalesDataID;
                    model.GeneralItemMasterDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.GeneralItemMasterDTO.XMLstringForSaleUomcode = model.XMLstringForSaleUomcode;


                    //GeneralItemStockData
                    model.GeneralItemMasterDTO.GeneralItemStockDataID = model.GeneralItemStockDataID;
                    model.GeneralItemMasterDTO.GLAccountBy = model.GLAccountBy;
                    model.GeneralItemMasterDTO.StockUoMCode = model.StockUoMCode;
                    model.GeneralItemMasterDTO.ValuationMethod = model.ValuationMethod;
                    model.GeneralItemMasterDTO.UomCode = model.UomCode;
                    model.GeneralItemMasterDTO.MinStock = model.MinStock;
                    model.GeneralItemMasterDTO.MaxStock = model.MaxStock;


                    model.GeneralItemMasterDTO.GeneralItemStoreSpecificDetailsXml = model.GeneralItemStoreSpecificDetailsXml;
                    if (!string.IsNullOrEmpty(model.CentreCode))
                    {
                        string[] splitCentreCode = model.CentreCode.Split(':');
                        model.CentreCode = splitCentreCode[0];
                    }
                    model.GeneralItemMasterDTO.CentreCode = model.CentreCode;
                    model.GeneralItemMasterDTO.InventoryItemStoreSpecificInfoID = model.InventoryItemStoreSpecificInfoID;
                    model.GeneralItemMasterDTO.InventoryItemCodeCentreLevelSpecificInfoID = model.InventoryItemCodeCentreLevelSpecificInfoID;
                    //model.GeneralItemMasterDTO.CentreCode = model.CentreCode;

                    //GeneralItemRestaurantData
                    model.GeneralItemMasterDTO.InventoryRecipeMasterID = model.InventoryRecipeMasterID;
                    model.GeneralItemMasterDTO.Description = model.Description;
                    model.GeneralItemMasterDTO.InventoryRecipeMasterTitle = model.InventoryRecipeMasterTitle;
                    model.GeneralItemMasterDTO.BillingItemName = model.BillingItemName;
                    model.GeneralItemMasterDTO.DefineVariants = model.DefineVariants;
                    model.GeneralItemMasterDTO.BOMRelevant = model.BOMRelevant;
                    model.GeneralItemMasterDTO.XMLstringForRestuarent = model.XMLstringForRestuarent;
                    model.GeneralItemMasterDTO.PriceForRecipe = model.PriceForRecipe;
                    model.GeneralItemMasterDTO.RecipeMenuCategoryID = model.RecipeMenuCategoryID;
                    model.GeneralItemMasterDTO.InventoryRecipeMenuMasterID = model.InventoryRecipeMenuMasterID;
                    model.GeneralItemMasterDTO.IsRelatedWithCafe = model.IsRelatedWithCafe;
                    model.GeneralItemMasterDTO.ArabicTransalationForMainMenu = model.ArabicTransalationForMainMenu;
                    model.GeneralItemMasterDTO.CroppedImagePath = model.CroppedImagePath;

                    //GeneralItemDimensionData
                    model.GeneralItemMasterDTO.XMLstringForAttribute = model.XMLstringForAttribute;
                    model.GeneralItemMasterDTO.GeneralItemAttributeDataID = model.GeneralItemAttributeDataID;

                    //model.GeneralItemMasterDTO.WidthOfItem = model.WidthOfItem;
                    //model.GeneralItemMasterDTO.Volume = model.Volume;

                    //GeneralItemEcommerceData
                    model.GeneralItemMasterDTO.XMLstringForMultipleImageUpload = model.XMLstringForMultipleImageUpload;
                    model.GeneralItemMasterDTO.HSNCode = model.HSNCode;


                    model.GeneralItemMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    model.GeneralItemMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.InsertGeneralItemMaster(model.GeneralItemMasterDTO);
                    model.GeneralItemMasterDTO.ID = response.Entity.ID;
                    model.GeneralItemMasterDTO.ItemNumber = response.Entity.ItemNumber;
                    model.GeneralItemMasterDTO.ItemCategoryCode = response.Entity.ItemCategoryCode;
                    model.GeneralItemMasterDTO.GeneralItemMasterID = model.GeneralItemMasterID;
                    model.GeneralItemMasterDTO.GeneralVendorID = model.GeneralVendorID;
                    if (response.Entity.ErrorCode == 18)
                    {
                        string[] arrayList = { "Entered Barcode are Repeated", "warning", string.Empty };
                        model.GeneralItemMasterDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        string[] arrayList = { "Barcode Already Exist in DataBase", "warning", string.Empty };
                        model.GeneralItemMasterDTO.errorMessage = string.Join(",", arrayList);
                    }
                    else
                    {
                        model.GeneralItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }



                    return Json(model.GeneralItemMasterDTO, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateGeneralItemWarehouseData()
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            return PartialView("/Views/Inventory/GeneralItemMaster/CreateWarehouseData.cshtml", model);
        }
        public ActionResult CreateGeneralItemStoreData(string TaskCode, string ItemNumber, string GeneralItemMasterID, string GeneralUnitsID, string GeneralVendorID, string ItemCategoryCode_Param)//,string CentreCode)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();

            //if (Convert.ToString(Session["UserType"]) == "A")
            //{
            //    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
            //    AdminRoleApplicableDetails a = null;
            //    foreach (var item in listAdminRoleApplicableDetails)
            //    {

            //        a = new AdminRoleApplicableDetails();
            //        a.CentreCode = item.CentreCode + ":Centre";
            //        a.CentreName = item.CentreName;
            //        // a.ScopeIdentity = item.ScopeIdentity;
            //        model.ListGetAdminRoleApplicableCentre.Add(a);

            //    }
            //}
            //else
            //{
            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }

            //    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
            //    AdminRoleApplicableDetails a = null;
            //    foreach (var item in listAdminRoleApplicableDetails)
            //    {
            //        a = new AdminRoleApplicableDetails();
            //        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
            //        a.CentreName = item.CentreName;
            //        // a.ScopeIdentity = item.ScopeIdentity;
            //        model.ListGetAdminRoleApplicableCentre.Add(a);
            //    }
            //}

            //if (!string.IsNullOrEmpty(CentreCode))
            //{
            //    string[] splitCentreCode = CentreCode.Split(':');
            //    model.CentreCode = splitCentreCode[0];
            //}

            //model.GeneralItemMasterDTO.SelectedCentreCode = CentreCode;

            //  model.GeneralItemMasterListForGeneralUnits = GetGeneralUnitsForItemmaster(model.CentreCode);

            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByStoreManager(AdminRoleMasterID);
            string GetCentreListXML = "<rows>";
            foreach (var item in listAdminRoleApplicableDetails)
            {
                GetCentreListXML = GetCentreListXML + "<row><CentreCode>" + item.CentreCode + "</CentreCode></row>";
            }
            GetCentreListXML = GetCentreListXML + "</rows>";

            model.CentreListXML = GetCentreListXML;

            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);
            model.GeneralItemMasterDTO.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
            model.GeneralItemMasterDTO.GeneralVendorID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralVendorID) ? GeneralVendorID : null);
            model.GeneralItemMasterDTO.ItemCategoryCode_Param = ItemCategoryCode_Param;

            model.GeneralItemMasterListForStoreData = GetGeneralItemMasterListForDelistingAndDelistingDate(GeneralItemMasterID, ItemNumber, model.CentreListXML);
            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                if (model.GeneralItemMasterListForStoreData.Count > 0 && model.GeneralItemMasterListForStoreData != null)
                {
                    model.ItemNumber = model.GeneralItemMasterListForStoreData[0].ItemNumber;
                }
            }


            List<SelectListItem> RPType = new List<SelectListItem>();
            ViewBag.RPType = new SelectList(RPType, "Value", "Text");
            List<SelectListItem> li_RPType = new List<SelectListItem>();
            li_RPType.Add(new SelectListItem { Text = "Reorder Point", Value = "1" });
            li_RPType.Add(new SelectListItem { Text = "Regression", Value = "2" });
            ViewData["RPType"] = li_RPType;

            List<SelectListItem> SupplySourceCode = new List<SelectListItem>();
            ViewBag.SupplySourceCode = new SelectList(SupplySourceCode, "Value", "Text");
            List<SelectListItem> li_SupplySourceCode = new List<SelectListItem>();
            li_SupplySourceCode.Add(new SelectListItem { Text = "External Vendor", Value = "1" });
            li_SupplySourceCode.Add(new SelectListItem { Text = "Internal Source", Value = "2" });
            ViewData["SupplySourceCode"] = li_SupplySourceCode;



            return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemStoreData.cshtml", model);
        }
        public ActionResult CreateGeneralItemRestaurantData(string TaskCode, string ItemNumber, string GeneralItemMasterID)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);

            if (model.GeneralItemMasterDTO.GeneralItemMasterID > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.GetRestaurantDataByItemNumber(model.GeneralItemMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMasterDTO.InventoryRecipeMasterID = response.Entity.InventoryRecipeMasterID;
                    model.GeneralItemMasterDTO.InventoryRecipeMasterTitle = response.Entity.InventoryRecipeMasterTitle;
                    // model.InventoryRecipeMasterTitle = response.Entity.InventoryRecipeMasterTitle;
                    model.GeneralItemMasterDTO.Description = response.Entity.Description;
                    model.GeneralItemMasterDTO.BillingItemName = response.Entity.BillingItemName;
                    model.GeneralItemMasterDTO.BOMRelevant = response.Entity.BOMRelevant;
                    model.GeneralItemMasterDTO.DefineVariants = response.Entity.DefineVariants;
                    model.BOMRelevant = response.Entity.BOMRelevant;
                    model.PriceForRecipe = response.Entity.PriceForRecipe;
                    model.DefineVariants = response.Entity.DefineVariants;
                    model.RecipeMenuCategoryID = response.Entity.RecipeMenuCategoryID;
                    model.InventoryRecipeMenuMasterID = response.Entity.InventoryRecipeMenuMasterID;
                    model.IsRelatedWithCafe = response.Entity.IsRelatedWithCafe;
                    model.ArabicTransalationForMainMenu = response.Entity.ArabicTransalationForMainMenu;
                    model.CroppedImagePath = response.Entity.CroppedImagePath;

                }
            }
            model.GeneralItemMasterListForVarientDetails = GetGeneralItemMasterListForVarientDetails(GeneralItemMasterID);
            if (model.GeneralItemMasterDTO.GeneralItemMasterID > 0)
            {
                if (model.GeneralItemMasterListForVarientDetails.Count > 0 && model.GeneralItemMasterListForVarientDetails != null)
                {
                    //model.RecipeVariationTitle = model.GeneralItemMasterListForVarientDetails[0].RecipeVariationTitle;
                    model.PriceForVariation = model.GeneralItemMasterListForVarientDetails[0].PriceForVariation;
                    model.IsActive = model.GeneralItemMasterListForVarientDetails[0].IsActive;
                }
            }

            //**************************************************************************************************************//
            //List<InventoryRecipeMenuCategory> GeneralItemCategoryMaster = GetListRecipeMenuCategory();
            //List<SelectListItem> GetListRecipeMenuCategoryList = new List<SelectListItem>();
            //foreach (InventoryRecipeMenuCategory item in GeneralItemCategoryMaster)
            //{
            //    GetListRecipeMenuCategoryList.Add(new SelectListItem { Text = item.MenuCategory, Value = Convert.ToString(item.ID) });
            //}
            //ViewBag.GetListRecipeMenuCategoryList = new SelectList(GetListRecipeMenuCategoryList, "Value", "Text");

            List<SelectListItem> IsRelatedWith = new List<SelectListItem>();
            ViewBag.IsRelatedWith = new SelectList(IsRelatedWith, "Value", "Text");
            List<SelectListItem> li_IsRelatedWith = new List<SelectListItem>();
            //li_IsRelatedWith.Add(new SelectListItem { Text = "None", Value = "0" });
            //li_IsRelatedWith.Add(new SelectListItem { Text = "Cafe", Value = "1" });
            //ViewData["IsRelatedWith"] = li_IsRelatedWith;



            if (model.GeneralItemMasterDTO.IsRelatedWithCafe > 0)
            {


                li_IsRelatedWith.Add(new SelectListItem { Text = "Cafe", Value = "1" });
                li_IsRelatedWith.Add(new SelectListItem { Text = "Kitchen", Value = "2" });
                ViewData["IsRelatedWithCafe"] = new SelectList(li_IsRelatedWith, "Value", "Text", (model.GeneralItemMasterDTO.IsRelatedWithCafe).ToString().Trim());
            }
            else
            {
                li_IsRelatedWith.Add(new SelectListItem { Text = "Cafe", Value = "1" });
                li_IsRelatedWith.Add(new SelectListItem { Text = "Kitchen", Value = "2" });
                ViewData["IsRelatedWithCafe"] = li_IsRelatedWith;
            }

            return PartialView("/Views/Inventory/GeneralItemMaster/CreateRestaurantMenuDetails.cshtml", model);
        }
        [HttpGet]
        public ActionResult CreateIngridentsOnVarients()
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            return PartialView("/Views/Inventory/GeneralItemMaster/CreateIngridentsOnVarients.cshtml", model);
        }
        public ActionResult CreateGeneralItemAttributeData(string TaskCode, string ItemNumber, string GeneralItemMasterID)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.TaskCode = TaskCode;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);


            model.GeneralItemMasterAttributeList = GetGeneralItemMasterListForAttributeData(GeneralItemMasterID, ItemNumber);
            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                if (model.GeneralItemMasterAttributeList.Count > 0 && model.GeneralItemMasterAttributeList != null)
                {
                    model.ItemNumber = model.GeneralItemMasterAttributeList[0].ItemNumber;
                }
            }

            //**************************************************************************************************************//
            List<InventoryAttributeMaster> InventoryAttributeMaster = GetListInventoryAttributeMaster();
            List<SelectListItem> InventoryAttributeMasterList = new List<SelectListItem>();
            foreach (InventoryAttributeMaster item in InventoryAttributeMaster)
            {
                InventoryAttributeMasterList.Add(new SelectListItem { Text = item.AttributeName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.InventoryAttributeMasterList = new SelectList(InventoryAttributeMasterList, "Value", "Text");


            return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemAttributeData.cshtml", model);

        }


        public ActionResult CreateGeneralItemServiceData(string TaskCode, string ItemNumber, string GeneralItemMasterID)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.TaskCode = TaskCode;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);

            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.GetGeneralItemServiceDataByItemNumber(model.GeneralItemMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMasterDTO.HSNCode = response.Entity.HSNCode;
                    model.GeneralItemMasterDTO.GenTaxGroupMasterID = response.Entity.GenTaxGroupMasterID;
                    model.GenTaxGroupMasterID = response.Entity.GenTaxGroupMasterID;
                }
            }

            List<GeneralTaxGroupMaster> GeneralTaxGroupMaster = GetGeneralTaxGroupMaster();
            List<SelectListItem> GeneralTaxGroupMasterList = new List<SelectListItem>();
            foreach (GeneralTaxGroupMaster item in GeneralTaxGroupMaster)
            {
                GeneralTaxGroupMasterList.Add(new SelectListItem { Text = item.TaxGroupName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralTaxGroupMasterList = new SelectList(GeneralTaxGroupMasterList, "Value", "Text", model.GenTaxGroupMasterID);




            return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemServiceData.cshtml", model);
        }
        public ActionResult CreateGeneralItemEcommerceData(string TaskCode, string ItemNumber, string ItemCategoryCode_Param)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.TaskCode = TaskCode;
            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.ItemCategoryCode_Param = ItemCategoryCode_Param;
            if (model.GeneralItemMasterDTO.ItemNumber > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.GetGeneralItemEcommerceDataByItemNumber(model.GeneralItemMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMasterDTO.ItemCategoryDescription = response.Entity.ItemCategoryDescription;
                    model.GeneralItemMasterDTO.GroupDescription = response.Entity.GroupDescription;
                    model.GeneralItemMasterDTO.MerchantiseDepartmentName = response.Entity.MerchantiseDepartmentName;
                    model.GeneralItemMasterDTO.MerchantiseCategoryName = response.Entity.MerchantiseCategoryName;
                    model.GeneralItemMasterDTO.MerchantiseSubCategoryName = response.Entity.MerchantiseSubCategoryName;
                    model.GeneralItemMasterDTO.MarchandiseBaseCatgoryName = response.Entity.MarchandiseBaseCatgoryName;
                    model.GeneralItemMasterDTO.ImageNameString = response.Entity.ImageNameString;
                    model.GeneralItemMasterDTO.DisplayName = response.Entity.DisplayName;

                }
            }

            return PartialView("/Views/Inventory/GeneralItemMaster/CreateECommerceData.cshtml", model);
        }
        [HttpGet]
        public ActionResult UploadExcel()
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            return PartialView("/Views/Inventory/GeneralItemMaster/UploadExcel.cshtml", model);
        }
        [HttpGet]
        public ActionResult MultipleVendor(string GeneralItemMasterID, string ItemNumber)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
            model.GeneralItemMasterDTO.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            return PartialView("/Views/Inventory/GeneralItemMaster/MultipleVendor.cshtml", model);
        }

        [HttpPost]
        public ActionResult MultipleVendor(GeneralItemMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                var errorMessage = string.Empty;
                IBaseEntityResponse<GeneralItemMaster> response = null;
                if (model != null && model.GeneralItemMasterDTO != null)

                {
                    model.GeneralItemMasterDTO.ConnectionString = _connectioString;

                    model.GeneralItemMasterDTO.VendorNumber = model.VendorNumber;
                    model.GeneralItemMasterDTO.GeneralVendorID = model.GeneralVendorID;
                    model.GeneralItemMasterDTO.GeneralItemSupliersDataID = model.GeneralItemSupliersDataID;
                    model.GeneralItemMasterDTO.ItemNumber = model.ItemNumber;
                    model.GeneralItemMasterDTO.IsDefaultVendor = model.IsDefaultVendor;

                    model.GeneralItemMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    //IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.InsertGeneralItemSupplierDataForVendorDetails(model.GeneralItemMasterDTO);
                    response = _GeneralItemMasterBA.InsertGeneralItemSupplierDataForVendorDetails(model.GeneralItemMasterDTO);
                    string errorMessageDis = string.Empty;
                    string colorCode = string.Empty;
                    string mode = string.Empty;
                    if (response.Entity.ErrorCode == 15)
                    {
                        errorMessageDis = response.Entity.errorMessage;
                        colorCode = "danger";
                    }
                    else if (response.Entity.ErrorCode == 16)
                    {
                        errorMessageDis = response.Entity.errorMessage;
                        colorCode = "danger";
                    }
                    else if (response.Entity.ErrorCode == 0)
                    {
                        errorMessageDis = response.Entity.errorMessage;
                        colorCode = "success";
                    }
                    string[] arrayList = { errorMessageDis, colorCode, mode };
                    errorMessage = string.Join(",", arrayList);
                    model.GeneralItemMasterDTO.errorMessage = errorMessage;

                    return Json(model.GeneralItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult CreateGeneralItemDimensionData(string TaskCode, string ItemNumber)
        //{
        //    GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();

        //    model.TaskCode = TaskCode;
        //    model.GeneralItemMasterDTO.ConnectionString = _connectioString;
        //    model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null); 
        //    return PartialView("/Views/Inventory/GeneralItemMaster/CreateGeneralItemDimensionData.cshtml", model);
        //}
        [HttpGet]
        public ActionResult CreateStoreSpecificInformation(string ItemNumber, string GeneralUnitsID, string GeneralItemMasterID, string UnitName, string GeneralVendorID, string ItemCategoryCode_Param)
        {
            GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();

            //List<SelectListItem> RPType = new List<SelectListItem>();
            //ViewBag.RPType = new SelectList(RPType, "Value", "Text");
            //List<SelectListItem> li_RPType = new List<SelectListItem>();
            //li_RPType.Add(new SelectListItem { Text = "Reorder Point", Value = "1" });
            //li_RPType.Add(new SelectListItem { Text = "Safety Stock Driven", Value = "2" });
            //ViewData["RPType"] = li_RPType;

            //List<SelectListItem> SupplySourceCode = new List<SelectListItem>();
            //ViewBag.SupplySourceCode = new SelectList(SupplySourceCode, "Value", "Text");
            //List<SelectListItem> li_SupplySourceCode = new List<SelectListItem>();
            //li_SupplySourceCode.Add(new SelectListItem { Text = "External Vendor", Value = "External Vendor" });
            //li_SupplySourceCode.Add(new SelectListItem { Text = "Internal Source", Value = "Internal Source" });
            //ViewData["SupplySourceCode"] = li_SupplySourceCode;


            model.GeneralItemMasterDTO.ConnectionString = _connectioString;
            model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            model.GeneralItemMasterDTO.UnitName = (!string.IsNullOrEmpty(UnitName) ? UnitName : null);
            model.GeneralItemMasterDTO.GeneralItemMasterID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null);
            model.GeneralItemMasterDTO.GeneralUnitsID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralUnitsID) ? GeneralUnitsID : null);
            model.GeneralItemMasterDTO.GeneralVendorID = Convert.ToInt16(!string.IsNullOrEmpty(GeneralVendorID) ? GeneralVendorID : null);
            model.GeneralItemMasterDTO.ItemCategoryCode_Param = ItemCategoryCode_Param;
            //**************************************************************************************************************//
            List<OrderingAndDeliveryDay> OrderingAndDeliveryDay = GetListForOrderingDayAndDelivaryDayCode();
            List<SelectListItem> OrderingAndDeliveryDayList = new List<SelectListItem>();
            foreach (OrderingAndDeliveryDay item in OrderingAndDeliveryDay)
            {
                OrderingAndDeliveryDayList.Add(new SelectListItem { Text = item.OrderingDay, Value = Convert.ToString(item.code) });
            }
            ViewBag.OrderingAndDeliveryDay = new SelectList(OrderingAndDeliveryDayList, "Value", "Text");
            //*****************************************************************************************************************//


            if (model.GeneralItemMasterDTO.GeneralItemMasterID > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.SelectOneInventoryStoreSpecificInformation(model.GeneralItemMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMasterDTO.InventoryItemCodeCentreLevelSpecificInfoID = response.Entity.InventoryItemCodeCentreLevelSpecificInfoID;
                    model.GeneralItemMasterDTO.GeneralItemMasterID = response.Entity.GeneralItemMasterID;
                    model.GeneralItemMasterDTO.GeneralUnitsID = response.Entity.GeneralUnitsID;
                    model.GeneralItemMasterDTO.RPType = response.Entity.RPType;
                    model.GeneralItemMasterDTO.MaxStock = response.Entity.MaxStock;
                    model.GeneralItemMasterDTO.RoundingProfile = response.Entity.RoundingProfile;
                    model.GeneralItemMasterDTO.ReorderPoint = response.Entity.ReorderPoint;
                    model.GeneralItemMasterDTO.SafetyStockDriven = response.Entity.SafetyStockDriven;
                    model.GeneralItemMasterDTO.PlannerCode = response.Entity.PlannerCode;
                    model.GeneralItemMasterDTO.OrderingDay = response.Entity.OrderingDay;
                    model.GeneralItemMasterDTO.LeadTimeForStore = response.Entity.LeadTimeForStore;
                    model.GeneralItemMasterDTO.leadTimeUom = response.Entity.leadTimeUom;
                    model.GeneralItemMasterDTO.DeliveryDay = response.Entity.DeliveryDay;
                    model.GeneralItemMasterDTO.SupplySource = response.Entity.SupplySource;
                    model.GeneralItemMasterDTO.BlockforProcurutment = response.Entity.BlockforProcurutment;
                    model.GeneralItemMasterDTO.GRProccessingTime = response.Entity.GRProccessingTime;
                    model.GeneralItemMasterDTO.GRPUomCode = response.Entity.GRPUomCode;

                    model.GeneralItemMasterDTO.Facing = response.Entity.Facing;
                    model.GeneralItemMasterDTO.ShelfNumber = response.Entity.ShelfNumber;
                    model.GeneralItemMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }

                List<SelectListItem> SupplySourceCode = new List<SelectListItem>();
                ViewBag.SupplySourceCode = new SelectList(SupplySourceCode, "Value", "Text");
                List<SelectListItem> li_SupplySourceCode = new List<SelectListItem>();

                if (model.GeneralItemMasterDTO.SupplySource == "External Vendor" || model.GeneralItemMasterDTO.SupplySource == "Internal Source")
                {
                    li_SupplySourceCode.Add(new SelectListItem { Text = "External Vendor", Value = "External Vendor" });
                    li_SupplySourceCode.Add(new SelectListItem { Text = "Internal Source", Value = "Internal Source" });

                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["SupplySourceCode"] = new SelectList(li_SupplySourceCode, "Value", "Text", (model.GeneralItemMasterDTO.SupplySource).ToString().Trim());
                }
                else
                {

                    li_SupplySourceCode.Add(new SelectListItem { Text = "External Vendor", Value = "External Vendor" });
                    li_SupplySourceCode.Add(new SelectListItem { Text = "Internal Source", Value = "Internal Source" });

                    ViewData["SupplySourceCode"] = li_SupplySourceCode;
                }
                //*************************RP type***************************************************

                List<SelectListItem> RPType = new List<SelectListItem>();
                ViewBag.RPType = new SelectList(RPType, "Value", "Text");
                List<SelectListItem> li_RPType = new List<SelectListItem>();

                if (model.GeneralItemMasterDTO.RPType > 0)
                {
                    li_RPType.Add(new SelectListItem { Text = "Reorder Point", Value = "1" });
                    li_RPType.Add(new SelectListItem { Text = "Safety Stock Driven", Value = "2" });

                    //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                    ViewData["RPType"] = new SelectList(li_RPType, "Value", "Text", (model.GeneralItemMasterDTO.RPType).ToString().Trim());
                }
                else
                {

                    li_RPType.Add(new SelectListItem { Text = "Reorder Point", Value = "1" });
                    li_RPType.Add(new SelectListItem { Text = "Safety Stock Driven", Value = "2" });

                    ViewData["RPType"] = li_RPType;
                }

            }
            if (model.GeneralItemMasterDTO.LeadTimeForStore == 0)
            {
                return PartialView("/Views/Inventory/GeneralItemMaster/ErrorMessage.cshtml", model);
            }
            else
            {
                return PartialView("/Views/Inventory/GeneralItemMaster/CreateStoreSpecificInformation.cshtml", model);
            }



        }
        [HttpPost]
        public ActionResult CreateStoreSpecificInformation(GeneralItemMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMasterDTO != null)
                {
                    model.GeneralItemMasterDTO.ConnectionString = _connectioString;

                    model.GeneralItemMasterDTO.InventoryItemCodeCentreLevelSpecificInfoID = model.InventoryItemCodeCentreLevelSpecificInfoID;
                    model.GeneralItemMasterDTO.UnitName = model.UnitName;
                    model.GeneralItemMasterDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.GeneralItemMasterDTO.GeneralItemMasterID = model.GeneralItemMasterID;
                    model.GeneralItemMasterDTO.RPType = model.RPType;
                    model.GeneralItemMasterDTO.MaxStock = model.MaxStock;
                    model.GeneralItemMasterDTO.RoundingProfile = model.RoundingProfile;
                    model.GeneralItemMasterDTO.PlannerCode = model.PlannerCode;
                    model.GeneralItemMasterDTO.OrderingDay = model.OrderingDay;
                    model.GeneralItemMasterDTO.DeliveryDay = model.DeliveryDay;
                    model.GeneralItemMasterDTO.LeadTimeForStore = model.LeadTimeForStore;
                    model.GeneralItemMasterDTO.GRProccessingTime = model.GRProccessingTime;
                    model.GeneralItemMasterDTO.RoundingProfile = model.RoundingProfile;
                    model.GeneralItemMasterDTO.SupplySource = model.SupplySource;
                    model.GeneralItemMasterDTO.BlockforProcurutment = model.BlockforProcurutment;
                    model.GeneralItemMasterDTO.ReorderPoint = model.ReorderPoint;
                    model.GeneralItemMasterDTO.SafetyStockDriven = model.SafetyStockDriven;
                    model.GeneralItemMasterDTO.Facing = model.Facing;
                    model.GeneralItemMasterDTO.ShelfNumber = model.ShelfNumber;


                    model.GeneralItemMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.InsertInventoryStoreSpecificInformation(model.GeneralItemMasterDTO);

                    model.GeneralItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(GeneralItemMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemMasterDTO != null)
                {
                    if (model != null && model.GeneralItemMasterDTO != null)
                    {
                        model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                        //model.GeneralItemMasterDTO.GroupDescription = model.GroupDescription;
                        // model.GeneralItemMasterDTO.SeqNo = model.SeqNo;
                        // model.GeneralItemMasterDTO.MarchandiseGroupCode = model.MarchandiseGroupCode;
                        //model.GeneralItemMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralItemMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.UpdateGeneralItemMaster(model.GeneralItemMasterDTO);
                        model.GeneralItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }

        }

        public ActionResult EditVarient(Int16 id)
        {
            try
            {
                GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
                model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                model.GeneralItemMasterDTO.ID = id;
                model.GeneralItemMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.UpdateGeneralItemMaster(model.GeneralItemMasterDTO);
                model.GeneralItemMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.GeneralItemMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }
        public ActionResult GetGeneralItemSupliersDataByItemNumberandVendorID(string ItemNumber, string GeneralVendorID)
        {

            var UOMCodeDesc = GetGeneralItemSupliersDataByItemNumberandVendorIDLiSt(ItemNumber, GeneralVendorID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              LastPurchasePrice = s.LastPurchasePrice,
                              GeneralItemSupliersDataID = s.GeneralItemSupliersDataID,
                              ManufacturCatalogNumber = s.ManufacturCatalogNumber,
                              GenTaxGroupMasterID = s.GenTaxGroupMasterID,
                              GeneralVendorID = s.GeneralVendorID,
                              VendorName = s.VendorName,
                              PurchaseUoMCode = s.PurchaseUoMCode,
                              GeneralPurchaseGroupMasterID = s.GeneralPurchaseGroupMasterID,
                              PurchaseOrganization = s.PurchaseOrganization,
                              MinimumOrderquantity = s.MinimumOrderquantity,
                              CountryOfOrigin = s.CountryOfOrigin,
                              LeadTime = s.LeadTime,
                              HSCode = s.HSCode,
                              ShelfLife = s.ShelfLife,
                              CurrencyCode = s.CurrencyCode,
                              ManufacturerName = s.ManufacturerName,
                              VendorNumber = s.VendorNumber,
                              RemainingShelfLife = s.RemainingShelfLife,
                              IsDefaultVendor = s.IsDefaultVendor

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumberandVendorIDLiSt(string ItemNumber, string GeneralVendorID)
        {

            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);
            searchRequest.GeneralVendorID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralVendorID) ? GeneralVendorID : null);

            List<GeneralItemMaster> listOrganisationDepartmentMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemSupliersDataByItemNumberandVendorID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        public ActionResult Delete(int ItemNumber)
        {
            var errorMessage = string.Empty;
            if (ItemNumber > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = null;
                GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
                model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                model.GeneralItemMasterDTO.ItemNumber = Convert.ToInt32(ItemNumber);
                model.GeneralItemMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMasterBA.DeleteGeneralItemMaster(model.GeneralItemMasterDTO);
                string errorMessageDis = string.Empty;
                string colorCode = string.Empty;
                string mode = string.Empty;
                if (response.Entity.ErrorCode == 77)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "danger";
                }
                else if (response.Entity.ErrorCode == 0)
                {
                    errorMessageDis = response.Entity.errorMessage;
                    colorCode = "success";
                }
                string[] arrayList = { errorMessageDis, colorCode, mode };
                errorMessage = string.Join(",", arrayList);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        //-------------------EComDelete---------------
        public ActionResult DeleteEComImage(int ID, string ImageName)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralItemMaster> response = null;
                GeneralItemMaster GeneralItemMasterDTO = new GeneralItemMaster();
                GeneralItemMasterDTO.ConnectionString = _connectioString;
                GeneralItemMasterDTO.ID = Convert.ToInt32(ID);
                GeneralItemMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemMasterBA.DeleteGeneralItemMasterEComImages(GeneralItemMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }
            string filePath = Path.Combine(Server.MapPath("~") + "\\Content\\UploadedFiles\\ArticleImage\\", ImageName);
            FileInfo file = new FileInfo(filePath);
            if (Directory.Exists(filePath) || file.Exists)
            {
                System.IO.File.Delete(filePath);

            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UploadExcel(GeneralItemMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemMasterDTO != null)
                {
                    UploadExcelFile();
                    model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                    model.GeneralItemMasterDTO.ID = model.ID;
                    model.GeneralItemMasterDTO.XMLstring = xmlParameter;
                    model.GeneralItemMasterDTO.UomDetailsParameterXML1 = UomDetailsParameterXML1;
                    model.GeneralItemMasterDTO.UomDetailsParameterXML2 = UomDetailsParameterXML2;
                    model.GeneralItemMasterDTO.UomDetailsParameterXML3 = UomDetailsParameterXML3;
                    model.GeneralItemMasterDTO.UomDetailsParameterXML4 = UomDetailsParameterXML4;
                    model.GeneralItemMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.InsertGeneralitemMasterExcel(model.GeneralItemMasterDTO);
                        string errorMessageDis = string.Empty;
                        string colorCode = string.Empty;
                        string mode = string.Empty;
                        if (response.Entity.ErrorCode == 18)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 19)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 77)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 0)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "success";
                        }
                        string[] arrayList = { errorMessageDis, colorCode, mode };
                        errorMessage = string.Join(",", arrayList);
                        model.GeneralItemMasterDTO.errorMessage = errorMessage;

                    }
                    else if (IsExcelValid == false)
                    {
                        model.GeneralItemMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.GeneralItemMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.GeneralItemMasterDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "GeneralItemMaster");
                    //return Json(model.VendorMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception ex)
            {
                //_logException.Error(ex.Message);
                //throw;
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "GeneralItemMaster");
            }

        }
        public void UploadExcelFile()
        {
            string _ExcelFileXML = string.Empty;
            //   string XMLstring = string.Empty;
            var _comPath = "";
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var ExcelFile = System.Web.HttpContext.Current.Request.Files["ExcelFile"];
                if (ExcelFile.ContentLength > 0)
                {
                    string extension = System.IO.Path.GetExtension(ExcelFile.FileName);
                    if (extension == ".xlsx")
                    {

                        _comPath = Server.MapPath("~") + "Content\\UploadedFiles\\UplodedExcel\\";
                        var myUniqueFileName = Guid.NewGuid();
                        string filePath = String.Concat(myUniqueFileName, ExcelFile.FileName);
                        filePath = string.Format("{0}{1}", _comPath, filePath);

                        if (!Directory.Exists(_comPath))
                        {
                            Directory.CreateDirectory(_comPath);
                        }
                        if (System.IO.File.Exists(filePath))
                            System.IO.File.Delete(filePath);

                        ExcelFile.SaveAs(filePath);

                        OpenXmlValidator validator = new OpenXmlValidator();

                        int count = 0;

                        foreach (ValidationErrorInfo error in validator.Validate(SpreadsheetDocument.Open(filePath, false)))
                        {
                            count++;
                        }

                        if (count <= 0)
                        {

                            xmlParameter = "<rows>";
                            UomDetailsParameterXML1 = "<rows>";
                            UomDetailsParameterXML2 = "<rows>";
                            UomDetailsParameterXML3 = "<rows>";
                            UomDetailsParameterXML4 = "<rows>";

                            //Open the Excel file in Read Mode using OpenXml.
                            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, false))
                            {
                                //Read the first Sheet from Excel file.
                                Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                                //Get the Worksheet instance.
                                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;

                                //Fetch all the rows present in the Worksheet.
                                // IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                                SheetData rows = worksheet.GetFirstChild<SheetData>();

                                DataTable dt = new DataTable();
                                //Loop through the Worksheet rows.
                                foreach (Cell cell in rows.ElementAt(1))
                                {
                                    if (
                                 (GetCellValue(doc, cell)) == "* Vendor Number ( as per Vendor Master)" ||
                                 (GetCellValue(doc, cell)) == "Brand" ||
                                 (GetCellValue(doc, cell)) == "Vendor Product Code" ||
                                 (GetCellValue(doc, cell)) == "* Product description" ||
                                 (GetCellValue(doc, cell)) == "ArabicTranslation as per the Till Description (Vendor to input)" ||
                                 (GetCellValue(doc, cell)) == "Special Product Feature" ||
                                 (GetCellValue(doc, cell)) == "HS Code" ||
                                 (GetCellValue(doc, cell)) == "Country of Origin" ||
                                 (GetCellValue(doc, cell)) == "Manufacturer Name" ||
                                 (GetCellValue(doc, cell)) == "* Item Category Code" ||
                                 (GetCellValue(doc, cell)) == "* Tax Group" ||
                                 (GetCellValue(doc, cell)) == "* Temperature for Display in Store" ||
                                 (GetCellValue(doc, cell)) == "Total Shelf Life" ||
                                 (GetCellValue(doc, cell)) == "Remaining Shelf Life at the time of delivery" ||
                                 //(GetCellValue(doc, cell)) == "Delivery Lead-time (days)" ||
                                 (GetCellValue(doc, cell)) == "* Minimum Order Quantity (in order units)" ||
                                 (GetCellValue(doc, cell)) == "* Cost per Order Unit" ||
                                 (GetCellValue(doc, cell)) == "* Purchase Group" ||
                                 (GetCellValue(doc, cell)) == "Gross Weight per piece (g)" ||
                                 (GetCellValue(doc, cell)) == "Net Contents per piece" ||
                                 (GetCellValue(doc, cell)) == "Net Contents unit of measure" ||
                                 (GetCellValue(doc, cell)) == "Base Unit" ||
                                 (GetCellValue(doc, cell)) == "Pack Size" ||
                                 (GetCellValue(doc, cell)) == "Lower Unit of Measure" ||
                                 (GetCellValue(doc, cell)) == "Barcode" ||
                                 (GetCellValue(doc, cell)) == "Length (cm)" ||
                                 (GetCellValue(doc, cell)) == "Width (cm)" ||
                                 (GetCellValue(doc, cell)) == "Height (cm)" ||
                                 (GetCellValue(doc, cell)) == "Alternate Selling Unit" ||
                                 (GetCellValue(doc, cell)) == "Pack Size 1" ||
                                 (GetCellValue(doc, cell)) == "Lower Unit of Measure 1" ||
                                 (GetCellValue(doc, cell)) == "Barcode 1" ||
                                 (GetCellValue(doc, cell)) == "Length 1 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Width 1 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Height 1 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Order Unit" ||
                                 (GetCellValue(doc, cell)) == "Pack Size 2" ||
                                 (GetCellValue(doc, cell)) == "Lower Unit of Measure 2" ||
                                 (GetCellValue(doc, cell)) == "Barcode 2" ||
                                 (GetCellValue(doc, cell)) == "Length 2 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Width 2 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Height 2 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Consumption Unit" ||
                                 (GetCellValue(doc, cell)) == "Pack Size 3" ||
                                 (GetCellValue(doc, cell)) == "Lower Unit of Measure 3" ||
                                 (GetCellValue(doc, cell)) == "Barcode 3" ||
                                 (GetCellValue(doc, cell)) == "Length 3 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Width 3 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Height 3 (cm)" ||
                                 (GetCellValue(doc, cell)) == "Suggested Selling Price For Spinneys" ||
                                 (GetCellValue(doc, cell)) == "Product present in market?" ||
                                 (GetCellValue(doc, cell)) == "Retailer 1 Name" ||
                                 (GetCellValue(doc, cell)) == "RSP 1" ||
                                 (GetCellValue(doc, cell)) == "Retailer 2 Name" ||
                                 (GetCellValue(doc, cell)) == "RSP 2" ||
                                 (GetCellValue(doc, cell)) == "Promotion Plan" ||
                                 (GetCellValue(doc, cell)) == "Target Sales 1st Month in Store")
                                    {
                                        dt.Columns.Add(GetCellValue(doc, cell));
                                    }
                                    else
                                    {
                                        IsExcelValid = false;
                                        errorMessage = "Invalid excel column,warning";


                                    }

                                }
                                if (dt.Columns.Count > 0)
                                {
                                    if ((IsExcelValid == true))
                                    {

                                        //foreach (Cell cell in rows.ElementAt(1))
                                        //{
                                        //    dt.Columns.Add(GetCellValue(doc, cell));
                                        //}
                                        foreach (Row row in rows)
                                        {
                                            DataRow tempRow = dt.NewRow();
                                            int columnIndex = 0;
                                            foreach (Cell cell in row.Descendants<Cell>())
                                            {
                                                // Gets the column index of the cell with data

                                                int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));

                                                cellColumnIndex--; //zero based index
                                                if (columnIndex < cellColumnIndex)
                                                {
                                                    do
                                                    {
                                                        tempRow[columnIndex] = ""; //Insert blank data here;
                                                        columnIndex++;
                                                    }
                                                    while (columnIndex < cellColumnIndex);
                                                }
                                                tempRow[columnIndex] = GetCellValue(doc, cell);

                                                columnIndex++;
                                            }
                                            dt.Rows.Add(tempRow);
                                        }
                                        dt.Rows.RemoveAt(1); //...so i'm taking it out here.

                                        RemoveDuplicateRows(dt, "* Vendor Number ( as per Vendor Master)");

                                        if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            if (
                                            dt.Columns[0].ColumnName != "* Vendor Number ( as per Vendor Master)" ||
                                            dt.Columns[1].ColumnName != "Brand" ||
                                            dt.Columns[2].ColumnName != "Vendor Product Code" ||
                                            dt.Columns[3].ColumnName != "* Product description" ||
                                            dt.Columns[4].ColumnName != "ArabicTranslation as per the Till Description (Vendor to input)" ||
                                            dt.Columns[5].ColumnName != "Special Product Feature" ||
                                            dt.Columns[6].ColumnName != "HS Code" ||
                                            dt.Columns[7].ColumnName != "Country of Origin" ||
                                            dt.Columns[8].ColumnName != "Manufacturer Name" ||
                                            dt.Columns[9].ColumnName != "* Item Category Code" ||
                                            dt.Columns[10].ColumnName != "* Tax Group" ||
                                            dt.Columns[11].ColumnName != "* Temperature for Display in Store" ||
                                            dt.Columns[12].ColumnName != "Total Shelf Life" ||
                                            dt.Columns[13].ColumnName != "Remaining Shelf Life at the time of delivery" ||
                                            //dt.Columns[12].ColumnName != "Delivery Lead-time (days)" ||
                                            dt.Columns[14].ColumnName != "* Minimum Order Quantity (in order units)" ||
                                            dt.Columns[15].ColumnName != "* Cost per Order Unit" ||
                                            dt.Columns[16].ColumnName != "* Purchase Group" ||
                                            dt.Columns[17].ColumnName != "Gross Weight per piece (g)" ||
                                            dt.Columns[18].ColumnName != "Net Contents per piece" ||
                                            dt.Columns[19].ColumnName != "Net Contents unit of measure" ||
                                            dt.Columns[20].ColumnName != "Base Unit" ||
                                            dt.Columns[21].ColumnName != "Pack Size" ||
                                            dt.Columns[22].ColumnName != "Lower Unit of Measure" ||
                                            dt.Columns[23].ColumnName != "Barcode" ||
                                            dt.Columns[24].ColumnName != "Length (cm)" ||
                                            dt.Columns[25].ColumnName != "Width (cm)" ||
                                            dt.Columns[26].ColumnName != "Height (cm)" ||
                                            dt.Columns[27].ColumnName != "Alternate Selling Unit" ||
                                            dt.Columns[28].ColumnName != "Pack Size 1" ||
                                            dt.Columns[29].ColumnName != "Lower Unit of Measure 1" ||
                                            dt.Columns[30].ColumnName != "Barcode 1" ||
                                            dt.Columns[31].ColumnName != "Length 1 (cm)" ||
                                            dt.Columns[32].ColumnName != "Width 1 (cm)" ||
                                            dt.Columns[33].ColumnName != "Height 1 (cm)" ||
                                            dt.Columns[34].ColumnName != "Order Unit" ||
                                            dt.Columns[35].ColumnName != "Pack Size 2" ||
                                            dt.Columns[36].ColumnName != "Lower Unit of Measure 2" ||
                                            dt.Columns[37].ColumnName != "Barcode 2" ||
                                            dt.Columns[38].ColumnName != "Length 2 (cm)" ||
                                            dt.Columns[39].ColumnName != "Width 2 (cm)" ||
                                            dt.Columns[40].ColumnName != "Height 2 (cm)" ||

                                            dt.Columns[41].ColumnName != "Consumption Unit" ||
                                            dt.Columns[42].ColumnName != "Pack Size 3" ||
                                            dt.Columns[43].ColumnName != "Lower Unit of Measure 3" ||
                                            dt.Columns[44].ColumnName != "Barcode 3" ||
                                            dt.Columns[45].ColumnName != "Length 3 (cm)" ||
                                            dt.Columns[46].ColumnName != "Width 3 (cm)" ||
                                            dt.Columns[47].ColumnName != "Height 3 (cm)" ||

                                            dt.Columns[48].ColumnName != "Suggested Selling Price For Spinneys" ||
                                            dt.Columns[49].ColumnName != "Product present in market?" ||
                                            dt.Columns[50].ColumnName != "Retailer 1 Name" ||
                                            dt.Columns[51].ColumnName != "RSP 1" ||
                                            dt.Columns[52].ColumnName != "Retailer 2 Name" ||
                                            dt.Columns[53].ColumnName != "RSP 2" ||
                                            dt.Columns[54].ColumnName != "Promotion Plan" ||
                                            dt.Columns[55].ColumnName != "Target Sales 1st Month in Store")

                                            {
                                                IsExcelValid = false;
                                                errorMessage = "Invalid excel column,warning";
                                            }
                                        }
                                        if (IsExcelValid == true)
                                        {
                                            long result;
                                            //while (dReader.Read())
                                            for (int i = 1; i < (dt.Rows.Count); i++)
                                            {


                                                if (dt.Rows[i]["* Product description"].ToString().Length > 1)
                                                {
                                                    string partnumber = dt.Rows[i]["* Product description"].ToString();
                                                    Regex rgx = new Regex(@"^[a-zA-Z0-9_&',%./\-+() ]+$");
                                                    var CheckItemDescriptionForAlphanumeric = (rgx.IsMatch(partnumber) ? "isAlphanumeric" : "isnotAlphanumeric");
                                                    if (CheckItemDescriptionForAlphanumeric == "isAlphanumeric")
                                                    {
                                                        if (dt.Rows[i]["* Vendor Number ( as per Vendor Master)"].ToString().Trim().Length > 0
                                                            && dt.Rows[i]["* Product description"].ToString().Trim().Length > 0
                                                            && dt.Rows[i]["* Item Category Code"].ToString().Trim().Length > 0
                                                            && dt.Rows[i]["* Tax Group"].ToString().Trim().Length > 0
                                                            //&& dt.Rows[i]["* Temperature for Display in Store"].ToString().Trim().Length > 0
                                                            && dt.Rows[i]["* Minimum Order Quantity (in order units)"].ToString().Trim().Length > 0
                                                            && dt.Rows[i]["* Cost per Order Unit"].ToString().Length > 0
                                                            && dt.Rows[i]["* Purchase Group"].ToString().Trim().Length > 1
                                                            )
                                                        {
                                                            xmlParameter = xmlParameter + "<row><VendorName>" + dt.Rows[i]["* Vendor Number ( as per Vendor Master)"].ToString().Trim() + "</VendorName><Brand>" + dt.Rows[i]["Brand"].ToString().Trim().Replace("&", "[and]") + "</Brand><VendorProductCode>" + dt.Rows[i]["Vendor Product Code"].ToString().Trim() + "</VendorProductCode><vendorProductDescription>" + dt.Rows[i]["* Product description"].ToString().Trim().Replace("&", "[and]") + "</vendorProductDescription><ArabicTranslationasperDescription>" + dt.Rows[i]["ArabicTranslation as per the Till Description (Vendor to input)"].ToString().Trim() + "</ArabicTranslationasperDescription><SpecialProductFeature>" + dt.Rows[i]["Special Product Feature"].ToString().Trim() + "</SpecialProductFeature><HSCode>" + dt.Rows[i]["HS Code"].ToString().Trim() + "</HSCode><CountryofOrigin>" + dt.Rows[i]["Country of Origin"].ToString().Trim() + "</CountryofOrigin><ManufacturerName>" + dt.Rows[i]["Manufacturer Name"].ToString().Trim() + "</ManufacturerName><ItemCategoryCode>" + dt.Rows[i]["* Item Category Code"].ToString().Trim() + "</ItemCategoryCode><TaxGroup>" + dt.Rows[i]["* Tax Group"].ToString().Trim() + "</TaxGroup><Temperature>" + dt.Rows[i]["* Temperature for Display in Store"].ToString().Trim() + "</Temperature><TotalShelfLife>" + dt.Rows[i]["Total Shelf Life"].ToString().Trim() + "</TotalShelfLife><RemainingShelfLife>" + dt.Rows[i]["Remaining Shelf Life at the time of delivery"].ToString().Trim() + "</RemainingShelfLife><DeliveryLeadtime>" + 0 + "</DeliveryLeadtime><MinimumOrderQuantity>" + dt.Rows[i]["* Minimum Order Quantity (in order units)"].ToString().Trim() + "</MinimumOrderQuantity><CostperOrderUnit>" + dt.Rows[i]["* Cost per Order Unit"].ToString().Trim() + "</CostperOrderUnit><PurchaseGroup>" + dt.Rows[i]["* Purchase Group"].ToString().Trim() + "</PurchaseGroup><GrossWeightPerPiece>" + dt.Rows[i]["Gross Weight per piece (g)"].ToString().Trim() + "</GrossWeightPerPiece><NetContentsperpiece>" + dt.Rows[i]["Net Contents per piece"].ToString().Trim() + "</NetContentsperpiece><NetContentsUOM>" + dt.Rows[i]["Net Contents unit of measure"].ToString().Trim() + "</NetContentsUOM><GeneralItemMasterID>0</GeneralItemMasterID><GeneralItemSupliersDataID>" + 0 + "</GeneralItemSupliersDataID><GeneralItemGeneralDataID>" + 0 + "</GeneralItemGeneralDataID><ItemNumber>0</ItemNumber><GeneralVendorID>" + 0 + "</GeneralVendorID><VendorNumber>" + dt.Rows[i]["* Vendor Number ( as per Vendor Master)"].ToString().Trim() + "</VendorNumber><CountryID>" + 0 + "</CountryID></row>";
                                                            if ((dt.Rows[i]["Base Unit"].ToString().Trim().Length > 1) && (dt.Rows[i]["Pack Size"].ToString().Trim().Length > 0) && (dt.Rows[i]["Lower Unit of Measure"].ToString().Trim().Length > 1))
                                                            {
                                                                UomDetailsParameterXML1 = UomDetailsParameterXML1 + "<row><BaseUnit>" + dt.Rows[i]["Base Unit"].ToString().Trim() + "</BaseUnit><PackSize>" + dt.Rows[i]["Pack Size"].ToString().Trim() + "</PackSize><LowerUnitofMeasure>" + dt.Rows[i]["Lower Unit of Measure"].ToString().Trim() + "</LowerUnitofMeasure><Barcode>" + dt.Rows[i]["Barcode"].ToString().Trim() + "</Barcode><Length>" + dt.Rows[i]["Length (cm)"].ToString().Trim() + "</Length><Width>" + dt.Rows[i]["Width (cm)"].ToString().Trim() + "</Width><Height>" + dt.Rows[i]["Height (cm)"].ToString().Trim() + "</Height><GeneralItemMasterID>0</GeneralItemMasterID><ItemNumber>0</ItemNumber><vendorProductDescription>" + dt.Rows[i]["* Product description"].ToString().Trim().Replace("&", "[and]") + "</vendorProductDescription></row>";
                                                            }
                                                            if ((dt.Rows[i]["Alternate Selling Unit"].ToString().Trim().Length > 1) && (dt.Rows[i]["Pack Size 1"].ToString().Trim().Length > 0) && (dt.Rows[i]["Lower Unit of Measure 1"].ToString().Trim().Length > 1))
                                                            {
                                                                if (dt.Rows[i]["Barcode 1"].ToString().Trim().Length > 8)
                                                                {
                                                                    UomDetailsParameterXML2 = UomDetailsParameterXML2 + "<row><AlternateSellingUnit>" + dt.Rows[i]["Alternate Selling Unit"].ToString().Trim() + "</AlternateSellingUnit><PackSize>" + dt.Rows[i]["Pack Size 1"].ToString().Trim() + "</PackSize><LowerUnitofMeasure>" + dt.Rows[i]["Lower Unit of Measure 1"].ToString().Trim() + "</LowerUnitofMeasure><Barcode>" + dt.Rows[i]["Barcode 1"].ToString().Trim() + "</Barcode><Length>" + dt.Rows[i]["Length 1 (cm)"].ToString().Trim() + "</Length><Width>" + dt.Rows[i]["Width 1 (cm)"].ToString().Trim() + "</Width><Height>" + dt.Rows[i]["Height 1 (cm)"].ToString().Trim() + "</Height><GeneralItemMasterID>0</GeneralItemMasterID><ItemNumber>0</ItemNumber><vendorProductDescription>" + dt.Rows[i]["* Product description"].ToString().Trim().Replace("&", "[and]") + "</vendorProductDescription></row>";
                                                                }
                                                                else
                                                                {
                                                                    errorMessage = "Please Enter Barcode As it is the sale UOM,warning";
                                                                    BarcodeCount = 0;
                                                                    break;
                                                                }
                                                            }
                                                            //else
                                                            //{
                                                            //    UomDetailsParameterXML2 = UomDetailsParameterXML2 + "<row><AlternateSellingUnit>" + dt.Rows[i]["Alternate Selling Unit"].ToString().Trim() + "</AlternateSellingUnit><PackSize>" + dt.Rows[i]["Pack Size 1"].ToString().Trim() + "</PackSize><LowerUnitofMeasure>" + dt.Rows[i]["Lower Unit of Measure 1"].ToString().Trim() + "</LowerUnitofMeasure><Barcode>" + dt.Rows[i]["Barcode 1"].ToString().Trim() + "</Barcode><Length>" + dt.Rows[i]["Length 1 (cm)"].ToString().Trim() + "</Length><Width>" + dt.Rows[i]["Width 1 (cm)"].ToString().Trim() + "</Width><Height>" + dt.Rows[i]["Height 1 (cm)"].ToString().Trim() + "</Height><GeneralItemMasterID>0</GeneralItemMasterID><ItemNumber>0</ItemNumber><vendorProductDescription>" + dt.Rows[i]["Product description"].ToString().Trim() + "</vendorProductDescription></row>";
                                                            //}

                                                            if ((dt.Rows[i]["Order Unit"].ToString().Trim().Length > 1) && (dt.Rows[i]["Pack Size 2"].ToString().Trim().Length > 0) && (dt.Rows[i]["Lower Unit of Measure 2"].ToString().Trim().Length > 1))
                                                            {
                                                                UomDetailsParameterXML3 = UomDetailsParameterXML3 + "<row><OrderUnit>" + dt.Rows[i]["Order Unit"].ToString().Trim() + "</OrderUnit><PackSize>" + dt.Rows[i]["Pack Size 2"].ToString().Trim() + "</PackSize><LowerUnitofMeasure>" + dt.Rows[i]["Lower Unit of Measure 2"].ToString().Trim() + "</LowerUnitofMeasure><Barcode>" + dt.Rows[i]["Barcode 2"].ToString().Trim() + "</Barcode><Length>" + dt.Rows[i]["Length 2 (cm)"].ToString().Trim() + "</Length><Width>" + dt.Rows[i]["Width 2 (cm)"].ToString().Trim() + "</Width><Height>" + dt.Rows[i]["Height 2 (cm)"].ToString().Trim() + "</Height><GeneralItemMasterID>0</GeneralItemMasterID><ItemNumber>0</ItemNumber><vendorProductDescription>" + dt.Rows[i]["* Product description"].ToString().Trim().Replace("&", "[and]") + "</vendorProductDescription></row>";
                                                            }

                                                            if ((dt.Rows[i]["Consumption Unit"].ToString().Trim().Length > 1) && (dt.Rows[i]["Pack Size 3"].ToString().Trim().Length > 0) && (dt.Rows[i]["Lower Unit of Measure 3"].ToString().Trim().Length > 1))
                                                            {
                                                                UomDetailsParameterXML4 = UomDetailsParameterXML4 + "<row><ConsumptionUnit>" + dt.Rows[i]["Consumption Unit"].ToString().Trim() + "</ConsumptionUnit><PackSize>" + dt.Rows[i]["Pack Size 3"].ToString().Trim() + "</PackSize><LowerUnitofMeasure>" + dt.Rows[i]["Lower Unit of Measure 3"].ToString().Trim() + "</LowerUnitofMeasure><Barcode>" + dt.Rows[i]["Barcode 3"].ToString().Trim() + "</Barcode><Length>" + dt.Rows[i]["Length 3 (cm)"].ToString().Trim() + "</Length><Width>" + dt.Rows[i]["Width 3 (cm)"].ToString().Trim() + "</Width><Height>" + dt.Rows[i]["Height 3 (cm)"].ToString().Trim() + "</Height><GeneralItemMasterID>0</GeneralItemMasterID><ItemNumber>0</ItemNumber><vendorProductDescription>" + dt.Rows[i]["* Product description"].ToString().Trim().Replace("&", "[and]") + "</vendorProductDescription></row>";
                                                            }
                                                            BarcodeCount = 1;



                                                        }
                                                        else
                                                        {
                                                            errorMessage = "Please enter Required Data ,warning";
                                                            VendorCount = 1;
                                                            BarcodeCount = 1;
                                                            break;
                                                        }
                                                    }

                                                    else
                                                    {
                                                        errorMessage = "Please enter alpha-numeric text for item description.,warning";
                                                        BarcodeCount = 1;
                                                        ItemalphanumericCount = 1;
                                                        break;
                                                    }
                                                    //}
                                                }
                                            }
                                            if (BarcodeCount == 1)
                                            {

                                                if (xmlParameter.Length > 9)
                                                {
                                                    xmlParameter = xmlParameter + "</rows>";
                                                    if (UomDetailsParameterXML1.Length > 9)
                                                    {
                                                        UomDetailsParameterXML1 = UomDetailsParameterXML1 + "</rows>";
                                                    }
                                                    else
                                                    {
                                                        UomDetailsParameterXML1 = null;
                                                    }

                                                    if (UomDetailsParameterXML2.Length > 9)
                                                    {
                                                        UomDetailsParameterXML2 = UomDetailsParameterXML2 + "</rows>";
                                                    }
                                                    else
                                                    {
                                                        UomDetailsParameterXML2 = null;
                                                    }
                                                    if (UomDetailsParameterXML3.Length > 9)
                                                    {
                                                        UomDetailsParameterXML3 = UomDetailsParameterXML3 + "</rows>";
                                                    }
                                                    else
                                                    {
                                                        UomDetailsParameterXML3 = null;
                                                    }
                                                    if (UomDetailsParameterXML4.Length > 9)
                                                    {
                                                        UomDetailsParameterXML4 = UomDetailsParameterXML4 + "</rows>";
                                                    }
                                                    else
                                                    {
                                                        UomDetailsParameterXML4 = null;
                                                    }


                                                }
                                                else if (ItemCount == 1)
                                                {
                                                    xmlParameter = string.Empty;
                                                    errorMessage = "Please enter Item Description,warning";
                                                }
                                                else if (VendorCount == 1)
                                                {
                                                    xmlParameter = string.Empty;
                                                    errorMessage = "Please enter Required Data,warning";
                                                }
                                                else if (ItemalphanumericCount == 1)
                                                {
                                                    xmlParameter = string.Empty;
                                                    errorMessage = "Please enter alpha-numeric text for item description.,warning";
                                                }

                                                else
                                                {
                                                    xmlParameter = string.Empty;
                                                    errorMessage = "No data found in excel,warning";
                                                }
                                            }
                                            else if (BarcodeCount == 0)
                                            {
                                                errorMessage = "Please Enter Barcode As it is the sale UOM,warning";
                                                IsExcelValid = false;
                                            }


                                        }
                                    }
                                }
                                else
                                {
                                    IsExcelValid = false;
                                    errorMessage = "The selected file does not appear to be an excel file,warning";
                                }
                                dt.Dispose();
                            }

                            // excelConnection.Close();

                            // SQL Server Connection String

                        }
                        else
                        {
                            IsExcelValid = false;
                            errorMessage = "Invalid excel file,warning";
                        }
                    }
                    else
                    {
                        IsExcelValid = false;
                        errorMessage = "Please Upload Downloaded File,warning";
                    }
                }
                else
                {
                    IsExcelValid = false;
                    errorMessage = "Excel file not selected,warning";
                }
            }

        }
        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }

        public static int? GetColumnIndexFromName(string columnName)
        {

            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            //Removing a list of duplicate items from datatable.
            foreach (DataRow dRow in duplicateList)
                //dTable.Rows.Remove(dRow);
                errorMessage = "Do not add same vendor name twice,#FFCC80";

            //Datatable which contains unique records will be return as output.

            return dTable;
        }

        //public FileResult Download()
        //{
        //    string FileName = "GeneralItemMasterExcelFile.xlsx";
        //    string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
        //    string contentType = "application/vnd.ms-excel";
        //    return File(filePath, contentType, FileName);
        //}

        public FileResult Download()
        {

            string FileName = "GeneralItemMasterExcelFile.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelDoc(filePath);
            InsertItemDataInExcel(filePath);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateExcelDoc(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Item Master" };

                MergeCells mergeCells = new MergeCells();
                mergeCells.Append(new MergeCell() { Reference = new StringValue("A1:T1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("U1:AV1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AW1:BD1") });

                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());

                GeneralItemMasterViewModel model = new GeneralItemMasterViewModel();
                model.GeneralItemMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.GetDataValidationListsForExcel(model.GeneralItemMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemMasterDTO.CountryList = response.Entity.CountryList;
                    model.GeneralItemMasterDTO.TemperatureList = response.Entity.TemperatureList;
                    model.GeneralItemMasterDTO.CurrencyList = response.Entity.CurrencyList;
                    model.GeneralItemMasterDTO.UnitList = response.Entity.UnitList;
                    model.GeneralItemMasterDTO.TaxGroupList = response.Entity.TaxGroupList;
                    model.GeneralItemMasterDTO.VendorNumberList = response.Entity.VendorNumberList;
                    model.GeneralItemMasterDTO.PurchaseGrouplist = response.Entity.PurchaseGrouplist;
                    model.GeneralItemMasterDTO.CategoryCodeList = response.Entity.CategoryCodeList;
                }

                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "H4:H100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.CountryList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };

                DataValidations dvs = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs != null)
                {
                    dvs.Count = dvs.Count + 1;
                    dvs.Append(dataValidation);
                }
                else
                {
                    DataValidations newDVs = new DataValidations();
                    newDVs.Append(dataValidation);
                    newDVs.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs);
                }

                DataValidation dataValidation1 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "L4:L100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.TemperatureList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs1 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs1.Count = dvs1.Count + 1;
                dvs1.Append(dataValidation1);

                DataValidation dataValidation2 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Q4:Q100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.PurchaseGrouplist, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs2 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs2.Count = dvs2.Count + 1;
                dvs2.Append(dataValidation2);

                DataValidation dataValidation3 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "U4:U100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.UnitList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs3.Count = dvs3.Count + 1;
                dvs3.Append(dataValidation3);

                DataValidation dataValidation4 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "W4:W100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.UnitList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs4 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs4.Count = dvs4.Count + 1;
                dvs4.Append(dataValidation4);

                DataValidation dataValidation5 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AB4:AB100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.UnitList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs5 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs5.Count = dvs5.Count + 1;
                dvs5.Append(dataValidation5);

                DataValidation dataValidation6 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AD4:AD100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.UnitList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs6 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs6.Count = dvs6.Count + 1;
                dvs6.Append(dataValidation6);

                DataValidation dataValidation7 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AI4:AI100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.UnitList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs7 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs7.Count = dvs7.Count + 1;
                dvs7.Append(dataValidation7);

                DataValidation dataValidation8 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AK4:AK100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.UnitList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs8 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs8.Count = dvs8.Count + 1;
                dvs8.Append(dataValidation8);


                DataValidation dataValidation9 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "V4:V100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs9 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs9.Count = dvs9.Count + 1;
                dvs9.Append(dataValidation9);

                DataValidation dataValidation10 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Y4:Y100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs10 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs10.Count = dvs10.Count + 1;
                dvs10.Append(dataValidation10);

                DataValidation dataValidation11 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Z4:Z100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs11 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs11.Count = dvs11.Count + 1;
                dvs11.Append(dataValidation11);

                DataValidation dataValidation12 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AA4:AA100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs12 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs12.Count = dvs12.Count + 1;
                dvs12.Append(dataValidation12);

                DataValidation dataValidation13 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AC4:AC100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs13 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs13.Count = dvs13.Count + 1;
                dvs13.Append(dataValidation13);

                DataValidation dataValidation14 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AF4:AF100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs14 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs14.Count = dvs14.Count + 1;
                dvs14.Append(dataValidation14);

                DataValidation dataValidation15 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AG4:AG100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs15 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs15.Count = dvs15.Count + 1;
                dvs15.Append(dataValidation15);

                DataValidation dataValidation16 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AI4:AI100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs16 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs16.Count = dvs16.Count + 1;
                dvs16.Append(dataValidation16);

                DataValidation dataValidation17 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AJ4:AJ100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs17 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs17.Count = dvs17.Count + 1;
                dvs17.Append(dataValidation17);

                DataValidation dataValidation18 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AM4:AM100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs18 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs18.Count = dvs18.Count + 1;
                dvs18.Append(dataValidation18);

                DataValidation dataValidation19 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AN4:AN100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs19 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs19.Count = dvs19.Count + 1;
                dvs19.Append(dataValidation19);

                DataValidation dataValidation20 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AO4:AO100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs20 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs20.Count = dvs20.Count + 1;
                dvs20.Append(dataValidation20);

                DataValidation dataValidation21 = new DataValidation
                {
                    Type = DataValidationValues.TextLength,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AE4:AE100" },
                    Formula1 = new Formula1("8"),
                    Formula2 = new Formula2("14"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please Enter Barcode greater then 8 less then 14")
                };
                DataValidations dvs21 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs21.Count = dvs21.Count + 1;
                dvs21.Append(dataValidation21);

                DataValidation dataValidation22 = new DataValidation
                {
                    Type = DataValidationValues.TextLength,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AL4:AL100" },
                    Formula1 = new Formula1("8"),
                    Formula2 = new Formula2("14"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please Enter Barcode greater then 8 less then 14")
                };
                DataValidations dvs22 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs22.Count = dvs22.Count + 1;
                dvs22.Append(dataValidation22);

                DataValidation dataValidation23 = new DataValidation
                {
                    Type = DataValidationValues.TextLength,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "X4:X100" },
                    Formula1 = new Formula1("8"),
                    Formula2 = new Formula2("14"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please Enter Barcode greater then 8 less then 14")
                };
                DataValidations dvs23 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs23.Count = dvs23.Count + 1;
                dvs23.Append(dataValidation23);

                DataValidation dataValidation24 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "K4:K100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.TaxGroupList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs24 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs24.Count = dvs24.Count + 1;
                dvs24.Append(dataValidation24);
                sheets.Append(sheet);

                DataValidation dataValidation25 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A4:A100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.VendorNumberList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs25 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs25.Count = dvs25.Count + 1;
                dvs25.Append(dataValidation25);

                DataValidation dataValidation26 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "J4:J100" },
                    Formula1 = new Formula1(string.Concat("\"", model.GeneralItemMasterDTO.CategoryCodeList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs26 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs26.Count = dvs26.Count + 1;
                dvs26.Append(dataValidation26);

                DataValidation dataValidation27 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AT4:AT100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs27 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs27.Count = dvs27.Count + 1;
                dvs27.Append(dataValidation27);

                DataValidation dataValidation28 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AU4:AU100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs28 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs28.Count = dvs28.Count + 1;
                dvs28.Append(dataValidation28);

                DataValidation dataValidation29 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "AV4:AV100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs29 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs29.Count = dvs29.Count + 1;
                dvs29.Append(dataValidation29);



                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertItemDataInExcel(string fileName)
        {
            string[] HeaderData = new string[] { "* Vendor Number ( as per Vendor Master)", "Brand", "Vendor Product Code", "* Product description", "ArabicTranslation as per the Till Description (Vendor to input)", "Special Product Feature", "HS Code", "Country of Origin", "Manufacturer Name", "* Item Category Code", "* Tax Group", "* Temperature for Display in Store", "Total Shelf Life", "Remaining Shelf Life at the time of delivery", "* Minimum Order Quantity (in order units)", "* Cost per Order Unit", "* Purchase Group", "Gross Weight per piece (g)", "Net Contents per piece", "Net Contents unit of measure", "Base Unit", "Pack Size", "Lower Unit of Measure", "Barcode", "Length (cm)", "Width (cm)", "Height (cm)", "Alternate Selling Unit", "Pack Size 1", "Lower Unit of Measure 1", "Barcode 1", "Length 1 (cm)", "Width 1 (cm)", "Height 1 (cm)", "Order Unit", "Pack Size 2", "Lower Unit of Measure 2", "Barcode 2", "Length 2 (cm)", "Width 2 (cm)", "Height 2 (cm)", "Consumption Unit", "Pack Size 3", "Lower Unit of Measure 3", "Barcode 3", "Length 3 (cm)", "Width 3 (cm)", "Height 3 (cm)", "Suggested Selling Price For Spinneys", "Product present in market?", "Retailer 1 Name", "RSP 1", "Retailer 2 Name", "RSP 2", "Promotion Plan", "Target Sales 1st Month in Store" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD" };

            InsertTextInExcel(fileName, "General Information", "A", 1);
            InsertTextInExcel(fileName, "Dimensions (Note: The unit for which barcodes are maintained will be considered as Selling Units. Selling unit can be more than 1)", "U", 1);
            InsertTextInExcel(fileName, "Supplier Data on Competition and Target Expected", "AW", 1);

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 2);
            }
        }

        public static void InsertTextInExcel(string docName, string text, string Columns, uint rowID)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                //WorksheetPart worksheetPart = InsertWorksheet(spreadSheet.WorkbookPart);

                Sheet sheet = spreadSheet.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                //Get the Worksheet instance.
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);

                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                if (cell.CellReference.Value == "A1")
                {
                    cell.StyleIndex = 5;
                }
                else if (cell.CellReference.Value == "U1")
                {
                    cell.StyleIndex = 6;
                }
                else if (cell.CellReference.Value == "AW1")
                {
                    cell.StyleIndex = 7;
                }
                else if (cell.CellReference.Value == "B2" || cell.CellReference.Value == "C2")
                {
                    cell.StyleIndex = 8;
                }
                else if (cell.CellReference.Value == "A2" || cell.CellReference.Value == "D2")
                {
                    cell.StyleIndex = 14;
                }
                else if (cell.CellReference.Value == "E2" || cell.CellReference.Value == "F2" || cell.CellReference.Value == "G2" || cell.CellReference.Value == "H2" || cell.CellReference.Value == "I2")
                {
                    cell.StyleIndex = 9;
                }
                else if (cell.CellReference.Value == "K2" || cell.CellReference.Value == "J2")
                {
                    cell.StyleIndex = 15;
                }
                else if (cell.CellReference.Value == "M2" || cell.CellReference.Value == "N2" || cell.CellReference.Value == "R2" || cell.CellReference.Value == "S2" || cell.CellReference.Value == "T2")
                {
                    cell.StyleIndex = 10;
                }
                else if (cell.CellReference.Value == "L2" || cell.CellReference.Value == "O2" || cell.CellReference.Value == "P2" || cell.CellReference.Value == "S2" || cell.CellReference.Value == "Q2")
                {
                    cell.StyleIndex = 16;
                }
                else if (cell.CellReference.Value == "U2" || cell.CellReference.Value == "V2" || cell.CellReference.Value == "W2" || cell.CellReference.Value == "X2" || cell.CellReference.Value == "Y2" || cell.CellReference.Value == "Z2" || cell.CellReference.Value == "AA2" || cell.CellReference.Value == "AI2" || cell.CellReference.Value == "AJ2" || cell.CellReference.Value == "AK2" || cell.CellReference.Value == "AL2" || cell.CellReference.Value == "AM2" || cell.CellReference.Value == "AN2" || cell.CellReference.Value == "AO2")
                {
                    cell.StyleIndex = 11;
                }
                else if (cell.CellReference.Value == "AB2" || cell.CellReference.Value == "AC2" || cell.CellReference.Value == "AD2" || cell.CellReference.Value == "AE2" || cell.CellReference.Value == "AF2" || cell.CellReference.Value == "AG2" || cell.CellReference.Value == "AH2" || cell.CellReference.Value == "AP2" || cell.CellReference.Value == "AQ2" || cell.CellReference.Value == "AR2" || cell.CellReference.Value == "AS2" || cell.CellReference.Value == "AT2" || cell.CellReference.Value == "AU2" || cell.CellReference.Value == "AV2")
                {
                    cell.StyleIndex = 12;
                }
                else if (cell.CellReference.Value == "AW2" || cell.CellReference.Value == "AX2" || cell.CellReference.Value == "AY2" || cell.CellReference.Value == "AZ2" || cell.CellReference.Value == "BA2" || cell.CellReference.Value == "BB2" || cell.CellReference.Value == "BC2" || cell.CellReference.Value == "BD2")
                {
                    cell.StyleIndex = 13;
                }
                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 – The default font.
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 1 – The bold font.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "ffffff" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 – The Italic font.
                        new Italic(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 3 – The Times Roman font. with 16 size
                        new FontSize() { Val = 16 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" }),
                    new Font(                                                               // Index 4 – The bold font.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "ff0000" } },
                        new FontName() { Val = "Calibri" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 – The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 – The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(                                                           // Index 2 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "EC700A" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 3 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "948B54" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 4 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "D99795" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 5 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "92D050" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 6 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "C6EFCE" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 7 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "FFFF99" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 8 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "C0C0C0" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 9 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "EEECE1" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 10 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "F2DDDC" } }
                        )
                        { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(                                                         // Index 0 – The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Index 1 – Applies a Left, Right, Top, Bottom border to a cell
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 – The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 – Bold 
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 – Italic
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 – Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Index 4 – Yellow Fill
                    new CellFormat(                                                                   // Index 5 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                    { FontId = 1, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 6 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                    { FontId = 1, FillId = 3, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 7 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                    { FontId = 1, FillId = 4, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 8 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 5, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 9 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 6, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 10 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 7, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 11 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 8, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 12 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 9, BorderId = 1, ApplyAlignment = true },
                    new CellFormat(                                                                   // Index 13 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 10, BorderId = 1, ApplyAlignment = true },
                     new CellFormat(                                                                   // Index 14 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                     { FontId = 4, FillId = 5, BorderId = 1, ApplyAlignment = true },
                     new CellFormat(                                                                   // Index 15 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                     { FontId = 4, FillId = 6, BorderId = 1, ApplyAlignment = true },
                     new CellFormat(                                                                   // Index 16 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                     { FontId = 4, FillId = 7, BorderId = 1, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 17 – Border
                )
            ); // return
        }
        #endregion
        //Image Upload
        #region Image Upload Methods
        private const int AvatarStoredWidth = 350;  // ToDo - Change the size of the stored avatar image
        private const int AvatarStoredHeight = 350; // ToDo - Change the size of the stored avatar image
        private const int AvatarScreenWidth = 700;  // ToDo - Change the value of the width of the image on the screen

        private const string TempFolder = "/Content/UploadedFiles/Temp";
        private const string MapTempFolder = "~" + TempFolder;
        private const string AvatarPath = "/Content/UploadedFiles/ArticleImage";

        private readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };

        [HttpGet]
        public ActionResult ArticleImageUpload()
        {
            //return PartialView();
            return PartialView("/Views/Inventory/GeneralItemMaster/ArticleImageUpload.cshtml");
        }
        [HttpGet]
        public ActionResult MultipleArticleImageUpload()
        {
            //return PartialView();
            return PartialView("/Views/Inventory/GeneralItemMaster/MultipleImageUpload.cshtml");
        }
        [ValidateAntiForgeryToken]
        public ActionResult ArticleImageUpload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any()) return Json(new { success = false, errorMessage = "No file uploaded." });
            var file = files.FirstOrDefault();  // get ONE only
            if (file == null || !IsImage(file)) return Json(new { success = false, errorMessage = "File is of wrong format." });
            if (file.ContentLength <= 0) return Json(new { success = false, errorMessage = "File cannot be zero length." });
            var webPath = GetTempSavedFilePath(file);
            //mistertommat - 18 Nov '15 - replacing '\' to '//' results in incorrect image url on firefox and IE,
            //                            therefore replacing '\\' to '/' so that a proper web url is returned.            
            return Json(new { success = true, fileName = webPath.Replace("\\", "/") }); // success
        }
        [ValidateAntiForgeryToken]
        public ActionResult MultipleArticleImageUpload(IEnumerable<HttpPostedFileBase> files)
        {
            if (files == null || !files.Any()) return Json(new { success = false, errorMessage = "No file uploaded." });
            var file = files.FirstOrDefault();  // get ONE only
            if (file == null || !IsImage(file)) return Json(new { success = false, errorMessage = "File is of wrong format." });
            if (file.ContentLength <= 0) return Json(new { success = false, errorMessage = "File cannot be zero length." });
            var webPath = GetTempSavedFilePath(file);
            //mistertommat - 18 Nov '15 - replacing '\' to '//' results in incorrect image url on firefox and IE,
            //                            therefore replacing '\\' to '/' so that a proper web url is returned.            
            return Json(new { success = true, fileName = webPath.Replace("\\", "/") }); // success
        }



        [HttpPost]
        public ActionResult Save(string t, string l, string h, string w, string fileName)
        {
            try
            {
                // Calculate dimensions
                var top = Convert.ToInt32(t.Replace("-", "").Replace("px", ""));
                var left = Convert.ToInt32(l.Replace("-", "").Replace("px", ""));
                var height = Convert.ToInt32(h.Replace("-", "").Replace("px", ""));
                var width = Convert.ToInt32(w.Replace("-", "").Replace("px", ""));

                // Get file from temporary folder
                var fn = Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(fileName));
                // ...get image and resize it, ...
                var img = new WebImage(fn);
                img.Resize(width, height);
                // ... crop the part the user selected, ...
                img.Crop(top, left, img.Height - top - AvatarStoredHeight, img.Width - left - AvatarStoredWidth);


                // ... delete the temporary file,...
                System.IO.File.Delete(fn);
                // ... and save the new one.
                var newFileName = Path.Combine(AvatarPath, Path.GetFileName(fn));
                var newFileLocation = HttpContext.Server.MapPath(newFileName);
                if (Directory.Exists(Path.GetDirectoryName(newFileLocation)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation));
                }

                img.Save(newFileLocation);

                var img2 = new WebImage(newFileLocation);
                //img2.Resize(width / 2, height);
                // ... crop the part the user selected, ...
                img2.Crop(0, img2.Width / 2, 0, 0);

                var fileName2 = Path.GetFileNameWithoutExtension(newFileName);
                var _ext = Path.GetExtension(newFileName);
                var newFileName2 = fileName2 + "_1By2" + _ext;
                var newFileNameFull = Path.Combine(AvatarPath, newFileName2);
                var newFileLocation2 = HttpContext.Server.MapPath(newFileNameFull);
                if (Directory.Exists(Path.GetDirectoryName(newFileLocation2)) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(newFileLocation2));
                }

                img2.Save(newFileLocation2);
                return Json(new { success = true, avatarFileLocation = newFileName, ArticleFileName = Path.GetFileName(fileName) });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMessage = "Unable to upload file.\nERRORINFO: " + ex.Message });
            }
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            if (file == null) return false;
            return file.ContentType.Contains("image") ||
                _imageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        private string GetTempSavedFilePath(HttpPostedFileBase file)
        {
            // Define destination
            var serverPath = HttpContext.Server.MapPath(TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }


            string _imgname = string.Empty;
            // Generate unique file name
            var fileName = Path.GetFileName(file.FileName);

            var _ext = Path.GetExtension(file.FileName);
            _imgname = Guid.NewGuid().ToString();

            _imgname = "Article_" + _imgname + _ext;

            fileName = SaveTemporaryAvatarFileImage(file, serverPath, _imgname);

            // Clean up old files after every save
            CleanUpTempFolder(1);
            return Path.Combine(TempFolder, fileName);
        }

        private static string SaveTemporaryAvatarFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(AvatarScreenWidth, (int)(AvatarScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);


            return Path.GetFileName(img.FileName);
        }

        private void CleanUpTempFolder(int hoursOld)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = HttpContext.Server.MapPath("/Temp");
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);
                foreach (var fileEntry in fileEntries)
                {
                    var fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry);
                    var res = currentUtcNow - fileCreationTime;
                    if (res.TotalHours > hoursOld)
                    {
                        System.IO.File.Delete(fileEntry);
                    }
                }
            }
            catch
            {
                // Deliberately empty.
            }
        }



        #endregion

        // Non-Action Method
        #region Methods


        public ActionResult GetBaseUoMcodeByUoMGroupCode(string UoMGroupCode)
        {
            if (String.IsNullOrEmpty(UoMGroupCode))
            {
                throw new ArgumentNullException("UoMGroupCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(UoMGroupCode, out id);
            var department = GetListBaseCodebyUoMGroupCode(UoMGroupCode);
            var result = (from s in department
                          select new
                          {
                              id = s.InventoryUoMGroupDetailsID,
                              GroupCode = s.GroupCode,
                              name = s.BaseUomCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Barcode Validation
        [HttpPost]
        public JsonResult CheckFocusOnAction(string selectedbarcodeName)
        {
            bool _ExistsFlag = false;
            if (selectedbarcodeName != string.Empty)
            {
                GeneralItemMaster _GeneralItemMaster = new GeneralItemMaster();
                _GeneralItemMaster.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _GeneralItemMaster.BarCode = selectedbarcodeName;
                IBaseEntityResponse<GeneralItemMaster> response = _GeneralItemMasterBA.CheckFocusOnAction(_GeneralItemMaster);
                if (response != null && response.Entity != null)
                {
                    _ExistsFlag = response.Entity.IsExists;
                }

            }
            return Json(Convert.ToString(_ExistsFlag), JsonRequestBehavior.AllowGet);
        }

        //Serachlist for Vendor name

        [HttpPost]
        public JsonResult GetItemNumberSearchList(string term)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemMasterSearchList(searchRequest);
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
                              name = r.ItemDescription,
                              ItemDescription = r.ItemDescription,
                              ItemNumber = r.ItemNumber,
                              ItemCategoryCode = r.ItemCategoryCode,
                              BaseUoMcode = r.BaseUoMcode,
                              //lastpurchaseprice = r.lastpurchaseprice,
                              //currencycode = r.currencycode,
                              //basebarcode = r.basebarcode,
                              //basepricelistid = r.basepricelistid,
                              //inventorypurchasegroupmasterid = r.inventorypurchasegroupmasterid,
                              IsInventoryItem = r.IsInventoryItem,
                              IsSalesItem = r.IsSalesItem,
                              IsPurchaseItem = r.IsPurchaseItem,
                              IsFixedAssetItem = r.IsFixedAssetItem,
                              UoMGroupCode = r.UoMGroupCode,
                              ItemType = r.ItemType,
                              //GeneralItemCodeID=r.GeneralItemCodeID,
                              Temprature = r.Temprature,
                              //TempratureUpto = r.TempratureUpto,
                              RetailSale = r.RetailSale,
                              BOM = r.BOM,
                              Restaurant = r.Restaurant,
                              IsMultipleVendor = r.IsMultipleVendor,
                              IsServiceItem=r.IsServiceItem,
                              IsEComItem = r.IsEComItem,
                              HSNCode=r.HSNCode,
                              ItemCode = r.ItemCode,
                              IsConsumable = r.IsConsumable,
                              IsMachine = r.IsMachine,
                              IsToner = r.IsToner,
                              //data from GeneralItemSuppliermaster 
                              GeneralItemSupliersDataID = r.GeneralItemSupliersDataID,
                              ManufacturCatalogNumber = r.ManufacturCatalogNumber,
                              GenTaxGroupMasterID = r.GenTaxGroupMasterID,
                              PurchaseUoMCode = r.PurchaseUoMCode,
                              GeneralVendorID = r.GeneralVendorID,
                              VendorName = r.VendorName,
                              GeneralPurchaseGroupMasterID = r.GeneralPurchaseGroupMasterID,
                              PackageType = r.PackageType,

                              //data from GeneralItemGeneralData
                              ManufacturerID = r.ManufacturerID,
                              ShippingTypeId = r.ShippingTypeId,
                              SerialAndBatchManagedBy = r.SerialAndBatchManagedBy,
                              ManagementMethod = r.ManagementMethod,
                              IssueMethod = r.IssueMethod,
                              GeneralItemGeneralDataID = r.GeneralItemGeneralDataID,
                              NetContentPerPiece = r.NetContentPerPiece,
                              NetContentUOM = r.NetContentUOM,
                              NetWeightPerPiece = r.NetWeightPerPiece,
                              SpecialFeature = r.SpecialFeature,
                              ShortDescription = r.ShortDescription,
                              BrandName = r.BrandName,
                              ArabicTransalation = r.ArabicTransalation,
                              ////data from GeneralItemSalesData
                              //SaleUoMCode = r.SaleUoMCode,
                              //ItemPerSaleUnit = r.ItemPerSaleUnit,
                              //PackingUnitSale = r.PackingUnitSale,
                              //QuantityPerPackingUnitSale = r.QuantityPerPackingUnitSale,

                              //// data from GeneralItemStockData
                              //GLAccountBy = r.GLAccountBy,
                              //StockUoMCode = r.StockUoMCode,
                              //ValuationMethod = r.ValuationMethod,
                              //UoMCode = r.UoMCode,
                              //MinStock = r.MinStock,
                              //MaxStock = r.MaxStock,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetCCRMPartNoSearchList(string term)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
           
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetCCRMPartNoSearchList(searchRequest);
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
                              ID = r.ID,
                            
                              ItemDescription = r.ItemDescription,
                              ItemNumber = r.ItemNumber,
                              ItemCategoryCode = r.ItemCategoryCode,
                              lifeInCopies = r.lifeInCopies,
                              //LastCallDate=r.LastCallDate,
                              //LastQuantity=r.LastQuantity,
                              //LastMtrRead=r.LastMtrRead,
                             
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Serachlist for Vendor name
        [HttpPost]
        public JsonResult GetVendorSearchList(string term)
        {
            VendorMasterSearchRequest searchRequest = new VendorMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<VendorMaster> listFeeSubType = new List<VendorMaster>();
            IBaseEntityCollectionResponse<VendorMaster> baseEntityCollectionResponse = _VendorMasterBA.GetVendorMasterSearchList(searchRequest);
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
                              id = r.ID,
                              name = r.VendorName,
                              vendorname = r.VendorName,
                              VendorNumber = r.VendorNumber,
                              //countryId = r.CountryID,
                              currency = r.Currency,

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //protected List<InventoryRecipeMenuCategory> GetListRecipeMenuCategory()
        //{
        //    InventoryRecipeMenuCategorySearchRequest searchRequest = new InventoryRecipeMenuCategorySearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    List<InventoryRecipeMenuCategory> listRecipeMenuCategory = new List<InventoryRecipeMenuCategory>();
        //    IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> baseEntityCollectionResponse = _IInventoryRecipeMenuCategoryBA.GetRestaurantCategory(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listRecipeMenuCategory = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listRecipeMenuCategory;
        //}


        protected List<GeneralPackageType> GetGeneralPackageType()
        {
            GeneralPackageTypeSearchRequest searchRequest = new GeneralPackageTypeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPackageType> listGeneralPackageType = new List<GeneralPackageType>();
            IBaseEntityCollectionResponse<GeneralPackageType> baseEntityCollectionResponse = _IGeneralPackageTypeBA.GetGeneralPackageTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralPackageType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralPackageType;
        }
        //drop down for process unit
        protected List<GeneralPriceListAndListLine> GetListGeneralPriceGroupForPriceGroupCode()
        {
            GeneralPriceListAndListLineSearchRequest searchRequest = new GeneralPriceListAndListLineSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPriceListAndListLine> listtGeneralPriceGroup = new List<GeneralPriceListAndListLine>();
            IBaseEntityCollectionResponse<GeneralPriceListAndListLine> baseEntityCollectionResponse = _GeneralPriceListAndListLineBA.GetGeneralPriceListAndListLineSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }
        [NonAction]
        protected List<GeneralItemMaster> GetGeneralItemMasterListForUoMDetails(string TaskCode, string ItemNumber)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            searchRequest.TaskCode = TaskCode;
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetUomDetailsForGeneralItemMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralItemMaster;
        }
        [HttpPost]
        public JsonResult GetLeadTimeByVendorID(string ItemNumber, string GeneralVendorID)
        {
            VendorMasterViewModel model = new VendorMasterViewModel();
            model.VendorMasterDTO = new VendorMaster();
            model.VendorMasterDTO.ItemNumber = Convert.ToInt32(ItemNumber);
            model.VendorMasterDTO.VendorID = Convert.ToInt32(GeneralVendorID);

            model.VendorMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<VendorMaster> response = _VendorMasterBA.GetLeadTimeByVendorID(model.VendorMasterDTO);
            if (response != null && response.Entity != null)
            {

                model.VendorMasterDTO.LeadTime = response.Entity.LeadTime;

            }
            return Json(model.VendorMasterDTO.LeadTime, JsonRequestBehavior.AllowGet);
        }
        [NonAction]
        protected List<GeneralItemMaster> GetGeneralItemMasterListForDelistingAndDelistingDate(string GeneralItemMasterID, string ItemNumber, string CentreListXML)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            searchRequest.ID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null); ;
            searchRequest.CentreListXML = CentreListXML;
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemStoreData(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralItemMaster;
        }

        protected List<GeneralItemMaster> GetGeneralItemMasterListForAttributeData(string GeneralItemMasterID, string ItemNumber)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            searchRequest.ID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemMasterID) ? GeneralItemMasterID : null); ;
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemAttributeDataByItemNumber(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralItemMaster;
        }

        protected List<GeneralItemMaster> GetGeneralItemMasterListForSaleDetails(string ItemNumber, string CentreListXML)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            searchRequest.CentreListXML = CentreListXML;
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemSalesDataByItemNumber(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralItemMaster;
        }
        [NonAction]
        protected List<GeneralItemMaster> GetGeneralItemMasterListForVarientDetails(string GeneralItemmasterID)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = Convert.ToInt32(!string.IsNullOrEmpty(GeneralItemmasterID) ? GeneralItemmasterID : null);
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetVariantDetailsForGeneralItemMasters(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralItemMaster;
        }
        protected List<GeneralPriceGroup> GetListGeneralItemPriceGroup()
        {
            GeneralPriceGroupSearchRequest searchRequest = new GeneralPriceGroupSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPriceGroup> listtGeneralPriceGroup = new List<GeneralPriceGroup>();
            IBaseEntityCollectionResponse<GeneralPriceGroup> baseEntityCollectionResponse = _GeneralPriceGroupBA.GetGeneralPriceGroupSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }
        protected List<GeneralItemCategoryMaster> GetListGeneralItemCategoryMaster()
        {
            GeneralItemCategoryMasterSearchRequest searchRequest = new GeneralItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemCategoryMaster> listtGeneralPriceGroup = new List<GeneralItemCategoryMaster>();
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollectionResponse = _GeneralItemCategoryMasterBA.GetGeneralItemCategoryMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }

        protected List<InventoryAttributeMaster> GetListInventoryAttributeMaster()
        {
            InventoryAttributeMasterSearchRequest searchRequest = new InventoryAttributeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryAttributeMaster> listtGeneralPriceGroup = new List<InventoryAttributeMaster>();
            IBaseEntityCollectionResponse<InventoryAttributeMaster> baseEntityCollectionResponse = _InventoryAttributeMasterBA.GetInventoryAttributeMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }

        protected List<InventoryBrandMaster> GetListGeneralItemBrandMaster()
        {
            InventoryBrandMasterSearchRequest searchRequest = new InventoryBrandMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryBrandMaster> listBrandName = new List<InventoryBrandMaster>();
            IBaseEntityCollectionResponse<InventoryBrandMaster> baseEntityCollectionResponse = _InventoryBrandMasterBA.GetInventoryBrandMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBrandName = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listBrandName;
        }
        //************Drop down for Temperature field************
        protected List<GeneralTemperatureMaster> GetListGeneralTemperatureMaster()
        {
            GeneralTemperatureMasterSearchRequest searchRequest = new GeneralTemperatureMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTemperatureMaster> listTemperature = new List<GeneralTemperatureMaster>();
            IBaseEntityCollectionResponse<GeneralTemperatureMaster> baseEntityCollectionResponse = _GeneraltemperatureMasterBA.GetGeneralTemperatureMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listTemperature = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listTemperature;
        }

        //Multiple Vendor
        protected List<GeneralPurchaseGroupMaster> GetListGeneralPurchaseGroupMaster()
        {
            GeneralPurchaseGroupMasterSearchRequest searchRequest = new GeneralPurchaseGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralPurchaseGroupMaster> listtGeneralPriceGroup = new List<GeneralPurchaseGroupMaster>();
            IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> baseEntityCollectionResponse = _GeneralPurchaseGroupMasterBA.GetGeneralPurchaseGroupMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listtGeneralPriceGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listtGeneralPriceGroup;
        }
        //Multiple Vendor
        protected List<GeneralItemMaster> GetListMultipleVendorItemWise(int ItemNumber)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = ItemNumber;
            List<GeneralItemMaster> ListOFMultipleVendor = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetMultipleVendorListItemWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListOFMultipleVendor = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListOFMultipleVendor;
        }
        protected List<GeneralCountryMaster> GetListGeneralCountryMaster()
        {
            GeneralCountryMasterSearchRequest searchRequest = new GeneralCountryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCountryMaster> ListGeneralCountryMaster = new List<GeneralCountryMaster>();
            IBaseEntityCollectionResponse<GeneralCountryMaster> baseEntityCollectionResponse = _GeneralCountryMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralCountryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralCountryMaster;
        }

        protected List<GeneralCurrencyMaster> GetListGeneralCurrencyMaster()
        {
            GeneralCurrencyMasterSearchRequest searchRequest = new GeneralCurrencyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCurrencyMaster> ListGeneralCurrencyMaster = new List<GeneralCurrencyMaster>();
            IBaseEntityCollectionResponse<GeneralCurrencyMaster> baseEntityCollectionResponse = _GeneralCurrencyMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralCurrencyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralCurrencyMaster;
        }
        protected List<InventoryUoMGroupAndDetails> GetListInventoryUoMGroup()
        {
            InventoryUoMGroupAndDetailsSearchRequest searchRequest = new InventoryUoMGroupAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryUoMGroupAndDetails> ListInventoryUoMGroup = new List<InventoryUoMGroupAndDetails>();
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> baseEntityCollectionResponse = _InventoryUoMGroupAndDetailsBA.GetInventoryUoMGroupAndDetailsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMGroup = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMGroup;
        }
        //Dropdown for General Item Merchantise Department
        protected List<InventoryUoMMaster> GetListInventoryUoMMasterForUomCode()
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<InventoryUoMMaster> ListInventoryUoMMasterForUomCode = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForUomCode;
        }
        //Dropdown for General Units
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
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }
        //Dropdown for GetSaleUomCode
        protected List<InventoryUoMMaster> GetSaleUomCode(string ItemNumber)
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            List<InventoryUoMMaster> ListInventoryUoMMasterForSaleUomCode = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforSaleUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForSaleUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForSaleUomCode;
        }

        //Dropdown for GetPurchaseUomCode
        protected List<InventoryUoMMaster> GetPurchaseUomCode(string ItemNumber)
        {
            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(!string.IsNullOrEmpty(ItemNumber) ? ItemNumber : null);
            List<InventoryUoMMaster> ListInventoryUoMMasterForSaleUomCode = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforPurchaseUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryUoMMasterForSaleUomCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryUoMMasterForSaleUomCode;
        }

        protected List<InventoryUoMGroupAndDetails> GetListBaseCodebyUoMGroupCode(string UoMGroupCode)
        {

            InventoryUoMGroupAndDetailsSearchRequest searchRequest = new InventoryUoMGroupAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.UoMGroupCode = UoMGroupCode;

            List<InventoryUoMGroupAndDetails> listOrganisationDepartmentMaster = new List<InventoryUoMGroupAndDetails>();
            IBaseEntityCollectionResponse<InventoryUoMGroupAndDetails> baseEntityCollectionResponse = _InventoryUoMGroupAndDetailsBA.GetInventoryUomCodeByUomGroupCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        //Code for Ordering day and delivary day dropdown
        protected List<OrderingAndDeliveryDay> GetListForOrderingDayAndDelivaryDayCode()
        {

            OrderingAndDeliveryDaySearchRequest searchRequest = new OrderingAndDeliveryDaySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            // searchRequest.UoMGroupCode = UoMGroupCode;

            List<OrderingAndDeliveryDay> listOrganisationDepartmentMaster = new List<OrderingAndDeliveryDay>();
            IBaseEntityCollectionResponse<OrderingAndDeliveryDay> baseEntityCollectionResponse = _OrderingAndDeliveryDayBA.GetDropDownListForOrderingAndDeliveryDay(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }
        //Code end for Ordering day and delivary day dropdown

        //For Menu Image.
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string _imgname = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(pic.FileName);
                    var _ext = Path.GetExtension(pic.FileName);

                    _imgname = Guid.NewGuid().ToString();
                    var _comPath = Server.MapPath("~") + "\\Content\\UploadedFiles\\ItemMaster\\MenuImage\\";
                    _imgname = "option_" + _imgname + _ext;

                    if (!Directory.Exists(_comPath))
                    {
                        Directory.CreateDirectory(_comPath);
                    }
                    pic.SaveAs(_comPath + "\\" + Path.GetFileName(_imgname));

                    ViewBag.Msg = _comPath;
                    var path = _comPath;
                    MemoryStream ms = new MemoryStream();
                }
            }
            return Json(Convert.ToString(_imgname), JsonRequestBehavior.AllowGet);
        }

        public IEnumerable<GeneralItemMasterViewModel> GetGeneralItemMaster(out int TotalRecords)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
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
            List<GeneralItemMasterViewModel> listGeneralItemMasterViewModel = new List<GeneralItemMasterViewModel>();
            List<GeneralItemMaster> listGeneralItemMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralItemMaster item in listGeneralItemMaster)
                    {
                        GeneralItemMasterViewModel GeneralItemMasterViewModel = new GeneralItemMasterViewModel();
                        GeneralItemMasterViewModel.GeneralItemMasterDTO = item;
                        listGeneralItemMasterViewModel.Add(GeneralItemMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemMasterViewModel;
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

                IEnumerable<GeneralItemMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.GroupDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%' or A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.MarchandiseGroupCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%' or A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralItemMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ItemDescription) };

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