using AERP.Base.DTO;
using AERP.Business.BusinessRules;
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
    public class EmpDesignationMasterBA : IEmpDesignationMasterBA
    {
        IEmpDesignationMasterDataProvider _empDesignationMasterDataProvider;
        IEmpDesignationMasterBR _empDesignationMasterBR;
        private ILogger _logException;

        public EmpDesignationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _empDesignationMasterBR = new EmpDesignationMasterBR();
            _empDesignationMasterDataProvider = new EmpDesignationMasterDataProvider();
        }

        public IBaseEntityResponse<EmpDesignationMaster> InsertEmpDesignationMaster(EmpDesignationMaster item)
        {
            IBaseEntityResponse<EmpDesignationMaster> entityResponse = new BaseEntityResponse<EmpDesignationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empDesignationMasterBR.InsertEmpDesignationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empDesignationMasterDataProvider.InsertEmpDesignationMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        public IBaseEntityResponse<EmpDesignationMaster> UpdateEmpDesignationMaster(EmpDesignationMaster item)
        {
            IBaseEntityResponse<EmpDesignationMaster> entityResponse = new BaseEntityResponse<EmpDesignationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empDesignationMasterBR.UpdateEmpDesignationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empDesignationMasterDataProvider.UpdateEmpDesignationMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        public IBaseEntityResponse<EmpDesignationMaster> DeleteEmpDesignationMaster(EmpDesignationMaster item)
        {
            IBaseEntityResponse<EmpDesignationMaster> entityResponse = new BaseEntityResponse<EmpDesignationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empDesignationMasterBR.DeleteEmpDesignationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empDesignationMasterDataProvider.DeleteEmpDesignationMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        public IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySearch(EmpDesignationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpDesignationMaster> empDesignationMasterCollection = new BaseEntityCollectionResponse<EmpDesignationMaster>();
            try
            {
                if (_empDesignationMasterDataProvider != null)
                {
                    empDesignationMasterCollection = _empDesignationMasterDataProvider.GetEmpDesignationMasterBySearch(searchRequest);
                }
                else
                {
                    empDesignationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    empDesignationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                empDesignationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                empDesignationMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return empDesignationMasterCollection;
        }



        public IBaseEntityResponse<EmpDesignationMaster> SelectByID(EmpDesignationMaster item)
        {

            IBaseEntityResponse<EmpDesignationMaster> entityResponse = new BaseEntityResponse<EmpDesignationMaster>();
            try
            {
                entityResponse = _empDesignationMasterDataProvider.GetEmpDesignationMasterByID(item);
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

        public IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySearchList(EmpDesignationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpDesignationMaster> empDesignationMasterCollection = new BaseEntityCollectionResponse<EmpDesignationMaster>();
            try
            {
                if (_empDesignationMasterDataProvider != null)
                {
                    empDesignationMasterCollection = _empDesignationMasterDataProvider.GetEmpDesignationMasterBySearchList(searchRequest);
                }
                else
                {
                    empDesignationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    empDesignationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                empDesignationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                empDesignationMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return empDesignationMasterCollection;
        }

        public IBaseEntityCollectionResponse<EmpDesignationMaster> GetBySelectList(EmpDesignationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpDesignationMaster> empDesignationMasterCollection = new BaseEntityCollectionResponse<EmpDesignationMaster>();
            try
            {
                if (_empDesignationMasterDataProvider != null)
                {
                    empDesignationMasterCollection = _empDesignationMasterDataProvider.GetEmpDesignationMasterBySearchSelectList(searchRequest);
                }
                else
                {
                    empDesignationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    empDesignationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                empDesignationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                empDesignationMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return empDesignationMasterCollection;
        }
    }
}
