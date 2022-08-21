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
    public class EmployeeSalarySpanBA:IEmployeeSalarySpanBA
    {
        private ILogger _logException;
        private IEmployeeSalarySpanDataProvider _EmployeeSalarySpanDataProvider;
        public EmployeeSalarySpanBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _EmployeeSalarySpanDataProvider = new EmployeeSalarySpanDataProvider();
        }

        public IBaseEntityResponse<EmployeeSalarySpan> InsertEmployeeSalarySpan(EmployeeSalarySpan item)
        {
            IBaseEntityResponse<EmployeeSalarySpan> entityResponse = new BaseEntityResponse<EmployeeSalarySpan>();
            try
            {
                entityResponse = _EmployeeSalarySpanDataProvider.InsertEmployeeSalarySpan(item);
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

        public IBaseEntityCollectionResponse<EmployeeSalarySpan> GetBySearch(EmployeeSalarySpanSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalarySpan> EmployeeSalarySpanCollection = new BaseEntityCollectionResponse<EmployeeSalarySpan>();
            try
            {
                if (_EmployeeSalarySpanDataProvider != null)
                    EmployeeSalarySpanCollection = _EmployeeSalarySpanDataProvider.GetEmployeeSalarySpanBySearch(searchRequest);
                else
                {
                    EmployeeSalarySpanCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSalarySpanCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSalarySpanCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSalarySpanCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSalarySpanCollection;
        }

        public IBaseEntityResponse<EmployeeSalarySpan> SelectByID(EmployeeSalarySpan item)
        {
            IBaseEntityResponse<EmployeeSalarySpan> entityResponse = new BaseEntityResponse<EmployeeSalarySpan>();
            try
            {
                entityResponse = _EmployeeSalarySpanDataProvider.GetEmployeeSalarySpanByID(item);
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

        public IBaseEntityResponse<EmployeeSalarySpan> UpdateEmployeeSalarySpan(EmployeeSalarySpan item)
        {
            IBaseEntityResponse<EmployeeSalarySpan> entityResponse = new BaseEntityResponse<EmployeeSalarySpan>();
            try
            {
                entityResponse = _EmployeeSalarySpanDataProvider.UpdateEmployeeSalarySpan(item);
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

        public IBaseEntityCollectionResponse<EmployeeSalarySpan> GetSalarySpanList(EmployeeSalarySpanSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalarySpan> AttendenceCollection = new BaseEntityCollectionResponse<EmployeeSalarySpan>();
            try
            {
                if (_EmployeeSalarySpanDataProvider != null)
                    AttendenceCollection = _EmployeeSalarySpanDataProvider.GetSalarySpan(searchRequest);
                else
                {
                    AttendenceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AttendenceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AttendenceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AttendenceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AttendenceCollection;
        }
    }
}
