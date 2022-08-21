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
    public class PurchaseReportMasterBA : IPurchaseReportMasterBA
    {
        IPurchaseReportMasterDataProvider _PurchaseReportMasterDataProvider;
        IPurchaseReportMasterBR _PurchaseReportMasterBR;
        private ILogger _logException;

        public PurchaseReportMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PurchaseReportMasterBR = new PurchaseReportMasterBR();
            _PurchaseReportMasterDataProvider = new PurchaseReportMasterDataProvider();
        }

        // PurchaseReportMaster Method
        #region PurchaseReportMaster

        /// Create new record of PurchaseReportMaster.        
        public IBaseEntityResponse<PurchaseReportMaster> InsertPurchaseReportMaster(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> entityResponse = new BaseEntityResponse<PurchaseReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReportMasterBR.InsertPurchaseReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReportMasterDataProvider.InsertPurchaseReportMaster(item);
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

        /// Update a specific record  of PurchaseReportMaster.       
        public IBaseEntityResponse<PurchaseReportMaster> UpdatePurchaseReportMaster(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> entityResponse = new BaseEntityResponse<PurchaseReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReportMasterBR.UpdatePurchaseReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReportMasterDataProvider.UpdatePurchaseReportMaster(item);
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

        /// Delete a selected record from PurchaseReportMaster.        
        public IBaseEntityResponse<PurchaseReportMaster> DeletePurchaseReportMaster(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> entityResponse = new BaseEntityResponse<PurchaseReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReportMasterBR.DeletePurchaseReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReportMasterDataProvider.DeletePurchaseReportMaster(item);
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

        
        /// Select a record from PurchaseReportMaster table by ID        
        public IBaseEntityResponse<PurchaseReportMaster> SelectPurchaseReportMasterByID(PurchaseReportMaster item)
        {
            IBaseEntityResponse<PurchaseReportMaster> entityResponse = new BaseEntityResponse<PurchaseReportMaster>();
            try
            {
                entityResponse = _PurchaseReportMasterDataProvider.GetPurchaseReportMasterByID(item);
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

        // Select all record from PurchaseReportMaster table to search list.
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetPurchaseReportMasterSearchList(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> PurchaseReportMasterCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    PurchaseReportMasterCollection = _PurchaseReportMasterDataProvider.GetPurchaseReportMasterSearchList(searchRequest);
                else
                {
                    PurchaseReportMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReportMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReportMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReportMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReportMasterCollection;
        }


        /// Select all record from item wise consumption.        
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetArticalMovementReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> ArticalMovementCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    ArticalMovementCollection = _PurchaseReportMasterDataProvider.GetArticalMovementReport(searchRequest);
                else
                {
                    ArticalMovementCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ArticalMovementCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ArticalMovementCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ArticalMovementCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ArticalMovementCollection;
        }

        /// Select all record GetLocationWiseCurrentStockReport    
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetLocationWiseCurrentStockReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> DailyRateChangeCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    DailyRateChangeCollection = _PurchaseReportMasterDataProvider.GetLocationWiseCurrentStockReport(searchRequest);
                else
                {
                    DailyRateChangeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DailyRateChangeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DailyRateChangeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DailyRateChangeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DailyRateChangeCollection;
        }


        /// Select all record from Dump And Shrink Report.        
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetStockConsumptionReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> DumpAndShrinkReportCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    DumpAndShrinkReportCollection = _PurchaseReportMasterDataProvider.GetStockConsumptionReport(searchRequest);
                else
                {
                    DumpAndShrinkReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DumpAndShrinkReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DumpAndShrinkReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DumpAndShrinkReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DumpAndShrinkReportCollection;
        }

        ///   For DailyItemRateChange Report     
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetDailyItemRateChangeReportBySearch(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> DailyRateChangeCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    DailyRateChangeCollection = _PurchaseReportMasterDataProvider.GetDailyItemRateChangeReportBySearch(searchRequest);
                else
                {
                    DailyRateChangeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DailyRateChangeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DailyRateChangeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DailyRateChangeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DailyRateChangeCollection;
        }


        //For Below Indend Level Report.                
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetBelowIndendLevelReportBySearch(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> BelowIndendLevelReportCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    BelowIndendLevelReportCollection = _PurchaseReportMasterDataProvider.GetBelowIndendLevelReportBySearch(searchRequest);
                else
                {
                    BelowIndendLevelReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BelowIndendLevelReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BelowIndendLevelReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BelowIndendLevelReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BelowIndendLevelReportCollection;
        }
        //For Item order Status Report
                    
        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetItemOrderStatusList(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> BelowIndendLevelReportCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    BelowIndendLevelReportCollection = _PurchaseReportMasterDataProvider.GetItemOrderStatusList(searchRequest);
                else
                {
                    BelowIndendLevelReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BelowIndendLevelReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BelowIndendLevelReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BelowIndendLevelReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BelowIndendLevelReportCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseReportMaster> GetInventoryPurchaseStockReport(PurchaseReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReportMaster> ArticalMovementCollection = new BaseEntityCollectionResponse<PurchaseReportMaster>();
            try
            {
                if (_PurchaseReportMasterDataProvider != null)
                    ArticalMovementCollection = _PurchaseReportMasterDataProvider.GetInventoryPurchaseStockReport(searchRequest);
                else
                {
                    ArticalMovementCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ArticalMovementCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ArticalMovementCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ArticalMovementCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ArticalMovementCollection;
        }

        #endregion

    }
}
