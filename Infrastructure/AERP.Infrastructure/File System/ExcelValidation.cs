using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Data;
using AERP.Base.DTO;
using AERP.Common;

namespace AERP.Infrastructure
{
    public class ExcelValidation : IExcelValidation
    {
        /// <summary>
        /// Get the latest(Last updated) file from Shared location
        /// </summary>
        /// <param name="fileNameContains">file name(Intial/Access/Permission</param>
        /// <returns>Fully qualified file shared path</returns>
        public string GetFileName(string fileNameContains)
        {
            string fileName = string.Empty;
            string direcotryName = @"Content\Documents";
            //ConfigurationManager.AppSettings["excelFilesPath"];
            try
            {
                // Create a DirectoryInfo of the directory of the files to enumerate.
                DirectoryInfo DirInfo = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + direcotryName));

                // LINQ query to identify a last updated .xls/xlxs file base on file name argument.
                fileName = DirInfo.EnumerateFiles().Where(f => f.Name.Contains(fileNameContains)).Where(f => f.Extension.EndsWith(".xlsx") || f.Extension.EndsWith(".xls")).OrderByDescending(f => f.LastWriteTime).Select(f => f.Name).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory + direcotryName) + @"\" + fileName;
        }

        /// <summary>
        /// Get the data from excel and return data in reader
        /// </summary>
        /// <param name="fileType">Intial/Access/Permission</param>
        /// <returns></returns>
        public DataTable GetDataFromExcel(string fileName)
        {
            DataTable dataTable = new DataTable();
            OleDbDataReader reader = null;

            // Create the connection object
            OleDbConnection oledbConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0");
            try
            {
                if (oledbConn.State.Equals(System.Data.ConnectionState.Closed))
                {
                    oledbConn.Open();
                }
                // Open connection
                //oledbConn.Open();
                //OleDbDataReader reader;
                DataTable dtExcel = new DataTable();
                // Get the data table containg the schema guid.
                dtExcel = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                DataRow dr = dtExcel.Rows.Count > 0 ? dtExcel.Rows[0] : null;
                string sheetName = dr["Table_Name"] != null ? Convert.ToString(dr["Table_Name"]) : "";
                if (!string.IsNullOrEmpty(sheetName))
                {
                    //Create OleDbCommand object and select data from worksheet Sheet1
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", oledbConn);
                    reader = cmd.ExecuteReader();
                    if (reader != null && reader.HasRows)
                    {
                        dataTable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                reader.Close();
                oledbConn.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// Validate the method
        /// </summary>
        /// <param name="dr">Datareader Instance</param>
        /// <param name="columnName">Column to Validate</param>
        /// <param name="type">DataType of Databse column</param>
        /// <param name="lstExceptionInfo">reference type for Error collection</param>
        /// <param name="empIdColumn">Unique Identifier for exception</param>
        /// <returns></returns>
        public bool Isvalid(DataRow dr, string columnName, string type, ref List<MessageDTO> lstExceptionInfo, string empIdColumn, bool requiredField)
        {
            bool returnValue = false;
            //try
            //{
            //    switch (type)
            //    {
            //        case "string":
            //            string value = dr[columnName].ToString();
            //            if (string.IsNullOrEmpty(value) && requiredField)
            //            {
            //                throw new Exception(Resources.Error_NullReference);
            //            }
            //            returnValue = true;
            //            break;
            //        case "int":
            //            int intValue = Convert.ToInt32(dr[columnName]);
            //            if (intValue == 0 && requiredField)
            //            {
            //                throw new Exception(Resources.Error_NullReference);
            //            }

            //            if ((columnName.Equals(Resources.Initial_EmployeeID) || columnName.Equals(Resources.Permission_EmployeeID) || columnName.Equals(Resources.Access_EmployeeId)) && (intValue.ToString().Length < 6 || intValue.ToString().Length > 7))
            //            {
            //                throw new Exception(Resources.Error_EmployeeID);
            //            }
            //            returnValue = true;
            //            break;
            //        case "decimal":
            //            decimal decValue = 0;
            //            if (requiredField)
            //            {
            //                decValue = Convert.ToDecimal(dr[columnName]);
            //                if (decValue == 0)
            //                {
            //                    throw new Exception(Resources.Error_NullReference);
            //                }
            //                returnValue = true;
            //            }
            //            else
            //            {
            //                if (!string.IsNullOrEmpty(dr[columnName].ToString()))
            //                    decValue = Convert.ToDecimal(dr[columnName]);
            //                if (decValue == 0)
            //                    returnValue = false;
            //                else
            //                    returnValue = true;
            //            }


            //            break;
            //        case "DateTime":
            //            DateTime dtValue = Convert.ToDateTime(dr[columnName]);
            //            if (dtValue.ToShortDateString() == string.Empty && requiredField)
            //            {
            //                throw new Exception(Resources.Error_NullReference);
            //            }
            //            returnValue = true;
            //            break;
            //        default:
            //            returnValue = false;
            //            break;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //add current exception to the list.
            //    MessageDTO exceptInfo = new MessageDTO()
            //    {
            //        ExcelEmpID = Convert.ToString(dr[empIdColumn]),
            //        Title = columnName,
            //        ErrorMessage = ex.Message,
            //        MessageType = MessageTypeEnum.Error
            //    };
            //    lstExceptionInfo.Add(exceptInfo);
            //    returnValue = false;
            //}
            return returnValue;
        }
    }
}
