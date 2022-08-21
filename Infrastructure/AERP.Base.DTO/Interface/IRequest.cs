
using System;
namespace AERP.Base.DTO
{
    public interface IRequest
    {
        int UserId { get; set; }

        string UserName { get; set; }

        int PageSize { get; set; }

        int PageNo { get; set; }

        Guid? ZtechCreator { get; set; }

        Guid? ZtechModificator { get; set; }

        string ConnectionString
        {
            get;
            set;
        }
    }
}
