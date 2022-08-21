using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AERP.Base.DTO
{
    interface IEmail
    {
        string FromAddress
        {
            get;
            set;
        }

        string ToAddress
        {
            get;
            set;
        }

        string Subject
        {
            get;
            set;
        }

        string EmailBody
        {
            get;
            set;
        }

        string DisplayName
        {
            get;
            set;
        }

        string CcAddress
        {
            get;
            set;
        }

        string BccAddress
        {
            get;
            set;
        }

        List<string> EmailAttachment
        {
            get;
            set;
        }

        string LoginUserMailID
        {
            get;
            set;
        }
    }
}
