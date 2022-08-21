using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPeriodTypeMasterSearchRequest : Request
    {
        public int GeneralPeriodTypeMasterID { get; set; }
        public string PeriodType { get; set; }
        public Int16 NumberOfDays { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
    }
}
  