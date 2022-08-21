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
    public class SaleContractMasterBA : ISaleContractMasterBA
    {
        ISaleContractMasterDataProvider _SaleContractMasterDataProvider;
        ISaleContractMasterBR _SaleContractMasterBR;
        private ILogger _logException;

        public SaleContractMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractMasterBR = new SaleContractMasterBR();
            _SaleContractMasterDataProvider = new SaleContractMasterDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetSaleContractMasterBySearch(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetSaleContractMasterBySearch(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityResponse<SaleContractMaster> InsertSaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractMasterBR.InsertSaleContractMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractMasterDataProvider.InsertSaleContractMaster(item);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetContractNumberSearchList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetContractNumberSearchList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityResponse<SaleContractMaster> GetGeneralContractDetails(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider!=null)
                {
                    entityResponse = _SaleContractMasterDataProvider.GetGeneralContractDetails(item);
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

        public IBaseEntityResponse<SaleContractMaster> GetTermDetailsData(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                {
                    entityResponse = _SaleContractMasterDataProvider.GetTermDetailsData(item);
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

        public IBaseEntityCollectionResponse<SaleContractMaster> GetManPowerItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetManPowerItemList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetAssignedEmployeeList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetAssignedEmployeeList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetContractMaterialList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetContractMaterialList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetMachineMasterList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetMachineMasterList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetJobWorkItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetJobWorkItemList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetFixItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetFixItemList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetServiceChargeList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetServiceChargeList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetServiceChargeOnAllowanceList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetServiceChargeOnAllowanceList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetOverTimeList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetOverTimeList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetOverTimeFixList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetOverTimeFixList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetServiceItemList(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetServiceItemList(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityCollectionResponse<SaleContractMaster> GetContractNumberSearchListByCustomer(SaleContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractMaster> SaleContractMasterCollection = new BaseEntityCollectionResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                    SaleContractMasterCollection = _SaleContractMasterDataProvider.GetContractNumberSearchListByCustomer(searchRequest);
                else
                {
                    SaleContractMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractMasterCollection;
        }

        public IBaseEntityResponse<SaleContractMaster> ModifySaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                {
                    entityResponse = _SaleContractMasterDataProvider.ModifySaleContractMaster(item);
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

        public IBaseEntityResponse<SaleContractMaster> ExtendSaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                {
                    entityResponse = _SaleContractMasterDataProvider.ExtendSaleContractMaster(item);
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

        public IBaseEntityResponse<SaleContractMaster> SaleContractMasterShiftEmployee(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                {
                    entityResponse = _SaleContractMasterDataProvider.SaleContractMasterShiftEmployee(item);
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

        public IBaseEntityResponse<SaleContractMaster> RenewSaleContractMaster(SaleContractMaster item)
        {
            IBaseEntityResponse<SaleContractMaster> entityResponse = new BaseEntityResponse<SaleContractMaster>();
            try
            {
                if (_SaleContractMasterDataProvider != null)
                {
                    entityResponse = _SaleContractMasterDataProvider.RenewSaleContractMaster(item);
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
    }
}