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
    public class GeneralPriceListAndListLineBA : IGeneralPriceListAndListLineBA
    {
        IGeneralPriceListAndListLineDataProvider _GeneralPriceListAndListLineDataProvider;
        IGeneralPriceListAndListLineBR _GeneralPriceListAndListLineBR;
        private ILogger _logException;
        public GeneralPriceListAndListLineBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPriceListAndListLineBR = new GeneralPriceListAndListLineBR();
            _GeneralPriceListAndListLineDataProvider = new GeneralPriceListAndListLineDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPriceListAndListLine.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceListAndListLine(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceListAndListLineBR.InsertGeneralPriceListAndListLineValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceListAndListLineDataProvider.InsertGeneralPriceListAndListLine(item);
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
        /// Update a specific record  of GeneralPriceListAndListLine.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceListAndListLine(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceListAndListLineBR.UpdateGeneralPriceListAndListLineValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceListAndListLineDataProvider.UpdateGeneralPriceListAndListLine(item);
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
        /// Delete a selected record from GeneralPriceListAndListLine.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceListAndListLine(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceListAndListLineBR.DeleteGeneralPriceListAndListLineValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceListAndListLineDataProvider.DeleteGeneralPriceListAndListLine(item);
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
        /// Select all record from GeneralPriceListAndListLine table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetBySearch(GeneralPriceListAndListLineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GeneralPriceListAndListLineCollection = new BaseEntityCollectionResponse<GeneralPriceListAndListLine>();
            try
            {
                if (_GeneralPriceListAndListLineDataProvider != null)
                    GeneralPriceListAndListLineCollection = _GeneralPriceListAndListLineDataProvider.GetGeneralPriceListAndListLineBySearch(searchRequest);
                else
                {
                    GeneralPriceListAndListLineCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPriceListAndListLineCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPriceListAndListLineCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPriceListAndListLineCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPriceListAndListLineCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineSearchList(GeneralPriceListAndListLineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GeneralPriceListAndListLineCollection = new BaseEntityCollectionResponse<GeneralPriceListAndListLine>();
            try
            {
                if (_GeneralPriceListAndListLineDataProvider != null)
                    GeneralPriceListAndListLineCollection = _GeneralPriceListAndListLineDataProvider.GetGeneralPriceListAndListLineSearchList(searchRequest);
                else
                {
                    GeneralPriceListAndListLineCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPriceListAndListLineCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPriceListAndListLineCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPriceListAndListLineCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPriceListAndListLineCollection;
        }
        /// <summary>
        /// Select a record from GeneralPriceListAndListLine table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> SelectByID(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                entityResponse = _GeneralPriceListAndListLineDataProvider.GetGeneralPriceListAndListLineByID(item);
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

        //*******************************************************************************************************
        /// <summary>
        /// Create new record of GeneralPriceListAndListLine.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceList(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceListAndListLineBR.InsertGeneralPriceListValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceListAndListLineDataProvider.InsertGeneralPriceList(item);
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
        /// Update a specific record  of GeneralPriceListAndListLine.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceList(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceListAndListLineBR.UpdateGeneralPriceListValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceListAndListLineDataProvider.UpdateGeneralPriceList(item);
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
        /// Delete a selected record from GeneralPriceListAndListLine.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceList(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceListAndListLineBR.DeleteGeneralPriceListValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceListAndListLineDataProvider.DeleteGeneralPriceList(item);
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

        public IBaseEntityCollectionResponse<GeneralPriceListAndListLine> SelectByGeneralPriceListID(GeneralPriceListAndListLineSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GeneralPriceListAndListLineCollection = new BaseEntityCollectionResponse<GeneralPriceListAndListLine>();
            try
            {
                if (_GeneralPriceListAndListLineDataProvider != null)
                    GeneralPriceListAndListLineCollection = _GeneralPriceListAndListLineDataProvider.GetGeneralPriceListAndListLineByGeneralPriceListID(searchRequest);
                else
                {
                    GeneralPriceListAndListLineCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPriceListAndListLineCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPriceListAndListLineCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPriceListAndListLineCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPriceListAndListLineCollection;
        }


        public IBaseEntityResponse<GeneralPriceListAndListLine> GetIsRootCount(GeneralPriceListAndListLine item)
        {
            IBaseEntityResponse<GeneralPriceListAndListLine> entityResponse = new BaseEntityResponse<GeneralPriceListAndListLine>();
            try
            {
                entityResponse = _GeneralPriceListAndListLineDataProvider.GetIsRootCount(item);
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
    }
}
