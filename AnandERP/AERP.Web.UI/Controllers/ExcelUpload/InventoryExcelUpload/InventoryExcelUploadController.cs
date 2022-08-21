using AERP.Base.DTO;
using AERP.DTO;
//using AERP.ServiceAccess;
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
using System.Web.Hosting;
using System.Data;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;

namespace AERP.Web.UI.Controllers
{
    public class InventoryExcelUploadController : BaseController
    {
        InventoryExcelUploadBA _InventoryExcelUploadBA= null;
        private readonly ILogger _logException;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryExcelUploadController()
        {
            _InventoryExcelUploadBA = new InventoryExcelUploadBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            return View("/Views/ExcelUpload/InventoryExcelUpload/Index.cshtml", model);
        }
        public ActionResult ItemMasterStoreData()
        {
            InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            return View("/Views/ExcelUpload/InventoryExcelUpload/ItemMasterStoreData.cshtml", model);
        }
        public ActionResult ItemMasterMerchandiseCategory()
        {
            InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            return View("/Views/ExcelUpload/InventoryExcelUpload/ItemMasterMerchandiseCategory.cshtml", model);
        }
        public ActionResult ItemMasterPrice()
        {
            InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            return View("/Views/ExcelUpload/InventoryExcelUpload/ItemMasterPrice.cshtml", model);
        }
        public ActionResult VendorMasterMerchandiseCategory()
        {
            InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            return View("/Views/ExcelUpload/InventoryExcelUpload/VendorMasterMerchandiseCategory.cshtml", model);
        }
        public ActionResult GeneralItemMaster()
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
            return View("/Views/ExcelUpload/InventoryExcelUpload/GeneralItemMaster.cshtml", model);
        }
        public ActionResult VendorMaster()
        {
            VendorMasterViewModel model = new VendorMasterViewModel();
            if (TempData["_errorMsg"] != null)
            {
                model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
            }
            else
            {
                model.errorMessage = "NoMessage";
            }
            return View("/Views/ExcelUpload/InventoryExcelUpload/VendorMaster.cshtml", model);
        }
        public ActionResult GeneralItemCategoryMaster()
        {
            GeneralItemCategoryMasterViewModel model = new GeneralItemCategoryMasterViewModel();
            return View("/Views/ExcelUpload/InventoryExcelUpload/GeneralItemCategoryMaster.cshtml", model);
        }
        public FileResult DownloadVendorMasterMapCategoryExcel()
        {

            string FileName = "VendorMasterMapCategoryExcel.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateVendorMasterMapCategoryExcel(filePath);
            InsertVendorMasterMapCategoryExcel(filePath);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateVendorMasterMapCategoryExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Vendor Master and Category" };

                InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
                model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                model.InventoryExcelUploadDTO.ExcelSheetName = "VendorMasterAndMarchendiseCategory";
                IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.GetDataValidationListsForInventoryExcel(model.InventoryExcelUploadDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryExcelUploadDTO.MarchendiseCategoryList = response.Entity.MarchendiseCategoryList;
                    model.InventoryExcelUploadDTO.VendorNumberList = response.Entity.VendorNumberList;
                }

                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "B3:B100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.MarchendiseCategoryList, "\"")),
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

                //DataValidation dataValidation3 = new DataValidation
                //{
                //    Type = DataValidationValues.Whole,
                //    AllowBlank = true,
                //    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A3:A100" },
                //    Formula1 = new Formula1("1"),
                //    Formula2 = new Formula2("99999"),
                //    ShowErrorMessage = true,
                //    ErrorStyle = DataValidationErrorStyleValues.Stop,
                //    ErrorTitle = new StringValue("Incorrect Value"),
                //    Error = new StringValue("Please enter numeric value.")
                //};
                //DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                //dvs3.Count = dvs3.Count + 1;
                //dvs3.Append(dataValidation3);

                DataValidation dataValidation4 = new DataValidation
                {
                    Type = DataValidationValues.Whole,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "C3:C100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs4 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs4.Count = dvs4.Count + 1;
                dvs4.Append(dataValidation4);

                DataValidation dataValidation5 = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "B3:B100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.MarchendiseCategoryList, "\"")),
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
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A3:A100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.VendorNumberList, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs6 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs6.Count = dvs6.Count + 1;
                dvs6.Append(dataValidation6);


                //DataValidations dvs6 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                //if (dvs6 != null)
                //{
                //    dvs6.Count = dvs6.Count + 1;
                //    dvs6.Append(dataValidation6);
                //}
                //else
                //{
                //    DataValidations newDVs = new DataValidations();
                //    newDVs.Append(dataValidation6);
                //    newDVs.Count = 1;
                //    worksheetPart.Worksheet.Append(newDVs);
                //}


                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertVendorMasterMapCategoryExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Vendor Number", "Merchandise Category", "Lead Time" };

            string[] ColumnsData = new string[] { "A", "B", "C"};
            InsertTextInExcel(fileName, "", "A", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }

        [HttpPost]
        public ActionResult UploadExcelForVendorMerchandiseCategory(InventoryExcelUploadViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryExcelUploadDTO != null)
                {
                    UploadExcelForVendorMerchandiseCategory();
                    model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                    //model.InventoryExcelUploadDTO.ID = model.ID;
                    model.InventoryExcelUploadDTO.XMLstring = xmlParameter;
                    model.InventoryExcelUploadDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.InsertVendorMasterMapCategoryExcel(model.InventoryExcelUploadDTO);
                        model.InventoryExcelUploadDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    else if (IsExcelValid == false)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.InventoryExcelUploadDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("VendorMasterMerchandiseCategory", "InventoryExcelUpload");
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
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "InventoryExcelUpload");
            }

        }

        public void UploadExcelForVendorMerchandiseCategory()
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
                                foreach (Cell cell in rows.ElementAt(0))
                                {
                                    if (
                                        // (GetCellValue(doc, cell)) == "" ||
                                       
                                        (GetCellValue(doc, cell)) == "Vendor Number" ||
                                        (GetCellValue(doc, cell)) == "Merchandise Category" ||
                                        (GetCellValue(doc, cell)) == "Lead Time")
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
                                    dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                                    RemoveDuplicateRows(dt, "Vendor Number");




                                    if (extension == ".xls" || extension == ".xlsx")
                                    {
                                        if (
                                            //dt.Columns[0].ColumnName != " " ||
                                      
                                        dt.Columns[0].ColumnName != "Vendor Number" ||
                                        dt.Columns[1].ColumnName != "Merchandise Category" ||
                                        dt.Columns[2].ColumnName != "Lead Time")
                                        {
                                            IsExcelValid = false;
                                            errorMessage = "Invalid excel column,warning";
                                        }
                                    }
                                    if (IsExcelValid == true)
                                    {
                                        long result;


                                        //while (dReader.Read())
                                        for (int i = 0; i < (dt.Rows.Count); i++)
                                        {
                                            if (dt.Rows[i]["Vendor Number"].ToString().Trim().Length >=1)
                                            {
                                                xmlParameter = xmlParameter + "<row><VendorName></VendorName><VendorNumber>" + dt.Rows[i]["Vendor Number"].ToString().Trim() + "</VendorNumber><MerchandiseCategory>" + dt.Rows[i]["Merchandise Category"].ToString().Trim() + "</MerchandiseCategory><LeadTime>" + dt.Rows[i]["Lead Time"].ToString().Trim() + "</LeadTime></row>";

                                            }
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

        //Code Ends for Vendormaster Map categoryExcel

        public FileResult DownloadItemMasterMapCategoryExcel()
        {

            string FileName = "ItemMasterMapCategoryExcel.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateItemMasterMapCategoryExcel(filePath);
            InsertItemMasterMapCategoryExcel(filePath);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateItemMasterMapCategoryExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Item Master and Category" };

                InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
                model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                model.InventoryExcelUploadDTO.ExcelSheetName = "ItemMasterAndMarchendiseCategory";
                IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.GetDataValidationListsForInventoryExcel(model.InventoryExcelUploadDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryExcelUploadDTO.MarchendiseCategoryList = response.Entity.MarchendiseCategoryList;
                }

                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "C3:C100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.MarchendiseCategoryList, "\"")),
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

                DataValidation dataValidation3 = new DataValidation
                {
                    Type = DataValidationValues.Whole,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "B3:B100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs3.Count = dvs3.Count + 1;
                dvs3.Append(dataValidation3);

                //DataValidation dataValidation4 = new DataValidation
                //{
                //    Type = DataValidationValues.Whole,
                //    AllowBlank = true,
                //    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "D3:D100" },
                //    Formula1 = new Formula1("1"),
                //    Formula2 = new Formula2("99999"),
                //    ShowErrorMessage = true,
                //    ErrorStyle = DataValidationErrorStyleValues.Stop,
                //    ErrorTitle = new StringValue("Incorrect Value"),
                //    Error = new StringValue("Please enter numeric value.")
                //};
                //DataValidations dvs4 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                //dvs4.Count = dvs4.Count + 1;
                //dvs4.Append(dataValidation4);

                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertItemMasterMapCategoryExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Item Name", "Item Number", "Merchandise Category" };

            string[] ColumnsData = new string[] { "A", "B", "C" };

            InsertTextInExcel(fileName, "", "A", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }
        [HttpPost]
        public ActionResult UploadExcelForItemMasterMapCategoryExcel(InventoryExcelUploadViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryExcelUploadDTO != null)
                {
                    UploadExcelForItemMasterMapCategoryExcel();
                    model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                    //model.InventoryExcelUploadDTO.ID = model.ID;
                    model.InventoryExcelUploadDTO.XMLstring = xmlParameter;
                    model.InventoryExcelUploadDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.InsertItemMasterMapCategoryExcel(model.InventoryExcelUploadDTO);
                        model.InventoryExcelUploadDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    else if (IsExcelValid == false)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.InventoryExcelUploadDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("ItemMasterMerchandiseCategory", "InventoryExcelUpload");
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
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "InventoryExcelUpload");
            }

        }

        public void UploadExcelForItemMasterMapCategoryExcel()
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


                                foreach (Cell cell in rows.ElementAt(0))
                                {
                                    if (
                                     (GetCellValue(doc, cell)) == "Item Name" ||
                                     (GetCellValue(doc, cell)) == "Item Number" ||
                                     (GetCellValue(doc, cell)) == "Merchandise Category")
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
                                        dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                                        RemoveDuplicateRows(dt, "Item Name");

                                        if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            if (
                                               dt.Columns[0].ColumnName != "Item Name" ||
                                               dt.Columns[1].ColumnName != "Item Number" ||
                                               dt.Columns[2].ColumnName != "Merchandise Category")
                                            //dt.Columns[3].ColumnName != "Lead Time")
                                            {
                                                IsExcelValid = false;
                                                errorMessage = "Invalid excel column,warning";
                                            }
                                        }
                                        if (IsExcelValid == true)
                                        {
                                            long result;


                                            //while (dReader.Read())
                                            for (int i = 0; i < (dt.Rows.Count); i++)
                                            {
                                                if (dt.Rows[i]["Item Number"].ToString().Trim().Length > 0 || dt.Rows[i]["Item Name"].ToString().Trim().Length > 1)
                                                {
                                                    xmlParameter = xmlParameter + "<row><ItemName>" + dt.Rows[i]["Item Name"].ToString().Trim() + "</ItemName><ItemNumber>" + dt.Rows[i]["Item Number"].ToString().Trim() + "</ItemNumber><MerchandiseCategory>" + dt.Rows[i]["Merchandise Category"].ToString().Trim() + "</MerchandiseCategory><LeadTime>0</LeadTime></row>";
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

        //Code ends for Item master MAp Ctaegory Excel


        //Code ends For Price Report

        public FileResult DownloadItemMasterStoreDataExcel()
        {

            string FileName = "ItemMasterStoreDateExcel.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateItemMasterStoreDataExcel(filePath);
            InsertItemMasterStoreDataExcel(filePath);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateItemMasterStoreDataExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Item Store Date" };

                InventoryExcelUploadViewModel model = new InventoryExcelUploadViewModel();
                model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                model.InventoryExcelUploadDTO.ExcelSheetName = "ItemMasterStoreData";
                IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.GetDataValidationListsForInventoryExcel(model.InventoryExcelUploadDTO);
                if (response != null && response.Entity != null)
                {
                    model.InventoryExcelUploadDTO.UnitsList = response.Entity.UnitsList;
                    model.InventoryExcelUploadDTO.OrderingdayList = response.Entity.OrderingdayList;
                }

                DataValidation dataValidation = new DataValidation
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "C3:C100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.UnitsList, "\"")),
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
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "H3:H100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.OrderingdayList, "\"")),
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
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "I3:I100" },
                    Formula1 = new Formula1(string.Concat("\"", model.InventoryExcelUploadDTO.OrderingdayList, "\"")),
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
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "F3:F100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs3.Count = dvs3.Count + 1;
                dvs3.Append(dataValidation3);

                DataValidation dataValidation4 = new DataValidation
                {
                    Type = DataValidationValues.Decimal,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "G3:G100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs4 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs4.Count = dvs4.Count + 1;
                dvs4.Append(dataValidation4);

                DataValidation dataValidation5 = new DataValidation
                {
                    Type = DataValidationValues.Whole,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "B3:B100" },
                    Formula1 = new Formula1("1"),
                    Formula2 = new Formula2("99999"),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please enter numeric value.")
                };
                DataValidations dvs5 = worksheetPart.Worksheet.GetFirstChild<DataValidations>();
                dvs5.Count = dvs5.Count + 1;
                dvs5.Append(dataValidation5);

                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertItemMasterStoreDataExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Item Name", "Item Number", "Store", "Listing Date", "Delisting Date", "Reorder Point", "Safty Stock Point", "Ordering Day", "Delivery Day", "Facing", "Shelf Number" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

            InsertTextInExcel(fileName, "", "A", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }

        [HttpPost]
        public ActionResult UploadExcelForItemMasterStoreDataExcel(InventoryExcelUploadViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryExcelUploadDTO != null)
                {
                    UploadExcelForItemMasterStoreDataExcel();
                    model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                    //model.InventoryExcelUploadDTO.ID = model.ID;
                    model.InventoryExcelUploadDTO.XMLstring = xmlParameter;
                    model.InventoryExcelUploadDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.InsertItemMasterStoreDataExcel(model.InventoryExcelUploadDTO);
                        model.InventoryExcelUploadDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    else if (IsExcelValid == false)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.InventoryExcelUploadDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("ItemMasterStoreData", "InventoryExcelUpload");
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
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "InventoryExcelUpload");
            }

        }

        public void UploadExcelForItemMasterStoreDataExcel()
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
                                foreach (Cell cell in rows.ElementAt(0))
                                {
                                    if (
                                        (GetCellValue(doc, cell)) == "Item Name" ||
                                        (GetCellValue(doc, cell)) == "Item Number" ||
                                        (GetCellValue(doc, cell)) == "Store" ||
                                        (GetCellValue(doc, cell)) == "Listing Date" ||
                                        (GetCellValue(doc, cell)) == "Delisting Date" ||
                                        (GetCellValue(doc, cell)) == "Reorder Point" ||
                                        (GetCellValue(doc, cell)) == "Safty Stock Point" ||
                                        (GetCellValue(doc, cell)) == "Ordering Day" ||
                                        (GetCellValue(doc, cell)) == "Delivery Day" ||
                                        (GetCellValue(doc, cell)) == "Facing" ||
                                         (GetCellValue(doc, cell)) == "Shelf Number")
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
                                        dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                                        RemoveDuplicateRows(dt, "Item Name");




                                        if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            if (
                                            dt.Columns[0].ColumnName != "Item Name" ||
                                            dt.Columns[1].ColumnName != "Item Number" ||
                                            dt.Columns[2].ColumnName != "Store" ||
                                            dt.Columns[3].ColumnName != "Listing Date" ||
                                            dt.Columns[4].ColumnName != "Delisting Date" ||
                                            dt.Columns[5].ColumnName != "Reorder Point" ||
                                            dt.Columns[6].ColumnName != "Safty Stock Point" ||
                                            dt.Columns[7].ColumnName != "Ordering Day" ||
                                            dt.Columns[8].ColumnName != "Delivery Day" ||
                                            dt.Columns[9].ColumnName != "Facing" ||
                                            dt.Columns[10].ColumnName != "Shelf Number")
                                            {
                                                IsExcelValid = false;
                                                errorMessage = "Invalid excel column,warning";
                                            }
                                        }
                                        if (IsExcelValid == true)
                                        {
                                            long result;


                                            //while (dReader.Read())
                                            for (int i = 0; i < (dt.Rows.Count); i++)
                                            {
                                                if((dt.Rows[i]["Item Number"].ToString().Trim().Length > 0 || dt.Rows[i]["Item Name"].ToString().Trim().Length > 1))
                                                { 
                                                //if (dt.Rows[i]["Listing Date"].ToString()!=null ||dt.Rows[i]["Listing Date"].ToString()!=""||dt.Rows[i]["Listing Date"].ToString()!=string.em)
                                                double d = double.Parse(dt.Rows[i]["Listing Date"].ToString());
                                                DateTime conv = DateTime.FromOADate(d);
                                                string date = conv.ToString("yyyy-MM-dd");

                                                if (!ValidateDate(date))
                                                {
                                                    int RowNo = i + 2;
                                                    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Wrong Date format in row " + RowNo + "');", true);
                                                    TempData["Message"] = "You are not authorized.";
                                                    return;
                                                }

                                                double d1 = double.Parse(dt.Rows[i]["Delisting Date"].ToString());
                                                DateTime conv1 = DateTime.FromOADate(d1);
                                                string date1 = conv1.ToString("yyyy-MM-dd");
                                                if (!ValidateDate(date1))
                                                {
                                                    int RowNo = i + 3;
                                                    // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "InvalidArgs", "alert('Wrong Date format in row " + RowNo + "');", true);
                                                    TempData["Message"] = "You are not authorized.";
                                                    return;
                                                }



                                                if ((dt.Rows[i]["Item Number"].ToString().Trim().Length > 0 || dt.Rows[i]["Item Name"].ToString().Trim().Length > 1) && dt.Rows[i]["Store"].ToString().Trim().Length > 1)
                                                {
                                                    xmlParameter = xmlParameter + "<row><ItemName>" + dt.Rows[i]["Item Name"].ToString().Trim() + "</ItemName><ItemNumber>" + dt.Rows[i]["Item Number"].ToString().Trim() + "</ItemNumber><Store>" + dt.Rows[i]["Store"].ToString().Trim() + "</Store><ListingDate>" + date + "</ListingDate><DelistingDate>" + date1 + "</DelistingDate><ReorderPoint>" + dt.Rows[i]["Reorder Point"].ToString().Trim() + "</ReorderPoint><SaftyStockPoint>" + dt.Rows[i]["Safty Stock Point"].ToString().Trim() + "</SaftyStockPoint><OrderingDay>" + dt.Rows[i]["Ordering Day"].ToString().Trim() + "</OrderingDay><DeliveryDay>" + dt.Rows[i]["Delivery Day"].ToString().Trim() + "</DeliveryDay><Facing>" + dt.Rows[i]["Facing"].ToString().Trim() + "</Facing><ShelfNumber>" + dt.Rows[i]["Shelf Number"].ToString().Trim() + "</ShelfNumber><OrderingDayCode>0</OrderingDayCode><DeliveryDayCode>0</DeliveryDayCode></row>";

                                                }

                                            }
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

        private bool ValidateDate(string date)
        {
            try
            {
                string[] dateParts = date.Split('-');
                DateTime testDate = new DateTime(Convert.ToInt32(dateParts[0]), Convert.ToInt32(dateParts[1]), Convert.ToInt32(dateParts[2]));
                return true;
            }
            catch
            {
                return false;
            }
        }


        [HttpPost]
        public ActionResult UploadExcelForPriceReport(InventoryExcelUploadViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryExcelUploadDTO != null)
                {
                    UploadExcelForPrice();
                    model.InventoryExcelUploadDTO.ConnectionString = _connectioString;
                    //model.InventoryExcelUploadDTO.ID = model.ID;
                    model.InventoryExcelUploadDTO.XMLstring = xmlParameter.Replace("&", "[and]");
                    model.InventoryExcelUploadDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<InventoryExcelUpload> response = _InventoryExcelUploadBA.InsertItemMasterPriceReportExcel(model.InventoryExcelUploadDTO);
                        model.InventoryExcelUploadDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    else if (IsExcelValid == false)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.InventoryExcelUploadDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.InventoryExcelUploadDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("ItemMasterPrice", "InventoryExcelUpload");
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
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return RedirectToAction("Index", "InventoryExcelUpload");
            }

        }

        public void UploadExcelForPrice()
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


                                foreach (Cell cell in rows.ElementAt(0))
                                {
                                    if (
                                        (GetCellValue(doc, cell)) == "Item Number" ||
                                        (GetCellValue(doc, cell)) == "Item Name" ||
                                        (GetCellValue(doc, cell)) == "HSN Code" ||
                                        (GetCellValue(doc, cell)) == "Item Category Code" ||
                                        (GetCellValue(doc, cell)) == "Site" ||
                                        (GetCellValue(doc, cell)) == "Order UoM" ||
                                        (GetCellValue(doc, cell)) == "Cost per Order Unit" ||
                                        (GetCellValue(doc, cell)) == "Sales UoM" ||
                                        (GetCellValue(doc, cell)) == "Sales Price")
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
                                        dt.Rows.RemoveAt(0); //...so i'm taking it out here.

                                        RemoveDuplicateRows(dt, "Item Name");

                                        if (extension == ".xls" || extension == ".xlsx")
                                        {
                                            if (
                                                  dt.Columns[0].ColumnName != "Item Number" ||
                                                  dt.Columns[1].ColumnName != "Item Name" ||
                                                  dt.Columns[2].ColumnName != "HSN Code" ||
                                                  dt.Columns[3].ColumnName != "Item Category Code" ||
                                                  dt.Columns[4].ColumnName != "Site" ||
                                                  dt.Columns[5].ColumnName != "Order UoM" ||
                                                  dt.Columns[6].ColumnName != "Cost per Order Unit" ||
                                                  dt.Columns[7].ColumnName != "Sales UoM" ||
                                                  dt.Columns[8].ColumnName != "Sales Price")
                                            {
                                                IsExcelValid = false;
                                                errorMessage = "Invalid excel column,warning";
                                            }
                                        }
                                        if (IsExcelValid == true)
                                        {
                                            long result;


                                            //while (dReader.Read())
                                            for (int i = 0; i < (dt.Rows.Count); i++)
                                            {
                                                xmlParameter = xmlParameter + "<row><ItemNumber>" + dt.Rows[i]["Item Number"].ToString().Trim() + "</ItemNumber><ItemDescription>" + dt.Rows[i]["Item Name"].ToString().Trim() + "</ItemDescription><Site>" + dt.Rows[i]["Site"].ToString().Trim() + "</Site><OrderUOMCode>" + dt.Rows[i]["Order UoM"].ToString().Trim() + "</OrderUOMCode><CostPerOrderingUnit>" + dt.Rows[i]["Cost per Order Unit"].ToString().Trim() + "</CostPerOrderingUnit><SaleUOMCode>" + dt.Rows[i]["Sales UoM"].ToString().Trim() + "</SaleUOMCode><SalesPrice>" + dt.Rows[i]["Sales Price"].ToString().Trim() + "</SalesPrice><GeneralItemMasterID>" + 0 + "</GeneralItemMasterID><GeneralItemsupplierDataID>" + 0 + "</GeneralItemsupplierDataID><GeneralUnitsID>" + 0 + "</GeneralUnitsID></row>";
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
        #endregion

        // Non-Action Method
        #region Methods
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

                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1" || cell.CellReference.Value == "G1" || cell.CellReference.Value == "H1" || cell.CellReference.Value == "I1" || cell.CellReference.Value == "J1" || cell.CellReference.Value == "K1" || cell.CellReference.Value == "L1")
                {
                    cell.StyleIndex = 5;
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
                    new Font(                                                               // Index 2 – The Times Roman font. with 16 size
                        new FontSize() { Val = 16 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 – The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 – The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(                                                           // Index 2 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "00B050" } }
                        ) { PatternType = PatternValues.Solid })
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
                        ) { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        ) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 – The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 – Bold 
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 – Italic
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 – Times Roman
                    new CellFormat() { FontId = 0, FillId = 2, BorderId = 0, ApplyFill = true },       // Index 4 – Yellow Fill
                    new CellFormat(                                                                   // Index 5 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    ) { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 6 – Border
                )
            ); // return
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

        // AjaxHandler Method
        #region
        #endregion
    }
}

