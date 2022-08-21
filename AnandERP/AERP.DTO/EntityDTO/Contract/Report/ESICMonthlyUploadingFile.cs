using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ESICMonthlyUploadingFile : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string ExcelFile
        {
            get;set;
        }

        public string ExcelSheetName
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get; set;
        }
        public string EmployeeFathersFullName
        {
            get; set;
        }
        public string ESICNumber
        {
            get; set;
        }
        public byte MonthName
        {
            get; set;
        }
        public string MonthFullName
        {
            get; set;
        }
        public byte WorkingDays
        {
            get; set;
        }
        public string Monthyear
        {
            get; set;
        }
        public decimal TotalAmountofWages
        {
            get;set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

    }
}
