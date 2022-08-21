using System.Collections.Generic;
namespace AERP.Base.DTO
{
    public class BaseResponse : IBaseResponse
    {
        public BaseResponse()
        {
            Message = new List<MessageDTO>();
        }

        public List<MessageDTO> Message
        {
            get;
            set;
        }
    }
}
