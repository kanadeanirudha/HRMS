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
    public class ESICMonthlyUploadingFileBA : IESICMonthlyUploadingFileBA
    {
        IESICMonthlyUploadingFileDataProvider _ESICMonthlyUploadingFileDataProvider;
      //  IESICMonthlyUploadingFileBR _generalRegionMasterBR;
        private ILogger _logException;

        public ESICMonthlyUploadingFileBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //_generalRegionMasterBR = new ESICMonthlyUploadingFileBR();
            _ESICMonthlyUploadingFileDataProvider = new ESICMonthlyUploadingFileDataProvider();
        }

        public IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileDataList(ESICMonthlyUploadingFileSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> ESICMonthlyUploadingFileCollection = new BaseEntityCollectionResponse<ESICMonthlyUploadingFile>();
            try
            {
                if (_ESICMonthlyUploadingFileDataProvider != null)
                    ESICMonthlyUploadingFileCollection = _ESICMonthlyUploadingFileDataProvider.GetESICMonthlyUploadingFileDataList(searchRequest);
                else
                {
                    ESICMonthlyUploadingFileCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ESICMonthlyUploadingFileCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ESICMonthlyUploadingFileCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ESICMonthlyUploadingFileCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ESICMonthlyUploadingFileCollection;
        }
        public IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileDataListForParticularsMonthWise(ESICMonthlyUploadingFileSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> ESICMonthlyUploadingFileCollection = new BaseEntityCollectionResponse<ESICMonthlyUploadingFile>();
            try
            {
                if (_ESICMonthlyUploadingFileDataProvider != null)
                    ESICMonthlyUploadingFileCollection = _ESICMonthlyUploadingFileDataProvider.GetESICMonthlyUploadingFileDataListForParticularsMonthWise(searchRequest);
                else
                {
                    ESICMonthlyUploadingFileCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ESICMonthlyUploadingFileCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ESICMonthlyUploadingFileCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ESICMonthlyUploadingFileCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ESICMonthlyUploadingFileCollection;
        }
        public IBaseEntityResponse<ESICMonthlyUploadingFile> InsertESICMonthlyUploadingFile(ESICMonthlyUploadingFile item)
        {
            IBaseEntityResponse<ESICMonthlyUploadingFile> entityResponse = new BaseEntityResponse<ESICMonthlyUploadingFile>();
            try
            {
                if (_ESICMonthlyUploadingFileDataProvider != null)
                {
                    entityResponse = _ESICMonthlyUploadingFileDataProvider.InsertESICMonthlyUploadingFile(item);
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