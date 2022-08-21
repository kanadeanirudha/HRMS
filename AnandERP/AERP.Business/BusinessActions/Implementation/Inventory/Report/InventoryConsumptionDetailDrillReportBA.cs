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
    public class InventoryConsumptionDetailDrillReportBA : IInventoryConsumptionDetailDrillReportBA
    {
        IInventoryConsumptionDetailDrillReportDataProvider _InventoryConsumptionDetailDrillReportDataProvider;
        private ILogger _logException;
        public InventoryConsumptionDetailDrillReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryConsumptionDetailDrillReportDataProvider = new InventoryConsumptionDetailDrillReportDataProvider();
        }

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
         public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetGeneralUnitsDropdownForProccesingUnit(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetGeneralUnitsDropdownForProccesingUnit(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        //----------------------------------------------Sale and Wastage------------------------------------------------
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventorySaleandWastageReportBySearch_GroupDescription(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }

        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
        public IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_ItemDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> InventoryConsumptionDetailDrillReportCollection = new BaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport>();
            try
            {
                if (_InventoryConsumptionDetailDrillReportDataProvider != null)
                    InventoryConsumptionDetailDrillReportCollection = _InventoryConsumptionDetailDrillReportDataProvider.GetInventorySaleandWastageReportBySearch_ItemDescription(searchRequest);
                else
                {
                    InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryConsumptionDetailDrillReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryConsumptionDetailDrillReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryConsumptionDetailDrillReportCollection;
        }
       
    }
}



