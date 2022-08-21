
using System;
namespace AERP.Base.DTO
{
    public class Request : IRequest
    {
        public int UserId
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }


        public int RoleId
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public int PageNo
        {
            get;
            set;
        }

        public Guid? ZtechCreator
        {
            get;
            set;
        }

        public Guid? ZtechModificator
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }
    }
}
