using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AERP.ExceptionManager
{
    public interface ILogger
    {
        void Info(object message);

        void Warn(object message);

        void Debug(object message);

        void Error(object message, Exception ex);

        void Error(Exception ex);

        void Error(object message);

        void Fatal(object message);

        void Fatal(object message, Exception ex);

    }
}
