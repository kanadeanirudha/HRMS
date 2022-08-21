using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractServiceItemAttendanceDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetSaleContractServiceItemAttendanceBySearch(SaleContractServiceItemAttendanceSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetSaleContractServiceItemAttendanceGetBySearchList(SaleContractServiceItemAttendanceSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> GetSaleContractServiceItemAttendanceByID(SaleContractServiceItemAttendance item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> InsertSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);

        /// <summary>
        /// data provider interface of update record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> UpdateSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractServiceItemAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractServiceItemAttendance> DeleteSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetMachineMasterBySearchWord(SaleContractServiceItemAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetListSaleContractServiceItemAttendance(SaleContractServiceItemAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractServiceItemAttendance> GetListSaleContractMachineAttendance(SaleContractServiceItemAttendanceSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractServiceItemAttendance> RemoveSaleContractServiceItemAttendance(SaleContractServiceItemAttendance item);
    }
}
