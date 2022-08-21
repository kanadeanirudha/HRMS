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
using AMS.Business.BusinessActions;
namespace AMS.Web.UI.Controllers
{
    public class EnterpriseDrillThroughReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEnterpriseDrillThroughReportServiceAccess _EnterpriseDrillThroughReportServiceAccess = null;
        private readonly ILogger _logException;
        protected string _centreCode = string.Empty;
        //protected static int _balanesheetMstID;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EnterpriseDrillThroughReportController()
        {
            _EnterpriseDrillThroughReportServiceAccess = new EnterpriseDrillThroughReportServiceAccess();          
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {               
           return View("/Views/Accounts/EnterpriseDrillThroughReport/Index.cshtml");
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------
        public List<EnterpriseDrillThroughReport> GetCentreList()
        {
            try
            {
                List<EnterpriseDrillThroughReport> listEnterpriseDrillThroughReport = new List<EnterpriseDrillThroughReport>();
                EnterpriseDrillThroughReportSearchRequest searchRequest = new EnterpriseDrillThroughReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> baseEntityCollectionResponse = _EnterpriseDrillThroughReportServiceAccess.GetEnterpriseDrillThroughReportBySearch_Centre(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listEnterpriseDrillThroughReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                return listEnterpriseDrillThroughReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<EnterpriseDrillThroughReport> GetDepartementList(string CentreCode)
        {
            try
            {
                List<EnterpriseDrillThroughReport> listEnterpriseDrillThroughReport = new List<EnterpriseDrillThroughReport>();
                EnterpriseDrillThroughReportSearchRequest searchRequest = new EnterpriseDrillThroughReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = CentreCode;
                IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> baseEntityCollectionResponse = _EnterpriseDrillThroughReportServiceAccess.GetEnterpriseDrillThroughReportBySearch_Department(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listEnterpriseDrillThroughReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listEnterpriseDrillThroughReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public List<EnterpriseDrillThroughReport> GetEmployeeList(int DepartmentID)
        {
            try
            {
                List<EnterpriseDrillThroughReport> listEnterpriseDrillThroughReport = new List<EnterpriseDrillThroughReport>();
                EnterpriseDrillThroughReportSearchRequest searchRequest = new EnterpriseDrillThroughReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.DepartmentID = DepartmentID;
                IBaseEntityCollectionResponse<EnterpriseDrillThroughReport> baseEntityCollectionResponse = _EnterpriseDrillThroughReportServiceAccess.GetEnterpriseDrillThroughReportBySearch_Employee(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listEnterpriseDrillThroughReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listEnterpriseDrillThroughReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion



    }
}
