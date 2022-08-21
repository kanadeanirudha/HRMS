using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AERP.Base.DTO;

namespace AERP.Infrastructure
{
    public interface IExcelValidation
    {
        string GetFileName(string fileNameContains);

        DataTable GetDataFromExcel(string fileName);

        bool Isvalid(DataRow dr, string columnName, string type, ref List<MessageDTO> lstExceptionInfo, string empIdColumn, bool requiredField);
    }
}
