using System.Collections.Generic;
namespace AERP.Base.DTO
{
    public class BaseEntityCollectionResponse<T> : IBaseEntityCollectionResponse<T> where T : IBaseDTO
    {
        public BaseEntityCollectionResponse()
        {
            this.Message = new List<IMessageDTO>();
        }

        public IList<T> CollectionResponse
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        public ICollection<IMessageDTO> Message
        {
            get;
            set;
        }

        public int TotalRecords
        {
            get;
            set;
        }
        public int AccessLevel
        {
            get;
            set;
        }


    }
}