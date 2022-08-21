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
    public class GeneralSupplierMasterBA: IGeneralSupplierMasterBA
    {
        IGeneralSupplierMasterDataProvider _GeneralSupplierMasterDataProvider;
        IGeneralSupplierMasterBR _GeneralSupplierMasterBR;
        private ILogger _logException;

        public GeneralSupplierMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralSupplierMasterBR = new GeneralSupplierMasterBR();
            _GeneralSupplierMasterDataProvider = new GeneralSupplierMasterDataProvider();
        }

        /// <summary>
        /// Select all record from Account Balance Sheet Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearch(GeneralSupplierMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralSupplierMaster> GeneralSupplierMasterCollection = new BaseEntityCollectionResponse<GeneralSupplierMaster>();
            try
            {
                if (_GeneralSupplierMasterDataProvider != null)
                {
                    GeneralSupplierMasterCollection = _GeneralSupplierMasterDataProvider.GetGeneralSupplierMasterBySearch(searchRequest);
                }
                else
                {
                    GeneralSupplierMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralSupplierMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralSupplierMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralSupplierMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralSupplierMasterCollection;
        }

        /// <summary>
        /// Select a record from Account Balance Sheet Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> SelectByID(GeneralSupplierMaster item)
        {

            IBaseEntityResponse<GeneralSupplierMaster> entityResponse = new BaseEntityResponse<GeneralSupplierMaster>();
            try
            {
                entityResponse = _GeneralSupplierMasterDataProvider.GetGeneralSupplierMasterByID(item);
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
        /// Create new record of Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> InsertGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            IBaseEntityResponse<GeneralSupplierMaster> entityResponse = new BaseEntityResponse<GeneralSupplierMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralSupplierMasterBR.InsertGeneralSupplierMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralSupplierMasterDataProvider.InsertGeneralSupplierMaster(item);
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

        /// <summary>
        /// Update a specific record of Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> UpdateGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            IBaseEntityResponse<GeneralSupplierMaster> entityResponse = new BaseEntityResponse<GeneralSupplierMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralSupplierMasterBR.UpdateGeneralSupplierMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralSupplierMasterDataProvider.UpdateGeneralSupplierMaster(item);
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

        /// <summary>
        /// Delete a selected record from Account Balance Sheet Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralSupplierMaster> DeleteGeneralSupplierMaster(GeneralSupplierMaster item)
        {
            IBaseEntityResponse<GeneralSupplierMaster> entityResponse = new BaseEntityResponse<GeneralSupplierMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralSupplierMasterBR.DeleteGeneralSupplierMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralSupplierMasterDataProvider.DeleteGeneralSupplierMaster(item);
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

        public IBaseEntityCollectionResponse<GeneralSupplierMaster> GetBySearchList(GeneralSupplierMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralSupplierMaster> SupplierMasterCollection = new BaseEntityCollectionResponse<GeneralSupplierMaster>();
            try
            {
                if (_GeneralSupplierMasterDataProvider != null)
                {
                    SupplierMasterCollection = _GeneralSupplierMasterDataProvider.GetGeneralSupplierMasterGetBySearchList(searchRequest);
                }
                else
                {
                    SupplierMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SupplierMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SupplierMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                SupplierMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SupplierMasterCollection;
        }
    }
}
