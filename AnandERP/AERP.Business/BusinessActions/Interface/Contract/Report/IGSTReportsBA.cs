using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGSTReportsBA
    {
        IBaseEntityCollectionResponse<GSTReports> GetGSTR1ReportsDataList(GSTReportsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GSTReports> GetGSTR2ReportsDataList(GSTReportsSearchRequest searchRequest);

    }
}
