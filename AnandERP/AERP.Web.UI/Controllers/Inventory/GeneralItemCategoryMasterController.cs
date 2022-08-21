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
using System.Data;
using System.Web.Hosting;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Web;
using DocumentFormat.OpenXml.Validation;
namespace AERP.Web.UI.Controllers
{
    public class GeneralItemCategoryMasterController : BaseController
    {
        IGeneralItemCategoryMasterBA _GeneralItemCategoryMasterServiceAcess = null;
        IGeneralItemMarchandiseGroupBA _GeneralItemMarchandiseGroupBA = null;
        IGeneralItemMerchantiseDepartmentBA _GeneralItemMerchantiseDepartmentBA = null;
        IGeneralItemMerchantiseCategoryBA _GeneralItemMerchantiseCategoryBA = null;
        IGeneralItemMarchandiseSubCategoryBA _GeneralItemMarchandiseSubCategoryBA = null;
        IGeneralItemMarchandiseBaseCategoryBA _GeneralItemMarchandiseBaseCategoryBA = null;
        IGeneralItemCategoryMasterBA _GeneralItemCategoryMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralItemCategoryMasterController()
        {
            _GeneralItemCategoryMasterServiceAcess = new GeneralItemCategoryMasterBA();
            _GeneralItemMarchandiseGroupBA = new GeneralItemMarchandiseGroupBA();
            _GeneralItemMerchantiseDepartmentBA = new GeneralItemMerchantiseDepartmentBA();
            _GeneralItemMerchantiseCategoryBA = new GeneralItemMerchantiseCategoryBA();
            _GeneralItemMarchandiseSubCategoryBA = new GeneralItemMarchandiseSubCategoryBA();
            _GeneralItemMarchandiseBaseCategoryBA = new GeneralItemMarchandiseBaseCategoryBA();
            _GeneralItemCategoryMasterBA = new GeneralItemCategoryMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
                return View("/Views/Inventory/GeneralItemCategoryMaster/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public FileResult Download()
        {
            string FileName = "GeneralItemCategoryMaster.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralItemCategoryMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult UploadExcel()
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
            return PartialView("/Views/Inventory/GeneralItemCategoryMaster/UploadExcel.cshtml", model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
            //************************** Drop Down For General Item Marchandise Group***********************************************
            List<GeneralItemMarchandiseGroup> GeneralItemMarchandiseGroup = GetListGeneralItemMarchandiseGroup();
            List<SelectListItem> GeneralItemMarchandiseGroupList = new List<SelectListItem>();
            foreach (GeneralItemMarchandiseGroup item in GeneralItemMarchandiseGroup)
            {
                GeneralItemMarchandiseGroupList.Add(new SelectListItem { Text = item.GroupDescription + "(" + item.MarchandiseGroupCode + ")", Value = Convert.ToString(item.ID + "~" + item.MarchandiseGroupCode) });
            }
            ViewBag.MarchandiseGroupList = new SelectList(GeneralItemMarchandiseGroupList, "Value", "Text");

            //************************** Drop Down For General Item Marchandise Department***********************************************
            List<GeneralItemMerchantiseDepartment> GeneralItemMerchantiseDepartment = GetListGeneralItemMerchantiseDepartment();
            List<SelectListItem> GeneralItemMerchantiseDepartmentList = new List<SelectListItem>();
            foreach (GeneralItemMerchantiseDepartment item in GeneralItemMerchantiseDepartment)
            {
                GeneralItemMerchantiseDepartmentList.Add(new SelectListItem { Text = item.MerchantiseDepartmentName + "(" + item.MerchantiseDepartmentCode + ")", Value = Convert.ToString(item.ID + "~" + item.MerchantiseDepartmentCode) });
            }
            ViewBag.MerchandiseDepartmentList = new SelectList(GeneralItemMerchantiseDepartmentList, "Value", "Text");

            //************************** Drop Down For General Item Marchandise Category***********************************************
            List<GeneralItemMerchantiseCategory> GeneralItemMerchantiseCategory = GetListGeneralItemMerchantiseCategory();
            List<SelectListItem> GeneralItemMerchantiseCategoryList = new List<SelectListItem>();
            foreach (GeneralItemMerchantiseCategory item in GeneralItemMerchantiseCategory)
            {
                GeneralItemMerchantiseCategoryList.Add(new SelectListItem { Text = item.MerchantiseCategoryName + "(" + item.MerchantiseCategoryCode + ")", Value = Convert.ToString(item.ID + "~" + item.MerchantiseCategoryCode) });
            }
            ViewBag.MerchantiseCategoryList = new SelectList(GeneralItemMerchantiseCategoryList, "Value", "Text");

            //************************** Drop Down For General Item Marchandise Sub Category***********************************************
            List<GeneralItemMarchandiseSubCategory> GeneralItemMerchantiseSubCategory = GetListGeneralItemMerchantiseSubCategory();
            List<SelectListItem> GeneralItemMerchantiseSubCategoryList = new List<SelectListItem>();
            foreach (GeneralItemMarchandiseSubCategory item in GeneralItemMerchantiseSubCategory)
            {
                GeneralItemMerchantiseSubCategoryList.Add(new SelectListItem { Text = item.MarchantiseSubCategoryName + "(" + item.MarchantiseSubCategoryCode + ")", Value = Convert.ToString(item.ID + "~" + item.MarchantiseSubCategoryCode) });
            }
            ViewBag.MerchantiseSubCategoryList = new SelectList(GeneralItemMerchantiseSubCategoryList, "Value", "Text");


            //************************** Drop Down For General Item Marchandise Base Category***********************************************
            List<GeneralItemMarchandiseBaseCategory> GeneralItemMerchantiseBaseCategory = GetListGeneralItemMerchantiseBaseCategory();
            List<SelectListItem> GeneralItemMerchantiseBaseCategoryList = new List<SelectListItem>();
            foreach (GeneralItemMarchandiseBaseCategory item in GeneralItemMerchantiseBaseCategory)
            {
                GeneralItemMerchantiseBaseCategoryList.Add(new SelectListItem { Text = item.MarchandiseBaseCategoryName + "(" + item.MarchandiseBaseCategoryCode + ")", Value = Convert.ToString(item.ID + "~" + item.MarchandiseBaseCategoryCode) });
            }
            ViewBag.MerchantiseBaseCategoryList = new SelectList(GeneralItemMerchantiseBaseCategoryList, "Value", "Text");


            return PartialView("/Views/Inventory/GeneralItemCategoryMaster/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult CreateBMC()
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();

            return PartialView("/Views/Inventory/GeneralItemCategoryMaster/CreateBMC.cshtml", model);
        }


        [HttpPost]
        public ActionResult Create(GeneralItemCategoryMasterViewModel model)
        {
            try
            {

                if (model != null && model.GeneralItemCategoryMasterDTO != null)
                {
                    model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;
                    model.GeneralItemCategoryMasterDTO.ItemCategoryDescription = model.ItemCategoryDescription;
                    model.GeneralItemCategoryMasterDTO.ItemCategoryCode = model.ItemCategoryCode;
                    model.GeneralItemCategoryMasterDTO.MarchandiseGroupID = model.MarchandiseGroupID;
                    model.GeneralItemCategoryMasterDTO.MerchandiseDepartmentID = model.MerchandiseDepartmentID;
                    model.GeneralItemCategoryMasterDTO.MerchandiseCategoryID = model.MerchandiseCategoryID;
                    model.GeneralItemCategoryMasterDTO.MarchandiseSubCategoryID = model.MarchandiseSubCategoryID;
                    model.GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryID = model.MarchandiseBaseCatgoryID;
                    model.GeneralItemCategoryMasterDTO.IsConsumable = model.IsConsumable;
                    model.GeneralItemCategoryMasterDTO.IsMachine = model.IsMachine;
                    model.GeneralItemCategoryMasterDTO.IsToner = model.IsToner;

                    model.GeneralItemCategoryMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterServiceAcess.InsertGeneralItemCategoryMaster(model.GeneralItemCategoryMasterDTO);
                    model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);

                }

                return Json("Please review your form");


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(Int16 id)
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
            try
            {
                model.GeneralItemCategoryMasterDTO = new GeneralItemCategoryMaster();
                model.GeneralItemCategoryMasterDTO.ID = id;
                model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterServiceAcess.SelectByID(model.GeneralItemCategoryMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemCategoryMasterDTO.ItemCategoryCode = response.Entity.ItemCategoryCode;
                    model.GeneralItemCategoryMasterDTO.ItemCategoryDescription = response.Entity.ItemCategoryDescription;
                    model.GeneralItemCategoryMasterDTO.MarchandiseBaseCatgoryID = response.Entity.MarchandiseBaseCatgoryID;
                    model.GeneralItemCategoryMasterDTO.MarchandiseGroupID = response.Entity.MarchandiseGroupID;
                    model.GeneralItemCategoryMasterDTO.MarchandiseSubCategoryID = response.Entity.MarchandiseSubCategoryID;
                    model.GeneralItemCategoryMasterDTO.MerchandiseDepartmentID = response.Entity.MerchandiseDepartmentID;
                    model.GeneralItemCategoryMasterDTO.MerchandiseCategoryID = response.Entity.MerchandiseCategoryID;
                    model.GeneralItemCategoryMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }

                //************************** Drop Down For General Item Marchandise Group***********************************************
                List<GeneralItemMarchandiseGroup> GeneralItemMarchandiseGroup = GetListGeneralItemMarchandiseGroup();
                List<SelectListItem> GeneralItemMarchandiseGroupList = new List<SelectListItem>();
                foreach (GeneralItemMarchandiseGroup item in GeneralItemMarchandiseGroup)
                {
                    GeneralItemMarchandiseGroupList.Add(new SelectListItem { Text = item.GroupDescription + "(" + item.MarchandiseGroupCode + ")", Value = Convert.ToString(item.ID + "~" + item.MarchandiseGroupCode) });
                }
                ViewBag.MarchandiseGroupList = new SelectList(GeneralItemMarchandiseGroupList, "Value", "Text", Convert.ToString(response.Entity.MarchandiseGroupID + "~" + response.Entity.MarchandiseGroupCode));

                //************************** Drop Down For General Item Marchandise Department***********************************************
                List<GeneralItemMerchantiseDepartment> GeneralItemMerchantiseDepartment = GetListGeneralItemMerchantiseDepartment();
                List<SelectListItem> GeneralItemMerchantiseDepartmentList = new List<SelectListItem>();
                foreach (GeneralItemMerchantiseDepartment item in GeneralItemMerchantiseDepartment)
                {
                    GeneralItemMerchantiseDepartmentList.Add(new SelectListItem { Text = item.MerchantiseDepartmentName + "(" + item.MerchantiseDepartmentCode + ")", Value = Convert.ToString(item.ID + "~" + item.MerchantiseDepartmentCode) });
                }
                ViewBag.MerchandiseDepartmentList = new SelectList(GeneralItemMerchantiseDepartmentList, "Value", "Text", Convert.ToString(response.Entity.MerchandiseDepartmentID + "~" + response.Entity.MerchantiseDepartmentCode));

                //************************** Drop Down For General Item Marchandise Category***********************************************
                List<GeneralItemMerchantiseCategory> GeneralItemMerchantiseCategory = GetListGeneralItemMerchantiseCategory();
                List<SelectListItem> GeneralItemMerchantiseCategoryList = new List<SelectListItem>();
                foreach (GeneralItemMerchantiseCategory item in GeneralItemMerchantiseCategory)
                {
                    GeneralItemMerchantiseCategoryList.Add(new SelectListItem { Text = item.MerchantiseCategoryName + "(" + item.MerchantiseCategoryCode + ")", Value = Convert.ToString(item.ID + "~" + item.MerchantiseCategoryCode) });
                }
                ViewBag.MerchantiseCategoryList = new SelectList(GeneralItemMerchantiseCategoryList, "Value", "Text", Convert.ToString(response.Entity.MerchandiseCategoryID + "~" + response.Entity.MerchantiseCategoryCode));

                //************************** Drop Down For General Item Marchandise Sub Category***********************************************
                List<GeneralItemMarchandiseSubCategory> GeneralItemMerchantiseSubCategory = GetListGeneralItemMerchantiseSubCategory();
                List<SelectListItem> GeneralItemMerchantiseSubCategoryList = new List<SelectListItem>();
                foreach (GeneralItemMarchandiseSubCategory item in GeneralItemMerchantiseSubCategory)
                {
                    GeneralItemMerchantiseSubCategoryList.Add(new SelectListItem { Text = item.MarchantiseSubCategoryName + "(" + item.MarchantiseSubCategoryCode + ")", Value = Convert.ToString(item.ID + "~" + item.MarchantiseSubCategoryCode) });
                }
                ViewBag.MerchantiseSubCategoryList = new SelectList(GeneralItemMerchantiseSubCategoryList, "Value", "Text", Convert.ToString(response.Entity.MarchandiseSubCategoryID + "~" + response.Entity.MerchantiseSubCategoryCode));


                //************************** Drop Down For General Item Marchandise Base Category***********************************************
                List<GeneralItemMarchandiseBaseCategory> GeneralItemMerchantiseBaseCategory = GetListGeneralItemMerchantiseBaseCategory();
                List<SelectListItem> GeneralItemMerchantiseBaseCategoryList = new List<SelectListItem>();
                foreach (GeneralItemMarchandiseBaseCategory item in GeneralItemMerchantiseBaseCategory)
                {
                    GeneralItemMerchantiseBaseCategoryList.Add(new SelectListItem { Text = item.MarchandiseBaseCategoryName + "(" + item.MarchandiseBaseCategoryCode + ")", Value = Convert.ToString(item.ID + "~" + item.MarchandiseBaseCategoryCode) });
                }
                ViewBag.MerchantiseBaseCategoryList = new SelectList(GeneralItemMerchantiseBaseCategoryList, "Value", "Text", Convert.ToString(response.Entity.MarchandiseBaseCatgoryID + "~" + response.Entity.MarchandiseBaseCatgoryCode));



                return PartialView("/Views/Inventory/GeneralItemCategoryMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditBMC(Int16 id)
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
            try
            {
                model.GeneralItemCategoryMasterDTO = new GeneralItemCategoryMaster();
                model.GeneralItemCategoryMasterDTO.ID = id;
                model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterServiceAcess.SelectByID(model.GeneralItemCategoryMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralItemCategoryMasterDTO.ItemCategoryCode = response.Entity.ItemCategoryCode;
                    model.GeneralItemCategoryMasterDTO.ItemCategoryDescription = response.Entity.ItemCategoryDescription;
                    model.GeneralItemCategoryMasterDTO.IsConsumable = response.Entity.IsConsumable;
                    model.GeneralItemCategoryMasterDTO.IsMachine = response.Entity.IsMachine;
                    model.GeneralItemCategoryMasterDTO.IsToner = response.Entity.IsToner;
                    model.GeneralItemCategoryMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Inventory/GeneralItemCategoryMaster/EditBMC.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult EditBMC(GeneralItemCategoryMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemCategoryMasterDTO != null)
                {
                    if (model != null && model.GeneralItemCategoryMasterDTO != null)
                    {
                        model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;
                        model.GeneralItemCategoryMasterDTO.ID = model.ID;
                        model.GeneralItemCategoryMasterDTO.ItemCategoryCode = model.ItemCategoryCode;
                        model.GeneralItemCategoryMasterDTO.ItemCategoryDescription = model.ItemCategoryDescription;
                        model.GeneralItemCategoryMasterDTO.IsConsumable = model.IsConsumable;
                        model.GeneralItemCategoryMasterDTO.IsMachine = model.IsMachine;
                        model.GeneralItemCategoryMasterDTO.IsToner = model.IsToner;

                        model.GeneralItemCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterServiceAcess.UpdateGeneralItemCategoryMaster(model.GeneralItemCategoryMasterDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        [HttpPost]
        public ActionResult Edit(GeneralItemCategoryMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralItemCategoryMasterDTO != null)
                {
                    if (model != null && model.GeneralItemCategoryMasterDTO != null)
                    {
                        model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;
                        model.GeneralItemCategoryMasterDTO.ID = model.ID;
                        model.GeneralItemCategoryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterServiceAcess.UpdateGeneralItemCategoryMaster(model.GeneralItemCategoryMasterDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(Int16 ID)
        //{
        //    GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
        //    model.GeneralItemCategoryMasterDTO = new GeneralItemCategoryMaster();
        //    model.GeneralItemCategoryMasterDTO.ID = ID;
        //    return PartialView("/Views/Inventory/GeneralItemCategoryMaster/Delete.cshtml", model);
        //}

        public ActionResult Delete(Int16 ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralItemCategoryMaster> response = null;
                GeneralItemCategoryMaster GeneralItemCategoryMasterDTO = new GeneralItemCategoryMaster();
                GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;
                GeneralItemCategoryMasterDTO.ID = ID;
                GeneralItemCategoryMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralItemCategoryMasterServiceAcess.DeleteGeneralItemCategoryMaster(GeneralItemCategoryMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UploadExcel(GeneralItemCategoryMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralItemCategoryMasterDTO != null)
                {
                    UploadExcelFile();
                    model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;
                    model.GeneralItemCategoryMasterDTO.ID = model.ID;
                    model.GeneralItemCategoryMasterDTO.XMLstring = xmlParameter.Replace("&", "[and]");
                    model.GeneralItemCategoryMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterServiceAcess.InsertGeneralItemCategoryMasterExcel(model.GeneralItemCategoryMasterDTO);
                        //model.GeneralItemCategoryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
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
                        else if (response.Entity.ErrorCode == 20)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 21)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 22)
                        {
                            errorMessageDis = response.Entity.errorMessage;
                            colorCode = "danger";
                        }
                        else if (response.Entity.ErrorCode == 23)
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
                        model.GeneralItemCategoryMasterDTO.errorMessage = errorMessage;

                    }
                    else if (IsExcelValid == false)
                    {
                        model.GeneralItemCategoryMasterDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.GeneralItemCategoryMasterDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }
                    TempData["_errorMsg"] = model.GeneralItemCategoryMasterDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "GeneralItemCategoryMaster", new { _GeneralItemCategoryMasterID = model.ID });
                    //return Json(model.GeneralItemCategoryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                return RedirectToAction("Index", "GeneralItemCategoryMaster", new { _GeneralItemCategoryMasterID = model.ID });
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
                                        (GetCellValue(doc, cell)) == "Item Category Description" ||
                                        (GetCellValue(doc, cell)) == "Group Code" ||
                                        (GetCellValue(doc, cell)) == "Group Description" ||
                                        (GetCellValue(doc, cell)) == "Department Code" ||
                                        (GetCellValue(doc, cell)) == "Department Description" ||
                                        (GetCellValue(doc, cell)) == "Category Code" ||
                                        (GetCellValue(doc, cell)) == "Category Description" ||
                                        (GetCellValue(doc, cell)) == "Sub Category Code" ||
                                        (GetCellValue(doc, cell)) == "Sub Category Description" ||
                                        (GetCellValue(doc, cell)) == "Base Category Code" ||
                                        (GetCellValue(doc, cell)) == "Base Category Description"
                                        )
                                    {
                                        dt.Columns.Add(GetCellValue(doc, cell));
                                    }
                                    else
                                    {
                                        IsExcelValid = false;
                                        errorMessage = "Invalid excel column,warning";
                                        break;

                                    }
                                }
                                if (dt.Columns.Count > 0)
                                {
                                    if ((IsExcelValid == true))
                                    {
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

                                        RemoveDuplicateRows(dt, "Group Code");

                                        if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            if (
                                                dt.Columns[0].ColumnName != "Item Category Description" ||
                                                dt.Columns[1].ColumnName != "Group Code" ||
                                                dt.Columns[2].ColumnName != "Group Description" ||
                                                dt.Columns[3].ColumnName != "Department Code" ||
                                                dt.Columns[4].ColumnName != "Department Description" ||
                                                dt.Columns[5].ColumnName != "Category Code" ||
                                                dt.Columns[6].ColumnName != "Category Description" ||
                                                dt.Columns[7].ColumnName != "Sub Category Code" ||
                                                dt.Columns[8].ColumnName != "Sub Category Description" ||
                                                dt.Columns[9].ColumnName != "Base Category Code" ||
                                                dt.Columns[10].ColumnName != "Base Category Description"
                                                )
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
                                                //if (long.TryParse(dt.Rows[i]["StudentMobileNo"].ToString().Trim(), out result))
                                                //{

                                                //double d = double.Parse(dt.Rows[i]["ExpectedDate"].ToString());
                                                //DateTime conv = DateTime.FromOADate(d);
                                                //string date = conv.ToString("yyyy-MM-dd");

                                                //if (!ValidateDate(date))
                                                //{
                                                //    int RowNo = i + 2;
                                                //    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Wrong Date format in row " + RowNo + "');", true);
                                                //    TempData["Message"] = "You are not authorized.";
                                                //    return;
                                                //}

                                                if (dt.Rows[i]["Item Category Description"].ToString().Trim().Length >= 1 && dt.Rows[i]["Group Code"].ToString().Trim().Length >= 1 && dt.Rows[i]["Group Description"].ToString().Trim().Length >= 1 && dt.Rows[i]["Department Code"].ToString().Trim().Length >= 1 && dt.Rows[i]["Department Description"].ToString().Trim().Length >= 1 && dt.Rows[i]["Category Code"].ToString().Trim().Length >= 1 && dt.Rows[i]["Category Description"].ToString().Trim().Length >= 1 && dt.Rows[i]["Sub Category Code"].ToString().Trim().Length >= 1 && dt.Rows[i]["Sub Category Description"].ToString().Trim().Length >= 1 && dt.Rows[i]["Base Category Code"].ToString().Trim().Length >= 1 && dt.Rows[i]["Base Category Description"].ToString().Trim().Length >= 1)
                                                {
                                                    xmlParameter = xmlParameter + "<row><ItemCategoryDescription>" + dt.Rows[i]["Item Category Description"].ToString().Trim() + "</ItemCategoryDescription><GeneralItemCategoryMasterID>0</GeneralItemCategoryMasterID><GeneralItemMarchandiseGroupID>0</GeneralItemMarchandiseGroupID><GroupCode>" + dt.Rows[i]["Group Code"].ToString().Trim() + "</GroupCode><GroupDescription>" + dt.Rows[i]["Group Description"].ToString().Trim() + "</GroupDescription><GeneralItemMerchantiseDepartmentID>0</GeneralItemMerchantiseDepartmentID><DepartmentCode>" + dt.Rows[i]["Department Code"].ToString().Trim() + "</DepartmentCode><DepartmentDescription>" + dt.Rows[i]["Department Description"].ToString().Trim() + "</DepartmentDescription><GeneralItemMerchantiseCategoryID>0</GeneralItemMerchantiseCategoryID><CategoryCode>" + dt.Rows[i]["Category Code"].ToString().Trim() + "</CategoryCode><CategoryDescription>" + dt.Rows[i]["Category Description"].ToString().Trim() + "</CategoryDescription><GeneralItemMarchandiseSubCategoryID>0</GeneralItemMarchandiseSubCategoryID><SubCategoryCode>" + dt.Rows[i]["Sub Category Code"].ToString().Trim() + "</SubCategoryCode><SubCategoryDescription>" + dt.Rows[i]["Sub Category Description"].ToString().Trim() + "</SubCategoryDescription><GeneralItemMarchandiseBaseCatgoryID>0</GeneralItemMarchandiseBaseCatgoryID><BaseCategoryCode>" + dt.Rows[i]["Base Category Code"].ToString().Trim() + "</BaseCategoryCode><BaseCategoryDescription>" + dt.Rows[i]["Base Category Description"].ToString().Trim() + "</BaseCategoryDescription></row>";

                                                    // xmlParameter = xmlParameter + "<row><GeneralItemCategoryMasterID>0</GeneralItemCategoryMasterID><GeneralItemMarchandiseGroupID>0</GeneralItemMarchandiseGroupID><MarchandiseGroupCode>" + dt.Rows[i]["Group Code"].ToString().Trim() + "</MarchandiseGroupCode><GroupDescription>" + dt.Rows[i]["Group Description"].ToString().Trim() + "</GroupDescription><MerchantiseDepartmentCode>" + dt.Rows[i]["Department Code"].ToString().Trim() + "</MerchantiseDepartmentCode><MerchantiseDepartmentName>" + dt.Rows[i]["Department Description"].ToString().Trim() + "</MerchantiseDepartmentName><MerchantiseCategoryCode>" + dt.Rows[i]["Category Code"].ToString().Trim() + "</MerchantiseCategoryCode><MerchantiseCategoryName>" + dt.Rows[i]["Category Description"].ToString().Trim() + "</MerchantiseCategoryName><MerchantiseSubCategoryCode>" + dt.Rows[i]["Sub Category Code"].ToString().Trim() + "</MerchantiseSubCategoryCode><MerchantiseSubCategoryName>" + dt.Rows[i]["Sub Category Description"].ToString().Trim() + "</MerchantiseSubCategoryName><MarchandiseBaseCatgoryCode>" + dt.Rows[i]["Base Category Code"].ToString().Trim() + "</MarchandiseBaseCatgoryCode><MarchandiseBaseCatgoryName>" + dt.Rows[i]["Base Category Description"].ToString().Trim() + "</MarchandiseBaseCatgoryName></row>"; 
                                                }



                                                //}
                                            }
                                            if (xmlParameter.Length > 9)
                                            {
                                                xmlParameter = xmlParameter + "</rows>";

                                            }
                                            else
                                            {
                                                xmlParameter = string.Empty;
                                                errorMessage = "No data found in excel,warning";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    errorMessage = "The selected file does not appear to be an excel file,warning";
                                }


                                dt.Dispose();
                            }
                        }
                        else
                        {
                            errorMessage = "Excel file not selected,warning";
                        }
                    }
                    else
                    {
                        IsExcelValid = false;
                        errorMessage = "Please Upload Downloaded File,warning";
                    }

                    // excelConnection.Close();

                    // SQL Server Connection String

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

        #endregion

        // Non-Action Method
        #region Methods

        //Serachlist for Vendor name
        [HttpPost]
        public JsonResult GetGroupCodeSearchList(string term)
        {
            GeneralItemMarchandiseGroupSearchRequest searchRequest = new GeneralItemMarchandiseGroupSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<GeneralItemMarchandiseGroup> listFeeSubType = new List<GeneralItemMarchandiseGroup>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> baseEntityCollectionResponse = _GeneralItemMarchandiseGroupBA.GetGeneralItemMarchandiseGroupSearchListForCategory(searchRequest);
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
                              name = r.GroupDescription,
                              GroupCode = r.MarchandiseGroupCode


                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDepartmentIDByGroupCode(string GroupCode)
        {

            var GroupCodeDesc = GetDepartmentCodeByGroupCode(GroupCode);
            var result = (from s in GroupCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.MerchantiseDepartmentCode,
                              DepartmentName = s.MerchantiseDepartmentName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoryIDByDepartmentID(string MerchandiseDepartmentID)
        {

            var DepartmentCodeDesc = GetCategoryCodeByDepartmentCode(MerchandiseDepartmentID);
            var result = (from s in DepartmentCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.MerchantiseCategoryCode,
                              CategoryName = s.MerchantiseCategoryName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubCategoryIDByCategoryID(string MerchandiseCategoryID)
        {

            var CategoryCodeDesc = GetSubCategoryCodeByCategoryCode(MerchandiseCategoryID);
            var result = (from s in CategoryCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.MarchantiseSubCategoryCode,
                              SubCategoryName = s.MarchantiseSubCategoryName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBaseCategoryIDBySubCategoryID(string MerchandiseSubCategoryID)
        {

            var SubCategoryCodeDesc = GetBaseCategoryCodeBySubCategoryCode(MerchandiseSubCategoryID);
            var result = (from s in SubCategoryCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.MarchandiseBaseCategoryCode,
                              BaseCategoryName = s.MarchandiseBaseCategoryName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<GeneralItemMerchantiseDepartment> GetDepartmentCodeByGroupCode(string GroupCode)
        {

            GeneralItemMerchantiseDepartmentSearchRequest searchRequest = new GeneralItemMerchantiseDepartmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.MerchantiseGroupCode = GroupCode;

            List<GeneralItemMerchantiseDepartment> listOrganisationDepartmentMaster = new List<GeneralItemMerchantiseDepartment>();
            IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> baseEntityCollectionResponse = _GeneralItemMerchantiseDepartmentBA.GetGeneralItemMerchantiseDepartmentCodeByGroupCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected List<GeneralItemMerchantiseCategory> GetCategoryCodeByDepartmentCode(string MerchandiseDepartmentID)
        {

            GeneralItemMerchantiseCategorySearchRequest searchRequest = new GeneralItemMerchantiseCategorySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.MerchantiseDepartmentID = Convert.ToInt32(MerchandiseDepartmentID);

            List<GeneralItemMerchantiseCategory> listOrganisationDepartmentMaster = new List<GeneralItemMerchantiseCategory>();
            IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> baseEntityCollectionResponse = _GeneralItemMerchantiseCategoryBA.GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected List<GeneralItemMarchandiseSubCategory> GetSubCategoryCodeByCategoryCode(string MerchandiseCategoryID)
        {

            GeneralItemMarchandiseSubCategorySearchRequest searchRequest = new GeneralItemMarchandiseSubCategorySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.MerchandiseCategoryID = Convert.ToInt32(MerchandiseCategoryID);

            List<GeneralItemMarchandiseSubCategory> listOrganisationDepartmentMaster = new List<GeneralItemMarchandiseSubCategory>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> baseEntityCollectionResponse = _GeneralItemMarchandiseSubCategoryBA.GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected List<GeneralItemMarchandiseBaseCategory> GetBaseCategoryCodeBySubCategoryCode(string MerchandiseSubCategoryID)
        {

            GeneralItemMarchandiseBaseCategorySearchRequest searchRequest = new GeneralItemMarchandiseBaseCategorySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.MerchantiseSubCategoryID = Convert.ToInt32(MerchandiseSubCategoryID);

            List<GeneralItemMarchandiseBaseCategory> listOrganisationDepartmentMaster = new List<GeneralItemMarchandiseBaseCategory>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> baseEntityCollectionResponse = _GeneralItemMarchandiseBaseCategoryBA.GetGeneralItemMerchantiseBaseCategoryCodeByCategoryCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }


        //Dropdown for General Item Marchandise Group
        protected List<GeneralItemMarchandiseGroup> GetListGeneralItemMarchandiseGroup()
        {
            GeneralItemMarchandiseGroupSearchRequest searchRequest = new GeneralItemMarchandiseGroupSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemMarchandiseGroup> listAdmin = new List<GeneralItemMarchandiseGroup>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> baseEntityCollectionResponse = _GeneralItemMarchandiseGroupBA.GetGeneralItemMarchandiseGroupSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }
        //Dropdown for General Item Merchantise Department
        protected List<GeneralItemMerchantiseDepartment> GetListGeneralItemMerchantiseDepartment()
        {
            GeneralItemMerchantiseDepartmentSearchRequest searchRequest = new GeneralItemMerchantiseDepartmentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemMerchantiseDepartment> listAdmin = new List<GeneralItemMerchantiseDepartment>();
            IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> baseEntityCollectionResponse = _GeneralItemMerchantiseDepartmentBA.GetGeneralItemMerchantiseDepartmentSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }

        //Dropdown for General Item Merchantise Department
        protected List<GeneralItemMerchantiseCategory> GetListGeneralItemMerchantiseCategory()
        {
            GeneralItemMerchantiseCategorySearchRequest searchRequest = new GeneralItemMerchantiseCategorySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemMerchantiseCategory> listAdmin = new List<GeneralItemMerchantiseCategory>();
            IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> baseEntityCollectionResponse = _GeneralItemMerchantiseCategoryBA.GetGeneralItemMerchantiseCategorySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }
        //Dropdown for General Item Merchantise Department
        protected List<GeneralItemMarchandiseSubCategory> GetListGeneralItemMerchantiseSubCategory()
        {
            GeneralItemMarchandiseSubCategorySearchRequest searchRequest = new GeneralItemMarchandiseSubCategorySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemMarchandiseSubCategory> listAdmin = new List<GeneralItemMarchandiseSubCategory>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> baseEntityCollectionResponse = _GeneralItemMarchandiseSubCategoryBA.GetGeneralItemMarchandiseSubCategorySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }
        [HttpPost]
        public JsonResult GetGeneralItemByCategoryCode(string ItemCategoryCode)
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
            model.GeneralItemCategoryMasterDTO = new GeneralItemCategoryMaster();
            model.GeneralItemCategoryMasterDTO.ItemCategoryCode = Convert.ToString(ItemCategoryCode);
            //model.GeneralItemCategoryMasterDTO.VendorID = Convert.ToInt32(GeneralVendorID);

            model.GeneralItemCategoryMasterDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralItemCategoryMaster> response = _GeneralItemCategoryMasterBA.GetGeneralItemByCategoryCode(model.GeneralItemCategoryMasterDTO);
            if (response != null && response.Entity != null)
            {

                model.GeneralItemCategoryMasterDTO.IsConsumable = response.Entity.IsConsumable;
                model.GeneralItemCategoryMasterDTO.IsMachine = response.Entity.IsMachine;
                model.GeneralItemCategoryMasterDTO.IsToner = response.Entity.IsToner;
            }
            return Json(model.GeneralItemCategoryMasterDTO, JsonRequestBehavior.AllowGet);
        }
        //Dropdown for General Item Merchantise Department
        protected List<GeneralItemMarchandiseBaseCategory> GetListGeneralItemMerchantiseBaseCategory()
        {
            GeneralItemMarchandiseBaseCategorySearchRequest searchRequest = new GeneralItemMarchandiseBaseCategorySearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralItemMarchandiseBaseCategory> listAdmin = new List<GeneralItemMarchandiseBaseCategory>();
            IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> baseEntityCollectionResponse = _GeneralItemMarchandiseBaseCategoryBA.GetGeneralItemMarchandiseBaseCategorySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }

        public IEnumerable<GeneralItemCategoryMaster> GetGeneralItemCategoryMaster(out int TotalRecords)
        {
            GeneralItemCategoryMasterSearchRequest searchRequest = new GeneralItemCategoryMasterSearchRequest();
            List<GeneralItemCategoryMaster> listGeneralItemCategoryMaster = new List<GeneralItemCategoryMaster>();
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

            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollectionResponse = _GeneralItemCategoryMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemCategoryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralItemCategoryMaster;
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

                IEnumerable<GeneralItemCategoryMaster> filteredLocationMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ItemCategoryDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ItemCategoryDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.ItemCategoryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ItemCategoryCode Like '%" + param.sSearch + "%' or A.ItemCategoryDescription Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;


                filteredLocationMaster = GetGeneralItemCategoryMaster(out TotalRecords);

                if ((filteredLocationMaster.Count()) == 0)
                {
                    filteredLocationMaster = new List<GeneralItemCategoryMaster>();
                    TotalRecords = 0;
                }

                var records = filteredLocationMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.ItemCategoryDescription.ToString(), c.ItemCategoryCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsConsumable), Convert.ToString(c.IsMachine), Convert.ToString(c.IsToner) };

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