using AERP.Base.DTO;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public class EmployeeBulkAttendenceBA : IEmployeeBulkAttendenceBA
    {
        private ILogger _logException;
        private IEmployeeBulkAttendenceDataProvider _EmployeeBulkAttendenceDataProvider;
        public EmployeeBulkAttendenceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeBulkAttendenceDataProvider = new EmployeeBulkAttendenceDataProvider();
        }

        public IBaseEntityResponse<EmployeeBulkAttendenceMaster> InsertEmployeeBulkAttendenceExcelUpload(EmployeeBulkAttendenceMaster item)
        {
            IBaseEntityResponse<EmployeeBulkAttendenceMaster> entityResponse = new BaseEntityResponse<EmployeeBulkAttendenceMaster>();
            try
            {
                entityResponse = _EmployeeBulkAttendenceDataProvider.InsertEmployeeBulkAttendenceMasterExcelUpload(item);

            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<EmployeeBulkAttendenceMaster> SelectByID(EmployeeBulkAttendenceMaster item)
        {
            IBaseEntityResponse<EmployeeBulkAttendenceMaster> entityResponse = new BaseEntityResponse<EmployeeBulkAttendenceMaster>();
            try
            {
                entityResponse = _EmployeeBulkAttendenceDataProvider.GetEmployeeAttendenceByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<EmployeeBulkAttendenceMaster> UpdateEmployeeAttendence(EmployeeBulkAttendenceMaster item)
        {
            IBaseEntityResponse<EmployeeBulkAttendenceMaster> entityResponse = new BaseEntityResponse<EmployeeBulkAttendenceMaster>();
            try
            {
                entityResponse = _EmployeeBulkAttendenceDataProvider.UpdateEmployeeAttendence(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityResponse<EmployeeBulkAttendenceMaster> InsertEmployeeAttendenceForSingleOne(EmployeeBulkAttendenceMaster item)
        {
            IBaseEntityResponse<EmployeeBulkAttendenceMaster> entityResponse = new BaseEntityResponse<EmployeeBulkAttendenceMaster>();
            try
            {
                entityResponse = _EmployeeBulkAttendenceDataProvider.InsertEmployeeAttendenceForSingleOne(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> GetEmployeeListForDownloadExcel(EmployeeBulkAttendenceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<EmployeeBulkAttendenceMaster>();
            try
            {
                if (_EmployeeBulkAttendenceDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _EmployeeBulkAttendenceDataProvider.GetEmployeeListForDownloadExcel(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }

        public IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> GetEmployeeListCentreAndDepartmentWise(EmployeeBulkAttendenceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeBulkAttendenceMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<EmployeeBulkAttendenceMaster>();
            try
            {
                if (_EmployeeBulkAttendenceDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _EmployeeBulkAttendenceDataProvider.GetEmployeeListCentreAndDepartmentWise(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }
    }
}
