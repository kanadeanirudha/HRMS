using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AERP.Base.DTO
{
    public interface IMessageDTO
    {
        int ErrorID { get; set; }

        string ExcelEmpID { get; set; }

        string Title { get; set; }

        string ErrorMessage { get; set; }

        MessageTypeEnum MessageType { get; set; }

    }
}
