using System.Collections.Generic;

namespace AERP.Base.DTO
{
    public interface IBaseResponse
    {
        List<MessageDTO> Message
        {
            get;
            set;
        }
    }
}
