using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AERP.Base.DTO
{
    public interface IBaseEntityCollectionResponse<T> where T : IBaseDTO
    {
        IList<T> CollectionResponse { get; set; }

        ICollection<IMessageDTO> Message { get; set; }

        Int32 TotalRecords { get; set; }

        Int32 AccessLevel { get; set; }


    }
}
