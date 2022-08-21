using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace AERP.DataProvider
{
    public class EmployeeDependentsDataProvider : DBInteractionBase, IEmployeeDependentsDataProvider
    {
        #region Variable Declaration
        private readonly string _connectionString;
        private readonly ILogger _logException;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        public EmployeeDependentsDataProvider()
        {
        }
        /// <summary>
        /// Constructor to initialized data member and member functions
        /// </summary>
        /// <param name="logException"></param>
        public EmployeeDependentsDataProvider(ILogger logException)
        {
            _connectionString = ""; //ConfigurationManager.ConnectionStrings["AERPEntities"].ToString();
            _logException = logException; // This should fix later
        }
        #endregion
        #region Method Implementation
        /// <summary>
        /// Select all record from EmployeeDependents table with search parameters
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeDependents> GetEmployeeDependentsBySearch(EmployeeDependentsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeDependents> baseEntityCollection = baseEntityCollection = new BaseEntityCollectionResponse<EmployeeDependents>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeeDependents_SelectAll";
					cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EmployeeID));
					cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _errorCode));
					cmdToExecute.Parameters.Add(new SqlParameter("@sSortBy", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, searchRequest.SortBy));
					cmdToExecute.Parameters.Add(new SqlParameter("@iStartRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.StartRow));
					cmdToExecute.Parameters.Add(new SqlParameter("@iEndRow", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.EndRow));
                     cmdToExecute.Parameters.Add(new SqlParameter("@nsSearchBy", SqlDbType.NVarChar, 200, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SearchBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@sSortDirection", SqlDbType.VarChar, 10, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, searchRequest.SortDirection));
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
					baseEntityCollection.CollectionResponse = new List<EmployeeDependents>();
					while (sqlDataReader.Read())
					{
						EmployeeDependents item = new EmployeeDependents();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        { 
						item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        { 
						item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        { 
						item.NameTitle = sqlDataReader["NameTitle"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["DependentName"]) == false)
                        { 
						item.DependentName = sqlDataReader["DependentName"].ToString();
                        }



                        if (DBNull.Value.Equals(sqlDataReader["Address1"]) == false)
                        {
                            item.Address1 = sqlDataReader["Address1"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["Address2"]) == false)
                        {
                            item.Address2 = sqlDataReader["Address2"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CityID"]) == false)
                        { 
						item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PhoneNumber"]) == false)
                        { 
						item.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDependentQualification"]) == false)
                        { 

						item.EmployeeDependentQualification = sqlDataReader["EmployeeDependentQualification"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDependentDesignation"]) == false)
                        { 
						item.EmployeeDependentDesignation = sqlDataReader["EmployeeDependentDesignation"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["GotAnyMedal"]) == false)
                        { 
						item.GotAnyMedal = Convert.ToBoolean(sqlDataReader["GotAnyMedal"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalReceivedDate"]) == false)
                        {

                            item.MedalReceivedDate = Convert.ToString(sqlDataReader["MedalReceivedDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalDescription"]) == false)
                        { 
						item.MedalDescription = sqlDataReader["MedalDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["IsScholarshipReceived"]) == false)
                        { 
						item.IsScholarshipReceived = Convert.ToBoolean(sqlDataReader["IsScholarshipReceived"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipAmount"]) == false)
                        {
                            item.ScholarshipAmount = Convert.ToDecimal(sqlDataReader["ScholarshipAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipStartDate"]) == false)
                        {
                           
                            item.ScholarshipStartDate = Convert.ToString(sqlDataReader["ScholarshipStartDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipUptoDate"]) == false)
                        {

                            item.ScholarshipUptoDate = Convert.ToString(sqlDataReader["ScholarshipUptoDate"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipDescription"]) == false)
                        { 
						item.ScholarshipDescription = sqlDataReader["ScholarshipDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Hobbies"]) == false)
                        { 
						item.Hobbies = sqlDataReader["Hobbies"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CurriculumActivity"]) == false)
                        { 
						item.CurriculumActivity = sqlDataReader["CurriculumActivity"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["DateOfBirth"]) == false)
                        {

                            item.DateOfBirth = Convert.ToString(sqlDataReader["DateOfBirth"]);

                        }

                        if (DBNull.Value.Equals(sqlDataReader["PlaceOfBirth"]) == false)
                        { 
						item.PlaceOfBirth = sqlDataReader["PlaceOfBirth"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["GeneralRelationshipTypeMasterID"]) == false)
                        {
						item.GeneralRelationshipTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralRelationshipTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MotherTongueID"]) == false)
                        { 
						item.MotherTongueID = Convert.ToInt32(sqlDataReader["MotherTongueID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["LanguageKnown"]) == false)
                        { 
						item.LanguageKnown = sqlDataReader["LanguageKnown"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RelationshipType"]) == false)
                        {
                            item.RelationshipType = sqlDataReader["RelationshipType"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NationalityID"]) == false)
                        {
						item.NationalityID = Convert.ToInt32(sqlDataReader["NationalityID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ReligionID"]) == false)
                        { 
						item.ReligionID = Convert.ToInt32(sqlDataReader["ReligionID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CasteID"]) == false)
                        { 
						item.CasteID = Convert.ToInt32(sqlDataReader["CasteID"]);
                        }
                       

                        if (DBNull.Value.Equals(sqlDataReader["CategoryID"]) == false)
                        { 
						item.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["WeddingAnniversaryDate"]) == false)
                        {

                            item.WeddingAnniversaryDate = Convert.ToString(sqlDataReader["WeddingAnniversaryDate"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["IsActive"]) == false)
                        { 
						item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                        }

						baseEntityCollection.CollectionResponse.Add(item);
						baseEntityCollection.TotalRecords = Convert.ToInt32(sqlDataReader["TotalRecords"]);
					}
					if (cmdToExecute.Parameters["@iErrorCode"].Value != null)                    
                    {
						_errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
					}
					if (_errorCode != (int)ErrorEnum.AllOk)                   
                    {
						// Throw error.
						throw new Exception("Stored Procedure 'USP_EmployeeDependents_SelectAll' reported the ErrorCode: " + _errorCode);
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
        public IBaseEntityResponse<EmployeeDependents> GetEmployeeDependentsByID(EmployeeDependents item)
		{
			IBaseEntityResponse<EmployeeDependents> response = new BaseEntityResponse<EmployeeDependents>();
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
					cmdToExecute.CommandText = "dbo.USP_EmployeeDependents_SelectOne";
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
						EmployeeDependents _item = new EmployeeDependents();
                        if (DBNull.Value.Equals(sqlDataReader["ID"]) == false)
                        {
                            _item.ID = Convert.ToInt32(sqlDataReader["ID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeID"]) == false)
                        {
                            _item.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["SequenceNumber"]) == false)
                        {
                            _item.SequenceNumber = Convert.ToInt32(sqlDataReader["SequenceNumber"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NameTitle"]) == false)
                        {
                            _item.NameTitle = sqlDataReader["NameTitle"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["DependentName"]) == false)
                        {
                            _item.DependentName = sqlDataReader["DependentName"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Address1"]) == false)
                        {
                            _item.Address1 = sqlDataReader["Address1"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["Address2"]) == false)
                        {
                            _item.Address2 = sqlDataReader["Address2"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["AdharCardNumber"]) == false)
                        {
                            _item.AdharCardNumber = sqlDataReader["AdharCardNumber"].ToString();
                        }


                        if (DBNull.Value.Equals(sqlDataReader["CityID"]) == false)
                        {
                            _item.CityID = Convert.ToInt32(sqlDataReader["CityID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CountryID"]) == false)
                        {
                            _item.CountryID = Convert.ToInt32(sqlDataReader["CountryID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["RegionID"]) == false)
                        {
                            _item.RegionID = Convert.ToInt32(sqlDataReader["RegionID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["PhoneNumber"]) == false)
                        {
                            _item.PhoneNumber = sqlDataReader["PhoneNumber"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MobileNumber"]) == false)
                        {
                            _item.MobileNumber = sqlDataReader["MobileNumber"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDependentQualification"]) == false)
                        {

                            _item.EmployeeDependentQualification = sqlDataReader["EmployeeDependentQualification"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["EmployeeDependentDesignation"]) == false)
                        {
                            _item.EmployeeDependentDesignation = sqlDataReader["EmployeeDependentDesignation"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["GotAnyMedal"]) == false)
                        {
                            _item.GotAnyMedal = Convert.ToBoolean(sqlDataReader["GotAnyMedal"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalReceivedDate"]) == false)
                        {
                            _item.MedalReceivedDate = sqlDataReader["MedalReceivedDate"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["MedalDescription"]) == false)
                        {
                            _item.MedalDescription = sqlDataReader["MedalDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["IsScholarshipReceived"]) == false)
                        {
                            _item.IsScholarshipReceived = Convert.ToBoolean(sqlDataReader["IsScholarshipReceived"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipAmount"]) == false)
                        {
                            _item.ScholarshipAmount = Convert.ToDecimal(sqlDataReader["ScholarshipAmount"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipStartDate"]) == false)
                        {
                            _item.ScholarshipStartDate = sqlDataReader["ScholarshipStartDate"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipUptoDate"]) == false)
                        {
                            _item.ScholarshipUptoDate = sqlDataReader["ScholarshipUptoDate"].ToString();
                        }
                        if (DBNull.Value.Equals(sqlDataReader["ScholarshipDescription"]) == false)
                        {
                            _item.ScholarshipDescription = sqlDataReader["ScholarshipDescription"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["Hobbies"]) == false)
                        {
                            _item.Hobbies = sqlDataReader["Hobbies"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CurriculumActivity"]) == false)
                        {
                            _item.CurriculumActivity = sqlDataReader["CurriculumActivity"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["DateOfBirth"]) == false)
                        {
                            _item.DateOfBirth = sqlDataReader["DateOfBirth"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["PlaceOfBirth"]) == false)
                        {
                            _item.PlaceOfBirth = sqlDataReader["PlaceOfBirth"].ToString();

                        }

                        if (DBNull.Value.Equals(sqlDataReader["GeneralRelationshipTypeMasterID"]) == false)
                        {
                            _item.GeneralRelationshipTypeMasterID = Convert.ToInt32(sqlDataReader["GeneralRelationshipTypeMasterID"]);
                        }
                        if (DBNull.Value.Equals(sqlDataReader["MotherTongueID"]) == false)
                        {
                            _item.MotherTongueID = Convert.ToInt32(sqlDataReader["MotherTongueID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["LanguageKnown"]) == false)
                        {
                            _item.LanguageKnown = sqlDataReader["LanguageKnown"].ToString();
                        }

                        if (DBNull.Value.Equals(sqlDataReader["NationalityID"]) == false)
                        {
                            _item.NationalityID = Convert.ToInt32(sqlDataReader["NationalityID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["ReligionID"]) == false)
                        {
                            _item.ReligionID = Convert.ToInt32(sqlDataReader["ReligionID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["CasteID"]) == false)
                        {
                            _item.CasteID = Convert.ToInt32(sqlDataReader["CasteID"]);
                        }
                       

                        if (DBNull.Value.Equals(sqlDataReader["CategoryID"]) == false)
                        {
                            _item.CategoryID = Convert.ToInt32(sqlDataReader["CategoryID"]);
                        }

                        if (DBNull.Value.Equals(sqlDataReader["WeddingAnniversaryDate"]) == false)
                        {
                            _item.WeddingAnniversaryDate = sqlDataReader["WeddingAnniversaryDate"].ToString();
                        }

                        _item.IsNominee = Convert.ToBoolean(sqlDataReader["IsNominee"]);
                        _item.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);

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
        /// Create new record of the table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> InsertEmployeeDependents(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> response = new BaseEntityResponse<EmployeeDependents>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeDependents_INSERT";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSequenceNumber", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 50,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.NameTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDependentName", SqlDbType.NVarChar, 200,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.DependentName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.RegionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PhoneNumber != null ? item.PhoneNumber : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 50,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.MobileNumber!=null? item.MobileNumber:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 255,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.Address1!=null ? item.Address1 : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 255,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.Address2 != null ? item.Address2 : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdharCardNumber != null ? item.AdharCardNumber : string.Empty));

                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeDependentQualification", SqlDbType.NVarChar, 100,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.EmployeeDependentQualification!=null? item.EmployeeDependentQualification:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeDependentDesignation", SqlDbType.NVarChar, 100,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.EmployeeDependentDesignation!=null? item.EmployeeDependentDesignation:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bGotAnyMedal", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.GotAnyMedal));
                    if (item.MedalReceivedDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalReceivedDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MedalDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                  
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsScholarshipReceived", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsScholarshipReceived));
                    if (item.ScholarshipAmount != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                 
             

                    if (item.ScholarshipDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }



                    if (item.ScholarshipStartDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipStartDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ScholarshipUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHobbies", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Hobbies != null ? item.Hobbies : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurriculumActivity", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurriculumActivity != null ? item.CurriculumActivity : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.Date, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.DateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlaceOfBirth", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.PlaceOfBirth != null? item.PlaceOfBirth:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralRelationshipTypeMasterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.GeneralRelationshipTypeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMotherTongueID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.MotherTongueID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLanguageKnown", SqlDbType.VarChar, 255,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LanguageKnown!=null? item.LanguageKnown:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NationalityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iReligionID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ReligionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCasteID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CasteID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CategoryID));
                    if (item.WeddingAnniversaryDate != null && item.WeddingAnniversaryDate != "")
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daWeddingAnniversaryDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.WeddingAnniversaryDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daWeddingAnniversaryDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNominee", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsNominee));

                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCreatedBy", SqlDbType.Int, 4,ParameterDirection.Input, true, 10, 0, "",DataRowVersion.Proposed, item.CreatedBy));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,ParameterDirection.Output, true, 10, 0, "",DataRowVersion.Proposed, _errorCode));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    if (_rowsAffected > 0)
                    {
                        item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    }
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    item.ErrorCode = (Int32)_errorCode;
                    response.Entity = item;
                    if (_errorCode != (int)ErrorEnum.AllOk && _errorCode != (int)ErrorEnum.DuplicateEntry)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeDependents_Insert' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    //if (_rowsAffected > 0)
                    //{
                    //    response.Entity = item;
                    //}
                    //else
                    //{
                    //    response.Message.Add(new MessageDTO
                    //    {
                    //        ErrorMessage = "Create failed"
                    //    });
                    //}
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
        /// Update a specific record of EmployeeDependents
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> UpdateEmployeeDependents(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> response = new BaseEntityResponse<EmployeeDependents>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeDependents_Update";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iEmployeeID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.EmployeeID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iSequenceNumber", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.SequenceNumber));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsNameTitle", SqlDbType.NVarChar, 50,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.NameTitle));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsDependentName", SqlDbType.NVarChar, 200,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.DependentName));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCountryID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CountryID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iRegionID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.RegionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCityID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPhoneNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.PhoneNumber != null ? item.PhoneNumber : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsMobileNumber", SqlDbType.NVarChar, 50,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.MobileNumber!=null ?item.MobileNumber:string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress1", SqlDbType.NVarChar, 255,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.Address1 != null ? item.Address1 : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAddress2", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Address2 != null ? item.Address2 : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsAdharCardNumber", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.AdharCardNumber != null ? item.AdharCardNumber : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeDependentQualification", SqlDbType.NVarChar, 100,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.EmployeeDependentQualification != null ? item.EmployeeDependentQualification : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsEmployeeDependentDesignation", SqlDbType.NVarChar, 100,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.EmployeeDependentDesignation != null ? item.EmployeeDependentDesignation : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bGotAnyMedal", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.GotAnyMedal));
                    if (item.MedalReceivedDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalReceivedDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daMedalReceivedDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.MedalDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.VarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.MedalDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsMedalDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                  
                  
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsScholarshipReceived", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsScholarshipReceived));
                    if (item.ScholarshipAmount != 0)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipAmount));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@dScholarshipAmount", SqlDbType.Money, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                 
             

                    if (item.ScholarshipDescription != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipDescription));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@nsScholarshipDescription", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }



                    if (item.ScholarshipStartDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipStartDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipStartDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }

                    if (item.ScholarshipUptoDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.ScholarshipUptoDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daScholarshipUptoDate", SqlDbType.Date, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }


                    cmdToExecute.Parameters.Add(new SqlParameter("@nsHobbies", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.Hobbies != null ? item.Hobbies : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsCurriculumActivity", SqlDbType.NVarChar, 255, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.CurriculumActivity != null ? item.CurriculumActivity : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@daDateOfBirth", SqlDbType.Date, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.DateOfBirth));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsPlaceOfBirth", SqlDbType.NVarChar, 50,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.PlaceOfBirth != null ? item.PlaceOfBirth : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iGeneralRelationshipTypeMasterID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.GeneralRelationshipTypeMasterID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iMotherTongueID", SqlDbType.Int, 10,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.MotherTongueID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@nsLanguageKnown", SqlDbType.VarChar, 255,ParameterDirection.Input, false, 10, 0, "",DataRowVersion.Proposed, item.LanguageKnown != null ? item.LanguageKnown : string.Empty));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iNationalityID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.NationalityID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iReligionID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.ReligionID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCasteID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CasteID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iCategoryID", SqlDbType.Int, 4,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.CategoryID));
                    if (item.WeddingAnniversaryDate != null)
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daWeddingAnniversaryDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, item.WeddingAnniversaryDate));
                    }
                    else
                    {
                        cmdToExecute.Parameters.Add(new SqlParameter("@daWeddingAnniversaryDate", SqlDbType.VarChar, 0, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, DBNull.Value));
                    }
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsActive", SqlDbType.Bit, 0,ParameterDirection.Input, false, 0, 0, "",DataRowVersion.Proposed, item.IsActive));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsNominee", SqlDbType.Bit, 0, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, item.IsNominee));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, true, 10, 0, "", DataRowVersion.Proposed, item.ModifiedBy));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeDependents_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
        /// Delete a specific record of EmployeeDependents
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> DeleteEmployeeDependents(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> response = new BaseEntityResponse<EmployeeDependents>();
            SqlCommand cmdToExecute = new SqlCommand();
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
                    _mainConnection.ConnectionString = item.ConnectionString;
                    cmdToExecute.Connection = _mainConnection;
                    cmdToExecute.CommandText = "dbo.USP_EmployeeDependents_Delete";
                    cmdToExecute.CommandType = CommandType.StoredProcedure;
                    cmdToExecute.Parameters.Add(new SqlParameter("@iID", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, item.ID));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bIsDeletedType", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 0));
                    cmdToExecute.Parameters.Add(new SqlParameter("@bDeletedStatus", SqlDbType.Bit, 1,
                                            ParameterDirection.Input, false, 0, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iDeletedBy", SqlDbType.Int, 4,
                                            ParameterDirection.Input, true, 10, 0, "",
                                            DataRowVersion.Proposed, 1));
                    cmdToExecute.Parameters.Add(new SqlParameter("@iErrorCode", SqlDbType.Int, 4,
                                            ParameterDirection.Output, true, 10, 0, "",
                                            DataRowVersion.Proposed, _errorCode));
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
                    // Execute query.
                    _rowsAffected = cmdToExecute.ExecuteNonQuery();
                    item.ID = (Int32)cmdToExecute.Parameters["@iID"].Value;
                    _errorCode = (SqlInt32)cmdToExecute.Parameters["@iErrorCode"].Value;
                    if (_errorCode != (int)ErrorEnum.AllOk)
                    {
                        // Throw error.
                        throw new Exception("Stored Procedure 'dbo.USP_EmployeeDependents_Delete' reported the ErrorCode: " +
                                        _errorCode);
                    }
                    if (_rowsAffected > 0)
                    {
                        response.Entity = item;
                    }
                    else
                    {
                        response.Message.Add(new MessageDTO
                        {
                            ErrorMessage = "Create failed"
                        });
                    }
                }
            }
            catch (SqlException ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
            }
            catch (Exception ex)
            {
                response.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                _logException.Error(ex.Message);
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
        #endregion
    }
}
