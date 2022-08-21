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
    public class SaleContractServiceItemAttendanceBA : ISaleContractServiceItemAttendanceBA
    {
        ISaleContractServiceItemAttendanceDataProvider _SaleContractServiceItemAttendanceDataProvider;
        private ILogger _logException;

        public SaleContractServiceItemAttendanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractServiceItemAttendanceDataProvider = new SaleContractServiceItemAttendanceDataProvider();
        }

        /// <summary>
        /// Create new record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractServiceItemAttendance> InsertSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item)
        {
            IBaseEntityResponse<SaleContractServiceItemAttendance> entityResponse = new BaseEntityResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractServiceItemAttendanceDataProvider.InsertSaleContractServiceItemAttendance(item);
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
        /// Update a specific record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractServiceItemAttendance> UpdateSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item)
        {
            IBaseEntityResponse<SaleContractServiceItemAttendance> entityResponse = new BaseEntityResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractServiceItemAttendanceDataProvider.UpdateSaleContractServiceItemAttendance(item);
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
        /// Delete a selected record from SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractServiceItemAttendance> DeleteSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item)
        {
            IBaseEntityResponse<SaleContractServiceItemAttendance> entityResponse = new BaseEntityResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractServiceItemAttendanceDataProvider.DeleteSaleContractServiceItemAttendance(item);
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
        /// Select all record from SaleContractServiceItemAttendance table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetBySearch(SaleContractServiceItemAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractServiceItemAttendanceDataProvider.GetSaleContractServiceItemAttendanceBySearch(searchRequest);
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
        /// Select all record from SaleContractServiceItemAttendance table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetBySearchList(SaleContractServiceItemAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractServiceItemAttendanceDataProvider.GetSaleContractServiceItemAttendanceGetBySearchList(searchRequest);
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
        /// Select a record from SaleContractServiceItemAttendance table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractServiceItemAttendance> SelectByID(SaleContractServiceItemAttendance item)
        {

            IBaseEntityResponse<SaleContractServiceItemAttendance> entityResponse = new BaseEntityResponse<SaleContractServiceItemAttendance>();
            try
            {
                entityResponse = _SaleContractServiceItemAttendanceDataProvider.GetSaleContractServiceItemAttendanceByID(item);
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

        public IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetMachineMasterBySearchWord(SaleContractServiceItemAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractServiceItemAttendanceDataProvider.GetMachineMasterBySearchWord(searchRequest);
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

        public IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetListSaleContractServiceItemAttendance(SaleContractServiceItemAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractServiceItemAttendanceDataProvider.GetListSaleContractServiceItemAttendance(searchRequest);
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


         public IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetListSaleContractMachineAttendance(SaleContractServiceItemAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    categoryMasterCollection = _SaleContractServiceItemAttendanceDataProvider.GetListSaleContractMachineAttendance(searchRequest);
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

        public IBaseEntityResponse<SaleContractServiceItemAttendance> RemoveSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item)
        {
            IBaseEntityResponse<SaleContractServiceItemAttendance> entityResponse = new BaseEntityResponse<SaleContractServiceItemAttendance>();
            try
            {
                if (_SaleContractServiceItemAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractServiceItemAttendanceDataProvider.RemoveSaleContractServiceItemAttendance(item);
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