using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractAttendanceBA
    {
        IBaseEntityCollectionResponse<SaleContractAttendance> GetMonthListBySaleContractMaster(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendance(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForAttendanceDate(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendance(SaleContractAttendance item);
        IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForMonthWise(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendanceMonthWise(SaleContractAttendance item);
        IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendanceMonthWise(SaleContractAttendanceSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SaleContractAttendance> GetSaleContractAttendanceSpanWise(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractAttendance> GetSpanListBySaleContractMaster(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractAttendance> GetAttendanceListForSpanWise(SaleContractAttendanceSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractAttendance> InsertSaleContractAttendanceSpanWise(SaleContractAttendance item);

        IBaseEntityResponse<SaleContractAttendance> InsertSaleContractSplitSalarySpan(SaleContractAttendance item);

        IBaseEntityResponse<SaleContractAttendance> GetSalaryForManPowerItem(SaleContractAttendance item);
        IBaseEntityResponse<SaleContractAttendance> InsertSalaryForManPowerItem(SaleContractAttendance item); 
    }
}
