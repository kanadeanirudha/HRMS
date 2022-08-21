using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IESICMonthlyUploadingFileDataProvider
    {
        IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileDataList(ESICMonthlyUploadingFileSearchRequest searchRequest);
        IBaseEntityCollectionResponse<ESICMonthlyUploadingFile> GetESICMonthlyUploadingFileDataListForParticularsMonthWise(ESICMonthlyUploadingFileSearchRequest searchRequest);
        IBaseEntityResponse<ESICMonthlyUploadingFile> InsertESICMonthlyUploadingFile(ESICMonthlyUploadingFile item);
    }
}
