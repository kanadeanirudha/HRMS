using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ICCRMCallTrack_Web_API_DataProvider
    {
        IBaseEntityResponse<CCRMCallTrack> InsertCallTrack(CCRMCallTrack item); 
    }
}
