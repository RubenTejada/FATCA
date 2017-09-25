using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FATCA.Interfaces
{
   public interface IApplicationLog
    {
        void LogMessage(string message);
        void LogWarnign(string message);
        void LogError(Exception ex, string message);
        IEnumerable<string> ProcessLogs();
    }
}
