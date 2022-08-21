using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AERP.Base.DTO
{
    public class Email : IEmail
    {
        # region Private Members

        private string _fromAddress = string.Empty;
        private string _toAddress = string.Empty;
        private string _subject = string.Empty;
        private string _emailBody = string.Empty;
        private string _displayName = string.Empty;
        private string _ccAddress = string.Empty;
        private string _bccAddress = string.Empty;

        # endregion

        # region Email Properties

        public string FromAddress
        {
            get { return _fromAddress; }
            set { _fromAddress = value; }
        }

        public string ToAddress
        {
            get { return _toAddress; }
            set { _toAddress = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string EmailBody
        {
            get { return _emailBody; }
            set { _emailBody = value; }
        }

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public string CcAddress
        {
            get { return _ccAddress; }
            set { _ccAddress = value; }
        }

        public string BccAddress
        {
            get { return _bccAddress; }
            set { _bccAddress = value; }
        }

        public List<string> EmailAttachment
        {
            get;
            set;
        }

        public string LoginUserMailID
        {
            get;
            set;
        }

        # endregion

        public Email()
        {
        }
    }
}
