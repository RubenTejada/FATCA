using BPD.FATCA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPD.FATCA.Procesor
{
   public class SessionApplicationLog : IApplicationLog
    {
        List<string> sessionMessages;

        public SessionApplicationLog()
        {
            sessionMessages = new List<string>();
        }

        public void LogError(Exception ex, string message)
        {
            sessionMessages.Add(String.Concat(ex.Message, " ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => "), message));
        }

        public void LogMessage(string message)
        {
            sessionMessages.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss => ") + message);
        }

        public void LogWarnign(string message)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ProcessLogs()
        {
            return sessionMessages;
        }
    }
}
