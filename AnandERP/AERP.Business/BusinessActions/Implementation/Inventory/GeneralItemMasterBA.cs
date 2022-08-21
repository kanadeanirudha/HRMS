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
    public class GeneralItemMasterBA : IGeneralItemMasterBA
    {
        IGeneralItemMasterDataProvider _GeneralItemMasterDataProvider;
        IGeneralItemMasterBR _GeneralItemMasterBR;
        private ILogger _logException;
        public GeneralItemMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemMasterBR = new GeneralItemMasterBR();
            _GeneralItemMasterDataProvider = new GeneralItemMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemMaster(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.InsertGeneralItemMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.InsertGeneralItemMaster(item);
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
        /// Update a specific record  of GeneralItemMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> UpdateGeneralItemMaster(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.UpdateGeneralItemMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.UpdateGeneralItemMaster(item);
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
        /// Delete a selected record from GeneralItemMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMaster(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.DeleteGeneralItemMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.DeleteGeneralItemMaster(item);
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
        /// Select all record from GeneralItemMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetBySearch(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemMasterBySearch(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemMasterSearchList(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMaster> SelectByID(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetGeneralItemMasterByID(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> SearchListForGeneralPackingTypeInfo(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.SearchListForGeneralPackingTypeInfo(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }


        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetGeneralItemSupliersDataByItemNumber(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemSalesDataByItemNumber(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemGeneralDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetGeneralItemGeneralDataByItemNumber(item);
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

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemServiceDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetGeneralItemServiceDataByItemNumber(item);
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

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemStockDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetGeneralItemStockDataByItemNumber(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemDetailsForSupliersDataSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemDetailsForSupliersDataSearchList(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetUomDetailsForGeneralItemMaster(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetUomDetailsForGeneralItemMaster(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemBarcodes(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.InsertGeneralItemBarcodesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.InsertGeneralItemBarcodes(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetBarcodesBySearch(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetBarcodesBySearch(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemBarcodes(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.DeleteGeneralItemMasterEComImagesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.DeleteGeneralItemBarcodes(item);
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

        public IBaseEntityResponse<GeneralItemMaster> InsertInventoryStoreSpecificInformation(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.InsertInventoryStoreSpecificInformationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.InsertInventoryStoreSpecificInformation(item);
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

       
        public IBaseEntityResponse<GeneralItemMaster> SelectOneInventoryStoreSpecificInformation(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.SelectOneInventoryStoreSpecificInformation(item);
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

        public IBaseEntityResponse<GeneralItemMaster> CheckFocusOnAction(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.CheckFocusOnAction(item);
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

    

        public IBaseEntityResponse<GeneralItemMaster> GetRestaurantDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetRestaurantDataByItemNumber(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVariantDetailsForGeneralItemMasters(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetVariantDetailsForGeneralItemMasters(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemStoreData(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemStoreData(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralitemMasterExcel(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.InsertGeneralItemMasterExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.InsertGeneralitemMasterExcel(item);
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

        public IBaseEntityResponse<GeneralItemMaster> GetDataValidationListsForExcel(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                {
                    entityResponse = _GeneralItemMasterDataProvider.GetDataValidationListsForExcel(item);
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



        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeData(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemAttributeData(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeDataByItemNumber(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemAttributeDataByItemNumber(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetItemSearchListForVarientsMenu(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetItemSearchListForVarientsMenu(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchListForReport(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemMasterSearchListForReport(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListForRequisition(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetVendorWiseItemSearchListForRequisition(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        //Multiple Vendor
        public IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemSupplierDataForVendorDetails(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.InsertGeneralItemSupplierDataForVendorDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.InsertGeneralItemSupplierDataForVendorDetails(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetMultipleVendorListItemWise(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetMultipleVendorListItemWise(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }


        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumberandVendorID(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemSupliersDataByItemNumberandVendorID(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityResponse<GeneralItemMaster> GetGeneralItemEcommerceDataByItemNumber(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                entityResponse = _GeneralItemMasterDataProvider.GetGeneralItemEcommerceDataByItemNumber(item);
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
        public IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMasterEComImages(GeneralItemMaster item)
        {
            IBaseEntityResponse<GeneralItemMaster> entityResponse = new BaseEntityResponse<GeneralItemMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMasterBR.DeleteGeneralItemBarcodesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMasterDataProvider.DeleteGeneralItemMasterEComImages(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralServiceItemList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralServiceItemList(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterForSaleUOMBySearchWord(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetGeneralItemMasterForSaleUOMBySearchWord(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListWithCompoundTax(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetVendorWiseItemSearchListWithCompoundTax(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }
        public IBaseEntityCollectionResponse<GeneralItemMaster> GetCCRMPartNoSearchList(GeneralItemMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMaster> GeneralItemMasterCollection = new BaseEntityCollectionResponse<GeneralItemMaster>();
            try
            {
                if (_GeneralItemMasterDataProvider != null)
                    GeneralItemMasterCollection = _GeneralItemMasterDataProvider.GetCCRMPartNoSearchList(searchRequest);
                else
                {
                    GeneralItemMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMasterCollection;
        }

    }
}
