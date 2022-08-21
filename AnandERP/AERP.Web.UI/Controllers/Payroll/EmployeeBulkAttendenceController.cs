using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;
using System.IO;
using System.Configuration;
using AERP.ExceptionManager;
using AERP.DTO;
using System.Data;
using AERP.Base.DTO;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers.Payroll
{
    public class EmployeeBulkAttendenceController : BaseController
    {
        IEmployeeBulkAttendenceBA _EmployeeBulkAttendence = null;
        IEmployeeSalarySpanBA _IEmplyoeeSalarySpan = null;
        string _centreCode = string.Empty;
        string _designationId = string.Empty;
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
        int EmpCodeFlag;
        int FirstNameFlag;
        int LastNameFlag; int CentreCodeFlag;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeBulkAttendenceController()
        {
            _EmployeeBulkAttendence = new EmployeeBulkAttendenceBA();
            _IEmplyoeeSalarySpan = new EmployeeSalarySpanBA();
        }

        public ActionResult Index(string centerCode, string departmentID)
        {
            EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();
            int AdminRoleMasterID = 0;
            if (!string.IsNullOrEmpty(centerCode))
            {
                string[] splitCentreCode = centerCode.Split(':');
                model.CentreCode = splitCentreCode[0];
               // model.EntityLevel = splitCentreCode[1];
            }
            else
            {
                model.CentreCode = centerCode;
                //model.EntityLevel = null;
            }
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["HR Manager"]) > 0 && IsApplied == true))
            {
                //--------------------------------------For Centre Code list---------------------------------//
                List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
                model.EntityLevel = "Centre";

                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + "Centre";
                }

                List<EmployeeSalarySpan> ListOfSalarySpan = GetListSalarySpan();
                foreach (var item in ListOfSalarySpan)
                {
                    EmployeeBulkAttendenceMaster obj = new EmployeeBulkAttendenceMaster();
                    obj.SpanID = item.SpanID;
                    obj.Span = item.Span;
                    model.ListGetSalarySpan.Add(obj);
                }

                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
            }
            return View("/Views/Payroll/EmployeeBulkAttendence/Index.cshtml",model);
        }

        private List<EmployeeSalarySpan> GetListSalarySpan()
        {
            EmployeeSalarySpanSearchRequest searchRequest = new EmployeeSalarySpanSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<EmployeeSalarySpan> listTotalAttendence = new List<EmployeeSalarySpan>();
            IBaseEntityCollectionResponse<EmployeeSalarySpan> baseEntityCollectionResponse = _IEmplyoeeSalarySpan.GetSalarySpanList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listTotalAttendence = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listTotalAttendence;
        }

        public ActionResult List(string centerCode, string departmentID, string SpanID, string actionMode)
        {
            EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();
            model.CentreCode = centerCode;
            model.SelectedDepartmentID = departmentID;
            model.SpanID = Convert.ToInt32(SpanID);

            return PartialView("/Views/Payroll/EmployeeBulkAttendence/List.cshtml",model);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();
            try
            {
                model.EmployeeBulkAttendenceDTO = new EmployeeBulkAttendenceMaster();
                model.EmployeeBulkAttendenceDTO.ID = ID;
                model.EmployeeBulkAttendenceDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmployeeBulkAttendenceMaster> response = _EmployeeBulkAttendence.SelectByID(model.EmployeeBulkAttendenceDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeBulkAttendenceDTO.ID = response.Entity.ID;
                    model.EmployeeBulkAttendenceDTO.Span = response.Entity.Span;
                    model.EmployeeBulkAttendenceDTO.SpanID = response.Entity.SpanID;
                    model.EmployeeBulkAttendenceDTO.EmployeeName = response.Entity.EmployeeName;
                    model.EmployeeBulkAttendenceDTO.EmployeeCode = response.Entity.EmployeeCode;
                    model.EmployeeBulkAttendenceDTO.TotalAttendence = response.Entity.TotalAttendence;
                    model.EmployeeBulkAttendenceDTO.TotalOvertime = response.Entity.TotalOvertime;
                    model.EmployeeBulkAttendenceDTO.TotalDays = response.Entity.TotalDays;
                }
                return PartialView("/Views/Payroll/EmployeeBulkAttendence/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeBulkAttendenceViewModel model)
        {
            //  if (ModelState.IsValid)
            {
                if (model != null && model.EmployeeBulkAttendenceDTO != null)
                {
                    if (model != null && model.EmployeeBulkAttendenceDTO != null)
                    {
                        model.EmployeeBulkAttendenceDTO.ConnectionString = _connectioString;
                        model.EmployeeBulkAttendenceDTO.ID = model.ID;
                        model.EmployeeBulkAttendenceDTO.TotalAttendence = model.TotalAttendence;
                        model.EmployeeBulkAttendenceDTO.TotalOvertime = model.TotalOvertime;

                        model.EmployeeBulkAttendenceDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeBulkAttendenceMaster> response = _EmployeeBulkAttendence.UpdateEmployeeAttendence(model.EmployeeBulkAttendenceDTO);
                        model.EmployeeBulkAttendenceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.EmployeeBulkAttendenceDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            /*   else
               {
                   return Json("Please review your form");
               }*/
        }

        public FileResult Download(string CentreCode,string DepartmentID,int SpanID)
        {

            string FileName = "EmployeeBulkAttendenceExcel.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateSaleContractEmployeeExcel(filePath);
            InsertSaleContractEmployeeExcel(filePath);
            InsertEmployeeExcel(filePath, CentreCode, DepartmentID,SpanID);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        [HttpGet]
        public ActionResult Create(int EmployeeID,byte SpanId,string EmployeeName,string SpanName)
        {
            EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();
            model.EmployeeID = EmployeeID;
            model.SpanID = SpanId;
            model.EmployeeName = EmployeeName;
            model.Span = SpanName;
            return PartialView("/Views/Payroll/EmployeeBulkAttendence/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeBulkAttendenceViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.EmployeeBulkAttendenceDTO != null)
                {
                    model.EmployeeBulkAttendenceDTO.ConnectionString = _connectioString;
                    model.EmployeeBulkAttendenceDTO.TotalAttendence = model.TotalAttendence;
                    model.EmployeeBulkAttendenceDTO.TotalOvertime = model.TotalOvertime;
                    model.EmployeeBulkAttendenceDTO.EmployeeID = model.EmployeeID;
                    model.EmployeeBulkAttendenceDTO.SpanID = model.SpanID;

                    model.EmployeeBulkAttendenceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeBulkAttendenceMaster> response = _EmployeeBulkAttendence.InsertEmployeeAttendenceForSingleOne(model.EmployeeBulkAttendenceDTO);

                    model.EmployeeBulkAttendenceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EmployeeBulkAttendenceDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult UploadExcel(int SpanID)
        {
            EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();
            model.SpanID = SpanID;
            return PartialView("/Views/Payroll/EmployeeBulkAttendence/UploadExcel.cshtml", model);
        }

        [HttpPost]
        public ActionResult UploadExcel(EmployeeBulkAttendenceViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.EmployeeBulkAttendenceDTO != null)
                {
                    UploadExcelForEmployeeAttendence();


                    model.EmployeeBulkAttendenceDTO.ConnectionString = _connectioString;
                    model.EmployeeBulkAttendenceDTO.SpanID = model.SpanID;
                    model.EmployeeBulkAttendenceDTO.XMLString = xmlParameter;
                    model.EmployeeBulkAttendenceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (xmlParameter != string.Empty && xmlParameter != null && IsExcelValid == true)
                    {
                        IBaseEntityResponse<EmployeeBulkAttendenceMaster> response = _EmployeeBulkAttendence.InsertEmployeeBulkAttendenceExcelUpload(model.EmployeeBulkAttendenceDTO);

                        model.EmployeeBulkAttendenceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert); ;
                    }
                    else if (IsExcelValid == false)
                    {
                        model.EmployeeBulkAttendenceDTO.errorMessage = errorMessage;// "Invalide excel column,#FFCC80";
                    }
                    else if (xmlParameter == string.Empty || xmlParameter != null)
                    {
                        model.EmployeeBulkAttendenceDTO.errorMessage = errorMessage;// "No data found in excel,#FFCC80";
                    }

                    TempData["_errorMsg"] = model.EmployeeBulkAttendenceDTO.errorMessage;
                    xmlParameter = null;
                    IsExcelValid = true;
                    errorMessage = null;
                    return RedirectToAction("Index", "EmployeeBulkAttendence");
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
                return RedirectToAction("Index", "SaleContractEmployeeMaster");
            }
        }


        public void UploadExcelForEmployeeAttendence()
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

                                System.Data.DataTable dt = new System.Data.DataTable();
                                //Loop through the Worksheet rows.
                                foreach (Cell cell in rows.ElementAt(0))
                                {
                                    if (
                                        // (GetCellValue(doc, cell)) == "" ||
                                           

                                 ( GetCellValue(doc, cell)) == "Employee Name" ||
                                        (GetCellValue(doc, cell)) == "Employee Code" ||
                                        (GetCellValue(doc, cell)) == "Total Attendence" ||
                                        (GetCellValue(doc, cell)) == "Total Overtime"
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

                                    RemoveDuplicateRows(dt, "Employee Code");


                                    if (extension == ".xls" || extension == ".xlsx")
                                    {
                                        if (dt.Columns[0].ColumnName != "Employee Name" ||
                                            dt.Columns[1].ColumnName != "Employee Code" ||
                                            dt.Columns[2].ColumnName != "Total Attendence" ||
                                            dt.Columns[3].ColumnName != "Total Overtime" )
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

                                            if (dt.Rows[i]["Employee Name"].ToString().Trim().Length >= 1 || dt.Rows[i]["Employee Code"].ToString().Trim().Length >= 1 || dt.Rows[i]["Total Attendence"].ToString().Trim().Length >= 1 || dt.Rows[i]["Total Overtime"].ToString().Trim().Length >= 1)

                                            {

                                                string date1 = string.Empty; string date = string.Empty; string date3 = string.Empty;

                                                xmlParameter = xmlParameter + "<row><EmployeeName>" + dt.Rows[i]["Employee Name"] + "</EmployeeName><EmployeeCode>" + dt.Rows[i]["Employee Code"].ToString().Trim() + "</EmployeeCode><TotalAttendence>" + dt.Rows[i]["Total Attendence"].ToString().Trim() + "</TotalAttendence><TotalOvertime>" + dt.Rows[i]["Total Overtime"].ToString().Trim() + "</TotalOvertime></row>";

                                            }
                                            else if (dt.Rows[i]["Employee Name"].ToString().Trim().Length < 1 )
                                            {
                                                xmlParameter = string.Empty;
                                                FirstNameFlag = 1;
                                                break;
                                            }
                                            else if (dt.Rows[i]["Employee Code"].ToString().Trim().Length < 1 )
                                            {
                                                xmlParameter = string.Empty;
                                                LastNameFlag = 1;
                                                errorMessage = "Please Enter Last Name,warning";
                                                break;
                                            }
                                           
                                        }
                                    }
                                    if (xmlParameter.Length > 9)
                                    {
                                        xmlParameter = xmlParameter + "</rows>";
                                    }
                                    else
                                    {
                                        //if (EmpCodeFlag == 1)
                                        //{
                                        //    xmlParameter = string.Empty;
                                        //    errorMessage = "Please enter Emp Code,warning";
                                        //}
                                        //else
                                        if (FirstNameFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please enter First Name,warning";
                                        }

                                        else if (LastNameFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please enter Last Name,warning";
                                        }
                                        else if (CentreCodeFlag == 1)
                                        {
                                            xmlParameter = string.Empty;
                                            errorMessage = "Please Select Centre Code,warning";
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
                errorMessage = "Do not add same Data twice,#FFCC80";

            //Datatable which contains unique records will be return as output.

            return dTable;
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

        public void CreateSaleContractEmployeeExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Total Attendence Employee Excel" };

                 EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();
                 model.EmployeeBulkAttendenceDTO.ConnectionString = _connectioString;
                 model.EmployeeBulkAttendenceDTO.ExcelSheetName = "EmployeeBulkAttendenceExcel";

                /*
                 IBaseEntityResponse<SaleContractEmployeeMaster> response = _SaleContractEmployeeMasterBA.GetDataValidationListsForEmployeeMasterExcel(model.SaleContractEmployeeMasterDTO);
                 if (response != null && response.Entity != null)
                 {
                     model.SaleContractEmployeeMasterDTO.Title = response.Entity.Title;
                     model.SaleContractEmployeeMasterDTO.ESICZoneCode = response.Entity.ESICZoneCode;
                     model.SaleContractEmployeeMasterDTO.CentreCode = response.Entity.CentreCode;

                 }

                DataValidation dataValidation = new DataValidation();
                 {
                     Type = DataValidationValues.List,
                     AllowBlank = true,
                     SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A3:A100" },
                     Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.Title, "\"")),
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

                DataValidation dataValidation1 = new DataValidation();
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "M3:M100" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.ESICZoneCode, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs1 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs1 != null)
                {
                    dvs1.Count = dvs1.Count + 1;
                    dvs1.Append(dataValidation1);
                }
                else
                {
                    DataValidations newDVs1 = new DataValidations();
                    newDVs1.Append(dataValidation1);
                    newDVs1.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs1);
                }
                DataValidation dataValidation2 = new DataValidation();
               
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "P3:P500" },
                    Formula1 = new Formula1(string.Concat("\"", model.SaleContractEmployeeMasterDTO.CentreCode, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs2 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs2 != null)
                {
                    dvs2.Count = dvs2.Count + 1;
                    dvs2.Append(dataValidation2);
                }
                else
                {
                    DataValidations newDVs2 = new DataValidations();
                    newDVs2.Append(dataValidation2);
                    newDVs2.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs2);
                }
                DataValidation dataValidation3 = new DataValidation();
                
               {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "Q3:Q500" },
                    Formula1 = new Formula1(string.Concat("\"M,F\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs3 != null)
                {
                    dvs3.Count = dvs3.Count + 1;
                    dvs3.Append(dataValidation3);
                }
                else
                {
                    DataValidations newDVs3 = new DataValidations();
                    newDVs3.Append(dataValidation3);
                    newDVs3.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs3);
                }
                */
                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertSaleContractEmployeeExcel(string fileName)
        {
            string[] HeaderData = new string[] { "Employee Name","Employee Code","Total Attendence","Total Overtime" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D"};
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }

        protected List<EmployeeBulkAttendenceMaster> GetListOfEmployeeForDownloadExcel(out int TotalRecords, string CentreCode, string DepartmentID, int SpanID)
        {

            EmployeeBulkAttendenceMasterSearchRequest searchRequest = new EmployeeBulkAttendenceMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.DepartmentID = DepartmentID;
            searchRequest.SpanID = SpanID;
           
            List<EmployeeBulkAttendenceMaster> listOrganisationDepartmentMaster = new List<EmployeeBulkAttendenceMaster>();
            IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> baseEntityCollectionResponse = _EmployeeBulkAttendence.GetEmployeeListForDownloadExcel(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationDepartmentMaster;
        }


        protected List<EmployeeBulkAttendenceMaster> GetListOrganisationMasterCentreAndDepartmentWise(out int TotalRecords, string CentreCode, string DepartmentID, int SpanID)
        {

            EmployeeBulkAttendenceMasterSearchRequest searchRequest = new EmployeeBulkAttendenceMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.DepartmentID = DepartmentID;
            searchRequest.SpanID = SpanID;
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
                searchRequest.SortDirection =_sortDirection;
            }
            List<EmployeeBulkAttendenceMaster> listOrganisationDepartmentMaster = new List<EmployeeBulkAttendenceMaster>();
            IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> baseEntityCollectionResponse = _EmployeeBulkAttendence.GetEmployeeListCentreAndDepartmentWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;

            return listOrganisationDepartmentMaster;
        }

        public void InsertEmployeeExcel(string fileName,string CenterCode,string DepartmentID,int SpanID)
        {
            EmployeeBulkAttendenceViewModel model = new EmployeeBulkAttendenceViewModel();

            string[] ColumnsData = new string[] { "A", "B" };

            int TotalRecords;
            model.ListGetOrganisationDepartmentCentreAndDepartmentWise = GetListOfEmployeeForDownloadExcel(out TotalRecords,CenterCode, DepartmentID,SpanID);

            for(int i = 0; i < model.ListGetOrganisationDepartmentCentreAndDepartmentWise.Count; i++)
            {
                EmployeeBulkAttendenceMaster org = model.ListGetOrganisationDepartmentCentreAndDepartmentWise[i];
                string[] HeaderData = new string[] { org.EmployeeName, org.EmployeeCode };

                for (uint j = 0; j < HeaderData.Length; j++)
                {
                    InsertTextInExcel(fileName, HeaderData[j], ColumnsData[j],(uint)i+3);
                }
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

                if (cell.CellReference.Value == "A1" || cell.CellReference.Value == "B1" || cell.CellReference.Value == "C1" || cell.CellReference.Value == "D1" || cell.CellReference.Value == "E1" || cell.CellReference.Value == "F1" || cell.CellReference.Value == "G1" || cell.CellReference.Value == "H1" || cell.CellReference.Value == "I1" || cell.CellReference.Value == "J1" || cell.CellReference.Value == "K1" || cell.CellReference.Value == "L1" || cell.CellReference.Value == "M1" || cell.CellReference.Value == "N1" || cell.CellReference.Value == "O1" || cell.CellReference.Value == "P1" || cell.CellReference.Value == "Q1" || cell.CellReference.Value == "R1")
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
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true },
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }      // Index 6 – Border
                )
            ); // return
        }

        public ActionResult GetDepartmentByCentreCode(string SelectedCentreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
            string[] splited = SelectedCentreCode.Split(':');
            if (String.IsNullOrEmpty(SelectedCentreCode))
            {
                throw new ArgumentNullException("SelectedCentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCentreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode,string DepartmentID,string SpanID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<EmployeeBulkAttendenceMaster> filteredEmployeeBulkAttendence;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EmployeeCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeName Like '%" + param.sSearch + "%' or EmployeeCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            int Span_ID = 0;
            if (SpanID != "")
            {
                Span_ID = Convert.ToInt32(SpanID);
            }
            filteredEmployeeBulkAttendence = GetListOrganisationMasterCentreAndDepartmentWise(out TotalRecords, CentreCode, DepartmentID, Span_ID);

            var records = filteredEmployeeBulkAttendence.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeName), Convert.ToString(c.EmployeeCode), Convert.ToString(c.TotalAttendence), Convert.ToString(c.TotalOvertime), Convert.ToString(c.ID),Convert.ToString(c.EmployeeID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion

    }
}