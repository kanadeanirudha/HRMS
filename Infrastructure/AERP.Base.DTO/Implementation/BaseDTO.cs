using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AERP.Base.DTO
{
    public class BaseDTO : IBaseDTO
    {
        public string Locale
        {
            get;
            set;
        }

        public string ConnectionString
        {
            get;
            set;
        }
        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; }


    }
}
