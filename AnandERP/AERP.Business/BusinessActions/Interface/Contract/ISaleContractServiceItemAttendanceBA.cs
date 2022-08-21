using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractServiceItemAttendanceBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> InsertSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);

        /// <summary>
        /// business action interface of update record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> UpdateSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);

        /// <summary>
        /// business action interface of dalete record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> DeleteSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);

        /// <summary>
        /// business action interface of select all record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetBySearch(SaleContractServiceItemAttendanceSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetBySearchList(SaleContractServiceItemAttendanceSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> SelectByID(SaleContractServiceItemAttendance item);
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetMachineMasterBySearchWord(SaleContractServiceItemAttendanceSearchRequest searchRequest);


        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetListSaleContractServiceItemAttendance(SaleContractServiceItemAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetListSaleContractMachineAttendance(SaleContractServiceItemAttendanceSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractServiceItemAttendance> RemoveSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item); 
    }
}
