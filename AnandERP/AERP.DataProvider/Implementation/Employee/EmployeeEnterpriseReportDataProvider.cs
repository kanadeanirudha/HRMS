using AMS.Base.DTO;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AMS.DataProvider
{
    public class EmployeeEnterpriseReportDataProvider : DBInteractionBase, IEmployeeEnterpriseReportDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeEnterpriseReportDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeEnterpriseReportDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AMSEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeEnterpriseReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeePerformanceMonitoringReportBySearch(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeEnterpriseReport>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeePerformanceMonitoringReport";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iLevel", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.Level));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode != null ? searchRequest.CentreCode : DBNull.Value.ToString()));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID != null ? searchRequest.DepartmentID : 0));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<EmployeeEnterpriseReport>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeEnterpriseReport item = new EmployeeEnterpriseReport();
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentCount"]) == false)
                        {
                            item.DepartmentCount = Convert.ToInt32(sqlDataReader["DepartmentCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalEmployeeInCentre"]) == false)
                        {
                            item.TotalEmployeeInCentre = Convert.ToInt32(sqlDataReader["TotalEmployeeInCentre"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreName"]) == false)
                        {
                            item.CentreName = sqlDataReader["CentreName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["CentreCode"]) == false)
                        {
                            item.CentreCode = sqlDataReader["CentreCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentId"]) == false)
                        {
                            item.DepartmentID = Convert.ToInt32(sqlDataReader["DepartmentId"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DepartmentName"]) == false)
                        {
                            item.DepartmentName = sqlDataReader["DepartmentName"].ToString();
                        }                        
                        if (DBNull.Value.Equals(sqlDataReader["DeptShortCode"]) == false)
                        {
                            item.DeptShortCode = sqlDataReader["DeptShortCode"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["TotalEmployeeInDepartment"]) == false)
                        {
                            item.TotalEmployeeInDepartment = Convert.ToInt32(sqlDataReader["TotalEmployeeInDepartment"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AcademicNonAcademic"]) == false)
                        {
                            item.AcademicNonAcademic = sqlDataReader["AcademicNonAcademic"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["DoctorateCount"]) == false)
                        {
                            item.DoctorateCount = Convert.ToInt32(sqlDataReader["DoctorateCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PostGraduationCount"]) == false)
                        {
                            item.PostGraduationCount = Convert.ToInt32(sqlDataReader["PostGraduationCount"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ExperinceInMonthCount"]) == false)
                        {
                            int var1 = Convert.ToInt32(sqlDataReader["ExperinceInMonthCount"]);
                            int a, b;
                            a = var1 / 12;
                            b = var1 % 12;
                            item.ExperinceInMonthCount = Convert.ToDecimal(a+"."+b);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SpecialResearchArea"]) == false)
                        {
                            item.SpecialResearchArea = Convert.ToInt32(sqlDataReader["SpecialResearchArea"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Journal_International"]) == false)
                        {
                            item.PaperPresentCount_Journal_International = Convert.ToInt32((Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Journal_International"])+(Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Journal_International"]))));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Journal_International"]) == false)
                        {
                            item.PaperPresentCount_CoAuthor_Journal_International = Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Journal_International"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_MainAuthor_Journal_International"]) == false)
                        {
                            item.PaperPresentCount_MainAuthor_Journal_International = Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Journal_International"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Journal_National"]) == false)
                        {
                            item.PaperPresentCount_Journal_National = Convert.ToInt32((Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Journal_National"]) + (Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Journal_National"]))));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Journal_National"]) == false)
                        {
                            item.PaperPresentCount_CoAuthor_Journal_National = Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Journal_National"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_MainAuthor_Journal_National"]) == false)
                        {
                            item.PaperPresentCount_MainAuthor_Journal_National = Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Journal_National"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Conference_International"]) == false)
                        {
                            item.PaperPresentCount_Conference_International = Convert.ToInt32((Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Conference_International"]) + (Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Conference_International"]))));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Conference_International"]) == false)
                        {
                            item.PaperPresentCount_CoAuthor_Conference_International = Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Conference_International"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_MainAuthor_Conference_International"]) == false)
                        {
                            item.PaperPresentCount_MainAuthor_Conference_International = Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Conference_International"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Conference_National"]) == false)
                        {
                            item.PaperPresentCount_Conference_National = Convert.ToInt32((Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Conference_National"])+(Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Conference_National"]))));
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_CoAuthor_Conference_National"]) == false)
                        {
                            item.PaperPresentCount_CoAuthor_Conference_National = Convert.ToInt32(sqlDataReader["PaperPresentCount_CoAuthor_Conference_National"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["PaperPresentCount_MainAuthor_Conference_National"]) == false)
                        {
                            item.PaperPresentCount_MainAuthor_Conference_National = Convert.ToInt32(sqlDataReader["PaperPresentCount_MainAuthor_Conference_National"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["AverageRanking"]) == false)
                        {
                            item.AverageRanking = Convert.ToDecimal(sqlDataReader["AverageRanking"]);
                        }
                        
                        

                        baseEntityCollection.CollectionResponse.Add(item);
                       
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeEnterpriseReport_SelectAll' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }
        /// <summary>
        /// Select a record from table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeEnterpriseReport> GetEmployeeEnterpriseReportByCentreCode(EmployeeEnterpriseReport item)
        {
            IBaseEntityResponse<EmployeeEnterpriseReport> response = new BaseEntityResponse<EmployeeEnterpriseReport>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(item.ConnectionString))
                {
                    response.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeEnterpriseReport_SelectOne";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        EmployeeEnterpriseReport _item = new EmployeeEnterpriseReport();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeCode"]) == false)
                        {
                            _item.EmployeeCode = sqlDataReader["EmployeeCode"].ToString();
                        }                       
                       
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            _item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        } 
                        response.Entity = _item;
                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'Select Procedure' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return response;
        }      
        
        /// <summary>
        /// Select all record from EmployeeEnterpriseReport table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeeList(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeEnterpriseReport>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeEnterpriseReport_GetEmployeeList";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                  //  cmdToExecute.Parameters.Add(new SqlParameter("@sSearchWord", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SearchWord));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<EmployeeEnterpriseReport>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeEnterpriseReport item = new EmployeeEnterpriseReport();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                            //item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                          //  item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeEnterpriseReport_SelectAll' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }


        /// <summary>
        /// Select all record from EmployeeEnterpriseReport table with search parameters for employee list ByCentreCodeAndDeptID
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetByCentreCodeAndDeptID(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeEnterpriseReport>();
            SqlCommand cmdToExecute = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            try
            {
                if (string.IsNullOrEmpty(searchRequest.ConnectionString))
                {
                    baseEntityCollection.Message.Add(new MessageDTO()
                    {
                        ErrorMessage = "Connection string is empty.",
                        MessageType = MessageTypeEnum.Error
                    });
                }
                else
                {
                    // Use base class' connection object
                    _mainConnection.ConnectionString = searchRequest.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeEnterpriseReport_GetByCenterCodeAndDepartmentWise";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDepartmentId", SqlDbType.Int, 4, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.DepartmentID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCentreCode", SqlDbType.NVarChar, 15, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.CentreCode));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Open connection.
                        _mainConnection.Open();
                    }
                    else
                    {
                        if (_mainConnectionProvider.IsTransactionPending)
                        {
                            cmdToExecute.Transaction = _mainConnectionProvider.CurrentTransaction;
                        }
                    }
                    sqlDataReader = cmdToExecute.ExecuteReader();
                    baseEntityCollection.CollectionResponse = new List<EmployeeEnterpriseReport>();
                    while (sqlDataReader.Read())
                    {
                        EmployeeEnterpriseReport item = new EmployeeEnterpriseReport();
                        item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        {
                           // item.NameTitle = sqlDataReader["NameTitle"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFullName"]) == false)
                        {
                            item.EmployeeFullName = sqlDataReader["EmployeeFullName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeFirstName"]) == false)
                        {
                            item.EmployeeFirstName = sqlDataReader["EmployeeFirstName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeMiddleName"]) == false)
                        {
                          //  item.EmployeeMiddleName = sqlDataReader["EmployeeMiddleName"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["EmployeeLastName"]) == false)
                        {
                          //  item.EmployeeLastName = sqlDataReader["EmployeeLastName"].ToString();
                        }
                        baseEntityCollection.CollectionResponse.Add(item);

                    }
                    if (cmdToExecute.Parameters["@iErrorCode"].Value != null)
                    {
                        _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    }
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'USP_EmployeeEnterpriseReport_GetByCenterCodeAndDepartmentWise' reported the ErrorCode: " + _errorCode);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntityCollection.Message.Add(new MessageDTO()
                {
                    ErrorMessage = ex.InnerException.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // _logException.Error(ex.Message);
            }
            finally
            {
                if (_mainConnectionIsCreatedLocal)
                {
                    // Close connection.
                    _mainConnection.Close();
                }
                cmdToExecute.Dispose();
            }
            return baseEntityCollection;
        }

        #endregion
    }
}
