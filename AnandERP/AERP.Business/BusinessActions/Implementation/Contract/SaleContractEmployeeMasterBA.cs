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
    public class SaleContractEmployeeMasterBA : ISaleContractEmployeeMasterBA
    {
        ISaleContractEmployeeMasterDataProvider _generalRegionMasterDataProvider;
        ISaleContractEmployeeMasterBR _generalRegionMasterBR;
        private ILogger _logException;

        public SaleContractEmployeeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new SaleContractEmployeeMasterBR();
            _generalRegionMasterDataProvider = new SaleContractEmployeeMasterDataProvider();
        }

        /// <summary>
        /// Create new record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractEmployeeMaster> InsertSaleContractEmployeeMaster(SaleContractEmployeeMaster item)
        {
            IBaseEntityResponse<SaleContractEmployeeMaster> entityResponse = new BaseEntityResponse<SaleContractEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertSaleContractEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertSaleContractEmployeeMaster(item);
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
        /// Update a specific record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractEmployeeMaster> UpdateSaleContractEmployeeMaster(SaleContractEmployeeMaster item)
        {
            IBaseEntityResponse<SaleContractEmployeeMaster> entityResponse = new BaseEntityResponse<SaleContractEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateSaleContractEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateSaleContractEmployeeMaster(item);
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
        /// Delete a selected record from SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractEmployeeMaster> DeleteSaleContractEmployeeMaster(SaleContractEmployeeMaster item)
        {
            IBaseEntityResponse<SaleContractEmployeeMaster> entityResponse = new BaseEntityResponse<SaleContractEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteSaleContractEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteSaleContractEmployeeMaster(item);
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
        /// Select all record from SaleContractEmployeeMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetBySearch(SaleContractEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractEmployeeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractEmployeeMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSaleContractEmployeeMasterBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from SaleContractEmployeeMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetBySearchList(SaleContractEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractEmployeeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractEmployeeMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSaleContractEmployeeMasterGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from SaleContractEmployeeMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractEmployeeMaster> SelectByID(SaleContractEmployeeMaster item)
        {

            IBaseEntityResponse<SaleContractEmployeeMaster> entityResponse = new BaseEntityResponse<SaleContractEmployeeMaster>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetSaleContractEmployeeMasterByID(item);
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

        public IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearchWord(SaleContractEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractEmployeeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractEmployeeMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSaleContractEmployeeMasterBySearchWord(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        public IBaseEntityResponse<SaleContractEmployeeMaster> InsertSaleContractEmployeeMasterExcelUpload(SaleContractEmployeeMaster item)
        {
            IBaseEntityResponse<SaleContractEmployeeMaster> entityResponse = new BaseEntityResponse<SaleContractEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertSaleContractEmployeeMasterExcelUploadValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertSaleContractEmployeeMasterExcelUpload(item);
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

        public IBaseEntityResponse<SaleContractEmployeeMaster> GetDataValidationListsForEmployeeMasterExcel(SaleContractEmployeeMaster item)
        {

            IBaseEntityResponse<SaleContractEmployeeMaster> entityResponse = new BaseEntityResponse<SaleContractEmployeeMaster>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetDataValidationListsForEmployeeMasterExcel(item);
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
        public IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearchWordForReports(SaleContractEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractEmployeeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractEmployeeMaster>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSaleContractEmployeeMasterBySearchWordForReports(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


    }
}