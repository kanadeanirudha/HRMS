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
    public class GeneralTaxMasterBA : IGeneralTaxMasterBA
    {
        IGeneralTaxMasterDataProvider _generalRegionMasterDataProvider;
        IGeneralTaxMasterBR _generalRegionMasterBR;
        private ILogger _logException;

        public GeneralTaxMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new GeneralTaxMasterBR();
            _generalRegionMasterDataProvider = new GeneralTaxMasterDataProvider();
        }

        /// <summary>
        /// Create new record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> InsertGeneralTaxMaster(GeneralTaxMaster item)
        {
            IBaseEntityResponse<GeneralTaxMaster> entityResponse = new BaseEntityResponse<GeneralTaxMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertGeneralTaxMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertGeneralTaxMaster(item);
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
        /// Update a specific record of GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> UpdateGeneralTaxMaster(GeneralTaxMaster item)
        {
            IBaseEntityResponse<GeneralTaxMaster> entityResponse = new BaseEntityResponse<GeneralTaxMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateGeneralTaxMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateGeneralTaxMaster(item);
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
        /// Delete a selected record from GeneralTaxMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> DeleteGeneralTaxMaster(GeneralTaxMaster item)
        {
            IBaseEntityResponse<GeneralTaxMaster> entityResponse = new BaseEntityResponse<GeneralTaxMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteGeneralTaxMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteGeneralTaxMaster(item);
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
        /// Select all record from GeneralTaxMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearch(GeneralTaxMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaxMaster> TaxMasterCollection = new BaseEntityCollectionResponse<GeneralTaxMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    TaxMasterCollection = _generalRegionMasterDataProvider.GetGeneralTaxMasterBySearch(searchRequest);
                }
                else
                {
                    TaxMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TaxMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TaxMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                TaxMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TaxMasterCollection;
        }

        /// <summary>
        /// Select all record from GeneralTaxMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<GeneralTaxMaster> GetBySearchList(GeneralTaxMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaxMaster> TaxMasterCollection = new BaseEntityCollectionResponse<GeneralTaxMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    TaxMasterCollection = _generalRegionMasterDataProvider.GetGeneralTaxMasterGetBySearchList(searchRequest);
                }
                else
                {
                    TaxMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    TaxMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                TaxMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                TaxMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TaxMasterCollection;
        }


        /// <summary>
        /// Select a record from GeneralTaxMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxMaster> SelectByID(GeneralTaxMaster item)
        {

            IBaseEntityResponse<GeneralTaxMaster> entityResponse = new BaseEntityResponse<GeneralTaxMaster>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetGeneralTaxMasterByID(item);
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