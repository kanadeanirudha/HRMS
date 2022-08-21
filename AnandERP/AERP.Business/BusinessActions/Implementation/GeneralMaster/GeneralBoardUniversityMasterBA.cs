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
namespace AMS.Business.BusinessAction
{
    public class GeneralBoardUniversityMasterBA : IGeneralBoardUniversityMasterBA
    {
        IGeneralBoardUniversityMasterDataProvider _generalBoardUniversityMasterDataProvider;
        IGeneralBoardUniversityMasterBR _generalBoardUniversityMasterBR;
        private ILogger _logException;
        public GeneralBoardUniversityMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalBoardUniversityMasterBR = new GeneralBoardUniversityMasterBR();
            _generalBoardUniversityMasterDataProvider = new GeneralBoardUniversityMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralBoardUniversityMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralBoardUniversityMaster> InsertGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item)
        {
            IBaseEntityResponse<GeneralBoardUniversityMaster> entityResponse = new BaseEntityResponse<GeneralBoardUniversityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalBoardUniversityMasterBR.InsertGeneralBoardUniversityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalBoardUniversityMasterDataProvider.InsertGeneralBoardUniversityMaster(item);
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
        /// Update a specific record  of GeneralBoardUniversityMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralBoardUniversityMaster> UpdateGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item)
        {
            IBaseEntityResponse<GeneralBoardUniversityMaster> entityResponse = new BaseEntityResponse<GeneralBoardUniversityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalBoardUniversityMasterBR.UpdateGeneralBoardUniversityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalBoardUniversityMasterDataProvider.UpdateGeneralBoardUniversityMaster(item);
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
        /// Delete a selected record from GeneralBoardUniversityMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralBoardUniversityMaster> DeleteGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item)
        {
            IBaseEntityResponse<GeneralBoardUniversityMaster> entityResponse = new BaseEntityResponse<GeneralBoardUniversityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalBoardUniversityMasterBR.DeleteGeneralBoardUniversityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalBoardUniversityMasterDataProvider.DeleteGeneralBoardUniversityMaster(item);
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
        /// Select all record from GeneralBoardUniversityMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetBySearch(GeneralBoardUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterCollection = new BaseEntityCollectionResponse<GeneralBoardUniversityMaster>();
            try
            {
                if (_generalBoardUniversityMasterDataProvider != null)
                    GeneralBoardUniversityMasterCollection = _generalBoardUniversityMasterDataProvider.GetGeneralBoardUniversityMasterBySearch(searchRequest);
                else
                {
                    GeneralBoardUniversityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralBoardUniversityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralBoardUniversityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralBoardUniversityMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralBoardUniversityMasterCollection;
        }
        /// <summary>
        /// Select all record from GeneralBoardUniversityMaster table with search.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetBySearchList(GeneralBoardUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterCollection = new BaseEntityCollectionResponse<GeneralBoardUniversityMaster>();
            try
            {
                if (_generalBoardUniversityMasterDataProvider != null)
                    GeneralBoardUniversityMasterCollection = _generalBoardUniversityMasterDataProvider.GetGeneralBoardUniversityMasterBySearchList(searchRequest);
                else
                {
                    GeneralBoardUniversityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralBoardUniversityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralBoardUniversityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralBoardUniversityMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralBoardUniversityMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralBoardUniversityMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralBoardUniversityMaster> SelectByID(GeneralBoardUniversityMaster item)
        {
            IBaseEntityResponse<GeneralBoardUniversityMaster> entityResponse = new BaseEntityResponse<GeneralBoardUniversityMaster>();
            try
            {
                entityResponse = _generalBoardUniversityMasterDataProvider.GetGeneralBoardUniversityMasterByID(item);
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
