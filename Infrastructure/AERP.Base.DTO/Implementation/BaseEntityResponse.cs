using System.Collections.Generic;

namespace AERP.Base.DTO
{
    public class BaseEntityResponse<T> : IBaseEntityResponse<T> where T : IBaseDTO
    {
        public BaseEntityResponse()
        {
            this.Message = new List<IMessageDTO>();
        }

        public T Entity
        {
            get;
            set;
        }

        public IList<IMessageDTO> Message
        {
            get;
            set;
        }
    }
}