using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class GeneralCounterPOSAndPosOperatorBA : IGeneralCounterPOSAndPosOperatorBA
    {
        IGeneralCounterPOSAndPosOperatorDataProvider _GeneralCounterPOSAndPosOperatorDataProvider;
        IGeneralCounterPOSAndPosOperatorBR _GeneralCounterPOSAndPosOperatorBR;
        private ILogger _logException;
        public GeneralCounterPOSAndPosOperatorBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralCounterPOSAndPosOperatorBR = new GeneralCounterPOSAndPosOperatorBR();
            _GeneralCounterPOSAndPosOperatorDataProvider = new GeneralCounterPOSAndPosOperatorDataProvider();
        }

        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetListCounterMaster(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> CounterMasterCollection = new BaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                if (_GeneralCounterPOSAndPosOperatorDataProvider != null)
                    CounterMasterCollection = _GeneralCounterPOSAndPosOperatorDataProvider.GetListCounterMaster(searchRequest);
                else
                {
                    CounterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CounterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CounterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CounterMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CounterMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetListPOSMaster(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> POSMasterCollection = new BaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                if (_GeneralCounterPOSAndPosOperatorDataProvider != null)
                    POSMasterCollection = _GeneralCounterPOSAndPosOperatorDataProvider.GetListPOSMaster(searchRequest);
                else
                {
                    POSMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    POSMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                POSMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                POSMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return POSMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetGeneralCounterPOSApplicableBySearch(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GeneralCounterPOSApplicable = new BaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                if (_GeneralCounterPOSAndPosOperatorDataProvider != null)
                    GeneralCounterPOSApplicable = _GeneralCounterPOSAndPosOperatorDataProvider.GetGeneralCounterPOSApplicableBySearch(searchRequest);
                else
                {
                    GeneralCounterPOSApplicable.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCounterPOSApplicable.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCounterPOSApplicable.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCounterPOSApplicable.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCounterPOSApplicable;
        }

        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> SelectByID(GeneralCounterPOSAndPosOperator item)
        {
            IBaseEntityResponse<GeneralCounterPOSAndPosOperator> entityResponse = new BaseEntityResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                entityResponse = _GeneralCounterPOSAndPosOperatorDataProvider.SelectByID(item);
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

        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> InsertGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item)
        {
            IBaseEntityResponse<GeneralCounterPOSAndPosOperator> entityResponse = new BaseEntityResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralCounterPOSAndPosOperatorBR.InsertGeneralCounterPOSAndPosOperatorValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralCounterPOSAndPosOperatorDataProvider.InsertGeneralCounterPOSAndPosOperator(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Update a specific record  of GeneralCounterPOSAndPosOperator.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> UpdateGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item)
        {
            IBaseEntityResponse<GeneralCounterPOSAndPosOperator> entityResponse = new BaseEntityResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralCounterPOSAndPosOperatorBR.UpdateGeneralCounterPOSAndPosOperatorValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralCounterPOSAndPosOperatorDataProvider.UpdateGeneralCounterPOSAndPosOperator(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Delete a selected record from GeneralCounterPOSAndPosOperator.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCounterPOSAndPosOperator> DeleteGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item)
        {
            IBaseEntityResponse<GeneralCounterPOSAndPosOperator> entityResponse = new BaseEntityResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralCounterPOSAndPosOperatorBR.DeleteGeneralCounterPOSAndPosOperatorValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralCounterPOSAndPosOperatorDataProvider.DeleteGeneralCounterPOSAndPosOperator(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// <summary>
        /// Select all record from GeneralCounterPOSAndPosOperator table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
           public IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetGeneralCounterPOSAndPosOperatorSearchList(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GeneralCounterPOSAndPosOperatorCollection = new BaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator>();
            try
            {
                if (_GeneralCounterPOSAndPosOperatorDataProvider != null)
                    GeneralCounterPOSAndPosOperatorCollection = _GeneralCounterPOSAndPosOperatorDataProvider.GetGeneralCounterPOSAndPosOperatorSearchList(searchRequest);
                else
                {
                    GeneralCounterPOSAndPosOperatorCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCounterPOSAndPosOperatorCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCounterPOSAndPosOperatorCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCounterPOSAndPosOperatorCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCounterPOSAndPosOperatorCollection;
        }
    }
}
