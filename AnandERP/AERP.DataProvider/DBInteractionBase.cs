using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace AERP.DataProvider
{
    /// <summary>
    /// Purpose: Error Enums used by this library.
    /// </summary>
    public enum ErrorEnum
    {
        AllOk,
        DuplicateEntry = 11,
        LimitExceeds = 9,
        DependantEntry = 547,
        WorkFlowNotDefined = 10,
        Success = 200,
        InvalidCredentials = 404,
        NotExist = 101,
        VersionUpgrade = 505,
        DataNotFound = 100,
        NotRegistered = 405,
        OldPasswordNotMatched = 23
    }

    /// <summary>
    /// Purpose: General interface of the API generated. Contains only common methods of all classes.
    /// </summary>
    public interface ICommonDBAccess
    {
        bool Insert();
        bool Update();
        bool Delete();
        DataTable SelectOne();
        DataTable SelectAll();
    }

    /// <summary>
    /// Purpose: Abstract base class for Database Interaction classes.
    /// </summary>
    public abstract class DBInteractionBase : IDisposable, ICommonDBAccess
    {
        #region Class Member Declarations

        protected SqlConnection _mainConnection;
        protected SqlConnection _onlineDbConnection;
        protected SqlConnection _wareHouseDbConnection;
        protected int _rowsAffected;
        protected SqlInt32 _errorCode;
        protected SqlInt32 _RowCount;
        protected SqlInt32 _NewID;
        protected bool _mainConnectionIsCreatedLocal;
        protected bool _onlineDbConnectionIsCreatedLocal;
        protected bool _wareHouseDbConnectionIsCreatedLocal;
        protected ConnectionProvider _mainConnectionProvider;
        protected ConnectionProvider _onlineDbConnectionProvider;
        protected ConnectionProvider _wareHouseDbConnectionProvider;
        private bool _isDisposed;

        #endregion

        #region Class Method Declaration

        /// <summary>
        /// Purpose: Class constructor.
        /// </summary>
        public DBInteractionBase()
        {
            // create all the objects and initialize other members.
            _mainConnection = new SqlConnection();
            _onlineDbConnection = new SqlConnection();
            _wareHouseDbConnection = new SqlConnection();
            _mainConnectionIsCreatedLocal = true;
            _onlineDbConnectionIsCreatedLocal = true;
            _wareHouseDbConnectionIsCreatedLocal = true;
            _mainConnectionProvider = null;
            _onlineDbConnectionProvider = null;
            _wareHouseDbConnectionProvider = null;

            // Set connection string of the sqlconnection object
            // _mainConnection.ConnectionString = connectionString;
            _errorCode = (int)ErrorEnum.AllOk;
            _isDisposed = false;
        }

        /// <summary>
        /// Purpose: Implements the IDispose' method Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Purpose: Implements the Dispose functionality.
        /// </summary>
        protected virtual void Dispose(bool isDisposing)
        {
            // Check to see if Dispose has already been called.
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    // Dispose managed resources.
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Object is created in this class, so destroy it here.
                        _mainConnection.Close();
                        _mainConnection.Dispose();
                        _mainConnectionIsCreatedLocal = false;
                    }
                    _mainConnectionProvider = null;
                    _mainConnection = null;
                }
            }
            _isDisposed = true;
        }

        /// <summary>
        /// Purpose: Implements the ICommonDBAccess.Insert() method.
        /// </summary>
        public virtual bool Insert()
        {
            // No implementation, throw exception
            throw new NotImplementedException();
        }

        /// <summary>
        /// Purpose: Implements the ICommonDBAccess.Delete() method.
        /// </summary>
        public virtual bool Delete()
        {
            // No implementation, throw exception
            throw new NotImplementedException();
        }

        /// <summary>
        /// Purpose: Implements the ICommonDBAccess.Update() method.
        /// </summary>
        public virtual bool Update()
        {
            // No implementation, throw exception
            throw new NotImplementedException();
        }

        /// <summary>
        /// Purpose: Implements the ICommonDBAccess.SelectOne() method.
        /// </summary>
        public virtual DataTable SelectOne()
        {
            // No implementation, throw exception
            throw new NotImplementedException();
        }

        /// <summary>
        /// Purpose: Implements the ICommonDBAccess.SelectAll() method.
        /// </summary>
        public virtual DataTable SelectAll()
        {
            // No implementation, throw exception
            throw new NotImplementedException();
        }

        #endregion

        #region Class Property Declarations

        public ConnectionProvider MainConnectionProvider
        {
            set
            {
                if (value == null)
                {
                    // Invalid value
                    throw new ArgumentNullException("MainConnectionProvider", "Null passed as value to this property which is not allowed.");
                }

                // A connection provider object is passed to this class.
                // Retrieve the SqlConnection object, if present and create a
                // reference to it. If there is already a MainConnection object
                // referenced by the membervar, destroy that one or simply 
                // remove the reference, based on the flag.
                if (_mainConnection != null)
                {
                    // First get rid of current connection object. Caller is responsible
                    if (_mainConnectionIsCreatedLocal)
                    {
                        // Is local created object, close it and dispose it.
                        _mainConnection.Close();
                        _mainConnection.Dispose();
                    }
                    // Remove reference.
                    _mainConnection = null;
                }
                _mainConnectionProvider = (ConnectionProvider)value;
                _mainConnection = _mainConnectionProvider.DBConnection;
                _mainConnectionIsCreatedLocal = false;
            }
        }

        //public ConnectionProvider OnlineDbConnectionProvider
        //{
        //    set
        //    {
        //        if (value == null)
        //        {
        //            // Invalid value
        //            throw new ArgumentNullException("OnlineDbConnectionProvider", "Null passed as value to this property which is not allowed.");
        //        }

        //        // A connection provider object is passed to this class.
        //        // Retrieve the SqlConnection object, if present and create a
        //        // reference to it. If there is already a MainConnection object
        //        // referenced by the membervar, destroy that one or simply 
        //        // remove the reference, based on the flag.
        //        if (_onlineDbConnection != null)
        //        {
        //            // First get rid of current connection object. Caller is responsible
        //            if (_onlineDbConnectionIsCreatedLocal)
        //            {
        //                // Is local created object, close it and dispose it.
        //                _onlineDbConnection.Close();
        //                _onlineDbConnection.Dispose();
        //            }
        //            // Remove reference.
        //            _onlineDbConnection = null;
        //        }
        //        _onlineDbConnectionProvider = (ConnectionProvider)value;
        //        _onlineDbConnection = _onlineDbConnectionProvider.DBConnection;
        //        _onlineDbConnectionIsCreatedLocal = false;
        //    }
        //}

        //public ConnectionProvider WareHouseDbConnectionProvider
        //{
        //    set
        //    {
        //        if (value == null)
        //        {
        //            // Invalid value
        //            throw new ArgumentNullException("WareHouseDbConnectionProvider", "Null passed as value to this property which is not allowed.");
        //        }

        //        // A connection provider object is passed to this class.
        //        // Retrieve the SqlConnection object, if present and create a
        //        // reference to it. If there is already a MainConnection object
        //        // referenced by the membervar, destroy that one or simply 
        //        // remove the reference, based on the flag.
        //        if (_wareHouseDbConnection != null)
        //        {
        //            // First get rid of current connection object. Caller is responsible
        //            if (_wareHouseDbConnectionIsCreatedLocal)
        //            {
        //                // Is local created object, close it and dispose it.
        //                _wareHouseDbConnection.Close();
        //                _wareHouseDbConnection.Dispose();
        //            }
        //            // Remove reference.
        //            _wareHouseDbConnection = null;
        //        }
        //        _wareHouseDbConnectionProvider = (ConnectionProvider)value;
        //        _wareHouseDbConnection = _wareHouseDbConnectionProvider.DBConnection;
        //        _wareHouseDbConnectionIsCreatedLocal = false;
        //    }
        //}

        public SqlInt32 ErrorCode
        {
            get
            {
                return _errorCode;
            }
        }

        public int RowsAffected
        {
            get
            {
                return _rowsAffected;
            }
        }

        #endregion
    }
}

