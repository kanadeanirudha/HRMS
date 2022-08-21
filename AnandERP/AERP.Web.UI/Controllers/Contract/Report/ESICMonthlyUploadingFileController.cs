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
using System.Globalization;

namespace AERP.Web.UI.Controllers
{
    public class ESICMonthlyUploadingFileController : BaseController
    {
        ESICMonthlyUploadingFileBA _ESICMonthlyUploadingFileBA = null;
        private readonly ILogger _logException;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        ActionModeEnum actionModeEnum;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public ESICMonthlyUploadingFileController()
        {
            _ESICMonthlyUploadingFileBA = new ESICMonthlyUploadingFileBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                ESICMonthlyUploadingFileViewModel model = new ESICMonthlyUploadingFileViewModel();

                List<SelectListItem> MonthList = new List<SelectListItem>();
                DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                ViewBag.MonthList = new SelectList(MonthList, "Value", "Text");
                List<SelectListItem> li_MonthList = new List<SelectListItem>();
                li_MonthList.Add(new SelectListItem { Text = "--Select month -- ", Value = "0" });
                for (int i = 1; i < 13; i++)
                {
                    ViewBag.MonthList = new SelectList(info.GetMonthName(i), i.ToString());
                    li_MonthList.Add(new SelectListItem { Text = info.GetMonthName(i), Value = (i).ToString() });
                }
                ViewData["MonthName"] = new SelectList(li_MonthList, "Value", "Text");
                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> li_YearList = new List<SelectListItem>();
                ViewBag.YearList = new SelectList(li_YearList, "Value", "Text");
                li_YearList.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_YearList.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["MonthYear"] = new SelectList(li_YearList, "Value", "Text");

                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
                return View("/Views/Contract/Report/ESICMonthlyUploadingFile/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }


        //Code Ends for Vendormaster Map categoryExcel

        public FileResult DownloadExcel(byte MonthName, string MonthYear)
        {

            string FileName = "ESICMonthlyUploadingFile.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            InsertExcelFile(filePath, MonthName, MonthYear);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateExcelFile(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "ESIC Monthly Uploading File" };
                ESICMonthlyUploadingFileViewModel model = new ESICMonthlyUploadingFileViewModel();
                model.ESICMonthlyUploadingFile.ConnectionString = _connectioString;
                model.ESICMonthlyUploadingFile.ExcelSheetName = "ESICMonthlyUploadingFile";
                sheets.Append(sheet);
                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }
        public void InsertExcelFile(string fileName, byte MonthName, string MonthYear)
        {
            string[] HeaderData = new string[] { "IP Number (10 Digits)", "IP Name( Only alphabets and space )", "No of Days for which wages paid/payable during the month", "Total Monthly Wages", "Reason Code for Zero workings days(numeric only; provide 0 for all other reasons- Click on the link for reference)", " Last Working Day( Format DD/MM/YYYY  or DD-MM-YYYY)" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F" };
            InsertTextInExcel(fileName, "", "A", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
            ESICMonthlyUploadingFileViewModel model = new ESICMonthlyUploadingFileViewModel();
            uint index = 3;
            model.ESICMonthlyUploadingFileList = GetESICMonthlyUploadingFileList(MonthName, MonthYear);
            if (model.ESICMonthlyUploadingFileList.Count > 0)
            {
                for (int i = 0; i < model.ESICMonthlyUploadingFileList.Count; i++)
                {
                    InsertTextInExcel(fileName, model.ESICMonthlyUploadingFileList[i].ESICNumber, "A", index);
                    InsertTextInExcel(fileName, model.ESICMonthlyUploadingFileList[i].EmployeeName, "B", index);
                    InsertTextInExcel(fileName, Convert.ToString(model.ESICMonthlyUploadingFileList[i].WorkingDays), "C", index);
                    InsertTextInExcel(fileName, Convert.ToString(model.ESICMonthlyUploadingFileList[i].TotalAmountofWages), "D", index);
                    InsertTextInExcel(fileName, "0", "E", index);

                    index++;
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

                //Get the Worksheet instance.s
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);


                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);


                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1")
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
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "a8fffb" } }
                        )
                        { PatternType = PatternValues.Solid })
                ),
                new Columns
                (
                    new Column()
                    {
                        CustomWidth = true,
                        Width = 200
                    }
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
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 6 – Border
                )
            ); // return
        }




        public List<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileList(byte MonthName, string Monthyear)
        {
            try
            {
                List<ESICMonthlyUploadingFile> listESICMonthlyUploadingFile = new List<ESICMonthlyUploadingFile>();
                ESICMonthlyUploadingFileSearchRequest searchRequest = new ESICMonthlyUploadingFileSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                if (Monthyear != string.Empty)
                {
                    searchRequest.MonthName = MonthName;
                    searchRequest.Monthyear = Monthyear;
                    IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> baseEntityCollectionResponse = _ESICMonthlyUploadingFileBA.GetESICMonthlyUploadingFileDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listESICMonthlyUploadingFile = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listESICMonthlyUploadingFile;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        // AjaxHandler Method
        #region
        #endregion
    }
}

