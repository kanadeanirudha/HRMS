using System;
using System.Collections.Generic;

namespace AERP.Base.DTO
{
    public class MessageDTO : IMessageDTO
    {
        public int ErrorID
        {
            get;
            set;
        }

        public string ExcelEmpID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public MessageTypeEnum MessageType
        {
            get;
            set;
        }
    }
}